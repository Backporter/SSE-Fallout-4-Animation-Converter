using System;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace SSE_Fallout_4_Animation_Converter
{
    public partial class Main : Form
    {
        private List<string> filePaths = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            /// thse are what you see when you hover over the buttons
            toolTip1.SetToolTip(this.btadd, "This is to add them one by one");
            toolTip1.SetToolTip(this.btadddir, "This is for adding a dirtory");
            toolTip1.SetToolTip(this.btClear, "this will purge the list");
            toolTip1.SetToolTip(this.credit, "This will open the credit");
            toolTip1.SetToolTip(this.btstart, "this will start the ");

            /// this will check to see if the at9tool is present
            if (File.Exists("data\\HavokBehaviorPostProcess.exe"))
            {

            }
            else
            {
                MessageBox.Show("HavokBehaviorPostProcess.exe is missing please put it in the data folder");
                panel1.Enabled = false;
            }

            if (File.Exists("Data\\HCT_2010\\hctStandAloneFilterManager.exe"))
            {

            }
            else
            {
                MessageBox.Show("hctStandAloneFilterManager.exe is missing please put it in the Data\\HCT_2010\\ folder");
                panel2.Enabled = false;
            }

            if (File.Exists("Data\\HCT_2014\\hctStandAloneFilterManager.exe"))
            {

            }
            else
            {
                MessageBox.Show("hctStandAloneFilterManager.exe is missing please put it in the Data\\HCT_2014 folder");
                panel3.Enabled = false;
            }
            /// this is going to show the Mesagebox that give the warning if anything is missing it might now work like its suppost to
            MessageBox.Show("if any other required tools are missing this will not work right", ("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Due to legail reasons i can't include the required tools you will need to find them yourself", ("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            /// this is going to add files via the add file button to the listbox
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            OFD.ShowDialog();
            filePaths.AddRange(OFD.FileNames);
            for (int i = 0; i < filePaths.Count; i++)
            {
                lboxFiles.Items.Add(OFD.SafeFileNames[i]);
            }
            /// this is going to tell the system that label is the count of the listbox and the " To be converted "
            /// IE, "5 To be converted "
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void btadddir_Click(object sender, EventArgs e)
        {
            /// this is going to add all files via the add dir to the listbox
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select the Meshes Folder";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.hkx", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    if (!filePaths.Contains(file))
                    {
                        lboxFiles.Items.Add(Path.GetFileName(file));
                        filePaths.Add(file);
                        label1.Text = lboxFiles.Items.Count + " To be converted ";
                    }
                }
            }
            /// this is going to tell the system that label is the count of the listbox and the " To be converted "
            /// IE, "5 To be converted "
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            /// this is going to clear the list box
            lboxFiles.Items.Clear();
            /// this is going to refresh the listbox
            lboxFiles.Refresh();
            /// this is going to clear the list of file that where in the listbox
            filePaths.Clear();
            /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
            progressBar1.Maximum = lboxFiles.Items.Count;
            /// this is going to tell the system that label is the count of the listbox and the " To be converted "
            /// IE, "5 To be converted "
            label1.Text = lboxFiles.Items.Count + " To be converted ";
        }

        private void lboxFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string text in array)
            {
                if ((Path.GetExtension(text) == ".hkx" || Path.GetExtension(text) == ".HKX" || Path.GetExtension(text) == ".xml" || Path.GetExtension(text) == ".XML" && !filePaths.Contains(text)))
                {
                    lboxFiles.Items.Add(Path.GetFileName(text));
                    filePaths.Add(text);
                    label1.Text = lboxFiles.Items.Count + " To be converted ";
                }
                if (Directory.Exists(text))
                {
                    string[] files = Directory.GetFiles(text, "*.hkx", SearchOption.AllDirectories);
                    foreach (string text2 in files)
                    {
                        if (!filePaths.Contains(text2))
                        {
                            lboxFiles.Items.Add(Path.GetFileName(text2));
                            filePaths.Add(text2);
                            label1.Text = lboxFiles.Items.Count + " To be converted ";
                        }
                    }
                    files = Directory.GetFiles(text, "*.xml", SearchOption.AllDirectories);
                    foreach (string xml in files)
                    {
                        if (!filePaths.Contains(xml))
                        {
                            lboxFiles.Items.Add(Path.GetFileName(xml));
                            filePaths.Add(xml);
                            label1.Text = lboxFiles.Items.Count + " To be converted ";
                        }
                    }
                }
            }
        }

        private void lboxFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void credit_Click(object sender, EventArgs e)
        {
            /// this is going to open the credits window
            if (Application.OpenForms["Credits"] == null)
            {
                Credits form = new Credits();
                form.Show();
            }
        }

        private string getFileName(string path)
        {
            path = path.Replace("\\", ",");
            string[] pathSplit = path.Split(',');
            return pathSplit[pathSplit.Length - 1];
        }

        private void btstart_Click(object sender, EventArgs e)
        {
            /// this is going to create the dirtory hkx
            Directory.CreateDirectory("hkx");
            /// this is going to pass the dirtory info
            DirectoryInfo info = new DirectoryInfo(Application.StartupPath + "\\hkx\\");
            FileInfo[] files = info.GetFiles();
            foreach (FileInfo file in files)
            {
                /// this is going to delete all existing files in the hkx folder
                file.Delete();
            }
            for (int i = 0; i < filePaths.Count; i++)
            {
                if (F4.Checked)
                {
                    if (filePaths[i].Contains(".hkx"))
                    {
                        if (File.Exists(filePaths[i].ToString().Replace(".hkx", ".hko")))
                        {
                            File.Delete(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        }
                        File.Copy("Data\\Refrence.hko", filePaths[i].ToString().Replace(".hkx", ".hko"));
                        string text = File.ReadAllText(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        string exportinfo = File.ReadAllText(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        text = text.Replace("Replace", filePaths[i].ToString());
                        exportinfo = text.Replace("filename.hkx", filePaths[i].ToString());
                        File.WriteAllText(filePaths[i].ToString().Replace(".hkx", ".hko"), text);
                        File.WriteAllText(filePaths[i].ToString().Replace(".hkx", ".hko"), exportinfo);
                        Process pro = new Process();
                        pro.StartInfo.FileName = "cmd.exe";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.StartInfo.Arguments = "/c Data\\HCT_2014\\hctStandAloneFilterManager.exe -s \"" + filePaths[i].ToString().Replace(".hkx", ".hko") + "\" \"" + filePaths[i] + "\" -t -v -o \"" + filePaths[i] + "\"";
                        pro.Start();
                        pro.WaitForExit();
                        File.Delete(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        /// This its going to convert the Animation to PS4 version
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".HKX"))
                    {
                        if (File.Exists(filePaths[i].ToString().Replace(".HKX", ".hko")))
                        {
                            File.Delete(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        }
                        File.Copy("Data\\Refrence.hko", filePaths[i].ToString().Replace(".HKX", ".hko"));
                        string text = File.ReadAllText(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        string exportinfo = File.ReadAllText(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        text = text.Replace("Replace", filePaths[i].ToString());
                        exportinfo = text.Replace("filename.hkx", filePaths[i].ToString());
                        File.WriteAllText(filePaths[i].ToString().Replace(".HKX", ".hko"), text);
                        File.WriteAllText(filePaths[i].ToString().Replace(".HKX", ".hko"), exportinfo);
                        Process pro = new Process();
                        pro.StartInfo.FileName = "cmd.exe";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.StartInfo.Arguments = "/c Data\\HCT_2014\\hctStandAloneFilterManager.exe -s \"" + filePaths[i].ToString().Replace(".HKX", ".hko") + "\" \"" + filePaths[i] + "\" -t -v -o \"" + filePaths[i] + "\"";
                        pro.Start();
                        pro.WaitForExit();
                        File.Delete(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        /// This its going to convert the Animation to PS4 version
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }

                else if (SK.Checked)
                {
                    if (filePaths[i].Contains(".hkx"))
                    {
                        if (File.Exists(filePaths[i].ToString().Replace(".hkx", ".hko")))
                        {
                            File.Delete(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        }
                        File.Copy("Data\\SkyrimRefrence.hko", filePaths[i].ToString().Replace(".hkx", ".hko"));
                        string text = File.ReadAllText(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        string exportinfo = File.ReadAllText(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        text = text.Replace("Replace", filePaths[i].ToString());
                        exportinfo = text.Replace("filename.hkx", filePaths[i].ToString());
                        File.WriteAllText(filePaths[i].ToString().Replace(".hkx", ".hko"), text);
                        File.WriteAllText(filePaths[i].ToString().Replace(".hkx", ".hko"), exportinfo);
                        Process pro = new Process();
                        pro.StartInfo.FileName = "cmd.exe";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.StartInfo.Arguments = "/c Data\\HCT_2010\\hctStandAloneFilterManager.exe -s \"" + filePaths[i].ToString().Replace(".hkx", ".hko") + "\" \"" + filePaths[i] + "\" -t -v -o \"" + filePaths[i] + "\"";
                        pro.Start();
                        pro.WaitForExit();
                        File.Delete(filePaths[i].ToString().Replace(".hkx", ".hko"));
                        Process pro1 = new Process();
                        pro1.StartInfo.FileName = "cmd.exe";
                        pro1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro1.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i] + "\" \"" + filePaths[i] + "\"";
                        pro1.Start();
                        pro1.WaitForExit();
                        /// This its going to convert the Animation to PS4 version
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }

                    else if (filePaths[i].Contains(".HKX"))
                    {
                        if (File.Exists(filePaths[i].ToString().Replace(".HKX", ".hko")))
                        {
                            File.Delete(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        }
                        File.Copy("Data\\SkyrimRefrence.hko", filePaths[i].ToString().Replace(".HKX", ".hko"));
                        string text = File.ReadAllText(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        string exportinfo = File.ReadAllText(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        text = text.Replace("Replace", filePaths[i].ToString());
                        exportinfo = text.Replace("filename.hkx", filePaths[i].ToString());
                        File.WriteAllText(filePaths[i].ToString().Replace(".HKX", ".hko"), text);
                        File.WriteAllText(filePaths[i].ToString().Replace(".HKX", ".hko"), exportinfo);
                        Process pro = new Process();
                        pro.StartInfo.FileName = "cmd.exe";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.StartInfo.Arguments = "/c Data\\HCT_2010\\hctStandAloneFilterManager.exe -s \"" + filePaths[i].ToString().Replace(".HKX", ".hko") + "\" \"" + filePaths[i] + "\" -t -v -o \"" + filePaths[i] + "\"";
                        pro.Start();
                        pro.WaitForExit();
                        File.Delete(filePaths[i].ToString().Replace(".HKX", ".hko"));
                        Process pro1 = new Process();
                        pro1.StartInfo.FileName = "cmd.exe";
                        pro1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro1.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i] + "\" \"" + filePaths[i] + "\"";
                        pro1.Start();
                        pro1.WaitForExit();
                        /// This its going to convert the Animation to PS4 version
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                    else if (filePaths[i].Contains(".HkX"))
                    {
                        if (File.Exists(filePaths[i].ToString().Replace(".HkX", ".hko")))
                        {
                            File.Delete(filePaths[i].ToString().Replace(".HkX", ".hko"));
                        }
                        File.Copy("Data\\SkyrimRefrence.hko", filePaths[i].ToString().Replace(".HkX", ".hko"));
                        string text = File.ReadAllText(filePaths[i].ToString().Replace(".HkX", ".hko"));
                        string exportinfo = File.ReadAllText(filePaths[i].ToString().Replace(".HkX", ".hko"));
                        text = text.Replace("Replace", filePaths[i].ToString());
                        exportinfo = text.Replace("filename.hkx", filePaths[i].ToString());
                        File.WriteAllText(filePaths[i].ToString().Replace(".HkX", ".hko"), text);
                        File.WriteAllText(filePaths[i].ToString().Replace(".HkX", ".hko"), exportinfo);
                        Process pro = new Process();
                        pro.StartInfo.FileName = "cmd.exe";
                        pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro.StartInfo.Arguments = "/c Data\\HCT_2010\\hctStandAloneFilterManager.exe -s \"" + filePaths[i].ToString().Replace(".HkX", ".hko") + "\" \"" + filePaths[i] + "\" -t -v -o \"" + filePaths[i] + "\"";
                        pro.Start();
                        pro.WaitForExit();
                        File.Delete(filePaths[i].ToString().Replace(".HkX", ".hko"));
                        Process pro1 = new Process();
                        pro1.StartInfo.FileName = "cmd.exe";
                        pro1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        pro1.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i] + "\" \"" + filePaths[i] + "\"";
                        pro1.Start();
                        pro1.WaitForExit();
                        /// This its going to convert the Animation to PS4 version
                        /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                        progressBar1.Maximum = lboxFiles.Items.Count;
                        /// This is going to make it so you can see the bar move
                        System.GC.Collect();
                        /// this is going to make it move
                        progressBar1.Value++;
                    }
                }

                else if (SK_Upgrade.Checked)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i] + "\" \"" + filePaths[i] + "\"";
                    process.Start();
                    process.WaitForExit();
                    /// This its going to convert the Animation to PS4 version
                    /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                    progressBar1.Maximum = lboxFiles.Items.Count;
                    /// This is going to make it so you can see the bar move
                    System.GC.Collect();
                    /// this is going to make it move
                    progressBar1.Value++;
                }

                if (filePaths[i].Contains(".xml"))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.Arguments = "/c data\\hkxcmd.exe convert -v:WIN32 \"" + filePaths[i] + "\" \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    process.WaitForExit();
                    Process process1 = new Process();
                    process1.StartInfo.FileName = "cmd.exe";
                    process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process1.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\" \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\"";
                    process1.Start();
                    process1.WaitForExit();
                    /// This its going to convert the Animation to PS4 version
                    /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                    progressBar1.Maximum = lboxFiles.Items.Count;
                    /// This is going to make it so you can see the bar move
                    System.GC.Collect();
                    /// this is going to make it move
                    progressBar1.Value++;

                    if (FIX_PATH.Checked)
                    {
                        ///MessageBox.Show("IF You Don't Got The xml In The Current Directory this will fail and cause the app to crash");
                        Directory.CreateDirectory("Meshes");
                        Directory.CreateDirectory("Meshes\\actors");
                        Directory.CreateDirectory("Meshes\\actors\\character");
                        Directory.CreateDirectory("Meshes\\actors\\character\\animations");
                        Directory.CreateDirectory("Meshes\\actors\\character\\behaviors");
                        Directory.CreateDirectory("Meshes\\actors\\character\\characters");
                        Directory.CreateDirectory("Meshes\\actors\\character\\characters female");
                        if (File.Exists("xml\\0_master.hkx"))
                        {
                            File.Move("xml\\0_master.hkx", "Meshes\\actors\\character\\behaviors\\0_master.hkx");
                        }
                        else if (File.Exists("xml\\1hm_behavior_PATCHED.hkx"))
                        {
                            File.Move("xml\\1hm_behavior_PATCHED.hkx", "Meshes\\actors\\character\\behaviors\\1hm_behavior.hkx");
                        }
                        else if (File.Exists("xml\\1hm_locomotion.hkx"))
                        {
                            File.Move("xml\\1hm_locomotion.hkx", "Meshes\\actors\\character\\behaviors\\1hm_locomotion.hkx");
                        }
                        else if (File.Exists("xml\\bashbehavior.hkx"))
                        {
                            File.Move("xml\\bashbehavior.hkx", "Meshes\\actors\\character\\behaviors\\bashbehavior.hkx");
                        }
                        ///
                        else if (File.Exists("xml\\blockbehavior.hkx"))
                        {
                            File.Move("xml\\blockbehavior.hkx", "Meshes\\actors\\character\\behaviors\\blockbehavior.hkx");
                        }
                        else if (File.Exists("xml\\bow_direction_behavior.hkx"))
                        {
                            File.Move("xml\\bow_direction_behavior.hkx", "Meshes\\actors\\character\\behaviors\\bow_direction_behavior.hkx");
                        }
                        else if (File.Exists("xml\\FNIS_FNISBase_Behavior.hkx"))
                        {
                            File.Move("xml\\FNIS_FNISBase_Behavior.hkx", "Meshes\\actors\\character\\behaviors\\FNIS_FNISBase_Behavior.hkx");
                        }
                        else if (File.Exists("xml\\idlebehavior_PATCHED.hkx"))
                        {
                            File.Move("xml\\idlebehavior_PATCHED.hkx", "Meshes\\actors\\character\\behaviors\\idlebehavior.hkx");
                        }
                        else if (File.Exists("xml\\magic_readied_direction_behavior.hkx"))
                        {
                            File.Move("xml\\magic_readied_direction_behavior.hkx", "Meshes\\actors\\character\\behaviors\\magic_readied_direction_behavior.hkx");
                        }
                        else if (File.Exists("xml\\magicbehavior.hkx"))
                        {
                            File.Move("xml\\magicbehavior.hkx", "Meshes\\actors\\character\\behaviors\\magicbehavior.hkx");
                        }
                        else if (File.Exists("xml\\magicmountedbehavior.hkx"))
                        {
                            File.Move("xml\\magicmountedbehavior.hkx", "Meshes\\actors\\character\\behaviors\\magicmountedbehavior.hkx");
                        }
                        else if (File.Exists("xml\\mt_behavior.hkx"))
                        {
                            File.Move("xml\\mt_behavior.hkx", "Meshes\\actors\\character\\behaviors\\mt_behavior.hkx");
                        }
                        else if (File.Exists("xml\\shout_behavior.hkx"))
                        {
                            File.Move("xml\\shout_behavior.hkx", "Meshes\\actors\\character\\behaviors\\shout_behavior.hkx");
                        }
                        else if (File.Exists("xml\\sprintbehavior.hkx"))
                        {
                            File.Move("xml\\sprintbehavior.hkx", "Meshes\\actors\\character\\behaviors\\sprintbehavior.hkx");
                        }
                        else if (File.Exists("xml\\staggerbehavior.hkx"))
                        {
                            File.Move("xml\\staggerbehavior.hkx", "Meshes\\actors\\character\\behaviors\\staggerbehavior.hkx");
                        }
                        else if (File.Exists("xml\\weapequip.hkx"))
                        {
                            File.Move("xml\\weapequip.hkx", "Meshes\\actors\\character\\behaviors\\weapequip.hkx");
                        }
                        ///
                        else if (File.Exists("xml\\defaultmale.hkx"))
                        {
                            File.Move("xml\\defaultmale.hkx", "Meshes\\actors\\character\\characters\\defaultmale.hkx");
                        }
                        else if (File.Exists("xml\\defaultfemale.hkx"))
                        {
                            File.Move("xml\\defaultfemale.hkx", "Meshes\\actors\\character\\characters female\\defaultfemale.hkx");
                        }
                        else if (File.Exists("xml\\1hm_behavior.hkx"))
                        {
                            File.Move("xml\\1hm_behavior.hkx", "Meshes\\actors\\character\\behaviors\\1hm_behavior.hkx");
                        }
                    }
                }

                if (filePaths[i].Contains(".XML"))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.Arguments = "/c data\\hkxcmd.exe convert -v:WIN32 \"" + filePaths[i] + "\" \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    process.WaitForExit();
                    Process process1 = new Process();
                    process1.StartInfo.FileName = "cmd.exe";
                    process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process1.StartInfo.Arguments = "/c data\\HavokBehaviorPostProcess.exe --platformPS4 \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\" \"" + filePaths[i].ToString().Replace(".xml", ".hkx") + "\"";
                    process1.Start();
                    process1.WaitForExit();
                    /// This its going to convert the Animation to PS4 version
                    /// this is going to make the progress bar know how many files there are so it can move the bar acordingly
                    progressBar1.Maximum = lboxFiles.Items.Count;
                    /// This is going to make it so you can see the bar move
                    System.GC.Collect();
                    /// this is going to make it move
                    progressBar1.Value++;

                    if (FIX_PATH.Checked)
                    {
                        ///MessageBox.Show("IF You Don't Got The xml In The Current Directory this will fail and cause the app to crash");
                        Directory.CreateDirectory("Meshes");
                        Directory.CreateDirectory("Meshes\\actors");
                        Directory.CreateDirectory("Meshes\\actors\\character");
                        Directory.CreateDirectory("Meshes\\actors\\character\\animations");
                        Directory.CreateDirectory("Meshes\\actors\\character\\behaviors");
                        Directory.CreateDirectory("Meshes\\actors\\character\\characters");
                        Directory.CreateDirectory("Meshes\\actors\\character\\characters female");
                        if (File.Exists("xml\\0_master.hkx"))
                        {
                            File.Move("xml\\0_master.hkx", "Meshes\\actors\\character\\behaviors\\0_master.hkx");
                        }
                        else if (File.Exists("xml\\1hm_behavior_PATCHED.hkx"))
                        {
                            File.Move("xml\\1hm_behavior_PATCHED.hkx", "Meshes\\actors\\character\\behaviors\\1hm_behavior.hkx");
                        }
                        else if (File.Exists("xml\\1hm_locomotion.hkx"))
                        {
                            File.Move("xml\\1hm_locomotion.hkx", "Meshes\\actors\\character\\behaviors\\1hm_locomotion.hkx");
                        }
                        else if (File.Exists("xml\\bashbehavior.hkx"))
                        {
                            File.Move("xml\\bashbehavior.hkx", "Meshes\\actors\\character\\behaviors\\bashbehavior.hkx");
                        }
                        ///
                        else if (File.Exists("xml\\blockbehavior.hkx"))
                        {
                            File.Move("xml\\blockbehavior.hkx", "Meshes\\actors\\character\\behaviors\\blockbehavior.hkx");
                        }
                        else if (File.Exists("xml\\bow_direction_behavior.hkx"))
                        {
                            File.Move("xml\\bow_direction_behavior.hkx", "Meshes\\actors\\character\\behaviors\\bow_direction_behavior.hkx");
                        }
                        else if (File.Exists("xml\\FNIS_FNISBase_Behavior.hkx"))
                        {
                            File.Move("xml\\FNIS_FNISBase_Behavior.hkx", "Meshes\\actors\\character\\behaviors\\FNIS_FNISBase_Behavior.hkx");
                        }
                        else if (File.Exists("xml\\idlebehavior_PATCHED.hkx"))
                        {
                            File.Move("xml\\idlebehavior_PATCHED.hkx", "Meshes\\actors\\character\\behaviors\\idlebehavior.hkx");
                        }
                        else if (File.Exists("xml\\magic_readied_direction_behavior.hkx"))
                        {
                            File.Move("xml\\magic_readied_direction_behavior.hkx", "Meshes\\actors\\character\\behaviors\\magic_readied_direction_behavior.hkx");
                        }
                        else if (File.Exists("xml\\magicbehavior.hkx"))
                        {
                            File.Move("xml\\magicbehavior.hkx", "Meshes\\actors\\character\\behaviors\\magicbehavior.hkx");
                        }
                        else if (File.Exists("xml\\magicmountedbehavior.hkx"))
                        {
                            File.Move("xml\\magicmountedbehavior.hkx", "Meshes\\actors\\character\\behaviors\\magicmountedbehavior.hkx");
                        }
                        else if (File.Exists("xml\\mt_behavior.hkx"))
                        {
                            File.Move("xml\\mt_behavior.hkx", "Meshes\\actors\\character\\behaviors\\mt_behavior.hkx");
                        }
                        else if (File.Exists("xml\\shout_behavior.hkx"))
                        {
                            File.Move("xml\\shout_behavior.hkx", "Meshes\\actors\\character\\behaviors\\shout_behavior.hkx");
                        }
                        else if (File.Exists("xml\\sprintbehavior.hkx"))
                        {
                            File.Move("xml\\sprintbehavior.hkx", "Meshes\\actors\\character\\behaviors\\sprintbehavior.hkx");
                        }
                        else if (File.Exists("xml\\staggerbehavior.hkx"))
                        {
                            File.Move("xml\\staggerbehavior.hkx", "Meshes\\actors\\character\\behaviors\\staggerbehavior.hkx");
                        }
                        else if (File.Exists("xml\\weapequip.hkx"))
                        {
                            File.Move("xml\\weapequip.hkx", "Meshes\\actors\\character\\behaviors\\weapequip.hkx");
                        }
                        ///
                        else if (File.Exists("xml\\defaultmale.hkx"))
                        {
                            File.Move("xml\\defaultmale.hkx", "Meshes\\actors\\character\\characters\\defaultmale.hkx");
                        }
                        else if (File.Exists("xml\\defaultfemale.hkx"))
                        {
                            File.Move("xml\\defaultfemale.hkx", "Meshes\\actors\\character\\characters female\\defaultfemale.hkx");
                        }
                        else if (File.Exists("xml\\1hm_behavior.hkx"))
                        {
                            File.Move("xml\\1hm_behavior.hkx", "Meshes\\actors\\character\\behaviors\\1hm_behavior.hkx");
                        }
                    }
                }

                /// this checks to see if they are all done converting
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    /// this is going to show the messege box
                    MessageBox.Show("Your Animation(s) are converted!", "Finished!");
                    filePaths.Clear();
                    lboxFiles.Items.Clear();
                    label1.Text = "Add More To Convert";
                    progressBar1.Value = 0;
                    Directory.Delete("hkx");
                    F4.Checked = false;
                    SK.Checked = false;
                    SK_Upgrade.Checked = false;
                }
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists("hkx"))
            {
                Directory.Delete("hkx");
            }
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp");
            }
        }

        private void F4_CheckedChanged(object sender, EventArgs e)
        {
            if (F4.Checked)
            {
                SK.Checked = false;
                SK_Upgrade.Checked = false;
            }
        }

        private void SK_CheckedChanged(object sender, EventArgs e)
        {
            if (SK.Checked)
            {
                SK_Upgrade.Checked = false;
                F4.Checked = false;
            }
        }

        private void SK_Upgrade_CheckedChanged(object sender, EventArgs e)
        {
            if (SK_Upgrade.Checked)
            {
                F4.Checked = false;
                SK.Checked = false;
            }
        }
    }
}