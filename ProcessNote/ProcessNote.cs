using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using EasyTabs;

namespace ProcessNote
{
    public partial class ProcessNote : Form
    {
        ViewService viewService;
        TabService tabService;
        TaskStats taskstats;

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public ProcessNote()
        {
            InitializeComponent();
            this.viewService = new ViewService();
            this.tabService = new TabService();
            listView1.DoubleClick += listView1_DoubleClick;
        }

        private void ProcessNote_Load(object sender, EventArgs e)
        {
            viewService.ListViewStart(listView1);
        }
        
        private void listView1_SingleClick(object sender, EventArgs e)
        {
            ProcessNote_Load(sender,e);
        }
        

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            ProcessContainer processContainer = viewService.GetProcessById(id);
            tabService.AddNewTab(processContainer);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }


    }
}
