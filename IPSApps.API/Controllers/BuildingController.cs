using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPSApps.API.Data;
using IPSApps.API.Entities;
using IPSApps.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace IPSApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private DataContext _context;
        public BuildingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var res = await BuildingService.GetAllBuildings(_context);
            return new ObjectResult(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBuilding(int id)
        {
            var res = await BuildingService.GetBuilding(_context, id);
            return new ObjectResult(res);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpsertBuilding([FromBody]Building building)
        {
            var res = await BuildingService.UpsertBuilding(_context, building);
            return new ObjectResult(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            var res = await BuildingService.DeleteBuilding(_context, id);
            return new ObjectResult(res);
        }
    }
}
