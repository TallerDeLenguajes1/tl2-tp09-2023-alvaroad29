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
    public class TableroController : ControllerBase
    {
        private readonly ILogger<TableroController> _logger;

        private ITableroRepository manejoTablero;
        public TableroController(ILogger<TableroController> logger)
        {
            _logger = logger;
            manejoTablero = new TableroRepository();
        }

        [HttpPost]
        public void AddTablero(Tablero tablero)
        {
            manejoTablero.Create(tablero);
        }

        [HttpGet]
        public ActionResult<List<Tablero>> GetAll()
        {
            var tableros = manejoTablero.GetAll();
            return Ok(tableros);
        }
    }
}