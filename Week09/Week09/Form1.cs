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
        Random rng = new Random(9936);
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        public Form1()
        {
            InitializeComponent();
            Population = Beolvas_nep(@"c:/Temp/nép.csv");
            BirthProbabilities = Beolvas_szuletes(@"c:/Temp/születés.csv");
            DeathProbabilities = Beolvas_halal(@"c:/Temp/halál.csv");

            for (int year = 2005; year < 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {

                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive == true
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive == true
                                    select x).Count();
                Console.WriteLine("Év:{0} Fiuk{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales);
            }
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
    }
}
