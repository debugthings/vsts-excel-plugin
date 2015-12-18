USE LoadTest2010;
GO 
CREATE procedure [dbo].[Pbx_DeleteLoadTestsLessThan15MinutesDuration]  
as  
begin  
set nocount on  
declare @runID int  
declare @RC int  
declare curRunIds cursor for  
select LoadTestRunId   
from dbo.LoadTestRun  
where (EndTime - StartTime) < '1900-01-01 00:15:00'  
open curRunIds  
fetch next from curRunIds into @runID  
while @@FETCH_STATUS = 0  
 begin  
  execute @RC = [LoadTest2010].[dbo].[Prc_DeleteLoadTestRun]   
   @runID  
 end  
close curRunIds  
deallocate curRunIds  
set nocount off  
end  