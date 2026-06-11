using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemCri.Domain.Entities
{
    public class Vereda
    {
        [Key]
        public int VeredaCod { get; set; }

        [Required]
        public string VeredaNom { get; set; } = null!;

        public string? VeredaUbicacion { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
