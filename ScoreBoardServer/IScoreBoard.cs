using System.Collections.Generic;
using System.ServiceModel;

namespace ScoreBoardServer
{
  /// <summary>
  /// Контракт сервиса доски рекордов.
  /// </summary>
  [ServiceContract]
  public interface IScoreBoard
  {
    /// <summary>
    /// Получить список лучших результатов.
    /// </summary>
    /// <param name="count">Количество результатов.</param>
    /// <returns>Список лучших результатов.</returns>
    [OperationContract]
    List<ScoreBoardResult> GetTopResults(int count);

    /// <summary>
    /// Добавить результат.
    /// </summary>
    /// <param name="result">Результат.</param>
    [OperationContract]
    void AddResult(ScoreBoardResult result);
  }
}
