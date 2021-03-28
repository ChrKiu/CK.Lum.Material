using AutoMapper;
using CK.Lum.Material.Data.RavenDb;
using CK.Lum.Material.Data.RavenDb.Models;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using MaterialModel = CK.Lum.Material.Domain.Models.MaterialAggregate.Material;

namespace CK.Lum.Material.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly RavenDbContext _ravenDbContext;
        private readonly IMapper _mapper;

        public MaterialRepository(RavenDbContext ravenDbContext, IMapper mapper)
        {
            _ravenDbContext = ravenDbContext ?? throw new ArgumentNullException(nameof(ravenDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public MaterialModel Create(MaterialModel material)
        {
            var mappedMaterial = _mapper.Map<MaterialDbo>(material);
            var createdMaterial =_ravenDbContext.CreateMaterial(mappedMaterial);

            return _mapper.Map<MaterialModel>(createdMaterial);
        }

        public bool Delete(string id)
        {
            return _ravenDbContext.DeleteMaterial(id);
        }

        public IEnumerable<MaterialModel> GetAll()
        {
            var materialDbos = _ravenDbContext.GetAllMaterials();

            return _mapper.Map<IEnumerable<MaterialModel>>(materialDbos);
        }

        public IEnumerable<MaterialModel> Get(Expression<Func<MaterialModel, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<MaterialDbo, bool>>>(expression);

            var materialDbos =_ravenDbContext.GetMaterials(mappedExpression);

            return _mapper.Map<IEnumerable<MaterialModel>>(materialDbos);
        }

        public MaterialModel Update(MaterialModel material)
        {
            throw new NotImplementedException();
        }
    }
}
