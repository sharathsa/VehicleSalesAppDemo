using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Vehicle_Sales.Models;

namespace Vehicle_Sales.Service
{
    public class CarDataService : ICarDataService
    {
        public List<VehicleModel> TransformCarData(List<string> lines)
        {
            var vehicleList = new List<VehicleModel>();

            for (var x = 1; x <= lines?.Count - 1; x++)
            {
                var splitFields = Regex.Split(lines[x], @",(?=(?:[^""]*""[^""]*"")*[^""]*$)");
                var vehicle = new VehicleModel();

                vehicle.DealNumber = int.Parse(splitFields[0]?.Replace(@"""", string.Empty));
                vehicle.CustomerName = splitFields[1]?.Replace(@"""", string.Empty);
                vehicle.DealershipName = splitFields[2]?.Replace(@"""", string.Empty);
                vehicle.Vehicle = splitFields[3]?.Replace(@"""", string.Empty);
                vehicle.Price = double.Parse(splitFields[4].Replace(@"""", string.Empty));
                vehicle.Date = DateTime.Parse(splitFields[5]);

                vehicleList.Add(vehicle);
            }
            return vehicleList;
        }
    }
}