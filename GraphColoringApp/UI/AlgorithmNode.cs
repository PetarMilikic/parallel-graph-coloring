using CommonProject;

namespace UI
{
    internal class AlgorithmNode
    {
        private readonly AlgorithmType algorithmType;

        internal AlgorithmNode(AlgorithmType algorithmType)
        {
            this.algorithmType = algorithmType;
        }

        #region Properties

        public AlgorithmType AlgoritimType
        {
            get { return this.algorithmType; }
        }

        public string Name
        {
            get { return this.algorithmType.GetAlgorithmName(); }
        }

        #endregion
    }
}
