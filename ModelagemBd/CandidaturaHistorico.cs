using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelagemBd
{
    public class CandidaturaHistorico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Candidatura")]
        public int CandidaturaId { get; set; }
        public Anuncio? Candidatura { get; set; }

        public DateTime DataDoStatus { get; set; }
        public StatusEnum Status { get; set; }
    }
}
