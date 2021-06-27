using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //POST /teste
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(Product product)
        {
            if (product.Id == 0) return BadRequest();

            // add no banco
            return CreatedAtAction("Post", product);
        }


        public class Product
        {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Description { get; set; }
        }

    }

}
