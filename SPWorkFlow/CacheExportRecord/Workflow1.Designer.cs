﻿using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CacheExportRecord
{
    public sealed partial class Workflow1
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.SyncToOR = new System.Workflow.Activities.CodeActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // SyncToOR
            // 
            this.SyncToOR.Description = "同步出货记录中的信息至OR";
            this.SyncToOR.Name = "SyncToOR";
            this.SyncToOR.ExecuteCode += new System.EventHandler(this.SyncToOR_ExecuteCode);
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.codeActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.OnWhileActivity);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.whileActivity1);
            this.Activities.Add(this.SyncToOR);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity SyncToOR;
        private CodeActivity codeActivity1;
        private WhileActivity whileActivity1;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;





    }
}
