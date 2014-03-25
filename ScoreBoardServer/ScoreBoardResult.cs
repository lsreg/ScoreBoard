using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardServer
{
  [DataContract]
  public class ScoreBoardResult
  {
    [DataMember]
    public string Game { get; set; }

    [DataMember]
    public string UserCode { get; set; }

    [DataMember]
    public string UserTitle { get; set; }

    [DataMember]
    public int Score { get; set; }
  }
}
