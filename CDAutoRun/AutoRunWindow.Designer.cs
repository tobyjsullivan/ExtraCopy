namespace CDAutoRun
{
    partial class AutoRunWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoRunWindow));
            this.w_lTitle = new System.Windows.Forms.Label();
            this.w_bInstall = new System.Windows.Forms.Button();
            this.w_bClose = new System.Windows.Forms.Button();
            this.w_bRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // w_lTitle
            // 
            this.w_lTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.w_lTitle.Font = new System.Drawing.Font("Neuropol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_lTitle.Location = new System.Drawing.Point(12, 39);
            this.w_lTitle.Name = "w_lTitle";
            this.w_lTitle.Size = new System.Drawing.Size(542, 46);
            this.w_lTitle.TabIndex = 0;
            this.w_lTitle.Text = "ExtraCopy";
            this.w_lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // w_bInstall
            // 
            this.w_bInstall.Font = new System.Drawing.Font("Neuropol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_bInstall.Location = new System.Drawing.Point(202, 158);
            this.w_bInstall.Name = "w_bInstall";
            this.w_bInstall.Size = new System.Drawing.Size(152, 37);
            this.w_bInstall.TabIndex = 1;
            this.w_bInstall.Text = "Install";
            this.w_bInstall.UseVisualStyleBackColor = true;
            this.w_bInstall.Click += new System.EventHandler(this.w_bInstall_Click);
            // 
            // w_bClose
            // 
            this.w_bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.w_bClose.Font = new System.Drawing.Font("Neuropol", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_bClose.Location = new System.Drawing.Point(202, 308);
            this.w_bClose.Name = "w_bClose";
            this.w_bClose.Size = new System.Drawing.Size(152, 37);
            this.w_bClose.TabIndex = 2;
            this.w_bClose.Text = "Close";
            this.w_bClose.UseVisualStyleBackColor = true;
            this.w_bClose.Click += new System.EventHandler(this.w_bClose_Click);
            // 
            // w_bRemove
            // 
            this.w_bRemove.Font = new System.Drawing.Font("Neuropol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.w_bRemove.Location = new System.Drawing.Point(202, 201);
            this.w_bRemove.Name = "w_bRemove";
            this.w_bRemove.Size = new System.Drawing.Size(152, 37);
            this.w_bRemove.TabIndex = 3;
            this.w_bRemove.Text = "Remove";
            this.w_bRemove.UseVisualStyleBackColor = true;
            this.w_bRemove.Visible = false;
            this.w_bRemove.Click += new System.EventHandler(this.w_bRemove_Click);
            // 
            // AutoRunWindow
            // 
            this.AcceptButton = this.w_bInstall;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.w_bClose;
            this.ClientSize = new System.Drawing.Size(566, 429);
            this.Controls.Add(this.w_bRemove);
            this.Controls.Add(this.w_bClose);
            this.Controls.Add(this.w_bInstall);
            this.Controls.Add(this.w_lTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoRunWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExtraCopy 1.0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label w_lTitle;
        private System.Windows.Forms.Button w_bInstall;
        private System.Windows.Forms.Button w_bClose;
        private System.Windows.Forms.Button w_bRemove;
    }
}