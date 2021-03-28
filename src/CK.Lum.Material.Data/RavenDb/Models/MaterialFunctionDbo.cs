using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Data.RavenDb.Models
{
    /// <summary>
    /// Data base object, which is written and fetched into/from the Database
    /// </summary>
    public class MaterialFunctionDbo
    {
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
    }
}
