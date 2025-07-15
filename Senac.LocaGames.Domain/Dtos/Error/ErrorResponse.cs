using System.Text.Json.Serialization;

namespace Senac.LocaGames.Domain.Dtos.Error
{
    public class ErrorResponse
    {
        public string Mensagem { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Codigo { get; set; }
    }
}
