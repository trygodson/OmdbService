using System;
using Newtonsoft.Json.Linq;

namespace OMDBService.Services
{
	public class OMDBApiService
	{
		public OMDBApiService()
		{
		}

        public async Task<JObject> searchMovies(string search, string year, string plot)
        {
            using (HttpClient client = new HttpClient())
            {

                var res =  client.GetStringAsync($"https://www.omdbapi.com/?t={search}&y={year}&plot={plot}&apikey=7a47464f").Result;

                var json = JObject.Parse(res);

                return json;

            }


        }

    }
}

