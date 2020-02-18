using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace gridfixerc
{
    public partial class Gridfixer : Form
    {
        public Gridfixer()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (pathin.Text == "" || pathout.Text == "")
            {
                MessageBox.Show(this, "You need to set an input/output file!",
                                   "Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            else
            {
                output1.Clear();
                output2.Clear();

                string[] lignes = File.ReadAllLines(pathin.Text);
                int i = 0;
                string save = "";

                progressBar1.Visible = true;
                progressBar1.Minimum = 1;
                progressBar1.Maximum = lignes.Length;
                progressBar1.Value = 1;
                progressBar1.Step = 1;

                progressLabel.Text = "1/" + lignes.Length;
                progressLabel.Refresh();
                foreach (string ligne in lignes)
                {
                    if (ligne.Contains("plane"))
                    {
                        output1.Text += ligne.Substring(3) + "\r\n";
                        lignes[i] = Planeligne(ligne);
                    }
                    else if (ligne.Contains("uaxis"))
                    {
                        output1.Text += ligne.Substring(3) + "\r\n";
                        lignes[i] = UAxisligne(ligne);
                    }
                    else if (ligne.Contains("vaxis"))
                    {
                        output1.Text += ligne.Substring(3) + "\r\n";
                        lignes[i] = VAxisligne(ligne);

                        output1.Text += "\r\n";
                        output2.Text += "\r\n";
                    }
                    save = save + lignes[i] + "\r\n";
                    i += 1;

                    progressBar1.PerformStep();
                    progressLabel.Text = i + "/" + lignes.Length;
                    progressLabel.Refresh();
                }

                StreamWriter sw = new StreamWriter(this.pathout.Text);
                sw.Write(save);
                sw.Close();
                MessageBox.Show(this, "Succesfully fixed the vmf file ! Saved in " + pathout.Text,
                                       "Notification", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }
        }

        private string Planeligne(string ligne)
        {
            // "plane" "(-576 192 0) (-576 64 0) (-384 64 0)"
            // "uaxis" "[0.433013 0.5 -0.75 -0.615784] 0.25"
            // "vaxis" "[-0.866025 0 -0.5 -14.7688] 0.25"

            string plane = "\t\t\t\"plane\" \"(";
            string[] stringSeparators = new string[] { ") (", " ", ")\"" };
            ligne = ligne.Substring(13);

            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };

            string[] groupede3 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede3) { 
                double result = Convert.ToDouble(groupede3[n],provider);
               
                double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                groupede3[n] = nombre.ToString();
                n += 1;
            }

            ligne = plane + groupede3[0] + " " + groupede3[1] + " " + groupede3[2] + ") ";
            ligne += "(" + groupede3[3] + " " + groupede3[4] + " " + groupede3[5] + ") ";
            ligne += "(" + groupede3[6] + " " + groupede3[7] + " " + groupede3[8] + ")\"";
            output2.Text += ligne.Substring(3) + "\r\n";

            return ligne;
        }
        private string UAxisligne(string ligne)
        {
            // "plane" "(-576 192 0) (-576 64 0) (-384 64 0)"
            // "uaxis" "[0.433013 0.5 -0.75 -0.615784] 0.25"
            // "vaxis" "[-0.866025 0 -0.5 -14.7688] 0.25"

            string uaxis = "\t\t\t\"uaxis\" \"[";
            string[] stringSeparators = new string[] { " ", "]", "\"" };
            ligne = ligne.Substring(13);

            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };

            string[] groupede4 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede4)
            {
                if (n < 4)
                {
                    double result = Convert.ToDouble(groupede4[n], provider);

                    double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                    groupede4[n] = nombre.ToString();
                }
                n += 1;
            }

            ligne = uaxis + groupede4[0] + " " + groupede4[1] + " " + groupede4[2] + " ";
            ligne += groupede4[3] + "] " + groupede4[4] + "\"";
            output2.Text += ligne.Substring(3) + "\r\n";

            return ligne;
        }
        private string VAxisligne(string ligne)
        {
            // "plane" "(-576 192 0) (-576 64 0) (-384 64 0)"
            // "uaxis" "[0.433013 0.5 -0.75 -0.615784] 0.25"
            // "vaxis" "[-0.866025 0 -0.5 -14.7688] 0.25"

            string vaxis = "\t\t\t\"vaxis\" \"[";
            string[] stringSeparators = new string[] { " ", "]", "\"" };
            ligne = ligne.Substring(13);

            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };

            string[] groupede4 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede4)
            {
                if (n < 4)
                {
                    double result = Convert.ToDouble(groupede4[n], provider);

                    double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                    groupede4[n] = nombre.ToString();
                }
                n += 1;
            }

            ligne = vaxis + groupede4[0] + " " + groupede4[1] + " " + groupede4[2] + " ";
            ligne += groupede4[3] + "] " + groupede4[4] + "\"";
            output2.Text += ligne.Substring(3) + "\r\n";

            return ligne;
        }

        private void File_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose a vmf to fix";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "VMF (*.vmf)|*.vmf";
            openFileDialog1.FileName = "";
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    pathin.Text = openFileDialog1.FileName;
                    if (pathout.Text == "")
                        pathout.Text = Path.GetDirectoryName(openFileDialog1.FileName) + '\\' + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_fix.vmf";
                }
                catch (IOException)
                {
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save destination";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "VMF (*.vmf)|*.vmf";
            if (pathin.Text != "")
                saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(pathin.Text) + "_fix.vmf";
            else
                saveFileDialog1.FileName = "";
            saveFileDialog1.RestoreDirectory = true;
            DialogResult result = saveFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    pathout.Text = saveFileDialog1.FileName;
                }
                catch (IOException)
                {
                }
            }
        }

        private void Gridfixer_Load(object sender, EventArgs e)
        {

        }
    }
}
