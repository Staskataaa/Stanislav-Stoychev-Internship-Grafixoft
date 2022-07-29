using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net 
    {
        private readonly ICollection<Fish> fish;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => this.fish.Count;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;

        public string AddFish(Fish fish)
        {
            string result = "";
            if (IsValidFish(fish))
            {
                if (Fish.Count + 1 > Capacity)
                {
                    result = "Fishing net is full.";
                }
                else                 
                {
                    this.fish.Add(fish);
                    result = $"Successfully added {fish.FishType} to the fishing net.";
                }
            }
            else
            {
                result = "Invalid fish.";
            }
            return result;
        }

        private bool IsValidFish(Fish fish)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(fish.FishType) && Math.Min(fish.Length, fish.Weight) > 0)
            {
                result = true;
            }
            return result;
        }


        public bool ReleaseFish(double weight)
        { 
            bool result = false;

            for (int i = 0; i < fish.Count(); i++)
            {
                if (fish.ElementAt(i).Weight == weight)
                {
                    result = true;
                    fish.Remove(fish.ElementAt(i));
                    break;
                }
            }

            return result;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = null;
            for (int i = 0; i < this.fish.Count; i++)
            {
                if (this.fish.ElementAt(i).FishType == fishType)
                {
                    fish = this.fish.ElementAt(i);
                    break;
                }
            }

            return fish;
        }

        public Fish GetBiggestFish()
        {
            double longestLength = 0;
            int index = 0;
            for (int i = 0; i < fish.Count(); i++)
            {
                if (fish.ElementAt(i).Length > longestLength)
                {
                    longestLength = fish.ElementAt(i).Length;
                    index = i;
                }
            }
            Fish longestFish = fish.ElementAt(index);
            return longestFish;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Into the {this.Material}:");

            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                stringBuilder.AppendLine(fish.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }

    }
}
