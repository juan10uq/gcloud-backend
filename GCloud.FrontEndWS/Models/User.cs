using System.Collections.Generic;

namespace GCloud.FrontEndWS.Models
{
    public class User
    {
        public User()
        {
            Activities = new List<string>();
        }

        public string UserName { get; set; }
        public List<string> Activities { get; set; }
        public string AccessToken { get; set; }
    }
}