using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using ApiPeliculas.Repositorio.IRepositorio;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using XSystem.Security.Cryptography;

namespace ApiPeliculas.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _bd;
        private string claveSecreta
        public UsuarioRepositorio(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public Usuario GetUsuario(int usuarioId)
        {
            return _bd.Usuario.FirstOrDefault(u => u.Id == usuarioId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(u => u.NombreUsuario).ToList();
        }

        public bool IsUniqueUser(string usuario)
        {
            var usuariobd = _bd.Usuario.FirstOrDefault(u => u.NombreUsuario == usuario);
            if(usuariobd == null) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var passwordEncrpitado = obtenermd5(usuarioLoginDto.Password);

            var usuario = _bd.Usuario.FirstOrDefault(
                u => u.NombreUsuario.ToLower() == usuarioLoginDto.NombreUsuario.ToLower()
                && u.Password == passwordEncrpitado
                );

            //Validamos si el usuario no existe en la combinacion de usuario y password correcta
            if(usuario == null)
            {
                return new UsuarioLoginRespuestaDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            // Aqui existe el usuario entonces podemos procesar el login
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);


        }

        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var passwordEncrpitado = obtenermd5(usuarioRegistroDto.Password);

            Usuario usuario = new Usuario()
            { 
                NombreUsuario = usuarioRegistroDto.NombreUsuario,
                Password = passwordEncrpitado,
                Nombre = usuarioRegistroDto.Nombre,
                Role = usuarioRegistroDto.Role
            };

            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            usuario.Password = passwordEncrpitado;
            return usuario;

        }

        //Método para encriptar contraseña con MD5 se usa tanto en el Acceso como en el Registro
        public static string obtenermd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
