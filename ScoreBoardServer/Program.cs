using System;
using System.ServiceModel;

namespace ScoreBoardServer
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var serviceHost =
        new ServiceHost(typeof(ScoreBoardService)))
      {
        serviceHost.Open();
        
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine();
        Console.ReadLine();

        serviceHost.Close();
      }
    }
  }
}
