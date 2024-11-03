using System.Collections;

namespace RankedChoiceBallotSimulator.obj.interfaces;

public interface IVotingGuide
{
    List<IRanking> GetRankings();
}