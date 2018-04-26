using System;
using System.Collections.Generic;
using HoMeAPI.Entities;
using HoMeAPI.Models;

namespace HoMeAPI.Services
{
    public interface IMeasurementsRepository
    {
        Measurement GetMeasurement(int id);
        bool AddMeasurement(Measurement measurement);
        bool UpdateMeasurement(Measurement measurementToUpdate);
        bool DeleteMeasurement(int measurementId);
        IEnumerable<Measurement> GetMeasurements(DateTime? from = null, DateTime? to = null);
        bool Save();
    }
}