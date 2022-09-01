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
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Endereco>? Enderecos { get; set; }
        public ICollection<Anuncio>? Anuncios { get; set; }
        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}
