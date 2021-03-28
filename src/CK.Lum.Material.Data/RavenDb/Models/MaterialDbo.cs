using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Data.RavenDb.Models
{
    public class MaterialDbo : DbEntity
    {
        public string Name { get; set; }
        public bool? IsVisible { get; set; }

        public string TypeOfPhase { get; set; }

        public MaterialFunctionDbo MaterialFunction { get; set; }
    }
}
