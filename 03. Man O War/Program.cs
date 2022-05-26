using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] statusOfPirateShip = Console.ReadLine()
            .Split('>', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int[] warShip = Console.ReadLine()
            .Split('>', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int healthCapacity = int.Parse(Console.ReadLine());
            string command;
            double needReapir = healthCapacity * 0.20;
            bool hasAnyoneWon = false;
            while((command=Console.ReadLine())!= "Retire")
            {
                string[] cmdArgs = command.
                Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string action = cmdArgs[0];
                if(action=="Fire")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int damage = int.Parse(cmdArgs[2]);
                    if(index<0 || index >= warShip.Length)
                    {
                        continue;
                    }
                    FireShip(warShip, index, damage);
                    if (warShip[index] <= 0)
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        hasAnyoneWon = true;
                        break;
                    }
                }else if(action== "Defend")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    int damage = int.Parse(cmdArgs[3]);
                    if(startIndex >= 0 && 
                        startIndex < 
                        statusOfPirateShip.Length && endIndex >= 0 && 
                        endIndex < statusOfPirateShip.Length )
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            statusOfPirateShip[i] -= damage;
                            if (statusOfPirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                hasAnyoneWon = true;
                                break;
                            }
                        }

                    }

                  
                   
                }
                else if(action== "Repair")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int health = int.Parse(cmdArgs[2]);
                    if(index<0 || index >= statusOfPirateShip.Length)
                    {
                        continue;
                    }
                    RepairShip(statusOfPirateShip, health, index, healthCapacity);
                }
                else if(action=="Status")
                {
                    int countSections = GetCountNeedRepeairSection
                        (statusOfPirateShip, needReapir);
                    Console.WriteLine($"{countSections} sections need repair.");
                }

            }
            if (!hasAnyoneWon)
            {
                int pirateShipSum = statusOfPirateShip.Sum();
                int warShipSum = warShip.Sum();
                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }
            
            
        }
        static int GetCountNeedRepeairSection(int[] pirateShip,double needRepairHealth)
        {
            int count = 0;
            for(int i = 0; i < pirateShip.Length; i++)
            {
                int currentPirateShipSection = pirateShip[i];
                if (currentPirateShipSection < needRepairHealth)
                {
                    count++;
                }
            }
            return count;
        }
        static void FireShip(int[]warShip,int index,int damage)
        {
            warShip[index] -= damage;
        }
        static void RepairShip(int[]pirateShip,int health,int index,int helthCapacity)
        {
            pirateShip[index] += health;
            if (pirateShip[index] >= helthCapacity)
            {
                pirateShip[index] = helthCapacity;
            }
        }
    }
}
