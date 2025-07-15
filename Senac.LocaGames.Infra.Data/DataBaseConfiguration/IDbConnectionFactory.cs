using System.Data;

namespace Senac.GerenciamentoVeiculos.Infra.Data.DataBaseConfiguration;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
