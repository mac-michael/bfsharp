using System;
using System.Collections.Generic;

namespace BFsharp
{
    public class GlobalRulePrototypeExtensionPoint<T> : ExtensionPoint<T>
    {
        public IEnumerable<Rule> Prototypes { get; set; }

        public GlobalRulePrototypeExtensionPoint(IEnumerable<Rule> prototypes)
        {
            Prototypes = prototypes;
        }

        public override void Init(ExtensionsOptions<T> options)
        {
            options.RulePrototypes.AddRange(Prototypes);
        }
    }
}