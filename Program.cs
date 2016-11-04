using Actividad6.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Actividad6
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.flickr.com/services/feeds/photos_public.gne?tags=soccer&format=json&nojsoncallback=1

           
            Task.Run(async () =>
            {
                //Inicializamos el objeto
                using (HttpClient client = new HttpClient())
                {
              
                   String content = await client.GetStringAsync("http://www.flickr.com/services/feeds/photos_public.gne?tags=soccer&format=json&nojsoncallback=1");
                   
                    Feed feed = JsonConvert.DeserializeObject<Feed>(content);
                  
                    Console.WriteLine("Titulo: {0}", feed.Title);

                                      foreach (var f in feed.Items)
                    {
                        Console.WriteLine("Imagen: {0}", f.Media.M);
                    }

                  
                    Console.ReadLine();
                }

            }).Wait();


        }
    }
}


