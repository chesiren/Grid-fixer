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
            this.start.Click += new System.EventHandler(this.start_Click);
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
            // Gridfixer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pathin);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.output1);
            this.Controls.Add(this.output2);
            this.Controls.Add(this.pathout);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label2);
            this.Name = "Gridfixer";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

