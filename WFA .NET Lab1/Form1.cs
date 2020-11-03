using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO.Compression;
using System.Linq.Expressions;

namespace WFA.NET_Lab1
{
    public partial class Form1
    {
        Employer Employer = new Employer();
        NewFile currentFile = new NewFile();
        NewFile compressedFile = new NewFile();
        List<Button> dinButtons = new List<Button>();
        private string dataFolder =
            @"C:\\Users\\Asus\\Desktop\\Универ\\3 Семестр. 2 Курс\\asp.net.C#\\LaboratoryProjects.С#\\LP1\\WFA .NET Lab1\\WFA .NET Lab1\\AppData\\";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Employer.employers.Add(new Employer("Ilya", "Lelia", 20, 174.0, 3));
                Employer.employers.Add(new Employer("Andrey", "Veselov", 20, 172.0, 2));
                Employer.employers.Add(new Employer("Olga", "Aleksandrova", 19, 170.0));
                Employer.employers.Add(new Employer("Alexander", "CalVal"));
                Employer.SerializeBin(Employer.employers);
                //Employer.BinWriter(Employer.employers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load error:" + ex.Message);
            }
        }
        private void Button_Open_Click(object sender, EventArgs e)
        {
            try
            {
                //currentFile.name = OpenTxt();
                //await TxtReaderAsync(currentFile.name);

                TxtReader(currentFile.name = OpenTxt());
                if (currentFile.name != null)
                {

                    var SaveButton = new Button();
                    SaveButton.Text = "Save";
                    SaveButton.Name = "SaveButton";
                    SaveButton.Size = new Size(70, 23); // 
                    SaveButton.Location = new Point(30, 262); //220 + 35  7
                    Controls.Add(SaveButton);
                    dinButtons.Add(SaveButton);
                    SaveButton.Click += new System.EventHandler(this.saveButton_click);

                    var CopyButton = new Button();
                    CopyButton.Text = "Save Copy";
                    CopyButton.Name = "CopyButton";
                    CopyButton.Size = new Size(70, 23);
                    CopyButton.Location = new Point(30, 292);
                    Controls.Add(CopyButton);
                    dinButtons.Add(CopyButton);
                    CopyButton.Click += new System.EventHandler(this.copyButton_click);

                    var rnmButton = new Button();
                    rnmButton.Text = "Rename";
                    rnmButton.Name = "rnmButton";
                    rnmButton.Size = new Size(70, 23);
                    rnmButton.Location = new Point(30, 322);
                    Controls.Add(rnmButton);
                    dinButtons.Add(rnmButton);
                    rnmButton.Click += new System.EventHandler(this.rnmButton_click);

                    var relocButton = new Button();
                    relocButton.Text = "Relocate";
                    relocButton.Name = "relocButton";
                    relocButton.Size = new Size(70, 23);
                    relocButton.Location = new Point(166, 262);
                    Controls.Add(relocButton);
                    dinButtons.Add(relocButton);
                    relocButton.Click += new System.EventHandler(this.relocButton_click);

                    var cmpButton = new Button();
                    cmpButton.Text = "To GZip";
                    cmpButton.Name = "cmpButton";
                    cmpButton.Size = new Size(70, 23);
                    cmpButton.Location = new Point(166, 292);
                    Controls.Add(cmpButton);
                    dinButtons.Add(cmpButton);
                    cmpButton.Click += new System.EventHandler(this.cmpButton_click);

                    var DCmpButton = new Button();
                    DCmpButton.Text = "From GZip";
                    DCmpButton.Name = "DCmpButton";
                    DCmpButton.Location = new Point(166, 322);
                    DCmpButton.Size = new Size(70, 23);
                    DCmpButton.TabIndex = 5;
                    DCmpButton.UseVisualStyleBackColor = true;
                    Controls.Add(DCmpButton);
                    dinButtons.Add(DCmpButton);
                    DCmpButton.Click += new System.EventHandler(this.dcmpButton_click);

                    openBinFile.Enabled = false;
                    closeButton.Enabled = true;

                    MessageBox.Show("File opened!");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Button_Open_Click error:" + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Button_Open_Click error:" + ex.Message);
            }
        }

        
        private void openBinFile_Click(object sender, EventArgs e)
        {
            try
            {
                //Employer.employers = Employer.BinReader();
                Employer.employers = Employer.DeserializeBin();
                ResultBlock.Text = "Имя:\tФамилия:\tРост:\tКоманда:\tВозраст:\r\n";
                if(Employer.employers!=null)
                foreach(var empr in Employer.employers)
                {
                    ResultBlock.Text += empr.name + "\t" + empr.lastName + "\t\t" + empr.stature + "\t" + empr.staff + "\t" + empr.age + "\r\n";
                }

                var ClearBinButton = new Button();
                ClearBinButton.Text = "Clear";
                ClearBinButton.Name = "ClearBinButton";
                ClearBinButton.Size = new Size(68, 23); // 
                ClearBinButton.Location = new Point(100, 262); //220 + 35  7
                Controls.Add(ClearBinButton);
                dinButtons.Add(ClearBinButton);
                ClearBinButton.Click += new System.EventHandler(this.clearBinButton_click);

                Button_Open.Enabled = false;
                saveAsButton.Enabled = false;
                closeButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load error:" + ex.Message);
            }

        }
        private async void saveAsButton_Click(object sender, EventArgs e)
        {
            if ((currentFile.name = SaveTxt()) != null)
            {
                await TxtWriterAsync(currentFile.name);
                MessageBox.Show("File saved!");
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            foreach (var FButton in dinButtons)
            {
                Controls.Remove(FButton);
            }
            ResultBlock.Clear();
            Button_Open.Enabled = true;
            saveAsButton.Enabled = true;
            closeButton.Enabled = false;

            //send all files from \AppData\start to \AppData\end
                /*
                string StartDir = @"C:\\Users\\Asus\\Desktop\\Универ\\3 Семестр. 2 Курс\\asp.net.C#\\Лабораторные работы. С#\\ЛР1\\WFA .NET Lab1\\WFA .NET Lab1\\AppData\\start";
                string EndDir = @"C:\\Users\\Asus\\Desktop\\Универ\\3 Семестр. 2 Курс\\asp.net.C#\\Лабораторные работы. С#\\ЛР1\\WFA .NET Lab1\\WFA .NET Lab1\\AppData\\end";

                foreach(string filename in Directory.EnumerateFiles(StartDir))
                {
                    using(FileStream SourceStream = System.IO.File.Open(filename,FileMode.Open))
                    {
                        using (FileStream DestinationStream = System.IO.File.Create(EndDir + filename.Substring(filename.LastIndexOf('\\'))))
                        {
                            await SourceStream.CopyToAsync(DestinationStream);
                        }
                    }
                }*/
            }

        string SaveTxt()
        {
            try
            {
                using (var openPicker = new SaveFileDialog())  
                {
                    openPicker.FileName = "";
                    openPicker.DefaultExt = "txt";
                    openPicker.Filter =
                        "Text files (*.txt)|*.txt|" +
                        "Dat Files (*.dat)|*.dat|" +
                        "All files (*.*)|*.*";
                    openPicker.InitialDirectory = dataFolder;

                    if (openPicker.ShowDialog() == DialogResult.Cancel)
                        return null;
                    return openPicker.FileName;
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("SaveTxtFile error:" + ex.Message);
                return null;
            }
        }
        string OpenTxt()
        {
            try
            {
                using (var openPicker = new OpenFileDialog())
                {
                    openPicker.FileName = "";
                    openPicker.DefaultExt = "txt";
                    openPicker.Filter =
                        "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openPicker.InitialDirectory = dataFolder;

                    if (openPicker.ShowDialog() == DialogResult.Cancel)
                        return null;
                    return openPicker.FileName;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("OpenTxt error:" + ex.Message);
                return null;
            }
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
        string OpenGz()
        {
            try
            {
                using (var openPicker = new OpenFileDialog())
                {
                    openPicker.FileName = "";
                    openPicker.DefaultExt = "gz";
                    openPicker.Filter =
                        "Archive files (*.gz)|*.gz|All files (*.*)|*.*";
                    openPicker.InitialDirectory = dataFolder;

                    if (openPicker.ShowDialog() == DialogResult.Cancel)
                        return null;
                    return openPicker.FileName;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("OpenGz error:" + ex.Message);
                return null;
            }
        }
        public string BrowseFolder()
        {
            try
            {
                using (var openPicker = new FolderBrowserDialog())
                {
                    openPicker.SelectedPath = dataFolder;
                    openPicker.Description = "Select Folder name:";

                    if (openPicker.ShowDialog() == DialogResult.Cancel)
                        return null;
                    return openPicker.SelectedPath;
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("BrowseFolder error:" + ex.Message);
                return null;
            }
        }
        async Task TxtReaderAsync(string FileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    ResultBlock.Text = await sr.ReadToEndAsync();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("TxtReaderAsync error:" + ex.Message);
            }
        }
        async Task TxtWriterAsync(string FileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName))
                {
                    await sw.WriteAsync(ResultBlock.Text);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("TxtWriterAsync error:" + ex.Message);
            }
        }
        void TxtReader(string FileName)
        {
            try
            {
                if (FileName != null)
                    using (StreamReader sr = new StreamReader(FileName))
                    {
                            ResultBlock.Text = sr.ReadToEnd();
                    }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("TxtReader error:" + ex.Message);
            }
        }
        void TxtWriter(string FileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName))
                {
                    sw.Write(ResultBlock.Text);
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("TxtWriter error:" + ex.Message);
            }
        }

        void clearBinButton_click(object sender, EventArgs e)
        {
            currentFile.name = Employer.BinList;
            File.Delete(Employer.BinList);
            using (BinaryWriter bw = new BinaryWriter(File.Create(Employer.BinList = dataFolder + currentFile.name.Substring(currentFile.name.LastIndexOf('\\')))))
            {

            }
        }
        void saveButton_click(object sender, EventArgs e)
        {
            TxtWriter(currentFile.name);
            MessageBox.Show("File Saved!");
        }
        void copyButton_click(object sender, EventArgs e)
        {
            TxtWriter(SaveTxt());
            MessageBox.Show("Copy saved!");
        }
        void rnmButton_click(object sender, EventArgs e)
        {
            //nextFile.name = SaveTxt();
            //TxtWriter(nextFile.name);
            compressedFile.name = currentFile.name;
            TxtWriter(currentFile.name = SaveTxt());
            File.Delete(compressedFile.name);

            MessageBox.Show("File renamed!");
        }
        void relocButton_click(object sender, EventArgs e)
        {
            /*
            currentFile.dirInfo = new DirectoryInfo(BrowseFolder());
            compressedFile.name = currentFile.name; compressedFile.dirInfo = currentFile.dirInfo;

            using (FileStream SourceStream = System.IO.File.Open(compressedFile.name, FileMode.Open))
            {
                using (FileStream DestinationStream = System.IO.File.Create(currentFile.name = (compressedFile.dirInfo + compressedFile.name.Substring(compressedFile.name.LastIndexOf('\\')))))
                {
                    SourceStream.CopyTo(DestinationStream);
                }
            }
            File.Delete(compressedFile.name);
            compressedFile.name = currentFile.name;*/
            File.Move(currentFile.name,BrowseFolder()+currentFile.name.Substring(currentFile.name.LastIndexOf('\\')));

            MessageBox.Show("File located!");
        }
        void cmpButton_click(object sender, EventArgs e)
        {
            try
            {
                compressedFile.fileInfo = Compress(currentFile.fileInfo = new FileInfo(currentFile.name));
                MessageBox.Show($"File compressed: { currentFile.name} from { currentFile.fileInfo.Length.ToString()} to {compressedFile.fileInfo.Length.ToString()} bytes.");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("cmpButton_click error:" + ex.Message);
            }
        }
        void dcmpButton_click(object sender, EventArgs e)
        {
            try
            {
                Decompress(new FileInfo(compressedFile.name = OpenGz()));
                MessageBox.Show($"File decompressed: {compressedFile.name}");
                File.Delete(compressedFile.name);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("cmpButton_click error:" + ex.Message);
            }
        }

        FileInfo Compress(FileInfo fileToCompress)
        {
            try
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                        return new FileInfo(fileToCompress.DirectoryName + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                    }
                    return null;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Compress error:" + ex.Message);
                return null;
            }
        }
        void DirCompress(DirectoryInfo dirSelected)
        {
            // for show info List<FileInfo> and MessageBox.Show($"File compressed { currentFile.name} from { currentFile.fileInfo.Length.ToString()} to { compressedFile.fileInfo.Length.ToString()} bytes.");
            try
            {
                foreach (FileInfo fileToCompress in dirSelected.GetFiles())
                {
                    using (FileStream originalFileStream = fileToCompress.OpenRead())
                    {
                        if ((File.GetAttributes(fileToCompress.FullName) &
                           FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                        {
                            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                            {
                                using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                                   CompressionMode.Compress))
                                {
                                    originalFileStream.CopyTo(compressionStream);
                                }
                            }
                            FileInfo info = new FileInfo(dataFolder + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("DirCompress error:" + ex.Message);
            }
        }
        void Decompress(FileInfo fileToDecompress)
        {
            try
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Decompress error:" + ex.Message);
            }
        }
    }
}
