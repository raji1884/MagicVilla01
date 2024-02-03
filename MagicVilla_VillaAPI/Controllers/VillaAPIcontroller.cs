using MagicVilla_VillaAPI.models;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

using MagicVilla_VillaAPI.models.DTO;
using MagicVilla_VillaAPI.data;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MagicVilla_VillaAPI.repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[comtroller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIcontroller : ControllerBase
    {
        public APIResponce responce;
        public readonly IVillaRepository _dbvilla;
        public readonly IMapper _mapper; 
        public VillaAPIcontroller(IVillaRepository  _dbvilla, IMapper mapper)
        {
            _dbvilla = _dbvilla;
            _mapper = mapper;
            this.responce = new ();  
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>
            > GetVillas()
        {
            IEnumerable<Villamodel> villalist = await _dbvilla.GetAllAsync();
            responce.Result  = _mapper.Map<List<VillaDTO>>(villalist);
            responce .StatusCode=HttpStatusCode.OK;
            return Ok(responce );
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(200,type=typeof(villaDTO))
        public async Task<ActionResul< >> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await  _dbvilla.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task <ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreatDTO creatDTO)

        {
            
            if (await  _dbvilla.GetAsync(u => u.Name.ToLower() == creatDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "villa already exists!");
                return BadRequest(ModelState);
            }
            if (creatDTO == null)
            {
                return BadRequest(creatDTO);
            }
            Villamodel model =_mapper .Map<Villamodel>(creatDTO);

             await  _dbvilla .CreateAsync(model);
             return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpDelete("{id}", Name = "DeleteVilla")]
        public async Task< IActionResult> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }
            var villa = await  _dbvilla.GetAllAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            await _dbvilla.RemoveAsync();
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "updateVilla")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO UpdateDTO)
        {

            if (UpdateDTO == null || id != UpdateDTO.Id)
            {
                return BadRequest();
            }
            
            Villamodel model =_mapper.Map<Villamodel>(UpdateDTO); 
            
            
            await  _dbvilla.UpdateAsync (model);
            return NoContent();

        }
        [HttpPatch("{id:int}", Name = "UpdatPartialvilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialvilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbvilla.GetAsync(u => u.Id == id, tracked:false ) ;
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
            
            if (villa == null)
            {
                return BadRequest();
            }
            
            patchDTO.ApplyTo(villaDTO, ModelState);
            Villamodel  villamodel =_mapper.Map<Villamodel>(villaDTO);
            
            await _dbvilla.UpdateAsync(villamodel);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        }
    }
