using Project.Tech.OpenSky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Project.Tech.OpenSky.Dal
{
    public class Respones
    {
        public async Task<OpenSkyModel> GetAllData()
        {

            OpenSkyModel flightsData;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://opensky-network.org/");

                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage pespones = await client.GetAsync(@"api/states/all#");

                string lines = await pespones.Content.ReadAsStringAsync();

                flightsData = JsonSerializer.Deserialize<OpenSkyModel>(lines);

                return flightsData;

            }
        }

    }
}
