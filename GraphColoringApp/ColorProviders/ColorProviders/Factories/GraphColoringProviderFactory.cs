using ColorProviders.Interfaces;
using CommonProject;

namespace ColorProviders.Factories
{
    public class GraphColoringProviderFactory
    {
        public IGraphColoringProvider Create(AlgorithmType algorithmType)
        {
            switch (algorithmType)
            {
                case AlgorithmType.FirstFitSequential:
                    return new FirstFitGraphColoringProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithmType), "Invalid algorithm type.");
            }
        }
    }
}
