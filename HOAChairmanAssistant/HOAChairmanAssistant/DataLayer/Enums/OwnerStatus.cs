using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HOAChairmanAssistant.Model
{
    public enum OwnerStatus
    {
        [Description("Проживает")]
        Lives = 1,
        [Description("Сдает")]
        Rents
    }
}
