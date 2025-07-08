namespace Senac.GerenciamentoVeiculos.Domain.Dtos.Requests.Caminhao;

public class AtualizarCaminhaoRequest
{
    public string Placa { get; set; }
    public string Cor { get; set; }
    public string TipoCombustivel { get; set; }
    public decimal CapacidadeCargaToneladas { get; set; }
    public int QuantidadeEixos { get; set; }
}
