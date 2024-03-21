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
                case AlgorithmType.LargestDegreeFirstSequential:
                    return new LDOGraphColoringProvider();
                case AlgorithmType.IDOSequential:
                    return new IDOGraphColoringProvider();
                case AlgorithmType.SDOSequential:
                    return new SDOGraphColoringProvider();
                case AlgorithmType.IndependentSetBasedSequential:
                    return new MaximalIndependentSetGraphColoringProvider();
                case AlgorithmType.FirstFitModifiedSequential:
                    return new FirstFitModifiedGraphColoringProvider(additionalNumberOfIterations: 3);
                case AlgorithmType.GMParallel:
                    return new GMGraphColoringProvider();
                case AlgorithmType.JonnesPlassmanLDFParallel:
                    return new JonesPlassmanLDFColorProvider();
                case AlgorithmType.LubyMISParallel:
                    return new LubyMISParallelColoringProvider();
                case AlgorithmType.BlockPartitioningBasicParallel:
                    return new BasicBlockPartitioningColorProvider();
                case AlgorithmType.AdvancedBlockPartitioningParallel:
                    return new AdvancedBlockPartitioningColorProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithmType), "Invalid algorithm type.");
            }
        }
    }
}