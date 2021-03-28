using CK.Lum.Material.Data.RavenDb.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CK.Lum.Material.Data.RavenDb
{
    /// <summary>
    /// Database context, used to connect and manipulate the database
    /// </summary>
    public class RavenDbContext
    {
        private readonly IRavenDbConfiguration _ravenDbConfiguration;

        private IDocumentStore _store;

        public RavenDbContext(IRavenDbConfiguration ravenDbConfiguration)
        {
            _ravenDbConfiguration = ravenDbConfiguration ?? throw new ArgumentNullException(nameof(ravenDbConfiguration));

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                var dbClusters = _ravenDbConfiguration.RavenDbClusters.Select(ri => ri.Url);

                var store = new DocumentStore
                {
                    Urls = dbClusters.ToArray(),
                    Database = _ravenDbConfiguration.RavenDbName,
                    Conventions = { }
                };
                _store = store.Initialize();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public MaterialDbo UpdateMaterial(string id, MaterialDbo material)
        {
            try
            {
                using (var session = _store.OpenSession())
                {
                    var dbMaterial = session.Load<MaterialDbo>(id);

                    dbMaterial.IsVisible = material.IsVisible;
                    dbMaterial.MaterialFunction = material.MaterialFunction;
                    dbMaterial.Name = material.Name;
                    dbMaterial.TypeOfPhase = material.TypeOfPhase;

                    session.SaveChanges();

                    return dbMaterial;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool DeleteMaterial(string id)
        {
            try
            {
                using (IDocumentSession session = _store.OpenSession())
                {
                    var material = session.Load<MaterialDbo>(id);

                    session.Delete(material);

                    session.SaveChanges();

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MaterialDbo CreateMaterial(MaterialDbo material)
        {
            try
            {
                using (IDocumentSession session = _store.OpenSession())
                {
                    session.Store(material);

                    session.SaveChanges();
                }

                return material;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MaterialDbo> GetAllMaterials()
        {
            try
            {
                using (IDocumentSession session = _store.OpenSession())
                {
                    List<MaterialDbo> materials = session
                        .Query<MaterialDbo>()
                        .Select(m => m)
                        .ToList();

                    return materials;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MaterialDbo> GetMaterials(Expression<Func<MaterialDbo, bool>> expression)
        {
            try
            {
                using (IDocumentSession session = _store.OpenSession())
                {
                    List<MaterialDbo> materials = session
                        .Query<MaterialDbo>()
                        .Where(expression)
                        .Select(m => m)
                        .ToList();

                    return materials;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
