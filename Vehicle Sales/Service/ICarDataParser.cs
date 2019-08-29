using System.Collections.Generic;
using Vehicle_Sales.Models;

namespace Vehicle_Sales.Service
{
    public interface ICarDataService
    {
        List<VehicleModel> TransformCarData(List<string> lines);
    }
}