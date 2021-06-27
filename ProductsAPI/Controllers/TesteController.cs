using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        // GET /teste
        [HttpGet]
        public string Get()
        {
            return "Teste concluido com sucesso";
        }

        //GET /teste/obter-por-id/5
        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return $"valor recebido por parametro {id}";
        }

        //GET /teste/obter-por-id/5
        [HttpGet("obter-por-id/{id}")]
        public ActionResult<string> GetId(int id)
        {
            return $"valor recebido por parametro {id}";
        }

        //GET /teste/obter-todos
        [HttpGet("obter-todos")]
        public ActionResult<IEnumerable<string>> ObterTodos()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length > 5000)
                return BadRequest();

            return Ok(valores);
        }

        //GET /teste/obter-resultado
        [HttpGet("obter-resultado")]
        public ActionResult ObterResultado()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length > 5000)
                return BadRequest();

            return valores;
        }
    }

}
