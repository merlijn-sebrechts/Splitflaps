using System;
using System.Windows.Forms;
using SplitflapsFrontend.Datalayer;
using SplitflapsFrontend.Overkoepelend;

namespace SplitflapsFrontend.presentationlayer
{
    public partial class Form1 : Form
    {
        private TwitterController twitterController;
        private SplitflapController splitflapController;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            twitterController = new TwitterController();
            labelTweet.Text = twitterController.CurrentTweet.Text;
            labelUsername.Text = twitterController.CurrentTweet.User;
            textBoxSearchQuery.Text = twitterController.Query;

            splitflapController = new SplitflapController();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.splitflapController.Show(twitterController.CurrentTweet.Text);
        }

        private void buttonDecline_Click(object sender, EventArgs e)
        {
            this.twitterController.NextTweet();
            labelTweet.Text = twitterController.CurrentTweet.Text;
            labelUsername.Text = twitterController.CurrentTweet.User;
        }

        private void buttonChangeSearchQuery_Click(object sender, EventArgs e)
        {
            twitterController.Query = textBoxSearchQuery.Text;
        }


    }
}
