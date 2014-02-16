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
using System.Collections.Generic;

namespace CacheMaterials
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();

        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public String[] result_txt = new String[16];
        String Material = "";
        String C = "C", Mn = "Mn", P = "P", S = "S", Si = "Si", Cu = "Cu", Ni = "Ni", Cr = "Cr", Mo = "Mo", V = "V", Nb = "Nb", TS = "T.S.MPa", YS = "Y.S.MPa", EL = "EL", RA = "RA", Hardness = "Hardness";
        public Guid TaskId1 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskId2 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties2 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
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


        private Boolean verifyElement(int index, String Material, String ElementName, float value)
        {
            bool rtn = false;
            float Minimum = -1, Maximum = -1;
            DataTable props = getProps(Material, ElementName, this.workflowProperties.Web);
            if (props.Rows.Count > 0)
            {
                if (!props.Rows[0]["Minimum"].Equals(""))
                {
                    Minimum = float.Parse(props.Rows[0]["Minimum"].ToString());
                }

                if (!props.Rows[0]["Maximum"].Equals(""))
                {
                    Maximum = float.Parse(props.Rows[0]["Maximum"].ToString());
                }

                if (Minimum != -1)
                {
                    if (value < Minimum)
                    {
                        result_txt[index] = ElementName + ":" + value + "小于最低标准:" + Minimum;
                        rtn = true;
                    }
                }
                if (Maximum != -1)
                {
                    if (value > Maximum)
                    {
                        result_txt[index] = ElementName + ":" + value + "大于最高标准" + Maximum;
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
                           "<And>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Chemical Name"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Material + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Element Name"].InternalName + "\" />" +
                            "<Value Type=\"CHOICE\">" + ElementName + "</Value>" +
                          "</Eq>" +
                          "</And>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, PressureList, oWebSite);
        }

        private DataTable getPVSItem(String MTCNo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList PressureList = oWebSite.GetList("/teamwork/Lists/PVS%20Data");
            String[] ViewFields = { PressureList.Fields["ID"].InternalName, PressureList.Fields["BodyHeat"].InternalName, PressureList.Fields["BonnetHeat"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["MTCNo"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + MTCNo + "</Value>" +
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

        private static SPFieldLookupValue ConvertToLookupValue(string lookupField)
        {
            if (string.IsNullOrEmpty(lookupField)) return null;
            string[] vals = lookupField.Split(";#".ToArray());
            return (vals.Length == 3) ? new SPFieldLookupValue(Convert.ToInt32(vals[0]), vals[2]) : null;
        }

        private void Condition_Hardness_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Hardness] != null)
                e.Result = verifyElement(15, Material, Hardness, float.Parse(workflowProperties.Item[Hardness].ToString()));
        }

        private void Condition_C_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[C] != null)

                e.Result = verifyElement(0, Material, C, float.Parse(workflowProperties.Item[C].ToString()));
        }

        private void Condition_Mn_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Mn] != null)
                e.Result = verifyElement(1, Material, Mn, float.Parse(workflowProperties.Item[Mn].ToString()));

        }

        private void Condition_P_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[P] != null)

                e.Result = verifyElement(2, Material, P, float.Parse(workflowProperties.Item[P].ToString()));

        }

        private void Condition_S_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[S] != null)

                e.Result = verifyElement(3, Material, S, float.Parse(workflowProperties.Item[S].ToString()));

        }

        private void Condition_SI_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Si] != null)

                e.Result = verifyElement(4, Material, Si, float.Parse(workflowProperties.Item[Si].ToString()));

        }

        private void Condition_CU_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Cu] != null)

                e.Result = verifyElement(5, Material, Cu, float.Parse(workflowProperties.Item[Cu].ToString()));

        }

        private void Condition_NI_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Ni] != null)

                e.Result = verifyElement(6, Material, Ni, float.Parse(workflowProperties.Item[Ni].ToString()));

        }

        private void Condition_CR_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Cr] != null)
                e.Result = verifyElement(7, Material, Cr, float.Parse(workflowProperties.Item[Cr].ToString()));
        }

        private void Condition_MO_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Mo] != null)
                e.Result = verifyElement(8, Material, Mo, float.Parse(workflowProperties.Item[Mo].ToString()));
        }

        private void Condition_V_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[V] != null)

                e.Result = verifyElement(9, Material, V, float.Parse(workflowProperties.Item[V].ToString()));

        }

        private void Condition_NB_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[Nb] != null)

                e.Result = verifyElement(10, Material, Nb, float.Parse(workflowProperties.Item[Nb].ToString()));

        }

        private void Condition_TS_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[TS] != null)

                e.Result = verifyElement(11, Material, TS, float.Parse(workflowProperties.Item[TS].ToString()));

        }

        private void Condition_YS_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[YS] != null)

                e.Result = verifyElement(12, Material, YS, float.Parse(workflowProperties.Item[YS].ToString()));

        }

        private void Condition_EL_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[EL] != null)

                e.Result = verifyElement(13, Material, EL, float.Parse(workflowProperties.Item[EL].ToString()));

        }

        private void Condition_RA_CreateTask(object sender, ConditionalEventArgs e)
        {
            if (workflowProperties.Item[RA] != null)

                e.Result = verifyElement(14, Material, RA, float.Parse(workflowProperties.Item[RA].ToString()));

        }

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId1 = Guid.NewGuid();
            TaskProperties1.Title = result_txt[0];
            TaskProperties1.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void completeTask1_MethodInvoking(object sender, EventArgs e)
        {
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Material = workflowProperties.Item["Material"].ToString();
        }

        private void onTaskChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[C] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties1.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();

        }

        private void createTask2_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId2 = Guid.NewGuid();
            TaskProperties2.Title = result_txt[1];
            TaskProperties2.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged2_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Mn] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties2.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask3_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId3 = Guid.NewGuid();
            TaskProperties3.Title = result_txt[2];
            TaskProperties3.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged3_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[P] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties3.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask4_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId4 = Guid.NewGuid();
            TaskProperties4.Title = result_txt[3];
            TaskProperties4.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged4_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[S] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties4.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask5_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId5 = Guid.NewGuid();
            TaskProperties5.Title = result_txt[4];
            TaskProperties5.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged5_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Si] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties5.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask6_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId6 = Guid.NewGuid();
            TaskProperties6.Title = result_txt[5];
            TaskProperties6.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged6_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Cu] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask7_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId7 = Guid.NewGuid();
            TaskProperties7.Title = result_txt[6];
            TaskProperties7.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged7_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Ni] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask8_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId8 = Guid.NewGuid();
            TaskProperties8.Title = result_txt[7];
            TaskProperties8.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged8_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Cr] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask9_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId9 = Guid.NewGuid();
            TaskProperties9.Title = result_txt[8];
            TaskProperties9.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged9_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Mo] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask10_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId10 = Guid.NewGuid();
            TaskProperties10.Title = result_txt[9];
            TaskProperties10.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged10_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[V] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask11_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId11 = Guid.NewGuid();
            TaskProperties11.Title = result_txt[10];
            TaskProperties11.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged11_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Nb] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask12_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId12 = Guid.NewGuid();
            TaskProperties12.Title = result_txt[11];
            TaskProperties12.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged12_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[TS] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask13_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId13 = Guid.NewGuid();
            TaskProperties13.Title = result_txt[12];
            TaskProperties13.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged13_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[YS] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask14_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId14 = Guid.NewGuid();
            TaskProperties14.Title = result_txt[13];
            TaskProperties14.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged14_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[EL] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask15_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId15 = Guid.NewGuid();
            TaskProperties15.Title = result_txt[14];
            TaskProperties15.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged15_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[RA] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void createTask16_MethodInvoking(object sender, EventArgs e)
        {
            this.TaskId16 = Guid.NewGuid();
            TaskProperties16.Title = result_txt[15];
            TaskProperties16.AssignedTo = this.workflowProperties.Item["Author"].ToString().Split('#')[1];
        }

        private void onTaskChanged16_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.workflowProperties.Item[Hardness] = this.workflowProperties.Web.GetList("/teamwork/Lists/Tasks").GetItemById(TaskProperties6.TaskItemId)["Material Props"];
            this.workflowProperties.Item.Update();
        }

        private void OnBodyHeatNo(object sender, ConditionalEventArgs e)
        {
            if (this.workflowProperties.Item["Part Name"].ToString().ToLower() == "body")
            {
                e.Result = true;
            }
        }
        private void OnBonnetHeatNo(object sender, ConditionalEventArgs e)
        {
            if (this.workflowProperties.Item["Part Name"].ToString().ToLower() == "closure" || this.workflowProperties.Item["Part Name"].ToString().ToLower() == "cover" || this.workflowProperties.Item["Part Name"].ToString().ToLower() == "bonnet")
            {
                e.Result = true;
            }
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            if (this.workflowProperties.Item["MTCId"].ToString().Trim().Length > 0)
            {
                DataTable pvsItems = getPVSItem(ConvertToLookupValue(this.workflowProperties.Item["MTCId"].ToString()).LookupValue, this.workflowProperties.Web);
                SPList PVSList = this.workflowProperties.Web.GetList("/teamwork/Lists/PVS%20Data");
                for (int i = 0; i < pvsItems.Rows.Count; i++)
                {
                    SPListItem pvs = PVSList.GetItemById(int.Parse(pvsItems.Rows[i]["ID"].ToString()));
                    pvs["BodyHeat"] = this.workflowProperties.Item["Heat No"];
                    pvs.Update();
                }
            }
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            if (this.workflowProperties.Item["MTCId"].ToString().Trim().Length > 0)
            {
                DataTable pvsItems = getPVSItem(ConvertToLookupValue(this.workflowProperties.Item["MTCId"].ToString()).LookupValue, this.workflowProperties.Web);
                SPList PVSList = this.workflowProperties.Web.GetList("/teamwork/Lists/PVS%20Data");
                for (int i = 0; i < pvsItems.Rows.Count; i++)
                {
                    SPListItem pvs = PVSList.GetItemById(int.Parse(pvsItems.Rows[i]["ID"].ToString()));
                    pvs["BonnetHeat"] = this.workflowProperties.Item["Heat No"];
                    pvs.Update();
                }
            }
        }
    }
}
