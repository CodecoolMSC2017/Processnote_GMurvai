using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessNote
{
    public class ProcessContainer
    {
        private Process process;
        private List<string> notes;

        public ProcessContainer(Process process)
        {
            this.process = process;
            this.notes = new List<string>();
        }

        public Process Process { get => process; set => process = value; }
        public List<string> Notes { get => notes; set => notes = value; }

        public void AddNewNote(string note)
        {
            this.notes.Add(note);
        }

        public override string ToString()
        {
            return String.Format("%s , %d" + "% , " + "%d GB", process.ProcessName);
        }
    }
}
