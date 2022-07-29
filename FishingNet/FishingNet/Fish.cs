namespace FishingNet
{
    public class Fish
    {
        private string _fishType;

        private double _length;

        private double _weight;

        public string FishType
        {
            get { return _fishType; }
            set { _fishType = value; }
        }

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
