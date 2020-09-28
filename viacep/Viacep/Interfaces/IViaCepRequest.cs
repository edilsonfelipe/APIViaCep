using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using viacep.Models;

namespace viacep.Viacep.Interfaces
{
    public interface IViaCepRequest
    {
        ViaCepResultado BuscarPorCep(string cep);
        IEnumerable<ViaCepResultado> BuscarPorEndereco(string uf, string cidade, string logradouro);

        Task<ViaCepResultado> SearchAsync(string cep, CancellationToken cancellationToken);

        Task<IEnumerable<ViaCepResultado>> SearchAsync(string uf, string cidade, string logradouro, CancellationToken cancellationToken);
    }
}
