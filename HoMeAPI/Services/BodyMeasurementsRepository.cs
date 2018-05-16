using System;
using System.Collections.Generic;
using System.Linq;
using HoMeAPI.Entities;

namespace HoMeAPI.Services
{
    public class BodyMeasurementsRepository : IBodyMeasurementsRepository
    {
        private readonly MeasurementsContext _context;

        public BodyMeasurementsRepository(MeasurementsContext context)
        {
            _context = context;
        }

        public BodyMeasurement GetBodyMeasurement(int id)
        {
            return _context.BodyMeasurements.FirstOrDefault(m => m.Id == id);
        }

        public bool AddBodyMeasurement(BodyMeasurement bodyMeasurement)
        {
            try
            {
                _context.BodyMeasurements.Add(bodyMeasurement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            _context.SaveChanges();

            return true;
        }

        public bool UpdateBodyMeasurement(BodyMeasurement bodyMeasurementToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBodyMeasurement(int bodyMeasurementId)
        {
            var bodyMeasurementToDelete = _context.BodyMeasurements.FirstOrDefault(m => m.Id == bodyMeasurementId);

            if (bodyMeasurementToDelete == null)
                return false;

            _context.BodyMeasurements.Remove(bodyMeasurementToDelete);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<BodyMeasurement> GetBodyMeasurements(DateTime? from = null, DateTime? to = null)
        {
            if (from == null || to == null)
                return _context.BodyMeasurements;
            return _context.BodyMeasurements.Where(m => m.Time > @from && m.Time < to);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}