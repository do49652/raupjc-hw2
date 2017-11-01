using System;

namespace Zadatak1
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Student
    {
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Jmbag == student.Jmbag;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1 != null && s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            try
            {
                return !s1.Equals(s2);
            }
            catch (NullReferenceException e)
            {
                return false;
            }
        }
    }
}