using FluentAssertions;
using RankedChoiceBallotSimulator.obj;
using RankedChoiceBallotSimulator.obj.interfaces;

namespace RankedChoiceBallotTests;

[TestFixture]
public class RankedChoiceBallotSimulatorSpecTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void TestVote()
    {
    var simulator = new ElectionSimulator();
        
    var result = simulator.SimulateElection();

    VerifyResults(result);
    }

    private void VerifyResults(IElectionResult result)
    {
        VerifyRunOffCountDecrements(result);
    }

    private static void VerifyRunOffCountDecrements(IElectionResult result)
    {
        var  initialCount = result.Primary.Candidates.Count;
        
        var firstRunOffCount = result.RunOffs.First().Candidates.Count;
        
        var difference = initialCount - firstRunOffCount;

        difference.Should().Be(1);
    }
}