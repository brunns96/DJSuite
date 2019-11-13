using DJSuite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
namespace DJSuite.Services
{
    public class LoginService
    {

        User user = new User();
        public LoginService(User user)
        {
            this.user = user;
        }
        public LoginService()
        {
            
        }        
        public string PostDataToAPI(string deviceId, string authToken)
        {
            try
            {
                WebRequest request = WebRequest.Create($"https://djsuiteapi.azurewebsites.net/api/dj/AuthFromDevice?deviceId={deviceId}&token={authToken}");
                //request.Headers.Add("deviceId", deviceId);
                //request.Headers.Add("token", authToken);
                request.ContentType = "application/x-www-form-urlencoded";



                WebResponse response = request.GetResponse();
                string responseFromServer = "";

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                }

                response.Close();
                return responseFromServer;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
      

        private string ApiGetRequest(string apiEndpoint, string token) 
        { 
            WebRequest request = WebRequest.Create(apiEndpoint);
            request.Headers.Add("Authorization", "Bearer" + token);
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse(); 
            string responseFromServer = "";

            using (Stream dataStream = response.GetResponseStream()) 
            { 
                StreamReader reader = new StreamReader(dataStream); 
                responseFromServer = reader.ReadToEnd(); 
            }

            response.Close();
            return responseFromServer; 
        }


        public void DeserializeJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "/test.json");
            using (StreamReader r = new StreamReader(File.ReadAllText(path)))
            {
                string json = r.ReadToEnd();
                this.user = JsonConvert.DeserializeObject<User>(json);
            }
        }


    }
}
