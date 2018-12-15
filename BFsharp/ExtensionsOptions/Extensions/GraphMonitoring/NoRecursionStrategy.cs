using System.Collections;
using System.Collections.Generic;

namespace BFsharp
{
    public class NoRecursionStrategy : RecursiveStrategy
    {
        protected override IEnumerable<IEntityExtensions> GetSimpleProperties(object target)
        {
            yield break;
        }

        public override IEnumerable<IEnumerable> GetCollections(object target)
        {
            yield break;
        }

        protected override IEnumerable<IEntityExtensions> GetCollectionsElements(object target)
        {
            yield break;
        }

        public static readonly NoRecursionStrategy Instance = new NoRecursionStrategy();
    }
}