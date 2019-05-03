namespace Verktyg
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDestination = new System.Windows.Forms.Label();
            this.lbOriginal = new System.Windows.Forms.Label();
            this.btnSetOriginal = new System.Windows.Forms.Button();
            this.btnSetDestination = new System.Windows.Forms.Button();
            this.btnDeleteAllFiles = new System.Windows.Forms.Button();
            this.btnCopyFolder = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancelConverting = new System.Windows.Forms.Button();
            this.ckboverwrite = new System.Windows.Forms.CheckBox();
            this.btnSetExtensions = new System.Windows.Forms.Button();
            this.txtBatchFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateBatchFile = new System.Windows.Forms.Button();
            this.ckbSubfolder = new System.Windows.Forms.CheckBox();
            this.btnSetOutput = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetOriginalDir = new System.Windows.Forms.Button();
            this.txtOriginalDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOriginalExtension = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputFileExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetLibreOffice = new System.Windows.Forms.Button();
            this.txtLibrePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCheck_Cancel = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnCheck_SetOutput = new System.Windows.Forms.Button();
            this.txtCheck_OutputDir = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCheck_SetOriginalDir = new System.Windows.Forms.Button();
            this.txtCheck_OriginalDir = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnConflict_SetOriginalDir = new System.Windows.Forms.Button();
            this.txtConflict_OriginalDir = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnConflict_CancelAnalysis = new System.Windows.Forms.Button();
            this.btnConflict_Analyze = new System.Windows.Forms.Button();
            this.btnConflict_SetExtension = new System.Windows.Forms.Button();
            this.txtConflict_OriginalFileExtension = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtConflict_OutputFileExtension = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFold = new System.Windows.Forms.FolderBrowserDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.ckbConflict_showAllFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(852, 737);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 277);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.lbDestination);
            this.tabPage1.Controls.Add(this.lbOriginal);
            this.tabPage1.Controls.Add(this.btnSetOriginal);
            this.tabPage1.Controls.Add(this.btnSetDestination);
            this.tabPage1.Controls.Add(this.btnDeleteAllFiles);
            this.tabPage1.Controls.Add(this.btnCopyFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(844, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Folder";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lbDestination
            // 
            this.lbDestination.AutoSize = true;
            this.lbDestination.Location = new System.Drawing.Point(144, 18);
            this.lbDestination.Name = "lbDestination";
            this.lbDestination.Size = new System.Drawing.Size(47, 12);
            this.lbDestination.TabIndex = 14;
            this.lbDestination.Text = "       ";
            // 
            // lbOriginal
            // 
            this.lbOriginal.AutoSize = true;
            this.lbOriginal.Location = new System.Drawing.Point(144, 55);
            this.lbOriginal.Name = "lbOriginal";
            this.lbOriginal.Size = new System.Drawing.Size(47, 12);
            this.lbOriginal.TabIndex = 13;
            this.lbOriginal.Text = "       ";
            // 
            // btnSetOriginal
            // 
            this.btnSetOriginal.Location = new System.Drawing.Point(16, 42);
            this.btnSetOriginal.Name = "btnSetOriginal";
            this.btnSetOriginal.Size = new System.Drawing.Size(104, 23);
            this.btnSetOriginal.TabIndex = 11;
            this.btnSetOriginal.Text = "Set Orginal";
            this.btnSetOriginal.UseVisualStyleBackColor = true;
            this.btnSetOriginal.Click += new System.EventHandler(this.BtnSetOriginal_Click);
            // 
            // btnSetDestination
            // 
            this.btnSetDestination.Location = new System.Drawing.Point(16, 13);
            this.btnSetDestination.Name = "btnSetDestination";
            this.btnSetDestination.Size = new System.Drawing.Size(104, 23);
            this.btnSetDestination.TabIndex = 12;
            this.btnSetDestination.Text = "Set destination";
            this.btnSetDestination.UseVisualStyleBackColor = true;
            this.btnSetDestination.Click += new System.EventHandler(this.BtnSetDestination_Click);
            // 
            // btnDeleteAllFiles
            // 
            this.btnDeleteAllFiles.Location = new System.Drawing.Point(16, 100);
            this.btnDeleteAllFiles.Name = "btnDeleteAllFiles";
            this.btnDeleteAllFiles.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteAllFiles.TabIndex = 9;
            this.btnDeleteAllFiles.Text = "DeleteAllFiles";
            this.btnDeleteAllFiles.UseVisualStyleBackColor = true;
            this.btnDeleteAllFiles.Click += new System.EventHandler(this.BtnDeleteAllFiles_Click);
            // 
            // btnCopyFolder
            // 
            this.btnCopyFolder.Location = new System.Drawing.Point(16, 71);
            this.btnCopyFolder.Name = "btnCopyFolder";
            this.btnCopyFolder.Size = new System.Drawing.Size(104, 23);
            this.btnCopyFolder.TabIndex = 10;
            this.btnCopyFolder.Text = "CopyFolder";
            this.btnCopyFolder.UseVisualStyleBackColor = true;
            this.btnCopyFolder.Click += new System.EventHandler(this.BtnCopyFolder_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancelConverting);
            this.tabPage2.Controls.Add(this.ckboverwrite);
            this.tabPage2.Controls.Add(this.btnSetExtensions);
            this.tabPage2.Controls.Add(this.txtBatchFilePath);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnCreateBatchFile);
            this.tabPage2.Controls.Add(this.ckbSubfolder);
            this.tabPage2.Controls.Add(this.btnSetOutput);
            this.tabPage2.Controls.Add(this.txtOutputDir);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnSetOriginalDir);
            this.tabPage2.Controls.Add(this.txtOriginalDir);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtOriginalExtension);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtOutputFileExtension);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtCommand);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSetLibreOffice);
            this.tabPage2.Controls.Add(this.txtLibrePath);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(844, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Convert";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelConverting
            // 
            this.btnCancelConverting.Location = new System.Drawing.Point(694, 220);
            this.btnCancelConverting.Name = "btnCancelConverting";
            this.btnCancelConverting.Size = new System.Drawing.Size(121, 28);
            this.btnCancelConverting.TabIndex = 21;
            this.btnCancelConverting.Text = "Cancel Converting";
            this.btnCancelConverting.UseVisualStyleBackColor = true;
            this.btnCancelConverting.Click += new System.EventHandler(this.BtnCancelConverting_Click);
            // 
            // ckboverwrite
            // 
            this.ckboverwrite.AutoSize = true;
            this.ckboverwrite.Location = new System.Drawing.Point(143, 170);
            this.ckboverwrite.Name = "ckboverwrite";
            this.ckboverwrite.Size = new System.Drawing.Size(78, 16);
            this.ckboverwrite.TabIndex = 20;
            this.ckboverwrite.Text = "overwrite";
            this.ckboverwrite.UseVisualStyleBackColor = true;
            // 
            // btnSetExtensions
            // 
            this.btnSetExtensions.Location = new System.Drawing.Point(694, 83);
            this.btnSetExtensions.Name = "btnSetExtensions";
            this.btnSetExtensions.Size = new System.Drawing.Size(121, 23);
            this.btnSetExtensions.TabIndex = 19;
            this.btnSetExtensions.Text = "Set Extensions";
            this.btnSetExtensions.UseVisualStyleBackColor = true;
            this.btnSetExtensions.Click += new System.EventHandler(this.btnSetExtensions_Click);
            // 
            // txtBatchFilePath
            // 
            this.txtBatchFilePath.Location = new System.Drawing.Point(141, 193);
            this.txtBatchFilePath.Name = "txtBatchFilePath";
            this.txtBatchFilePath.Size = new System.Drawing.Size(547, 21);
            this.txtBatchFilePath.TabIndex = 18;
            this.txtBatchFilePath.Text = "c:\\test\\batch.txt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "BatchFilePath";
            // 
            // btnCreateBatchFile
            // 
            this.btnCreateBatchFile.Location = new System.Drawing.Point(694, 170);
            this.btnCreateBatchFile.Name = "btnCreateBatchFile";
            this.btnCreateBatchFile.Size = new System.Drawing.Size(121, 44);
            this.btnCreateBatchFile.TabIndex = 16;
            this.btnCreateBatchFile.Text = "Create Batch File";
            this.btnCreateBatchFile.UseVisualStyleBackColor = true;
            this.btnCreateBatchFile.Click += new System.EventHandler(this.BtnCreateBatchFile_Click);
            // 
            // ckbSubfolder
            // 
            this.ckbSubfolder.AutoSize = true;
            this.ckbSubfolder.Location = new System.Drawing.Point(11, 170);
            this.ckbSubfolder.Name = "ckbSubfolder";
            this.ckbSubfolder.Size = new System.Drawing.Size(126, 16);
            this.ckbSubfolder.TabIndex = 15;
            this.ckbSubfolder.Text = "include subfolder";
            this.ckbSubfolder.UseVisualStyleBackColor = true;
            // 
            // btnSetOutput
            // 
            this.btnSetOutput.Location = new System.Drawing.Point(694, 141);
            this.btnSetOutput.Name = "btnSetOutput";
            this.btnSetOutput.Size = new System.Drawing.Size(121, 23);
            this.btnSetOutput.TabIndex = 14;
            this.btnSetOutput.Text = "Set Output";
            this.btnSetOutput.UseVisualStyleBackColor = true;
            this.btnSetOutput.Click += new System.EventHandler(this.BtnSetOutput_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(140, 141);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(547, 21);
            this.txtOutputDir.TabIndex = 13;
            this.txtOutputDir.Text = "C:\\test ui\\test AB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "OutputDirectory";
            // 
            // btnSetOriginalDir
            // 
            this.btnSetOriginalDir.Location = new System.Drawing.Point(694, 112);
            this.btnSetOriginalDir.Name = "btnSetOriginalDir";
            this.btnSetOriginalDir.Size = new System.Drawing.Size(121, 23);
            this.btnSetOriginalDir.TabIndex = 11;
            this.btnSetOriginalDir.Text = "Set Origrinal";
            this.btnSetOriginalDir.UseVisualStyleBackColor = true;
            this.btnSetOriginalDir.Click += new System.EventHandler(this.btnSetOriginalDir_Click);
            // 
            // txtOriginalDir
            // 
            this.txtOriginalDir.Location = new System.Drawing.Point(141, 112);
            this.txtOriginalDir.Name = "txtOriginalDir";
            this.txtOriginalDir.Size = new System.Drawing.Size(547, 21);
            this.txtOriginalDir.TabIndex = 10;
            this.txtOriginalDir.Text = "c:\\test AB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "OriginalDirectory";
            // 
            // txtOriginalExtension
            // 
            this.txtOriginalExtension.Location = new System.Drawing.Point(141, 85);
            this.txtOriginalExtension.Name = "txtOriginalExtension";
            this.txtOriginalExtension.Size = new System.Drawing.Size(547, 21);
            this.txtOriginalExtension.TabIndex = 8;
            this.txtOriginalExtension.Text = "docx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "OriginalFileExtension";
            // 
            // txtOutputFileExtension
            // 
            this.txtOutputFileExtension.Location = new System.Drawing.Point(141, 58);
            this.txtOutputFileExtension.Name = "txtOutputFileExtension";
            this.txtOutputFileExtension.Size = new System.Drawing.Size(547, 21);
            this.txtOutputFileExtension.TabIndex = 6;
            this.txtOutputFileExtension.Text = "pdf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "OutputFileExtension";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(141, 31);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(547, 21);
            this.txtCommand.TabIndex = 4;
            this.txtCommand.Text = "--convert-to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "LibreOffice command";
            // 
            // btnSetLibreOffice
            // 
            this.btnSetLibreOffice.Location = new System.Drawing.Point(694, 3);
            this.btnSetLibreOffice.Name = "btnSetLibreOffice";
            this.btnSetLibreOffice.Size = new System.Drawing.Size(121, 23);
            this.btnSetLibreOffice.TabIndex = 2;
            this.btnSetLibreOffice.Text = "SetLibreOffice";
            this.btnSetLibreOffice.UseVisualStyleBackColor = true;
            this.btnSetLibreOffice.Click += new System.EventHandler(this.BtnSetLibreOffice_Click);
            // 
            // txtLibrePath
            // 
            this.txtLibrePath.Location = new System.Drawing.Point(141, 4);
            this.txtLibrePath.Name = "txtLibrePath";
            this.txtLibrePath.Size = new System.Drawing.Size(547, 21);
            this.txtLibrePath.TabIndex = 1;
            this.txtLibrePath.Text = "C:\\Program Files\\LibreOffice\\program\\soffice.exe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "LibreOffice Path";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCheck_Cancel);
            this.tabPage3.Controls.Add(this.btnCheck);
            this.tabPage3.Controls.Add(this.btnCheck_SetOutput);
            this.tabPage3.Controls.Add(this.txtCheck_OutputDir);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.btnCheck_SetOriginalDir);
            this.tabPage3.Controls.Add(this.txtCheck_OriginalDir);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(844, 251);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Check";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCheck_Cancel
            // 
            this.btnCheck_Cancel.Location = new System.Drawing.Point(691, 125);
            this.btnCheck_Cancel.Name = "btnCheck_Cancel";
            this.btnCheck_Cancel.Size = new System.Drawing.Size(121, 48);
            this.btnCheck_Cancel.TabIndex = 22;
            this.btnCheck_Cancel.Text = "Cancel Check Threading";
            this.btnCheck_Cancel.UseVisualStyleBackColor = true;
            this.btnCheck_Cancel.Click += new System.EventHandler(this.BtnCheck_Cancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(691, 71);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(121, 48);
            this.btnCheck.TabIndex = 21;
            this.btnCheck.Text = "Check File";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // btnCheck_SetOutput
            // 
            this.btnCheck_SetOutput.Location = new System.Drawing.Point(691, 41);
            this.btnCheck_SetOutput.Name = "btnCheck_SetOutput";
            this.btnCheck_SetOutput.Size = new System.Drawing.Size(121, 23);
            this.btnCheck_SetOutput.TabIndex = 20;
            this.btnCheck_SetOutput.Text = "Set Output";
            this.btnCheck_SetOutput.UseVisualStyleBackColor = true;
            this.btnCheck_SetOutput.Click += new System.EventHandler(this.BtnCheck_SetOutput_Click);
            // 
            // txtCheck_OutputDir
            // 
            this.txtCheck_OutputDir.Location = new System.Drawing.Point(137, 41);
            this.txtCheck_OutputDir.Name = "txtCheck_OutputDir";
            this.txtCheck_OutputDir.Size = new System.Drawing.Size(516, 21);
            this.txtCheck_OutputDir.TabIndex = 19;
            this.txtCheck_OutputDir.Text = "C:\\test ui\\test AB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "OutputDirectory";
            // 
            // btnCheck_SetOriginalDir
            // 
            this.btnCheck_SetOriginalDir.Location = new System.Drawing.Point(691, 12);
            this.btnCheck_SetOriginalDir.Name = "btnCheck_SetOriginalDir";
            this.btnCheck_SetOriginalDir.Size = new System.Drawing.Size(121, 23);
            this.btnCheck_SetOriginalDir.TabIndex = 17;
            this.btnCheck_SetOriginalDir.Text = "Set Origrinal";
            this.btnCheck_SetOriginalDir.UseVisualStyleBackColor = true;
            this.btnCheck_SetOriginalDir.Click += new System.EventHandler(this.BtnCheck_SetOriginalDir_Click);
            // 
            // txtCheck_OriginalDir
            // 
            this.txtCheck_OriginalDir.Location = new System.Drawing.Point(138, 12);
            this.txtCheck_OriginalDir.Name = "txtCheck_OriginalDir";
            this.txtCheck_OriginalDir.Size = new System.Drawing.Size(516, 21);
            this.txtCheck_OriginalDir.TabIndex = 16;
            this.txtCheck_OriginalDir.Text = "c:\\test AB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "OriginalDirectory";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ckbConflict_showAllFolder);
            this.tabPage4.Controls.Add(this.btnConflict_SetOriginalDir);
            this.tabPage4.Controls.Add(this.txtConflict_OriginalDir);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.btnConflict_CancelAnalysis);
            this.tabPage4.Controls.Add(this.btnConflict_Analyze);
            this.tabPage4.Controls.Add(this.btnConflict_SetExtension);
            this.tabPage4.Controls.Add(this.txtConflict_OriginalFileExtension);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.txtConflict_OutputFileExtension);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(844, 251);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "name conflict";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnConflict_SetOriginalDir
            // 
            this.btnConflict_SetOriginalDir.Location = new System.Drawing.Point(696, 14);
            this.btnConflict_SetOriginalDir.Name = "btnConflict_SetOriginalDir";
            this.btnConflict_SetOriginalDir.Size = new System.Drawing.Size(121, 23);
            this.btnConflict_SetOriginalDir.TabIndex = 28;
            this.btnConflict_SetOriginalDir.Text = "Set Origrinal";
            this.btnConflict_SetOriginalDir.UseVisualStyleBackColor = true;
            this.btnConflict_SetOriginalDir.Click += new System.EventHandler(this.BtnConflict_SetOriginalDir_Click);
            // 
            // txtConflict_OriginalDir
            // 
            this.txtConflict_OriginalDir.Location = new System.Drawing.Point(143, 14);
            this.txtConflict_OriginalDir.Name = "txtConflict_OriginalDir";
            this.txtConflict_OriginalDir.Size = new System.Drawing.Size(547, 21);
            this.txtConflict_OriginalDir.TabIndex = 27;
            this.txtConflict_OriginalDir.Text = "c:\\test AB";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "OriginalDirectory";
            // 
            // btnConflict_CancelAnalysis
            // 
            this.btnConflict_CancelAnalysis.Location = new System.Drawing.Point(696, 139);
            this.btnConflict_CancelAnalysis.Name = "btnConflict_CancelAnalysis";
            this.btnConflict_CancelAnalysis.Size = new System.Drawing.Size(121, 38);
            this.btnConflict_CancelAnalysis.TabIndex = 25;
            this.btnConflict_CancelAnalysis.Text = "Cancel Analysis";
            this.btnConflict_CancelAnalysis.UseVisualStyleBackColor = true;
            this.btnConflict_CancelAnalysis.Click += new System.EventHandler(this.BtnConflict_CancelAnalysis_Click);
            // 
            // btnConflict_Analyze
            // 
            this.btnConflict_Analyze.Location = new System.Drawing.Point(696, 95);
            this.btnConflict_Analyze.Name = "btnConflict_Analyze";
            this.btnConflict_Analyze.Size = new System.Drawing.Size(121, 38);
            this.btnConflict_Analyze.TabIndex = 25;
            this.btnConflict_Analyze.Text = "Analyze";
            this.btnConflict_Analyze.UseVisualStyleBackColor = true;
            this.btnConflict_Analyze.Click += new System.EventHandler(this.BtnConflict_Analyze_Click);
            // 
            // btnConflict_SetExtension
            // 
            this.btnConflict_SetExtension.Location = new System.Drawing.Point(696, 66);
            this.btnConflict_SetExtension.Name = "btnConflict_SetExtension";
            this.btnConflict_SetExtension.Size = new System.Drawing.Size(121, 23);
            this.btnConflict_SetExtension.TabIndex = 24;
            this.btnConflict_SetExtension.Text = "Set Extensions";
            this.btnConflict_SetExtension.UseVisualStyleBackColor = true;
            this.btnConflict_SetExtension.Click += new System.EventHandler(this.BtnConflict_SetExtension_Click);
            // 
            // txtConflict_OriginalFileExtension
            // 
            this.txtConflict_OriginalFileExtension.Location = new System.Drawing.Point(143, 68);
            this.txtConflict_OriginalFileExtension.Name = "txtConflict_OriginalFileExtension";
            this.txtConflict_OriginalFileExtension.Size = new System.Drawing.Size(547, 21);
            this.txtConflict_OriginalFileExtension.TabIndex = 23;
            this.txtConflict_OriginalFileExtension.Text = "docx";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "OriginalFileExtension";
            // 
            // txtConflict_OutputFileExtension
            // 
            this.txtConflict_OutputFileExtension.Location = new System.Drawing.Point(143, 41);
            this.txtConflict_OutputFileExtension.Name = "txtConflict_OutputFileExtension";
            this.txtConflict_OutputFileExtension.Size = new System.Drawing.Size(547, 21);
            this.txtConflict_OutputFileExtension.TabIndex = 21;
            this.txtConflict_OutputFileExtension.Text = "pdf";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "OutputFileExtension";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(852, 456);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // openFile
            // 
            this.openFile.FileName = "soffice";
            // 
            // ckbConflict_showAllFolder
            // 
            this.ckbConflict_showAllFolder.AutoSize = true;
            this.ckbConflict_showAllFolder.Location = new System.Drawing.Point(13, 95);
            this.ckbConflict_showAllFolder.Name = "ckbConflict_showAllFolder";
            this.ckbConflict_showAllFolder.Size = new System.Drawing.Size(234, 16);
            this.ckbConflict_showAllFolder.TabIndex = 29;
            this.ckbConflict_showAllFolder.Text = "Show information of all the folders";
            this.ckbConflict_showAllFolder.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 737);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Konvertering Verktyg";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FolderBrowserDialog openFold;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDeleteAllFiles;
        private System.Windows.Forms.Button btnCopyFolder;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbDestination;
        private System.Windows.Forms.Label lbOriginal;
        private System.Windows.Forms.Button btnSetOriginal;
        private System.Windows.Forms.Button btnSetDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLibrePath;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnSetLibreOffice;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputFileExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetOriginalDir;
        private System.Windows.Forms.TextBox txtOriginalDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOriginalExtension;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetOutput;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbSubfolder;
        private System.Windows.Forms.Button btnCreateBatchFile;
        private System.Windows.Forms.TextBox txtBatchFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSetExtensions;
        private System.Windows.Forms.CheckBox ckboverwrite;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCheck_SetOutput;
        private System.Windows.Forms.TextBox txtCheck_OutputDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCheck_SetOriginalDir;
        private System.Windows.Forms.TextBox txtCheck_OriginalDir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancelConverting;
        private System.Windows.Forms.Button btnCheck_Cancel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnConflict_Analyze;
        private System.Windows.Forms.Button btnConflict_SetExtension;
        private System.Windows.Forms.TextBox txtConflict_OriginalFileExtension;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtConflict_OutputFileExtension;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnConflict_CancelAnalysis;
        private System.Windows.Forms.Button btnConflict_SetOriginalDir;
        private System.Windows.Forms.TextBox txtConflict_OriginalDir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ckbConflict_showAllFolder;
    }
}

