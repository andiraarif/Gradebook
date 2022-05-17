namespace Gradebook
{
    public abstract class Book
    {
        private string name;
        public string Name{get => name;}

        public abstract void AddGrade(double grade);
        public abstract List<double> GetGrades();

        public Book(string name)
        {
            this.name = name;
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            List<double>grades = GetGrades();

            foreach (double grade in grades)
            {
                stats.Add(grade);

            }
            return stats;
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> gradeList;

        public InMemoryBook(string name) : base(name)
        {   
            gradeList = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100) 
            {
                gradeList.Add(grade);
            }
            else
            {
                throw new InvalidDataException("Value must be between 0 to 100");
            }
        }

        public override List<double> GetGrades()
        {
            return gradeList;   
        }
    }

    public class InFileBook : Book
    {
        private string fname;

        public InFileBook(string name) : base(name)
        {
            fname = $"{Name}.txt";
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100) 
            {
                using(StreamWriter writer = File.AppendText(fname))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new InvalidDataException("Value must be between 0 to 100");
            }
        }

        public override List<double> GetGrades()
        {
            var grades = new List<double>();
            
            try
            {
                using (StreamReader reader = File.OpenText(fname))
                {
                    string? line = reader.ReadLine();
                    while (line != null)
                    {
                        grades.Add(double.Parse(line));
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            return grades;
        }
    }
}

