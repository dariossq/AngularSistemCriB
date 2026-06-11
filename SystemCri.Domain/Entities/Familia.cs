using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Familia
    {
        [Key]
        public int FamCod { get; set; }

        public string FamNombre { get; set; } = null!;
        public string? FamDescrip { get; set; }
    }
}
