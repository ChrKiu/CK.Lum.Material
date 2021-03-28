using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    public class Material
    {
        public string Name { get; private set; }

        public bool? IsVisible { get; private set; }

        public PhaseType TypeOfPhase { get; private set; }

        public MaterialFunction MaterialFunction { get; private set; }
    }
}
