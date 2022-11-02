using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api_bodega.Entitys
{
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        [Required]
        [StringLength(
            maximumLength: 11,
            ErrorMessage = "Verifique el Numero de Documento"
            )]
        public string NDocumento { get; set; }
        [Required]
        public string TipoDocumento { get; set; }
        [Required]
        [StringLength(
            maximumLength: 100,
            ErrorMessage = "Verifique el Nombre del Cliente"
            )]
        public string NombreCliente { get; set; }
        [Required]
        [StringLength(
            maximumLength: 100,
            ErrorMessage = "Verifique el Apellido del Cliente"
            )]
        public string ApellidoCliente { get; set; }

        [Required]
        public bool EstadoCliente { get; set; }

        public List<Comprobante> comprobante { get; set; }
    }
}
