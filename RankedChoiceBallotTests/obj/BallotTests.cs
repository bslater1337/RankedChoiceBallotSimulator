using Castle.Core.Configuration;
using Moq;
using RankedChoiceBallotSimulator.obj;
using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotTests.obj;

[TestFixture]
public class BallotTests
{
    private Ballot _sut;
    private Mock<IVoteManager> _voteManager;
    private Mock<IVotingGuide> _votingGuide;
    private Mock<IRanking> _ranking;
    private Mock<ICandidate> _candidate;

    [Test]
    public void CastInitialVoteCastsVote_ByDelegatingToVoteManager()
    {
        GenerateVotingGuide();
        GenerateVotingManager();
        _sut = new Ballot(_voteManager.Object, _votingGuide.Object);
        
        _sut.CastInitialVote();
        
        _voteManager.Verify(x => x.CastVote(_candidate.Object, _sut), Times.Once);
        _votingGuide.Verify(x => x.GetRankings(), Times.Once);
        _ranking.Verify(x => x.ChooseCandidateWithRandomNumber(It.IsAny<int>()), Times.Once);
    }

    private void GenerateVotingManager()
    {
        _voteManager = new Mock<IVoteManager>();
        _voteManager.Setup(x => x.CastVote(_candidate.Object, It.IsAny<IBallot>()));
        _voteManager.Setup(x => x.IsCandidateStillValid(_candidate.Object)).Returns(true);
    }

    private void GenerateVotingGuide()
    {
        _candidate = new Mock<ICandidate>();
        
        _votingGuide = new Mock<IVotingGuide>();
        
        _ranking = new Mock<IRanking>();
        _ranking.Setup(x => x.ChooseCandidateWithRandomNumber(It.IsAny<int>())).Returns(_candidate.Object);
        
        _votingGuide.Setup(x => x.GetRankings()).Returns(new List<IRanking> { _ranking.Object });
    }
}