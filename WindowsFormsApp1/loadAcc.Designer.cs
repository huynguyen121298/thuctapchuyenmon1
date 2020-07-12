namespace WindowsFormsApp1
{
    partial class loadAcc
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.bntDong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(26, 32);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(432, 331);
            this.dgv1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Image = global::WindowsFormsApp1.Properties.Resources.btn_add;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnThem.Location = new System.Drawing.Point(516, 39);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(209, 49);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Tạo tài khoản mới cho user";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::WindowsFormsApp1.Properties.Resources.btn_delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnXoa.Location = new System.Drawing.Point(630, 175);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 49);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::WindowsFormsApp1.Properties.Resources.edit;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSua.Location = new System.Drawing.Point(474, 230);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 46);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // bntDong
            // 
            this.bntDong.Image = global::WindowsFormsApp1.Properties.Resources.logout;
            this.bntDong.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntDong.Location = new System.Drawing.Point(630, 230);
            this.bntDong.Name = "bntDong";
            this.bntDong.Size = new System.Drawing.Size(95, 46);
            this.bntDong.TabIndex = 18;
            this.bntDong.Text = "Đóng";
            this.bntDong.UseVisualStyleBackColor = true;
            this.bntDong.Click += new System.EventHandler(this.bntDong_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 50);
            this.button1.TabIndex = 19;
            this.button1.Text = "Làm Mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntDong);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgv1);
            this.Name = "loadAcc";
            this.Text = "loadAcc";
            this.Load += new System.EventHandler(this.loadAcc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button bntDong;
        private System.Windows.Forms.Button button1;
    }
}