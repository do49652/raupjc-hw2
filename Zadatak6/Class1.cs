using System.Threading.Tasks;

namespace Zadatak6
{
    public class Class1
    {
        public static async Task<int> FactorialDigitSum(int n)
        {
            var result = 1;

            for (var i = 1; i <= n; i++)
                result *= i;

            return result;
        }
    }
}