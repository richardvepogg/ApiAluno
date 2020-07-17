using System.Collections.Generic;
using APIAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Repositorio;

namespace Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller 
    {
       private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        } 

       [HttpGet("{id}", Name="GetUsuario")]
       public IActionResult GetById(long id)
       {
           var usuario = _usuarioRepositorio.Find(id);
           if(usuario==null)
           return NotFound();

           return new ObjectResult(usuario);
       }



    }
}