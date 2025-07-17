namespace Senac.LocaGames.Dominio.Models;

public class Game
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Available { get; set; }
    public GameCategory Category { get; set; }
    public string Responsible { get; set; }
    public DateTime? WithdrawalDate { get; set; }
}
