using Domain.Commands;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<string> CadastroAsync(ClientesCommand command);
        Task<IEnumerable<ClientesCommand>> GetUfAsync(string Estado);
    }
}
