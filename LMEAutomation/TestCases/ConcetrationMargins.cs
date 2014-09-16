
using fit;
using HKEx.Clear.CDWGUI.Param;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
namespace LMEAutomation.TestCases
{
    [TestFixture, RequiresSTA]
    class ConcetrationMargins:RowFixture
    {
        private readonly List<ConcentrationRows> _rowDetails = new List<ConcentrationRows>();

        public ConcetrationMargins()
        {

            var thread = new Thread(new ThreadStart(LoadData));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            
        }

        
        [STAThread]
        public void LoadData()
        {

             HKEx.Clear.CDWGUI.Param.ConcentrationMarginView _concetrationMargerns = new ConcentrationMarginView();
            _concetrationMargerns.LoadData();
            

            
            var _concentrationData = _concetrationMargerns.ConcentrationMarginsDT;

            
            foreach (DataColumn cols in _concentrationData.Columns)
            {
                Console.Write(cols.ColumnName + "\t");
            }
            Console.WriteLine("\n");

            

            for (int allRows = 0; allRows < _concentrationData.Rows.Count; allRows++)
            {

                DataRow row = _concetrationMargerns.ConcentrationMarginsDT.Rows[allRows];

                _rowDetails.Add(new ConcentrationRows
                {
                    ConcentrationThresholdID = row.ItemArray[0],
                    UnderlyingID = row.ItemArray[1],
                    UnderlyingCode = row.ItemArray[2],
                    ChargeNameID = row.ItemArray[3],
                    ChargeName = row.ItemArray[4],
                    ThresholdNameID = row.ItemArray[5],
                    ThresholdName = row.ItemArray[6],
                    Threshold = row.ItemArray[7],
                    Charge_USD = row.ItemArray[8],
                    IsPending = row.ItemArray[9]
                });
                
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.Write(row.ItemArray[i] + "\t");                    
                                        

                }

                 Console.WriteLine("\n");
            }
        }

        public override Type GetTargetClass()
        {

            return typeof(ConcentrationRows);
        }

        public override object[] Query()
        {
            
            
            return _rowDetails.ToArray();
        }

    }
}
