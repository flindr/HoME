using System;
using System.Collections.Generic;
using HoMeAPI.Entities;
using HoMeAPI.Models;

namespace HoMeAPI.Services
{
    public interface IBodyMeasurementsRepository
    {
        BodyMeasurement GetBodyMeasurement(int id);
        bool AddBodyMeasurement(BodyMeasurement measurement);
        bool UpdateBodyMeasurement(BodyMeasurement bodyMeasurementToUpdate);
        bool DeleteBodyMeasurement(int bodyMeasurementId);
        IEnumerable<BodyMeasurement> GetBodyMeasurements(DateTime? from = null, DateTime? to = null);
        bool Save();
    }
}