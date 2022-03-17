using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Framework.Domain
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;private set; }
    }
}
