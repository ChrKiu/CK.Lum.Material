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
    ///<inheritdoc/>
    public class MaterialRepository : IMaterialRepository
    {
        private readonly RavenDbContext _ravenDbContext;
        private readonly IMapper _mapper;

        ///<inheritdoc/>
        public MaterialRepository(RavenDbContext ravenDbContext, IMapper mapper)
        {
            _ravenDbContext = ravenDbContext ?? throw new ArgumentNullException(nameof(ravenDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        ///<inheritdoc/>
        public MaterialModel Create(MaterialModel material)
        {
            var mappedMaterial = _mapper.Map<MaterialDbo>(material);
            var createdMaterial =_ravenDbContext.CreateMaterial(mappedMaterial);

            return _mapper.Map<MaterialModel>(createdMaterial);
        }

        ///<inheritdoc/>
        public bool Delete(string id)
        {
            return _ravenDbContext.DeleteMaterial(id);
        }

        ///<inheritdoc/>
        public IEnumerable<MaterialModel> GetAll()
        {
            var materialDbos = _ravenDbContext.GetAllMaterials();

            return _mapper.Map<IEnumerable<MaterialModel>>(materialDbos);
        }

        ///<inheritdoc/>
        public IEnumerable<MaterialModel> Get(Expression<Func<MaterialModel, bool>> expression)
        {
            var mappedExpression = _mapper.Map<Expression<Func<MaterialDbo, bool>>>(expression);

            var materialDbos =_ravenDbContext.GetMaterials(mappedExpression);

            return _mapper.Map<IEnumerable<MaterialModel>>(materialDbos);
        }

        ///<inheritdoc/>
        public MaterialModel Update(string id, MaterialModel material)
        {
            var mappedMaterial = _mapper.Map<MaterialDbo>(material);
            var materialDbo = _ravenDbContext.UpdateMaterial(id, mappedMaterial);
            return _mapper.Map<MaterialModel>(materialDbo);
        }
    }
}
