using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreBoard;
using ScoreBoardServer;

namespace ScoreBoardTestApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new ScoreBoardClient("net.tcp://localhost:9876/");
      client.AddResult(new ScoreBoardResult() {Game = "Civilization", UserCode = "Ivanov", UserTitle = "Ivanov II", Score = 7});
      client.AddResult(new ScoreBoardResult() { Game = "Civilization", UserCode = "Petrov", UserTitle = "Petrov PP", Score = 7 });
      client.AddResult(new ScoreBoardResult() { Game = "Civilization", UserCode = "Sidorov", UserTitle = "Sidorov SS", Score = 7 });

      foreach (var result in client.GetTopResults(9))
        Console.WriteLine(string.Format("{0} - {1} - {2} - {3}", result.Game, result.UserCode, result.UserTitle, result.Score));
    }
  }
}
