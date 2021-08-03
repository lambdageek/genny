using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;

namespace Alekseyzor
{
    [Generator]
    public class Alekseyzor : IIncrementalGenerator
    {
        private readonly DiagnosticDescriptor _genDescriptor;

        public Alekseyzor () {
            _genDescriptor = new DiagnosticDescriptor ("AZ0001", "Generating", "Generating {0}", "Alekseyzor", DiagnosticSeverity.Info, true);
        }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            System.IO.File.AppendAllText("/tmp/az.txt", string.Format("Running at {0}\n", DateTime.Now));
            // No initialization required for this one

            var texts = context.AdditionalTextsProvider;

            context.RegisterSourceOutput(texts, (context, addtext) => {
                var bp = System.IO.Path.GetFileName(addtext.Path);
                context.ReportDiagnostic(Diagnostic.Create(_genDescriptor, null, bp));
                var str = addtext.GetText().ToString();
                // Code generation goes here
                context.AddSource (bp + ".cs", str);
            });
        }
    }
}
