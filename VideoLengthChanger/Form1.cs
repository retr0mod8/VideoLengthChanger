﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoLengthChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void Start_Click(object sender, EventArgs e)
        {
            uint Length = 0;
            string hours = Hours.Text;
            string minutes = Minutes.Text;
            string seconds = Minutes.Text;
            if (PublicFunctions.FrontendFunctions.CheckAndCalculateInput(hours, minutes, seconds))
                {
                Length += Convert.ToUInt32(seconds);
                Length += (Convert.ToUInt32(minutes)) * 60;
                Length += (Convert.ToUInt32(hours)) * 3600;
                PublicVariables.InputTime = Length;

                Start.Enabled = false; //Debounce
                Hours.ReadOnly = true; //Ditto
                bool WhileLoop = true;

                PublicFunctions.FrontendFunctions.EditData();
                while (WhileLoop){ //constantly check if the edit data job is done.
                    if (PublicVariables.EditDataFinished == true){
                        DialogResult dialogResult = MessageBox.Show("Video length has successfully been changed!");
                        WhileLoop = false;
                        Start.Enabled = true;
                        Hours.ReadOnly = false;
                    }

                }
                
            }
            else
            {
                MessageBox.Show("Invalid Number!");
            }
        }

        public void Browse(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = ".mp4 Files (*.mp4*)|*.mp4*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                PublicVariables.filelocation = choofdlog.FileName;
                LocationText.Text = choofdlog.SafeFileName;
                PublicVariables.EditDataFinished = false;
                PublicFunctions.FrontendFunctions.getHeaderOffset();
                /*PublicFunctions.FrontendFunctions.getVideoLength();
                if (PublicVariables.seconds >= 0){
                    IncPerSecond.Text = PublicVariables.seconds.ToString();
                }
                else
                {
                    IncPerSecond.Text = "N/A";
                }
                */
                Start.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void NewCustom_TextChanged(object sender, EventArgs e)
        {

        }

        private void LocationText_TextChanged(object sender, EventArgs e)
        {

        }

        private void IncPerSecond_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCzK5RJAGlfXoRfK4Hfgx9jw");
        }
        private void VisitSource()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel2.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start("https://github.com/retr0mod8/VideoLengthChanger");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }

    public class VisualFunctions {
        static void ChangeVideoLengthTextBox()
        {
            
        }
    }

}
