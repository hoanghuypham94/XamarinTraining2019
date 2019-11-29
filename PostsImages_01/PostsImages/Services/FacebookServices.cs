using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostsImages.Models;

namespace PostsImages.Services
{
    public class FacebookServices
    {

        public async Task<FacebookProfile> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.5/me?fields=id,name,age_range,first_name,last_name,picture,cover,birthday,gender,email&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

            return facebookProfile;
        }
    }
}
