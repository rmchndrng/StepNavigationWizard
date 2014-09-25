using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StepNavigationWizard
{
    public class Step
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string FormName { get; set; }
        public List<Step> Steps { get; set; }

        public Step()
        {
            this.Steps = new List<Step>();
        }

        public static List<Step> ParseXml(string xml)
        {
            XDocument xmlDoc = XDocument.Parse(xml);
            List<Step> steps = null;
            XElement stepsElement = xmlDoc.Element("Steps");
            if (stepsElement != null)
            {
                foreach (XElement stepElement in stepsElement.Elements("Step"))
                {
                    Step step = new Step()
                    {
                        Name = stepElement.Element("Name").Value,
                        Text = stepElement.Element("Text").Value,
                        Description = stepElement.Element("Description") != null ? stepElement.Element("Description").Value : string.Empty,
                        FormName = stepElement.Element("FormName") != null ? stepElement.Element("FormName").Value : string.Empty,
                        Steps = stepElement.Element("Steps") != null ? ParseXml(stepElement.Element("Steps").ToString()) : null
                    };
                    if (steps == null)
                    {
                        steps = new List<Step>();
                    }
                    steps.Add(step);
                }
            }
            return steps;
        }
    }
}
