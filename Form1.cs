using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenFileUseAsArg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnFileBrowser(object sender, EventArgs e)
        {
            // This is a .NET Framework WinForm component to show a dialog.
            // It has opens to force a filter like *.txt

            var fileDialog = new OpenFileDialog()
            {
                Filter = "Test Programs (*.xml)|*.xml|All files (*.*)|*.*",
                CheckFileExists = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileToUse = fileDialog.FileName;
                this.fileToUseInput.Text = fileToUse;                
            }
        }

        private void runNotepad_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Focused Test Inc\\FTI Studio\\FTIStudio.exe");
            // This can also have other command line arguments such as forcing notepad
            // to open the file as ASCII instead of UNICODE.
             startInfo.Arguments = String.Format("-program %0", this.fileToUseInput.Text);

            // But because there is only one parameter needed, then just set
            // the filename as the first argument directly.
            //startInfo.Arguments = this.fileToUseInput.Text;

            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
        }
    }
}
