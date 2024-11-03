using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotSimulator.obj;

public class Electorate : IElectorate
{
    public IElectionResult TallyVotes(List<IBallot> ballots)
    {
        throw new NotImplementedException();
    }
}