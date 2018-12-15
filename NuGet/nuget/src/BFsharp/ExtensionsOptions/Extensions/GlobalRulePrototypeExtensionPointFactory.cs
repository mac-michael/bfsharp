using System;
using System.Collections.Generic;

namespace BFsharp
{
    public class GlobalRulePrototypeExtensionPointFactory : ExtensionPointFactory
    {
        public IEnumerable<Rule> Prototypes { get; set; }

        public GlobalRulePrototypeExtensionPointFactory(IEnumerable<Rule> prototypes)
        {
            Prototypes = prototypes;
        }

        public GlobalRulePrototypeExtensionPointFactory(Func<IEnumerable<Rule>> prototypeFactory)
        {
            Prototypes = prototypeFactory();
        }

        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new GlobalRulePrototypeExtensionPoint<T>(Prototypes);
        }
    }
}