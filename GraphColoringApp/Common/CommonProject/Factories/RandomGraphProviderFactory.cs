using CommonProject.Interfaces;

namespace CommonProject
{
    public class RandomGraphProviderFactory
    {
        public IRandomGraphProvider Create()
        {
            return new RandomGraphProvider();
        }
    }
}
