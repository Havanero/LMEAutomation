using fit;
using fitlibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    public class CDWAutomation:DoFixture
    {


        Bonds SelectBondsView()
        {
            return new Bonds();
        }

         ConcetrationMargins SelectMarginView()
         {
             return new ConcetrationMargins();
         }

         UpdateMargins UpdateMargins()
         {

             return new UpdateMargins();
         }

         PendingConcentrationMargins GetPendingConcentrationMargins()
         {

             return new PendingConcentrationMargins();
         }

         ApproveMargins ViewPendingMarginsApproval()
         {

             return new ApproveMargins();

         }

    }
}
