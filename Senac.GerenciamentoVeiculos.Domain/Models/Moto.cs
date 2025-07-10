namespace Senac.GerenciamentoVeiculos.Domain.Models;

public class Moto
{
    public long Id { get; set; }

    public string Nome { get; set; } 
    
    public string Marca { get; set; }

    public string Placa { get; set; }

    public string Cor { get; set; }

    public int AnoFabricacao { get; set; }

    public TipoCombustivelCarro TipoCombustivel { get; set; }
}
