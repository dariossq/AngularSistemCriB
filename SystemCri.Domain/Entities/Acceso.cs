using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemCri.Domain.Entities
{
    public class Acceso
    {
        [Key]
        public int CodAcceso { get; set; }

        public DateTime FechaIAcceso { get; set; }
        public DateTime FechaFAcceso { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
