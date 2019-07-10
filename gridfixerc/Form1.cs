using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void start_Click(object sender, EventArgs e)
        {
            output2.Clear();
            string[] lignes= File.ReadAllLines(pathin.Text);
            int i = 0;
            string save = "";
            foreach (string ligne in lignes)
            {
                if (ligne.Contains("plane"))
                {
                    output1.Text = output1.Text + ligne.Substring(3) + "\r\n";
                    lignes[i] = Planeligne(ligne);
                }
                if (ligne.Contains("uaxis"))
                {
                    output1.Text = output1.Text + ligne.Substring(3) + "\r\n";
                    lignes[i] = UAxisligne(ligne);
                }
                if (ligne.Contains("vaxis"))
                {
                    output1.Text = output1.Text + ligne.Substring(3) + "\r\n";
                    lignes[i] = VAxisligne(ligne);

                    output1.Text = output1.Text + "\r\n";
                    output2.Text = output2.Text + "\r\n";
                }
                save = save + lignes[i] + "\r\n";
                i += 1;
            }
            StreamWriter sw = new StreamWriter(this.pathout.Text);
            sw.Write(save);
            sw.Close();
            MessageBox.Show(this, "Succesfully fixed the vmf file ! Saved in " + pathout.Text,
                                   "Notification", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
        }


        private string Planeligne(string ligne)
        {
            // "plane" "(-576 192 0) (-576 64 0) (-384 64 0)"
            // "uaxis" "[0.433013 0.5 -0.75 -0.615784] 0.25"
            // "vaxis" "[-0.866025 0 -0.5 -14.7688] 0.25"

            string plane = "\t\t\t\"plane\" \"(";
            string[] stringSeparators = new string[] { ") (", " ", ")\"" };
            ligne = ligne.Substring(13);
            
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            string[] groupede3;
            groupede3 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede3) { 
                double result;
                result = Convert.ToDouble(groupede3[n],provider);
               
                double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                groupede3[n] = nombre.ToString();
                n = n + 1;
            }

            ligne = plane + groupede3[0] + " " + groupede3[1] + " " + groupede3[2] + ") ";
            ligne += "(" + groupede3[3] + " " + groupede3[4] + " " + groupede3[5] + ") ";
            ligne += "(" + groupede3[6] + " " + groupede3[7] + " " + groupede3[8] + ")\"";
            output2.Text = output2.Text + ligne.Substring(3) + "\r\n";

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

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            string[] groupede4;
            groupede4 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede4)
            {
                if (n < 4)
                {
                    double result;
                    result = Convert.ToDouble(groupede4[n], provider);

                    double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                    groupede4[n] = nombre.ToString();
                }
                n = n + 1;
            }

            ligne = uaxis + groupede4[0] + " " + groupede4[1] + " " + groupede4[2] + " ";
            ligne += groupede4[3] + "] " + groupede4[4] + "\"";
            output2.Text = output2.Text + ligne.Substring(3) + "\r\n";

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

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            string[] groupede4;
            groupede4 = ligne.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            int n = 0;

            foreach (var element in groupede4)
            {
                if (n < 4)
                {
                    double result;
                    result = Convert.ToDouble(groupede4[n], provider);

                    double nombre = Math.Round(result, MidpointRounding.AwayFromZero);
                    groupede4[n] = nombre.ToString();
                }
                n = n + 1;
            }

            ligne = vaxis + groupede4[0] + " " + groupede4[1] + " " + groupede4[2] + " ";
            ligne += groupede4[3] + "] " + groupede4[4] + "\"";
            output2.Text = output2.Text + ligne.Substring(3) + "\r\n";

            return ligne;
        }

        // scroll bar sync
        public enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        public enum Message : uint
        {
            WM_VSCROLL = 0x0115
        }

        public enum ScrollBarCommands : uint
        {
            SB_THUMBPOSITION = 4
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private void myRichTextBox1_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(output1.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(output2.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
    }
}
