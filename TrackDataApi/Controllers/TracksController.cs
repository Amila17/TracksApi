using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrackDataApi.Controllers
{
    public class TracksController : ApiController
    {
        // GET api/values
        public IEnumerable<TrackDetails> Get()
        {
            return Data.Tracks;
        }

        
    }
}
