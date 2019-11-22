using System;
using System.Data;
using System.Data.SqlClient;

public class Users_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateUser(User user, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarUsuario", connectivity.Connection());
        string ep = Helper.EncodePassword(string.Concat(user.UserID, user.passwd));

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", user.UserID);
        cmd.Parameters.AddWithValue("@email", user.email);
        cmd.Parameters.AddWithValue("@passwd", ep);
        cmd.Parameters.AddWithValue("@remember_token", "laduchaliduchvsdlivubskdrvfbserkhb");
        cmd.Parameters.AddWithValue("@name", user.name);
        cmd.Parameters.AddWithValue("@lastname", user.lastname);
        cmd.Parameters.AddWithValue("@dateofborn", user.dateofborn);
        cmd.Parameters.AddWithValue("@nationality", user.nationality);
        cmd.Parameters.AddWithValue("@phone", user.phone);
        cmd.Parameters.AddWithValue("@created_at", user.created_at);
        cmd.Parameters.AddWithValue("@updated_at", user.updated_at);
        cmd.Parameters.AddWithValue("@ConditionID", user.ConditionID);
        cmd.Parameters.AddWithValue("@RoleID", user.RoleID);
        cmd.Parameters.AddWithValue("@DriverLicenseID", user.DriverLicenseID);
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteUser(String UserID)
    {
        SqlCommand cmd = new SqlCommand("EliminarUsuario", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", UserID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public User FindUser(String UserID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarUsuario", connectivity.Connection()) {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add("@UserID", SqlDbType.NVarChar);
        cmd.Parameters["@UserID"].Value = UserID;

        connectivity.OpenConnection();
        SqlDataReader dataReaded = cmd.ExecuteReader();
        User user = new User();

        if (dataReaded.HasRows) {
            while (dataReaded.Read()) {
                user.UserID = Convert.ToString(dataReaded["UserID"]);
                user.email = Convert.ToString(dataReaded["email"]);
                user.name = Convert.ToString(dataReaded["name"]);
                user.lastname = Convert.ToString(dataReaded["lastname"]);
                user.dateofborn = Convert.ToDateTime(dataReaded["dateofborn"]);
                user.nationality = Convert.ToString(dataReaded["nationality"]);
                user.phone = Convert.ToString(dataReaded["phone"]);
                user.created_at = Convert.ToDateTime(dataReaded["created_at"]);
                user.updated_at = Convert.ToDateTime(dataReaded["updated_at"]);
                user.ConditionID = Convert.ToInt32(dataReaded["ConditionID"]);
                user.RoleID = Convert.ToInt32(dataReaded["RoleID"]);
                user.DriverLicenseID = Convert.ToInt32(dataReaded["DriverLicenseID"]);
            }
        } else {
            user = null;
        }

        dataReaded.Close();
        cmd.Dispose();
        connectivity.CloseConnection();
        return user;
    }

    public User ValidateUser(String UserID, String password)
    {
        SqlCommand cmd = new SqlCommand();
        string ep = Helper.EncodePassword(string.Concat(UserID, password));

        cmd = new SqlCommand("ValidarUsuario", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@password", ep);

        connectivity.OpenConnection();
        SqlDataReader dataReaded = cmd.ExecuteReader();
        User user = new User();

        if (dataReaded.HasRows) {
            while (dataReaded.Read()) {
                user.UserID = Convert.ToString(dataReaded["UserID"]);
                user.email = Convert.ToString(dataReaded["email"]);
                user.name = Convert.ToString(dataReaded["name"]);
                user.lastname = Convert.ToString(dataReaded["lastname"]);
                user.dateofborn = Convert.ToDateTime(dataReaded["dateofborn"]);
                user.nationality = Convert.ToString(dataReaded["nationality"]);
                user.phone = Convert.ToString(dataReaded["phone"]);
                user.created_at = Convert.ToDateTime(dataReaded["created_at"]);
                user.updated_at = Convert.ToDateTime(dataReaded["updated_at"]);
                user.ConditionID = Convert.ToInt32(dataReaded["ConditionID"]);
                user.RoleID = Convert.ToInt32(dataReaded["RoleID"]);
                user.DriverLicenseID = Convert.ToInt32(dataReaded["DriverLicenseID"]);
            }
        } else {
            user = null;
        }

        dataReaded.Close();
        connectivity.CloseConnection();
        return user;
    }

    public DataTable GetUsers()
    {
        SqlCommand cmd = new SqlCommand("ListarUsuarios", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        connectivity.CloseConnection();
        return dt;
    }

    public DataTable GetUsersDate(DateTime FechaInicio, DateTime FechaFinal)
    {

        SqlCommand cmd = new SqlCommand("QryUsuariosFechaIngreso", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FechaInicio", FechaInicio);
        cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);

        connectivity.OpenConnection();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        connectivity.CloseConnection();
        sda.Dispose();
        return dt;
    }

    public int InsertUserLog(String UserID, int type, string description, DateTime created_at)
    {
        SqlCommand cmd = new SqlCommand("InsertarRegistro", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@created_at", created_at);
        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();
        return i;
    }

    public int UpdatePassword(User user, String passwd)
    {
        string ep = Helper.EncodePassword(string.Concat(user.UserID, passwd));
        SqlCommand cmd = new SqlCommand("ActualizarPasswdUsuario", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserID", user.UserID);
        cmd.Parameters.AddWithValue("@email", user.email);
        cmd.Parameters.AddWithValue("@passwd", ep);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }
}

