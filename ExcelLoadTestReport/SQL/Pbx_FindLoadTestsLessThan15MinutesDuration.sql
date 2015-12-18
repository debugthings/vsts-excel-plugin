USE LoadTest2010;
GO
CREATE procedure [dbo].[Pbx_FindLoadTestsLessThan15MinutesDuration]  
as  
begin  
declare @runID int  
declare @RC int  
select LoadTestRunId   
from dbo.LoadTestRun  
where (EndTime - StartTime) < '1900-01-01 00:15:00'  
end