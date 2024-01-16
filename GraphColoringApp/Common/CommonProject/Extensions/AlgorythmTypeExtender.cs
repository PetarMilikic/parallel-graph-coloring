namespace CommonProject
{
    public static class AlgorythmTypeExtender
    {
        public static string GetAlgorithmName(this AlgorithmType algorithm)
        {
            switch (algorithm)
            {
                case AlgorithmType.FirstFitSequential:
                    return "First Fit [Sequential]";
                case AlgorithmType.LargestDegreeFirstSequential:
                    return "Largest Degree First [Sequential]";
                case AlgorithmType.IDOSequential:
                    return "IDO [Sequential]";
                case AlgorithmType.SDOSequential:
                    return "SDO [Sequential]";
                case AlgorithmType.IndependentSetBasedSequential:
                    return "Maximal Independent Set Based [Sequential]";
                case AlgorithmType.FirstFitModifiedSequential:
                    return "First Fit Modified [Sequential]";
                case AlgorithmType.GMParallel:
                    return "GM [Parallel]";
                case AlgorithmType.JonnesPlassmanLDFParallel:
                    return "Jonnes Plassman LDF [Prallel]";
                case AlgorithmType.LubyMISParallel:
                    return "Luby MIS [Parallel]";
                case AlgorithmType.BlockPartitioningBasicParallel:
                    return "Basic Block Partitioning [Parallel]";
                case AlgorithmType.AdvancedBlockPartitioningParallel:
                    return "Advanced Block Partitioning [Parallel]";
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm), "Invalid algorithm type.");
            }
        }
    }
}
