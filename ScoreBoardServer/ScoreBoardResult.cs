using System.Runtime.Serialization;

namespace ScoreBoardServer
{
  /// <summary>
  /// Результат в таблице рекордов.
  /// </summary>
  [DataContract]
  public class ScoreBoardResult
  {
    /// <summary>
    /// Игра.
    /// </summary>
    [DataMember]
    public string Game { get; set; }

    /// <summary>
    /// Код пользователя.
    /// </summary>
    [DataMember]
    public string UserCode { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [DataMember]
    public string UserName { get; set; }

    /// <summary>
    /// Набранные очки.
    /// </summary>
    [DataMember]
    public int Score { get; set; }
  }
}
