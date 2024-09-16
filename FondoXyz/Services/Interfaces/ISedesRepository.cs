using FondosXYZ.Models;

namespace FondosXYZ.Services{
    public interface ISedesRepository {
        Task<IEnumerable<Sede>> GetAllSedes(); // Listamos todas las sedes
        Task<Sede> GetSedeById(int id); //Listamos  por id 
        Task AddSedeAsync(Sede sede);//Creamos nueva sede
        Task UpdateSedeAsync(Sede sede); //Actualizamos sede
        Task DeleteSedeAsync(int id);  //Eliminamos sede
    }
}