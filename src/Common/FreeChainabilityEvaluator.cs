using Common.Extensions;

namespace Common
{
    internal class FreeChainabilityEvaluator<T> : ChainExtensions.IChainabilityComparer<T>
    {
        public bool Chainable(T a, T b)
        {
            return true;
        }
    }
}