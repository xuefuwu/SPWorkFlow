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

namespace CacheMTC
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.BackActivity = new System.Workflow.Activities.CodeActivity();
            this.LPClosureActivity = new System.Workflow.Activities.CodeActivity();
            this.HPClosureActivity = new System.Workflow.Activities.CodeActivity();
            this.ShellTestActivity = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity8 = new System.Workflow.Activities.IfElseBranchActivity();
            this.NeedBackTest = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity6 = new System.Workflow.Activities.IfElseBranchActivity();
            this.NeedLPTest = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity4 = new System.Workflow.Activities.IfElseBranchActivity();
            this.NeedHPTest = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.NeedShellTest = new System.Workflow.Activities.IfElseBranchActivity();
            this.BackSeatTest = new System.Workflow.Activities.IfElseActivity();
            this.LPClosureTest = new System.Workflow.Activities.IfElseActivity();
            this.HPClosureTest = new System.Workflow.Activities.IfElseActivity();
            this.ShellTest = new System.Workflow.Activities.IfElseActivity();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.CachePVSList = new System.Workflow.Activities.CodeActivity();
            this.sequenceActivity4 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity3 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.IsPVSEmptyActivity = new System.Workflow.Activities.IfElseActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // BackActivity
            // 
            this.BackActivity.Name = "BackActivity";
            this.BackActivity.ExecuteCode += new System.EventHandler(this.BackActivity_ExecuteCode);
            // 
            // LPClosureActivity
            // 
            this.LPClosureActivity.Name = "LPClosureActivity";
            this.LPClosureActivity.ExecuteCode += new System.EventHandler(this.LPClosureActivity_ExecuteCode);
            // 
            // HPClosureActivity
            // 
            this.HPClosureActivity.Name = "HPClosureActivity";
            this.HPClosureActivity.ExecuteCode += new System.EventHandler(this.HPClosureActivity_ExecuteCode);
            // 
            // ShellTestActivity
            // 
            this.ShellTestActivity.Name = "ShellTestActivity";
            this.ShellTestActivity.ExecuteCode += new System.EventHandler(this.ShellTestActivity_ExecuteCode);
            // 
            // ifElseBranchActivity8
            // 
            this.ifElseBranchActivity8.Name = "ifElseBranchActivity8";
            // 
            // NeedBackTest
            // 
            this.NeedBackTest.Activities.Add(this.BackActivity);
            ruleconditionreference1.ConditionName = "NeedBackTest";
            this.NeedBackTest.Condition = ruleconditionreference1;
            this.NeedBackTest.Name = "NeedBackTest";
            // 
            // ifElseBranchActivity6
            // 
            this.ifElseBranchActivity6.Name = "ifElseBranchActivity6";
            // 
            // NeedLPTest
            // 
            this.NeedLPTest.Activities.Add(this.LPClosureActivity);
            ruleconditionreference2.ConditionName = "NeedLPTest";
            this.NeedLPTest.Condition = ruleconditionreference2;
            this.NeedLPTest.Name = "NeedLPTest";
            // 
            // ifElseBranchActivity4
            // 
            this.ifElseBranchActivity4.Name = "ifElseBranchActivity4";
            // 
            // NeedHPTest
            // 
            this.NeedHPTest.Activities.Add(this.HPClosureActivity);
            ruleconditionreference3.ConditionName = "NeedHPTest";
            this.NeedHPTest.Condition = ruleconditionreference3;
            this.NeedHPTest.Name = "NeedHPTest";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // NeedShellTest
            // 
            this.NeedShellTest.Activities.Add(this.ShellTestActivity);
            ruleconditionreference4.ConditionName = "NeedHPTest";
            this.NeedShellTest.Condition = ruleconditionreference4;
            this.NeedShellTest.Name = "NeedShellTest";
            // 
            // BackSeatTest
            // 
            this.BackSeatTest.Activities.Add(this.NeedBackTest);
            this.BackSeatTest.Activities.Add(this.ifElseBranchActivity8);
            this.BackSeatTest.Name = "BackSeatTest";
            // 
            // LPClosureTest
            // 
            this.LPClosureTest.Activities.Add(this.NeedLPTest);
            this.LPClosureTest.Activities.Add(this.ifElseBranchActivity6);
            this.LPClosureTest.Name = "LPClosureTest";
            // 
            // HPClosureTest
            // 
            this.HPClosureTest.Activities.Add(this.NeedHPTest);
            this.HPClosureTest.Activities.Add(this.ifElseBranchActivity4);
            this.HPClosureTest.Name = "HPClosureTest";
            // 
            // ShellTest
            // 
            this.ShellTest.Activities.Add(this.NeedShellTest);
            this.ShellTest.Activities.Add(this.ifElseBranchActivity2);
            this.ShellTest.Name = "ShellTest";
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // CachePVSList
            // 
            this.CachePVSList.Name = "CachePVSList";
            this.CachePVSList.ExecuteCode += new System.EventHandler(this.CachePVSList_ExecuteCode);
            // 
            // sequenceActivity4
            // 
            this.sequenceActivity4.Activities.Add(this.BackSeatTest);
            this.sequenceActivity4.Name = "sequenceActivity4";
            // 
            // sequenceActivity3
            // 
            this.sequenceActivity3.Activities.Add(this.LPClosureTest);
            this.sequenceActivity3.Name = "sequenceActivity3";
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.HPClosureTest);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.ShellTest);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // ifElseBranchActivity3
            // 
            this.ifElseBranchActivity3.Activities.Add(this.terminateActivity1);
            this.ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.CachePVSList);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsPVSEmpty);
            this.ifElseBranchActivity1.Condition = codecondition1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Activities.Add(this.sequenceActivity3);
            this.parallelActivity1.Activities.Add(this.sequenceActivity4);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // IsPVSEmptyActivity
            // 
            this.IsPVSEmptyActivity.Activities.Add(this.ifElseBranchActivity1);
            this.IsPVSEmptyActivity.Activities.Add(this.ifElseBranchActivity3);
            this.IsPVSEmptyActivity.Name = "IsPVSEmptyActivity";
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
            this.Activities.Add(this.IsPVSEmptyActivity);
            this.Activities.Add(this.parallelActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;
        private CodeActivity BackActivity;
        private CodeActivity LPClosureActivity;
        private CodeActivity HPClosureActivity;
        private CodeActivity ShellTestActivity;
        private TerminateActivity terminateActivity1;
        private CodeActivity CachePVSList;
        private IfElseBranchActivity ifElseBranchActivity8;
        private IfElseBranchActivity NeedBackTest;
        private IfElseBranchActivity ifElseBranchActivity6;
        private IfElseBranchActivity NeedLPTest;
        private IfElseBranchActivity ifElseBranchActivity4;
        private IfElseBranchActivity NeedHPTest;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity NeedShellTest;
        private IfElseActivity BackSeatTest;
        private IfElseActivity LPClosureTest;
        private IfElseActivity HPClosureTest;
        private IfElseActivity ShellTest;
        private SequenceActivity sequenceActivity4;
        private SequenceActivity sequenceActivity3;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private ParallelActivity parallelActivity1;
        private IfElseBranchActivity ifElseBranchActivity3;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity IsPVSEmptyActivity;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;



























    }
}
