﻿using ApiPeliculas.Models;

namespace ApiPeliculas.Repositorio.IRepositorio
{
    public interface IPeliculaRepositorio
    {
        ICollection<Pelicula> GetPeliculas();
        Pelicula GetPelicula(int peliculaId);
        bool ExistePelicula(string nombre);
        bool ExistePelicula(int id);
        bool CrearPelicula(Pelicula pelicula);
        bool ActualizarPelicula(Pelicula pelicula);
        bool BorrarPelicula(Pelicula pelicula);

        //Metodos para buscar peliculas en categoria y buscar pelicula por nombre

        ICollection<Pelicula> GetPeliculasEnCategoria(int catId);
        ICollection<Pelicula> BuscarPelicula(string nombre);


        bool Guardar();
    }
}
