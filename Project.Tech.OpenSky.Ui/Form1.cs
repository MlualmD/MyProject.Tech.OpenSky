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
        private async void Refresh_Click(object sender, EventArgs e)
        {
            float left = float.Parse(Left.Text);
            float right = float.Parse(Right.Text);
            float top = float.Parse(Top.Text);
            float bouttm = float.Parse(Bouttm.Text);

            List<OpenSkyDetails> DataCountry = await request.FindCountryWithCoordinates(left, top, right, bouttm);
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("flights", 250);
            for (int i = 0; i < DataCountry.Count; i++)
            {
                listView2.Items.Add(new ListViewItem(new string[] { $"ican 24:{DataCountry[i].icao24}, origin_country:{DataCountry[i].origin_country}" }));

            }
        }


        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Flights", 250);
            string countryName = listView1.SelectedItems[0].SubItems[0].Text;

            for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
            {
                if (request.AllDataOpenSkeyDetails[i].origin_country.ToString() == countryName)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { $"ican 24:{request.AllDataOpenSkeyDetails[i].icao24}, origin_country:{request.AllDataOpenSkeyDetails[i].origin_country}" }));
                }
            };
        }
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView3.Invoke(new Action(() =>
            {
                listView3.Clear();
                listView3.View = View.Details;
                listView3.Columns.Add("List Details", 250);
                var numberFlight = listView2.SelectedItems[0].SubItems[0].Text;
                for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
                {
                    var splitIcao24 = numberFlight.Split(':', ',')[1];
                    if (request.AllDataOpenSkeyDetails[i].icao24 != splitIcao24)
                    {
                        continue;
                    }
                    listView3.Items.Add(new ListViewItem(new string[] { $"icao24:{request.AllDataOpenSkeyDetails[i].icao24 }" }));
                    listView3.Items.Add(new ListViewItem(new string[] { $"origin_country:{request.AllDataOpenSkeyDetails[i].origin_country }" }));
                    listView3.Items.Add(new ListViewItem(new string[] { $"longitude{request.AllDataOpenSkeyDetails[i].longitude}" }));
                    listView3.Items.Add(new ListViewItem(new string[] { $"latitude{request.AllDataOpenSkeyDetails[i].latitude}"}));
                    listView3.Items.Add(new ListViewItem(new string[] { $"baro_altitude{request.AllDataOpenSkeyDetails[i].baro_altitude}" }));
                    break;
                };
            }));
           
        }
        private void listView4_MouseClick(object sender, MouseEventArgs e)
        {
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Flights", 250);
            var countryName = listView4.SelectedItems[0].SubItems[0].Text;
            for (int i = 0; i < request.AllDataOpenSkeyDetails.Count; i++)
            {
                if (request.AllDataOpenSkeyDetails[i].origin_country.ToString() == countryName)
                {
                    listView2.Items.Add(new ListViewItem(new string[] { $"ican 24:{request.AllDataOpenSkeyDetails[i].icao24}, origin_country:{request.AllDataOpenSkeyDetails[i].origin_country}" }));

                }
            };
        }
       


        private void ShowFiveTopCountriesUI()
        {
            listView4.Clear();
            listView4.View = View.Details;
            listView4.Columns.Add("Top 5 Countries", 250);
            var nameCountry = request.FiveTopFlights();
            for (int i = 0; i < nameCountry.Count; i++)
            {
                listView4.Items.Add(new ListViewItem(new string[] { nameCountry[i] }));
            }
        }
        private async void ShowCountriesUI()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("List All Name Countries", 250);
            var listscountriesName = await request.GetAllCountries();
            for (int i = 0; i < listscountriesName.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { listscountriesName[i].ToString() }));
            }
        }
        private void ShowLowsetFlighDetailsUI()
        {

            listView3.Clear();
            listView3.View = View.Details;
            listView3.Columns.Add("Fligt Details", 250);
            List<OpenSkyDetails> LowsetFlight = request.LowsetFlightDetails();
            for (int i = 0; i < LowsetFlight.Count; i++)
            {
                listView3.Items.Add(new ListViewItem(new string[] {$"icao24:{LowsetFlight[i].icao24}" }));
                listView3.Items.Add(new ListViewItem(new string[] { $"origin_country:{LowsetFlight[i].origin_country}"}));
                listView3.Items.Add(new ListViewItem(new string[] { $"longitude:{LowsetFlight[i].longitude}" }));
                listView3.Items.Add(new ListViewItem(new string[] { $"latitude{LowsetFlight[i].latitude}" }));
                listView3.Items.Add(new ListViewItem(new string[] { $"baro_altitude{LowsetFlight[i].baro_altitude}" }));
            }

        }
        private void ShowHighetFlightDetailsUI()
        {

            listView3.Clear();
            listView3.View = View.Details;
            listView3.Columns.Add("Flight Details", 250);
            List<OpenSkyDetails> HighetFlight = request.HighetFlightDetails();
            foreach (OpenSkyDetails Flight in HighetFlight)
            {
                listView3.Items.Add(new ListViewItem(new string[] { $"icao24:{Flight.icao24}"}));
                listView3.Items.Add(new ListViewItem(new string[] { $"origin_country:{Flight.origin_country}"}));
                listView3.Items.Add(new ListViewItem(new string[] { $"longitude:{Flight.longitude}"}));
                listView3.Items.Add(new ListViewItem(new string[] { $"latitude:{Flight.latitude}"}));
                listView3.Items.Add(new ListViewItem(new string[] { $"baro_altitude:{Flight.baro_altitude}"}));
            }

        }
        private void HttpHandlerUpdate()
        {

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

