﻿namespace Senac.GerenciamentoVeiculos.Domain.Dtos.Responses.Moto;

public class CadastrarMotoResponse
{
    public long Id { get; set; }

    public string Nome { get; set; }

    public string Marca { get; set; }

    public string Placa { get; set; }

    public string Cor { get; set; }

    public int AnoFabricacao { get; set; }

    public string TipoCombustivelMoto { get; set; }
}
