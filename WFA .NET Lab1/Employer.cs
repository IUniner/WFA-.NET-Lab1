using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.NET_Lab1
{
    public class Employer
    {    
        public string name;
        public string lastName;
        public int age;
        public double stature;
        public int staff;

        public Employer() { }
        public Employer(string Name, string LastName, int Age = 0, double Stature = 0.0, int Staff = 0) 
        {
            name = Name;
            lastName = LastName;
            age = Age;
            stature = Stature;
            staff = Staff;
        }

        void BinWriter(List<Employer> employers)
        {
            try
            {
                if (employers != null)
                {
                    // создаем объект BinaryWriter
                    using (BinaryWriter writer = new BinaryWriter(File.Open(Form1::BrowseFolder(), FileMode.OpenOrCreate)))
                    {
                        // записываем в файл значение каждого поля структуры
                        foreach (Employer emp in employers)
                        {
                            {
                                writer.Write(emp.name);
                                writer.Write(emp.lastName);
                                writer.Write(emp.age);
                                writer.Write(emp.stature);
                                writer.Write(emp.staff);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load error:" + ex.Message);
            }
        }

        void BinWriter(List<Employer> employers)
        {
            try
            {
                if (employers != null)
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(dataFolder, FileMode.Open)))
                    {
                        // пока не достигнут конец файла
                        // считываем каждое значение из файла
                        while (reader.PeekChar() > -1)
                        {
                            string name = reader.ReadString();
                            string capital = reader.ReadString();
                            int area = reader.ReadInt32();
                            double population = reader.ReadDouble();

                            Console.WriteLine("Страна: {0}  столица: {1}  площадь {2} кв. км   численность населения: {3} млн. чел.",
                                name, capital, area, population);
                        }
                    }
                }
            }
        }
    }
    }

