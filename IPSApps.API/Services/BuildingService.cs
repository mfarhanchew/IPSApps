using IPSApps.API.Data;
using IPSApps.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPSApps.API.Services
{
    public static class BuildingService
    {

        public static async Task<List<Building>> GetAllBuildings(DataContext db)
        {
            var buildings = await db.Buildings.Where(x => !x.IsDeleted).Include(x => x.Floors).ThenInclude(y => y.Locations).ThenInclude(z => z.LocationTypes).ToListAsync();
            return buildings;
        }

        public static async Task<Building> GetBuilding(DataContext db, int id)
        {
            var building = await db.Buildings.Where(x => x.Id == id).Include(x => x.Floors).ThenInclude(y => y.Locations).ThenInclude(z => z.LocationTypes).FirstOrDefaultAsync();
            return building;
        }

        public static async Task<Building> UpsertBuilding(DataContext db, Building building)
        {
            var b = await db.Buildings.Where(x => x.Id == building.Id).FirstOrDefaultAsync();
            if(b == null)
            {
                await db.Buildings.AddAsync(building);
                await db.SaveChangesAsync();
                b = building;
            }
            else
            {
                b.Name = building.Name;
                db.Buildings.Update(b);
                await db.SaveChangesAsync();
            }
            return b;
        }

        public static async Task<bool> DeleteBuilding(DataContext db, int id)
        {
            try
            {
                var b = await db.Buildings.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (b != null)
                {
                    b.IsDeleted = true;
                    db.Buildings.Update(b);
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
