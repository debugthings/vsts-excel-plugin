USE LoadTest2010;
GO
CREATE procedure [dbo].[Pbx_RebuildIndexes]  
as  
begin  
  
  
DECLARE @Database VARCHAR(255)     
DECLARE @Table VARCHAR(255)    
DECLARE @cmd NVARCHAR(500)    
DECLARE @fillfactor INT   
  
SET @fillfactor = 90   
SET @Database = 'LoadTest2010'  
  
SET @cmd = 'DECLARE TableCursor CURSOR FOR SELECT ''['' + table_catalog + ''].['' + table_schema + ''].['' +   
table_name + '']'' as tableName FROM ' + @Database + '.INFORMATION_SCHEMA.TABLES   
WHERE table_type = ''BASE TABLE'''     
  
-- create table cursor    
EXEC (@cmd)    
OPEN TableCursor     
  
FETCH NEXT FROM TableCursor INTO @Table     
WHILE @@FETCH_STATUS = 0     
BEGIN     
  
   IF (@@MICROSOFTVERSION / POWER(2, 24) >= 9)  
   BEGIN  
  select 'Rebuilding for table ' + @Table  
       -- SQL 2005 or higher command   
    if @Table <> '[LoadTest2010].[dbo].[LoadTestPerformanceCounterSample]'  
    begin  
       SET @cmd = 'ALTER INDEX ALL ON ' + @Table + ' REBUILD WITH (FILLFACTOR = ' + CONVERT(VARCHAR(3),@fillfactor) + ')'   
       EXEC (@cmd)   
    end  
   END  
   ELSE  
   BEGIN  
      -- SQL 2000 command   
      DBCC DBREINDEX(@Table,' ',@fillfactor)    
   END  
  
   FETCH NEXT FROM TableCursor INTO @Table     
END     
  
CLOSE TableCursor     
DEALLOCATE TableCursor    
end  
     
  