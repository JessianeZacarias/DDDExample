using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using System.Data;

namespace Service.Service
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> PostAsync(VeiculoCommand command)
        {
            if (command == null)
                return "Todos os campos são obrigatórios";

            int anoAtual = DateTime.Now.Year;
            if (anoAtual - command.AnoFabricacao > 5)
                return "O Ano do veículo é menor que o permitido";


            if (command.TipoVeiculo != ETipoVeiculo.SUV
                && command.TipoVeiculo != ETipoVeiculo.Hatch
                && command.TipoVeiculo != ETipoVeiculo.Fusion)

                return "O Tipo de Veículo não é permitido";

            return await _repository.PostAsync(command);

        }
        public async Task<IEnumerable<VeiculoCommand>> GetByIdAsync(bool Alugado)
        {
            return await _repository.GetByIdAsync(Alugado);
        }

    }
}
