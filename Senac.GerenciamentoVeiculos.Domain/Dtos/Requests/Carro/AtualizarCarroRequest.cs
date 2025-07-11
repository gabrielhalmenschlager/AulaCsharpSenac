namespace Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Carro;

public class AtualizarCarroRequest
{
    public string Placa { get; set; }
    public string Cor { get; set; }
    public string TipoCombustivelCarro { get; set; }
}
