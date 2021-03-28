using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Lum.Material.Domain;

using MaterialModel = CK.Lum.Material.Domain.Models.MaterialAggregate.Material;

namespace CK.Lum.Material.Application.Interfaces
{
    /// <summary>
    /// Services which contains all functions regarding the <see cref="Domain.Models.MaterialAggregate.Material"/>
    /// </summary>
    public interface IMaterialService
    {
        /// <summary>
        /// Gets a <see cref="Domain.Models.MaterialAggregate.Material"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        /// <returns>The <see cref="Domain.Models.MaterialAggregate.Material"/> with the requested id</returns>
        public MaterialModel GetMaterialById(string id);

        /// <summary>
        /// Gets all <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <returns>All <see cref="Domain.Models.MaterialAggregate.Material"/></returns>
        public IEnumerable<MaterialModel> GetMaterials();

        /// <summary>
        /// Creates a new <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <param name="name">The name of the material</param>
        /// <param name="isVisibile">The visibility of the material</param>
        /// <param name="typeOfPhase">The type of the phase of the material</param>
        /// <param name="minTemperature">The min temperature of the material</param>
        /// <param name="maxTemperature">The max temperature of the material</param>
        /// <returns>The created <see cref="Domain.Models.MaterialAggregate.Material"/></returns>
        public MaterialModel CreateMaterial(string name, bool? isVisibile, string? typeOfPhase, int? minTemperature, int? maxTemperature);

        /// <summary>
        /// Updates a new <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <param name="id">The id of the material</param>
        /// <param name="name">The name of the material</param>
        /// <param name="isVisibile">The visibility of the material</param>
        /// <param name="typeOfPhase">The type of the phase of the material</param>
        /// <param name="minTemperature">The min temperature of the material</param>
        /// <param name="maxTemperature">The max temperature of the material</param>
        /// <returns>The updated <see cref="Domain.Models.MaterialAggregate.Material"/></returns>
        public MaterialModel UpdateMaterial(string id, string? name, bool? isVisibile, string? typeOfPhase, int? minTemperature, int? maxTemperature);

        /// <summary>
        /// Deletes a <see cref="Domain.Models.MaterialAggregate.Material"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        public bool DeleteMaterial(string id);
    }
}
