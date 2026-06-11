using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Escolaridad
    {
        [Key]
        public int EscolaridadCod { get; set; }

        public string EscolaridadNom { get; set; } = null!;
        public string? EscolaridadDescrip { get; set; }
    }
}
