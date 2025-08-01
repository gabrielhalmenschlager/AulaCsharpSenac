﻿using Senac.LocaGames.Dominio.Models;

namespace Senac.LocaGames.Domain.Dtos.Request;

public class UpdateGameRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
