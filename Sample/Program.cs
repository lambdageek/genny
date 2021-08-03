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
            var ci = ty.GetConstructor(Array.Empty<Type>());
            var obj = ci.Invoke(Array.Empty<object>());
            var mi = ty.GetMethod("DoSomething", BindingFlags.Public | BindingFlags.Instance);
            mi.Invoke(obj, Array.Empty<object>());
        }
    }
}
