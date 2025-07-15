using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Dtos.Response;

public class GetDetailedGameByIdResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Available { get; set; }
    public GameCategory Category { get; set; }
    public string Responsible { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public bool IsInLate { get; set; }
}
