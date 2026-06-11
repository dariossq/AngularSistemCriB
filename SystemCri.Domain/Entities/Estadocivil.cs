using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Estadocivil
    {
        [Key]
        public int EstadocCod { get; set; }

        public string EstadocNom { get; set; } = null!;
        public string? EstadocDescrip { get; set; }
    }
}
