using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace ProcessNote
{
    public partial class TaskStats : Form
    {

        private ProcessContainer ProcessContainer;
        private ViewService viewService;

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public TaskStats(ProcessContainer processContainer)
        {
            InitializeComponent();
            this.ProcessContainer = processContainer;
            this.viewService = new ViewService();
            button1.Click += button1_ButtonClicked;
            button2.Click += button2_ButtonClicked;
        }

        public TaskStats() {
            InitializeComponent();
            this.viewService = new ViewService();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TaskStats_Load(object sender, EventArgs e)
        {
            if (ProcessContainer != null)
            {
                viewService.ShowSpecificProcess(listView1, ProcessContainer);
            }
            else
            {
                viewService.ShowGlobalSpecs(listView1);
            }

            
        }

        private void button1_ButtonClicked(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Equals(""))
            {
                MessageBox.Show("you can't save an empty note");
            }
            else
            {
                ProcessContainer.AddNewNote(richTextBox1.Text);
                this.Close();
            }
        }

        private void button2_ButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
