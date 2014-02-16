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

namespace CacheModelNumber
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference5 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference6 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition4 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.codeActivity10 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity9 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity8 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity7 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity6 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity5 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.terminateActivity1 = new System.Workflow.ComponentModel.TerminateActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.XX = new System.Workflow.Activities.IfElseBranchActivity();
            this.PL = new System.Workflow.Activities.IfElseBranchActivity();
            this.GL = new System.Workflow.Activities.IfElseBranchActivity();
            this.GA = new System.Workflow.Activities.IfElseBranchActivity();
            this.CH = new System.Workflow.Activities.IfElseBranchActivity();
            this.BU = new System.Workflow.Activities.IfElseBranchActivity();
            this.turnnionBA = new System.Workflow.Activities.IfElseBranchActivity();
            this.floatBA = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity10 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity9 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity3 = new System.Workflow.Activities.IfElseActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // codeActivity10
            // 
            this.codeActivity10.Name = "codeActivity10";
            this.codeActivity10.ExecuteCode += new System.EventHandler(this.codeActivity10_ExecuteCode);
            // 
            // codeActivity9
            // 
            this.codeActivity9.Name = "codeActivity9";
            this.codeActivity9.ExecuteCode += new System.EventHandler(this.codeActivity9_ExecuteCode);
            // 
            // codeActivity8
            // 
            this.codeActivity8.Name = "codeActivity8";
            this.codeActivity8.ExecuteCode += new System.EventHandler(this.codeActivity8_ExecuteCode);
            // 
            // codeActivity7
            // 
            this.codeActivity7.Name = "codeActivity7";
            this.codeActivity7.ExecuteCode += new System.EventHandler(this.codeActivity7_ExecuteCode);
            // 
            // codeActivity6
            // 
            this.codeActivity6.Name = "codeActivity6";
            this.codeActivity6.ExecuteCode += new System.EventHandler(this.codeActivity6_ExecuteCode);
            // 
            // codeActivity5
            // 
            this.codeActivity5.Name = "codeActivity5";
            this.codeActivity5.ExecuteCode += new System.EventHandler(this.codeActivity5_ExecuteCode);
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.codeActivity4_ExecuteCode);
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // terminateActivity1
            // 
            this.terminateActivity1.Name = "terminateActivity1";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.codeActivity10);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.onIdentity);
            this.ifElseBranchActivity1.Condition = codecondition1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // XX
            // 
            this.XX.Activities.Add(this.codeActivity9);
            ruleconditionreference1.ConditionName = "XX";
            this.XX.Condition = ruleconditionreference1;
            this.XX.Name = "XX";
            // 
            // PL
            // 
            this.PL.Activities.Add(this.codeActivity8);
            ruleconditionreference2.ConditionName = "PL";
            this.PL.Condition = ruleconditionreference2;
            this.PL.Name = "PL";
            // 
            // GL
            // 
            this.GL.Activities.Add(this.codeActivity7);
            ruleconditionreference3.ConditionName = "GL";
            this.GL.Condition = ruleconditionreference3;
            this.GL.Name = "GL";
            // 
            // GA
            // 
            this.GA.Activities.Add(this.codeActivity6);
            ruleconditionreference4.ConditionName = "GA";
            this.GA.Condition = ruleconditionreference4;
            this.GA.Name = "GA";
            // 
            // CH
            // 
            this.CH.Activities.Add(this.codeActivity5);
            ruleconditionreference5.ConditionName = "CH";
            this.CH.Condition = ruleconditionreference5;
            this.CH.Name = "CH";
            // 
            // BU
            // 
            this.BU.Activities.Add(this.codeActivity4);
            ruleconditionreference6.ConditionName = "BU";
            this.BU.Condition = ruleconditionreference6;
            this.BU.Name = "BU";
            // 
            // turnnionBA
            // 
            this.turnnionBA.Activities.Add(this.codeActivity3);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.onTurnnionBA);
            this.turnnionBA.Condition = codecondition2;
            this.turnnionBA.Name = "turnnionBA";
            // 
            // floatBA
            // 
            this.floatBA.Activities.Add(this.codeActivity2);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.onFloatBA);
            this.floatBA.Condition = codecondition3;
            this.floatBA.Name = "floatBA";
            // 
            // ifElseBranchActivity10
            // 
            this.ifElseBranchActivity10.Name = "ifElseBranchActivity10";
            // 
            // ifElseBranchActivity9
            // 
            this.ifElseBranchActivity9.Activities.Add(this.terminateActivity1);
            codecondition4.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.onUpgrade);
            this.ifElseBranchActivity9.Condition = codecondition4;
            this.ifElseBranchActivity9.Name = "ifElseBranchActivity9";
            // 
            // ifElseActivity3
            // 
            this.ifElseActivity3.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity3.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity3.Name = "ifElseActivity3";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.floatBA);
            this.ifElseActivity1.Activities.Add(this.turnnionBA);
            this.ifElseActivity1.Activities.Add(this.BU);
            this.ifElseActivity1.Activities.Add(this.CH);
            this.ifElseActivity1.Activities.Add(this.GA);
            this.ifElseActivity1.Activities.Add(this.GL);
            this.ifElseActivity1.Activities.Add(this.PL);
            this.ifElseActivity1.Activities.Add(this.XX);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity9);
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity10);
            this.ifElseActivity2.Name = "ifElseActivity2";
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
            this.Activities.Add(this.ifElseActivity2);
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.ifElseActivity3);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity10;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity3;
        private CodeActivity codeActivity9;
        private CodeActivity codeActivity8;
        private CodeActivity codeActivity7;
        private CodeActivity codeActivity6;
        private CodeActivity codeActivity5;
        private CodeActivity codeActivity4;
        private CodeActivity codeActivity3;
        private CodeActivity codeActivity2;
        private IfElseBranchActivity ifElseBranchActivity10;
        private IfElseBranchActivity ifElseBranchActivity9;
        private IfElseActivity ifElseActivity2;
        private TerminateActivity terminateActivity1;
        private IfElseBranchActivity XX;
        private CodeActivity codeActivity1;
        private IfElseBranchActivity PL;
        private IfElseBranchActivity GL;
        private IfElseBranchActivity GA;
        private IfElseBranchActivity CH;
        private IfElseBranchActivity BU;
        private IfElseBranchActivity turnnionBA;
        private IfElseBranchActivity floatBA;
        private IfElseActivity ifElseActivity1;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;
















































    }
}
