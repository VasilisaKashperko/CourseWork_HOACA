using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOAChairmanAssistant.Model
{
    public class Porch
    {
        [Key]
        public int PorchId { get; set; }

        [Required]
        public int PorchNumber { get; set; }

        [ForeignKey("HouseId")]
        public House HouseId { get; set; }
    }
}
