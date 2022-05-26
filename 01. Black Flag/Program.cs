using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	On the 1st line, you will receive the days of the plunder – an integer number in the range[0…100000]
            //•	On the 2nd line, you will receive the daily plunder – an integer number in the range[0…50]
            //•	On the 3rd line, you will receive the expected plunder – a real number in the range[0.0…10000.0]

            int daysPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            int expectedPluder = int.Parse(Console.ReadLine());
            double totalPlunder = 0.00;
            for(int curDay = 1; curDay <= daysPlunder; curDay++)
            {
                totalPlunder += dailyPlunder;
                if (curDay % 3 == 0)
                {
                    totalPlunder += dailyPlunder / 2.00;
                }
                if (curDay % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }
            }
            if (totalPlunder >= expectedPluder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only " +
                    $"{(totalPlunder*1.00/expectedPluder)*100.00:f2}% of the plunder.");
            }
        }
    }
}
