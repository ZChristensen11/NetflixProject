using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetFlixProject.Business_Objects
{
    public class Rental
    {
        public string movie_number { get; set; }
        public string member_number { get; set; }
        public string media_checkout_date { get; set; }
        public string media_return_date { get; set; }
    }
}
