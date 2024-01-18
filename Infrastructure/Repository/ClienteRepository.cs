using Dapper;
using Domain.Commands;
using Domain.Interfaces;
using System.Data.SqlClient;

public class ClienteRepository : IClienteRepository
{
    string conexao = @"Server=DESKTOP-HICDFBH;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";
    public async Task<string> CadastroAsync(ClientesCommand command)
    {
        string queryCreate = @"
            INSERT INTO Clientes(Nome, DataNascimento, Habilitacao, Estado)
            Values(@Nome, @DataNascimento, @Habilitacao, @Estado)
            ";
        using (SqlConnection conn = new SqlConnection(conexao))
        {
            conn.Execute(queryCreate, new
            {
                Nome = command.Nome,
                DataNascimento = command.DataNascimento,
                Habilitacao = command.Habilitacao,
                Estado = command.Estado,
            });
            return "Cadastrado com Sucesso";
        }
    }
    public async Task<IEnumerable<ClientesCommand>> GetUfAsync(string Estado)
    {
        string query = @"
            SELECT * FROM Clientes WHERE Estado = @Estado";
        using (SqlConnection conn = new SqlConnection(conexao))
        {
            conn.Open();
            return await conn.QueryAsync<ClientesCommand>(query, new { Estado = Estado });

        }

    }
}