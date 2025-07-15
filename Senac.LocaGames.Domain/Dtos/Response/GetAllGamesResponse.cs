using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Dtos.Response;

public class GetAllGamesResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public bool Available { get; set; }
    public GameCategory Category { get; set; }
    public DateTime WithdrawalDate { get; set; }
}
