using System.IO;

namespace WFA.NET_Lab1
{
    public class NewFile
    {
        public string name;
        public DirectoryInfo dirInfo;
        public FileInfo fileInfo;

        public NewFile()
        {

        }
        public NewFile(string Name, FileInfo FileInfo, DirectoryInfo DirInfo)
        {
            Name = this.name;
            FileInfo = this.fileInfo;
            DirInfo = this.dirInfo;
        }
    }
}
