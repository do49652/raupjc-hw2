using System.Linq;
using Zadatak1;

namespace Zadatak4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i).OrderBy(i => i.Key)
                .Select(i => $"Broj {i.Key} ponavlja se {i.Count()} puta").ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray
                .Where(uni => uni.Students.All(s => s.Gender != Gender.Female)).ToArray();
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray
                .Where(uni => uni.Students.Length < universityArray.Average(un => un.Students.Length)).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(uni => uni.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray
                .Where(uni =>
                    uni.Students.All(s => s.Gender == Gender.Female) || uni.Students.All(s => s.Gender == Gender.Male))
                .SelectMany(uni => uni.Students).Distinct().ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(uni => uni.Students).GroupBy(s => s).Where(g => g.Count() > 1)
                .Select(g => g.Key).ToArray();
        }
    }
}