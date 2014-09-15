

using NSoup.Nodes;
using NSoup.Select;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

using System.Data;
using NUnit.Framework;
using System.Threading;
using fitlibrary;
using fit;

namespace LMEAutomation.TestCases
{
    [RequiresSTA]
    public class PageTitleFixture:DoFixture
    {

        public string URL { get; set; }
        public string PageTitle { get; set; }
        public string HttpStatusCode { get; set; }

        public string NotAvailableField { get; set; }
        private Document doc;

        private string _noOfLinks;
        public ArrayList listOfLinks = new ArrayList();

        Dictionary<string, string> LinkNameAndLink = new Dictionary<string, string>();



        [TestCase]   
        private void StartWindows()
        {

            try
            {
                ConcetrationMargins concentrationMargins = new ConcetrationMargins();
                concentrationMargins.LoadData();
               // System.Windows.Threading.Dispatcher.Run();
                Console.WriteLine("Run OK");
            }
            catch (Exception s)
            {
                Console.WriteLine("Error  {0}", s.Message);

                Console.WriteLine("Error  {0}", s.StackTrace);


                throw new Exception("Cannot continue with Test");
            }

        }

        [TestCase]
        private void BondsWindow()
        {

            try
            {
                Bonds bonds = new Bonds();                
             //   System.Windows.Threading.Dispatcher.Run();
                Console.WriteLine("Run OK");
                bonds.ViewEnrichedBond();
            }
            catch (Exception s)
            {
                Console.WriteLine("Error  {0}", s.Message);

                Console.WriteLine("Error  {0}", s.StackTrace);


                throw new Exception("Cannot continue with Test");
            }

        }

        [STAThread]
        private PageTitleFixture GoToWebSite()
        {

       /*     var thread = new Thread(new ThreadStart(StartWindows));

           thread.SetApartmentState(ApartmentState.STA);
           thread.Start();
           thread.Join();
            */

            
           

            var thread = new Thread(new ThreadStart(StartWindows));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            Console.WriteLine("Response stream received.");


            string responseValue = readStream.ReadToEnd();            
            doc = NSoup.NSoupClient.ParseBodyFragment(responseValue);

           Elements element = doc.GetElementsByTag("Title");

           
            
            response.Close();
            readStream.Close();

              
            HttpStatusCode = response.StatusCode.GetHashCode().ToString();

            Console.WriteLine(response.StatusCode);

            
                        
            PageTitle = element.Text;
           
//            Console.WriteLine("Response stream received.\n {0}",responseValue);

            Elements links = doc.GetElementsByTag("a");
            int count = 0;
                        
                foreach (var _link in links)
                {

                    Element linkByLink = _link.TagName("a href");

                    if (!linkByLink.Text().ToString().Equals(""))
                    {

                        //var linkText = _link.TagName("a href").Text;
                        //Console.WriteLine("Link ={0}", linkByLink.Text());
                        //listOfLinks.Add(linkByLink.Text());

                        String absHref = linkByLink.Attr("abs:href");
                        Console.WriteLine("Link ={0}", absHref);

                        LinkNameAndLink.Add(count+"_"+linkByLink.Text(), absHref);

                        count++;
                    }
                }
            
            _noOfLinks = count.ToString();

            return null;
        }

        public string NoOfLinksOnThePage()
        {

            return _noOfLinks;
        }
        
        public Fixture ListAllLinks()
        {

            return new ShowLinks(LinkNameAndLink);
        }
       
    }
}
