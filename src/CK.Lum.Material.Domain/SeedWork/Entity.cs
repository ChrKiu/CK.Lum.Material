using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Lum.Material.Domain.SeedWork
{
    public abstract class Entity
    {
        public virtual string Id { get; set; }

        private int? _requestedHashCode;

        public bool IsTransient()
        {
            return this.Id == default;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this._requestedHashCode.HasValue)
                {
                    this._requestedHashCode =
                        this.Id.GetHashCode()
                        ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                }

                return this._requestedHashCode.Value;
            }

            return base.GetHashCode();
        }
    }
}
