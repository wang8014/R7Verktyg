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
using Verktyg.Tools;
using Verktyg.Log;
using Verktyg.Threading;

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
        
        

        private Task task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        //private int CheckNumber = 0;
        private CancellationToken token;
        

        private CustomizedLog log;
        #endregion
        

        public FormMain()
        {
            InitializeComponent();
            token = tokenSource.Token;
            log = new CustomizedLog(this.richTextBox1);
        }

        #region Test

        private void Button2_Click(object sender, EventArgs e)
        {
            //tokenSource = new CancellationTokenSource();
            //token = tokenSource.Token;

            //task = Task.Run(() => doSomething(200),token);
            //try { 
            //    await task;
            //}
            //catch (Exception ex)
            //{
            //    log.Log("task isCanceled:" + task.IsCanceled.ToString());
            //    log.Log("task isCompleted" + task.IsCompleted.ToString());
            //}
            // log.Log(Path.GetExtension("intervju.docx"));
            //FileInfo oneFile = new FileInfo(@"c:\test AB\intervju.docx");
            //FileInfo twoFile = oneFile.;
            //Get original files list
            DirectoryInfo originalFold = new DirectoryInfo(@"c:\test AB");
            var originalFileList = originalFold.GetFiles().Where(s =>
            {
                bool rtn = false;
                var extensionlist = "docx;xlsx;pdf;pptx".Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
            });
            foreach (FileInfo item in originalFileList)
            {
                log.Log(item.Name + "\t" + item.Length.ToString());
            }
            log.LogContinue();
            //Get LibreOffice support list
            var LibreOfficeSupportFileList = originalFold.GetFiles().Where(s =>
            {
                bool rtn = false;
                var extensionlist = "docx;xlsx;pdf;pptx".Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
            });
            
            IEnumerable<FileInfo> result = LibreOfficeSupportFileList.Where(s =>
            {
                return Path.GetFileNameWithoutExtension("vaccine_Jessica") == Path.GetFileNameWithoutExtension(s.Name);
            });
            ////Create converting File List
            ////foreach (FileInfo file in originalFileList)
            ////{
            log.Log("Except vaccine_Jessica");
            originalFileList = originalFileList.Except(result);
            foreach (FileInfo item in originalFileList)
            {
                log.Log(item.Name + "\t" + item.Length.ToString());
                
            }
            log.LogContinue();

            originalFileList = originalFold.GetFiles().Where(s =>
            {
                bool rtn = false;
                var extensionlist = "docx;xlsx;pdf;pptx".Split(';');
                foreach (string item in extensionlist)
                {
                    rtn = rtn || s.Name.EndsWith("." + item);
                }

                return rtn;
            });
            log.Log("Except FileInfoComparer");
            originalFileList = originalFileList.Except(result, new FileInfoComparer());

            while(originalFileList.Count()>0)  // (FileInfo item in originalFileList)
            {
                FileInfo file = originalFileList.First();
                log.Log(file.Name + "\t" + file.Length.ToString());
                originalFileList = originalFileList.Except(new FileInfo[] { file }, new FileInfoComparer());
            }


        }



        private void Button1_Click(object sender, EventArgs e)
        {
            //RecordBluelog("converting is started", true);
            //tokenSource.Cancel();
            //while (!task.IsCompleted) { 
            //    Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " task isCanceled:" + task.IsCanceled.ToString());
            //    Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " task isCompleted:" + task.IsCompleted.ToString());
            //}
            log.Log("first line");
            log.RecordBluelog("blue log");
            log.RecordRedlog("red log");

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
                log.Log(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss") + " loop " + i.ToString());
            }

        }

        #endregion test

        #region Folder Operation
        #region Button Click 
        private void BtnCancel_Copy_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetFolderButtonStatus(true); }

        }
        private void BtnSetOriginal_Click(object sender, EventArgs e)
        {
            SetOriginalFold();
        }
        private void BtnCancel_DeleteFile_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetFolderButtonStatus(true); }
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
                // await DeleteAllfiles(openFold.SelectedPath);
                try
                {
                    this.SetFolderButtonStatus(false);
                    StartNewTask();
                    DeleteFileParameter param = new DeleteFileParameter();
                    param.OutoutDirectoy = openFold.SelectedPath.Trim();
                    DeleteFile deleteThreading = new DeleteFile(this.log, this.tokenSource, param);
                    task = deleteThreading.Run();
                    await task;
                    //
                }
                catch (Exception ex)
                {
                    log.RecordError(ex.Message);
                    //this.SetFolderButtonStatus(true);
                }
                finally
                {
                    this.SetFolderButtonStatus(true);
                }
            }
            
        }
        private async void BtnCopyFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetFolderButtonStatus(false);
                StartNewTask();
                CopyFileParameter param = new CopyFileParameter();
                param.OutoutDirectoy = this.lbDestination.Text.Trim();
                param.OriginalDirectory = this.lbOriginal.Text.Trim();
                CopyFolder copyThreading = new CopyFolder(this.log, this.tokenSource, param);
                task = copyThreading.Run();
                await task;
                //
            }
            catch (Exception ex){
                log.RecordError(ex.Message);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                this.SetFolderButtonStatus(true);
            }
        }
        #endregion Button Click
        private void SetOriginalFold()
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                SetOriginalFold(openFold.SelectedPath);
            }
        }
        private void SetOriginalFold(string dirPath)
        {
            this.lbOriginal.Text = dirPath;
        }
        private void SetDestinationFold()
        {
            DialogResult dr = OpenFoldDialog();
            if ((dr == DialogResult.Yes) || (dr == DialogResult.OK))
            {
                SetDestinationFold(openFold.SelectedPath);
            }
        }
        private void SetDestinationFold(string dirPath)
        {
            this.lbDestination.Text = dirPath;
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

        private void SetFolderButtonStatus(bool flag)
        {
            this.btnCopyFolder.Enabled = flag;
            this.btnDeleteAllFiles.Enabled = flag;
            this.btnSetDestination.Enabled = flag;
            this.btnSetOriginal.Enabled = flag;
            this.btnCancel_Copy.Enabled = !flag;
            this.btnDeleteAllFiles.Enabled = flag;
            this.btnCancel_Copy.Enabled = !flag;
        }

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
                this.SetLibreOfficeButtonStatus(false);
                StartNewTask();
                LibreOfficeParameter param = GetLibreOfficeParamter();
                LibreOfficeConvert convertThreading = new LibreOfficeConvert(this.log, this.tokenSource, param);
                task = convertThreading.Run();
                await task;
                //
            }
            catch (Exception ex)
            {
                log.RecordError(ex.Message);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                this.SetLibreOfficeButtonStatus(true);
            }

        }

        private void BtnCancelConverting_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CancelTask();
            if (task.IsCompleted) { this.SetCheckFileButtonStatus(true); }
            
        }
        #endregion Buttion Click

        private LibreOfficeParameter GetLibreOfficeParamter()
        {
            LibreOfficeParameter libreparam = new LibreOfficeParameter();
            libreparam.Path = this.txtLibrePath.Text.Trim();
            libreparam.IsincludSubfolder = this.ckbSubfolder.Checked;
            libreparam.Command = this.txtCommand.Text.Trim();
            libreparam.OriginalDirectory = this.txtOriginalDir.Text.Trim();
            libreparam.OutputDirectory = this.txtOutputDir.Text.Trim();
            libreparam.OriginalExtension = this.txtOriginalExtension.Text.Trim();
            libreparam.OutputFileExtension = this.txtOutputFileExtension.Text.Trim();
            libreparam.Isoverwrite = this.ckboverwrite.Checked;
            libreparam.BatchFile = this.txtBatchFilePath.Text.Trim();
            FormSetting f = new FormSetting();
            libreparam.AllExtensionOfLibreOfficeSupporting = f.GetAllExtensions();
            return libreparam;
        }

        private string  GetBatchFilePath()
        {
            return this.txtBatchFilePath.Text.Trim();
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
                this.SetNameConflictButtonStatus(false);
                StartNewTask();
                NameConflictParameter param = GetNameConflictParameter();
                NameConflict nameConflictThreading = new NameConflict(this.log, this.tokenSource, param);
                task = nameConflictThreading.Run();
                await task;
                //
            }
            catch (System.OperationCanceledException ex)
            {
                log.RecordError(ex.Message);
            }
            catch (Exception ex)
            {
                log.RecordError(ex.Message);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                this.SetNameConflictButtonStatus(true);
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
       
        
        private void AnalyzeNameConflictThreadSub(NameConflictParameter param)
        {
            //NameConflictPathCheck(param.OriginalDirectory);
            
            
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
        private void BtnCheck_SetExtensions_Click(object sender, EventArgs e)
        {
            FormSetting f = new FormSetting();
            f.InitialExtensions(this.txtCheck_OriginalExtension.Text);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtCheck_OriginalExtension.Text = f.GetExtensions();
            }
        }
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
            try
            {
                this.SetCheckFileButtonStatus(false);
                StartNewTask();
                CheckFileParameter param = GetCheckFileParameter();
                CheckFile checkhreading = new CheckFile(this.log, this.tokenSource, param);
                task = checkhreading.Run();
                await task;
                //
            }
            catch (Exception ex)
            {
                log.RecordError(ex.Message);
                //this.SetFolderButtonStatus(true);
            }
            finally
            {
                this.SetCheckFileButtonStatus(true);
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
        //private Task CheckFile()
        //{
        //    //log.LogTaskBegin();
        //    //task = Task.Run(() => CheckFileThread());
        //    //return task;
        //}
        
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
        
        
        
        private CheckFileParameter GetCheckFileParameter()
        {
            CheckFileParameter param = new CheckFileParameter();
            param.OriginalDirectory = this.txtCheck_OriginalDir.Text.Trim();
            param.OutputDirectory = this.txtCheck_OutputDir.Text.Trim();

            param.OriginalExtension = this.txtCheck_OriginalExtension.Text.Trim();
            param.OutputFileExtension = this.txtCheck_OutputFileExtension.Text.Trim();
            FormSetting f = new FormSetting();
            param.AllExtensionOfLibreOfficeSupporting = f.GetAllExtensions();


            return param;

        }
        
        #endregion CheckFile Operation

        



        #region Task functions
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
        private void StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }
        #endregion 
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        
    }

}

