using System.Text.Json.Serialization;

namespace Senac.GerenciamentoVeiculos.Domain.Dtos.Responses;

public class ErroResponse
{
    public string Mensagem { get; set; }

    [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
    public string Codigo { get; set; }
}