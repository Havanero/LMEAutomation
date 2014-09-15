using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    class PendingConcentrationMarginsRow
    {

        public Object ConcentrationThresholdID{get;set;}
        public Object UnderlyingID{get;set;}
        public Object UnderlyingCode{get;set;}
        public Object ChargeNameID{get;set;}
        public Object ChargeName{get;set;}
        public Object ThresholdNameID{get;set;}
        public Object ThresholdName{get;set;}
        public Object Threshold{get;set;}
        public Object Charge_USD{get;set;}
        public Object PendingConcentrationMarginID { get; set; }
        public Object PendingCharge { get; set; }
        public Object PendingDateTime { get; set; }
    }
}
