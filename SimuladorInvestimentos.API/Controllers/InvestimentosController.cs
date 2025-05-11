using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladorInvestimentos.Core.Models;
using SimuladorInvestimentos.Core.Services;

namespace SimuladorInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentosController : ControllerBase
    {
        private readonly InvestimentoService _service;

        public InvestimentosController(InvestimentoService service)
        {
            _service = service;
        }


        /// <summary>
        /// Retorna todos os investimentos cadastrados.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna uma lista de todos os investimentos disponíveis no sistema.
        /// </remarks>
        /// <response code="200">Retorna a lista de investimentos cadastrados.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var investimentos = _service.ObterTodos();
            return Ok(investimentos);
        }

        /// <summary>
        /// Cria um novo investimento.
        /// </summary>
        /// <param name="investimento">Objeto contendo os dados do investimento a ser criado.</param>
        /// <remarks>
        /// Este endpoint cria um novo investimento com base nos dados fornecidos.
        /// </remarks>
        /// <response code="201">O investimento foi criado com sucesso.</response>
        /// <response code="400">Os dados fornecidos são inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Investimento investimento)
        {
            if (investimento == null || string.IsNullOrEmpty(investimento.Nome) || investimento.ValorInicial <= 0)
                return BadRequest("Dados inválidos para criação do investimento.");

            var novoInvestimento = _service.Criar(investimento);
            return CreatedAtAction(nameof(GetById), new { id = novoInvestimento.Id }, novoInvestimento);
        }

        /// <summary>
        /// Retorna um investimento específico pelo ID.
        /// </summary>
        /// <param name="id">ID do investimento a ser consultado.</param>
        /// <remarks>
        /// Este endpoint retorna os dados de um investimento específico com base no ID fornecido.
        /// </remarks>
        /// <response code="200">Retorna os dados do investimento.</response>
        /// <response code="404">O investimento com o ID fornecido não foi encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var investimento = _service.ObterPorId(id);
            if (investimento == null)
                return NotFound();

            return Ok(investimento);
        }

        /// <summary>
        /// Atualiza os dados de um investimento existente.
        /// </summary>
        /// <param name="id">ID do investimento a ser atualizado.</param>
        /// <param name="investimento">Objeto contendo os novos dados do investimento.</param>
        /// <remarks>
        /// Este endpoint atualiza os dados de um investimento existente com base no ID fornecido.
        /// </remarks>
        /// <response code="200">O investimento foi atualizado com sucesso.</response>
        /// <response code="400">Os dados fornecidos são inválidos.</response>
        /// <response code="404">O investimento com o ID fornecido não foi encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Investimento investimento)
        {
            if (investimento == null || id <= 0 || investimento.Id != id)
                return BadRequest("Dados inválidos para atualização.");

            var atualizado = _service.Atualizar(id, investimento);
            if (!atualizado)
                return NotFound();

            return Ok(investimento);
        }

        /// <summary>
        /// Remove um investimento pelo ID.
        /// </summary>
        /// <param name="id">ID do investimento a ser removido.</param>
        /// <remarks>
        /// Este endpoint remove um investimento existente com base no ID fornecido.
        /// </remarks>
        /// <response code="204">O investimento foi removido com sucesso.</response>
        /// <response code="400">O ID fornecido é inválido.</response>
        /// <response code="404">O investimento com o ID fornecido não foi encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido.");

            var removido = _service.Remover(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
