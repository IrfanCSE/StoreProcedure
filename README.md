# StoredProcedure

It's a Helper Tool to execute a Stored Procedure from .Net Application.

NOTE: This library written under .net 5 framework.

## Installation

Use the [nuget](https://www.nuget.org/packages/StoredProcedure/) package manager to install StoredProcedure.

```bash
dotnet add package StoredProcedure --version 5.0.0
```

## Usage
Prepare Data Set as Stored Procedure Accept.
```csharp
// Tag with Json, If your sp accept json
var obj = new Example { property="value" };
var json = new Json();
json.Add("@Json", obj);
```
```csharp
// Tag with Parameter, If your sp accept param
var param = new Param();
param.Add("@Param1", value);
param.Add("@Param2", value2);
```
```csharp
// Tag with Output, If your sp accept Out
var output = new Output();
param.Add("@Output", out);
```
Example: 1.1

SQL
```sql
EXECUTE [schema].[storeProcedureName]
```
C#
```csharp
context.Execute("storedProcedureName", default, default,default);
```
Example: 1.2

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json1,@json2,@json_n
```
C#
```csharp
context.Execute("storedProcedureName", json, default,default);
```
Example: 1.3

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json,@param1,@param2,@param_n
```
C#
```csharp
context.Execute("storedProcedureName", json, param,default);
```
Example: 1.4

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json,@param,@output
```
C#
```csharp
context.Execute("storedProcedureName", json, param,output);
```
Example: 1.5

SQL
```sql
EXECUTE [schema].[storeProcedureName] @param1,@param2,@param_n
```
C#
```csharp
context.Execute("storedProcedureName", default, param,default);
```
Example: 1.6

SQL
```sql
EXECUTE [schema].[storeProcedureName] @param1,@param2,@output
```
C#
```csharp
context.Execute("storedProcedureName", default, param,output);
```
Example: 1.7

SQL
```sql
EXECUTE [schema].[storeProcedureName] @output1,@output2,@output_n
```
C#
```csharp
context.Execute("storedProcedureName", default, default,output);

```

Example: 2.1

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json1,@json2
```
C#
```csharp
context.Execute<T_DTO>("storedProcedureName", json, default);

```
Example: 2.2

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json1,@param1
```
C#
```csharp
context.Execute<T_DTO>("storedProcedureName", json, param);

```
Example: 3.1

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json1,@json2
```
C#
```csharp
context.Execute("storedProcedureName", json, default);

```
Example: 3.2

SQL
```sql
EXECUTE [schema].[storeProcedureName] @json1,@param1
```
C#
```csharp
context.Execute("storedProcedureName", json, param);

```

## Description
I will prepare this document later with more specific in details!

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
