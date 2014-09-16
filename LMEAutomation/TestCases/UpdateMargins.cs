using HKEx.Clear.CDWGUI.Data;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string ReturnValue { get; set; }
        
        private UpdateMargins Save()
        {
            
            string res = clsLimits.EditConcentrationMargin(ConcentrationThresholdId, UnderlyingId,ChargeNameId,ThresholdNameId,Threshold,Charge_usd);

            HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter approvalTable = new HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter();
         
            var approvals = approvalTable.GetData();

            try
            {

                foreach (DataRow app in approvals.Rows)
                {

                    for (int i = 0; i < app.ItemArray.Length; i++)
                    {
                        Console.Write(app.ItemArray[i] + "\t");

                        if (ConcentrationThresholdId == (int)app.ItemArray[0])
                        {
                            ReturnValue = "Successfull";
                        }


                    }
                    Console.WriteLine("\n");
                }
            }
            catch (InvalidCastException s)
            {
                ReturnValue = s.Message;
            }
            
                
            
            return null;
        }

    }
}
