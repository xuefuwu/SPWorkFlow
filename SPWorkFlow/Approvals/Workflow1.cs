﻿using System;
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

namespace Approvals
{
    public sealed partial class Workflow1 : StateMachineWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();

        }

        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public SPWorkflowTaskProperties createPreApprovalTask_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid createPreApprovalTask_TaskId1 = default(System.Guid);
    }
}
