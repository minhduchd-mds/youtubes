using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtubeap.Model
{
    public class Videos
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public DateTime? PubDate { get; set; }
    }
}
