namespace RankedChoiceBallotSimulator.obj.interfaces;

public interface IRanking
{
    int TotalWeight { get; }
    ICandidate ChooseCandidateWithRandomNumber(int randomNumber);
}