using System;
using Domain.Seedwork.Entities;

namespace Domain.MainBoundedContext.Entities
{
    public class BookOutInfo : AggregateRoot<Guid>
    {
        public BookOutInfo(Book book, int count, DateTime outTime)
            : this(Guid.NewGuid(), book, count, outTime)
        {

        }

        public BookOutInfo(Guid id, Book book, int count, DateTime outTime)
            : base(id)
        {
            this.Book = book;
            this.Count = count;
            this.OutTime = outTime;
        }

        protected  BookOutInfo():base(Guid.NewGuid())
        {
            
        }

        public virtual Book Book { get; private set; }
        public virtual int Count { get; private set; }
        public virtual DateTime? OutTime { get; set; }
    }
}
