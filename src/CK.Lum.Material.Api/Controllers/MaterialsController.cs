using CK.Lum.Material.Api.Extensions.Mappers;
using CK.Lum.Material.Api.Transport;
using CK.Lum.Material.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CK.Lum.Material.Api.Controllers
{
    [Route("materials")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService ?? throw new ArgumentNullException(nameof(materialService));
        }

        /// <summary>
        /// Gets a <see cref="Domain.Models.MaterialAggregate.Material"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        /// <returns>The <see cref="MaterialDto"/> with the requested id</returns>
        [HttpGet("{id}")]
        public IActionResult GetMaterialById(string id)
        {
            var decodedId = System.Web.HttpUtility.UrlDecode(id);
            var material = _materialService.GetMaterialById(decodedId);
            return Ok(material);
        }

        /// <summary>
        /// Gets all <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <returns>All <see cref="MaterialDto"/></returns>
        [HttpGet]
        public IActionResult GetMaterials()
        {
            var materials = _materialService.GetMaterials();
            var materialDtos = materials.ToList().Select(m => m.MapToMaterialDto());
            return Ok(materialDtos);
        }

        /// <summary>
        /// Creates a new <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <param name="material">The dto of the material</param>
        /// <returns>The created <see cref="MaterialDto"/></returns>
        [HttpPost]        
        public IActionResult UploadMaterial([FromBody] MaterialDto material)
        {
            var creationResult = _materialService.CreateMaterial(material.Name, material.IsVisible, material.TypeOfPhase, material.MaterialFunction.MinTemperature, material.MaterialFunction.MaxTemperature);

            if(creationResult.errorMessages.Any())
            {
                return UnprocessableEntity(creationResult.errorMessages);
            } else
            {
                var materialDto = creationResult.material.MapToMaterialDto();
                return Ok(materialDto);
            }
        }

        /// <summary>
        /// Updates a new <see cref="Domain.Models.MaterialAggregate.Material"/>
        /// </summary>
        /// <param name="material">The dto of the material</param>
        /// <returns>The updated <see cref="MaterialDto"/></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(string id, [FromBody] MaterialDto material)
        {
            var decodedId = System.Web.HttpUtility.UrlDecode(id);
            var updateResult = _materialService.UpdateMaterial(decodedId, material.Name, material.IsVisible, material.TypeOfPhase, material.MaterialFunction.MinTemperature, material.MaterialFunction.MaxTemperature);
            if (updateResult.errorMessages.Any())
            {
                return UnprocessableEntity(updateResult.errorMessages);
            }
            else
            {
                var materialDto = updateResult.material.MapToMaterialDto();
                return Ok(materialDto);
            }
        }

        /// <summary>
        /// Deletes a <see cref="Domain.Models.MaterialAggregate.Material"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(string id)
        {
            var decodedId = System.Web.HttpUtility.UrlDecode(id);
            _materialService.DeleteMaterial(decodedId);
            return Ok();
        }
    }
}
