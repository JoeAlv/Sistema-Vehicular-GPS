using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Driverlicenses_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateDriverLicense(Driverlicense license, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarCondicion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DriverlicenseID", license.DriverlicenseID);
        cmd.Parameters.AddWithValue("@description", license.description);
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteDriverlicense(string DriverlicenseID)
    {
        SqlCommand cmd = new SqlCommand("EliminarLicenciaConducir", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DriverlicenseID", DriverlicenseID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Driverlicense FindDriverlicense(string DriverlicenseID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarLicenciaConducir", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@DriverlicenseID", SqlDbType.NVarChar);
        cmd.Parameters["@DriverlicenseID"].Value = DriverlicenseID;

        connectivity.OpenConnection();
        SqlDataReader result = cmd.ExecuteReader();
        Driverlicense licence = new Driverlicense();

        if (result.HasRows) {
            while (result.Read())
            {
                licence.DriverlicenseID = Convert.ToString(result["DriverlicenseID"]);
                licence.description = Convert.ToString(result["description"]);
            }
        } else {
            licence = null;
        }

        result.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return licence;
    }

    public List<Driverlicense> GetDriverlicenses()
    {
        List<Driverlicense> driverlicenses = new List<Driverlicense>();

        SqlCommand cmd = new SqlCommand("ListarCondiciones", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        connectivity.OpenConnection();
        SqlDataAdapter sqldata = new SqlDataAdapter(cmd);
        DataTable data = new DataTable();
        sqldata.Fill(data);

        foreach (DataRow result in data.Rows)
        {
            Driverlicense licence = new Driverlicense();
            licence.DriverlicenseID = Convert.ToString(result["DriverlicenseID"]);
            licence.description = Convert.ToString(result["description"]);
            driverlicenses.Add(licence);
        }
        sqldata.Dispose();
        data.Dispose();
        cmd.Dispose();
        connectivity.CloseConnection();
        return driverlicenses;
    }
}
