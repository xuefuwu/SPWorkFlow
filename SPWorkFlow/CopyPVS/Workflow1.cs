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

namespace CopyPVS
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void OnPrefixEmpty(object sender, ConditionalEventArgs e)
        {
            e.Result = !this.workflowProperties.Item["Serial Number Prefix"].Equals("");
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                int start = int.Parse(this.workflowProperties.Item["Serial Number Start"].ToString());
                int end = int.Parse(this.workflowProperties.Item["Serial Number End"].ToString().Split('#')[1]);
                SPFieldLookupValueCollection pvs_id = new SPFieldLookupValueCollection();
                SPList PVSRelation = web.GetList("/teamwork/Lists/PVSRelation");
                SPListItemCollection PVSRelationItems = PVSRelation.Items;
                SPListItem PVSRelationItem = null;
                if (ExistRelation(this.workflowProperties.Item) == null)
                {
                    PVSRelationItem = PVSRelationItems.Add();
                    PVSRelationItem["OrderId"] = this.workflowProperties.Item["ID"];
                    PVSRelationItem.Update();
                    for (int count = start; count <= end; count++)
                    {
                        SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                        SPListItemCollection items = PVSList.Items;
                        SPListItem item = items.Add();
                        item["SerialNo"] = count;
                        item["Prefix"] = this.workflowProperties.Item["Serial Number Prefix"];
                        item["Standards"] = this.workflowProperties.Item["Standards"];
                        item["ValveType"] = this.workflowProperties.Item["Valve Type"];
                        item["Size"] = this.workflowProperties.Item["Size"];
                        item["Rating"] = this.workflowProperties.Item["Rating"];
                        item["Brand"] = this.workflowProperties.Item["Brand"];
                        item["Body Material"] = this.workflowProperties.Item["Body Material"];
                        item["Contract No"] = this.workflowProperties.Item["Contract No"];
                        item["OrderItemId"] = this.workflowProperties.Item["ID"];
                        item["NPS"] = getValveSize(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveSize(this.workflowProperties.Item, web).Rows[0]["Title"] : "";
                        item["DN"] = getValveSize(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveSize(this.workflowProperties.Item, web).Rows[0]["DN"] : "";
                        item["CLASS"] = getValveRating(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveRating(this.workflowProperties.Item, web).Rows[0]["Title"] : "";
                        item["PN"] = getValveRating(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveRating(this.workflowProperties.Item, web).Rows[0]["PNEN"] : "";
                        item.Update();
                        SPFieldLookupValue pvs = new SPFieldLookupValue();
                        pvs.LookupId = item.ID;
                        pvs_id.Add(pvs);
                    }
                }
                else
                {
                    PVSRelationItem = ExistRelation(this.workflowProperties.Item);
                    SPFieldLookupValueCollection expvsCollection = (SPFieldLookupValueCollection)PVSRelationItem["PVSId"];
                    int count = start;
                    foreach (SPFieldLookupValue expvs in expvsCollection)
                    {
                        SPList PVSList = web.GetList("/teamwork/Lists/PVS%20Data");
                        SPListItemCollection items = PVSList.Items;
                        SPListItem item = null;
                        try
                        {

                            item = items.GetItemById(int.Parse(expvs.LookupValue));
                            item["SerialNo"] = count;
                            item["Prefix"] = this.workflowProperties.Item["Serial Number Prefix"];
                            item["Standards"] = this.workflowProperties.Item["Standards"];
                            item["ValveType"] = this.workflowProperties.Item["Valve Type"];
                            item["Size"] = this.workflowProperties.Item["Size"];
                            item["Rating"] = this.workflowProperties.Item["Rating"];
                            item["Brand"] = this.workflowProperties.Item["Brand"];
                            item["Body Material"] = this.workflowProperties.Item["Body Material"];
                            item["Contract No"] = this.workflowProperties.Item["Contract No"];
                            item["OrderItemId"] = this.workflowProperties.Item["ID"];
                            item["NPS"] = getValveSize(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveSize(this.workflowProperties.Item, web).Rows[0]["Title"] : "";
                            item["DN"] = getValveSize(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveSize(this.workflowProperties.Item, web).Rows[0]["DN"] : "";
                            item["CLASS"] = getValveRating(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveRating(this.workflowProperties.Item, web).Rows[0]["Title"] : "";
                            item["PN"] = getValveRating(this.workflowProperties.Item, web).Rows.Count > 0 ? getValveRating(this.workflowProperties.Item, web).Rows[0]["PNEN"] : ""; 
                            item.Update();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        SPFieldLookupValue pvs = new SPFieldLookupValue();
                        pvs.LookupId = item.ID;
                        pvs_id.Add(pvs);
                        count++;
                    }
                }
                PVSRelationItem["PVSId"] = pvs_id;
                PVSRelationItem.Update();
            }
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.Out.WriteLine("没有填写Prefix");
        }

        private static SPFieldLookupValue ConvertToLookupValue(string lookupField)
        {
            if (string.IsNullOrEmpty(lookupField)) return null;
            string[] vals = lookupField.Split(";#".ToArray());
            return (vals.Length == 3) ? new SPFieldLookupValue(Convert.ToInt32(vals[0]), vals[2]) : null;
        }

        private SPListItem ExistRelation(SPListItem order)
        {
            SPListItem rtn = null;
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPList PVSRelation = web.GetList("/teamwork/Lists/PVSRelation");
                SPListItemCollection PVSRelationItems = PVSRelation.Items;
                if (PVSRelationItems.Count <= 0)
                {
                    rtn = null;
                }
                else
                {
                    for (int R_count = 0; R_count < PVSRelationItems.Count; R_count++)
                    {
                        if (ConvertToLookupValue(PVSRelationItems[R_count]["OrderId"].ToString()).LookupValue.Equals(order["ID"].ToString()))
                        {
                            rtn = PVSRelationItems[R_count];
                        }
                    }
                }
            }
            return rtn;
        }

        private DataTable getValveRating(SPListItem item, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList LRating = oWebSite.GetList("/teamwork/Lists/Rating");
            String[] ViewFields = { LRating.Fields["ClassEN"].InternalName, LRating.Fields["PNEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + LRating.Fields["RatingDescEN"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + item["Rating"] + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, LRating, oWebSite);

        }

        private DataTable getValveSize(SPListItem item, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList LSize = oWebSite.GetList("/teamwork/Lists/Size");
            String[] ViewFields = {LSize.Fields["NPS"].InternalName,LSize.Fields["DN"].InternalName};
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + LSize.Fields["SizeDescEN"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + item["Size"] + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, LSize, oWebSite);
        }

        private DataTable getSiteDataQuery(String Query, String[] ViewField, SPList QList, SPWeb web)
        {
            DataTable dt = null;

            SPSiteDataQuery query = new SPSiteDataQuery();
          
            //Ask for all lists created from the contacts template.
            query.Lists = string.Format("<Lists><List ID=\"{0}\" /></Lists>", QList.ID);

            // Get the Title (Last Name) and FirstName fields.
            for(int i=0;i<ViewField.Length;i++)
            {
                query.ViewFields += "<FieldRef Name=\"" + ViewField[i] + "\" />";
            }
            query.Query = Query;
            // Query all Web sites in this site collection.
            query.Webs = "<Webs Scope=\"Recursive\" />";
            dt = web.GetSiteData(query);
            return dt;
        }

    }
}
