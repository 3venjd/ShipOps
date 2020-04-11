using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class NewsResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DatePublication { get; set; }

        public DateTime DatePublicationLocal => DatePublication.ToLocalTime();

        public List<NewImageResponse> NewImages { get; set; }
    }
}
