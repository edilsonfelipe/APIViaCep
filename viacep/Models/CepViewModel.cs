using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viacep.Models
{
    public class CepViewModel
    {
        public string? Cep { get; set; }

        public string? Logradouro { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Uf { get; set; }

        public string? Unidade { get; set; }

        public int? IBGE { get; set; }

        public int? GIACode { get; set; }
    }
}
