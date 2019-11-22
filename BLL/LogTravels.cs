using System;
using System.Collections.Generic;
using System.Data;

public class LogTravels
{
    public void AddTravel(Travel travel)
    {
        Travels_CRUD travelobj = new Travels_CRUD();
        travelobj.InsertUpdateTravel(travel, 1);
    }

    public void UpdateTravel(Travel travel)
    {
        Travels_CRUD obj = new Travels_CRUD();
        obj.InsertUpdateTravel(travel, 2);
    }

    public void DeleteTravel(int TravelID)
    {
        Travels_CRUD obj = new Travels_CRUD();
        obj.DeleteTravel(TravelID);
    }

    public Travel FindTravel(int TravelID)
    {
        Travels_CRUD obj = new Travels_CRUD();
        return obj.FindTravel(TravelID);
    }

    public DataTable ListTravels()
    {
        Travels_CRUD obj = new Travels_CRUD();
        return obj.GetTravels();
    }

    public DataTable ListTravelsDate(DateTime FechaInicio, DateTime FechaFinal)
    {
        Travels_CRUD obj = new Travels_CRUD();
        return obj.GetTravelsDate(FechaInicio, FechaFinal);
    }
}

