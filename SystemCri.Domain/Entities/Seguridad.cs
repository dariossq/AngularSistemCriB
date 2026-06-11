using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Seguridad
    {
        [Key]
        public int PerCod { get; set; }

        [Required]
        public string SeguridadPer { get; set; } = null!;

        [Required]
        public string SeguridadContra { get; set; } = null!;
    }
}
