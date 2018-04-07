using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using HoMeAPI.Entities;
using HoMeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class MeasurementsController : Controller
    {
        private IMeasurementsRepository _measurementsRepository;

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
            if (measurementDto == null)
            {
                return BadRequest();
            }

            var measurement = Mapper.Map<Measurement>(measurementDto);

            var success = _measurementsRepository.AddMeasurement(measurement);

            if (success)
                return Ok();
            return BadRequest();
        }

        // PUT api/measurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/measurements/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class MeasurementsRepository : IMeasurementsRepository
    {
        private MeasurementsContext _context;

        public MeasurementsRepository(MeasurementsContext context)
        {
            _context = context;
        }

        public MeasurementDto GetMeasurement(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddMeasurement(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeasurement(int measurementId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeasurementDto> GetMeasurements()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMeasurementsRepository
    {
        MeasurementDto GetMeasurement(int id);
        bool AddMeasurement(Measurement measurement);
        bool DeleteMeasurement(int measurementId);
        IEnumerable<MeasurementDto> GetMeasurements();
    }
}
