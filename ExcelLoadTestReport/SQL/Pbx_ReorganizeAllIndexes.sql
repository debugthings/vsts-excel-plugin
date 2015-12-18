USE LoadTest2010;
GO
CREATE procedure [dbo].[Pbx_ReorganizeAllIndexes]  
as  
begin  
set nocount on  
declare @tableName varchar(255)  
declare @indexName varchar(255)  
declare @sql varchar(max)  
declare curTableIndex cursor for  
select obj.Name TableName, ind.Name IndexName   
 from sys.indexes ind  
  inner join sys.objects obj  
   on ind.object_id = obj.object_id  
  inner join LoadTest2010.INFORMATION_SCHEMA.TABLES ist  
   on ist.TABLE_NAME = obj.Name  
 where ist.TABLE_TYPE = 'BASE TABLE'  
  and ind.Name is not null  
declare curTable cursor for  
select ist.TABLE_NAME  
 from LoadTest2010.INFORMATION_SCHEMA.TABLES ist  
 where ist.TABLE_TYPE = 'BASE TABLE'  
open curTableIndex  
fetch next from curTableIndex into @tableName, @indexName  
while @@FETCH_STATUS = 0  
 begin  
  set @sql = 'ALTER INDEX ' + @indexName + ' ON [LoadTest2010].[dbo].[' + @tableName + '] REORGANIZE'  
  --select @sql  
  exec (@sql)  
  fetch next from curTableIndex into @tableName, @indexName  
 end  
close curTableIndex  
deallocate curTableIndex  
open curTable  
fetch next from curTable into @tableName  
while @@FETCH_STATUS = 0  
 begin  
  set @sql = 'UPDATE STATISTICS [LoadTest2010].[dbo].[' + @tableName + ']'  
  exec (@sql)  
  fetch next from curTable into @tableName  
 end  
close curTable  
deallocate curTable  
set nocount off  
end