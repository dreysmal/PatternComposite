using System;
using System.Collections.Generic;
using System.IO;

namespace Composite_Xml_File_System
{
    class Directory_Composite : Component
    {
        private List<Component> components = new List<Component>();

        public Directory_Composite(DirectoryInfo directoryInfo) : base(directoryInfo)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Display(int depth)
        {
            //Console.WriteLine(new String(' ', depth) + "Directory: " + directoryInfo.Name);
            String_.str += (new String(' ', depth) + "Directory: " + directoryInfo.Name + Environment.NewLine);
            foreach (Component component in components)
            {
                component.Display(depth + 10);
            }
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }
    }
}
