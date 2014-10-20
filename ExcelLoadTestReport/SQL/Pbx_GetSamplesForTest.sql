-- =============================================  
-- Author:  James Davis  
-- Create date:   
-- Description:   
-- =============================================  
CREATE PROCEDURE [dbo].[Pbx_GetSamplesForTest]   
 -- Add the parameters for the stored procedure here  
 @LoadTestId int = 0,  
 @CounterCategory nvarchar(255),  
 @CounterName nvarchar(255),  
 @InstanceName nvarchar(255),  
 @FilterAgents bit  
AS  
BEGIN  
  
CREATE TABLE #Agents   
(  
 agent VARCHAR(30),  
 PRIMARY KEY (agent)  
)  
  
IF @FilterAgents = 1  
BEGIN  
 INSERT INTO #Agents  
 exec Pbx_GetAgents @LoadTestId  
   
 INSERT INTO #Agents  
 VALUES ('TPHRNA01')  
END  
   
  -- SET NOCOUNT ON added to prevent extra result sets from  
  -- interfering with SELECT statements.  
  SET NOCOUNT ON;  
    
  DECLARE @StartTime datetime  
  SELECT @StartTime = MIN([IntervalStartTime]) FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample] WHERE LoadTestRunId = @LoadTestId  
  
 -- Grab the entire Counter Category   
 IF (@CounterName IS NULL OR @CounterName = '') AND @CounterCategory IS NOT NULL AND (@InstanceName IS NULL OR @InstanceName = '')  
  BEGIN  
   SELECT [LoadTestRunId]  
      ,[MachineName]  
      ,[CategoryName]  
      ,[CounterName]  
      ,[InstanceName]  
      ,CAST(([IntervalStartTime] - @StartTime) As datetime)  As Interval  
      ,[CounterType]  
      ,[ComputedValue]  
      ,[ThresholdRuleResult]  
     FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample]  
     WHERE LoadTestRunId = @LoadTestId  
     AND CategoryName = @CounterCategory  
     AND MachineName NOT IN (SELECT agent from #Agents)  
  END  
 -- Do some specific work if it's a "LoadTest" counter   
 ELSE IF @CounterCategory LIKE 'LoadTest:%'  
  BEGIN  
   IF @CounterName IS NULL  
   SELECT [LoadTestRunId]  
      ,[MachineName]  
      ,[CategoryName]  
      ,[CounterName]  
      , CASE WHEN RIGHT([InstanceName],5) LIKE '(%)'   
         Then SUBSTRING([InstanceName],0,(LEN([InstanceName]) - 4))  
         Else [InstanceName] END As InstanceName  
      ,CAST(([IntervalStartTime] - @StartTime) As datetime)  As Interval  
      ,[ComputedValue]  
      ,[CounterType]  
      ,[ThresholdRuleResult]  
    FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample]  
    WHERE LoadTestRunId  = @LoadTestId  
    AND CategoryName = @CounterCategory  
    AND MachineName NOT IN (SELECT agent from #Agents)  
    ELSE  
    SELECT [LoadTestRunId]  
      ,[MachineName]  
      ,[CategoryName]  
      ,[CounterName]  
      , CASE WHEN RIGHT([InstanceName],5) LIKE '(%)'   
         Then SUBSTRING([InstanceName],0,(LEN([InstanceName]) - 4))  
         Else [InstanceName] END As InstanceName  
      ,CAST(([IntervalStartTime] - @StartTime) As datetime)  As Interval  
      ,[ComputedValue]  
      ,[CounterType]  
      ,[ThresholdRuleResult]  
    FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample]  
    WHERE LoadTestRunId  = @LoadTestId  AND CategoryName = @CounterCategory   
    AND CounterName = @CounterName  
    AND MachineName NOT IN (SELECT agent from #Agents)  
  END  
 -- Grab all Counters under a specific counter Category  
 ELSE IF @CounterCategory IS NOT NULL AND @CounterName IS NOT NULL AND (@InstanceName IS NULL OR @InstanceName = '')  
 BEGIN  
 SELECT [LoadTestRunId]  
     ,[MachineName]  
     ,[CategoryName]  
     ,[CounterName]  
     ,[InstanceName]  
     ,CAST(([IntervalStartTime] - @StartTime) As datetime)  As Interval  
     ,[CounterType]  
     ,[ComputedValue]  
     ,[ThresholdRuleResult]  
    FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample]  
    WHERE LoadTestRunId = @LoadTestId  
    AND CategoryName = @CounterCategory   
    AND CounterName = @CounterName  
    AND MachineName NOT IN (SELECT agent from #Agents)  
 END  
 -- Grab a specific counter and instance  
 ELSE IF @CounterCategory IS NOT NULL AND @CounterName IS NOT NULL AND (@InstanceName IS NOT NULL OR @InstanceName != '')  
 BEGIN  
 SELECT [LoadTestRunId]  
     ,[MachineName]  
     ,[CategoryName]  
     ,[CounterName]  
     ,[InstanceName]  
     ,CAST(([IntervalStartTime] - @StartTime) As datetime)  As Interval  
     ,[CounterType]  
     ,[ComputedValue]  
     ,[ThresholdRuleResult]  
    FROM [LoadTest2010].[dbo].[LoadTestComputedCounterSample]  
    WHERE LoadTestRunId = @LoadTestId  
    AND CategoryName = @CounterCategory   
    AND CounterName = @CounterName  
    AND InstanceName = @InstanceName  
    AND MachineName NOT IN (SELECT agent from #Agents)  
 END  
END