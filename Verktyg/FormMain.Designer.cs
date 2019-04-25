﻿namespace Verktyg
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
            this.ckboverwrite = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtBatchFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateBatchFile = new System.Windows.Forms.Button();
            this.ckbSubfolder = new System.Windows.Forms.CheckBox();
            this.btnSetOutput = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SetOriginalDir = new System.Windows.Forms.Button();
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
            this.btnSetOutput2 = new System.Windows.Forms.Button();
            this.txtOutputDir2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SetOriginalDir2 = new System.Windows.Forms.Button();
            this.txtOriginalDir2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFold = new System.Windows.Forms.FolderBrowserDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnCheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.ckboverwrite);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.txtBatchFilePath);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnCreateBatchFile);
            this.tabPage2.Controls.Add(this.ckbSubfolder);
            this.tabPage2.Controls.Add(this.btnSetOutput);
            this.tabPage2.Controls.Add(this.txtOutputDir);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.SetOriginalDir);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(694, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Set Extensions";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
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
            this.txtOutputDir.Text = "C:\\test2 ui\\test AB";
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
            // SetOriginalDir
            // 
            this.SetOriginalDir.Location = new System.Drawing.Point(694, 112);
            this.SetOriginalDir.Name = "SetOriginalDir";
            this.SetOriginalDir.Size = new System.Drawing.Size(121, 23);
            this.SetOriginalDir.TabIndex = 11;
            this.SetOriginalDir.Text = "Set Origrinal";
            this.SetOriginalDir.UseVisualStyleBackColor = true;
            this.SetOriginalDir.Click += new System.EventHandler(this.SetOriginalDir_Click);
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
            this.tabPage3.Controls.Add(this.btnCheck);
            this.tabPage3.Controls.Add(this.btnSetOutput2);
            this.tabPage3.Controls.Add(this.txtOutputDir2);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.SetOriginalDir2);
            this.tabPage3.Controls.Add(this.txtOriginalDir2);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(844, 251);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Check";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSetOutput2
            // 
            this.btnSetOutput2.Location = new System.Drawing.Point(691, 41);
            this.btnSetOutput2.Name = "btnSetOutput2";
            this.btnSetOutput2.Size = new System.Drawing.Size(121, 23);
            this.btnSetOutput2.TabIndex = 20;
            this.btnSetOutput2.Text = "Set Output";
            this.btnSetOutput2.UseVisualStyleBackColor = true;
            this.btnSetOutput2.Click += new System.EventHandler(this.BtnSetOutput2_Click);
            // 
            // txtOutputDir2
            // 
            this.txtOutputDir2.Location = new System.Drawing.Point(137, 41);
            this.txtOutputDir2.Name = "txtOutputDir2";
            this.txtOutputDir2.Size = new System.Drawing.Size(516, 21);
            this.txtOutputDir2.TabIndex = 19;
            this.txtOutputDir2.Text = "C:\\test2 ui\\test AB";
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
            // SetOriginalDir2
            // 
            this.SetOriginalDir2.Location = new System.Drawing.Point(691, 12);
            this.SetOriginalDir2.Name = "SetOriginalDir2";
            this.SetOriginalDir2.Size = new System.Drawing.Size(121, 23);
            this.SetOriginalDir2.TabIndex = 17;
            this.SetOriginalDir2.Text = "Set Origrinal";
            this.SetOriginalDir2.UseVisualStyleBackColor = true;
            this.SetOriginalDir2.Click += new System.EventHandler(this.SetOriginalDir2_Click);
            // 
            // txtOriginalDir2
            // 
            this.txtOriginalDir2.Location = new System.Drawing.Point(138, 12);
            this.txtOriginalDir2.Name = "txtOriginalDir2";
            this.txtOriginalDir2.Size = new System.Drawing.Size(516, 21);
            this.txtOriginalDir2.TabIndex = 16;
            this.txtOriginalDir2.Text = "c:\\test AB";
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
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(691, 71);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(121, 79);
            this.btnCheck.TabIndex = 21;
            this.btnCheck.Text = "Check File";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.BtnCheck_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 737);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Konvertering Verktyg";
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
        private System.Windows.Forms.Button SetOriginalDir;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ckboverwrite;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSetOutput2;
        private System.Windows.Forms.TextBox txtOutputDir2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SetOriginalDir2;
        private System.Windows.Forms.TextBox txtOriginalDir2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCheck;
    }
}

