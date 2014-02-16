using System;
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

namespace Approvals
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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.createPreApprovalTask = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.approvalActivity1 = new System.Workflow.Activities.StateActivity();
            this.EndApproval = new System.Workflow.Activities.StateActivity();
            this.StartApproval = new System.Workflow.Activities.StateActivity();
            // 
            // createPreApprovalTask
            // 
            correlationtoken1.Name = "approvalTaskToken";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.createPreApprovalTask.CorrelationToken = correlationtoken1;
            this.createPreApprovalTask.ListItemId = -1;
            this.createPreApprovalTask.Name = "createPreApprovalTask";
            this.createPreApprovalTask.SpecialPermissions = null;
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "createPreApprovalTask_TaskId1";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "createPreApprovalTask_TaskProperties1";
            this.createPreApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.createPreApprovalTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "approvalActivity1";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.createPreApprovalTask);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.onWorkflowActivated1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // approvalActivity1
            // 
            this.approvalActivity1.Activities.Add(this.stateInitializationActivity1);
            this.approvalActivity1.Name = "approvalActivity1";
            // 
            // EndApproval
            // 
            this.EndApproval.Name = "EndApproval";
            // 
            // StartApproval
            // 
            this.StartApproval.Activities.Add(this.eventDrivenActivity1);
            this.StartApproval.Name = "StartApproval";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.StartApproval);
            this.Activities.Add(this.EndApproval);
            this.Activities.Add(this.approvalActivity1);
            this.CompletedStateName = "EndApproval";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "StartApproval";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private StateActivity EndApproval;
        private StateActivity approvalActivity1;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createPreApprovalTask;
        private SetStateActivity setStateActivity1;
        private StateInitializationActivity stateInitializationActivity1;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;
        private EventDrivenActivity eventDrivenActivity1;
        private StateActivity StartApproval;































    }
}
