using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tech.OpenSky.Model
{

    public class OpenSkyModel
    {
        public OpenSkyModel(object[][] states)
        {
            this.states = states;


        }

        public int time { get; set; }
        public object[][] states { get; set; }



    }

}
