# bfsharp
A framework which helps building business applications.
It provides business rules, validation rules and a text-based language for writing rules.
It supports automatic dependency detection, automatic rule reevaluation.

- 8 August 2011: SwitchRule - better rule groups management; Client\Server context, ValidateOnlyOnServerSide
- 28 July 2011: Formula DSL language is available in WP7.
- 27 July 2011: Rules with Automatic Dependency Analysis support in WP7. Now rules can be truly multiplatform (.Net, SL, WP7).
- 24 July 2011: Major performance improvments and expression caching (alpha). To turn it on use ExtensionsOptions.CacheLambdas.

A new tutorial was created. You can find it [here](https://github.com/mac-michael/bfsharp/tutorial.html).

To view LiveSamples go here.

Now with NuGet integration - you can find it [here](http://nuget.org/List/Packages/BFsharp).

BFsharp
Provides several features which help in building business applications:
- Business rules
```csharp
[Test]
public void BusinessRuleEvaluate()
{
    var e = new Entity();
    e.Extensions.AddBusinessRule(en => en.Number2 + 5, en => en.Number);

    e.Extensions.Enable();

    e.Number2 = 5;

    e.Number.ShouldEqual(10);
}
```
- Formula - text language for writing rules
```csharp
e.Extensions.AddBusinessRule("Number=Number2+Number3");
```
You can use Formula without rules
```csharp
var compiler = new FormulaCompiler()
    .WithFlatType(typeof(Math));

var f = compiler.NewLambda().
    WithParam<int>("Param1").
    WithParam<int>("Param2").
    Returns<int>().
    Compile("max(@Param1, @Param2) + 4");

f(2, 3).ShouldEqual(7);
```
- Validation rules
```csharp
[Test]
public void FuncValidationRule()
{
    var e = new Entity();
    e.Extensions.AddValidationRule(en => en.Name == "yol");

    e.Extensions.Enable();

    e.Name = "abc";
    e.Extensions.BrokenRules.Count.ShouldEqual(1);
            
    e.Name = "yol";
    e.Extensions.BrokenRules.Count.ShouldEqual(0);
}
```