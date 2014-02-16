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
using System.Data;

namespace CacheMTCMaterials
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
            Material = workflowProperties.Item["Material"].ToString();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public String result_txt = "";
        String Material = "";
        String C = "C", Mn = "Mn", P = "P", S = "S", Si = "Si", Cu = "Cu", Ni = "Ni", Cr = "Cr", Mo = "Mo", V = "V", Nb = "Nb", TS = "T.S.MPa", YS = "Y.S.MPa", EL = "EL", RA = "RA", Hardness = "Hardness";

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
        }

        private Boolean verifyElement(String Material, String ElementName, float value)
        {
            bool rtn = false;
            float Minimum = -1, Maximum = -1;
            DataTable props = getProps(Material, ElementName, this.workflowProperties.Web);
            if (props.Rows.Count > 0)
            {
                if (!props.Rows[0]["Minimum"].Equals(null))
                {
                    Minimum = float.Parse(props.Rows[0]["Minimum"].ToString());
                }

                if (!props.Rows[0]["Maximum"].Equals(null))
                {
                    Maximum = float.Parse(props.Rows[0]["Maximum"].ToString());
                }

                if (Minimum != -1)
                {
                    if (value < Minimum)
                    {
                        result_txt += value + "小于最低标准\n";
                        rtn = true;
                    }
                }
                if (Maximum != -1)
                {
                    if (value > Maximum)
                    {
                        result_txt += value + "大于最高标准\n";
                        rtn = true;
                    }
                }
            }
            return rtn;
        }

        private DataTable getProps(String Material, String ElementName, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList PressureList = oWebSite.GetList("/teamwork/Lists/Chemical%20Standard");
            String[] ViewFields = { PressureList.Fields["Minimum"].InternalName, PressureList.Fields["Maximum"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Chemical Name"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Material + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Element Name"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + ElementName + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, PressureList, oWebSite);
        }

        private DataTable getSiteDataQuery(String Query, String[] ViewField, SPList QList, SPWeb web)
        {
            DataTable dt = null;

            SPSiteDataQuery query = new SPSiteDataQuery();

            //Ask for all lists created from the contacts template.
            query.Lists = string.Format("<Lists><List ID=\"{0}\" /></Lists>", QList.ID);

            // Get the Title (Last Name) and FirstName fields.
            for (int i = 0; i < ViewField.Length; i++)
            {
                query.ViewFields += "<FieldRef Name=\"" + ViewField[i] + "\" />";
            }
            query.Query = Query;
            // Query all Web sites in this site collection.
            query.Webs = "<Webs Scope=\"Recursive\" />";
            dt = web.GetSiteData(query);
            return dt;
        }

        private void Condition_Hardness_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Hardness, float.Parse(workflowProperties.Item[Hardness].ToString()));
        }

        public Guid TaskId1 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void Condition_C_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, C, float.Parse(workflowProperties.Item[C].ToString()));
        }

        private void Condition_Mn_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Mn, float.Parse(workflowProperties.Item[Mn].ToString()));

        }

        public Guid TaskId2 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties2 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void Condition_P_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, P, float.Parse(workflowProperties.Item[P].ToString()));

        }

        private void Condition_S_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, S, float.Parse(workflowProperties.Item[S].ToString()));

        }

        private void Condition_SI_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Si, float.Parse(workflowProperties.Item[Si].ToString()));

        }

        private void Condition_CU_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Cu, float.Parse(workflowProperties.Item[Cu].ToString()));

        }

        private void Condition_NI_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Ni, float.Parse(workflowProperties.Item[Ni].ToString()));

        }

        private void Condition_CR_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Cr, float.Parse(workflowProperties.Item[Cr].ToString()));

        }

        private void Condition_MO_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Mo, float.Parse(workflowProperties.Item[Mo].ToString()));

        }

        private void Condition_V_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, V, float.Parse(workflowProperties.Item[V].ToString()));

        }

        private void Condition_NB_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, Nb, float.Parse(workflowProperties.Item[Nb].ToString()));

        }

        private void Condition_TS_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, TS, float.Parse(workflowProperties.Item[TS].ToString()));

        }

        private void Condition_YS_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, YS, float.Parse(workflowProperties.Item[YS].ToString()));

        }

        private void Condition_EL_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, EL, float.Parse(workflowProperties.Item[EL].ToString()));

        }

        private void Condition_RA_CreateTask(object sender, ConditionalEventArgs e)
        {
            e.Result = verifyElement(Material, RA, float.Parse(workflowProperties.Item[RA].ToString()));

        }

        public Guid TaskId3 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties3 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId4 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties4 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId5 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties5 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId6 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties6 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId7 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties7 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId8 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties8 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId9 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties9 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId10 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties10 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId11 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties11 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId12 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties12 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId13 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties13 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId14 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties14 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId15 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties15 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId16 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties16 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            TaskId1 = new Guid();
            TaskProperties1.Title = result_txt;
            TaskProperties1.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void completeTask1_MethodInvoking(object sender, EventArgs e)
        {
            this.workflowProperties.Item[C] = this.workflowProperties.Web.GetList("/teamwork/Tasks").GetItemById(TaskProperties1.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }
    }
}
