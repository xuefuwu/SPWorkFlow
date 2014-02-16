using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;
using Microsoft.Office.Workflow.Utility;

namespace ContractTask
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public Guid TaskId1 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            TaskId1 = Guid.NewGuid();
            TaskProperties1.Title = workflowProperties.Item["_x5408__x540c__x7f16__x53f7_"].ToString();
            TaskProperties1.AssignedTo = workflowProperties.Item["_x4e1a__x52a1__x5458_"].ToString().Split('#')[1];
        }
    }
}
