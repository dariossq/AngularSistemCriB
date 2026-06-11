using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class ProfesinCreateDto
    {
        public int? ProfCod { get; set; }

        [Required]
        [StringLength(100)]
        public string ProfNombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ProfDescrip { get; set; }
    }

    public class ProfesinUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string ProfNombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ProfDescrip { get; set; }
    }

    public class ProfesinResponseDto
    {
        public int Id { get; set; }
        public string ProfNombre { get; set; } = string.Empty;
        public string? ProfDescrip { get; set; }
    }
}
