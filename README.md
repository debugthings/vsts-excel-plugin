vsts-excel-plugin
=================

A more robust replacement for the default Visual Studio Load Test report generator tool that comes standard.

James Davis - 03/15/2011
james.l.davis@outlook.com

Overview:

In order to create consistent results quickly we usually have to turn to Excel to do so. Excel is a great tool but it can be very tiresome and cumbersom to work with for large amounts of data.

This tool provides a way for us to connect to the LoadTest database and acurately pull reproducable data.


##Description of Excel Classes

The Excel classes are based on the Micorsoft.Office.* and Microsoft.Office.Interop.* classes. These classes are a collection of interfaces and enumerations.  There are some actual class types in these libraries but they are there to facilitate the Interop -> .NET conversions.

You cannot instantiate a new class and expect it to work. Like most VBA/VSTO you need to use the built-in 	Excel Application class. This class is provided by the plugin as Globals.ThisAddIn.Application. This is 	auto generated so you do not need to instatiate a new copy.

###How to write functions

The quickest way to start writing functions for this plugin is to start recording macros in Excel. Here	is an example Macro:
```C#
Sheets("Sheet3").Select
ActiveCell.FormulaR1C1 = ""
Sheets("Sheet3").Name = "RenameSheet3"
```

This Macro is simple enough. It first selects the sheet named "Sheet 3", sets the value of the ActiveCell 	to "" (blank) and then renames the sheet to "RenameSheet3".  Here is what the commands would look like in C#:
```C#
Globals.ThisAddIn.Application.Sheets[SheetName].Select();
Globals.ThisAddIn.Application.ActiveCell.Value = "";
Globals.ThisAddIn.Application.Sheets[SheetName].Name = "RenameSheet3";
// Or, you can use the ActiveSheet property
Globals.ThisAddIn.Application.ActiveSheet.Name = "RenameSheet3";
```

The commands are similar but some of the Syntax is different. You can also use the ActiveCell, ActiveChart, and ActiveSheet properties to get the currently active sheet.

##Gotchas

That previous code example will not cause many problems but as you expand the functionality of your application you will run into some of the following gotchas.

###Excel uses a 1 based index array system. 
You will need to either start your loops with 1 or adjust accordingly

The data you pull back will be of varying size. (Ranges, Cells, Address). This is important to note because you might be used to the "A1" style reference and you don't want to write some code that transalates your coordinates to and from this syntax.

Instead you should use the Range[Cell[],Cell[]] model to locate your data.  Once you create your selections you can use the Range[Cell[],Cell[]].Address property to translate your coordinates to something you can use with a formula.

Example:
```C#
// We are on a sheet of raw data and will use this command to get the address of the range
string formulaAddress = 
	App.ActiveSheet.Range[App.Cells[2, startingColumn], App.Cells[2 + countNumber, startingColumn]].Address;

// We will then switch to a new sheet and insert a MIN formula.
App.Sheets[statSheetName].Select();
App.ActiveSheet.Range[App.Cells[startingColumn + 1, 2], App.Cells[startingColumn + 1, 2]].Select();
App.ActiveCell.Formula = string.Format("=MIN('{0}'!{1})", rawSheetName, formulaAddress);
```

###It's slow to insert one cell at a time

When inserting multiple rows into a spreadsheet you will want to do it with an array. In some of the code it is done in lots of 1000 in order to speed up the data insertion as much as possible.  You can do your own timings to see what is faster.

For simple row insertions an array of objects will do fine. Note that the array has to be the same length as the range. You can insert anything you'd like in the array, string, int, float, single, etc.

Example:
```C#
App.ActiveSheet.Range["A1:F1"] = new object[] { "A", "B", "C", "D", "E", "F" };
```

For a multi row range you will need to use a multidimensional array (not a jagged array).  This array also
needs to be sized for the range. In the example below we are looping 100 times to create a column of data 
that will be inserted in one shot.

Example:
```C#
int countNumber = 100;
App.Sheets["RawTable"].Select();
Single[,] _multiDimensional = new Single[countNumber, 1];

for (int i = 0; i < countNumber; i++)
{
	_multiDimensional[i, 0] = i * 2.2;
}

App.ActiveSheet.Range[App.Cells[1, 1], App.Cells[1 + countNumber, 1]] = _multiDimensional;
```
###You can't expect a collection to be of one type.
When you loop through the Application.Sheets collection you can end up with Sheets and Charts.

One way you can help limit the amount of errors down the road is by checking the type of the item returned.

Example:
```C#
foreach (var worksheetTest in App.Sheets)
{
	if (worksheetTest is Excel.Worksheet)
	{
		// Do work
	}
}
```

###Pulling results takes too long
		
Well, yeah, it can. But there is a way to fix it. You need to update the stats on the load test database by executing sp_update stats.

Case in point, when I was developing this I had a couple of queries that ran for 40 seconds.  After updating the stats they ran in 1 second.

##Extensibility

This application is being written to be extensible.  What I am tryin to acheive is a plugin system that you can control and load anything you'd like without having to touch the main code base.

Here are the types of plugins accepted.

###Tables and Charts
This is the heart and soul of this application you will use these classes to create useful and repeatable charts.

One thing we need to avoid is creating a lot of application specific charts. However it would be good to have a repository of these so we can load and unload them as we wish.

###Rules Engine (under development)
The rules engine allows for you to develop a a way for you to both adorn your charts with special icons, gradients, or other items to call out specific events on a load test; and it can be used with the analysis engine to generate a report of possible violations. These rules can tie in to threshold violations for the load test, or they can be something unique.

One of the main tenants of these rules is to combine violations to make more complex rules and error reports. For example, if paging increases and available memory hits a low and does not recover we can assume that this machine could benefit from more memory.

The rules aren't made to replace standard analysis techniques, they are mean to augment them and make specific tasks quicker.

###Analysis Engine (under development)
The anlysis engine is closely tied into the Rules Engine. This engine will combine specific rules to look at the raw data and apply specific rules to data at points in time.

For example the Low Memory analysis will take a look at Available MBytes for all systems under test and call it out in a report. It will also combine the Process Memory 