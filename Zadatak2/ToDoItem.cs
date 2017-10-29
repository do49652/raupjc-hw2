using System;
using System.Collections.Generic;

namespace Zadatak2
{
    public class TodoItem
    {
        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public Guid Id { get; set; }
        public string Text { get; set; }

        public bool IsCompleted => DateCompleted.HasValue;

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public bool MarkAsCompleted()
        {
            if (IsCompleted) return false;
            DateCompleted = DateTime.Now;
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is TodoItem item &&
                   Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}