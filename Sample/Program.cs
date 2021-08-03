using System;
using System.Reflection;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var assm = typeof(Program).Assembly;
            var ty = assm.GetType("IAmHero");
            Console.WriteLine (Transform($"Got {ty.FullName}"));
            var ci = ty.GetConstructor(Array.Empty<Type>());
            var obj = ci.Invoke(Array.Empty<object>());
            var mi = ty.GetMethod("DoSomething", BindingFlags.Public | BindingFlags.Instance);
            mi.Invoke(obj, Array.Empty<object>());
        }

// Comment out the line pragma to get EnC Lambda info
#line hidden
        public static string Transform(string s) {
            Func<string,string> fn = (s) => s + "!";
            return fn(s);
        }
    }
}
