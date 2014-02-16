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

namespace RequestForDrawings
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
            if ((bool)workflowProperties.Item["Drawing_x0020_Request"])
            {
                String inquiryNo = workflowProperties.Item["Inquiry No"].ToString();
                using (SPSite site = new SPSite("http://localhost/EngineeringandQuality/default.aspx"))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        DataTable QuotedBy = getQuoted(inquiryNo, workflowProperties.Web);
                        SPList InquiryList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");
                        SPList drawingList = web.GetList("/EngineeringandQuality/Lists/Request%20For%20Drawings");
                        SPList drawingInfoList = web.GetList("/EngineeringandQuality/Lists/Drawing%20Information");
                        SPListItemCollection drawingItems = drawingList.Items;
                        SPListItemCollection drawingInfoItems = drawingInfoList.Items;
                        SPListItem drawingItem = default(SPListItem);

                        //String ForDrawings = workflowProperties.Item["For Drawing"].ToString();

                        foreach (DataRow row in QuotedBy.Rows)
                        {
                            //DataRowCollection Rows = getInquiryByID(oItem, workflowProperties.Web).Rows;
                            //if (Rows.Count > 0)
                            //{
                            SPFieldLookupValueCollection draw_id = new SPFieldLookupValueCollection();

                            //DataRow row = Rows[0];
                            
                            DataRowCollection drawingRows = getDrawing(inquiryNo, row[InquiryList.Fields["Quoted By"].InternalName].ToString().Split('#')[1], web).Rows;
                            if (drawingRows.Count == 0)
                            {
                                drawingItem = drawingItems.Add();
                                drawingItem["Title"] = inquiryNo;
                                drawingItem["Inquiry_x0020_No_x002e_"] = inquiryNo;
                                drawingItem["DWG_x0020_Number"] = 1;
                                drawingItem["Author"] = row["Author"].ToString();
                                drawingItem["Supplier"] = row["Quoted_x0020_By"].ToString().Split('#')[1];
                                drawingItem.Update();
                                SPFieldLookupValue draw = new SPFieldLookupValue();
                                draw.LookupId = drawingItem.ID;
                                draw_id.Add(draw);
                            }
                            else
                            {
                                drawingItem = drawingItems.GetItemById(int.Parse(drawingRows[0]["ID"].ToString()));
                                drawingItem["Title"] = inquiryNo;
                                drawingItem["DWG_x0020_Number"] = int.Parse(drawingItem["DWG_x0020_Number"].ToString()) + 1;
                                drawingItem.Update();
                                SPFieldLookupValue draw = new SPFieldLookupValue();
                                draw.LookupId = drawingItem.ID;
                                draw_id.Add(draw);
                            }

                            SPListItem drawInfoItem = drawingInfoItems.Add();
                            drawInfoItem["Title"] = row["Title"];
                            drawInfoItem["Inquiry_x0020_No"] = draw_id;
                            drawInfoItem["Item_x0020_Desc"] = row["_x5b8c__x6574__x63cf__x8ff0_"];
                            drawInfoItem["Item_x0020_Price"] = row["_x4ef7__x683c_"];
                            drawInfoItem.Update();
                            SPWorkflowManager manager = site.WorkflowManager;
                            SPWorkflowAssociation iscompleted = drawingList.WorkflowAssociations.GetAssociationByName("Is Completed", new System.Globalization.CultureInfo("en-US"));
                            manager.StartWorkflow(drawingItem, iscompleted, iscompleted.AssociationData, true);
                        }
                        // }
                    }
                }
            }
        }

        #region Query Method
        private DataTable getDrawing(String InquiryNo, String Quoted, SPWeb oWebSite)
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
        private DataTable getQuoted(String inquiry, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/InquirySystem");
            String[] ViewFields = { InquiryList.Fields["Quoted By"].InternalName, InquiryList.Fields["Qty"].InternalName, InquiryList.Fields["完整描述"].InternalName, "Author", InquiryList.Fields["价格"].InternalName, InquiryList.Fields["Model Number"].InternalName, InquiryList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiry + "</Value>" +
                          "</Eq>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
        }
        private DataTable getSiteDataQuery(String Query, String[] ViewField, SPList QList, SPWeb web)
        {
            DataTable dt = null;
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
