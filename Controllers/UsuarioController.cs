using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tl2_tp09_2023_alvaroad29.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsuarioRepository manejoUsuario;
        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            manejoUsuario = new UsuarioRepository();
        }

        //[HttpGet("GetAll")]
        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            var usuarios = manejoUsuario.GetAll();
            return Ok(usuarios);
        }

        [HttpPost]
        public void AddUser(Usuario usuario)
        {
            manejoUsuario.Create(usuario);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Usuario> GetUser(int id)
        {
            var usuario = manejoUsuario.GetById(id);
            return Ok(usuario);
        }

        [HttpPut]
        [Route("{id}")] //??
        public ActionResult UpdateUser(int id, Usuario usuario) // public void UpdateUser(int id, [FromBody] Usuario usuario)??
        {
            manejoUsuario.Update(id,usuario);
            return Ok();
        }
    }
}