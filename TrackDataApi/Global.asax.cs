using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrackDataApi.Controllers;

namespace TrackDataApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string resourceName = "TrackDataApi.tracks.csv";

            var lines = ReadLines(() => Assembly.GetExecutingAssembly()
                                    .GetManifestResourceStream(resourceName),
                      Encoding.UTF8)
                .ToList();

            Data.Tracks = lines.Skip(1)
                .Select(s => s.Split(','))
                .Select(columns => new TrackDetails
                {
                    Artist = columns[0],
                    SevenDigArtistId = int.Parse(columns[1]),
                    SevenDigTrackId = int.Parse(columns[2]),
                    Dancability = decimal.Parse(columns[3]),
                    Energy = decimal.Parse(columns[4]),
                    Tempo = decimal.Parse(columns[5]),
                    Title = columns[6]
                }).ToList();
        }

        public IEnumerable<string> ReadLines(Func<Stream> streamProvider,
                                     Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
