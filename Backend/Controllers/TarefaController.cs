using System;
using Microsoft.AspNetCore.Mvc;
using TaskManager_WebAPI.Data;
using TaskManager_WebAPI.Models;

namespace TaskManager_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IRepository _repo;
        public TarefaController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _repo.GetTarefas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpGet("{tarefaId}")]
        public IActionResult GetByTarefaId(int tarefaId)
        {
            try
            {
                var result = _repo.GetTarefasById(tarefaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("registrar")]
        public IActionResult Post(Tarefa model)
        {
            try
            {
                _repo.Add(model);

                if (_repo.SaveChanges())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }

            return BadRequest();
        }
        [HttpPut("{tarefaId}")]
        public IActionResult Put(int tarefaId, Tarefa model)
        {
            try
            {
                var tarefa = _repo.GetTarefasById(tarefaId);
                if (tarefa == null) return NotFound("Tarefa não encontrada");

                _repo.Update(model);

                if (_repo.SaveChanges())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }

            return BadRequest();
        }
        [HttpDelete("{tarefaId}")]
        public IActionResult Delete(int tarefaId)
        {
            try
            {
                var tarefa = _repo.GetTarefasById(tarefaId);
                if (tarefa == null) return NotFound("Tarefa não encontrada");

                _repo.Delete(tarefa);

                if (_repo.SaveChanges())
                {
                    return Ok(new { message = "Deletado" });
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }

            return BadRequest();
        }
    }
}