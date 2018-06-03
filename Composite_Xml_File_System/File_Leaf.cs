using System;
using System.IO;

namespace Composite_Xml_File_System
{
    class File_Leaf : Component
    {
        public File_Leaf(FileInfo fileInfo) : base(fileInfo)
        {
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {
            String_.str += (new String(' ', depth) + "File: " + fileInfo.Name + Environment.NewLine);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}

