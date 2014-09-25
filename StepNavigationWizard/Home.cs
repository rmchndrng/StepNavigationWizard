using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using StepNavigationWizard.Helpers;

namespace StepNavigationWizard
{
    public partial class Home : Form
    {
        private List<Step> _AllSteps { get; set; }
        private TreeNode _CurrentTreeNode { get; set; }

        public Home()
        {
            InitializeComponent();
            _InitializeChildForms();
            _LoadSteps();
            _BindTreeView();
            _ShowFirstScreen();
        }

        private void _ShowFirstScreen()
        {
            this._CurrentTreeNode = treeView1.Nodes[0];
            _ShowScreen(this._CurrentTreeNode.Name);
        }

        private void _InitializeChildForms()
        {   
            this._AllSteps = new List<Step>();
        }

        private void _LoadSteps()
        {
            this._AllSteps = StepHelper.GetSteps();
        }

        private void _BindTreeView()
        {
            TreeNode[] nodes = TreeViewHelper.GetTreeNodes(this._AllSteps);
            treeView1.Nodes.AddRange(nodes);            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bool blnContinute = false;
            if (pnlContent.Controls.Count > 0)
            {
                IStepForm objForm = (IStepForm)pnlContent.Controls[0];
                if (objForm.OnPrevClick())
                {
                    blnContinute = true;                    
                }
            }
            else
            {
                blnContinute = true;
            }
            if (blnContinute)
            {
                TreeNode prevNode = TreeViewHelper.GetPrevName(this._CurrentTreeNode);
                this._CurrentTreeNode = prevNode;
                _ShowScreen(prevNode.Name);
            }
        }

        private void _ShowScreen(string name)
        {
            Form form = null;

            Step step = StepHelper.GetStepByName(name, this._AllSteps);
            if (!string.IsNullOrEmpty(step.FormName))
            {
                object objForm = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(step.FormName);
                StepFormBase stepFormBase = (StepFormBase)objForm;
                stepFormBase.Text = step.Text;
                stepFormBase.Description = step.Description;
                form = (Form)stepFormBase;
            }

            if (form != null)
            {
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(form);
                form.Show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool blnContinute = false;
            if (pnlContent.Controls.Count > 0)
            {
                IStepForm objForm = (IStepForm)pnlContent.Controls[0];
                if (objForm.OnNextClick())
                {
                    blnContinute = true;                    
                }
            }
            else
            {
                blnContinute = true;                
            }
            if (blnContinute)
            {
                TreeNode nextNode = TreeViewHelper.GetNextNode(this._CurrentTreeNode);
                this._CurrentTreeNode = nextNode;
                _ShowScreen(nextNode.Name);
            }
        }    

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _ShowScreen(e.Node.Name);
        }
    }
}
