using DJSuite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DJSuite.Services
{
    public class LoginService
    {

        User user = new User();
        public LoginService(User user)
        {
            this.user = user;
        }

        public string GetLoginCredentials()
        {
            //  var scope = 'user-read-private user-read-email user-library-read';
            //      res.redirect('https://accounts.spotify.com/authorize?' +
            //        querystring.stringify({
            //      response_type: 'code',
            //client_id: client_id,
            //scope: scope,
            //redirect_uri: redirect_uri,
            //state: state
            //    }));
            var resp = ApiGetRequest("https://api.spotify.com/v1/users/jmperezperez", user.Token);

            return "";
        }

      

        private static string ApiGetRequest(string apiEndpoint, string token) 
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



    }
}
