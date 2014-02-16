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

namespace CacheMaterials
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
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken5 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken6 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken7 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken8 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken9 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind29 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken10 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind30 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind31 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind32 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind33 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind34 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken11 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind35 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind36 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind37 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind38 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind39 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken12 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind40 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind41 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind42 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind43 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind44 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken13 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind45 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind46 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind47 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind48 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind49 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken14 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind50 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind51 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind52 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind53 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind54 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken15 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind55 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind56 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind57 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind58 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind59 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken16 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind60 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind61 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind62 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind63 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind64 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind65 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition4 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition5 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition6 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition7 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition8 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition9 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition10 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition11 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition12 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition13 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition14 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition15 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition16 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition17 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition18 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind67 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken17 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind66 = new System.Workflow.ComponentModel.ActivityBind();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.completeTask16 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged16 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask16 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask15 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged15 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask15 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask14 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged14 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask14 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask13 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged13 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask13 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask12 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged12 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask12 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask11 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged11 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask11 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask10 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged10 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask10 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask9 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged9 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask9 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask8 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged8 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask8 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask7 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged7 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask7 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask6 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged6 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask6 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask5 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged5 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask5 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask4 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged4 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask4 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask3 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged3 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask3 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask2 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged2 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask2 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createTask1 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.ifElseBranchActivity36 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity35 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity34 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity33 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity32 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity31 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity30 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity29 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity28 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity27 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity26 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity25 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity24 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity23 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity22 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity21 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity20 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity19 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity18 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity17 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity16 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity15 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity14 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity13 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity12 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity11 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity10 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity9 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity8 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity7 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity6 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity5 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity4 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity18 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity17 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity16 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity15 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity14 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity13 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity12 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity11 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity10 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity9 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity8 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity7 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity6 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity5 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity4 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity3 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.sequenceActivity18 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity17 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity16 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity15 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity14 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity13 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity12 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity11 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity10 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity9 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity8 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity7 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity6 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity5 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity4 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity3 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.parallelActivity2 = new System.Workflow.Activities.ParallelActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
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
            // completeTask16
            // 
            correlationtoken1.Name = "TaskToken16";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.completeTask16.CorrelationToken = correlationtoken1;
            this.completeTask16.Name = "completeTask16";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "TaskId16";
            this.completeTask16.TaskOutcome = null;
            this.completeTask16.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // onTaskChanged16
            // 
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "TaskProperties16";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "TaskProperties16";
            this.onTaskChanged16.CorrelationToken = correlationtoken1;
            this.onTaskChanged16.Executor = null;
            this.onTaskChanged16.Name = "onTaskChanged16";
            this.onTaskChanged16.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged16.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged16_Invoked);
            this.onTaskChanged16.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onTaskChanged16.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // createTask16
            // 
            this.createTask16.CorrelationToken = correlationtoken1;
            this.createTask16.ListItemId = -1;
            this.createTask16.Name = "createTask16";
            this.createTask16.SpecialPermissions = null;
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "TaskId16";
            activitybind5.Name = "Workflow1";
            activitybind5.Path = "TaskProperties16";
            this.createTask16.MethodInvoking += new System.EventHandler(this.createTask16_MethodInvoking);
            this.createTask16.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createTask16.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // completeTask15
            // 
            correlationtoken2.Name = "TaskToken15";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.completeTask15.CorrelationToken = correlationtoken2;
            this.completeTask15.Name = "completeTask15";
            activitybind6.Name = "Workflow1";
            activitybind6.Path = "TaskId15";
            this.completeTask15.TaskOutcome = null;
            this.completeTask15.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // onTaskChanged15
            // 
            activitybind7.Name = "Workflow1";
            activitybind7.Path = "TaskProperties15";
            activitybind8.Name = "Workflow1";
            activitybind8.Path = "TaskProperties15";
            this.onTaskChanged15.CorrelationToken = correlationtoken2;
            this.onTaskChanged15.Executor = null;
            this.onTaskChanged15.Name = "onTaskChanged15";
            this.onTaskChanged15.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged15.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged15_Invoked);
            this.onTaskChanged15.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.onTaskChanged15.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            // 
            // createTask15
            // 
            this.createTask15.CorrelationToken = correlationtoken2;
            this.createTask15.ListItemId = -1;
            this.createTask15.Name = "createTask15";
            this.createTask15.SpecialPermissions = null;
            activitybind9.Name = "Workflow1";
            activitybind9.Path = "TaskId15";
            activitybind10.Name = "Workflow1";
            activitybind10.Path = "TaskProperties15";
            this.createTask15.MethodInvoking += new System.EventHandler(this.createTask15_MethodInvoking);
            this.createTask15.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createTask15.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // completeTask14
            // 
            correlationtoken3.Name = "TaskToken14";
            correlationtoken3.OwnerActivityName = "Workflow1";
            this.completeTask14.CorrelationToken = correlationtoken3;
            this.completeTask14.Name = "completeTask14";
            activitybind11.Name = "Workflow1";
            activitybind11.Path = "TaskId14";
            this.completeTask14.TaskOutcome = null;
            this.completeTask14.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // onTaskChanged14
            // 
            this.onTaskChanged14.AfterProperties = null;
            activitybind12.Name = "Workflow1";
            activitybind12.Path = "TaskProperties14";
            this.onTaskChanged14.CorrelationToken = correlationtoken3;
            this.onTaskChanged14.Executor = null;
            this.onTaskChanged14.Name = "onTaskChanged14";
            this.onTaskChanged14.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged14.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged14_Invoked);
            this.onTaskChanged14.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // createTask14
            // 
            this.createTask14.CorrelationToken = correlationtoken3;
            this.createTask14.ListItemId = -1;
            this.createTask14.Name = "createTask14";
            this.createTask14.SpecialPermissions = null;
            activitybind13.Name = "Workflow1";
            activitybind13.Path = "TaskId14";
            activitybind14.Name = "Workflow1";
            activitybind14.Path = "TaskProperties14";
            this.createTask14.MethodInvoking += new System.EventHandler(this.createTask14_MethodInvoking);
            this.createTask14.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createTask14.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            // 
            // completeTask13
            // 
            correlationtoken4.Name = "TaskToken13";
            correlationtoken4.OwnerActivityName = "Workflow1";
            this.completeTask13.CorrelationToken = correlationtoken4;
            this.completeTask13.Name = "completeTask13";
            activitybind15.Name = "Workflow1";
            activitybind15.Path = "TaskId13";
            this.completeTask13.TaskOutcome = null;
            this.completeTask13.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            // 
            // onTaskChanged13
            // 
            activitybind16.Name = "Workflow1";
            activitybind16.Path = "TaskProperties13";
            activitybind17.Name = "Workflow1";
            activitybind17.Path = "TaskProperties13";
            this.onTaskChanged13.CorrelationToken = correlationtoken4;
            this.onTaskChanged13.Executor = null;
            this.onTaskChanged13.Name = "onTaskChanged13";
            this.onTaskChanged13.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged13.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged13_Invoked);
            this.onTaskChanged13.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.onTaskChanged13.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // createTask13
            // 
            this.createTask13.CorrelationToken = correlationtoken4;
            this.createTask13.ListItemId = -1;
            this.createTask13.Name = "createTask13";
            this.createTask13.SpecialPermissions = null;
            activitybind18.Name = "Workflow1";
            activitybind18.Path = "TaskId13";
            activitybind19.Name = "Workflow1";
            activitybind19.Path = "TaskProperties13";
            this.createTask13.MethodInvoking += new System.EventHandler(this.createTask13_MethodInvoking);
            this.createTask13.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createTask13.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            // 
            // completeTask12
            // 
            correlationtoken5.Name = "TaskToken12";
            correlationtoken5.OwnerActivityName = "Workflow1";
            this.completeTask12.CorrelationToken = correlationtoken5;
            this.completeTask12.Name = "completeTask12";
            this.completeTask12.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeTask12.TaskOutcome = null;
            // 
            // onTaskChanged12
            // 
            this.onTaskChanged12.AfterProperties = null;
            this.onTaskChanged12.BeforeProperties = null;
            this.onTaskChanged12.CorrelationToken = correlationtoken5;
            this.onTaskChanged12.Executor = null;
            this.onTaskChanged12.Name = "onTaskChanged12";
            this.onTaskChanged12.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged12.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged12_Invoked);
            // 
            // createTask12
            // 
            this.createTask12.CorrelationToken = correlationtoken5;
            this.createTask12.ListItemId = -1;
            this.createTask12.Name = "createTask12";
            this.createTask12.SpecialPermissions = null;
            activitybind20.Name = "Workflow1";
            activitybind20.Path = "TaskId12";
            activitybind21.Name = "Workflow1";
            activitybind21.Path = "TaskProperties12";
            this.createTask12.MethodInvoking += new System.EventHandler(this.createTask12_MethodInvoking);
            this.createTask12.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.createTask12.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // completeTask11
            // 
            correlationtoken6.Name = "TaskToken11";
            correlationtoken6.OwnerActivityName = "Workflow1";
            this.completeTask11.CorrelationToken = correlationtoken6;
            this.completeTask11.Name = "completeTask11";
            this.completeTask11.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeTask11.TaskOutcome = null;
            // 
            // onTaskChanged11
            // 
            this.onTaskChanged11.AfterProperties = null;
            this.onTaskChanged11.BeforeProperties = null;
            this.onTaskChanged11.CorrelationToken = correlationtoken6;
            this.onTaskChanged11.Executor = null;
            this.onTaskChanged11.Name = "onTaskChanged11";
            this.onTaskChanged11.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged11.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged11_Invoked);
            // 
            // createTask11
            // 
            this.createTask11.CorrelationToken = correlationtoken6;
            this.createTask11.ListItemId = -1;
            this.createTask11.Name = "createTask11";
            this.createTask11.SpecialPermissions = null;
            activitybind22.Name = "Workflow1";
            activitybind22.Path = "TaskId11";
            activitybind23.Name = "Workflow1";
            activitybind23.Path = "TaskProperties11";
            this.createTask11.MethodInvoking += new System.EventHandler(this.createTask11_MethodInvoking);
            this.createTask11.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.createTask11.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            // 
            // completeTask10
            // 
            correlationtoken7.Name = "TaskToken10";
            correlationtoken7.OwnerActivityName = "Workflow1";
            this.completeTask10.CorrelationToken = correlationtoken7;
            this.completeTask10.Name = "completeTask10";
            this.completeTask10.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeTask10.TaskOutcome = null;
            // 
            // onTaskChanged10
            // 
            this.onTaskChanged10.AfterProperties = null;
            this.onTaskChanged10.BeforeProperties = null;
            this.onTaskChanged10.CorrelationToken = correlationtoken7;
            this.onTaskChanged10.Executor = null;
            this.onTaskChanged10.Name = "onTaskChanged10";
            this.onTaskChanged10.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged10.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged10_Invoked);
            // 
            // createTask10
            // 
            this.createTask10.CorrelationToken = correlationtoken7;
            this.createTask10.ListItemId = -1;
            this.createTask10.Name = "createTask10";
            this.createTask10.SpecialPermissions = null;
            activitybind24.Name = "Workflow1";
            activitybind24.Path = "TaskId10";
            activitybind25.Name = "Workflow1";
            activitybind25.Path = "TaskProperties10";
            this.createTask10.MethodInvoking += new System.EventHandler(this.createTask10_MethodInvoking);
            this.createTask10.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.createTask10.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            // 
            // completeTask9
            // 
            correlationtoken8.Name = "TaskToken9";
            correlationtoken8.OwnerActivityName = "Workflow1";
            this.completeTask9.CorrelationToken = correlationtoken8;
            this.completeTask9.Name = "completeTask9";
            this.completeTask9.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeTask9.TaskOutcome = null;
            // 
            // onTaskChanged9
            // 
            this.onTaskChanged9.AfterProperties = null;
            this.onTaskChanged9.BeforeProperties = null;
            this.onTaskChanged9.CorrelationToken = correlationtoken8;
            this.onTaskChanged9.Executor = null;
            this.onTaskChanged9.Name = "onTaskChanged9";
            this.onTaskChanged9.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged9.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged9_Invoked);
            // 
            // createTask9
            // 
            this.createTask9.CorrelationToken = correlationtoken8;
            this.createTask9.ListItemId = -1;
            this.createTask9.Name = "createTask9";
            this.createTask9.SpecialPermissions = null;
            activitybind26.Name = "Workflow1";
            activitybind26.Path = "TaskId9";
            activitybind27.Name = "Workflow1";
            activitybind27.Path = "TaskProperties9";
            this.createTask9.MethodInvoking += new System.EventHandler(this.createTask9_MethodInvoking);
            this.createTask9.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.createTask9.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            // 
            // completeTask8
            // 
            correlationtoken9.Name = "TaskToken8";
            correlationtoken9.OwnerActivityName = "Workflow1";
            this.completeTask8.CorrelationToken = correlationtoken9;
            this.completeTask8.Name = "completeTask8";
            this.completeTask8.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeTask8.TaskOutcome = null;
            // 
            // onTaskChanged8
            // 
            this.onTaskChanged8.AfterProperties = null;
            this.onTaskChanged8.BeforeProperties = null;
            this.onTaskChanged8.CorrelationToken = correlationtoken9;
            this.onTaskChanged8.Executor = null;
            this.onTaskChanged8.Name = "onTaskChanged8";
            this.onTaskChanged8.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged8.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged8_Invoked);
            // 
            // createTask8
            // 
            this.createTask8.CorrelationToken = correlationtoken9;
            this.createTask8.ListItemId = -1;
            this.createTask8.Name = "createTask8";
            this.createTask8.SpecialPermissions = null;
            activitybind28.Name = "Workflow1";
            activitybind28.Path = "TaskId8";
            activitybind29.Name = "Workflow1";
            activitybind29.Path = "TaskProperties8";
            this.createTask8.MethodInvoking += new System.EventHandler(this.createTask8_MethodInvoking);
            this.createTask8.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.createTask8.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            // 
            // completeTask7
            // 
            correlationtoken10.Name = "TaskToken7";
            correlationtoken10.OwnerActivityName = "Workflow1";
            this.completeTask7.CorrelationToken = correlationtoken10;
            this.completeTask7.Name = "completeTask7";
            activitybind30.Name = "Workflow1";
            activitybind30.Path = "TaskId7";
            this.completeTask7.TaskOutcome = null;
            this.completeTask7.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            // 
            // onTaskChanged7
            // 
            activitybind31.Name = "Workflow1";
            activitybind31.Path = "TaskProperties7";
            activitybind32.Name = "Workflow1";
            activitybind32.Path = "TaskProperties7";
            this.onTaskChanged7.CorrelationToken = correlationtoken10;
            this.onTaskChanged7.Executor = null;
            this.onTaskChanged7.Name = "onTaskChanged7";
            this.onTaskChanged7.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged7.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged7_Invoked);
            this.onTaskChanged7.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.onTaskChanged7.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            // 
            // createTask7
            // 
            this.createTask7.CorrelationToken = correlationtoken10;
            this.createTask7.ListItemId = -1;
            this.createTask7.Name = "createTask7";
            this.createTask7.SpecialPermissions = null;
            activitybind33.Name = "Workflow1";
            activitybind33.Path = "TaskId7";
            activitybind34.Name = "Workflow1";
            activitybind34.Path = "TaskProperties7";
            this.createTask7.MethodInvoking += new System.EventHandler(this.createTask7_MethodInvoking);
            this.createTask7.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind33)));
            this.createTask7.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind34)));
            // 
            // completeTask6
            // 
            correlationtoken11.Name = "TaskToken6";
            correlationtoken11.OwnerActivityName = "Workflow1";
            this.completeTask6.CorrelationToken = correlationtoken11;
            this.completeTask6.Name = "completeTask6";
            activitybind35.Name = "Workflow1";
            activitybind35.Path = "TaskId6";
            this.completeTask6.TaskOutcome = null;
            this.completeTask6.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind35)));
            // 
            // onTaskChanged6
            // 
            activitybind36.Name = "Workflow1";
            activitybind36.Path = "TaskProperties6";
            activitybind37.Name = "Workflow1";
            activitybind37.Path = "TaskProperties6";
            this.onTaskChanged6.CorrelationToken = correlationtoken11;
            this.onTaskChanged6.Executor = null;
            this.onTaskChanged6.Name = "onTaskChanged6";
            this.onTaskChanged6.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged6.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged6_Invoked);
            this.onTaskChanged6.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind36)));
            this.onTaskChanged6.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind37)));
            // 
            // createTask6
            // 
            this.createTask6.CorrelationToken = correlationtoken11;
            this.createTask6.ListItemId = -1;
            this.createTask6.Name = "createTask6";
            this.createTask6.SpecialPermissions = null;
            activitybind38.Name = "Workflow1";
            activitybind38.Path = "TaskId6";
            activitybind39.Name = "Workflow1";
            activitybind39.Path = "TaskProperties6";
            this.createTask6.MethodInvoking += new System.EventHandler(this.createTask6_MethodInvoking);
            this.createTask6.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind38)));
            this.createTask6.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind39)));
            // 
            // completeTask5
            // 
            correlationtoken12.Name = "TaskToken5";
            correlationtoken12.OwnerActivityName = "Workflow1";
            this.completeTask5.CorrelationToken = correlationtoken12;
            this.completeTask5.Name = "completeTask5";
            activitybind40.Name = "Workflow1";
            activitybind40.Path = "TaskId5";
            this.completeTask5.TaskOutcome = null;
            this.completeTask5.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind40)));
            // 
            // onTaskChanged5
            // 
            activitybind41.Name = "Workflow1";
            activitybind41.Path = "TaskProperties5";
            activitybind42.Name = "Workflow1";
            activitybind42.Path = "TaskProperties5";
            this.onTaskChanged5.CorrelationToken = correlationtoken12;
            this.onTaskChanged5.Executor = null;
            this.onTaskChanged5.Name = "onTaskChanged5";
            this.onTaskChanged5.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged5.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged5_Invoked);
            this.onTaskChanged5.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind41)));
            this.onTaskChanged5.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind42)));
            // 
            // createTask5
            // 
            this.createTask5.CorrelationToken = correlationtoken12;
            this.createTask5.ListItemId = -1;
            this.createTask5.Name = "createTask5";
            this.createTask5.SpecialPermissions = null;
            activitybind43.Name = "Workflow1";
            activitybind43.Path = "TaskId5";
            activitybind44.Name = "Workflow1";
            activitybind44.Path = "TaskProperties5";
            this.createTask5.MethodInvoking += new System.EventHandler(this.createTask5_MethodInvoking);
            this.createTask5.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind43)));
            this.createTask5.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind44)));
            // 
            // completeTask4
            // 
            correlationtoken13.Name = "TaskToken4";
            correlationtoken13.OwnerActivityName = "Workflow1";
            this.completeTask4.CorrelationToken = correlationtoken13;
            this.completeTask4.Name = "completeTask4";
            activitybind45.Name = "Workflow1";
            activitybind45.Path = "TaskId4";
            this.completeTask4.TaskOutcome = null;
            this.completeTask4.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind45)));
            // 
            // onTaskChanged4
            // 
            activitybind46.Name = "Workflow1";
            activitybind46.Path = "TaskProperties4";
            activitybind47.Name = "Workflow1";
            activitybind47.Path = "TaskProperties4";
            this.onTaskChanged4.CorrelationToken = correlationtoken13;
            this.onTaskChanged4.Executor = null;
            this.onTaskChanged4.Name = "onTaskChanged4";
            this.onTaskChanged4.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged4.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged4_Invoked);
            this.onTaskChanged4.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind46)));
            this.onTaskChanged4.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind47)));
            // 
            // createTask4
            // 
            this.createTask4.CorrelationToken = correlationtoken13;
            this.createTask4.ListItemId = -1;
            this.createTask4.Name = "createTask4";
            this.createTask4.SpecialPermissions = null;
            activitybind48.Name = "Workflow1";
            activitybind48.Path = "TaskId4";
            activitybind49.Name = "Workflow1";
            activitybind49.Path = "TaskProperties4";
            this.createTask4.MethodInvoking += new System.EventHandler(this.createTask4_MethodInvoking);
            this.createTask4.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind48)));
            this.createTask4.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind49)));
            // 
            // completeTask3
            // 
            correlationtoken14.Name = "TaskToken3";
            correlationtoken14.OwnerActivityName = "Workflow1";
            this.completeTask3.CorrelationToken = correlationtoken14;
            this.completeTask3.Name = "completeTask3";
            activitybind50.Name = "Workflow1";
            activitybind50.Path = "TaskId3";
            this.completeTask3.TaskOutcome = null;
            this.completeTask3.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind50)));
            // 
            // onTaskChanged3
            // 
            activitybind51.Name = "Workflow1";
            activitybind51.Path = "TaskProperties3";
            activitybind52.Name = "Workflow1";
            activitybind52.Path = "TaskProperties3";
            this.onTaskChanged3.CorrelationToken = correlationtoken14;
            this.onTaskChanged3.Executor = null;
            this.onTaskChanged3.Name = "onTaskChanged3";
            this.onTaskChanged3.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged3.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged3_Invoked);
            this.onTaskChanged3.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind51)));
            this.onTaskChanged3.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind52)));
            // 
            // createTask3
            // 
            this.createTask3.CorrelationToken = correlationtoken14;
            this.createTask3.ListItemId = -1;
            this.createTask3.Name = "createTask3";
            this.createTask3.SpecialPermissions = null;
            activitybind53.Name = "Workflow1";
            activitybind53.Path = "TaskId3";
            activitybind54.Name = "Workflow1";
            activitybind54.Path = "TaskProperties3";
            this.createTask3.MethodInvoking += new System.EventHandler(this.createTask3_MethodInvoking);
            this.createTask3.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind53)));
            this.createTask3.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind54)));
            // 
            // completeTask2
            // 
            correlationtoken15.Name = "TaskToken2";
            correlationtoken15.OwnerActivityName = "Workflow1";
            this.completeTask2.CorrelationToken = correlationtoken15;
            this.completeTask2.Name = "completeTask2";
            activitybind55.Name = "Workflow1";
            activitybind55.Path = "TaskId2";
            this.completeTask2.TaskOutcome = null;
            this.completeTask2.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind55)));
            // 
            // onTaskChanged2
            // 
            activitybind56.Name = "Workflow1";
            activitybind56.Path = "TaskProperties2";
            activitybind57.Name = "Workflow1";
            activitybind57.Path = "TaskProperties2";
            this.onTaskChanged2.CorrelationToken = correlationtoken15;
            this.onTaskChanged2.Executor = null;
            this.onTaskChanged2.Name = "onTaskChanged2";
            this.onTaskChanged2.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged2.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged2_Invoked);
            this.onTaskChanged2.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind56)));
            this.onTaskChanged2.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind57)));
            // 
            // createTask2
            // 
            this.createTask2.CorrelationToken = correlationtoken15;
            this.createTask2.ListItemId = -1;
            this.createTask2.Name = "createTask2";
            this.createTask2.SpecialPermissions = null;
            activitybind58.Name = "Workflow1";
            activitybind58.Path = "TaskId2";
            activitybind59.Name = "Workflow1";
            activitybind59.Path = "TaskProperties2";
            this.createTask2.MethodInvoking += new System.EventHandler(this.createTask2_MethodInvoking);
            this.createTask2.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind58)));
            this.createTask2.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind59)));
            // 
            // completeTask1
            // 
            correlationtoken16.Name = "TaskToken1";
            correlationtoken16.OwnerActivityName = "Workflow1";
            this.completeTask1.CorrelationToken = correlationtoken16;
            this.completeTask1.Name = "completeTask1";
            activitybind60.Name = "Workflow1";
            activitybind60.Path = "TaskId1";
            activitybind61.Name = "Workflow1";
            activitybind61.Path = "Name";
            this.completeTask1.MethodInvoking += new System.EventHandler(this.completeTask1_MethodInvoking);
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind60)));
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind61)));
            // 
            // onTaskChanged1
            // 
            activitybind62.Name = "Workflow1";
            activitybind62.Path = "TaskProperties1";
            activitybind63.Name = "Workflow1";
            activitybind63.Path = "TaskProperties1";
            this.onTaskChanged1.CorrelationToken = correlationtoken16;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            this.onTaskChanged1.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind62)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind63)));
            // 
            // createTask1
            // 
            this.createTask1.CorrelationToken = correlationtoken16;
            this.createTask1.ListItemId = -1;
            this.createTask1.Name = "createTask1";
            this.createTask1.SpecialPermissions = null;
            activitybind64.Name = "Workflow1";
            activitybind64.Path = "TaskId1";
            activitybind65.Name = "Workflow1";
            activitybind65.Path = "TaskProperties1";
            this.createTask1.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind64)));
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind65)));
            // 
            // ifElseBranchActivity36
            // 
            this.ifElseBranchActivity36.Name = "ifElseBranchActivity36";
            // 
            // ifElseBranchActivity35
            // 
            this.ifElseBranchActivity35.Activities.Add(this.codeActivity3);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.OnBonnetHeatNo);
            this.ifElseBranchActivity35.Condition = codecondition1;
            this.ifElseBranchActivity35.Name = "ifElseBranchActivity35";
            // 
            // ifElseBranchActivity34
            // 
            this.ifElseBranchActivity34.Name = "ifElseBranchActivity34";
            // 
            // ifElseBranchActivity33
            // 
            this.ifElseBranchActivity33.Activities.Add(this.codeActivity2);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.OnBodyHeatNo);
            this.ifElseBranchActivity33.Condition = codecondition2;
            this.ifElseBranchActivity33.Name = "ifElseBranchActivity33";
            // 
            // ifElseBranchActivity32
            // 
            this.ifElseBranchActivity32.Name = "ifElseBranchActivity32";
            // 
            // ifElseBranchActivity31
            // 
            this.ifElseBranchActivity31.Activities.Add(this.createTask16);
            this.ifElseBranchActivity31.Activities.Add(this.onTaskChanged16);
            this.ifElseBranchActivity31.Activities.Add(this.completeTask16);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_Hardness_CreateTask);
            this.ifElseBranchActivity31.Condition = codecondition3;
            this.ifElseBranchActivity31.Name = "ifElseBranchActivity31";
            // 
            // ifElseBranchActivity30
            // 
            this.ifElseBranchActivity30.Name = "ifElseBranchActivity30";
            // 
            // ifElseBranchActivity29
            // 
            this.ifElseBranchActivity29.Activities.Add(this.createTask15);
            this.ifElseBranchActivity29.Activities.Add(this.onTaskChanged15);
            this.ifElseBranchActivity29.Activities.Add(this.completeTask15);
            codecondition4.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_RA_CreateTask);
            this.ifElseBranchActivity29.Condition = codecondition4;
            this.ifElseBranchActivity29.Name = "ifElseBranchActivity29";
            // 
            // ifElseBranchActivity28
            // 
            this.ifElseBranchActivity28.Name = "ifElseBranchActivity28";
            // 
            // ifElseBranchActivity27
            // 
            this.ifElseBranchActivity27.Activities.Add(this.createTask14);
            this.ifElseBranchActivity27.Activities.Add(this.onTaskChanged14);
            this.ifElseBranchActivity27.Activities.Add(this.completeTask14);
            codecondition5.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_EL_CreateTask);
            this.ifElseBranchActivity27.Condition = codecondition5;
            this.ifElseBranchActivity27.Name = "ifElseBranchActivity27";
            // 
            // ifElseBranchActivity26
            // 
            this.ifElseBranchActivity26.Name = "ifElseBranchActivity26";
            // 
            // ifElseBranchActivity25
            // 
            this.ifElseBranchActivity25.Activities.Add(this.createTask13);
            this.ifElseBranchActivity25.Activities.Add(this.onTaskChanged13);
            this.ifElseBranchActivity25.Activities.Add(this.completeTask13);
            codecondition6.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_YS_CreateTask);
            this.ifElseBranchActivity25.Condition = codecondition6;
            this.ifElseBranchActivity25.Name = "ifElseBranchActivity25";
            // 
            // ifElseBranchActivity24
            // 
            this.ifElseBranchActivity24.Name = "ifElseBranchActivity24";
            // 
            // ifElseBranchActivity23
            // 
            this.ifElseBranchActivity23.Activities.Add(this.createTask12);
            this.ifElseBranchActivity23.Activities.Add(this.onTaskChanged12);
            this.ifElseBranchActivity23.Activities.Add(this.completeTask12);
            codecondition7.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_TS_CreateTask);
            this.ifElseBranchActivity23.Condition = codecondition7;
            this.ifElseBranchActivity23.Name = "ifElseBranchActivity23";
            // 
            // ifElseBranchActivity22
            // 
            this.ifElseBranchActivity22.Name = "ifElseBranchActivity22";
            // 
            // ifElseBranchActivity21
            // 
            this.ifElseBranchActivity21.Activities.Add(this.createTask11);
            this.ifElseBranchActivity21.Activities.Add(this.onTaskChanged11);
            this.ifElseBranchActivity21.Activities.Add(this.completeTask11);
            codecondition8.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_NB_CreateTask);
            this.ifElseBranchActivity21.Condition = codecondition8;
            this.ifElseBranchActivity21.Name = "ifElseBranchActivity21";
            // 
            // ifElseBranchActivity20
            // 
            this.ifElseBranchActivity20.Name = "ifElseBranchActivity20";
            // 
            // ifElseBranchActivity19
            // 
            this.ifElseBranchActivity19.Activities.Add(this.createTask10);
            this.ifElseBranchActivity19.Activities.Add(this.onTaskChanged10);
            this.ifElseBranchActivity19.Activities.Add(this.completeTask10);
            codecondition9.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_V_CreateTask);
            this.ifElseBranchActivity19.Condition = codecondition9;
            this.ifElseBranchActivity19.Name = "ifElseBranchActivity19";
            // 
            // ifElseBranchActivity18
            // 
            this.ifElseBranchActivity18.Name = "ifElseBranchActivity18";
            // 
            // ifElseBranchActivity17
            // 
            this.ifElseBranchActivity17.Activities.Add(this.createTask9);
            this.ifElseBranchActivity17.Activities.Add(this.onTaskChanged9);
            this.ifElseBranchActivity17.Activities.Add(this.completeTask9);
            codecondition10.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_MO_CreateTask);
            this.ifElseBranchActivity17.Condition = codecondition10;
            this.ifElseBranchActivity17.Name = "ifElseBranchActivity17";
            // 
            // ifElseBranchActivity16
            // 
            this.ifElseBranchActivity16.Name = "ifElseBranchActivity16";
            // 
            // ifElseBranchActivity15
            // 
            this.ifElseBranchActivity15.Activities.Add(this.createTask8);
            this.ifElseBranchActivity15.Activities.Add(this.onTaskChanged8);
            this.ifElseBranchActivity15.Activities.Add(this.completeTask8);
            codecondition11.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_CR_CreateTask);
            this.ifElseBranchActivity15.Condition = codecondition11;
            this.ifElseBranchActivity15.Name = "ifElseBranchActivity15";
            // 
            // ifElseBranchActivity14
            // 
            this.ifElseBranchActivity14.Name = "ifElseBranchActivity14";
            // 
            // ifElseBranchActivity13
            // 
            this.ifElseBranchActivity13.Activities.Add(this.createTask7);
            this.ifElseBranchActivity13.Activities.Add(this.onTaskChanged7);
            this.ifElseBranchActivity13.Activities.Add(this.completeTask7);
            codecondition12.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_NI_CreateTask);
            this.ifElseBranchActivity13.Condition = codecondition12;
            this.ifElseBranchActivity13.Name = "ifElseBranchActivity13";
            // 
            // ifElseBranchActivity12
            // 
            this.ifElseBranchActivity12.Name = "ifElseBranchActivity12";
            // 
            // ifElseBranchActivity11
            // 
            this.ifElseBranchActivity11.Activities.Add(this.createTask6);
            this.ifElseBranchActivity11.Activities.Add(this.onTaskChanged6);
            this.ifElseBranchActivity11.Activities.Add(this.completeTask6);
            codecondition13.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_CU_CreateTask);
            this.ifElseBranchActivity11.Condition = codecondition13;
            this.ifElseBranchActivity11.Name = "ifElseBranchActivity11";
            // 
            // ifElseBranchActivity10
            // 
            this.ifElseBranchActivity10.Name = "ifElseBranchActivity10";
            // 
            // ifElseBranchActivity9
            // 
            this.ifElseBranchActivity9.Activities.Add(this.createTask5);
            this.ifElseBranchActivity9.Activities.Add(this.onTaskChanged5);
            this.ifElseBranchActivity9.Activities.Add(this.completeTask5);
            codecondition14.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_SI_CreateTask);
            this.ifElseBranchActivity9.Condition = codecondition14;
            this.ifElseBranchActivity9.Name = "ifElseBranchActivity9";
            // 
            // ifElseBranchActivity8
            // 
            this.ifElseBranchActivity8.Name = "ifElseBranchActivity8";
            // 
            // ifElseBranchActivity7
            // 
            this.ifElseBranchActivity7.Activities.Add(this.createTask4);
            this.ifElseBranchActivity7.Activities.Add(this.onTaskChanged4);
            this.ifElseBranchActivity7.Activities.Add(this.completeTask4);
            codecondition15.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_S_CreateTask);
            this.ifElseBranchActivity7.Condition = codecondition15;
            this.ifElseBranchActivity7.Name = "ifElseBranchActivity7";
            // 
            // ifElseBranchActivity6
            // 
            this.ifElseBranchActivity6.Name = "ifElseBranchActivity6";
            // 
            // ifElseBranchActivity5
            // 
            this.ifElseBranchActivity5.Activities.Add(this.createTask3);
            this.ifElseBranchActivity5.Activities.Add(this.onTaskChanged3);
            this.ifElseBranchActivity5.Activities.Add(this.completeTask3);
            codecondition16.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_P_CreateTask);
            this.ifElseBranchActivity5.Condition = codecondition16;
            this.ifElseBranchActivity5.Name = "ifElseBranchActivity5";
            // 
            // ifElseBranchActivity4
            // 
            this.ifElseBranchActivity4.Name = "ifElseBranchActivity4";
            // 
            // ifElseBranchActivity3
            // 
            this.ifElseBranchActivity3.Activities.Add(this.createTask2);
            this.ifElseBranchActivity3.Activities.Add(this.onTaskChanged2);
            this.ifElseBranchActivity3.Activities.Add(this.completeTask2);
            codecondition17.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_Mn_CreateTask);
            this.ifElseBranchActivity3.Condition = codecondition17;
            this.ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.createTask1);
            this.ifElseBranchActivity1.Activities.Add(this.onTaskChanged1);
            this.ifElseBranchActivity1.Activities.Add(this.completeTask1);
            codecondition18.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.Condition_C_CreateTask);
            this.ifElseBranchActivity1.Condition = codecondition18;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // ifElseActivity18
            // 
            this.ifElseActivity18.Activities.Add(this.ifElseBranchActivity35);
            this.ifElseActivity18.Activities.Add(this.ifElseBranchActivity36);
            this.ifElseActivity18.Name = "ifElseActivity18";
            // 
            // ifElseActivity17
            // 
            this.ifElseActivity17.Activities.Add(this.ifElseBranchActivity33);
            this.ifElseActivity17.Activities.Add(this.ifElseBranchActivity34);
            this.ifElseActivity17.Name = "ifElseActivity17";
            // 
            // ifElseActivity16
            // 
            this.ifElseActivity16.Activities.Add(this.ifElseBranchActivity31);
            this.ifElseActivity16.Activities.Add(this.ifElseBranchActivity32);
            this.ifElseActivity16.Name = "ifElseActivity16";
            // 
            // ifElseActivity15
            // 
            this.ifElseActivity15.Activities.Add(this.ifElseBranchActivity29);
            this.ifElseActivity15.Activities.Add(this.ifElseBranchActivity30);
            this.ifElseActivity15.Name = "ifElseActivity15";
            // 
            // ifElseActivity14
            // 
            this.ifElseActivity14.Activities.Add(this.ifElseBranchActivity27);
            this.ifElseActivity14.Activities.Add(this.ifElseBranchActivity28);
            this.ifElseActivity14.Name = "ifElseActivity14";
            // 
            // ifElseActivity13
            // 
            this.ifElseActivity13.Activities.Add(this.ifElseBranchActivity25);
            this.ifElseActivity13.Activities.Add(this.ifElseBranchActivity26);
            this.ifElseActivity13.Name = "ifElseActivity13";
            // 
            // ifElseActivity12
            // 
            this.ifElseActivity12.Activities.Add(this.ifElseBranchActivity23);
            this.ifElseActivity12.Activities.Add(this.ifElseBranchActivity24);
            this.ifElseActivity12.Name = "ifElseActivity12";
            // 
            // ifElseActivity11
            // 
            this.ifElseActivity11.Activities.Add(this.ifElseBranchActivity21);
            this.ifElseActivity11.Activities.Add(this.ifElseBranchActivity22);
            this.ifElseActivity11.Name = "ifElseActivity11";
            // 
            // ifElseActivity10
            // 
            this.ifElseActivity10.Activities.Add(this.ifElseBranchActivity19);
            this.ifElseActivity10.Activities.Add(this.ifElseBranchActivity20);
            this.ifElseActivity10.Name = "ifElseActivity10";
            // 
            // ifElseActivity9
            // 
            this.ifElseActivity9.Activities.Add(this.ifElseBranchActivity17);
            this.ifElseActivity9.Activities.Add(this.ifElseBranchActivity18);
            this.ifElseActivity9.Name = "ifElseActivity9";
            // 
            // ifElseActivity8
            // 
            this.ifElseActivity8.Activities.Add(this.ifElseBranchActivity15);
            this.ifElseActivity8.Activities.Add(this.ifElseBranchActivity16);
            this.ifElseActivity8.Name = "ifElseActivity8";
            // 
            // ifElseActivity7
            // 
            this.ifElseActivity7.Activities.Add(this.ifElseBranchActivity13);
            this.ifElseActivity7.Activities.Add(this.ifElseBranchActivity14);
            this.ifElseActivity7.Name = "ifElseActivity7";
            // 
            // ifElseActivity6
            // 
            this.ifElseActivity6.Activities.Add(this.ifElseBranchActivity11);
            this.ifElseActivity6.Activities.Add(this.ifElseBranchActivity12);
            this.ifElseActivity6.Name = "ifElseActivity6";
            // 
            // ifElseActivity5
            // 
            this.ifElseActivity5.Activities.Add(this.ifElseBranchActivity9);
            this.ifElseActivity5.Activities.Add(this.ifElseBranchActivity10);
            this.ifElseActivity5.Name = "ifElseActivity5";
            // 
            // ifElseActivity4
            // 
            this.ifElseActivity4.Activities.Add(this.ifElseBranchActivity7);
            this.ifElseActivity4.Activities.Add(this.ifElseBranchActivity8);
            this.ifElseActivity4.Name = "ifElseActivity4";
            // 
            // ifElseActivity3
            // 
            this.ifElseActivity3.Activities.Add(this.ifElseBranchActivity5);
            this.ifElseActivity3.Activities.Add(this.ifElseBranchActivity6);
            this.ifElseActivity3.Name = "ifElseActivity3";
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity3);
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity4);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // sequenceActivity18
            // 
            this.sequenceActivity18.Activities.Add(this.ifElseActivity18);
            this.sequenceActivity18.Name = "sequenceActivity18";
            // 
            // sequenceActivity17
            // 
            this.sequenceActivity17.Activities.Add(this.ifElseActivity17);
            this.sequenceActivity17.Name = "sequenceActivity17";
            // 
            // sequenceActivity16
            // 
            this.sequenceActivity16.Activities.Add(this.ifElseActivity16);
            this.sequenceActivity16.Name = "sequenceActivity16";
            // 
            // sequenceActivity15
            // 
            this.sequenceActivity15.Activities.Add(this.ifElseActivity15);
            this.sequenceActivity15.Name = "sequenceActivity15";
            // 
            // sequenceActivity14
            // 
            this.sequenceActivity14.Activities.Add(this.ifElseActivity14);
            this.sequenceActivity14.Name = "sequenceActivity14";
            // 
            // sequenceActivity13
            // 
            this.sequenceActivity13.Activities.Add(this.ifElseActivity13);
            this.sequenceActivity13.Name = "sequenceActivity13";
            // 
            // sequenceActivity12
            // 
            this.sequenceActivity12.Activities.Add(this.ifElseActivity12);
            this.sequenceActivity12.Name = "sequenceActivity12";
            // 
            // sequenceActivity11
            // 
            this.sequenceActivity11.Activities.Add(this.ifElseActivity11);
            this.sequenceActivity11.Name = "sequenceActivity11";
            // 
            // sequenceActivity10
            // 
            this.sequenceActivity10.Activities.Add(this.ifElseActivity10);
            this.sequenceActivity10.Name = "sequenceActivity10";
            // 
            // sequenceActivity9
            // 
            this.sequenceActivity9.Activities.Add(this.ifElseActivity9);
            this.sequenceActivity9.Name = "sequenceActivity9";
            // 
            // sequenceActivity8
            // 
            this.sequenceActivity8.Activities.Add(this.ifElseActivity8);
            this.sequenceActivity8.Name = "sequenceActivity8";
            // 
            // sequenceActivity7
            // 
            this.sequenceActivity7.Activities.Add(this.ifElseActivity7);
            this.sequenceActivity7.Name = "sequenceActivity7";
            // 
            // sequenceActivity6
            // 
            this.sequenceActivity6.Activities.Add(this.ifElseActivity6);
            this.sequenceActivity6.Name = "sequenceActivity6";
            // 
            // sequenceActivity5
            // 
            this.sequenceActivity5.Activities.Add(this.ifElseActivity5);
            this.sequenceActivity5.Name = "sequenceActivity5";
            // 
            // sequenceActivity4
            // 
            this.sequenceActivity4.Activities.Add(this.ifElseActivity4);
            this.sequenceActivity4.Name = "sequenceActivity4";
            // 
            // sequenceActivity3
            // 
            this.sequenceActivity3.Activities.Add(this.ifElseActivity3);
            this.sequenceActivity3.Name = "sequenceActivity3";
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.ifElseActivity2);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.ifElseActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // parallelActivity2
            // 
            this.parallelActivity2.Activities.Add(this.sequenceActivity17);
            this.parallelActivity2.Activities.Add(this.sequenceActivity18);
            this.parallelActivity2.Name = "parallelActivity2";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Activities.Add(this.sequenceActivity3);
            this.parallelActivity1.Activities.Add(this.sequenceActivity4);
            this.parallelActivity1.Activities.Add(this.sequenceActivity5);
            this.parallelActivity1.Activities.Add(this.sequenceActivity6);
            this.parallelActivity1.Activities.Add(this.sequenceActivity7);
            this.parallelActivity1.Activities.Add(this.sequenceActivity8);
            this.parallelActivity1.Activities.Add(this.sequenceActivity9);
            this.parallelActivity1.Activities.Add(this.sequenceActivity10);
            this.parallelActivity1.Activities.Add(this.sequenceActivity11);
            this.parallelActivity1.Activities.Add(this.sequenceActivity12);
            this.parallelActivity1.Activities.Add(this.sequenceActivity13);
            this.parallelActivity1.Activities.Add(this.sequenceActivity14);
            this.parallelActivity1.Activities.Add(this.sequenceActivity15);
            this.parallelActivity1.Activities.Add(this.sequenceActivity16);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            activitybind67.Name = "Workflow1";
            activitybind67.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken17.Name = "workflowToken";
            correlationtoken17.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken17;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind66.Name = "Workflow1";
            activitybind66.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind67)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind66)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.parallelActivity1);
            this.Activities.Add(this.parallelActivity2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity3;
        private IfElseBranchActivity ifElseBranchActivity36;
        private IfElseBranchActivity ifElseBranchActivity35;
        private IfElseActivity ifElseActivity18;
        private SequenceActivity sequenceActivity18;
        private SequenceActivity sequenceActivity17;
        private ParallelActivity parallelActivity2;
        private CodeActivity codeActivity2;
        private IfElseBranchActivity ifElseBranchActivity34;
        private IfElseBranchActivity ifElseBranchActivity33;
        private IfElseActivity ifElseActivity17;
        private CodeActivity codeActivity1;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask2;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged2;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask3;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged3;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask4;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged4;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask5;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged5;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged6;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask6;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask16;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged16;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask15;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged15;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask14;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged14;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask13;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged13;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask12;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged12;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask11;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged11;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask10;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged10;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask9;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged9;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask8;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged8;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask7;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged7;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask16;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask15;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask14;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask13;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask12;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask11;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask10;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask9;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask8;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask7;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask6;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask5;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask4;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask3;
        private SequenceActivity sequenceActivity14;
        private SequenceActivity sequenceActivity15;
        private SequenceActivity sequenceActivity16;
        private IfElseBranchActivity ifElseBranchActivity32;
        private IfElseBranchActivity ifElseBranchActivity31;
        private IfElseBranchActivity ifElseBranchActivity30;
        private IfElseBranchActivity ifElseBranchActivity29;
        private IfElseBranchActivity ifElseBranchActivity28;
        private IfElseBranchActivity ifElseBranchActivity27;
        private IfElseActivity ifElseActivity16;
        private IfElseActivity ifElseActivity15;
        private IfElseActivity ifElseActivity14;
        private IfElseBranchActivity ifElseBranchActivity26;
        private IfElseBranchActivity ifElseBranchActivity25;
        private IfElseBranchActivity ifElseBranchActivity24;
        private IfElseBranchActivity ifElseBranchActivity23;
        private IfElseBranchActivity ifElseBranchActivity22;
        private IfElseBranchActivity ifElseBranchActivity21;
        private IfElseBranchActivity ifElseBranchActivity20;
        private IfElseBranchActivity ifElseBranchActivity19;
        private IfElseBranchActivity ifElseBranchActivity18;
        private IfElseBranchActivity ifElseBranchActivity17;
        private IfElseBranchActivity ifElseBranchActivity16;
        private IfElseBranchActivity ifElseBranchActivity15;
        private IfElseBranchActivity ifElseBranchActivity14;
        private IfElseBranchActivity ifElseBranchActivity13;
        private IfElseBranchActivity ifElseBranchActivity12;
        private IfElseBranchActivity ifElseBranchActivity11;
        private IfElseBranchActivity ifElseBranchActivity10;
        private IfElseBranchActivity ifElseBranchActivity9;
        private IfElseBranchActivity ifElseBranchActivity8;
        private IfElseBranchActivity ifElseBranchActivity7;
        private IfElseBranchActivity ifElseBranchActivity6;
        private IfElseBranchActivity ifElseBranchActivity5;
        private IfElseActivity ifElseActivity13;
        private IfElseActivity ifElseActivity12;
        private IfElseActivity ifElseActivity11;
        private IfElseActivity ifElseActivity10;
        private IfElseActivity ifElseActivity9;
        private IfElseActivity ifElseActivity8;
        private IfElseActivity ifElseActivity7;
        private IfElseActivity ifElseActivity6;
        private IfElseActivity ifElseActivity5;
        private IfElseActivity ifElseActivity4;
        private IfElseActivity ifElseActivity3;
        private SequenceActivity sequenceActivity13;
        private SequenceActivity sequenceActivity12;
        private SequenceActivity sequenceActivity11;
        private SequenceActivity sequenceActivity10;
        private SequenceActivity sequenceActivity9;
        private SequenceActivity sequenceActivity8;
        private SequenceActivity sequenceActivity7;
        private SequenceActivity sequenceActivity6;
        private SequenceActivity sequenceActivity5;
        private SequenceActivity sequenceActivity4;
        private SequenceActivity sequenceActivity3;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask2;
        private IfElseBranchActivity ifElseBranchActivity4;
        private IfElseBranchActivity ifElseBranchActivity3;
        private IfElseActivity ifElseActivity2;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private ParallelActivity parallelActivity1;
        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask1;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;


























































































































































































    }
}
