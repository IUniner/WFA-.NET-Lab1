using System;
using System.IO;
using System.Windows.Forms;

namespace WFA.NET_Lab1
{
    public class NewFile
    {
        public string name;
        public DirectoryInfo dirInfo;
        public FileInfo fileInfo;
        private string dataFolder =
            @"C:\\Users\\Asus\\Desktop\\Универ\\3 Семестр. 2 Курс\\asp.net.C#\\LaboratoryProjects.С#\\LP1\\WFA .NET Lab1\\WFA .NET Lab1\\AppData\\";

        public NewFile()
        {

        }
        public NewFile(string Name, FileInfo FileInfo, DirectoryInfo DirInfo)
        {
            Name = this.name;
            FileInfo = this.fileInfo;
            DirInfo = this.dirInfo;
        }

        public string OpenBin()
        {
            try
            {
                using (var openPicker = new OpenFileDialog())
                {
                    openPicker.FileName = "";
                    openPicker.DefaultExt = "dat";
                    openPicker.Filter =
                        "Bin files (*.dat)|*.dat|All files (*.*)|*.*";
                    openPicker.InitialDirectory = dataFolder;

                    if (openPicker.ShowDialog() == DialogResult.Cancel)
                        return null;
                    return openPicker.FileName;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("OpenBin error:" + ex.Message);
                return null;
            }
        }


    }
}
