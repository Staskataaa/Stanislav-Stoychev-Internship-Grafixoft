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
        public double Weigth
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Fish(string fishType, double length, double weight)
        {
            _fishType = fishType;
            _length = length;
            _weight = weight;
        }

        public override string ToString()
        { 
            return "There is a " + _fishType + ", " + _length + " cm. long and " + _weight + " gr. in weight";
        }
    }
}
