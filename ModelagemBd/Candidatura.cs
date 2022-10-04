using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemBd
{
    public class Candidatura
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Anuncio")]
        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }

        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }
        public Cliente? Candidato { get; set; }

        public StatusEnum Status { get; set; }

        public ICollection<CandidaturaHistorico>? Historico { get; set; }
    }
}
