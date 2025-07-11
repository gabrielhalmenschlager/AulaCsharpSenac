namespace Senac.GerenciamentoVeiculos.Domain.Models;

public class Caminhao
{
    public long Id { get; set; }

    public string Nome { get; set; }

    public string Marca { get; set; }

    public string Placa { get; set; }

    public string Cor { get; set; }

    public int AnoFabricacao { get; set; }

    public TipoCombustivelCaminhao TipoCombustivelCaminhao { get; set; }

    public decimal CapacidadeCargaToneladas { get; set; }

    public int QuantidadeEixos { get; set; }
}
