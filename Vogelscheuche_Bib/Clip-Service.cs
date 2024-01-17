using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogelscheuche_Bib
{
    public class AI_Service
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            string baseUrl = "http://localhost:5000/birds/";

            try
            {
                string imagePath = "C:\\Users\\FionaBüttner\\source\\repos\\Bird-Recognition\\Bird-Recognition-AI\\test-data\\puffin.jpeg"; // Replace with the path to your image file

                // string result = await MultiResponse(client, baseUrl, imagePath); // übernehmen für wpf
                string result2 = await SingleResponse(client, baseUrl, imagePath); // übernehmen für wpf
                Console.WriteLine(result2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static async Task<string> PostImageAsync(HttpClient client, string url, string imagePath)
        {
            using (var formData = new MultipartFormDataContent())
            {
                // Load the image file
                using (var fs = File.OpenRead(imagePath))
                {
                    var streamContent = new StreamContent(fs);
                    var imageContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync());
                    formData.Add(imageContent, "image", Path.GetFileName(imagePath));

                    // Send the request
                    HttpResponseMessage response = await client.PostAsync(url, formData);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task<dynamic> MultiResponse(HttpClient client, string baseUrl, string imagePath)
        {
            
            // Identify multiple birds
            var multiResponse = await PostImageAsync(client, baseUrl + "identify-multi", imagePath);
            // Console.WriteLine("Multi Bird Identification Response: " + multiResponse);
            var birdResponseMulti = JsonConvert.DeserializeObject<dynamic>(multiResponse);
            var detectedBirds = new List<dynamic>();
            if (birdResponseMulti?.detected_birds != null)
            {
                foreach (var bird in birdResponseMulti.detected_birds)
                {
                    Console.WriteLine("Detected Bird Multi: " + bird);
                    detectedBirds.Add(bird);
                }
                return detectedBirds;
            }
            else
            {
                Console.WriteLine("No bird detected or there was an error in the response.");
                return " ";
            }
            
        }
        public static async Task<dynamic> SingleResponse(HttpClient client, string baseUrl, string imagePath)
        {

            // Identify single bird
            var singleResponse = await PostImageAsync(client, baseUrl + "identify-single", imagePath);
            // Console.WriteLine("Single Bird Identification Response: " + singleResponse);
            var birdResponseSingle = JsonConvert.DeserializeObject<dynamic>(singleResponse);
            if (birdResponseSingle?.detected_bird != null)
            {
                Console.WriteLine("Detected Bird Single: " + birdResponseSingle.detected_bird);
                return birdResponseSingle.detected_bird;
            }
            else
            {
                Console.WriteLine("No bird detected or there was an error in the response.");
                return " ";
            }
        }
    }
}
