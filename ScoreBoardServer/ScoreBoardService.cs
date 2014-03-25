using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Embedded;

namespace ScoreBoardServer
{
  internal class ScoreBoardService : IScoreBoard
  {
    private EmbeddableDocumentStore documentStore;

    public List<ScoreBoardResult> GetTopResults(int count)
    {
      try
      {
        using (var session = this.documentStore.OpenSession())
        {
          return session.Query<ScoreBoardResult>()
            .OrderByDescending(r => r.Score)
            .Take(count)
            .ToList();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return new List<ScoreBoardResult>();
    }

    public void AddResult(ScoreBoardResult result)
    {
      try
      {
        using (var session = this.documentStore.OpenSession())
        {
          ScoreBoardResult record = session.Query<ScoreBoardResult>().SingleOrDefault(r => r.Game == result.Game && r.UserCode == result.UserCode);
          if (record != null)
          {
            if (record.Score < result.Score)
            {
              record.Score = result.Score;
              record.UserTitle = result.UserTitle;
              session.SaveChanges();
            }
          }
          else
          {
            session.Store(result);
            session.SaveChanges();
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public ScoreBoardService()
    {
      this.documentStore = new EmbeddableDocumentStore { DataDirectory = @"D:/temp/RavenDB/" };
      this.documentStore.Initialize();
    }
  }
}
