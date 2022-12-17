using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api_bodega.Entitys
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Verifique el nombre del empleado")]
        public string NombreEmpleado { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Verifique el nombre del usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Verifique la contraseña del usuario")]
        public string ContraseñaUsuario { get; set; }

        [Required]
        public bool EstadoUsuario { get; set; }

        public List<Comprobante> comprobante { get; set; }
    }
}

