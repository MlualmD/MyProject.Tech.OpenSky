﻿using Project.Tech.OpenSky.Dal;
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
        public DateTime datetime;

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
                       if(oneFligth.origin_country!="")
                       AllDataOpenSkeyDetails.Add(oneFligth);
                   }
                   datetime = DateTime.Now;
                   HandlerEventOpenSkyUpdate();
                   Thread.Sleep(20000);
               }
           });

        }
        public Task<List<string>> GetAllCountries()
        {
            return Task.Factory.StartNew(() =>
            {
              return  AllDataOpenSkeyDetails.OrderBy(x=>x.origin_country).Select(s => s.origin_country).Distinct().ToList();
            });
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
            return datetime;
        }
        public void StopRunning()
        {
            HandlerEventStopAutoRunning();
        }
        public Task<List<OpenSkyDetails>> FindCountryWithCoordinates(float lamin, float lomin, float lamax, float lomax)
        {
           return Task.Factory.StartNew(() => {
               return (from OpenSkyDetails corrdinates in AllDataOpenSkeyDetails.OrderBy(x => x.origin_country)
                        where corrdinates.latitude > lamin && corrdinates.latitude < lamax && corrdinates.longitude > lomin && corrdinates.longitude < lomax
                        select corrdinates).ToList();
            });
        }
    } 

}
