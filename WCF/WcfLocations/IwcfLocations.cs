using System;
using System.Data;
using System.ServiceModel;

namespace WcfLocations
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IwcfLocations" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IwcfLocations
    {
        [OperationContract]
        void AddLocation(Location location);

        [OperationContract]
        void UpdateLocation(Location location);

        [OperationContract]
        void DeleteLocation(int LocationID);

        [OperationContract]
        Location FindLocation(int LocationID);

        [OperationContract]
        DataTable ListLocations();

        [OperationContract]
        DataTable ListLocationsTravelID(int TravelID);

    }
}
