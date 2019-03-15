using System;
using System.Collections.Generic;
using HoMeAPI.Entities;
using HoMeAPI.Models;

namespace HoMeAPI.Services
{
    public interface IClimateMeasurementsRepository
    {
        ClimateMeasurement GetMeasurement(int id);
        bool AddMeasurement(ClimateMeasurement climateMeasurement);
        bool UpdateMeasurement(ClimateMeasurement climateMeasurementToUpdate);
        bool DeleteMeasurement(int measurementId);
        IEnumerable<ClimateMeasurement> GetMeasurements(DateTime? from = null, DateTime? to = null);
        bool Save();
    }
}