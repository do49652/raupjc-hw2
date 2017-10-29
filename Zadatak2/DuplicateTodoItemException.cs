using System;

namespace Zadatak2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(string message) : base(message)
        {
        }
    }
}