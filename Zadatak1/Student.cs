using System.Collections.Generic;

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
        public Gender Gender { get; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Name == student.Name &&
                   Jmbag == student.Jmbag &&
                   Gender == student.Gender;
        }

        public override int GetHashCode()
        {
            var hashCode = 430495180;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Jmbag);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1 != null && s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return s1 != null && !s1.Equals(s2);
        }
    }
}