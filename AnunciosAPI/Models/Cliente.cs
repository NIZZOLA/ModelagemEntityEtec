using System.ComponentModel.DataAnnotations;

namespace ModelagemBd;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime Nascimento { get; set; }
}