using System;
using System.Collections.Generic;
using System.Linq;
using HoMeAPI.Entities;

namespace HoMeAPI.Services
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        private readonly MeasurementsContext _context;

        public MeasurementsRepository(MeasurementsContext context)
        {
            _context = context;
        }

        public Measurement GetMeasurement(int id)
        {
            return _context.Measurements.FirstOrDefault(m => m.Id == id);
        }

        public bool AddMeasurement(Measurement measurement)
        {
            try
            {
                _context.Measurements.Add(measurement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            _context.SaveChanges();

            return true;
        }

        public bool DeleteMeasurement(int measurementId)
        {
            var measurementToDelete = _context.Measurements.FirstOrDefault(m => m.Id == measurementId);

            if (measurementToDelete == null)
                return false;

            _context.Measurements.Remove(measurementToDelete);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Measurement> GetMeasurements()
        {
            return _context.Measurements;
        }
    }
}