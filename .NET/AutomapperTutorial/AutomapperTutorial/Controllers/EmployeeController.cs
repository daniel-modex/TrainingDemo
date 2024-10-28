using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomapperTutorial.Models;
using AutoMapper;

namespace AutomapperTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/EmployeeDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            IEnumerable<EmployeeDTO> employees = _mapper.Map<IEnumerable<EmployeeDTO>>(await _context.Employees.ToListAsync());
            return Ok(employees);
        }

        //GET: api/EmployeeDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeDTO(int id)
        {
            var employeeDTO = _mapper.Map<EmployeeDTO>(await _context.Employees.FindAsync(id));

            if (employeeDTO == null)
            {
                return NotFound();
            }

            return employeeDTO;
        }

        //// PUT: api/EmployeeDTOes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployeeDTO(int id, EmployeeDTO employeeDTO)
        //{
        //    if (id != employeeDTO.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(employeeDTO).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeDTOExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/EmployeeDTOes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<EmployeeDTO>> PostEmployeeDTO(EmployeeDTO employeeDTO)
        //{
        //    _context.EmployeeDTO.Add(employeeDTO);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployeeDTO", new { id = employeeDTO.Id }, employeeDTO);
        //}

        //// DELETE: api/EmployeeDTOes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployeeDTO(int id)
        //{
        //    var employeeDTO = await _context.EmployeeDTO.FindAsync(id);
        //    if (employeeDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EmployeeDTO.Remove(employeeDTO);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool EmployeeDTOExists(int id)
        //{
        //    return _context.EmployeeDTO.Any(e => e.Id == id);
        //}
    }
}
