using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace WcfUsers
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfUsers" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfUsers
    {
        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        void DeleteUser(string UserID);

        [OperationContract]
        User FindUser(string UserID);

        [OperationContract]
        User ValidateUser(string UserID, string password);

        [OperationContract]
        DataTable ListUser();

        [OperationContract]
        DataTable ListUserDate(DateTime FechaInicio, DateTime FechaFinal);

        [OperationContract]
        void InsertUserLog(string UserID, int type, string description, DateTime created_at);

        [OperationContract]
        void UpdatePassword(User user, String passwd);

    }
}
