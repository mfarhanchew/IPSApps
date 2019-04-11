using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSApps.API.Entities
{
    public class Floor
    {
        [Key]
        public int Id { get; set; }
        public virtual Building Building { get; set; }
        public int? BuildingId { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
