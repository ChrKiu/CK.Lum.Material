using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CK.Lum.Material.Domain.Models.MaterialAggregate
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> Get(Expression<Func<Material, bool>> expression);

        IEnumerable<Material> GetAll();

        Material Create(Material material);

        Material Update(Material material);

        bool Delete(string id);
    }
}
