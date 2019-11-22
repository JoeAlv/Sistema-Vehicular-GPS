using System.Data;

public class LogLocations
{

    public void AddLocation(Location location)
    {
        Locations_CRUD locationobj = new Locations_CRUD();
        locationobj.InsertLocation(location);
    }

    public void UpdateLocation(Location location)
    {
        Locations_CRUD obj = new Locations_CRUD();
        obj.UpdateLocation(location);
    }

    public void DeleteLocation(int LocationID)
    {
        Locations_CRUD obj = new Locations_CRUD();
        obj.DeleteLocation(LocationID);
    }

    public Location FindLocation(int LocationID)
    {
        Locations_CRUD obj = new Locations_CRUD();
        return obj.FindLocation(LocationID);
    }

    public DataTable ListLocations()
    {
        Locations_CRUD obj = new Locations_CRUD();
        return obj.GetLocations();
    }

    public DataTable ListLocationsTravelID(int TravelID)
    {
        Locations_CRUD obj = new Locations_CRUD();
        return obj.GetLocationsTravelID(TravelID);
    }
}

