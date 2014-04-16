using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using Raven.Client.Embedded;

namespace ScoreBoardServer
{
  /// <summary>
  /// Реализация сервиса доски рекордов.
  /// </summary>
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
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
        return new List<ScoreBoardResult>();
      }      
    }

    public void AddResult(ScoreBoardResult result)
    {
      try
      {
        lock (this.documentStore)
        {
          using (var session = this.documentStore.OpenSession())
          {
            ScoreBoardResult record = session.Query<ScoreBoardResult>().SingleOrDefault(r => r.Game == result.Game && r.UserCode == result.UserCode);
            if (record != null)
            {
              if (record.Score < result.Score)
              {
                record.Score = result.Score;
                record.UserName = result.UserName;
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
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public ScoreBoardService()
    {
      this.documentStore = new EmbeddableDocumentStore { DataDirectory = ConfigurationManager.AppSettings["PathToDatabase"] };      
      this.documentStore.Initialize();      
    }
  }
}
