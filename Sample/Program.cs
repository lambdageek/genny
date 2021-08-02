using System;
using System.Reflection;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string,string> fn = (s) => s + "!";
            var assm = typeof(Program).Assembly;
            var ty = assm.GetType("IAmHero");
            Console.WriteLine (fn($"Got {ty.FullName}"));
            var mi = ty.GetMethod("DoSomething", BindingFlags.Public | BindingFlags.Static);
            mi.Invoke(null, Array.Empty<object>());
        }
    }
}
