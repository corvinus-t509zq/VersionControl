using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using szimulacio.Entities;

namespace szimulacio
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        Random rnd = new Random(1234);
        public Form1()
        {
            InitializeComponent();
        

          
            
        }
        public void Simulation()
        {
            Population = GetPopulation(textBox1.Text);
            BirthProbabilities = GetBirthProb(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProb(@"C:\Temp\halál.csv");
            for (int Year = 2005; Year < numericUpDown1.Value; Year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(Year, Population[i]);
                }
                int NbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int NbrOfFemales = (from y in Population
                                    where y.Gender == Gender.Femala && y.IsAlive
                                    select y).Count();

                Console.WriteLine(
                    string.Format("Év: {0} Fiúk:{1} Lányok:{2}", Year, NbrOfMales, NbrOfFemales));

            }
        }
        private void SimStep(int  year, Person person) 
        {
            if (!person.IsAlive) return;

            byte age = (byte)(year - person.BirthYear);

            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.Probability).FirstOrDefault();
            if (rnd.NextDouble() <= pDeath) person.IsAlive = false;

            if (person.Gender == Gender.Femala && person.IsAlive)
            {
                double pBirth = (from y in BirthProbabilities
                                 where y.Age == age
                                 select y.Probability).FirstOrDefault();

                if (rnd.NextDouble() <= pBirth) 
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rnd.Next(1,3));
                    Population.Add(újszülött);
                }

            }
        }
        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default)) 
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(
                        new Person()
                        {
                            BirthYear = int.Parse(line[0]),
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                            NbrOfChildren = int.Parse(line[2])
                        }
                        );
                }
            }
            return population;
        }

        public List<BirthProbability> GetBirthProb(string csvpath)
        {
            List<BirthProbability> birth = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birth.Add(
                        new BirthProbability()
                        {
                            Age = int.Parse(line[0]),
                            NbrOfChildren = int.Parse(line[1]),
                            Probability = double.Parse(line[2])
                        }
                        );
                }
            }
            return birth;
        }

        public List<DeathProbability> GetDeathProb(string csvpath)
        {
            List<DeathProbability> death = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    death.Add(
                        new DeathProbability()
                        {
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                            Age = int.Parse(line[1]),
                            Probability = double.Parse(line[2])
                        }
                        );
                }
            }
            return death;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Simulation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                textBox1.Text = ofd.FileName;
            }

        }
    }
}
