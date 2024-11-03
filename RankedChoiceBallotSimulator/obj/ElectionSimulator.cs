using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotSimulator.obj;

public class ElectionSimulator
{
    private List<IBallot> _ballots;
    private IElectorate _electorate;

    public ElectionSimulator(List<IBallot> ballots = null, IElectorate electorate = null)
    {
        _ballots = ballots ?? GenerateBallots();
        _electorate = electorate ?? new Electorate();
    }

    private List<IBallot> GenerateBallots()
    {
        throw new NotImplementedException();
    }

    public IElectionResult SimulateElection()
    {
        _ballots.ForEach(b => b.Vote());

        return _electorate.TallyVotes(_ballots);
    }
}