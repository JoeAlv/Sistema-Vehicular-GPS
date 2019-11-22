using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Conditions_CRUD
{
    Connectivity connectivity = new Connectivity();

    public int InsertUpdateCondition(Condition condition, int modo)
    {
        SqlCommand cmd = new SqlCommand("InsertarActualizarCondicion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ConditionID", condition.ConditionID);
        cmd.Parameters.AddWithValue("@title", condition.title);
        // 1= Add 2= Update
        cmd.Parameters.AddWithValue("@Mode", modo);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public int DeleteCondition(int ConditionID)
    {
        SqlCommand cmd = new SqlCommand("EliminarCondicion", connectivity.Connection());

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ConditionID", ConditionID);

        connectivity.OpenConnection();
        int i = cmd.ExecuteNonQuery();
        cmd.Dispose();
        connectivity.CloseConnection();

        return i;
    }

    public Condition FindCondition(int ConditionID)
    {
        SqlCommand cmd = new SqlCommand();

        cmd = new SqlCommand("ConsultarCondicion", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ConditionID", SqlDbType.NVarChar);
        cmd.Parameters["@ConditionID"].Value = ConditionID;

        connectivity.OpenConnection();
        SqlDataReader result = cmd.ExecuteReader();
        Condition condition = new Condition();

        if (result.HasRows) {
            while (result.Read()) {
                condition.ConditionID = Convert.ToInt32(result["ConditionID"]);
                condition.title = Convert.ToString(result["title"]);
            }
        } else {
            condition = null;
        }

        result.Close();
        connectivity.CloseConnection();
        return condition;
    }

    public List<Condition> GetConditions()
    {
        List<Condition> conditions = new List<Condition>();

        SqlCommand cmd = new SqlCommand("ListarCondiciones", connectivity.Connection());
        cmd.CommandType = CommandType.StoredProcedure;

        connectivity.OpenConnection();
        SqlDataAdapter sqldata = new SqlDataAdapter(cmd);
        DataTable data = new DataTable();
        sqldata.Fill(data);

        foreach (DataRow result in data.Rows)
        {
            Condition condition = new Condition();
            condition.ConditionID = Convert.ToInt32(result["ConditionID"]);
            condition.title = Convert.ToString(result["title"]);
            conditions.Add(condition);
        }
        connectivity.CloseConnection();
        return conditions;
    }
}

