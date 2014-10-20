CREATE PROCEDURE [dbo].[Pbx_GetAgents] @LoadTestRunId int  
AS  
SELECT DISTINCT AgentName   
FROM LoadTestRunAgent  
WHERE LoadTestRunId = @LoadTestRunId  
