using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StepNavigationWizard.Helpers
{
    public class StepHelper
    {
        public static List<Step> GetSteps()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Steps.xml");
            string xmlcontents = doc.InnerXml;
            return Step.ParseXml(xmlcontents);
        }

        public static Step GetStepByName(string name, List<Step> steps)
        {
            Step stepToBeReturned = null;
            foreach (Step step in steps)
            {
                if (step.Name.Equals(name))
                {
                    stepToBeReturned = step;                    
                }
                else
                {
                    if (step.Steps != null && step.Steps.Count > 0)
                    {
                        stepToBeReturned = GetStepByName(name, step.Steps);
                    }
                }
                if (stepToBeReturned != null)
                {
                    break;
                }
            }
            return stepToBeReturned;
        }
    }
}
