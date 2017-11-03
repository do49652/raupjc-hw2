using System;
using System.Threading.Tasks;

namespace Zadatak7
{
    public class Class1
    {
        public static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber().Result;
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuyAsync()
        {
            return await IKnowWhoKnowsThisAsync(10) + await IKnowWhoKnowsThisAsync(5);
        }

        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await Zadatak6.Class1.FactorialDigitSum(n);
        }
    }
}