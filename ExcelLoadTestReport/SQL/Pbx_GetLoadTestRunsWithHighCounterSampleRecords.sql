USE LoadTest2010;
GO
CREATE procedure [dbo].[Pbx_GetLoadTestRunsWithHighCounterSampleRecords]  
as  
begin  
set nocount on  
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
declare @tblTmp table  
(  
 LoadTestRunID int,  
 LoadTestName varchar(255),  
 CountOfSampleRecords bigint,  
 TestStart datetime,  
 TestEnd datetime,  
 TestDuration int,  
 Comment varchar(max)  
)  
while @@FETCH_STATUS = 0  
 begin  
 declare @index int = CHARINDEX(']', @comment)  
   set @comment = LEFT(@comment, @index +1)  
     
  set @count = (select COUNT(*)  
      from dbo.LoadTestPerformanceCounterSample  
      where LoadTestRunId = @loadTestRunID)  
  insert into @tblTmp   
   (LoadTestRunID, LoadTestName, CountOfSampleRecords, TestStart, TestEnd, TestDuration, Comment)  
   values   
    (@loadTestRunID, @loadTestName, @count, @testStart, @testEnd, @duration, @comment)  
  fetch next from curLoadTest   
   into @loadTestRunID, @loadTestName, @testStart, @testEnd, @duration, @comment   
 end  
close curLoadTest  
deallocate curLoadTest  
select * from @tblTmp order by CountOfSampleRecords desc  
set nocount off  
end