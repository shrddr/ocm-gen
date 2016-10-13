namespace ocm_gen
{
    partial class Form1
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
            this.treeViewRoutines = new System.Windows.Forms.TreeView();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonCloneAIn = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.treeViewGlobalTags = new System.Windows.Forms.TreeView();
            this.treeViewLocalTags = new System.Windows.Forms.TreeView();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxJSR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCloneDIn = new System.Windows.Forms.Button();
            this.buttonCloneValveMO = new System.Windows.Forms.Button();
            this.buttonCloneMotor = new System.Windows.Forms.Button();
            this.buttonCloneValveSO = new System.Windows.Forms.Button();
            this.buttonCloneRoutine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeViewRoutines.Location = new System.Drawing.Point(11, 41);
            this.treeViewRoutines.Name = "treeView1";
            this.treeViewRoutines.Size = new System.Drawing.Size(119, 354);
            this.treeViewRoutines.TabIndex = 0;
            this.treeViewRoutines.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(378, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonCloneAIn
            // 
            this.buttonCloneAIn.Enabled = false;
            this.buttonCloneAIn.Location = new System.Drawing.Point(459, 12);
            this.buttonCloneAIn.Name = "buttonCloneAIn";
            this.buttonCloneAIn.Size = new System.Drawing.Size(75, 23);
            this.buttonCloneAIn.TabIndex = 3;
            this.buttonCloneAIn.Text = "Clone AIn";
            this.buttonCloneAIn.UseVisualStyleBackColor = true;
            this.buttonCloneAIn.Click += new System.EventHandler(this.buttonCloneAIn_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(1042, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // treeView2
            // 
            this.treeViewGlobalTags.Location = new System.Drawing.Point(136, 41);
            this.treeViewGlobalTags.Name = "treeView2";
            this.treeViewGlobalTags.Size = new System.Drawing.Size(121, 354);
            this.treeViewGlobalTags.TabIndex = 5;
            // 
            // treeView3
            // 
            this.treeViewLocalTags.Location = new System.Drawing.Point(263, 41);
            this.treeViewLocalTags.Name = "treeView3";
            this.treeViewLocalTags.Size = new System.Drawing.Size(249, 354);
            this.treeViewLocalTags.TabIndex = 6;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(569, 70);
            this.textBoxNew.Multiline = true;
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(100, 325);
            this.textBoxNew.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Routines";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Globals";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Locals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Clones:";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(569, 44);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(100, 20);
            this.textBoxSource.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(521, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Source:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(675, 70);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(218, 325);
            this.textBoxLog.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(675, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Log:";
            // 
            // textBoxJSR
            // 
            this.textBoxJSR.Location = new System.Drawing.Point(899, 70);
            this.textBoxJSR.Multiline = true;
            this.textBoxJSR.Name = "textBoxJSR";
            this.textBoxJSR.Size = new System.Drawing.Size(218, 325);
            this.textBoxJSR.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(905, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "JSRs:";
            // 
            // buttonCloneDIn
            // 
            this.buttonCloneDIn.Enabled = false;
            this.buttonCloneDIn.Location = new System.Drawing.Point(526, 12);
            this.buttonCloneDIn.Name = "buttonCloneDIn";
            this.buttonCloneDIn.Size = new System.Drawing.Size(75, 23);
            this.buttonCloneDIn.TabIndex = 18;
            this.buttonCloneDIn.Text = "Clone DIn";
            this.buttonCloneDIn.UseVisualStyleBackColor = true;
            this.buttonCloneDIn.Click += new System.EventHandler(this.buttonCloneDIn_Click);
            // 
            // buttonCloneValveMO
            // 
            this.buttonCloneValveMO.Enabled = false;
            this.buttonCloneValveMO.Location = new System.Drawing.Point(594, 12);
            this.buttonCloneValveMO.Name = "buttonCloneValveMO";
            this.buttonCloneValveMO.Size = new System.Drawing.Size(75, 23);
            this.buttonCloneValveMO.TabIndex = 19;
            this.buttonCloneValveMO.Text = "Clone VMO";
            this.buttonCloneValveMO.UseVisualStyleBackColor = true;
            this.buttonCloneValveMO.Click += new System.EventHandler(this.buttonCloneValveMO_Click);
            // 
            // buttonCloneMotor
            // 
            this.buttonCloneMotor.Enabled = false;
            this.buttonCloneMotor.Location = new System.Drawing.Point(663, 12);
            this.buttonCloneMotor.Name = "buttonCloneMotor";
            this.buttonCloneMotor.Size = new System.Drawing.Size(75, 23);
            this.buttonCloneMotor.TabIndex = 20;
            this.buttonCloneMotor.Text = "Clone Motor";
            this.buttonCloneMotor.UseVisualStyleBackColor = true;
            this.buttonCloneMotor.Click += new System.EventHandler(this.buttonCloneMotor_Click);
            // 
            // buttonCloneValveSO
            // 
            this.buttonCloneValveSO.Enabled = false;
            this.buttonCloneValveSO.Location = new System.Drawing.Point(732, 12);
            this.buttonCloneValveSO.Name = "buttonCloneValveSO";
            this.buttonCloneValveSO.Size = new System.Drawing.Size(75, 23);
            this.buttonCloneValveSO.TabIndex = 21;
            this.buttonCloneValveSO.Text = "Clone VSO";
            this.buttonCloneValveSO.UseVisualStyleBackColor = true;
            this.buttonCloneValveSO.Click += new System.EventHandler(this.buttonCloneValveSO_Click);
            // 
            // buttonCloneRoutine
            // 
            this.buttonCloneRoutine.Enabled = false;
            this.buttonCloneRoutine.Location = new System.Drawing.Point(830, 12);
            this.buttonCloneRoutine.Name = "buttonCloneRoutine";
            this.buttonCloneRoutine.Size = new System.Drawing.Size(96, 23);
            this.buttonCloneRoutine.TabIndex = 22;
            this.buttonCloneRoutine.Text = "Clone ROUTINE";
            this.buttonCloneRoutine.UseVisualStyleBackColor = true;
            this.buttonCloneRoutine.Click += new System.EventHandler(this.buttonCloneRoutine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 415);
            this.Controls.Add(this.buttonCloneRoutine);
            this.Controls.Add(this.buttonCloneValveSO);
            this.Controls.Add(this.buttonCloneMotor);
            this.Controls.Add(this.buttonCloneValveMO);
            this.Controls.Add(this.buttonCloneDIn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxJSR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNew);
            this.Controls.Add(this.treeViewLocalTags);
            this.Controls.Add(this.treeViewGlobalTags);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCloneAIn);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.treeViewRoutines);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewRoutines;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonCloneAIn;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TreeView treeViewGlobalTags;
        private System.Windows.Forms.TreeView treeViewLocalTags;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxJSR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCloneDIn;
        private System.Windows.Forms.Button buttonCloneValveMO;
        private System.Windows.Forms.Button buttonCloneMotor;
        private System.Windows.Forms.Button buttonCloneValveSO;
        private System.Windows.Forms.Button buttonCloneRoutine;
    }
}

