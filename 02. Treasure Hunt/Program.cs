using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine()
                .Split('|',StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command;
            while((command=Console.ReadLine())!= "Yohoho!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];
                if(action== "Loot")
                {
                    LootItemsInList(treasureChest, cmdArgs);
                }
                else if(action== "Drop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if(index<0 || index >= treasureChest.Count)
                    {
                        continue;
                    }
                    DropItemInList(treasureChest, index);
                }
                else if(action== "Steal")
                {
                    int count = int.Parse(cmdArgs[1]);
                    List<string> stealItems = StealItemInList(treasureChest, count);
                    stealItems.Reverse();
                    Console.WriteLine(string.Join(", ",stealItems));
                }
            }
            if (treasureChest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double avatageGain = GetAvaregeSum(treasureChest);
                Console.WriteLine($"Average treasure gain: {avatageGain:f2} pirate credits.");
            }
        }
        static void LootItemsInList(List<string> items, string[] loots)
        {
            for(int i = 1; i <loots.Length; i++)
            {
                if (items.Contains(loots[i]))
                {
                    continue;
                }
                items.Insert(0, loots[i]);
            }
        }
        static void DropItemInList(List<string>items,int index)
        {
            string indexItem = items[index];
            items.RemoveAt(index);
            items.Add(indexItem);
        }
        static List<string> StealItemInList(List<string>items,int count)
        {
            List<string> stealItems = new List<string>();
            for(int removeCount = 1; removeCount <= count; removeCount++)
            {
                string removeItem = items[items.Count - 1];
                items.Remove(removeItem);
                if (items.Count == 0)
                {
                    break;
                }
                
                stealItems.Add(removeItem);
            }
            return stealItems;
        }
        static double GetAvaregeSum(List<string> items)
        {
            double avaregeSum = 0.00;
            for(int i = 0; i < items.Count; i++)
            {
                int curPoints = items[i].Length;
                avaregeSum += curPoints;
            }
            avaregeSum /= ((items.Count) * 1.00);
            return avaregeSum;
        }
    }
}
