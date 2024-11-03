namespace RankedChoiceBallotSimulator.obj.interfaces;

public class IElectionResult
{
    public IElectionRunOff Primary { get; }
    public List<IElectionRunOff> RunOffs { get; }
}