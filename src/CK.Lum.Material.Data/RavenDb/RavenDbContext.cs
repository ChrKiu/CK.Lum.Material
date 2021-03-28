﻿using CK.Lum.Material.Data.RavenDb.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Data.RavenDb
{
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
            var dbClusters = _ravenDbConfiguration.RavenDbClusters.Select(ri => ri.Url);

            var store = new DocumentStore
            {
                Urls = dbClusters.ToArray(),
                Database = _ravenDbConfiguration.RavenDbName,
                Conventions = { }
            };
            _store = store.Initialize();
        }

        //public MaterialDbo UpdateMaterial()
        //{

        //}

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
            using (IDocumentSession session = _store.OpenSession())
            {
                session.Store(material);                            

                session.SaveChanges();

            }

            return material;
        }

        public IEnumerable<MaterialDbo> GetAllMaterials()
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

        public IEnumerable<MaterialDbo> GetMaterials(Expression<Func<MaterialDbo, bool>> expression)
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
    }
}