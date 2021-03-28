using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    /// <summary>
    /// Repository for <see cref="Material"/>
    /// </summary>
    public interface IMaterialRepository
    {
        /// <summary>
        /// Gets a list of <see cref="Material"/> depending on the conditions in the expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<Material> Get(Expression<Func<Material, bool>> expression);

        /// <summary>
        /// Gets all <see cref="Material"/>
        /// </summary>
        /// <returns></returns>
        IEnumerable<Material> GetAll();

        /// <summary>
        /// Creates a <see cref="Material"/>
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        Material Create(Material material);

        /// <summary>
        /// Updates a <see cref="Material"/>
        /// </summary>
        /// <param name="material">Every value gets changed to the value in the parameter</param>
        /// <returns></returns>
        Material Update(string id, Material material);

        /// <summary>
        /// Deletes a <see cref="Material"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(string id);
    }
}
