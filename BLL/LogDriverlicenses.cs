using System.Collections.Generic;

public class LogDriverlicenses
{
    public Driverlicense FindDriverlicense(string DriverLicenseIID)
    {
        Driverlicenses_CRUD obj = new Driverlicenses_CRUD();
        return obj.FindDriverlicense(DriverLicenseIID);
    }

    public List<Driverlicense> ListDriverlicenses()
    {
        Driverlicenses_CRUD obj = new Driverlicenses_CRUD();
        return obj.GetDriverlicenses();
    }
}

