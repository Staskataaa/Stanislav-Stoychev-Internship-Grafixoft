using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net 
    {
        private static int _capacity;
        private string _material;
        private List<Fish> _Fish;

        public List<Fish> Fish
        { get; set; }

        public int capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public string material
        {
            get { return _material; }
            set { _material = value; }
        }

        public int Count
        {
            get 
            {
                int count = 0;
                for (int i = 0; i < _Fish.Count; i++)
                {
                    if (_Fish[i] != null)
                    {
                        count++;
                    }    
                }
                return count;
            }
        }

        public Net(string material, int capacity)
        {
            this.capacity = capacity;
            this.material = material;
            _Fish = new List<Fish>(capacity);
        }

        public string AddFish(Fish fish)
        {
            string result = "";
            bool IsAdded = false;
            if (IsValidFish(fish))
            {
                for (int i = 0; i < capacity; i++)
                {
                    _Fish.Add(fish);
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
            if (fish.FishType != "" && fish.FishType != null && Math.Min(fish.Length, fish.Weigth) > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
