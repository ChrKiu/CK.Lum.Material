using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.Builder
{
    /// <summary>
    /// Resultobject of <see cref="MaterialBuilder"/>
    /// </summary>
    public class MaterialBuilderResult
    {
        public Models.MaterialAggregate.Material? Material { get; set; }
        public bool IsValid { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
