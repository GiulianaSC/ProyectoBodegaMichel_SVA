using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_usuario.entitys
{
    public class usuario
    {
        //Definimos la clave primaria 
        [Key]
        public int codigo { get; set; }
        //definimos valores no nulos
        [Required]
        //definimos el tamaño del campo
        [StringLength(maximumLength:100,ErrorMessage ="Se tiene que ingresar un nombre")]
        public String nombre { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
