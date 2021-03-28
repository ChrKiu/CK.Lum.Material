using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Data.RavenDb.Models
{
    public abstract class DbEntity
    {
        public string Id { get; set; }
    }
}
