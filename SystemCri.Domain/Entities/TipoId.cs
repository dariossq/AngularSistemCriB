using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class TipoId
    {
        [Key]
        public int TipoIdCod { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoIdNom { get; set; } = null!;

        [Required]
        [StringLength(4)]
        public string TipoIdSigla { get; set; } = null!;
    }
}
