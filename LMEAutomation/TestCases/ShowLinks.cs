using fit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMEAutomation.TestCases
{
    class ShowLinks:RowFixture
    {
       
       
        private ArrayList list;
        private readonly List<LinksRow> _rowDetails = new List<LinksRow>();            
                
        public ShowLinks(ArrayList list)
        {
                      
            this.list = list;
            
            foreach (var s in this.list)
            {
                
                Console.WriteLine("Addinng {0}", s);               
                
                _rowDetails.Add(new LinksRow{LinkName=s.ToString()});
            }
                
            
        }

        public override Type GetTargetClass()
        {

            return typeof(LinksRow);
        }

        public override object[] Query()
        {

            return _rowDetails.ToArray();
        }
    }
}
