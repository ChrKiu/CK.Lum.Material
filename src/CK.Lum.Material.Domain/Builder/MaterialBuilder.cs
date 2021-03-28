using CK.Lum.Material.Domain.Models;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using CK.Lum.Material.Domain.Validator;
using System;
using System.Collections.Generic;

namespace CK.Lum.Material.Domain.Builder
{
    ///<inheritdoc/>
    public class MaterialBuilder : IMaterialBuilder
    {
        private readonly MaterialValidator _materialValidator;

        public string Name { get; private set; }

        public bool? IsVisible { get; private set; }

        public PhaseType? TypeOfPhase { get; private set; }

        public MaterialFunction? MaterialFunction { get; private set; }

        public MaterialBuilder(MaterialValidator materialValidator)
        {
            _materialValidator = materialValidator ?? throw new ArgumentNullException(nameof(materialValidator));
        }

        ///<inheritdoc/>
        public MaterialBuilderResult BuildMaterial()
        {
            var createdMaterial = Material.Domain.Models.MaterialAggregate.Material.CreateMaterial(Name, IsVisible, TypeOfPhase, MaterialFunction);
            var result = _materialValidator.Validate(createdMaterial);

            var builderResult = new MaterialBuilderResult();
            builderResult.IsValid = result.IsValid;
            
            if (result.IsValid)
            {
                builderResult.Material = createdMaterial;
            }

            var errorMessages = new List<string>();
            foreach (var failure in result.Errors)
            {
                errorMessages.Add(failure.ErrorMessage);
            }

            builderResult.ErrorMessages = errorMessages;

            CleanUp();
            return builderResult;
        }

        ///<inheritdoc/>
        public void SetMaterialFunction(int? maxTemperature, int? minTemperature)
        {
            MaterialFunction = new MaterialFunction(minTemperature, maxTemperature);
        }

        ///<inheritdoc/>
        public void SetVisibility(bool? isVisible)
        {
            IsVisible = isVisible;
        }

        ///<inheritdoc/>
        public void SetMaterialName(string name)
        {
            Name = name;
        }

        ///<inheritdoc/>
        public void SetTypeOfPhase(string typeOfPhase)
        {
            if (Enum.TryParse(typeof(PhaseType), typeOfPhase, true, out object result))
            {
                TypeOfPhase = (PhaseType)result;
            }
        }

        ///<inheritdoc/>
        private void CleanUp()
        {
            Name = string.Empty;
            IsVisible = null;
            TypeOfPhase = null;
            MaterialFunction = null;
        }
    }
}
