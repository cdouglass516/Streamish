using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamish.Models.ViewModels
{
    public class UserProfileVideo
    {
        public UserProfile User { set; get; }
        public List<Video> UserVideos { get; set; }
    }
}
