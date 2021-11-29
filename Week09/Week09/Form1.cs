using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week09.Entities;
using System.IO;

namespace Week09
{
    public partial class Form1 : Form
    {
        Random rng = new Random(1234);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        List<string> simulatedMale = new List<string>();
        List<string> simulatedFemale = new List<string>();
        public Form1()
        {
            InitializeComponent();
            //Population = Beolvas_nep(@"c:/Temp/nép.csv");
            numericUpDown1.Value = 2010;
            BirthProbabilities = Beolvas_szuletes(@"c:/Temp/születés.csv");
            DeathProbabilities = Beolvas_halal(@"c:/Temp/halál.csv");
        }
        public List<Person> Beolvas_nep(string fajlnev)
        {
            List<Person> population = new List<Person>();
            using (StreamReader sr = new StreamReader(fajlnev, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    Person p = new Person();
                    string[] sor = sr.ReadLine().Split(';');
                    p.BirthYear = int.Parse(sor[0]);
                    p.Gender = (Gender)Enum.Parse(typeof(Gender),sor[1]);
                    p.NbrOfChildren = int.Parse(sor[2]);
                    population.Add(p);
                }
            }
            return population;
        }
        public List<BirthProbability> Beolvas_szuletes(string fajlnev)
        {
            List<BirthProbability> bp = new List<BirthProbability>();
            using (StreamReader sr = new StreamReader(fajlnev, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    BirthProbability be = new BirthProbability();
                    string[] sor = sr.ReadLine().Split(';');
                    be.Age = int.Parse(sor[0]);
                    be.NbrOfChildren = int.Parse(sor[1]);
                    be.OddsOfBirth = double.Parse(sor[2]);
                    bp.Add(be);
                }
            }
            return bp;
        }
        public List<DeathProbability> Beolvas_halal(string fajlnev)
        {
            List<DeathProbability> deathProbability = new List<DeathProbability>();
            using (StreamReader sr = new StreamReader(fajlnev, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    DeathProbability dp = new DeathProbability();
                    string[] sor = sr.ReadLine().Split(';');
                    dp.Gender = (Gender)Enum.Parse(typeof(Gender), sor[0]);
                    dp.Age = int.Parse(sor[1]);
                    dp.OddsOfDeath = double.Parse(sor[2]);
                    deathProbability.Add(dp);
                }
            }
            return deathProbability;
        }
        public void SimStep(int year, Person person)
        {
            if (person.IsAlive == false) return;
            int age = year - person.BirthYear;

            double oddsOfDeath = (from x in DeathProbabilities
                            where x.Age == age && x.Gender == person.Gender
                            select x.OddsOfDeath).FirstOrDefault();
            if (rng.NextDouble() < oddsOfDeath)
            {
                person.IsAlive = false;
            }
            if (person.IsAlive == true && person.Gender == Gender.Female)
            {
                double oddsOfBirth = (from x in BirthProbabilities
                                      where x.Age == age && x.NbrOfChildren == person.NbrOfChildren
                                      select x.OddsOfBirth).FirstOrDefault();
                if (rng.NextDouble() < oddsOfBirth)
                {
                    Person newPerson = new Person();
                    newPerson.BirthYear = year;
                    newPerson.Gender = (Gender)rng.Next(3);
                    newPerson.NbrOfChildren = 0;
                    Population.Add(newPerson);
                }
            }
            else
            {
                return;
            }
        }
        public void Simulation(int endYear)
        {
            for (int year = 2005; year < endYear + 1; year++)
            {
                int szamlalo = 0;
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive == true
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive == true
                                    select x).Count();
                //Console.WriteLine("Év:{0} Fiuk{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales);
                simulatedMale.Add(nbrOfMales.ToString());
                simulatedFemale.Add(nbrOfFemales.ToString());
                DisplayResults(year, szamlalo);
                szamlalo++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sf.FileName;
            }
        }
        private void DisplayResults(int currentyear, int elem)
        {
            richTextBox1.Text += "Szimulációs év: " + currentyear + "\n" + "\t Fiúk: " + simulatedMale[elem] + "\n" + "\t Lányok: " + simulatedFemale[elem] + "\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            simulatedFemale.Clear();
            simulatedMale.Clear();
            richTextBox1.Text = "";
            Population = Beolvas_nep(textBox1.Text);
            Simulation((int)numericUpDown1.Value);
        }
    }
}
