using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Alekseyzor
{
    [Generator]
    public class Alekseyzor : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {
            // Code generation goes here
            context.AddSource ("myContent", @"
using System;
public class IAmHero {
    public static void DoSomething() {
        Func<string,string> fn = (s) => s + ""!"";
        Console.WriteLine(fn (""Hello, I am a hero""));
    }
}
            ");
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}
