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
            request.HandlerEventOpenSkyUpdate += HttpHandlerUpdate;
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
            request.HandlerEventStopAutoRunning += StopToRunAtou;
            request.StopRunning();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Flights", 150);
            string countryName = listView1.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
            {
                if (request.AllDataOpenSkeyDetails[i].origin_country.ToString() == countryName)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].icao24 + "," + request.AllDataOpenSkeyDetails[i].origin_country }));

                }
            };
        }
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView3.Clear();
            listView3.View = View.Details;
            listView3.Columns.Add("List Details", 150);
            var numberFlight = listView2.SelectedItems[0].SubItems[0].Text;
            for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
            {
                if (request.AllDataOpenSkeyDetails[i].icao24 != numberFlight.Split(',')[0])
                {
                    continue;
                }
                listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].icao24 }));
                listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].origin_country }));
                listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].longitude.ToString() }));
                listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].latitude.ToString() }));
                listView3.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].baro_altitude.ToString() }));
                break;
            };
        }
        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Flights", 150);
            var countryName = listView4.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
            {
                if (request.AllDataOpenSkeyDetails[i].origin_country.ToString() == countryName)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { request.AllDataOpenSkeyDetails[i].icao24 + "," + request.AllDataOpenSkeyDetails[i].origin_country }));

                }
            };
        }

        private void ShowFiveTopCountriesUI()
        {
            listView4.Clear();
            listView4.View = View.Details;
            listView4.Columns.Add("Top 5 Countries", 100);
            var nameCountry = request.FiveTopFlights();
            for (int i = 0; i < nameCountry.Count; i++)
            {
                listView4.Items.Add(new ListViewItem(new string[] { nameCountry[i] }));
            }
        }
        private void ShowCountriesUI()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("List All Name Countries", 100);
            var listscountriesName = request.GetAllCountries();
            for (int i = 0; i < listscountriesName.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { listscountriesName[i].ToString() }));
            }
        }
        private void ShowLowsetFlighDetailsUI()
        {

            listView3.Clear();
            listView3.View = View.Details;
            listView3.Columns.Add("List Details", 100);
            List<OpenSkyDetails> LowsetFlight = request.LowsetFlightDetails();
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
            listView3.Columns.Add("List Details", 100);
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
            // לשאול את המרצה עם צריך INVOKE
            if (listView1.InvokeRequired)
            {
                listView1.Invoke(new Action(() =>
                {
                    ShowCountriesUI();
                }));
                listView4.Invoke(new Action(() =>
                {
                    ShowFiveTopCountriesUI();
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
                ShowFiveTopCountriesUI();
                ShowCountriesUI();
                label1.Text = request.LengthCountries().ToString();
                label2.Text = request.Time().ToString();
            }
        }
        public void StopToRunAtou()
        {
            request.Running = false;
            MessageBox.Show("Stopping The Program");
        }


    }

}

