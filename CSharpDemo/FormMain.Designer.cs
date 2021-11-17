namespace CSharpDemo
{
    partial class FormMain
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
            this.BTN_01 = new System.Windows.Forms.Button();
            this.BTN_02 = new System.Windows.Forms.Button();
            this.BTN_03 = new System.Windows.Forms.Button();
            this.BTN_04 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_01
            // 
            this.BTN_01.Location = new System.Drawing.Point(12, 12);
            this.BTN_01.Name = "BTN_01";
            this.BTN_01.Size = new System.Drawing.Size(114, 71);
            this.BTN_01.TabIndex = 0;
            this.BTN_01.Text = "写Excel文件";
            this.BTN_01.UseVisualStyleBackColor = true;
            this.BTN_01.Click += new System.EventHandler(this.BTN_01_Click);
            // 
            // BTN_02
            // 
            this.BTN_02.Location = new System.Drawing.Point(132, 12);
            this.BTN_02.Name = "BTN_02";
            this.BTN_02.Size = new System.Drawing.Size(114, 71);
            this.BTN_02.TabIndex = 1;
            this.BTN_02.Text = "甜甜圈图";
            this.BTN_02.UseVisualStyleBackColor = true;
            this.BTN_02.Click += new System.EventHandler(this.BTN_02_Click);
            // 
            // BTN_03
            // 
            this.BTN_03.Location = new System.Drawing.Point(252, 12);
            this.BTN_03.Name = "BTN_03";
            this.BTN_03.Size = new System.Drawing.Size(114, 71);
            this.BTN_03.TabIndex = 2;
            this.BTN_03.Text = "曲线图";
            this.BTN_03.UseVisualStyleBackColor = true;
            this.BTN_03.Click += new System.EventHandler(this.BTN_03_Click);
            // 
            // BTN_04
            // 
            this.BTN_04.Location = new System.Drawing.Point(372, 12);
            this.BTN_04.Name = "BTN_04";
            this.BTN_04.Size = new System.Drawing.Size(114, 71);
            this.BTN_04.TabIndex = 3;
            this.BTN_04.Text = "Excel To PDF";
            this.BTN_04.UseVisualStyleBackColor = true;
            this.BTN_04.Click += new System.EventHandler(this.BTN_04_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BTN_04);
            this.Controls.Add(this.BTN_03);
            this.Controls.Add(this.BTN_02);
            this.Controls.Add(this.BTN_01);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_01;
        private System.Windows.Forms.Button BTN_02;
        private System.Windows.Forms.Button BTN_03;
        private System.Windows.Forms.Button BTN_04;
    }
}