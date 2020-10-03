using System;
using System.Runtime.InteropServices.ComTypes;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int[] dp = new int[days*20 + 1];
            int[] vouchers = new int[] { 20, 100 };

            dp[0] = 0;
            for (int i = 1; i <= days; i++)
            {
                int sum = i * 20;
                int minVouchers = int.MaxValue;
                for (int j = 0; j < vouchers.Length; j++)
                {
                    if (sum - vouchers[j] >= 0)
                    {
                        minVouchers = Math.Min(dp[sum - vouchers[j]], minVouchers);
                    }
                }

                dp[sum] = minVouchers + 1; //adding 1 voucher

            }
            Console.WriteLine(dp[days*20]);
        }
    }
}
