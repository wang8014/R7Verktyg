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
        #region  variable
        private delegate void SafeCallDelegateLog(string text);
        private delegate void SafeCallDelegateDeleteLog(int line);
        public delegate void InvokeLogWithoutColor(string text, bool medEnterteck);
        public delegate void InvokeLogWithColor(string text, System.Drawing.Color color, bool medEnterteck);
        public delegate void SetbuttonStatus(bool flag);
        
        private const string ConstContinueing = "Continueing...\r\n";

        private Task task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private int CheckNumber = 0;
        private CancellationToken token;
        List<string> commandList = new List<string>();
        #endregion 
        public FormMain()
        {
            InitializeComponent();
            token = tokenSource.Token;
        }

        #region Test

        private async void Button2_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            task = Task.Run(() => doSomething(200),token);
            try { 
                await task;
            }
            catch (Exception ex)
            {
                Log("task isCanceled:" + task.IsCanceled.ToString());
                Log("task isCompleted" + task.IsCompleted.ToString());
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //RecordBluelog("converting is started", true);
            tokenSource.Cancel();
            while (!task.IsCompleted) { 
                Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " task isCanceled:" + task.IsCanceled.ToString());
                Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " task isCompleted:" + task.IsCompleted.ToString());
            }


        }
        private void doSomething(int number)
        {
            token.ThrowIfCancellationRequested();
            for (int i = 1; i < number; i++)
            {
                Thread.Sleep(5000);
                if (token.IsCancellationRequested)
                {
                    // Clean up here, then...
                    token.ThrowIfCancellationRequested();
                }
                Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " loop " + i.ToString());
            }

        }

        #endregion test

        #region Folder Operation
        #region Button Click 
        private void BtnSetOriginal_Click(object sender, EventArgs e)
        {
            SetRiginalFold();
        }

        private void BtnSetDestination_Click(object sender, EventArgs e)
        {
            SetDestinationFold();
        }
        private async void BtnDeleteAllFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                await DeleteAllfiles(openFold.SelectedPath);
            }
        }
        private async void BtnCopyFolder_Click(object sender, EventArgs e)
        {
            try
            {
                await CopyFolder();
            }
            catch (Exception ex){
            }
        }
        #endregion Button Click
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

        #region Threading function
        private Task CopyFolder()
        {
            task = Task.Run(()=> { 
                DirectoryInfo originalFold = new DirectoryInfo(this.lbOriginal.Text);
                DirectoryInfo destinationFold = new DirectoryInfo(this.lbDestination.Text);

                if (!originalFold.Exists) { return; }
                if (!destinationFold.Exists) { return; }
                CreateFolder(originalFold.FullName, destinationFold.FullName);
            });
            return task;
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
        private Task DeleteAllfiles(string Dir)
        {
            task = Task.Run(() =>
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
            });
            return task;

        }
        #endregion Threading function
        #endregion Folder Operation


        #region LibreOffice Convert
        #region Buttion Click
        private void btnSetOriginalDir_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOriginalDir.Text = this.openFold.SelectedPath;
            }
        }
        private void btnSetExtensions_Click(object sender, EventArgs e)
        {
            FormSetting f = new FormSetting();
            f.InitialExtensions(this.txtOriginalExtension.Text);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtOriginalExtension.Text = f.GetExtensions();
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
        private void BtnSetOutput_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtOutputDir.Text = this.openFold.SelectedPath;
            }
        }
        private async void BtnCreateBatchFile_Click(object sender, EventArgs e)
        {
            try
            {
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                this.SetLibreOfficeButtonStatus(false);
                await CreateBatch();
            }
            catch(Exception ex)
            {

            }
            finally{
                this.BeginInvoke(new SetbuttonStatus(SetLibreOfficeButtonStatus), new object[] { true });

            }
        }

        private void BtnCancelConverting_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetCheckFileButtonStatus(true); }
            //while (!task.IsCompleted)
            //{
            //    Thread.Sleep(500);
            //}
            //task.Wait();

        }
        #endregion Buttion Click

        #region thread function
        private Task CreateBatch()
        {
            task = Task.Run(() =>
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
            return task;


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
                    if (token.IsCancellationRequested)
                    {
                        // Clean up here, then...
                        DeleteLog(3);
                        RecordRedlog("Task is canceled.");
                        this.BeginInvoke(new SetbuttonStatus(SetLibreOfficeButtonStatus), new object[] { true });
                        token.ThrowIfCancellationRequested();
                    }
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
                        
                        DateTime dtConvertStart = System.DateTime.Now;
                        Console.WriteLine("LibreOffice Process is finished");
                        while (!System.IO.File.Exists(librparam.OutputDirectory + "\\" + Path.GetFileNameWithoutExtension(file.Name) + "." + librparam.OutputFileExtension)) {
                            Console.WriteLine(librparam.OutputFileExtension + " is not created");
                            Thread.Sleep(100);
                        }
                        DateTime dtConvertEnd = System.DateTime.Now;
                        Console.WriteLine("wait for tbe pdf file time: " + (dtConvertEnd - dtConvertStart).TotalSeconds.ToString("F0") + "s");
                    }
                    
                    DateTime dtEnd = System.DateTime.Now;
                    
                    DeleteLog(3);
                    Log((dtEnd - dtStart).TotalSeconds.ToString("F0") + "s" + (isNeedConvert? "": "(N)") + "\t\t" + file.FullName);


                }
                catch(System.OperationCanceledException ex)
                {
                    // Cancel Task
                    throw ex; 
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
        #endregion Thread function
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

        #region Button Status controll
        /// <summary>
        /// Set LibreOffice converting buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetLibreOfficeButtonStatus(bool isEnabled)
        {
            this.btnSetLibreOffice.Enabled = isEnabled;
            this.btnSetExtensions.Enabled = isEnabled;
            this.btnSetOriginalDir.Enabled = isEnabled;
            this.btnSetOutput.Enabled = isEnabled;
            this.btnCreateBatchFile.Enabled = isEnabled;
            this.btnCancelConverting.Enabled = !isEnabled;
        }

        #endregion
        #endregion LibreOffice Convert

        #region Name Conflict
        #region Button Click
        private void BtnConflict_SetExtension_Click(object sender, EventArgs e)
        {
            FormSetting f = new FormSetting();
            f.InitialExtensions(this.txtConflict_OriginalFileExtension.Text);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtConflict_OriginalFileExtension.Text = f.GetExtensions();
            }
        }
        private async void BtnConflict_Analyze_Click(object sender, EventArgs e)
        {
            try
            {
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                SetNameConflictButtonStatus(false);
                await AnalyzeNameConflict();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.BeginInvoke(new SetbuttonStatus(SetNameConflictButtonStatus), new object[] { true });
            }
        }

        private void BtnConflict_CancelAnalysis_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetNameConflictButtonStatus(true); }
        }
        private void BtnConflict_SetOriginalDir_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtConflict_OriginalDir.Text = this.openFold.SelectedPath;
            }
        }
        #endregion Buttoon Click

        #region Threading Function
        private Task AnalyzeNameConflict()
        {
            task = Task.Run(() => AnalyzeNameConflictThread());
            return task;
        }
        private void AnalyzeNameConflictThread()
        {
            CheckNumber = 0;
            NameConflictParameter param = GetNameConflictParameter();
            if (!NameConflictPathCheck(param)) { return; }
            Log("FileName\tPath\tConflict Files");
            AnalyzeNameConflictThreadSub(param);
            RecordGreenlog("Finished!", true);
        }
        private void AnalyzeNameConflictThreadSub(NameConflictParameter param)
        {
            //NameConflictPathCheck(param.OriginalDirectory);
            
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            Log("Analyzing [" + originalFold.FullName + "]");

            var originalfiles = originalFold.GetFiles().Where(s => {
                bool rtn = false;
                var extensionlist = param.OriginalExtension.Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
                //s.Name.EndsWith(".exe") || s.Name.EndsWith(".doc") || s.Name.EndsWith(".docx")
            }
            );
            List<NameConflictResult> listNameConflictResult = new List<NameConflictResult>();
            IEnumerable<FileInfo> ListAllFile = (IEnumerable<FileInfo>)originalfiles.Where<FileInfo>(s => { return true; });


            // Check OrigLinal First
            foreach (FileInfo file in originalfiles)
            {
                if (token.IsCancellationRequested)
                {
                    // Clean up here, then...
                    RecordRedlog("Task is canceled.");
                    this.BeginInvoke(new SetbuttonStatus(this.SetNameConflictButtonStatus), new object[] { true });
                    token.ThrowIfCancellationRequested();
                }
                // remove self first
                ListAllFile = (IEnumerable<FileInfo>)ListAllFile.Except(new FileInfo[] { file } );
                var conflictList = ListAllFile.Where(item => { return Path.GetFileNameWithoutExtension(file.Name) == Path.GetFileNameWithoutExtension(item.Name); });
                if (conflictList.Count() > 0)
                {
                    NameConflictResult conflictresult = new NameConflictResult();
                    conflictresult.OriginalFileName = file.Name;
                    conflictresult.Path = param.OriginalDirectory;
                    conflictresult.ExtensionName = Path.GetExtension(file.Name);
                    foreach(FileInfo s in conflictList) {
                        conflictresult.NameConflictFileName += s.Name + " ; ";
                        // remove conflict file
                        ListAllFile = (IEnumerable<FileInfo>)ListAllFile.Except(new FileInfo[] { s });
                    }
                    listNameConflictResult.Add(conflictresult);
                }
                
                
            }
            if (param.IsShowFolder) { 
                if (listNameConflictResult.Count() == 0)
                {
                    // none conflict files under this folder
                    NameConflictResult conflictresult = new NameConflictResult();
                    conflictresult.OriginalFileName = "OK";
                    conflictresult.Path = param.OriginalDirectory;
                    conflictresult.NameConflictFileName = "none conflicts";
                    listNameConflictResult.Add(conflictresult);
                }
            }
            DeleteLog(2);
            LogConflictResult(listNameConflictResult);
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                NameConflictParameter paramSub = (NameConflictParameter)param.Clone();
                paramSub.OriginalDirectory = dir.FullName;
                
                AnalyzeNameConflictThreadSub(paramSub);
            }
        }
        private NameConflictParameter GetNameConflictParameter()
        {
            NameConflictParameter param = new NameConflictParameter();
            param.OriginalDirectory = this.txtConflict_OriginalDir.Text.Trim();
            param.OriginalExtension = this.txtConflict_OriginalFileExtension.Text.Trim();
            param.DestinationExtension = this.txtConflict_OutputFileExtension.Text.Trim();
            param.IsShowFolder = this.ckbConflict_showAllFolder.Checked;
            return param;
        }
        private bool NameConflictPathCheck(NameConflictParameter param)
        {
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalDirectory);
            if (!originalFold.Exists) { Log("Original Path is not exists."); return false; }
            return true;
        }
        private void LogConflictResult(List<NameConflictResult> list)
        {
            foreach(NameConflictResult item in list)
            {
                LogConflictResult(item);
                
            }
        }
        private void LogConflictResult(NameConflictResult result)
        {
            if (result.OriginalFileName == "OK")
                RecordWhitelog(result.OriginalFileName + "\t" + result.Path + "\t" + result.NameConflictFileName, true);
            else
                RecordRedlog(result.OriginalFileName + "\t" + result.Path + "\t" + result.NameConflictFileName, true);
        }

        #endregion  Threading Function

        #region Button Status controll
        private void SetNameConflictButtonStatus(bool flag)
        {
            this.btnConflict_Analyze.Enabled = flag;
            this.btnConflict_SetExtension.Enabled = flag;
            this.btnConflict_CancelAnalysis.Enabled = !flag;
        }
        #endregion Button Status controll
        #endregion Name Conflict

        #region CheckFile Operation
        #region Button Click
        private void BtnCheck_SetOriginalDir_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtCheck_OriginalDir.Text = this.openFold.SelectedPath;
            }
        }
        private void BtnCheck_SetOutput_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                this.txtCheck_OutputDir.Text = this.openFold.SelectedPath;
            }
        }
        private async void BtnCheck_Click(object sender, EventArgs e)
        {
            try {
                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                SetCheckFileButtonStatus(false);
                await CheckFile();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.BeginInvoke(new SetbuttonStatus(SetCheckFileButtonStatus), new object[] { true });
            }
        }
        private void BtnCheck_Cancel_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetCheckFileButtonStatus(true); }
            
        }
        #endregion Button Click

        #region Threading Function
        private Task CheckFile()
        {
            task = Task.Run(() => CheckFileThread());
            return task;
        }
        private void CheckFileThread()
        {
            CheckNumber = 0;
            CheckFileParameter paramCheckFile = GetCheckFileParameter();
            if (!PathCheck(paramCheckFile)) { return; }
            Log("number\tValid\tOriginal Size\tSize(Ori) Abbreviation\tOouput Size\tSize(Out) Abbreviation\ttOriginal Extension\tOutput Extension\tOriginal FileName\tOriginal Path\tDestination FileName\tDestination Path");
            CheckFileThreadSub(paramCheckFile);
            RecordGreenlog("Finished!", true);
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
            //token.ThrowIfCancellationRequested();
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
                if (token.IsCancellationRequested)
                {
                    // Clean up here, then...
                    RecordRedlog("Task is canceled.");
                    this.BeginInvoke(new SetbuttonStatus(SetCheckFileButtonStatus), new object[] { true });
                    token.ThrowIfCancellationRequested();
                }

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
        #endregion 
        #region Button Status controll
        /// <summary>
        /// Set LibreOffice converting buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetCheckFileButtonStatus(bool isEnabled)
        {
            this.btnCheck_SetOriginalDir.Enabled = isEnabled;
            this.btnCheck_SetOutput.Enabled = isEnabled;
            this.btnCheck.Enabled = isEnabled;
            this.btnCheck_Cancel.Enabled = !isEnabled;
        }

        #endregion
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
                // Mike add Number, Exact Size
                CheckNumber += 1;
                RecordWhitelog(CheckNumber.ToString() + "\t");
                if (result.isValid)
                {
                    RecordWhitelog("OK", false);
                }
                else
                {
                    RecordRedlog("No", false);
                }
                RecordWhitelog("\t", false);
                RecordWhitelog(result.OriginalFileSize.ToString("N0"), false);

                RecordWhitelog("\t", false);
                RecordWhitelog(GetByteDescription(result.OriginalFileSize), false);

                RecordWhitelog("\t", false);
                RecordWhitelog(result.DestinationFileSize.ToString("N0"), false);

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
            param.OriginalDirectory = this.txtCheck_OriginalDir.Text.Trim();
            param.OutputDirectory = this.txtCheck_OutputDir.Text.Trim();
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
        #endregion CheckFile Operation

        #region Log
        private void Log(string text)
        {
            RecordWhitelog(text, true);
        }
        private void LogContinue()
        {
            RecordWhitelog(System.DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.sss"), false);
            RecordRedlog(ConstContinueing, false);
        }

        private void DeleteLog(int line)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegateDeleteLog(DeleteLog);
                BeginInvoke(d, new object[] { line });
            }
            else
            {
                if (line > 0)
                {
                    //this.richTextBox1.Doc
                    int start = this.richTextBox1.Text.LastIndexOf("\n");
                    int end = this.richTextBox1.TextLength;
                    int len = end - start;
                    while ((start >= 0) && (line > 0))
                    {
                        //this.richTextBox1.Text = this.richTextBox1.Text.Remove(enter);
                        this.richTextBox1.Select(start, len);
                        this.richTextBox1.SelectedText = "";
                        line -= 1;
                        start = this.richTextBox1.Text.LastIndexOf("\n");
                        end = this.richTextBox1.TextLength;
                        len = end - start;
                    }

                }
                Log("");
            }
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



        #endregion


        #region Cancel Task
        private void CancelTask()
        {
            if (tokenSource != null)
            {
                if (tokenSource.IsCancellationRequested == false)
                {
                    tokenSource.Cancel();
                }
            }
        }
        #endregion 
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        
    }

    public class NameConflictParameter : ICloneable
    {
        public string OriginalDirectory { get; set; }
        public string OriginalExtension { get; set; }
        public string DestinationExtension { get; set; }

        public bool IsShowFolder { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public NameConflictParameter()
        {
            OriginalDirectory = "";
            DestinationExtension = "";
            OriginalExtension = "";
            IsShowFolder = false;
        }
    }
    public class CheckFileParameter : ICloneable
    {
        public string OriginalDirectory { get; set; }
        public string OriginalExtension { get; set; }
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
    public class NameConflictResult
    {
        public string NameConflictFileName { get; set; }
        public string ExtensionName { get; set; }
        public string OriginalFileName { get; set; }
        public string Path { get; set; }
        public NameConflictResult()
        {
            NameConflictFileName = "";
            ExtensionName = "";
            OriginalFileName = "";
            Path = "";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
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

