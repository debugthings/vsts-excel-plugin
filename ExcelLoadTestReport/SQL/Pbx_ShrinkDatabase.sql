create procedure [dbo].[Pbx_ShrinkDatabase]  
as  
begin  
  
  
DBCC SHRINKDATABASE (LoadTest2010, 5)   
end