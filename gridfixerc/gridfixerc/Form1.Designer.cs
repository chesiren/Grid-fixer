namespace gridfixerc
{
    partial class Gridfixer
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gridfixer));
            this.pathout = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.pathin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.output2 = new System.Windows.Forms.RichTextBox();
            this.output1 = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.file = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathout
            // 
            resources.ApplyResources(this.pathout, "pathout");
            this.pathout.Name = "pathout";
            // 
            // start
            // 
            resources.ApplyResources(this.start, "start");
            this.start.Name = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // pathin
            // 
            resources.ApplyResources(this.pathin, "pathin");
            this.pathin.Name = "pathin";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // output2
            // 
            this.output2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.output2, "output2");
            this.output2.Name = "output2";
            this.output2.ReadOnly = true;
            // 
            // output1
            // 
            resources.ApplyResources(this.output1, "output1");
            this.output1.Name = "output1";
            this.output1.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // file
            // 
            resources.ApplyResources(this.file, "file");
            this.file.Name = "file";
            this.file.UseVisualStyleBackColor = true;
            this.file.Click += new System.EventHandler(this.File_Click);
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.Name = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // progressLabel
            // 
            resources.ApplyResources(this.progressLabel, "progressLabel");
            this.progressLabel.Name = "progressLabel";
            // 
            // Gridfixer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.file);
            this.Controls.Add(this.pathin);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.output1);
            this.Controls.Add(this.output2);
            this.Controls.Add(this.pathout);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label2);
            this.Name = "Gridfixer";
            this.Load += new System.EventHandler(this.Gridfixer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox pathout;
        internal System.Windows.Forms.Button start;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox pathin;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox output2;
        private System.Windows.Forms.RichTextBox output1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button file;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
    }
}

