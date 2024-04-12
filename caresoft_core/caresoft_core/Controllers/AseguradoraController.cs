using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Models;
using caresoft_core.Services;
using caresoft_core.Utils;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradoraController(AseguradoraService aseguradoraService) : ControllerBase
    {
        private readonly AseguradoraService _aseguradoraService = aseguradoraService;
        private readonly LogHandler<AseguradoraController> _logHandler = new();

        // GET: api/Aseguradora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aseguradora>>> GetAseguradoras()
        {
            try
            {
                return await _aseguradoraService.GetAllAseguradoras();

            } catch (Exception ex)
            {
                _logHandler.LogFatal("Error al obtener las aseguradoras", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las aseguradoras");
            }
        }

        // GET: api/Aseguradora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aseguradora>> GetAseguradora(uint id)
        {
            try
            {
                var aseguradora = await _aseguradoraService.GetAseguradoraById(id);

                if (aseguradora == null)
                {
                    return NotFound();
                }

                return aseguradora;
            } catch (Exception ex)
            {
                _logHandler.LogFatal("Error al obtener la aseguradora", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la aseguradora");
            }
        }

        // PUT: api/Aseguradora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAseguradora(uint id, Aseguradora aseguradora)
        {
           try
            {
                if (id != aseguradora.IdAseguradora)
                {
                    return BadRequest();
                }

                bool updated = await _aseguradoraService.UpdateAseguradora(id, aseguradora);

                if (!updated)
                {
                    return NotFound();
                }
                return Ok();
            } catch (Exception ex)
            {
                _logHandler.LogFatal("Error al actualizar la aseguradora", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la aseguradora");
            }
        }


        // POST: api/Aseguradora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aseguradora>> PostAseguradora(Aseguradora aseguradora)
        {
            try
            {
                Aseguradora newAseguradora = await _aseguradoraService.CreateAseguradora(aseguradora);

                return CreatedAtAction("GetAseguradora", new { id = newAseguradora.IdAseguradora }, newAseguradora);
            } catch (Exception ex)
            {
                _logHandler.LogFatal("Error al crear la aseguradora", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la aseguradora");
            }
            
        }

        // DELETE: api/Aseguradora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAseguradora(uint id)
        {
            try
            {
                Aseguradora? aseguradora = await _aseguradoraService.GetAseguradoraById(id);

                if (aseguradora == null)
                {
                    return NotFound();
                }

                bool deleted = await _aseguradoraService.DeleteAseguradora(id);

                if (deleted)
                {
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _logHandler.LogFatal("Error al eliminar la aseguradora", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la aseguradora");
            }
            
        }

    }
}
