using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace anular_venta.Entitys
{
    public class Aventas
    {
        [Key]
        public int NumeroDeComprobante { get; set; }
        [Required]
        [StringLength(maximumLength:50, ErrorMessage ="Que tipo de comprobante es")]
        public string TipoDeComprobante { get; set; }

        [Required]
        public string Desde { get; set; }
       
        [Required]
        public string Hasta { get; set; }
    }
}
