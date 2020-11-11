
namespace ToDo.WinForms.Core
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbToDoItems = new System.Windows.Forms.CheckedListBox();
            this.btAddTask = new System.Windows.Forms.Button();
            this.btCompleted = new System.Windows.Forms.Button();
            this.btActive = new System.Windows.Forms.Button();
            this.btAll = new System.Windows.Forms.Button();
            this.tbLeftCounter = new System.Windows.Forms.Label();
            this.tbTask = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbToDoItems);
            this.panel1.Controls.Add(this.btAddTask);
            this.panel1.Controls.Add(this.btCompleted);
            this.panel1.Controls.Add(this.btActive);
            this.panel1.Controls.Add(this.btAll);
            this.panel1.Controls.Add(this.tbLeftCounter);
            this.panel1.Controls.Add(this.tbTask);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 436);
            this.panel1.TabIndex = 0;
            // 
            // lbToDoItems
            // 
            this.lbToDoItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbToDoItems.FormattingEnabled = true;
            this.lbToDoItems.Location = new System.Drawing.Point(12, 88);
            this.lbToDoItems.Name = "lbToDoItems";
            this.lbToDoItems.Size = new System.Drawing.Size(475, 268);
            this.lbToDoItems.TabIndex = 9;
            this.lbToDoItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbToDoItems_ItemCheck);
            // 
            // btAddTask
            // 
            this.btAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddTask.Location = new System.Drawing.Point(451, 38);
            this.btAddTask.Name = "btAddTask";
            this.btAddTask.Size = new System.Drawing.Size(36, 29);
            this.btAddTask.TabIndex = 8;
            this.btAddTask.Text = "+";
            this.btAddTask.UseVisualStyleBackColor = true;
            this.btAddTask.Click += new System.EventHandler(this.btAddTask_Click);
            // 
            // btCompleted
            // 
            this.btCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCompleted.Location = new System.Drawing.Point(353, 380);
            this.btCompleted.Name = "btCompleted";
            this.btCompleted.Size = new System.Drawing.Size(94, 29);
            this.btCompleted.TabIndex = 7;
            this.btCompleted.Text = "Completed";
            this.btCompleted.UseVisualStyleBackColor = true;
            this.btCompleted.Click += new System.EventHandler(this.btCompleted_Click);
            // 
            // btActive
            // 
            this.btActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btActive.Location = new System.Drawing.Point(253, 380);
            this.btActive.Name = "btActive";
            this.btActive.Size = new System.Drawing.Size(94, 29);
            this.btActive.TabIndex = 6;
            this.btActive.Text = "Active";
            this.btActive.UseVisualStyleBackColor = true;
            this.btActive.Click += new System.EventHandler(this.btActive_Click);
            // 
            // btAll
            // 
            this.btAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAll.Location = new System.Drawing.Point(153, 380);
            this.btAll.Name = "btAll";
            this.btAll.Size = new System.Drawing.Size(94, 29);
            this.btAll.TabIndex = 5;
            this.btAll.Text = "All";
            this.btAll.UseVisualStyleBackColor = true;
            this.btAll.Click += new System.EventHandler(this.btAll_Click);
            // 
            // tbLeftCounter
            // 
            this.tbLeftCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLeftCounter.AutoSize = true;
            this.tbLeftCounter.Location = new System.Drawing.Point(12, 380);
            this.tbLeftCounter.Name = "tbLeftCounter";
            this.tbLeftCounter.Size = new System.Drawing.Size(83, 20);
            this.tbLeftCounter.TabIndex = 4;
            this.tbLeftCounter.Text = "0 items left";
            // 
            // tbTask
            // 
            this.tbTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTask.Location = new System.Drawing.Point(199, 40);
            this.tbTask.Name = "tbTask";
            this.tbTask.Size = new System.Drawing.Size(246, 27);
            this.tbTask.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "What needs to be done?";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "todos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 436);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(517, 483);
            this.Name = "MainWindow";
            this.Text = "ToDo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCompleted;
        private System.Windows.Forms.Button btActive;
        private System.Windows.Forms.Button btAll;
        private System.Windows.Forms.Label tbLeftCounter;
        private System.Windows.Forms.Button btAddTask;
        private System.Windows.Forms.CheckedListBox lbToDoItems;
    }
}

