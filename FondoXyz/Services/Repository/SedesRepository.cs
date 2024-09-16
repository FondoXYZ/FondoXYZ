    using FondosXYZ.Models;
    using FondoXyz.Data;
    using Microsoft.EntityFrameworkCore;

    namespace FondosXYZ.Services{
        public class SedesRepository : ISedesRepository
        {
            private readonly dbContext _context;
            public SedesRepository(dbContext context)
            {
                _context = context;
            }
            public async Task AddSedeAsync(Sede sede)
            {
                _context.Sedes.Add(sede);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteSedeAsync(int id)
            {
                var sede = await _context.Sedes.FindAsync(id);
                if(sede != null)
                {
                    _context.Sedes.Remove(sede);
                    await _context.SaveChangesAsync();
                }
            }

            public async Task<IEnumerable<Sede>> GetAllSedes()
            {
                 try
                    {
                        return await _context.Sedes.ToListAsync();
                    }
                    catch (Exception ex)
                    {
                        // Agrega logging para ayudar en la depuración
                        Console.WriteLine($"Error al obtener sedes: {ex.Message}");
                        throw;
                    }
            }

            public async Task<Sede> GetSedeById(int id)
            {
                return await _context.Sedes.FindAsync(id);
            }

            public async Task UpdateSedeAsync(Sede sede)
            {
                _context.Sedes.Update(sede);
                await _context.SaveChangesAsync();
            }
        }
    }