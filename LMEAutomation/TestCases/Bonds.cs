using HKEx.Clear.CDWGUI.Param;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    [RequiresSTA]
    class Bonds
    {
        public int BondId { get; set; }
        public string ISIN {get;set;}
        public string ShortName{get;set;}
        public string CollateralID { get; set; }
        
      [STAThread]
        public void RetrieveBondInformation(){

            var thread = new Thread(new ThreadStart(ViewEnrichedBond));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

                     
        }
          
        [TestCase]   
        public void ViewEnrichedBond()
        {

            BondEnrichmentView bondEnrichmentView = new BondEnrichmentView();
            bondEnrichmentView.LoadData();

            foreach (DataColumn cols in bondEnrichmentView.BondLookupDT.Columns)
            {
                Console.WriteLine(cols.ColumnName);

            }



            var getParticularBond = bondEnrichmentView.BondLookupDT.FindByBondID(BondId);

          

            for (int i = 0; i < getParticularBond.ItemArray.Length; i++)
            {
                Console.WriteLine(getParticularBond.ItemArray[i]);
                BondId = getParticularBond.BondID;
                ISIN = getParticularBond.ISIN;
                ShortName = getParticularBond.ShortName;
                CollateralID = getParticularBond.CollateralID.ToString();
            }


        }
    }
}
