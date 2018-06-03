using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Xml_File_System
{
    class Presenter
    {
        private readonly Ifiles ifiles;
        Model model = new Model();
        public Presenter(Ifiles ifiles)
        {
            this.ifiles = ifiles;
            ifiles.Tree_string += new EventHandler<EventArgs>(Text);
        }

        public void Text(Object sender, EventArgs e)
        {
            String_.str = String.Empty;
            model.Lunch(ifiles.Path);
            ifiles.Tree = String_.str;
        }
    }
}
