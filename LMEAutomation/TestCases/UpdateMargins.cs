using HKEx.Clear.CDWGUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    class UpdateMargins
    {

        public int ConcentrationThresholdId { get; set; }
        public int UnderlyingId { get; set; }
        public int ChargeNameId { get; set; }
        public int ThresholdNameId { get; set; }
        public int Threshold { get; set; }
        public decimal Charge_usd { get; set; }

        private UpdateMargins Save()
        {

            var res = clsLimits.EditConcentrationMargin(ConcentrationThresholdId, UnderlyingId,ChargeNameId,ThresholdNameId,Threshold,Charge_usd);

            
            return null;
        }

    }
}
