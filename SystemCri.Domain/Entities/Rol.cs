using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Rol
    {
        [Key]
        public int RolCod { get; set; }

        [Required]
        [StringLength(20)]
        public string RolNom { get; set; } = null!;

        [StringLength(50)]
        public string? RolDescrip { get; set; }
    }
}
