using System.Collections.Generic;
using HoMeAPI.Entities;
using HoMeAPI.Models;

namespace HoMeAPI.Services
{
    public interface IMeasurementsRepository
    {
        MeasurementDto GetMeasurement(int id);
        bool AddMeasurement(Measurement measurement);
        bool DeleteMeasurement(int measurementId);
        IEnumerable<MeasurementDto> GetMeasurements();
    }
}