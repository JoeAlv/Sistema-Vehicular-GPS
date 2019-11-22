using System;
using System.Data;

public class LogUsers
{
    public void AddUser(User user)
    {
        Users_CRUD userobj = new Users_CRUD();
        userobj.InsertUpdateUser(user, 1);
    }

    public void UpdateUser(User user)
    {
        Users_CRUD obj = new Users_CRUD();
        obj.InsertUpdateUser(user, 2);
    }

    public void DeleteUser(string UserID)
    {
        Users_CRUD obj = new Users_CRUD();
        obj.DeleteUser(UserID);
    }

    public User FindUsers(string UserID)
    {
        Users_CRUD obj = new Users_CRUD();
        return obj.FindUser(UserID);
    }

    public User ValidateUser(string UserID, string password)
    {
        Users_CRUD obj = new Users_CRUD();
        return obj.ValidateUser(UserID,password);
    }

    public DataTable ListUser()
    {
        Users_CRUD obj = new Users_CRUD();
        return obj.GetUsers();
    }

    public DataTable ListUserDate(DateTime FechaInicio, DateTime FechaFinal)
    {
        Users_CRUD obj = new Users_CRUD();
        return obj.GetUsersDate(FechaInicio, FechaFinal);
    }

    public void InsertUserLog(String UserID, int type, string description, DateTime created_at)
    {
        Users_CRUD obj = new Users_CRUD();
        obj.InsertUserLog(UserID,type,description,created_at);
    }

    public void UpdatePassword(User user, String passwd)
    {
        Users_CRUD obj = new Users_CRUD();
        obj.UpdatePassword(user, passwd);
    }
}
