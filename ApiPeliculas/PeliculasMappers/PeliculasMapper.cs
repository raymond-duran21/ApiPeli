using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using AutoMapper;

namespace ApiPeliculas.PeliculasMappers
{
    public class PeliculasMapper : Profile
    {
        public PeliculasMapper()
        {
           CreateMap<Categoria, CategoriaDto>().ReverseMap();
           CreateMap<Categoria, CrearCategoriaDto>().ReverseMap();
           CreateMap<Pelicula, PeliculaDto>().ReverseMap();
           CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
