using System.Linq;
using AutoMapper;
using HoMeAPI.Entities;
using HoMeAPI.Models;
using HoMeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class MeasurementsController : Controller
    {
        private readonly IMeasurementsRepository _measurementsRepository;

        public MeasurementsController(IMeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        // GET api/measurements
        [HttpGet]
        public IActionResult GetMeasurements()
        {
            var measurements = _measurementsRepository.GetMeasurements();

            if (!measurements.Any())
            {
                return NotFound();
            }

            return Ok(measurements);
        }

        // GET api/measurements/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var measurement = _measurementsRepository.GetMeasurement(id);

            if (measurement == null)
                return NotFound();

            return Ok(measurement);
        }

        // POST api/measurements
        [HttpPost]
        public IActionResult Post([FromBody]MeasurementDto measurementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (measurementDto == null)
            {
                return BadRequest();
            }

            var measurement = Mapper.Map<Measurement>(measurementDto);

            //TODO How to handle errors?
            var success = _measurementsRepository.AddMeasurement(measurement);

            if (success)
                return Ok();
            return BadRequest();
        }

        // PUT api/measurements/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MeasurementDto measurement)
        {
            if (measurement == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var measurementEntity = _measurementsRepository.GetMeasurement(id);

            if (measurementEntity == null)
                return NotFound();

            Mapper.Map(measurement, measurementEntity);

            if(!_measurementsRepository.Save())
                return StatusCode(500, "Something went wrong trying to update the measurement.");

            return Ok();
        }

        // DELETE api/measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _measurementsRepository.DeleteMeasurement(id);
        }
    }
}
