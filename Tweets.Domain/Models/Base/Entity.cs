using System;
using System.Collections.Generic;

namespace Tweets.Domain.Models.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return obj is Entity identity && Id.Equals(identity.Id);
        }

        public override int GetHashCode()
        {
            return 2008858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
