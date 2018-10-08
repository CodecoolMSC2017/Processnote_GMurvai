using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcessNote
{
    public class ViewService
    {
        readonly Process[] procList = Process.GetProcesses();

        public List<ProcessContainer> ReturnProcesses()
        {
            List<ProcessContainer> processContainers = new List<ProcessContainer>();
            foreach (Process process in procList)
            {
                processContainers.Add(new ProcessContainer(process));
            }
            return processContainers;
        }

        public ProcessContainer GetProcessById(string id)
        {
            List<ProcessContainer> processes = ReturnProcesses();

            foreach (ProcessContainer processcontainer in processes)
            {
                Process process = processcontainer.Process;
                if(process.Id.ToString().Equals(id))
                {
                    return processcontainer;
                }
            }
            return null;
        }
        
        public void ListViewStart(ListView listView)
        {
            listView.GridLines = true;
            List<ProcessContainer> processes = ReturnProcesses();
            foreach (ProcessContainer processContainer in processes)
            {
                Process process = processContainer.Process;

                ListViewItem item = new ListViewItem(process.Id.ToString());
                item.SubItems.Add(process.ProcessName);
                listView.Items.Add(item);
            }
        }

        public void ShowSpecificProcess(ListView listView1, ProcessContainer processContainer)
        {
            listView1.GridLines = true;
            Process process = processContainer.Process;
            PerformanceCounter perfCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName, true);
            float cpu = perfCounter.NextValue();

            ListViewItem id = new ListViewItem("ID");
            id.SubItems.Add(process.Id.ToString());
            listView1.Items.Add(id);

            ListViewItem name = new ListViewItem("Process name");
            // TODO try to get proper cpu usage data.
            name.SubItems.Add(process.ProcessName);
            listView1.Items.Add(name);

            ListViewItem cpuList = new ListViewItem("CPU Usage /%/");
            cpuList.SubItems.Add(cpu.ToString());
            listView1.Items.Add(cpuList);

            ListViewItem memory = new ListViewItem("Memory Usage /GB/");
            memory.SubItems.Add((process.PrivateMemorySize64 / 1024.0 / 1024.0).ToString());
            listView1.Items.Add(memory);

            ListViewItem startTime = new ListViewItem("Started At");
            ListViewItem running = new ListViewItem("Time Running");

            try
            {
                startTime.SubItems.Add(process.StartTime.ToString());
                running.SubItems.Add(process.TotalProcessorTime.ToString());
            }
            catch (Exception ex)
            {
                startTime.SubItems.Add("NaN");
                running.SubItems.Add("NaN");
            }
            listView1.Items.Add(startTime);
            listView1.Items.Add(running);

            ListViewItem numOfComments = new ListViewItem("Number of comments");
            numOfComments.SubItems.Add(processContainer.Notes.Count.ToString());

        }

        // TODO add more data to the Global Stats view
        public void ShowGlobalSpecs(ListView listView)
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            float cpu = cpuCounter.NextValue();

            float memory = GC.GetTotalMemory(true);

            ListViewItem cpuList = new ListViewItem("CPU Usage /%/");
            cpuList.SubItems.Add(cpu.ToString());
            Console.WriteLine(cpu.ToString());
            listView.Items.Add(cpuList);

            ListViewItem memoryList = new ListViewItem("Memory Usage /GB/");
            memoryList.SubItems.Add(memory.ToString());
            Console.WriteLine(memory.ToString());
            listView.Items.Add(memoryList);
        }
    }
}


