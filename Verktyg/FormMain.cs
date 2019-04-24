using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace Verktyg
{
    public partial class FormMain : Form
    {
        private delegate void SafeCallDelegateLog(string text);
        private delegate void SafeCallDelegateDeleteLog(int line);
        public delegate void InvokeLogWithoutColor(string text, bool medEnterteck);
        public delegate void InvokeLogWithColor(string text, System.Drawing.Color color, bool medEnterteck);
        
        private const string ConstContinueing = "Continueing...\r\n";
        List<string> commandList = new List<string>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnSetOriginal_Click(object sender, EventArgs e)
        {
            SetRiginalFold();
        }

        private void BtnSetDestination_Click(object sender, EventArgs e)
        {
            SetDestinationFold();
        }


        private void SetRiginalFold()
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                SetOriginalFold(openFold.SelectedPath);
            }
        }
        private void SetDestinationFold()
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                SetDestinationFold(openFold.SelectedPath);
            }
        }
        private DialogResult OpenFoldDialog()
        {
            DialogResult dr = openFold.ShowDialog();
            return dr;

        }
        private DialogResult OpenFileDialog()
        {
            DialogResult dr = openFile.ShowDialog();
            return dr;

        }

        private void SetOriginalFold(string dirPath)
        {
            this.lbOriginal.Text = dirPath;
        }

        private void SetDestinationFold(string dirPath)
        {
            this.lbDestination.Text = dirPath;
        }



        private void CopyFolder()
        {
            DirectoryInfo originalFold = new DirectoryInfo(this.lbOriginal.Text);
            DirectoryInfo destinationFold = new DirectoryInfo(this.lbDestination.Text);

            if (!originalFold.Exists) { return; }
            if (!destinationFold.Exists) { return; }
            Task.Run(() => CreateFolder(originalFold.FullName, destinationFold.FullName));

        }

        private void BtnDeleteAllFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                DeleteAllfiles(openFold.SelectedPath);
            }
        }
        private void CreateFolder(string originalFoldName, string destinationFoldName)
        {
            DirectoryInfo originalFold = new DirectoryInfo(originalFoldName);
            DirectoryInfo destinationFold = new DirectoryInfo(destinationFoldName);
            Log(originalFold.Name + "\t" + originalFold.GetFiles().Length.ToString() + "\t" + originalFold.FullName + "\r\n");


            if (!System.IO.Directory.Exists(destinationFoldName + "\\" + originalFold.Name))
            {
                System.IO.Directory.CreateDirectory(destinationFoldName + "\\" + originalFold.Name);
            }
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                CreateFolder(dir.FullName, destinationFoldName + "\\" + originalFold.Name);
            }
        }


        private void Log(string text)
        {
            RecordWhitelog(text, true);
        }
        private void LogContinue()
        {
            RecordRedlog(ConstContinueing, false);
        }

        private void DeleteLog(int line)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegateDeleteLog(DeleteLog);
                Invoke(d, new object[] { line });
            }
            else
            {
                if (line > 0)
                {
                    int enter = this.richTextBox1.Text.LastIndexOf("\n");
                    while ((enter >= 0)&&(line>0)) {
                        this.richTextBox1.Text = this.richTextBox1.Text.Remove(enter);
                        line -= 1;
                        enter = this.richTextBox1.Text.LastIndexOf("\n");
                    }
                }
                Log("");
            }
        }
        //private void Recordlog(string text, bool medEntertecken)
        //{
            
        //}
        private void Recordlogutanbreak(string text, bool medEntertecken)
        {
            RecordColorLog(text, System.Drawing.Color.Black, medEntertecken);
        }
        private void RecordError(string text)
        {
            RecordRedlog(text);
        }
        private void RecordError(string text, bool medEntertecken)
        {
            RecordRedlog(text, medEntertecken);
        }
        private void RecordRedlog(string text)
        {
            RecordColorLog(text, System.Drawing.Color.Red, false);
        }
        private void RecordRedlog(string text, bool medEntertecken)
        {
            RecordColorLog(text, System.Drawing.Color.Red, medEntertecken);
        }
        private void RecordBluelog(string text)
        {
            RecordColorLog(text, System.Drawing.Color.Blue, false);
        }
        private void RecordBluelog(string text, bool medEntertecken)
        {
            RecordColorLog(text, System.Drawing.Color.Blue, medEntertecken);
        }
        private void RecordGreenlog(string text)
        {
            RecordColorLog(text, System.Drawing.Color.Green, false);
        }
        private void RecordWhitelog(string text)
        {
            RecordColorLog(text, System.Drawing.Color.White, false);
        }
        private void RecordWhitelog(string text, bool medEntertecken)
        {
            RecordColorLog(text, System.Drawing.Color.White, medEntertecken);
        }
        private void RecordGreenlog(string text, bool medEntertecken)
        {
            RecordColorLog(text, System.Drawing.Color.Green, medEntertecken);
        }
        private void RecordColorLog(string text, System.Drawing.Color color, bool medEntertecken)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                this.Invoke(new InvokeLogWithColor(RecordColorLog), new object[] { text, color, medEntertecken });
            }
            else
            {
                int start, len;
                if (this.richTextBox1.Text == null)
                {
                    this.richTextBox1.Text = "";
                }

                start = this.richTextBox1.TextLength;
                len = text.Length;
                this.richTextBox1.AppendText(text);
                this.richTextBox1.Select(start, len);
                this.richTextBox1.SelectionColor = color;
                if (medEntertecken)
                {
                    this.richTextBox1.AppendText("\r\n");
                }
            }
        }

        private void BtnCopyFolder_Click(object sender, EventArgs e)
        {
            CopyFolder();
        }

        private void DeleteAllfiles(string Dir)
        {
            DirectoryInfo originalFold = new DirectoryInfo(Dir);
            if (!originalFold.Exists) { return; }
            foreach (FileInfo file in originalFold.GetFiles())
            {
                try
                {
                    //System.IO.File.Delete(file.FullName);
                    file.Delete();
                    Log(file.FullName + " is deleted.");
                }
                catch (Exception ex)
                {
                    Log(" Not delete the file[" + file.FullName + "]");
                }
            }
            foreach (DirectoryInfo dirinfo in originalFold.GetDirectories())
            {
                Log("Mapp[" + dirinfo.FullName + "]");
                Task.Run(() => DeleteAllfiles(dirinfo.FullName));
            }


        }

        private void BtnSetLibreOffice_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFileDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtLibrePath.Text = this.openFile.FileName;
            }
        }

        private void SetOriginalDir_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOriginalDir.Text = this.openFold.SelectedPath;
            }       
        }

        private void BtnSetOutput_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOutputDir.Text = this.openFold.SelectedPath;
            }
        }

        private Task CreateBatch()
        {
            var t = Task.Run(() =>
            {
                LibreOfficeParamter librparam = this.GetLibreOfficeParamter();
                if (!CheckLibreOfficeParamter(librparam)) { return; }

                commandList.Clear();
                Log("Begin converting.");
                Log("Time\t\tFileName");
                CreateBatchSub(librparam);


                FileInfo finfo = new FileInfo(this.txtBatchFilePath.Text.Trim());

                if (!System.IO.Directory.Exists(finfo.DirectoryName))
                {
                    System.IO.Directory.CreateDirectory(finfo.DirectoryName);
                }
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(this.txtBatchFilePath.Text.Trim(), false))
                {
                    foreach (string line in commandList)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file.

                        file.WriteLine(line);

                    }
                }
                //DeleteLog(2);
                RecordGreenlog("Finished!",true);
            });
            return t;


        }
        private void CreateBatchSub(LibreOfficeParamter librparam)
        {
            DirectoryInfo originalFold = new DirectoryInfo(librparam.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(librparam.OutputDirectory);
            if (!originalFold.Exists) { return; }
            if (!destinationFold.Exists) { return; }


            var files = originalFold.GetFiles().Where(s => {
                bool rtn = false;
                var extensionlist = librparam.OriginalExtesnsion.Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
                //s.Name.EndsWith(".exe") || s.Name.EndsWith(".doc") || s.Name.EndsWith(".docx")
            }
            );

            foreach (FileInfo file in files)
            {
                try
                {

                    string temp = GetCommand(librparam, file.FullName);
                    commandList.Add(temp);
                    DateTime dtStart = System.DateTime.Now;
                    Log("Convert file [" + file.FullName + "]");
                    LogContinue();
                    bool isNeedConvert = true;
                    if(!librparam.Isoverwrite) {
                        if(System.IO.File.Exists(librparam.OutputDirectory + "\\" + Path.GetFileNameWithoutExtension(file.FullName) + "." + librparam.OutputFileExtension))
                        {
                            isNeedConvert = false;
                        }
                    }
                    if (isNeedConvert) { 
                        Process pr = new Process();//声明一个进程类对象
                        pr.StartInfo.FileName = "\"" + librparam.Path + "\"";
                        pr.StartInfo.Arguments = " " + librparam.Command + " " + librparam.OutputFileExtension + " " +  "\"" + file.FullName + "\" " + " --outdir \"" + librparam.OutputDirectory + "\"";
                        pr.Start();
                        pr.WaitForExit();
                    }
                    
                    DateTime dtEnd = System.DateTime.Now;
                    
                    DeleteLog(3);
                    Log((dtEnd - dtStart).TotalSeconds.ToString("F0") + "s" + (isNeedConvert? "": "(N)") + "\t\t" + file.FullName);


                }
                catch (Exception ex)
                {
                    Log("error:" + ex.Message);
                }
            }
            if (librparam.IsincludSubfolder)
            {
                foreach (DirectoryInfo dir in originalFold.GetDirectories())
                {
                    LibreOfficeParamter libreparamSub = (LibreOfficeParamter)librparam.Clone();
                    libreparamSub.OriginalDirectory = dir.FullName;
                    libreparamSub.OutputDirectory += "\\" + dir.Name;
                    CreateBatchSub(libreparamSub);

                }
            }

        }

        private string GetCommand(LibreOfficeParamter librparam, string originalFileName)
        {
            string command = "\"";
            command += librparam.Path + "\" ";
            command += librparam.Command + " ";
            command += librparam.OutputFileExtension + " ";
            command += "\"" + originalFileName + "\" ";
            command += " --outdir \""  + librparam.OutputDirectory + "\"";
            return command;
        }

        private LibreOfficeParamter GetLibreOfficeParamter()
        {
            LibreOfficeParamter libreparam = new LibreOfficeParamter();
            libreparam.Path = this.txtLibrePath.Text.Trim();
            libreparam.IsincludSubfolder = this.ckbSubfolder.Checked;
            libreparam.Command = this.txtCommand.Text.Trim();
            libreparam.OriginalDirectory = this.txtOriginalDir.Text.Trim();
            libreparam.OutputDirectory = this.txtOutputDir.Text.Trim();
            libreparam.OriginalExtesnsion = this.txtOriginalExtension.Text.Trim();
            libreparam.OutputFileExtension = this.txtOutputFileExtension.Text.Trim();
            libreparam.Isoverwrite = this.ckboverwrite.Checked;
            return libreparam;
        }

        private string  GetBatchFilePath()
        {
            return this.txtBatchFilePath.Text.Trim();
        }
        private bool CheckLibreOfficeParamter(LibreOfficeParamter libreparam)
        {
            bool rtn = false;
            if (!System.IO.File.Exists(libreparam.Path)) {
                Log("LibeOffice is not exists.");
                return rtn;
            }
            if (!System.IO.Directory.Exists(libreparam.OriginalDirectory)) {
                Log("OriginalDirectory is not exists.");
                return rtn;
            }
            if (!System.IO.Directory.Exists(libreparam.OutputDirectory)) {
                Log("OutputDirectory is not exists.");
                return rtn;
            }
            switch (libreparam.OutputFileExtension)
            {
                case "pdf":
                    break;
                default:
                    Log("OutputFileExtension[" + libreparam.OutputFileExtension + "] is not supported");
                    return rtn;
                    // break;
            }
            foreach(var extension in libreparam.OriginalExtesnsion.Split(';')) { 
                switch (extension)
                {
                    #region word
                    case "docx":
                        break;
                    case "doc":
                        break;
                    case "docm":
                        break;
                    case "dot":
                        break;
                    case "dotm":
                        break;
                    case "dotx":
                        break;
                    #endregion word
                    #region Excel
                    case "xlsx":
                        break;
                    case "xls":
                        break;
                    case "xlsb":
                        break;
                    case "xlsm":
                        break;
                    case "xltx":
                        break;
                    #endregion Excel
                    #region RichText
                    case "rtf":
                        break;
                    #endregion RichText
                    #region  PowerPoint
                    case "potm":
                        break;
                    case "potx":
                        break;
                    case "pps":
                        break;
                    case "ppsm":
                        break;
                    case "ppsx":
                        break;
                    case "ppt":
                        break;
                    case "pptm":
                        break;
                    case "pptx":
                        break;
                    #endregion PowerPoint
                    #region  PDF
                    case "pdf":
                        break;
                    #endregion PDF
                    default:
                        Log("OriginalExtesnsion[" + extension + "] is not supported");
                        return rtn;
                        // break;
                }
            }
            return true;
            
        }

        private async void BtnCreateBatchFile_Click(object sender, EventArgs e)
        {
            await CreateBatch();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RecordBluelog("converting is started",true);


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //DeleteLog(2);
            //var files = System.IO.Directory.GetFiles("c:\\test").Where(s => s.EndsWith(".exe") || s.EndsWith(".txt") || s.EndsWith(".doc"));


            //foreach (string f in files)
            //{
            //    Log(f);
            //}
            //string extensions = "doc;docx;xls;xlsx;txt;exe";
            //DirectoryInfo originalFold = new DirectoryInfo("c:\\test");
            //var files2 = originalFold.GetFiles().Where(s => {
            //    bool rtn = false;
            //    var extensionlist = extensions.Split(';');
            //    foreach(string item in extensionlist)
            //    {
            //        rtn = rtn || s.Name.EndsWith("." + item);
            //    }

            //    return rtn;
            //    //s.Name.EndsWith(".exe") || s.Name.EndsWith(".doc") || s.Name.EndsWith(".docx")
            //    }
            //);
            //foreach (FileInfo f in files2)
            //{
            //    Log(f.FullName);
            //}
            string ckbname = "button2";
            Type type = this.GetType();
            BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo info = type.GetField(ckbname, flag);
            if (info != null) { 
                ((Button)(info.GetValue(this))).Text = "kl";
            }
            //foreach(var inf in type.GetFields())
            //{
            //    Log(inf.Name);
            //}
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FormSetting f = new FormSetting();
            f.InitialExtensions(this.txtOriginalExtension.Text);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtOriginalExtension.Text = f.GetExtensions();
            }
        }
    }


    public class LibreOfficeParamter: ICloneable
    {
        public string Path { get; set; }
        public string Command { get; set; }
        public string OutputFileExtension { get; set; }
        public string OriginalDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string OriginalExtesnsion { get; set; }
        public bool IsincludSubfolder { get; set; }
        public bool Isoverwrite { get; set; }

        public  object Clone()
        {
            return this.MemberwiseClone();
        }
       
        

        //public LibreOfficeParamter()
        //{
        //    Path = "";
        //    Command = "";
        //    OutputFileExtension = "";
        //    OriginalDirectory = "";
        //    OutputDirectory = "";
        //    OriginalExtesnsion = "";
        //    IsincludSubfolder = false;
        //}

    }
}

