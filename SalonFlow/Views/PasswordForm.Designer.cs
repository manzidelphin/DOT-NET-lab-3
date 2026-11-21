using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SalonFlow.Views
{
    partial class PasswordForm
    {
        private IContainer? components;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblCurrent = new Label();
            this.txtCurrent = new TextBox();
            this.lblNew = new Label();
            this.txtNew = new TextBox();
            this.lblConfirm = new Label();
            this.txtConfirm = new TextBox();
            this.btnSave = new Button();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Location = new Point(24, 18);
            this.lblTitle.Size = new Size(447, 40);
            this.lblTitle.Text = "Change password";
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Location = new Point(26, 78);
            this.lblCurrent.Size = new Size(160, 24);
            this.lblCurrent.Text = "Current password";
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.TabIndex = 2;
            this.txtCurrent.Location = new Point(190, 76);
            this.txtCurrent.Size = new Size(270, 25);
            this.txtCurrent.UseSystemPasswordChar = true;
            this.lblNew.Name = "lblNew";
            this.lblNew.TabIndex = 3;
            this.lblNew.Location = new Point(26, 117);
            this.lblNew.Size = new Size(160, 24);
            this.lblNew.Text = "New password";
            this.txtNew.Name = "txtNew";
            this.txtNew.TabIndex = 4;
            this.txtNew.Location = new Point(190, 115);
            this.txtNew.Size = new Size(270, 25);
            this.txtNew.UseSystemPasswordChar = true;
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.TabIndex = 5;
            this.lblConfirm.Location = new Point(26, 156);
            this.lblConfirm.Size = new Size(160, 24);
            this.lblConfirm.Text = "Confirm password";
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.TabIndex = 6;
            this.txtConfirm.Location = new Point(190, 154);
            this.txtConfirm.Size = new Size(270, 25);
            this.txtConfirm.UseSystemPasswordChar = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 7;
            this.btnSave.Location = new Point(190, 199);
            this.btnSave.Size = new Size(140, 33);
            this.btnSave.Text = "Save password";
            this.btnSave.Click += new EventHandler(this.SavePassword);
            this.btnSave.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(495, 254);
            this.Text = "SalonFlow - Change password";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PasswordForm";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.btnSave);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle = null!;
        private Label lblCurrent = null!;
        private TextBox txtCurrent = null!;
        private Label lblNew = null!;
        private TextBox txtNew = null!;
        private Label lblConfirm = null!;
        private TextBox txtConfirm = null!;
        private Button btnSave = null!;
    }
}
