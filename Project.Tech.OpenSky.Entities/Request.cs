using Project.Tech.OpenSky.Dal;
using Project.Tech.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Tech.OpenSky.Entities
{
    public class Request
    {

        public List<OpenSkyDetails> AllDataOpenSkeyDetails = new List<OpenSkyDetails>();
        public bool Running = true;


        public delegate void delOpenSky();
        public event delOpenSky HandlerEventOpenSkyUpdate;


        public delegate void StopAutoRunning();
        public event StopAutoRunning HandlerEventStopAutoRunning;


        public async Task<object[][]> GetFlightsDobleArrays()
        {
            Respones res = new Respones();

            OpenSkyModel openSky = await res.GetAllData();

            object[][] doubleArray = openSky.states;

            return doubleArray;
        }
        public Task AutoRequset()
        {
            return Task.Factory.StartNew(async () =>
           {
               Running = true;
               while (Running)
               {
                   object[][] statesData = await GetFlightsDobleArrays();
                   AllDataOpenSkeyDetails.Clear();
                   foreach (var OneFlight in statesData)
                   {

                       OpenSkyDetails oneFligth = new OpenSkyDetails(OneFlight[0], OneFlight[2], OneFlight[5], OneFlight[6], OneFlight[7]);

                       AllDataOpenSkeyDetails.Add(oneFligth);
                   }
                   HandlerEventOpenSkyUpdate();
                   Thread.Sleep(20000);
               }
           });

        }
        public List<string> GetAllCountries()
        {
            return AllDataOpenSkeyDetails.Select(s => s.origin_country).Distinct().ToList();
        }
        public int LengthCountries()
        {
            return AllDataOpenSkeyDetails.Count();
        }
        public List<OpenSkyDetails> LowsetFlightDetails()
        {
            return AllDataOpenSkeyDetails.OrderBy(s => s.baro_altitude).Take(1).ToList();
        }
        public List<OpenSkyDetails> HighetFlightDetails()
        {
            return AllDataOpenSkeyDetails.OrderByDescending(s => s.baro_altitude).Take(1).ToList();
        }
        public List<string> FiveTopFlights()
        {
            List<string> FiveTop = new List<string>();
            var group = (from nameCountry in AllDataOpenSkeyDetails
                         group nameCountry by nameCountry.origin_country into cg
                         select new
                         {
                             Country = cg.Key,
                             NumberOfFlights = cg.Count()
                         }).OrderByDescending(x => x.NumberOfFlights).Take(5).ToList();
            foreach (var item in group)
            {
                FiveTop.Add(item.Country);
            }
            return FiveTop;
        }
        public DateTime Time()
        {
            return AllDataOpenSkeyDetails[0].Now;
        }
        public void StopRunning()
        {
            HandlerEventStopAutoRunning();
        }

        public void Refersh(float lat, float lon)
        {

            var lat_offset = 0.0008983152841195215;
            var lon_offset = 0.001265559599380766;

            var west_lat = lat;
            var west_lon = lon - lon_offset;

            var east_lat = lat;
            var east_lon = lon + lon_offset;

            var north_lat = lat + lat_offset;
            var north_lon = lon;

            var south_lat = lat - lat_offset;
            var south_lon = lon;


        }
        public static Boolean isWithin(float left, float right, float top, float buttom)
        {
            return left >= right &&
                  top <= buttom &&
                   buttom >= left &&
                   right <= top;
        }


    }

}
