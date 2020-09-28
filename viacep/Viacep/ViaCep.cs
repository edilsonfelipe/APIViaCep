using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using viacep.Models;
using viacep.Viacep.Interfaces;

namespace viacep.Viacep
{
    public class ViaCep : IViaCepRequest
    {
        private const string BaseUrl = "https://viacep.com.br";

        private readonly HttpClient _httpClient;

        public ViaCep()
        {
            _httpClient = HttpClientFactory.Create();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public ViaCep(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ViaCepResultado BuscarPorCep(string cep)
        {
            return SearchAsync(cep, CancellationToken.None).Result;
        }

        public IEnumerable<ViaCepResultado> BuscarPorEndereco(string uf, string cidade, string logradouro)
        {
            return SearchAsync(uf, cidade, logradouro, CancellationToken.None).Result;
        }

        public async Task<ViaCepResultado> SearchAsync(string cep, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/ws/{cep}/json", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ViaCepResultado>(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ViaCepResultado>> SearchAsync(string uf, string cidade, string logradouro, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/ws/{uf}/{cidade}/{logradouro}/json", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<ViaCepResultado>>(cancellationToken).ConfigureAwait(false);
        }
    }
}
