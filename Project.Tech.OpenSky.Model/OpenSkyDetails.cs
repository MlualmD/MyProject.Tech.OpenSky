using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tech.OpenSky.Model
{
    public class OpenSkyDetails
    {
        public string icao24 { get; set; }
        public string origin_country { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public float baro_altitude { get; set; }

        public DateTime Now;

        public OpenSkyDetails(object Id, object Origin_country, object Longitude, object Latitude, object Baro_altitude)
        {
            this.Now = DateTime.Now;
            icao24 = Id.ToString();
            origin_country = Origin_country.ToString();
            longitude = Longitude != null ? float.Parse(Longitude.ToString()) : 0;
            latitude = Latitude != null ? float.Parse(Latitude.ToString()) : 0;
            baro_altitude = Baro_altitude != null ? float.Parse(Baro_altitude.ToString()) : 0;
        }

    }
}
