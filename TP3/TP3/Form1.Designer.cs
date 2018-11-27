namespace TP3
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
            this.btnAjouter = new System.Windows.Forms.Button();
            this.versl2 = new System.Windows.Forms.Button();
            this.versl1 = new System.Windows.Forms.Button();
            this.txtbox = new System.Windows.Forms.TextBox();
            this.list1 = new System.Windows.Forms.ListBox();
            this.list2 = new System.Windows.Forms.ListBox();
            this.effacer1 = new System.Windows.Forms.Button();
            this.effacerl2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(527, 59);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.button1_Click);
            // 
            // versl2
            // 
            this.versl2.Location = new System.Drawing.Point(312, 148);
            this.versl2.Name = "versl2";
            this.versl2.Size = new System.Drawing.Size(75, 23);
            this.versl2.TabIndex = 1;
            this.versl2.Text = "Vers L2 >>";
            this.versl2.UseVisualStyleBackColor = true;
            this.versl2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // versl1
            // 
            this.versl1.Location = new System.Drawing.Point(312, 218);
            this.versl1.Name = "versl1";
            this.versl1.Size = new System.Drawing.Size(75, 23);
            this.versl1.TabIndex = 2;
            this.versl1.Text = "<< Vers L1";
            this.versl1.UseVisualStyleBackColor = true;
            this.versl1.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbox
            // 
            this.txtbox.Location = new System.Drawing.Point(103, 59);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(401, 20);
            this.txtbox.TabIndex = 3;
            // 
            // list1
            // 
            this.list1.FormattingEnabled = true;
            this.list1.Location = new System.Drawing.Point(103, 112);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(120, 160);
            this.list1.TabIndex = 4;
            this.list1.SelectedIndexChanged += new System.EventHandler(this.list1_SelectedIndexChanged);
            // 
            // list2
            // 
            this.list2.FormattingEnabled = true;
            this.list2.Location = new System.Drawing.Point(482, 112);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(120, 160);
            this.list2.TabIndex = 5;
            this.list2.SelectedIndexChanged += new System.EventHandler(this.list2_SelectedIndexChanged);
            // 
            // effacer1
            // 
            this.effacer1.Location = new System.Drawing.Point(126, 296);
            this.effacer1.Name = "effacer1";
            this.effacer1.Size = new System.Drawing.Size(75, 23);
            this.effacer1.TabIndex = 6;
            this.effacer1.Text = "Effacer";
            this.effacer1.UseVisualStyleBackColor = true;
            this.effacer1.Click += new System.EventHandler(this.button3_Click);
            // 
            // effacerl2
            // 
            this.effacerl2.Location = new System.Drawing.Point(507, 296);
            this.effacerl2.Name = "effacerl2";
            this.effacerl2.Size = new System.Drawing.Size(75, 23);
            this.effacerl2.TabIndex = 7;
            this.effacerl2.Text = "Effacer";
            this.effacerl2.UseVisualStyleBackColor = true;
            this.effacerl2.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 366);
            this.Controls.Add(this.effacerl2);
            this.Controls.Add(this.effacer1);
            this.Controls.Add(this.list2);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.versl1);
            this.Controls.Add(this.versl2);
            this.Controls.Add(this.btnAjouter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button versl2;
        private System.Windows.Forms.Button versl1;
        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.ListBox list1;
        private System.Windows.Forms.ListBox list2;
        private System.Windows.Forms.Button effacer1;
        private System.Windows.Forms.Button effacerl2;
    }
}

