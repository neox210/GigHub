using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewsModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Heading { get; set; }
    }
}