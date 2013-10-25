using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace FilterAdmin {
    public partial class Admin : Form {
        private Logic lg;
        private List<Woord> woorden;
        private string newHashtag;

        public Admin() {
            InitializeComponent();
            lg = new Logic();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            this.dataGridViewWoorden.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void buttonDirectory_Click(object sender, EventArgs e) {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                lg.SetFolder(folderBrowserDialog1.SelectedPath);
                woorden = lg.GetWoorden();
                foreach (Woord w in woorden) {
                    dataGridViewWoorden.Rows.Insert(0, w);
                }
                textBoxHuidig.Text = lg.GetHashtag();
                buttonOpslaan.Enabled = true;
                textBoxHashtag.Enabled = true;
                dataGridViewWoorden.Enabled = true;
                labelFolder.Visible = false;
            }
        }

        private void buttonOpslaan_Click(object sender, EventArgs e) {
            woorden.Clear();
            newHashtag = textBoxHashtag.Text;

            foreach (DataGridViewRow row in dataGridViewWoorden.Rows) {
                if (Convert.ToString(row.Cells[0].Value) != string.Empty) {
                    woorden.Add(new Woord(row.Cells[0].Value.ToString()));
                }
            }

            lg.SetWoorden(woorden);

            if (newHashtag != string.Empty) {
                lg.SetHashtag(newHashtag);
            }
            else { lg.SetHashtag(textBoxHuidig.Text); }
        }
    }
}
