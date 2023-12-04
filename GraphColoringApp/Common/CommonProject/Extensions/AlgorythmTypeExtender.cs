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
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm), "Invalid algorithm type.");
            }
        }
    }
}
