using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class TipoIdCreateDto
    {
        public int? TipoIdCod { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoIdNom { get; set; } = string.Empty;

        [Required]
        [StringLength(4)]
        public string TipoIdSigla { get; set; } = string.Empty;
    }

    public class TipoIdUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string TipoIdNom { get; set; } = string.Empty;

        [Required]
        [StringLength(4)]
        public string TipoIdSigla { get; set; } = string.Empty;
    }

    public class TipoIdResponseDto
    {
        public int Id { get; set; }
        public string TipoIdNom { get; set; } = string.Empty;
        public string TipoIdSigla { get; set; } = string.Empty;
    }
}
