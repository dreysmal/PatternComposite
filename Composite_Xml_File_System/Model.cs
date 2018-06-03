using System;
using System.IO;
using System.Xml.Linq;

namespace Composite_Xml_File_System
{
    public static class String_
    {
        public static String str;
    }
    class Model
    {
        public void Lunch(String path)
        {
            XDocument file_system = new XDocument();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            Component root = new Directory_Composite(directoryInfo);
            XElement root_xml = new XElement("Directory");

            FileInfo[] files_in_root = directoryInfo.GetFiles();

            foreach (FileInfo file in files_in_root)
            {
                root.Add(new File_Leaf(file));

                XElement next_xml_element = new XElement("File");
                XAttribute file_attribute_readonly = new XAttribute("Readonly", file.IsReadOnly);
                XAttribute file_attribute_name = new XAttribute("Name", file.Name);
                XAttribute file_attribute_size = new XAttribute("Size", file.Length);
                XAttribute file_attribute_datacreation = new XAttribute("Data_creation", file.CreationTime.ToString());
                XAttribute file_attribute_extension = new XAttribute("Extension", file.Extension);
                next_xml_element.Add(file_attribute_readonly);
                next_xml_element.Add(file_attribute_name);
                next_xml_element.Add(file_attribute_size);
                next_xml_element.Add(file_attribute_datacreation);
                next_xml_element.Add(file_attribute_extension);

                root_xml.Add(next_xml_element);
            }


            Go_throw_file_structure(directoryInfo, root, root_xml);
            root.Display(0);
            root_xml.Save("file_structure.xml");
        }



        public void Go_throw_file_structure(DirectoryInfo directory, Component updirectory, XElement upxelement)
        {
            try
            {
                DirectoryInfo[] subdir = directory.GetDirectories();

                foreach (DirectoryInfo item in subdir)
                {
                    Component directory_next = new Directory_Composite(item);
                    XElement next_xml_element = new XElement("directory");
                    XAttribute attribute_readonly = new XAttribute("Readonly", item.Attributes.HasFlag(FileAttributes.ReadOnly));
                    XAttribute attribute_name = new XAttribute("Name", item.Name);
                    next_xml_element.Add(attribute_readonly);
                    next_xml_element.Add(attribute_name);
                    upxelement.Add(next_xml_element);

                    Go_throw_file_structure(item, directory_next, next_xml_element);
                    FileInfo[] fi = item.GetFiles();
                    foreach (FileInfo file in fi)
                    {
                        directory_next.Add(new File_Leaf(file));
                        XElement next_file_xml_element = new XElement("File");

                        XAttribute file_attribute_readonly = new XAttribute("Readonly", file.IsReadOnly);
                        XAttribute file_attribute_name = new XAttribute("Name", file.Name);
                        XAttribute file_attribute_size = new XAttribute("Size", file.Length);
                        XAttribute file_attribute_datacreation = new XAttribute("Data_creation", file.CreationTime.ToString());
                        XAttribute file_attribute_extension = new XAttribute("Extension", file.Extension);
                        next_file_xml_element.Add(file_attribute_readonly);
                        next_file_xml_element.Add(file_attribute_name);
                        next_file_xml_element.Add(file_attribute_size);
                        next_file_xml_element.Add(file_attribute_datacreation);
                        next_file_xml_element.Add(file_attribute_extension);

                        next_xml_element.Add(next_file_xml_element);
                    }
                    updirectory.Add(directory_next);
                }
            }
            catch { }
        }
    }
}

