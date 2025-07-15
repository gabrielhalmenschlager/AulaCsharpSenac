using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Dtos.Request;

public class AddGameRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public GameCategory Category { get; set; }
}
