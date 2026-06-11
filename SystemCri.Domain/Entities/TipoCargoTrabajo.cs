using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class TipoCargoTrabajo
    {
        [Key]
        public int TicaCod { get; set; }

        [Required]
        public string TicaNombre { get; set; } = null!;

        public string? TicaDescrip { get; set; }
    }
}
