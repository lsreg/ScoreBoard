using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ScoreBoardServer
{
  [ServiceContract]
  public interface IScoreBoard
  {
    [OperationContract]
    List<ScoreBoardResult> GetTopResults(int count);

    [OperationContract]
    void AddResult(ScoreBoardResult result);
  }
}
