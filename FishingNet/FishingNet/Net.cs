using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net 
    {
        private static int _capacity;
        private string _material;
        private List<Fish> _fish;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this._fish;

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
                return _fish.Count();
            }
        }

        public Net(string material, int capacity)
        {
            this.capacity = capacity;
            this.material = material;
            _fish = new List<Fish>(capacity);
        }

        public string AddFish(Fish fish)
        {
            string result = "";
            bool IsAdded = false;
            if (IsValidFish(fish))
            {
                if (_fish.Count + 1 < capacity)
                {
                    _fish.Add(fish);
                    result = "Successfully added " + fish.FishType + " to the fishing net.";
                }
                else if (_fish.Count + 1 > _capacity)
                {
                    result = "Fishing net is full";
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

        public bool ReleaseFish(double weight)
        {
            bool result = false;

            for (int i = 0; i < _fish.Count(); i++)
            {
                if (_fish.ElementAt(i).Weigth == weight)
                {
                    _fish.RemoveAt(i);
                    result = true;
                }
            }

            return result;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = null;
            for (int i = 0; i < _fish.Count; i++)
            {
                if (_fish.ElementAt(i).FishType == fishType)
                {
                    fish = _fish.ElementAt(i);
                }
            }

            return fish;
        }

        public Fish GetBiggestFish()
        {
            int index = 0;
            double maxLength = 0;
            for (int i = 0; i < _fish.Count(); i++)
            {
                if (maxLength < _fish.ElementAt(i).Length)
                {
                    maxLength = _fish.ElementAt(i).Length;
                    index = i;
                }
            }

            Fish fish = _fish.ElementAt(index);
            return fish;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Fish fish in _fish.OrderByDescending(f => f.Length))
            {
                stringBuilder.AppendLine(fish.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }

        private void Swap<T>(IList<T> list, int indexA, int indexB)
{
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
