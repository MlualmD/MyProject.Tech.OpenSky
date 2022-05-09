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

        public delegate void delOpenSky();
        public event delOpenSky HandlerEventOpenSky;

        public delegate void StopAutoRunning();
        public event StopAutoRunning HandlerEventStopAutoRunning;


        public List<OpenSkyDetails> AllDataOpenSkey = new List<OpenSkyDetails>();

        public bool RunToStop = true;
        public async Task<object[][]> GetFlyiesDetails()
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
               RunToStop = true;
               while (RunToStop)
               {
                   object[][] statesData = await GetFlyiesDetails();

                   OpenSkyModel openSkyModel = new OpenSkyModel(statesData);

                   AllDataOpenSkey.Clear();
                   foreach (var OneFlight in statesData)
                   {

                       OpenSkyDetails oneFligth = new OpenSkyDetails(OneFlight[0], OneFlight[2], OneFlight[5], OneFlight[6], OneFlight[7]);

                       AllDataOpenSkey.Add(oneFligth);
                   }
                   HandlerEventOpenSky();
                   Thread.Sleep(20000);
               }
           });

        }
        public List<string> GetAllCountries()
        {

            var CuntryName = AllDataOpenSkey.Select(s => s.origin_country).Distinct().ToList();

            return CuntryName;

        }
        public int LengthCountries()
        {

            var CuntryName = AllDataOpenSkey.Count();

            return CuntryName;

        }
        public List<OpenSkyDetails> LowsetFlighDetails()
        {
            List<OpenSkyDetails> details = AllDataOpenSkey;
            List<OpenSkyDetails> LowsetFligh = details.OrderBy(s => s.baro_altitude).Take(1).ToList();
            return LowsetFligh;
        }
        public List<OpenSkyDetails> HighetFlightDetails()
        {
            List<OpenSkyDetails> details = AllDataOpenSkey;
            List<OpenSkyDetails> HighetFlight = details.OrderByDescending(s => s.baro_altitude).Take(1).ToList();
            return HighetFlight;
        }
        public List<string> FiveTopFlights()
        {
            List<string> FiveTop = new List<string>();
            var recentFiveForEachName = AllDataOpenSkey;
            var group = (from nameCountry in AllDataOpenSkey
                         group nameCountry by nameCountry.origin_country into cg
                         select new
                         {
                             City = cg.Key,
                             NumberOfCompanies = cg.Count()
                         }).OrderByDescending(x => x.NumberOfCompanies).Distinct().Take(5).ToList();
            foreach (var item in group)
            {
                FiveTop.Add(item.City);
            }
            return FiveTop;
        }
        public DateTime Time()
        {
            for (int i = 0; i < AllDataOpenSkey.Count;)
            {
                var time = AllDataOpenSkey[i].Now;
                return time;

            }
            return DateTime.Now;
        }
        public void StopRunning()
        {
            HandlerEventStopAutoRunning();
        }

    }

}
