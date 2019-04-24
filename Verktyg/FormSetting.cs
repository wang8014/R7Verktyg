using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Verktyg
{
    public partial class FormSetting : Form
    {
        Type type;
        public FormSetting()
        {
            InitializeComponent();
            type = this.GetType();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void InitialExtensions(string extensions)
        {
            BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo[] infoList = type.GetFields(flag);
            foreach(FieldInfo info in infoList)
            {
                if (info.FieldType.FullName == "System.Windows.Forms.CheckBox")
                {
                    ((CheckBox)info.GetValue(this)).Checked = false;
                }
            }
            var extensionsList = extensions.Split(';');
            foreach(var item in extensionsList)
            {
                InitialCheckbox(item);
            }
        }
        private void InitialCheckbox(string extension)
        {
            
            BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;
            FieldInfo info = type.GetField("ckb"+ extension , flag);
            if (info != null)
            {
                ((CheckBox)(info.GetValue(this))).Checked = true;
            }
        }
        public string GetExtensions()
        {
            string extensions=";";
            #region Word
            extensions += CheckExtension(this.ckbdoc);
            extensions += CheckExtension(this.ckbdocm);
            extensions += CheckExtension(this.ckbdocx);
            extensions += CheckExtension(this.ckbdot);
            extensions += CheckExtension(this.ckbdotm);
            extensions += CheckExtension(this.ckbdotx);
            #endregion Word

            #region Excel
            extensions += CheckExtension(this.ckbxls);
            extensions += CheckExtension(this.ckbxlsb);
            extensions += CheckExtension(this.ckbxlsm);
            extensions += CheckExtension(this.ckbxlsx);
            extensions += CheckExtension(this.ckbxltx);
            #endregion Excel


            #region PowerPoint
            extensions += CheckExtension(this.ckbpotm);
            extensions += CheckExtension(this.ckbpotx);
            extensions += CheckExtension(this.ckbpps);
            extensions += CheckExtension(this.ckbppsm);
            extensions += CheckExtension(this.ckbppsx);
            extensions += CheckExtension(this.ckbppt);
            extensions += CheckExtension(this.ckbpptm);
            extensions += CheckExtension(this.ckbpptx);

            #endregion PowerPoint

            #region PDF
            extensions += CheckExtension(this.ckbpdf);

            #endregion 

            #region RichText
            extensions += CheckExtension(this.ckbrtf);

            #endregion 

            extensions = extensions.Remove(extensions.Length - 1);
            extensions = extensions.Substring(1);

            return extensions;
        }
        public string CheckExtension(CheckBox ckb)
        {
            if (ckb.Checked) { return getExtensionFromCheckBox(ckb) + ";"; }
            else { return ""; }
        }
        public string getExtensionFromCheckBox(CheckBox ckb)
        {
            string extension = "";
            if (ckb != null ){
                extension = ckb.Text;
                extension = extension.Substring(1);
            }
            return extension;
        }
    }
}
