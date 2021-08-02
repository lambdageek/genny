== Building ==

Get .NET 6 Preview 6 and run `dotnet build Sample/Sample.csproj`

Then get `mdv` and run `mdv Sample/bin/Debug/net6.0/Sample.pdb`.

== Behavior ==

The `Alekseyzor` source generator genertes an `IAmHero` class with a public static `DoSomething` method that includes a static lambda.

For comparison, the sample program's `Main` method also includes a static lambda.

Expected:

A `CustomDebugInfo` "EnC Lambda and Closure Map" for the generated `IAmHero.DoSomething` method and for `Sample.Program.Main`

Actual:

A `CustomDebugInfo` "EnC Lambda and Closure Map" for `Sample.Program.Main`, but not one for the generated class and method.


