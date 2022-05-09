using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Porch
    {
        public int PorchId { get; set; }

        public int PorchNumber { get; set; }

        public House HouseId { get; set; }
    }
}
