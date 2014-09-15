using HKEx.Clear.CDWGUI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    class ApproveMargins
    {

        public int PendingConcentrationMarginID { get; set;}
        public int ConcentrationThresholdId { get; set; }
        public bool ReturnCode { get; set; }

        private ApproveMargins Approve()
        {
            HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter approvalTable = new HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter();
            var approvals = approvalTable.GetData();
            Console.WriteLine("Approving CMID  {0}", PendingConcentrationMarginID);
            var _retVal = clsApprovals.ApprovePendingConcentrationMargin(PendingConcentrationMarginID, ConcentrationThresholdId, true, true, 27);

            foreach (DataRow app in approvals.Rows)
            {

                for (int i = 0; i < app.ItemArray.Length; i++)
                {
                    Console.Write(app.ItemArray[i] + "\t");

                    if (ConcentrationThresholdId == (int)app.ItemArray[0])
                    {
                        ReturnCode = true;
                    }
                }                            
                              

            }
                 
            return null;
        }


    }
}
