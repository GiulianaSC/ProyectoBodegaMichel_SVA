using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bodega.Entitys
{
    public class Comprobante
    {
        [Key]
        public int idComprobante { get; set; }

        [Required]
        [StringLength(
            maximumLength: 11,
            ErrorMessage = "Verifique el Tipo de Comprobante"
            )]
        public string TipoComprobante{ get; set; }

        [Required]
        public string FechaComprobante { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Igv { get; set; }

        [Required]
        public bool EstadoComprobante { get; set; }
        [Required]
        public int idCliente { get; set; }

        public Cliente cliente { get; set; }

        [Required]
        public int idUsuario{ get; set; }
        public Usuario usuario { get; set; }

    }
}
