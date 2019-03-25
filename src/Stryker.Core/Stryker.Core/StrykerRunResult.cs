using Stryker.Core.Options;

namespace Stryker.Core
{
    public enum RunStatus
    {
        Successfull = 0,
        Unsuccessfull,
        NothingToTest,
        AllMutationsSkipped,
    }

    public class StrykerRunResult
    {
        private StrykerOptions _options { get; }
        public decimal? MutationScore { get; }
        public RunStatus Status { get; }

        public StrykerRunResult(StrykerOptions options, decimal? mutationScore)
        {
            _options = options;
            MutationScore = mutationScore;
            Status = IsScoreAboveThresholdBreak() ? RunStatus.Successfull : RunStatus.Unsuccessfull; 
        }

        public StrykerRunResult(RunStatus status)
        {
            Status = status;
        }

        private bool IsScoreAboveThresholdBreak()
        {
            if (MutationScore == null)
            {
                // Return true, because there were no mutations created.
                return true;
            }

            // Check if the mutation score is not below the threshold break
            return MutationScore >= _options.Thresholds.Break;
        }
    }
}