using Project.Tech.OpenSky.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Tech.OpenSky.Model;
using Project.Tech.OpenSky.Entities;

namespace Project.Tech.OpenSky.Ui
{
    public partial class Form1 : Form
    {

        Request request = new Request();
        public Form1()
        {
            InitializeComponent();

        }

        public void button1_Click(object sender, EventArgs e)
        {
            request.HandlerEventOpenSky += HttpHandlerUpdate;
            request.AutoRequset();
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowLowsetFlighDetailsUI();
        }
        private void HighetFlight_Click(object sender, EventArgs e)
        {
            ShowHighetFlightDetailsUI();
        }
        private void StopAutoRunning_Click(object sender, EventArgs e)
        {
            request.HandlerEventStopAutoRunning +=StopToRunAtou ;
            request.StopRunning();
        }
        public void StopToRunAtou()
        {
            request.RunToStop = false;
            MessageBox.Show("Stopping The Program");
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Items.Clear();

            var name = listView1.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < request.AllDataOpenSkey.Count; i++)
            {
                if (request.AllDataOpenSkey[i].origin_country.ToString() == name)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].icao24 + "," + request.AllDataOpenSkey[i].origin_country }));

                }
            };
        }
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView3.Items.Clear();

            var name = listView2.SelectedItems[0].SubItems[0].Text;
            for (int i = 0; i < request.AllDataOpenSkey.Count; i++)
            {
                if (request.AllDataOpenSkey[i].icao24 == name.Split(',')[0])
                {
                    listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].icao24 }));
                    listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].origin_country }));
                    listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].longitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].latitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].baro_altitude.ToString() }));
                    break;
                }
            };
        }
        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Items.Clear();

            var name = listView4.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < request.AllDataOpenSkey.Count; i++)
            {
                if (request.AllDataOpenSkey[i].origin_country.ToString() == name)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkey[i].icao24 + "," + request.AllDataOpenSkey[i].origin_country }));

                }
            };
        }

        private void ShowLowsetFlighDetailsUI()
        {
         
                listView3.Clear();
                listView3.View = View.Details;
                listView3.Columns.Add("List");
                List<OpenSkyDetails> LowsetFlight = request.LowsetFlighDetails();
                for (int i = 0; i < LowsetFlight.Count; i++)
                {
                    listView3.Items.Add(new ListViewItem(new string[] { LowsetFlight[i].icao24 }));
                    listView3.Items.Add(new ListViewItem(new string[] { LowsetFlight[i].origin_country }));
                    listView3.Items.Add(new ListViewItem(new string[] { LowsetFlight[i].longitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { LowsetFlight[i].latitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { LowsetFlight[i].baro_altitude.ToString() }));
                }
            
        }
        private void ShowHighetFlightDetailsUI()
        {
           
                listView3.Clear();
                listView3.View = View.Details;
                listView3.Columns.Add("List");
                List<OpenSkyDetails> HighetFlight = request.HighetFlightDetails();
                for (int i = 0; i < HighetFlight.Count; i++)
                {
                    listView3.Items.Add(new ListViewItem(new string[] { HighetFlight[i].icao24 }));
                    listView3.Items.Add(new ListViewItem(new string[] { HighetFlight[i].origin_country }));
                    listView3.Items.Add(new ListViewItem(new string[] { HighetFlight[i].longitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { HighetFlight[i].latitude.ToString() }));
                    listView3.Items.Add(new ListViewItem(new string[] { HighetFlight[i].baro_altitude.ToString() }));
                }
           
        }
        private void HttpHandlerUpdate()
        {
     
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new Action(() =>
                {
                    ShowUICountries();
                }));
                listView4.Invoke(new Action(() =>
                {
                    ShowUIFiveTopCountries();
                }));
                label1.Invoke(new Action(() =>
                  {
                      label1.Visible = true;
                      label1.Text = request.LengthCountries().ToString();
                  }));
                
                label2.Invoke(new Action(() =>
                {
                    label2.Visible = true;
                    label2.Text = request.Time().ToString();
                }));
            }
            else
            {
                ShowUIFiveTopCountries();
                ShowUICountries();
                label1.Text = request.LengthCountries().ToString();
                label2.Text = request.Time().ToString();
            }
           

        }
        private void ShowUIFiveTopCountries()
        {
            listView4.Clear();
            listView4.View = View.Details;
            listView4.Columns.Add("Top 5 Countries");
            var nameCountry = request.FiveTopFlights();
            for (int i = 0; i < nameCountry.Count; i++)
            {

                listView4.Items.Add(new ListViewItem(new string[] { nameCountry[i] }));

            }
        }
        private void ShowUICountries()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("List");
            var listname = request.GetAllCountries();
            for (int i = 0; i < listname.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { listname[i].ToString() }));
            }
        }

       
    }

}

