using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HoMeAPI.Entities;
using HoMeAPI.Models;
using HoMeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HoMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClimateController : Controller
    {
        private readonly IClimateMeasurementsRepository _climateMeasurementsRepository;
        private readonly ILogger<ClimateController> _logger;

        public ClimateController(IClimateMeasurementsRepository climateMeasurementsRepository, ILogger<ClimateController> logger)
        {
            _logger = logger;
            _climateMeasurementsRepository = climateMeasurementsRepository;
        }

        // GET api/climate
        [HttpGet]
        public IActionResult GetClimateMeasurements([FromQuery]string from, [FromQuery]string to)
        {
            DateTime.TryParse(from, out var fromDateTime);
            DateTime.TryParse(to, out var toDateTime);

            List<ClimateMeasurement> climateMeasurements;
            if (from == null || to == null)
            {
                _logger.LogInformation("Getting measurements");
                climateMeasurements = _climateMeasurementsRepository.GetMeasurements().ToList();
            }
            else
            {
                climateMeasurements = _climateMeasurementsRepository.GetMeasurements(fromDateTime, toDateTime).ToList();
            }


            if (!climateMeasurements.Any())
            {
                return NotFound();
            }

            return Ok(climateMeasurements);
        }

        // GET api/climate/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var climateMeasurement = _climateMeasurementsRepository.GetMeasurement(id);

            if (climateMeasurement == null)
                return NotFound();

            return Ok(climateMeasurement);
        }

        // POST api/climate
        [HttpPost]
        public IActionResult Post([FromBody]ClimateMeasurementDto climateMeasurementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (climateMeasurementDto == null)
            {
                return BadRequest();
            }

            var climateMeasurement = Mapper.Map<ClimateMeasurement>(climateMeasurementDto);

            //TODO How to handle errors?
            var success = _climateMeasurementsRepository.AddMeasurement(climateMeasurement);

            if (success)
                return Ok();
            return BadRequest();
        }

        // PUT api/climate/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ClimateMeasurementDto climateMeasurement)
        {
            if (climateMeasurement == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var measurementEntity = _climateMeasurementsRepository.GetMeasurement(id);

            if (measurementEntity == null)
                return NotFound();

            Mapper.Map(climateMeasurement, measurementEntity);

            if(!_climateMeasurementsRepository.Save())
                return StatusCode(500, "Something went wrong trying to update the climateMeasurement.");

            return Ok();
        }

        // DELETE api/climate/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _climateMeasurementsRepository.DeleteMeasurement(id);
        }
    }
}
