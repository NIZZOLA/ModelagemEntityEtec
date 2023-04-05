using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemBd
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public ICollection<Endereco>? Enderecos { get; set; }
        public ICollection<Anuncio>? Anuncios { get; set; }
        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}
