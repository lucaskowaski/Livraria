using Livraria.Application.Interfaces;
using Livraria.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Services.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_livroService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            return Ok(_livroService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]LivroViewModel livro)
        {
            _livroService.Add(livro);
            return Ok(livro);
        }

        [HttpPut]
        public IActionResult Put([FromBody]LivroViewModel livro)
        {
            _livroService.Update(livro);
            return Ok(livro);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _livroService.Remove(id);
            return Ok(true);
        }

    }
}