using CK.Lum.Material.Domain.Models;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using System;

namespace CK.Lum.Material.Domain.Builder
{
    public class MaterialBuilder : IMaterialBuilder
    {
        public string Name { get; private set; }

        public bool? IsVisible { get; private set; }

        public PhaseType? TypeOfPhase { get; private set; }

        public MaterialFunction? MaterialFunction { get; private set; }

        public Models.MaterialAggregate.Material BuildMaterial()
        {
            var createdMaterial = Material.Domain.Models.MaterialAggregate.Material.CreateMaterial(Name, IsVisible, TypeOfPhase, MaterialFunction);
            CleanUp();

            return createdMaterial;
        }

        public void SetMaterialFunction(int? maxTemperature, int? minTemperature)
        {
            MaterialFunction = new MaterialFunction(minTemperature, maxTemperature);
        }

        public void SetVisibility(bool? isVisible)
        {
            IsVisible = isVisible;
        }

        public void SetMaterialName(string name)
        {
            Name = name;
        }

        public void SetTypeOfPhase(string typeOfPhase)
        {
            if (Enum.TryParse(typeof(PhaseType), typeOfPhase, true, out object result))
            {
                TypeOfPhase = (PhaseType)result;
            }
        }

        private void CleanUp()
        {
            Name = string.Empty;
            IsVisible = null;
            TypeOfPhase = null;
            MaterialFunction = null;
        }
    }
}
