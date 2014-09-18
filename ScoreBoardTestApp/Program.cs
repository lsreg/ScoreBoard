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
      var client = new ScoreBoardClient("http://127.0.0.1:9876/");
      client.AddResult(new ScoreBoardResult() { Game = "Civilization", UserCode = "Ivanov", UserName = "Ivanov II", Score = 29 });
      client.AddResult(new ScoreBoardResult() { Game = "Civilization", UserCode = "Petrov", UserName = "Petrov PP", Score = 13 });
      client.AddResult(new ScoreBoardResult() { Game = "Civilization", UserCode = "Sidorov", UserName = "Sidorov SS", Score = 15 });

      foreach (var result in client.GetTopResults(9))
        Console.WriteLine(string.Format("{0} - {1} - {2} - {3}", result.Game, result.UserCode, result.UserName, result.Score));
    }
  }
}
