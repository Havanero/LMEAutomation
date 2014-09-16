using fit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    class PendingConcentrationMargins:RowFixture
    {

        private List<PendingConcentrationMarginsRow> _rowDetails;

        public override Type GetTargetClass()
        {

            return typeof(PendingConcentrationMarginsRow);
        }

        public override object[] Query()
        {

            _rowDetails = new List<PendingConcentrationMarginsRow>();

            HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter approvalTable = new HKEx.Clear.CDWGUI.Param.ApprovalsTableAdapters.GetPendingConcentrationMarginsTableAdapter();
            var approvals = approvalTable.GetData();

            Console.WriteLine("running approvals {0}", approvals.Count());


            foreach (DataRow app in approvals.Rows)
            {

                _rowDetails.Add(new PendingConcentrationMarginsRow
                {
                    ConcentrationThresholdID = app.ItemArray[0],
                    UnderlyingID = app.ItemArray[1],
                    UnderlyingCode = app.ItemArray[2],
                    ChargeNameID = app.ItemArray[3],
                    ChargeName = app.ItemArray[4],
                    ThresholdNameID = app.ItemArray[5],
                    ThresholdName = app.ItemArray[6],
                    Threshold = app.ItemArray[7],
                    Charge_USD = app.ItemArray[8],
                    PendingConcentrationMarginID=app.ItemArray[9],
                    PendingCharge = app.ItemArray[11],
                    PendingDateTime=app.ItemArray[12]
                });

                for (int i = 0; i < app.ItemArray.Length; i++)
                {
                    Console.Write(app.ItemArray[i] + "\t");


                }
                Console.WriteLine("\n");

            }


            return _rowDetails.ToArray();
        }

    }
}
