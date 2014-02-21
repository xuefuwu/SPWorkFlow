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

namespace SupplierFollowUp
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            using (SPSite site = new SPSite("http://localhost/EngineeringandQuality/default.aspx"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    String InquiryId = workflowProperties.Item["Identity"].ToString();
                    
                    SPList InquiryList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");
                    SPList drawingList = web.GetList("/EngineeringandQuality/Lists/Request%20For%20Drawings");
                    SPList drawingInfoList = web.GetList("/EngineeringandQuality/Lists/Drawing%20Information");

                    SPListItemCollection InquiryItems = InquiryList.Items;
                    SPListItem InquiryItem = InquiryItems.GetItemById(int.Parse(InquiryId));
                }
            }
        }
        #region Query Method
        private System.Data.DataTable getDrawing(String InquiryNo, String Quoted, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/EngineeringandQuality/Lists/Request%20For%20Drawings");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<And>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Inquiry No."].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryNo + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Supplier"].InternalName + "\" />" +
                            "<Value Type=\"Lookup\">" + Quoted + "</Value>" +
                          "</Eq>" +
                          "</And>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private System.Data.DataTable getQuoted(String inquiry, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/InquirySystem");
            String[] ViewFields = { InquiryList.Fields["Quoted By"].InternalName, InquiryList.Fields["Qty"].InternalName, InquiryList.Fields["完整描述"].InternalName, "Author", "ID", InquiryList.Fields["价格"].InternalName, InquiryList.Fields["Model Number"].InternalName, InquiryList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiry + "</Value>" +
                          "</Eq>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
        }
        private System.Data.DataTable getInquiryById(String Id, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/InquirySystem");
            String[] ViewFields = { InquiryList.Fields["Quoted By"].InternalName, InquiryList.Fields["Qty"].InternalName, InquiryList.Fields["完整描述"].InternalName, "Author", "ID", InquiryList.Fields["价格"].InternalName, InquiryList.Fields["Model Number"].InternalName, InquiryList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["ID"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Id + "</Value>" +
                          "</Eq>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
        }
        private System.Data.DataTable getSiteDataQuery(String Query, String[] ViewField, SPList QList, SPWeb web)
        {
            System.Data.DataTable dt = null;
            SPSiteDataQuery query = new SPSiteDataQuery();
            query.Lists = string.Format("<Lists><List ID=\"{0}\" /></Lists>", QList.ID);
            for (int i = 0; i < ViewField.Length; i++)
            {
                query.ViewFields += "<FieldRef Name=\"" + ViewField[i] + "\" />";
            }
            query.Query = Query;
            query.Webs = "<Webs Scope=\"Recursive\" />";
            dt = web.GetSiteData(query);
            return dt;
        }
        #endregion
    }
}
