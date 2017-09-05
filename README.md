# Serialize objects to csv in C# #
This small C# project illustrates how to export a list of objects to a csv file, using a generic method called `SerializeToCsv<T>()`. 
Take a given list of objects:
```
List<Child> children = new List<Child>();
```
where `Child` inherits from a certain `Base` class: 
```
public class Child : Base    
  {        
      public string StringPropertyChild { get; set; }        
      public DateTime DateTimePropertyChild { get; set; }        
      public bool BoolPropertyChild { get; set; }        
      public Child Brother { get; set; }    
  }
```
Once populated, these objects can be exported to a csv file directly as follows:
```
StaticMethods.SerializeToCsv<Child>(children, @"C:\temp\ExportExample.csv");
```
More specifically, using reflection, this static method creates a csv file where **headers match the property names** of the `Child` class (spaces are added to split camel case strings) and where the corresponding **property values** of each `Child` object are used to **populate lines**.  

Only *primitive* property types are exported to the csv file. An extension method `IsSimple()` is provided to extend the original concept of [primitive property type][1] to `Enum`, `String`, `Decimal`, `DateTime` and the corresponding nullable types. 

By default, *inherited* properties are also exported. One could easily exclude the inherited properties (from the `Base` class) by adding the `BindingFlags.DeclaredOnly` option in the GetProperties method used in the code:
```
var properties = type.GetProperties(BindingFlags.DeclaredOnly);
```
A custom attribute class `InternalUseOnly` can be used to prevent a given property from being exported to the flat file:
``` 
public class Base
  {        
      public string StringPropertyBase { get; set; }        
      public double DoublePropertyBase { get; set; }        
      [InternalUseOnly(true)]        
      public bool BoolPropertyBase { get; set; }   
  }
```
Sources
* [Use reflection to export an object to a csv file](https://stackoverflow.com/questions/2306667/how-can-i-convert-a-list-of-objects-to-csv)
* [Extend the concept of primitive type](https://stackoverflow.com/questions/863881/how-do-i-tell-if-a-type-is-a-simple-type-i-e-holds-a-single-value) 

[1]: https://msdn.microsoft.com/en-us/library/system.type.isprimitive(v=vs.110).aspx
