using System.IO;

namespace Composite_Xml_File_System
{
    abstract class Component
    {
        public FileInfo fileInfo { get; set; }
        public DirectoryInfo directoryInfo { get; set; }

        public Component(FileInfo fileInfo, DirectoryInfo directoryInfo)
        {
            this.fileInfo = fileInfo;
            this.directoryInfo = directoryInfo;
        }

        public Component(FileInfo fileInfo) : this(fileInfo, null) { }
        public Component(DirectoryInfo directoryInfo) : this(null, directoryInfo) { }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }
}
