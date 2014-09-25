using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepNavigationWizard
{
    public interface IStepForm
    {
        bool OnNextClick();
        bool OnPrevClick();
    }
}
