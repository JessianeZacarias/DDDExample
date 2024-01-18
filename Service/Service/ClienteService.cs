using Domain.Commands;
using Domain.Interfaces;

namespace Service.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _repository = clienteRepository;
        }
        public async Task<string> CadastroAsync(ClientesCommand command)
        {
            int idade = DateTime.Now.Year - command.DataNascimento.Year;
            if (idade < 18)
            {
                return "Cliente deve ter mais que 18 anos";
            }
            return await _repository.CadastroAsync(command);
        }

        public async Task<IEnumerable<ClientesCommand>> GetUfAsync(string Estado)
        {
            return await _repository.GetUfAsync(Estado);
        }
    }
}
