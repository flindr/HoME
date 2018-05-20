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
    public class BodyController : Controller
    {
        private readonly IBodyMeasurementsRepository _bodyMeasurementsRepository;
        private readonly ILogger<BodyController> _logger;

        public BodyController(IBodyMeasurementsRepository bodyMeasurementsRepository, ILogger<BodyController> logger)
        {
            _logger = logger;
            _bodyMeasurementsRepository = bodyMeasurementsRepository;
        }

        // GET api/measurements
        [HttpGet]
        public IActionResult GetBodyMeasurements([FromQuery]string from, [FromQuery]string to)
        {
            DateTime.TryParse(from, out var fromDateTime);
            DateTime.TryParse(to, out var toDateTime);

            List<BodyMeasurement> bodyMeasurements;
            if (from == null || to == null)
            {
                _logger.LogInformation("Getting body measurements");
                bodyMeasurements = _bodyMeasurementsRepository.GetBodyMeasurements().ToList();
            }
            else
            {
                bodyMeasurements = _bodyMeasurementsRepository.GetBodyMeasurements(fromDateTime, toDateTime).ToList();
            }


            if (!bodyMeasurements.Any())
            {
                return NotFound();
            }

            return Ok(bodyMeasurements);
        }

        // GET api/measurements/5
        [HttpGet("{id}")]
        public IActionResult GetBodyMeasurement(int id)
        {
            var bodyMeasurement = _bodyMeasurementsRepository.GetBodyMeasurement(id);

            if (bodyMeasurement == null)
                return NotFound();

            return Ok(bodyMeasurement);
        }

        // POST api/measurements
        [HttpPost]
        public IActionResult Post([FromBody]BodyMeasurementDto bodyMeasurementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bodyMeasurementDto == null)
            {
                return BadRequest();
            }

            var bodyMeasurement = Mapper.Map<BodyMeasurement>(bodyMeasurementDto);

            //TODO How to handle errors?
            var success = _bodyMeasurementsRepository.AddBodyMeasurement(bodyMeasurement);

            if (success)
                return Ok();
            return BadRequest();
        }

        // PUT api/measurements/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BodyMeasurementDto bodyMeasurement)
        {
            if (bodyMeasurement == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var measurementEntity = _bodyMeasurementsRepository.GetBodyMeasurement(id);

            if (measurementEntity == null)
                return NotFound();

            Mapper.Map(bodyMeasurement, measurementEntity);

            if(!_bodyMeasurementsRepository.Save())
                return StatusCode(500, "Something went wrong trying to update the measurement.");

            return Ok();
        }

        // DELETE api/measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bodyMeasurementsRepository.DeleteBodyMeasurement(id);
        }
    }
}
