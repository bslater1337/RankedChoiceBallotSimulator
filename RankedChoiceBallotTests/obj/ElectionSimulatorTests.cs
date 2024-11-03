using FluentAssertions;
using Moq;
using RankedChoiceBallotSimulator.obj;
using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotTests.obj;

[TestFixture]
public class ElectionSimulatorTests
{
    private ElectionSimulator _sut;
    private Mock<IElectorate> _electorate;
    private List<IBallot> _ballots;
    private Mock<IElectionResult> _electionResult;

    [Test]
    public void SimulateElection()
    {
        _electionResult = new Mock<IElectionResult>(MockBehavior.Strict);
        var ballot = new Mock<IBallot>(MockBehavior.Strict);
        ballot.Setup(x => x.CastInitialVote());
        _ballots = [ballot.Object];
        _electorate = new Mock<IElectorate>(MockBehavior.Strict);
        _electorate.Setup(x => x.TallyVotes(_ballots)).Returns(_electionResult.Object);
        _sut = new ElectionSimulator(_ballots, _electorate.Object);
        
        var result = _sut.SimulateElection();
        
        result.Should().Be(_electionResult.Object);
        ballot.Verify(x => x.CastInitialVote(),Times.Once());
    }
}