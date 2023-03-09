using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Contracts;
using HotelListing.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models.Country;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CountriesController : ControllerBase
    {
        private readonly ICountries _CountryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountries CountryRepository, IMapper mapper)
        {
            _CountryRepository= CountryRepository;
            _mapper = mapper;

        }

        // GET: api/Countries
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var country = await _CountryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(country);

            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _CountryRepository.GetDetails(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }
            var record = _mapper.Map<CountryDto>(country);

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Id doesn't match");
            }
            
            var country = await _CountryRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }
            _mapper.Map(updateCountryDto, country);
            

            try
            {
                await _CountryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( !await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry countrycreation)
        {
            var country = _mapper.Map<Country>(countrycreation);
            await _CountryRepository.AddAsync(country);
            

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _CountryRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }

            await _CountryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _CountryRepository.Exists(id);   
        }
    }
}
