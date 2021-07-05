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
    [ApiConventionType(typeof(DefaultApiConventions))]
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
        //[HttpPost]
        //[ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Post(Product product)
        //{
        //    if (product.Id == 0) return BadRequest();

        //    // add no banco
        //    return CreatedAtAction("Post", product);
        //}


        //POST /teste
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                        nameof(DefaultApiConventions.Post))]
        public ActionResult Post(Product product)
        {
            if (product.Id == 0) return BadRequest();

            // add no banco
            return CreatedAtAction("Post", product);
        }


        //PUT /teste/5
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                        nameof(DefaultApiConventions.Put))]
        public ActionResult Put([FromRoute] int id, [FromForm] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return NotFound();

            // add no banco
            return NoContent();
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


