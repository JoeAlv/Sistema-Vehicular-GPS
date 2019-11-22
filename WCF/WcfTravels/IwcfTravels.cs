using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTravels
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfTravels" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfTravels
    {
        [OperationContract]
        void AddTravel(Travel travel);

        [OperationContract]
        void UpdateTravel(Travel travel);

        [OperationContract]
        void DeleteTravel(int TravelID);

        [OperationContract]
        Travel FindTravel(int TravelID);

        [OperationContract]
        DataTable ListTravels();


        [OperationContract]
        DataTable ListTravelsDate(DateTime FechaInicio, DateTime FechaFinal);
    }
}
