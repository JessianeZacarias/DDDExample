using Dapper;
using Domain.Commands;
using Domain.Interfaces;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        string conexao = @"Server=DESKTOP-HICDFBH;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=True";

        public async Task<string> PostAsync(VeiculoCommand command)
        {
            string queryInsert = @"
            INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)
            VALUES(@Placa, @AnoFabricacao, @TipoVeiculoId, @Estado, @MontadoraId)";
            using(SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId = (int)command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = (int)command.Montadora,
                });
                return "Veiculo Cadastrado com Sucesso";
            }
        }
        public async Task<IEnumerable<VeiculoCommand>> GetByIdAsync(bool Alugado)
        {
            string querySelect = @"
            SELECT * FROM VEICULO WHERE Alugado = @Alugado";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                var result = await conn.QueryAsync<VeiculoCommand>(querySelect, new { Alugado = Alugado });
                return result;
            }

        }
    }
}

