﻿using System;
using Domain.Seedwork.Entities;

namespace Domain.MainBoundedContext.Entities
{
    public class LibraryAccount : AggregateRoot<Guid>
    {
        public LibraryAccount()
            :this("0")
        {}

        public LibraryAccount(string number)
            : this(Guid.NewGuid(), number)
        {
        }
        public LibraryAccount(Guid id, string number)
            : base(id)
        {
            this.Number = number;
        }

        public virtual string Number { get; private set; }
        public virtual string OwnerName { get; set; }
        public virtual bool IsLocked { get; set; }
    }
}
