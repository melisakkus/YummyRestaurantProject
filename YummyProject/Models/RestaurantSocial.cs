using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YummyProject.Models
{
    public class RestaurantSocial
    {
        public int RestaurantSocialId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string SocialMediaName { get; set; }
    }
}