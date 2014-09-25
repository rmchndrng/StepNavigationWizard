using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepNavigationWizard
{
    public partial class StepFormBase : Form
    {
        public string Description { get; set; }
 
        public StepFormBase()
        {
            InitializeComponent();
            this.TopLevel = false;
        }
    }
}
