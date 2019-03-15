using System;
using System.Collections.Generic;
using System.Linq;
using HoMeAPI.Entities;

namespace HoMeAPI.Services
{
    public class ClimateMeasurementsRepository : IClimateMeasurementsRepository
    {
        private readonly MeasurementsContext _context;

        public ClimateMeasurementsRepository(MeasurementsContext context)
        {
            _context = context;
        }

        public ClimateMeasurement GetMeasurement(int id)
        {
            return _context.ClimateMeasurements.FirstOrDefault(m => m.Id == id);
        }

        public bool AddMeasurement(ClimateMeasurement climateMeasurement)
        {
            try
            {
                _context.ClimateMeasurements.Add(climateMeasurement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            _context.SaveChanges();

            return true;
        }

        public bool UpdateMeasurement(ClimateMeasurement climateMeasurementToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeasurement(int measurementId)
        {
            var measurementToDelete = _context.ClimateMeasurements.FirstOrDefault(m => m.Id == measurementId);

            if (measurementToDelete == null)
                return false;

            _context.ClimateMeasurements.Remove(measurementToDelete);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ClimateMeasurement> GetMeasurements(DateTime? from = null, DateTime? to = null)
        {
            if (from == null || to == null)
                return _context.ClimateMeasurements;
            return _context.ClimateMeasurements.Where(m => m.Time > @from && m.Time < to);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}