using System.ComponentModel.DataAnnotations;

namespace SystemCri.API.DTOs
{
    public class TipoCargoTrabajoCreateDto
    {
        public int? TicaCod { get; set; }

        [Required]
        [StringLength(50)]
        public string TicaNombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string? TicaDescrip { get; set; }
    }

    public class TipoCargoTrabajoUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string TicaNombre { get; set; } = string.Empty;

        [StringLength(250)]
        public string? TicaDescrip { get; set; }
    }

    public class TipoCargoTrabajoResponseDto
    {
        public int Id { get; set; }
        public string TicaNombre { get; set; } = string.Empty;
        public string? TicaDescrip { get; set; }
    }
}
