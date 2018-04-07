using System;
using System.Collections.Generic;
using HoMeAPI.Entities;
using HoMeAPI.Models;

namespace HoMeAPI.Services
{
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
}