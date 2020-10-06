namespace CopyFilesWF
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lFrom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bPathFrom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bTo = new System.Windows.Forms.Button();
            this.lTo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bCopy = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Location = new System.Drawing.Point(6, 27);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(33, 13);
            this.lFrom.TabIndex = 0;
            this.lFrom.Text = "From:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.bPathFrom);
            this.groupBox1.Controls.Add(this.lFrom);
            this.groupBox1.Location = new System.Drawing.Point(23, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 225);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy Files From:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 121);
            this.listBox1.TabIndex = 6;
            // 
            // bPathFrom
            // 
            this.bPathFrom.Location = new System.Drawing.Point(19, 49);
            this.bPathFrom.Name = "bPathFrom";
            this.bPathFrom.Size = new System.Drawing.Size(75, 23);
            this.bPathFrom.TabIndex = 5;
            this.bPathFrom.Text = "Path From";
            this.bPathFrom.UseVisualStyleBackColor = true;
            this.bPathFrom.Click += new System.EventHandler(this.BPathFrom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.bTo);
            this.groupBox2.Controls.Add(this.lTo);
            this.groupBox2.Location = new System.Drawing.Point(423, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 215);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Copy Files To:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 71);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(264, 121);
            this.listBox2.TabIndex = 7;
            // 
            // bTo
            // 
            this.bTo.Location = new System.Drawing.Point(12, 42);
            this.bTo.Name = "bTo";
            this.bTo.Size = new System.Drawing.Size(75, 23);
            this.bTo.TabIndex = 3;
            this.bTo.Text = "Path To";
            this.bTo.UseVisualStyleBackColor = true;
            this.bTo.Click += new System.EventHandler(this.BTo_Click);
            // 
            // lTo
            // 
            this.lTo.AutoSize = true;
            this.lTo.Location = new System.Drawing.Point(6, 17);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(23, 13);
            this.lTo.TabIndex = 0;
            this.lTo.Text = "To:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bCopy);
            this.groupBox3.Location = new System.Drawing.Point(318, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(90, 214);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(22, 112);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(58, 30);
            this.bCopy.TabIndex = 0;
            this.bCopy.Text = "Copy";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.BCopy_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 263);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(640, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 288);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form";
            this.Text = "Copy Files";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bPathFrom;
        private System.Windows.Forms.Button bTo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

