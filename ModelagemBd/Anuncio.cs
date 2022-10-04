using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelagemBd;

public class Anuncio {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Anunciante")]
    public int AnuncianteId { get; set; }
    public Cliente? Anunciante { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
}