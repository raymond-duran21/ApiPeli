using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Models.Dtos
{
    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es 100.")]
        public string Nombre { get; set; }
    }
}
