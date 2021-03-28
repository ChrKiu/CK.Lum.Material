using CK.Lum.Material.Api.Transport;

namespace CK.Lum.Material.Api.Extensions.Mappers
{
    public static class MaterialDtoMapper
    {
        public static MaterialDto MapToMaterialDto(this Domain.Models.MaterialAggregate.Material material)
        {
            return new MaterialDto
            {
                Id = material.Id,
                Name = material.Name,
                IsVisible = material.IsVisible,
                TypeOfPhase = material.TypeOfPhase.ToString(),
                MaterialFunction = new MaterialFunctionDto
                {
                    MaxTemperature = material.MaterialFunction.MaxTemperature,
                    MinTemperature = material.MaterialFunction.MinTemperature
                }

            };
        }
    }
}
