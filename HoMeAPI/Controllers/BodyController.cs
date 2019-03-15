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

        // GET api/body
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

        // GET api/body/5
        [HttpGet("{id}")]
        public IActionResult GetBodyMeasurement(int id)
        {
            var bodyMeasurement = _bodyMeasurementsRepository.GetBodyMeasurement(id);

            if (bodyMeasurement == null)
                return NotFound();

            return Ok(bodyMeasurement);
        }

        // POST api/body
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

        // PUT api/body/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BodyMeasurementDto bodyMeasurement)
        {
            if (bodyMeasurement == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bodymeasurementEntity = _bodyMeasurementsRepository.GetBodyMeasurement(id);

            if (bodymeasurementEntity == null)
                return NotFound();

            Mapper.Map(bodyMeasurement, bodymeasurementEntity);

            if(!_bodyMeasurementsRepository.Save())
                return StatusCode(500, "Something went wrong trying to update the body measurement.");

            return Ok();
        }

        // DELETE api/body/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bodyMeasurementsRepository.DeleteBodyMeasurement(id);
        }
    }
}
