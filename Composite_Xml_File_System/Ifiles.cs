using System;

namespace Composite_Xml_File_System
{
    interface Ifiles
    {
        String Tree { get; set; }
        String Path { get; }
        event EventHandler<EventArgs> Tree_string;
    }
}
