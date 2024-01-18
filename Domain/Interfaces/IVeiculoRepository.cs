using Domain.Commands;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommand command);
        Task<IEnumerable<VeiculoCommand>> GetByIdAsync(bool Alugado);

    }
}
