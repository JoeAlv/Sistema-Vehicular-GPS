using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace WcfVehicles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfVehicles" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfVehicles
    {
        [OperationContract]
        void AddVehicle(Vehicle vehicle);

        [OperationContract]
        void UpdateVehicle(Vehicle vehicle);

        [OperationContract]
        int DeleteVehicle(string VehicleID);

        [OperationContract]
        Vehicle FindVehicle(string VehicleID);

        [OperationContract]
        DataTable ListVehicles();

        [OperationContract]
        DataTable ListVehicleDate(DateTime FechaInicio, DateTime FechaFinal);
    }
}
