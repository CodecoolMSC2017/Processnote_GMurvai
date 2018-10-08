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
    public partial class AppContainer : TitleBarTabs
    {
        private ViewService ViewService;
        public AppContainer()
        {
            InitializeComponent();
            this.ViewService = new ViewService();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new TaskStats
                {
                    Text = "Global Stats"
                }

            };
        }

       

        public TitleBarTab OpenStats(ProcessContainer processContainer)
        {
            String processName = processContainer.Process.ProcessName;
            return new TitleBarTab(this)
            {
                Content = new TaskStats(processContainer)
                {
                    Text = processName
                }
            };
        }

        private void AppContainer_Load(object sender, EventArgs e)
        {
            this.Size = new Size(330, 400);

        }
    }
}
