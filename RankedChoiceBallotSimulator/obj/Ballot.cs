using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotSimulator.obj;

public class Ballot : IBallot
{
    private readonly IVoteManager _voteManager;
    private List<ICandidate> _candidatesRanked;
    private readonly IVotingGuide _votingGuide;

    public Ballot(IVoteManager voteManager, IVotingGuide votingGuide)
    {
        _voteManager = voteManager;
        _votingGuide = votingGuide;
    }

    private void DeliberateCandidates()
    {
        _candidatesRanked = new List<ICandidate>();

        var rankings = _votingGuide.GetRankings();

        foreach (var ranking in rankings)
        {
            ChooseCandidate(ranking);
        }
    }

    private void ChooseCandidate(IRanking ranking)
    {
        var potentialCandidate = ChooseAtRandom(ranking);

        while(!_candidatesRanked.Contains(potentialCandidate))
        {
            if (_candidatesRanked.Contains(potentialCandidate))
            {
                potentialCandidate = ChooseAtRandom(ranking);
                continue;
            }
            
            _candidatesRanked.Add(potentialCandidate);
            
        }
    }

    private static ICandidate ChooseAtRandom(IRanking ranking)
    {
        var randomNumber = new Random().Next(0, ranking.TotalWeight);

        var potentialCandidate = ranking.ChooseCandidateWithRandomNumber(randomNumber);
        
        return potentialCandidate;
    }

    public void CastInitialVote()
    {
        DeliberateCandidates();

        CastVote();
    }

    private void CastVote()
    {
        foreach (var candidate in _candidatesRanked)
        {
            if (!_voteManager.IsCandidateStillValid(candidate))
            {
                continue;
            }
            
            _voteManager.CastVote(candidate, this);
        }
    }
}