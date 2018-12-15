using System;

namespace BFsharp
{
    public struct BrokenRuleToken
    {
        public BrokenRule[] BrokenRules { get; set; }
        public IEntityExtensions Extension { get; set; }

        public static BrokenRuleToken Create(IEntityExtensions extension,
                                             params BrokenRule[] brokenRules)
        {
            var token = new BrokenRuleToken
                            {
                                BrokenRules = brokenRules,
                                Extension = extension
                            };

            token.Add();
            return token;
        }

        public void Add()
        {
            foreach (var brokenRule in BrokenRules)
                Extension.BrokenRules.Add(brokenRule);
        }

        public void Cancel()
        {
            if (BrokenRules != null)
            {
                foreach (var brokenRule in BrokenRules)
                    Extension.BrokenRules.Remove(brokenRule);

                BrokenRules = null;
            }
        }
    }
}