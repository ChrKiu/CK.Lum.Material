using CK.Lum.Material.Api.Transport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CK.Lum.Material.Api.Controllers
{
    [Route("materials")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {

        /// <summary>
        /// Gets a <see cref="Material.Domain.Models.MaterialAggregate"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        /// <returns>The <see cref="MaterialDto"/> with the requested id</returns>
        [HttpGet("{id}")]
        public IActionResult GetMaterialById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all <see cref="Material.Domain.Models.MaterialAggregate"/>
        /// </summary>
        /// <returns>All materials</returns>
        [HttpGet]
        public IActionResult GetMaterials()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new <see cref="Material.Domain.Models.MaterialAggregate"/>
        /// </summary>
        /// <param name="material">The dto of the material</param>
        /// <returns>The created <see cref="MaterialDto"/></returns>
        [HttpPost]        
        public IActionResult UploadMaterial([FromBody] MaterialDto material)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a new <see cref="Material.Domain.Models.MaterialAggregate"/>
        /// </summary>
        /// <param name="material">The dto of the material</param>
        /// <returns>The updated <see cref="MaterialDto"/></returns>
        [HttpPut]
        public IActionResult UpdateMaterial([FromBody] MaterialDto material)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a <see cref="Material.Domain.Models.MaterialAggregate"/> by it's ID
        /// </summary>
        /// <param name="id">The id of the material</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(string id)
        {
            throw new NotImplementedException();
        }
    }
}
