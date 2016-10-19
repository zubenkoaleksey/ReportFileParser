using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace FileReportParser
{
    class InputDataModel
    {
        public int Start { get; set; }
        public List<string> Items { get; set; }
    }

    class ReportDataModel
    {
        public string FailIssueKey { get; set; }
    }

    class Reader
    {
        public void GetFormFile(string filePath)
        {
            XDocument xDoc = XDocument.Load(filePath);

            var items = from executionElement in xDoc.Element("executions").Elements("execution")
                        where executionElement.Element("executedStatus").Value == "FAIL"
                        select new ReportDataModel
                        {
                            FailIssueKey = executionElement.Element("issueKey").Value
                        };

          //  List<string> Items = new List<string>();

            foreach (var element in items)
            {
          //      Items.Add(element.FailIssueKey);
                Console.WriteLine(element.FailIssueKey + "\n");
            }

            //foreach (var item in Items)
            //{
            //    Console.WriteLine(item);
            //}
           
        }
    }

    class Writer
    {
        public void WriteToConsole(ReportDataModel myReport)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reader read = new Reader();
            read.GetFormFile(@"C:\Users\Алексей\Downloads\ZFJ-Executions-07-12-2016.xml");

            Console.ReadLine();
        }
    }
}
