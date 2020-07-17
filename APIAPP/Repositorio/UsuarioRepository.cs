using System.Collections.Generic;
using System.Linq;
using APIAPP.Models;

namespace Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {  

      private readonly UsuarioDbContext _contexto;

       public UsuarioRepository(UsuarioDbContext ctx)
       {
           _contexto = ctx;
       }

        public void Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.UsuarioID == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
           return _contexto.Usuarios.ToList();
        }

        public void Remove(long id)
        {
          var entity = _contexto.Usuarios.First(u=> u.UsuarioID
           ==id);
           _contexto.Usuarios.Remove(entity);
           _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}