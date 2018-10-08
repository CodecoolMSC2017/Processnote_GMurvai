using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace ProcessNote
{
    class TabService
    {
        private AppContainer appContainer = new AppContainer();

        public AppContainer AppContainer { get => appContainer; set => appContainer = value; }

        public void InitialTab()
        {
            // Add the initial Tab
            appContainer.Tabs.Add(
                // Our First Tab created by default in the Application will have as content the Form1
                new TitleBarTab(appContainer)
                {
                    Content = new ProcessNote
                    {
                        Text = "Main"
                    }
                }
            );
            // Set initial tab the first one
            appContainer.SelectedTabIndex = 0;
        }
        // TODO search bugs!!! Try to find out how can open new tab with a new WinForm too
        public void AddNewTab(ProcessContainer processContainer)
        {
            appContainer.Tabs.Add(appContainer.OpenStats(processContainer));
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.OpenWindow(appContainer);
           
        }
    }
}
