namespace RankedChoiceBallotSimulator.obj.interfaces;

public interface IElectorate
{
    IElectionResult TallyVotes(List<IBallot> ballots);
}