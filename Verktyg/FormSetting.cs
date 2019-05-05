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
        public string GetAllExtensions()
        {
            string extensions = ";";
            #region Word
            extensions += CheckExtension(this.ckbdoc, false);
            extensions += CheckExtension(this.ckbdocm, false);
            extensions += CheckExtension(this.ckbdocx, false);
            extensions += CheckExtension(this.ckbdot, false);
            extensions += CheckExtension(this.ckbdotm, false);
            extensions += CheckExtension(this.ckbdotx, false);
            #endregion Word

            #region Excel
            extensions += CheckExtension(this.ckbxls, false);
            extensions += CheckExtension(this.ckbxlsb, false);
            extensions += CheckExtension(this.ckbxlsm, false);
            extensions += CheckExtension(this.ckbxlsx, false);
            extensions += CheckExtension(this.ckbxltx, false);
            #endregion Excel


            #region PowerPoint
            extensions += CheckExtension(this.ckbpotm, false);
            extensions += CheckExtension(this.ckbpotx, false);
            extensions += CheckExtension(this.ckbpps, false);
            extensions += CheckExtension(this.ckbppsm, false);
            extensions += CheckExtension(this.ckbppsx, false);
            extensions += CheckExtension(this.ckbppt, false);
            extensions += CheckExtension(this.ckbpptm, false);
            extensions += CheckExtension(this.ckbpptx, false);

            #endregion PowerPoint

            #region PDF
            extensions += CheckExtension(this.ckbpdf, false);

            #endregion 

            #region RichText
            extensions += CheckExtension(this.ckbrtf, false);

            #endregion 

            extensions = extensions.Remove(extensions.Length - 1);
            extensions = extensions.Substring(1);

            return extensions;
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
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ckb"></param>
        ///// <returns></returns>
        //private string CheckExtension(CheckBox ckb)
        //{
        //    if (ckb.Checked) { return getExtensionFromCheckBox(ckb) + ";"; }
        //    else { return ""; }
        //}
        /// <summary>
        /// if flag = true ,return extension  according to Checkbox control 's checkedvalue
        /// if flag = false, return extension allways and don't check the checkedvalue of Checkbox control
        /// </summary>
        /// <param name="ckb"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string CheckExtension(CheckBox ckb,bool flag=true)
        {
            if (flag) { 
                if (ckb.Checked) { return getExtensionFromCheckBox(ckb) + ";"; }
                else { return ""; }
            }
            else
            {
                return getExtensionFromCheckBox(ckb) + ";";
            }
        }
        private string getExtensionFromCheckBox(CheckBox ckb)
        {
            string extension = "";
            if (ckb != null ){
                extension = ckb.Text;
                extension = extension.Substring(1);
            }
            return extension;
        }
        private void SetCheckedValue(CheckBox ckb,bool flag)
        {
            ckb.Checked = flag;            
        }
        private void CkbAllWord_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                SetCheckedValue(this.ckbdoc,true);
                SetCheckedValue(this.ckbdocm, true);
                SetCheckedValue(this.ckbdocx, true);
                SetCheckedValue(this.ckbdot, true);
                SetCheckedValue(this.ckbdotm, true);
                SetCheckedValue(this.ckbdotx, true);
            } else
            {
                SetCheckedValue(this.ckbdoc, false);
                SetCheckedValue(this.ckbdocm, false);
                SetCheckedValue(this.ckbdocx, false);
                SetCheckedValue(this.ckbdot, false);
                SetCheckedValue(this.ckbdotm, false);
                SetCheckedValue(this.ckbdotx, false);
            }
        }

        private void CkbAllPPT_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                SetCheckedValue(this.ckbpotm, true);
                SetCheckedValue(this.ckbpotx, true);
                SetCheckedValue(this.ckbpps, true);
                SetCheckedValue(this.ckbppsm, true);
                SetCheckedValue(this.ckbppsx, true);
                SetCheckedValue(this.ckbppt, true);
                SetCheckedValue(this.ckbpptm, true);
                SetCheckedValue(this.ckbpptx, true);
            }
            else
            {
                SetCheckedValue(this.ckbpotm, false);
                SetCheckedValue(this.ckbpotx, false);
                SetCheckedValue(this.ckbpps,  false);
                SetCheckedValue(this.ckbppsm,false);
                SetCheckedValue(this.ckbppsx, false);
                SetCheckedValue(this.ckbppt,  false);
                SetCheckedValue(this.ckbpptm, false);
                SetCheckedValue(this.ckbpptx, false);
            }
        }

        private void CkbAllExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                SetCheckedValue(this.ckbxls, true);
                SetCheckedValue(this.ckbxlsb, true);
                SetCheckedValue(this.ckbxlsm, true);
                SetCheckedValue(this.ckbxlsx, true);
                SetCheckedValue(this.ckbxltx, true);
            }
            else
            {
                SetCheckedValue(this.ckbxls, false);
                SetCheckedValue(this.ckbxlsb, false);
                SetCheckedValue(this.ckbxlsm, false);
                SetCheckedValue(this.ckbxlsx, false);
                SetCheckedValue(this.ckbxltx, false);
            }
        }
    }
}
