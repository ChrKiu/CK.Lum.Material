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
        public bool? IsVisible { get; private set; }

        public string TypeOfPhase { get; private set; }

        public MaterialFunctionDbo MaterialFunction { get; private set; }
    }
}
