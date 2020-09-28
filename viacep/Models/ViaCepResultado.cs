using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viacep.Models
{
    public class ViaCepResultado
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("ibge")]
        public int IBGE { get; set; }

        [JsonProperty("gia")]
        public int? GIACode { get; set; }
    }
}
