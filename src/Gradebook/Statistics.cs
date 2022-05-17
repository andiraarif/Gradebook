namespace Gradebook
{
    public class Statistics
    {
        private double lowest;
        private double highest;
        private double sum;
        private double count;

        public Statistics()
        {
            lowest = double.MaxValue;
            highest = double.MinValue;
            sum = 0.0;
            count = 0;
        }

        public double Lowest
        {
            get => lowest;
        }
        
        public double Highest
        {
            get => highest;
        }

        public double Average
        {
            get => sum / count;
        }
        public char AverageInLetter
        {
            get
            {
                switch (Average)
                {
                    case double average when average >= 90:
                        return 'A';
                    case double average when average >= 80:
                        return 'B';
                    case double average when average >= 70:
                        return 'C';
                    case double average when average >= 60:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public void Add(double grade)
        {
            sum += grade;
            count++;

            lowest = Math.Min(grade, lowest);
            highest = Math.Max(grade, highest);
        }
    }
}