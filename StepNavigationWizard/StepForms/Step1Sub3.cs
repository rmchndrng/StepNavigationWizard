﻿using System;
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
    public partial class Step1Sub3 : StepFormBase,IStepForm
    {
        public Step1Sub3()
        {
            InitializeComponent();
        }

        #region IStepForm Members

        public bool OnNextClick()
        {
            return true;
        }

        public bool OnPrevClick()
        {
            return true;
        }

        #endregion
    }
}
