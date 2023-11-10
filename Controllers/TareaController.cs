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
    public class TareaController : ControllerBase
    {
        private readonly ILogger<TareaController> _logger;

        private ITareaRepository manejoTarea;
        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            manejoTarea = new TareaRepository();
        }

        // [HttpPost]
        // [Route("{idTablero}")]
        [HttpPost]
        [Route("/api/tarea")]
        public ActionResult AddTarea(int idTablero,Tarea tarea)
        {
            manejoTarea.Create(idTablero, tarea);
            return Ok("Tarea creada");
        }

        [HttpPut] 
        [Route("/api/Nombre/{id}")] 
        public ActionResult<Tarea> UpdateEstado(int id, Tarea tarea)
        {
            var tarea1 = manejoTarea.GetById(id);
            tarea1.Nombre = tarea.Nombre;
            manejoTarea.Update(id, tarea1);
            return Ok(tarea1);
        }

        [HttpPut] 
        [Route("/api/Tarea/{id}/Estado/{estado}")] 
        public ActionResult<Tarea> UpdateEstadoTarea(int id, EstadoTarea estado)
        {
            var tarea1 = manejoTarea.GetById(id);
            tarea1.Estado = estado;
            manejoTarea.Update(id, tarea1);
            return Ok(tarea1);
        }

        [HttpDelete]
        [Route("/api/Tarea/{id}")]
        public void Delete(int id)
        {
            manejoTarea.Remove(id);
        }

        [HttpGet]
        [Route("/api/tarea/{estado}")] 
        public ActionResult<int> CantidadTareasPorEstado(EstadoTarea estado){
            var tareas = manejoTarea.GetAllByEstado(estado);
            return Ok(tareas.Count());
        }

        [HttpGet]
        [Route("/api/Tarea/Usuario/{Id}")]
        public ActionResult<List<Tarea>> GetAllByIdUsuario(int id)
        {
            var tareas = manejoTarea.GetAllByIdUsuario(id);
            return Ok(tareas);
        }

        [HttpGet]
        [Route("/api/Tarea/Tablero/{id}")]
        public ActionResult<List<Tarea>> GetAllByIdTablero(int id)
        {
            var tareas = manejoTarea.GetAllByIdTablero(id);
            return Ok(tareas);
        }
        
    }
}