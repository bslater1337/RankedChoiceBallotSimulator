using RankedChoiceBallotSimulator.obj;

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
        
    var results = simulator.SimulateElection();

    VerifyResults();
    }

    private void VerifyResults()
    {
        throw new NotImplementedException();
    }
}