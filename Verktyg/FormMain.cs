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
using System.Threading;

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
            RecordWhitelog(System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"),false);
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
                this.BeginInvoke(new InvokeLogWithColor(RecordColorLog), new object[] { text, color, medEntertecken });
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
                Log("Folder[" + dirinfo.FullName + "]");
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
                LibreOfficeParameter librparam = this.GetLibreOfficeParamter();
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
        private void CreateBatchSub(LibreOfficeParameter librparam)
        {
            CheckDirectoryIsExists(librparam.OriginalDirectory, true);
            CheckDirectoryIsExists(librparam.OutputDirectory, true);
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
                    LibreOfficeParameter libreparamSub = (LibreOfficeParameter)librparam.Clone();
                    libreparamSub.OriginalDirectory = dir.FullName;
                    libreparamSub.OutputDirectory += "\\" + dir.Name;
                    CreateBatchSub(libreparamSub);

                }
            }

        }

        private string GetCommand(LibreOfficeParameter librparam, string originalFileName)
        {
            string command = "\"";
            command += librparam.Path + "\" ";
            command += librparam.Command + " ";
            command += librparam.OutputFileExtension + " ";
            command += "\"" + originalFileName + "\" ";
            command += " --outdir \""  + librparam.OutputDirectory + "\"";
            return command;
        }

        private LibreOfficeParameter GetLibreOfficeParamter()
        {
            LibreOfficeParameter libreparam = new LibreOfficeParameter();
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
        private bool CheckLibreOfficeParamter(LibreOfficeParameter libreparam)
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

        private async void Button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("UI button begin. " + System.DateTime.Now.ToLongTimeString());
            Log("UI button begin. " + System.DateTime.Now.ToLongTimeString());
            Task t = Task.Run(() => doSomething(5));
            await t;
            Console.WriteLine("UI button end. " + System.DateTime.Now.ToLongTimeString());
            Log("UI button end. " + System.DateTime.Now.ToLongTimeString());

        }
        private void doSomething(int number)
        {
            Console.WriteLine("doSomething begin. " + System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"));
            Log("doSomething begin. " + System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"));
            Thread.Sleep(2000);
            Console.WriteLine("doSomething end. " + System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"));
            Log("doSomething end. " + System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"));

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

        private void SetOriginalDir2_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOriginalDir2.Text = this.openFold.SelectedPath;
            }
        }

        private void BtnSetOutput2_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOriginalDir2.Text = this.openFold.SelectedPath;
            }
        }

        private async void BtnCheck_Click(object sender, EventArgs e)
        {
            await CheckFile();
        }

        private Task CheckFile()
        {
            Task t = Task.Run(() => CheckFileThread());
            return t;
        }
        private void CheckFileThread()
        {
            CheckFileParameter paramCheckFile = GetCheckFileParameter();
            if (!PathCheck(paramCheckFile)) { return; }
            Log("Valid\tOriginal Size\tOouput Size\tOriginal Extension\tOutput Extension\tOriginal FileName\tOriginal Path\tDestination FileName\tDestination Path");
            CheckFileThreadSub(paramCheckFile);
        }
        private bool CheckDirectoryIsExists(string path,bool isCreate) {
            if(System.IO.File.Exists(path)) { return true; }
            else
            {
                if (isCreate)
                {
                    System.IO.Directory.CreateDirectory(path);
                    if (System.IO.File.Exists(path)) { return true; }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
        }
        private void CheckFileThreadSub(CheckFileParameter param)
        {
            CheckDirectoryIsExists(param.OriginalDirectory,true);
            CheckDirectoryIsExists(param.OutputDirectory,true);

            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutputDirectory);
            

            var originalfiles = originalFold.GetFiles();
            var destinationfiles = destinationFold.GetFiles();
            List<CheckResult> listCheckResult = new List<CheckResult>();

            // Check Original First
            foreach (FileInfo file in originalfiles)
            {
                CheckResult checkresult = new CheckResult();
                checkresult.OriginalExtension = Path.GetExtension(file.Name);
                checkresult.OriginalFileSize = file.Length;
                checkresult.OriginalFileNameWithExtension = Path.GetFileNameWithoutExtension(file.Name);
                checkresult.OriginalPath = file.Directory.FullName;
                FileInfo outputFile;
                try
                {
                    outputFile = destinationfiles.First(f => Path.GetFileNameWithoutExtension(f.Name)==Path.GetFileNameWithoutExtension(file.Name));
                    if (outputFile != null)
                    {
                        checkresult.DestinationExtension = Path.GetExtension(outputFile.Name);
                        checkresult.DestinationFileSize = outputFile.Length;
                        checkresult.DestinationFileNameWithExtension = Path.GetFileNameWithoutExtension(outputFile.Name);
                        checkresult.DestinationPath = outputFile.Directory.FullName;

                    }
                }
                catch(Exception ex)
                {

                }

                listCheckResult.Add(checkresult);
            }
            //check destination
            foreach (FileInfo file in destinationfiles)
            {
                CheckResult checkresult;
                try
                {
                    checkresult = listCheckResult.First(f =>
                    {
                        return (f.DestinationFileNameWithExtension == Path.GetFileNameWithoutExtension(file.Name)) && (f.DestinationExtension == Path.GetExtension(file.Name));
                    });
                    if (checkresult == null)
                    {
                        // Destination is more than original
                        listCheckResult.Add(GetDestinationCheckResult(file));
                    }
                }
                catch (Exception ex)
                {
                    listCheckResult.Add(GetDestinationCheckResult(file));
                }
                
            }
            LogCheckResult(listCheckResult);
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                CheckFileParameter paramSub = (CheckFileParameter)param.Clone();
                paramSub.OriginalDirectory = dir.FullName;
                paramSub.OutputDirectory += "\\" + dir.Name;
                CheckFileThreadSub(paramSub);
            }

        }
        private CheckResult GetDestinationCheckResult(FileInfo file)
        {
            CheckResult checkresult = new CheckResult();
            checkresult.DestinationExtension = Path.GetExtension(file.Name);
            checkresult.DestinationFileSize = file.Length;
            checkresult.DestinationFileNameWithExtension = Path.GetFileNameWithoutExtension(file.Name);
            checkresult.DestinationPath = file.Directory.FullName;
            return checkresult;
        }
        private void LogCheckResult(List<CheckResult> list)
        {
            foreach(CheckResult result in list)
            {
                LogCheckResult(result);
            }
        }
        private void LogCheckResult(CheckResult result)
        {
            if (result != null)
            {
                //Log((result.isValid ? "OK" : "No") + "\t"  + result.OriginalFileSize.ToString("F2") + "KB" + "\t" + result.DestinationFileSize.ToString("F2") + "KB" + "\t" + result.OriginalExtension  + "\t" + result.DestinationExtension + "\t" + result.OriginalFileNameWithExtension + "\t" + result.DestinationPath);
                if (result.isValid)
                {
                    RecordWhitelog("OK", false);
                }
                else
                {
                    RecordRedlog("No", false);
                }

                RecordWhitelog("\t", false);
                RecordWhitelog(GetByteDescription(result.OriginalFileSize), false);

                RecordWhitelog("\t", false);
                RecordWhitelog(GetByteDescription(result.DestinationFileSize), false);

                RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    RecordWhitelog(result.OriginalExtension, false);
                }else
                {
                    RecordRedlog(result.OriginalExtension, false);
                }

                RecordWhitelog("\t", false);
                if (result.isValid)
                { RecordWhitelog(result.DestinationExtension, false);  }
                else
                { RecordBluelog(result.DestinationExtension, false); }

                RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    RecordWhitelog(result.OriginalFileNameWithExtension, false);
                }
                else
                {
                    RecordRedlog(result.OriginalFileNameWithExtension, false);
                }


                RecordWhitelog("\t", false);
                if (result.isValid)
                { RecordWhitelog(result.OriginalPath, false); }
                else
                { RecordRedlog(result.OriginalPath, false); }

                RecordWhitelog("\t", false);
                if (result.isValid)
                {
                    RecordWhitelog(result.DestinationFileNameWithExtension, false);
                }
                else
                {
                    RecordBluelog(result.DestinationFileNameWithExtension, false);
                }


                RecordWhitelog("\t", false);
                if (result.isValid)
                { RecordWhitelog(result.DestinationPath, false); }
                else
                { RecordBluelog(result.DestinationPath, false); }

                RecordWhitelog("", true);
            }
        }
        private string GetByteDescription(long length)
        {
            string rtn = "";
            if (length < 1024)
            {
                rtn = length.ToString("N0") + "B";
            }else if (length < 1024 * 1024)
            {
                rtn = (length / 1024).ToString("N1") + "KB";
            }
            else if (length < 1024 * 1024* 1024)
            {
                rtn = (length / (1024*1024)).ToString("N1") + "MB";
            }
            else 
            {
                rtn = (length / (1024 * 1024 * 1024)).ToString("N1") + "GB";
            }
            return rtn;
        }
        private CheckFileParameter GetCheckFileParameter()
        {
            CheckFileParameter param = new CheckFileParameter();
            param.OriginalDirectory = this.txtOriginalDir2.Text.Trim();
            param.OutputDirectory = this.txtOutputDir2.Text.Trim();
            return param;

        }
        private bool PathCheck(CheckFileParameter param)
        {
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            DirectoryInfo destinationFold = new DirectoryInfo(param.OutputDirectory);
            if (!originalFold.Exists) { Log("Original Path is not exists."); return false; }
            if (!destinationFold.Exists) { Log("Destination Path is not exists."); return false; }
            return true;
        }
    }

    public class CheckFileParameter : ICloneable
    {
        public string OriginalDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public CheckFileParameter() {
            OriginalDirectory = "";
            OutputDirectory = "";
        }
    }
    public class CheckResult
    {
        public long OriginalFileSize { get; set; }
        public long DestinationFileSize { get; set; }

        public string OriginalPath { get; set; }
        public string DestinationPath { get; set; }
        public string OriginalExtension { get; set; }
        public string DestinationExtension { get; set; }
        public string OriginalFileNameWithExtension { get; set; }
        public string DestinationFileNameWithExtension { get; set; }
        public bool isValid {
                get
                {
                    return OriginalFileNameWithExtension == DestinationFileNameWithExtension ? true : false;
                }
            }
        public CheckResult()
        {
            OriginalPath = "";
            DestinationPath = "";
            OriginalExtension = "";
            DestinationExtension = "";
            OriginalFileNameWithExtension = "";
            DestinationFileNameWithExtension = "";
        }
    }
    public class LibreOfficeParameter: ICloneable
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



        public LibreOfficeParameter()
        {
            Path = "";
            Command = "";
            OutputFileExtension = "";
            OriginalDirectory = "";
            OutputDirectory = "";
            OriginalExtesnsion = "";
            IsincludSubfolder = false;
            Isoverwrite = false;
        }

    }
}

