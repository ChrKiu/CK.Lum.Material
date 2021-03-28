using CK.Lum.Material.Domain.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    /// <summary>
    /// Builder for a <see cref="Material"/>
    /// </summary>
    public interface IMaterialBuilder
    {
        string Name { get; }

        bool? IsVisible { get; }

        PhaseType? TypeOfPhase { get; }

        MaterialFunction? MaterialFunction { get; }

        /// <summary>
        /// Sets the name of the <see cref="Material"/>
        /// </summary>
        /// <param name="name"></param>
        void SetMaterialName(string name);

        /// <summary>
        /// Sets the phase type of the <see cref="Material"/>
        /// </summary>
        /// <param name="typeOfPhase"></param>
        void SetTypeOfPhase(string typeOfPhase);

        /// <summary>
        /// Sets the temperatures of the <see cref="Material"/>
        /// </summary>
        /// <param name="maxTemperature"></param>
        /// <param name="minTemperature"></param>
        void SetMaterialFunction(int? maxTemperature, int? minTemperature);

        /// <summary>
        /// Sets the visibility of the <see cref="Material"/>
        /// </summary>
        /// <param name="isVisible"></param>
        void SetVisibility(bool? isVisible);

        /// <summary>
        /// Builds the <see cref="Material"/>
        /// </summary>
        /// <returns>Resultobject, containing if the building is valid with the current paramters and error messages if not. When valid returns a build <see cref="Material"/></returns>
        MaterialBuilderResult BuildMaterial();
    }
}
