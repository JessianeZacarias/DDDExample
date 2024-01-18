using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVeiculoService
    {
        Task<string> PostAsync(VeiculoCommand command);
        Task<IEnumerable<VeiculoCommand>>GetByIdAsync(bool Alugado);
    }
}
