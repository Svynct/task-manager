using System;
using Microsoft.AspNetCore.Mvc;
using TaskManager_WebAPI.Data;
using TaskManager_WebAPI.Models;

namespace TaskManager_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository _repo;
        public UsuarioController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _repo.GetUsuarios();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpGet("{usuarioId}")]
        public IActionResult GetByUsuarioId(int usuarioId)
        {
            try
            {
                var result = _repo.GetUsuarioById(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("registrar")]
        public IActionResult Post(Usuario model)
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
        [HttpPut("{usuarioId}")]
        public IActionResult Put(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = _repo.GetUsuarioById(usuarioId);
                if (usuario == null) return NotFound("Usuário não encontrada");

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
        [HttpDelete("{usuarioId}")]
        public IActionResult Delete(int usuarioId)
        {
            try
            {
                var usuario = _repo.GetUsuarioById(usuarioId);
                if (usuario == null) return NotFound("Usuário não encontrada");

                _repo.Delete(usuario);

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