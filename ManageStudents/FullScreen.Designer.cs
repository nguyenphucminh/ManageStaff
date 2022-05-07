
namespace ManageStudents
{
    partial class FullScreen
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
            this.groupNhanVien = new System.Windows.Forms.GroupBox();
            this.pictureFS = new System.Windows.Forms.PictureBox();
            this.groupNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupNhanVien
            // 
            this.groupNhanVien.Controls.Add(this.pictureFS);
            this.groupNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNhanVien.Location = new System.Drawing.Point(0, 0);
            this.groupNhanVien.Name = "groupNhanVien";
            this.groupNhanVien.Size = new System.Drawing.Size(443, 423);
            this.groupNhanVien.TabIndex = 0;
            this.groupNhanVien.TabStop = false;
            this.groupNhanVien.Text = "Ảnh ";
            // 
            // pictureFS
            // 
            this.pictureFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureFS.Location = new System.Drawing.Point(3, 23);
            this.pictureFS.Name = "pictureFS";
            this.pictureFS.Size = new System.Drawing.Size(437, 397);
            this.pictureFS.TabIndex = 0;
            this.pictureFS.TabStop = false;
            // 
            // FullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 423);
            this.Controls.Add(this.groupNhanVien);
            this.Name = "FullScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picture FullScreen";
            this.Load += new System.EventHandler(this.FullScreen_Load);
            this.groupNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureFS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupNhanVien;
        private System.Windows.Forms.PictureBox pictureFS;
    }
}