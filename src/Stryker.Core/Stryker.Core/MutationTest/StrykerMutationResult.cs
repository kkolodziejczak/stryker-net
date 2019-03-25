namespace Stryker.Core.MutationTest
{
    public class StrykerMutationResult
    {
        public int NumberOfAllMutations { get; }
        public int MutationsToTest { get; }
        public int MutationsSkipped { get; }

        public StrykerMutationResult(int numberOfAllMutations, int mutationsToTest, int mutationsSkipped)
        {
            NumberOfAllMutations = numberOfAllMutations;
            MutationsToTest = mutationsToTest;
            MutationsSkipped = mutationsSkipped;
        }
    }
}