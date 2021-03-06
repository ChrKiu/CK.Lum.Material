using CK.Lum.Material.Application.Interfaces;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using MaterialModel = CK.Lum.Material.Domain.Models.MaterialAggregate.Material;

namespace CK.Lum.Material.Application.Services
{
    ///<inheritdoc/>
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialBuilder _materialBuilder;

        public MaterialService(IMaterialRepository materialRepository, IMaterialBuilder materialBuilder)
        {
            _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
            _materialBuilder = materialBuilder ?? throw new ArgumentNullException(nameof(materialBuilder)); ;
        }

        ///<inheritdoc/>
        (MaterialModel material, IEnumerable<string> errorMessages) IMaterialService.CreateMaterial(string name, bool? isVisibile, string typeOfPhase, int? minTemperature, int? maxTemperature)
        {
            _materialBuilder.SetMaterialName(name);
            _materialBuilder.SetVisibility(isVisibile);
            _materialBuilder.SetTypeOfPhase(typeOfPhase);
            _materialBuilder.SetMaterialFunction(maxTemperature, minTemperature);
            var builderResult = _materialBuilder.BuildMaterial();

            if(builderResult.IsValid)
            {
                return (_materialRepository.Create(builderResult.Material), new List<string>());
            }

            return (builderResult.Material, builderResult.ErrorMessages);
        }

        ///<inheritdoc/>
        bool IMaterialService.DeleteMaterial(string id)
        {
            return _materialRepository.Delete(id);
        }

        ///<inheritdoc/>
        MaterialModel IMaterialService.GetMaterialById(string id)
        {
            var material = _materialRepository.Get(m => m.Id == id).FirstOrDefault();
            return material;
        }

        ///<inheritdoc/>
        IEnumerable<MaterialModel> IMaterialService.GetMaterials()
        {
            var materials = _materialRepository.GetAll();
            return materials;
        }

        ///<inheritdoc/>
        (MaterialModel material, IEnumerable<string> errorMessages) IMaterialService.UpdateMaterial(string id, string name, bool? isVisibile, string? typeOfPhase, int? minTemperature, int? maxTemperature)
        {
            _materialBuilder.SetMaterialName(name);
            _materialBuilder.SetVisibility(isVisibile);
            _materialBuilder.SetTypeOfPhase(typeOfPhase);
            _materialBuilder.SetMaterialFunction(maxTemperature, minTemperature);
            var builderResult = _materialBuilder.BuildMaterial();

            if (builderResult.IsValid)
            {
                return (_materialRepository.Update(id, builderResult.Material), new List<string>());
            }

            return (builderResult.Material, builderResult.ErrorMessages);
        }

    }
}
