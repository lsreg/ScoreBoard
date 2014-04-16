using System.Collections.Generic;
using System.ServiceModel;
using ScoreBoardServer;

namespace ScoreBoard
{
  /// <summary>
  /// Клиент для доски рекордов.
  /// </summary>
  public class ScoreBoardClient : ClientBase<IScoreBoard>, IScoreBoard
  {
    public ScoreBoardClient(string remoteAddress) :
      base(new NetTcpBinding(), new EndpointAddress(remoteAddress)) { }

    public List<ScoreBoardResult> GetTopResults(int count)
    {
      return base.Channel.GetTopResults(count);
    }
    
    public void AddResult(ScoreBoardResult result)
    {
      base.Channel.AddResult(result);
    }
  }
}
