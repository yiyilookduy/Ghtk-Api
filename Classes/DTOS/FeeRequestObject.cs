using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiyilookGhtk.Classes.DTOS
{
    public class FeeRequestObject
    {
        public string PickProvince { get; set; }
        public string PickDistrict { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

    }
}
