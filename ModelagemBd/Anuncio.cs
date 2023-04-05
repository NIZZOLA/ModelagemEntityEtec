using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelagemBd
{
    public class Anuncio
    {
        public int Id { get; set; }
        public int AnuncianteId { get; set; }
        public virtual Cliente? Anunciante { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public ICollection<Candidatura>? Candidaturas { get; set; }
    }
}