using CK.Lum.Material.Domain.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    public interface IMaterialBuilder
    {
        string Name { get; }

        bool? IsVisible { get; }

        PhaseType? TypeOfPhase { get; }

        MaterialFunction? MaterialFunction { get; }

        void SetMaterialName(string name);

        void SetTypeOfPhase(string typeOfPhase);

        void SetMaterialFunction(int? maxTemperature, int? minTemperature);

        void SetVisibility(bool? isVisible);

        MaterialBuilderResult BuildMaterial();
    }
}
