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


        private Dictionary<string,string> list;
        private readonly List<LinksRow> _rowDetails = new List<LinksRow>();

        public ShowLinks(Dictionary<string,string> list)
        {                                   
 
            this.list = list;          
                            
        }

        public override Type GetTargetClass()
        {

            return typeof(LinksRow);
        }

        public override object[] Query()
        {


            foreach (var s in this.list)
            {
                int found = 0;
                found = s.Key.ToString().IndexOf("_");
                string removeNo = s.Key.ToString().Substring(found + 1);
                _rowDetails.Add(new LinksRow { LinkName = removeNo, LinkUrl = s.Value.ToString() });
            }

            return _rowDetails.ToArray();
        }
    }
}
