using System;
using System.Collections.Generic;
using System.Data;

public class LogVehicles
{
    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles_CRUD vehicleobj = new Vehicles_CRUD();
        vehicleobj.InsertUpdateVehicle(vehicle, 1);
    }

    public void UpdateVehicle(Vehicle vehicle)
    {
        Vehicles_CRUD obj = new Vehicles_CRUD();
        obj.InsertUpdateVehicle(vehicle, 2);
    }

    public int DeleteVehicle(string VehicleID)
    {
        Vehicles_CRUD obj = new Vehicles_CRUD();
        return obj.DeleteVehicle(VehicleID);
    }

    public Vehicle FindVehicles(string VehicleID)
    {
        Vehicles_CRUD obj = new Vehicles_CRUD();
        return obj.FindVehicle(VehicleID);
    }

    public DataTable ListVehicles()
    {
        Vehicles_CRUD obj = new Vehicles_CRUD();
        return obj.GetVehicles();
    }

    public DataTable ListVehicleDate(DateTime FechaInicio, DateTime FechaFinal)
    {
        Vehicles_CRUD obj = new Vehicles_CRUD();
        return obj.GetVehiclesDate(FechaInicio, FechaFinal);
    }

}

