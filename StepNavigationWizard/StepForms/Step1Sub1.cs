using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepNavigationWizard.StepForms
{
    public partial class Step1Sub1 : StepFormBase,IStepForm
    {
        public Step1Sub1()
        {
            InitializeComponent();
        }

        #region IStepForm Members

        public bool OnNextClick()
        {
            MessageBox.Show("Next Click event triggered");
            return true;
        }

        public bool OnPrevClick()
        {
            MessageBox.Show("Prev Click event triggered");
            return true;
        }

        #endregion
    }
}
