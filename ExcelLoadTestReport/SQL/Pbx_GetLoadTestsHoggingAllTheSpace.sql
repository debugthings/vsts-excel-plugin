USE LoadTest2010;
GO
CREATE procedure [dbo].[Pbx_GetLoadTestsHoggingAllTheSpace]  
as  
begin  
set nocount on  
declare @tableName varchar(255)  
declare curLoadTestTables cursor for  
select t.name from   
 sys.tables t  
 where t.object_id in (select c.object_id   
       from sys.all_columns c  
        where c.name = 'LoadTestRunId')  
open curLoadTestTables  
declare @tableSizeInformation table  
(  
    tableName varchar(100),  
    numberofRows varchar(100),  
    reservedSize varchar(50),  
    dataSize varchar(50),  
    indexSize varchar(50),  
    unusedSize varchar(50)  
)  
declare @tableSizeInfoNumbers table  
(  
    tableName varchar(100),  
    numberofRows bigint,  
    reservedSize float,  
    dataSize float,  
    indexSize float,  
    unusedSize float,  
    KBsPerRow float  
)  
declare @tsiTableName varchar(255)  
declare @tsinumberofRows varchar(100)  
declare @tsireservedSize varchar(50)  
declare @tsidataSize varchar(50)  
declare @tsiindexSize varchar(50)  
declare @tsiunusedSize varchar(50)  
declare @tsinTableName varchar(255)  
declare @tsinnumberofRows bigint  
declare @tsinreservedSize float  
declare @tsindataSize float  
declare @tsinindexSize float  
declare @tsinunusedSize float  
declare @tsinKBsPerRow float  
fetch next from curLoadTestTables into @tableName  
while @@FETCH_STATUS = 0  
 begin  
  insert @tableSizeInformation exec sp_spaceused @tableName  
  fetch next from curLoadTestTables into @tableName  
 end  
close curLoadTestTables  
deallocate curLoadTestTables  
declare curLoadTestTables cursor for  
 select * from @tableSizeInformation  
open curLoadTestTables  
fetch next from curLoadTestTables  
 into @tsiTableName, @tsinumberofRows, @tsireservedSize, @tsidataSize, @tsiindexSize, @tsiunusedSize  
while @@FETCH_STATUS = 0  
 begin  
  set @tsinTableName = @tsiTableName  
  set @tsinnumberofRows = convert(bigint, @tsinumberofRows)  
  set @tsinreservedSize = (CONVERT(float, substring(@tsireservedSize, 1, PATINDEX('% KB', @tsireservedSize))))-- / (1048576))  
  set @tsindataSize = (CONVERT(float, substring(@tsidataSize, 1, PATINDEX('% KB', @tsidataSize)))) -- / (1048576))  
  set @tsinindexSize = (CONVERT(float, substring(@tsiindexSize, 1, PATINDEX('% KB', @tsiindexSize)))) -- / (1048576))  
  set @tsinunusedSize = (CONVERT(float, substring(@tsiunusedSize, 1, PATINDEX('% KB', @tsiunusedSize)))) -- / (1048576))  
  if @tsinnumberofRows = 0  
   begin  
    set @tsinKBsPerRow = 0  
   end  
  else  
   begin  
    set @tsinKBsPerRow = (@tsindataSize + @tsinindexSize) / CONVERT(float, @tsinnumberofRows)  
   end  
  insert into @tableSizeInfoNumbers  
   (tableName, numberofRows, reservedSize, dataSize, indexSize, unusedSize, KBsPerRow)  
    values   
     (@tsinTableName, @tsinnumberofRows, @tsinreservedSize, @tsindataSize,  
     @tsinindexSize, @tsinunusedSize, @tsinKBsPerRow)  
  fetch next from curLoadTestTables  
   into @tsiTableName, @tsinumberofRows, @tsireservedSize, @tsidataSize, @tsiindexSize, @tsiunusedSize  
 end  
close curLoadTestTables  
deallocate curLoadTestTables  
declare @loadTestName varchar(255)  
declare @loadTestRunID int  
declare @count bigint  
declare @testStart datetime  
declare @testEnd datetime  
declare @duration int  
declare @comment varchar(max)  
declare curLoadTest cursor for  
 select LoadTestRunId, LoadTestName, StartTime, EndTime, RunDuration, Comment  
  from dbo.LoadTestRun   
open curLoadTest  
fetch next from curLoadTest   
 into @loadTestRunID, @loadTestName, @testStart, @testEnd, @duration, @comment   
  
  
declare @currentTableName varchar(255)  
declare @numberofRows bigint  
declare @reservedSize float  
declare @dataSize float  
declare @indexSize float  
declare @unusedSize float  
declare @KBsPerRow float  
declare @sql varchar(999)  
if exists(select * from sys.tables where name = 'Pbx_Tmp_LT_Large_Size')  
 begin  
  drop table dbo.Pbx_Tmp_LT_Large_Size  
 end  
create table dbo.Pbx_Tmp_LT_Large_Size  
(  
 LoadTestRunId int,  
 LoadTestName varchar(255),  
 StartTime datetime,  
 EndTime datetime,  
 Duration int,  
 Comment varchar(max),  
 TableName varchar(255),  
 NumberRows bigint,  
 KBsPerRow float  
)   
while @@FETCH_STATUS = 0  
 begin  
  declare curLoadTestTablesSizes cursor for  
   select * from @tableSizeInfoNumbers  
  open curLoadTestTablesSizes  
  fetch next from curLoadTestTablesSizes  
   into @currentTableName, @numberofRows, @reservedSize, @dataSize, @indexSize, @unusedSize, @KBsPerRow  
  while @@FETCH_STATUS = 0  
  begin  
   Declare @find nvarchar(5)  
   Declare @replace nvarchar(5)  
     
   declare @index int = CHARINDEX(']', @comment)  
   set @comment = LEFT(@comment, @index +1)  
   set @sql =  
    'declare @rec_count int  
    set @rec_count = (select count(*) from ' + @currentTableName +'  
    (nolock) where LoadTestRunId = ' + convert(varchar, @loadTestRunID) + ')  
    insert into dbo.Pbx_Tmp_LT_Large_Size   
    (LoadTestRunId, LoadTestName, StartTime, EndTime, Duration, Comment,  
    TableName, NumberRows, KBsPerRow) values (' + convert(varchar, @loadTestRunID) + ',  
    '+ CHAR(39)+@loadTestName+CHAR(39)+', '+CHAR(39)+convert(varchar,@testStart)+CHAR(39)+', '+CHAR(39)+ convert(varchar, @testEnd)+CHAR(39)+', '+convert(varchar, @duration)+', '+CHAR(39)+@comment+CHAR(39)+  
    ', '+CHAR(39)+@currentTableName+CHAR(39)+', @rec_count,'+CHAR(39)+ convert(varchar, @KBsPerRow)+CHAR(39) +')'  
    exec(@sql)  
    fetch next from curLoadTestTablesSizes  
     into @currentTableName, @numberofRows, @reservedSize, @dataSize, @indexSize, @unusedSize, @KBsPerRow  
   end  
  close curLoadTestTablesSizes  
  deallocate curLoadTestTablesSizes  
  fetch next from curLoadTest   
   into @loadTestRunID, @loadTestName, @testStart, @testEnd, @duration, @comment   
 end  
close curLoadTest  
deallocate curLoadTest  
declare @totalDBAllocation float  
set @totalDBAllocation = (select SUM(convert(float,NumberRows) * KBsPerRow) from dbo.Pbx_Tmp_LT_Large_Size)  
  
select LoadTestRunId, LoadTestName, StartTime, EndTime, Duration, Comment,   
 SUM(convert(float,NumberRows) * KBsPerRow) DBSizeInKB,  
 (((SUM(convert(float,NumberRows) * KBsPerRow)) / @totalDBAllocation) * 100) PercentOfDBSize   
from dbo.Pbx_Tmp_LT_Large_Size  
group by LoadTestRunId, LoadTestName, StartTime, EndTime, Duration, Comment  
order by SUM(convert(float,NumberRows) * KBsPerRow) desc  
if exists(select * from sys.tables where name = 'Pbx_Tmp_LT_Large_Size')  
 begin  
  drop table dbo.Pbx_Tmp_LT_Large_Size  
 end  
set nocount off  
end