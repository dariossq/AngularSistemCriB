using System.ComponentModel.DataAnnotations;

namespace SystemCri.Domain.Entities
{
    public class Profesion
    {
        [Key]
        public int ProfCod { get; set; }

        public string ProfNombre { get; set; } = null!;
        public string? ProfDescrip { get; set; }
    }
}
