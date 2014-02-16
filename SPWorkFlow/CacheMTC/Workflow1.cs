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

namespace CacheMTC
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        /// <summary>
        /// 判断是否选了阀门编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsPVSEmpty(object sender, ConditionalEventArgs e)
        {
            SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
            if (pvsCollection.Count > 0)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }

        private void CachePVSList_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPFieldLookupValueCollection MTC = new SPFieldLookupValueCollection();
                SPFieldLookupValue MTC_id = new SPFieldLookupValue();
                MTC_id.LookupId = this.workflowProperties.Item.ID;
                MTC.Add(MTC_id);

                SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
                foreach (SPFieldLookupValue pvs in pvsCollection)
                {
                    SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                    SPListItemCollection PVSitems = PVSList.Items;
                    SPListItem PVSItem = PVSitems.GetItemById(int.Parse(getPVSData(pvs.LookupValue, web).Rows[0]["ID"].ToString()));
                    PVSItem["MTCNo"] = MTC_id;
                    PVSItem.Update();
                }
            }
        }

        private DataTable getPVSData(String item, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList PVSList = oWebSite.GetList("/teamwork/Lists/PVS%20Data");
            String[] ViewFields = { PVSList.Fields["ID"].InternalName, PVSList.Fields["ValveType"].InternalName, PVSList.Fields["NPS"].InternalName, PVSList.Fields["DN"].InternalName, PVSList.Fields["PN"].InternalName, PVSList.Fields["CLASS"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PVSList.Fields["SerialNo"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + item + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, PVSList, oWebSite);
        }

        private DataTable getDuration(String NPS, String Standard, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList DurationList = oWebSite.GetList("/teamwork/Lists/Inspection%20Duration");
            String[] ViewFields = { DurationList.Fields["Shell Duration"].InternalName, DurationList.Fields["Back Seat Duration"].InternalName, DurationList.Fields["Seal Duration"].InternalName, DurationList.Fields["CV Seal Test"].InternalName, DurationList.Fields["Inspection Unit"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + DurationList.Fields["NPS"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + NPS + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + DurationList.Fields["Inspection Standard"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Standard + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, DurationList, oWebSite);
        }

        private DataTable getPressure(String Rating, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList PressureList = oWebSite.GetList("/teamwork/Lists/Pressure%20Standard");
            String[] ViewFields = { PressureList.Fields["Shell Test"].InternalName, PressureList.Fields["HP Closure Test"].InternalName, PressureList.Fields["LP Closure Test"].InternalName, PressureList.Fields["Back Seat Test"].InternalName, PressureList.Fields["Pressure Unit"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Rating"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Rating + "</Value>" +
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

        private void ShellTestActivity_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
                foreach (SPFieldLookupValue pvs in pvsCollection)
                {
                    SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                    SPListItemCollection PVSitems = PVSList.Items;
                    SPListItem PVSItem = PVSitems.GetItemById(int.Parse(getPVSData(pvs.LookupValue, web).Rows[0]["ID"].ToString()));
                    PVSItem["Shell Test"] = this.workflowProperties.Item["Shell Test"];
                    PVSItem["Shell Pressure"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Shell_x0020_Test"];
                    PVSItem["Shell Pressure Unit"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Pressure_x0020_Unit"];
                    PVSItem["Shell Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Shell_x0020_Duration"];
                    PVSItem["Shell Duration Unit"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Inspection_x0020_Unit"];
                    PVSItem["Shell Test Result"] = "ACCEPTED";
                    PVSItem.Update();
                }
            }
        }

        private void HPClosureActivity_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
                foreach (SPFieldLookupValue pvs in pvsCollection)
                {
                    SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                    SPListItemCollection PVSitems = PVSList.Items;
                    SPListItem PVSItem = PVSitems.GetItemById(int.Parse(getPVSData(pvs.LookupValue, web).Rows[0]["ID"].ToString()));
                    PVSItem["HP Closure Test"] = this.workflowProperties.Item["HP Closure Test"];
                    PVSItem["HP Closure Pressure"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["HP_x0020_Closure_x0020_Test"];
                    PVSItem["HP Closure Pressure Unit"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Pressure_x0020_Unit"];
                    if (PVSItem["ValveType"] == "CHECK VALVE")
                    {
                        PVSItem["HP Closure Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Seal_x0020_Duration"];
                    }
                    else
                    {
                        PVSItem["HP Closure Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["CV_x0020_Seal_x0020_Test"];

                    }
                    PVSItem["HP Closure Duration Unit"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Inspection_x0020_Unit"];
                    PVSItem["HP Closure Test Result"] = "ACCEPTED";
                    PVSItem.Update();
                }
            }
        }

        private void LPClosureActivity_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
                foreach (SPFieldLookupValue pvs in pvsCollection)
                {
                    SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                    SPListItemCollection PVSitems = PVSList.Items;
                    SPListItem PVSItem = PVSitems.GetItemById(int.Parse(getPVSData(pvs.LookupValue, web).Rows[0]["ID"].ToString()));
                    PVSItem["LP Closure Test"] = this.workflowProperties.Item["LP Closure Test"];
                    PVSItem["LP Closure Pressure"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["LP_x0020_Closure_x0020_Test"];
                    PVSItem["LP Closure Pressure Unit"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Pressure_x0020_Unit"];
                    if (PVSItem["ValveType"] == "CHECK VALVE")
                    {
                        PVSItem["LP Closure Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Seal_x0020_Duration"];
                    }
                    else
                    {
                        PVSItem["LP Closure Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["CV_x0020_Seal_x0020_Test"];

                    }
                    PVSItem["LP Closure Duration Unit"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Inspection_x0020_Unit"];
                    PVSItem["LP Closure Test Result"] = "ACCEPTED";
                    PVSItem.Update();
                }
            }
        }

        private void BackActivity_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPFieldLookupValueCollection pvsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["PVS List"];
                foreach (SPFieldLookupValue pvs in pvsCollection)
                {
                    SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                    SPListItemCollection PVSitems = PVSList.Items;
                    SPListItem PVSItem = PVSitems.GetItemById(int.Parse(getPVSData(pvs.LookupValue, web).Rows[0]["ID"].ToString()));
                    PVSItem["Back Seat Test"] = this.workflowProperties.Item["Back Seat Test"];
                    PVSItem["Back Seat Pressure"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Back_x0020_Seat_x0020_Test"];
                    PVSItem["Back Seat Pressure Unit"] = getPressure(PVSItem["CLASS"].ToString(), web).Rows[0]["Pressure_x0020_Unit"];
                    PVSItem["Back Seat Duration"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Back_x0020_Seat_x0020_Duration"];
                    PVSItem["Back Seat Duration Unit"] = getDuration(PVSItem["NPS"].ToString(), this.workflowProperties.Item["Test According To"].ToString(), web).Rows[0]["Inspection_x0020_Unit"];
                    PVSItem["Back Seat Result"] = "ACCEPTED";
                    PVSItem.Update();
                }
            }
        }

    }
}
