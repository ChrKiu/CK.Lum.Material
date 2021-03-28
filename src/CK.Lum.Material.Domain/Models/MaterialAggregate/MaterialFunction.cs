using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    public class MaterialFunction
    {
        public int MinTemperature { get; private set; }

        public int MaxTemperature { get; private set; }
    }
}
