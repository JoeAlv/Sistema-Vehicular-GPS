using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Roles_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateRole(Role role, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarRol", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoleID", role.RoleID);
        cmd.Parameters.AddWithValue("@title", role.title);
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteRole(int RoleID)
    {
        SqlCommand cmd = new SqlCommand("EliminarRol", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoleID", RoleID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Role FindRole(int RoleID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarRol", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RoleID", SqlDbType.NVarChar);
        cmd.Parameters["@RoleID"].Value = RoleID;

        connectivity.OpenConnection();
        SqlDataReader r = cmd.ExecuteReader();
        Role role = new Role();

        if (r.HasRows) {
            while (r.Read()) {
                role.RoleID = Convert.ToInt32(r["RoleID"]);
                role.title = Convert.ToString(r["title"]);
            }
        } else {
            role = null;
        }

        r.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return role;
    }

    public List<Role> GetRoles()
    {
        List<Role> roles = new List<Role>();
        SqlCommand cmd = new SqlCommand("ListarRoles", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        foreach (DataRow r in dt.Rows)
        {
            Role role = new Role();
            role.RoleID = Convert.ToInt32(r["RoleID"]);
            role.title = Convert.ToString(r["title"]);
            roles.Add(role);
        }

        dt.Dispose();
        sda.Dispose();
        cmd.Dispose();
        connectivity.CloseConnection();
        return roles;
    }
}

