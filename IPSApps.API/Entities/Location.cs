using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSApps.API.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public virtual Floor Floor { get; set; }
        public string Name { get; set; }
        public virtual LocationType LocationTypes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
