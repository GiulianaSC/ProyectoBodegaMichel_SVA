using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bodega.Entitys
{
    public class DetalleComprobante
    {
        [Key]
        public int idDetalleComprobante { get; set; }

        [Required]
        public int CantProducto { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioVenta { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ImporteProducto { get; set; }

        [Required]
        public int idProducto { get; set; }
        public Producto producto { get; set; }

        [Required]
        public int idComprobante { get; set; }
        public Comprobante comprobante { get; set; }
    }
}
