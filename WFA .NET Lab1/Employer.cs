using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA.NET_Lab1
{
    [Serializable]
    public class Employer
    {
        public string name;
        public string lastName;
        public int age;
        public double stature;
        public int staff;

        [NonSerialized]
        public List<Employer> employers = new List<Employer>();
        [NonSerialized]
        public string BinList; // save last open file

        [NonSerialized]
        private readonly BinaryFormatter formatter = new BinaryFormatter();
        public Employer() { }
        public Employer(string Name, string LastName, int Age = 0, double Stature = 0.0, int Staff = 0)
        {
            name = Name;
            lastName = LastName;
            age = Age;
            stature = Stature;
            staff = Staff;
        }

        public void SerializeBin(List<Employer> emprs)
        {
            using(FileStream fs = new FileStream(BinList = new Form1().OpenBin(), FileMode.OpenOrCreate))
            {
                    formatter.Serialize(fs, emprs);
            }
        }
        public List<Employer> DeserializeBin()
        {
            using (FileStream fs = new FileStream(BinList = new Form1().OpenBin(), FileMode.OpenOrCreate))
            {
                 return (List<Employer>)formatter.Deserialize(fs);
            }
        }

        public void BinWriter(List<Employer> emprs)
        {
            try
            {
                if (emprs != null)
                {
                    // создаем объект BinaryWriter
                    using (BinaryWriter writer = new BinaryWriter(File.Open(BinList = new Form1().OpenBin(), FileMode.OpenOrCreate)))
                    {
                        // записываем в файл значение каждого поля структуры
                        foreach (Employer emp in emprs)
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
                MessageBox.Show("Employer.BinWriter() error:" + ex.Message);
            }
        }
        public List<Employer> BinReader()
        {
            try
            {
                employers = new List<Employer>();
                using (BinaryReader reader = new BinaryReader(File.Open(this.BinList = new Form1().OpenBin(), FileMode.Open)))
                { 
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        this.name = reader.ReadString();
                        this.lastName = reader.ReadString();
                        this.age = reader.ReadInt32();
                        this.stature = reader.ReadDouble();
                        this.staff = reader.ReadInt32();

                        employers.Add(new Employer(name, lastName, age, stature, staff));
                    }
                }
                return employers;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Employer.BinReader() error:" + ex.Message);
                return employers;
            }
        }
    }
}

