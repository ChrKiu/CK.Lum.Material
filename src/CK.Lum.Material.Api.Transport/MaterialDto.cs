using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Api.Transport
{
    public class MaterialDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool? IsVisible { get; set; }

        public string TypeOfPhase { get; set; }

        public MaterialFunctionDto MaterialFunction { get; set; }
    }
}
