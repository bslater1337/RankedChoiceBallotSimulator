namespace RankedChoiceBallotSimulator.obj.interfaces;

public interface IVoteManager
{
    void CastVote(ICandidate candidate, IBallot ballot);
    bool IsCandidateStillValid(ICandidate candidate);
}