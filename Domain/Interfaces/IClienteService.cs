using Domain.Commands;

namespace Domain.Interfaces
{
    public interface IClienteService
    {
        Task<string> CadastroAsync(ClientesCommand command);
        Task<IEnumerable<ClientesCommand>> GetUfAsync(string Estado);

    }
}
