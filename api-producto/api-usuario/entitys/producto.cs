using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_producto.entitys
{
    public class producto
    {
        //Definimos la clave primaria 
        [Key]
        public int codigoProd { get; set; }
       
        //definimos valores no nulos
        [Required]
        //definimos el tamaño del campo
        [StringLength(maximumLength:100,ErrorMessage ="Se tiene que ingresar un nombre")]
        public String nombre { get; set; }

        public int precioventa { get; set; }
        public int stock { get; set; }
        public String categoria { get; set; }
        public String nombreProd { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
