using CK.Lum.Material.Application.Interfaces;
using System;
using System.Collections.Generic;
using MaterialModel = CK.Lum.Material.Domain.Models.MaterialAggregate.Material;

namespace CK.Lum.Material.Application.Services
{
    ///<inheritdoc/>
    public class MaterialService : IMaterialService
    {
        ///<inheritdoc/>
        MaterialModel IMaterialService.CreateMaterial(string name, bool? isVisibile, string typeOfPhase, int? minTemperature, int? maxTemperature)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        bool IMaterialService.DeleteMaterial(string id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        MaterialModel IMaterialService.GetMaterialById(string id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        IEnumerable<MaterialModel> IMaterialService.GetMaterials()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        MaterialModel IMaterialService.UpdateMaterial(string id, string name, bool? isVisibile, string typeOfPhase, int? minTemperature, int? maxTemperature)
        {
            throw new NotImplementedException();
        }
    }
}
