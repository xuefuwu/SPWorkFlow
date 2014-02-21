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

namespace CacheExportRecord
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        int ShippingItemCount = 0;

        private void OnWhileActivity(object sender, ConditionalEventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                SPList ShippingItems = web.GetList("/teamwork/Lists/Shipping%20Items");
                if (ShippingItemCount < ShippingItems.ItemCount)
                {
                    e.Result = true;
                }
                else
                {
                    e.Result = false;
                }
                ShippingItemCount++;
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = this.workflowProperties.Web)
            {
                if (web != null)
                {
                    SPList ShippingItems = web.GetList("/teamwork/Lists/Shipping%20Items");
                    SPListItemCollection items = ShippingItems.Items;

                    foreach (SPListItem item in items)
                    {
                        string ex_Field_hth = workflowProperties.List.Fields.GetField("物流合同号").InternalName;
                        string si_Field_hth = ShippingItems.Fields.GetField("Export ID").InternalName;
                        if (null != item[si_Field_hth] && !item[si_Field_hth].Equals(""))
                        {
                            if (item[si_Field_hth].ToString().Equals(this.workflowProperties.Item[ex_Field_hth]))
                            {

                                string si_Field_jcrq = ShippingItems.Fields.GetField("进仓日期").InternalName;
                                string ex_Field_jcrq = this.workflowProperties.List.Fields.GetField("进仓日期").InternalName;

                                string si_Field_hq = ShippingItems.Fields.GetField("航期").InternalName;
                                string ex_Field_hq = workflowProperties.List.Fields.GetField("航期").InternalName;

                                string si_Field_sjfh = ShippingItems.Fields.GetField("实际发货日期").InternalName;
                                string ex_Field_sjfh = workflowProperties.List.Fields.GetField("实际发货日期").InternalName;

                                item[si_Field_jcrq] = this.workflowProperties.Item[ex_Field_jcrq];
                                item[si_Field_sjfh] = this.workflowProperties.Item[si_Field_sjfh];
                                item[si_Field_hq] = this.workflowProperties.Item[ex_Field_hq];
                                item.Update();

                            }
                        }
                    }
                }
            }
        }

        private void SyncToOR_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = workflowProperties.Web)
            {
                SPList ExportList = workflowProperties.List;
                SPList orderCNList = web.GetList("/EngineeringandQuality/Lists/OrdersCN");
                SPList orderUSList = web.GetList("/EngineeringandQuality/Lists/OrdersUS");
                SPListItemCollection orderCNItems = orderCNList.Items;
                SPListItemCollection orderUSItems = orderUSList.Items;
                String itemPINo = workflowProperties.Item["Proforma Invoice"].ToString();
                String[] strPINo = itemPINo.Split(',');
                foreach (String PINo in strPINo)
                {
                    DataRowCollection orderCNRow = getOrderCN(PINo, web).Rows;
                    DataRowCollection orderUSRow = getOrderUS(PINo, web).Rows;
                    if (orderCNRow.Count > 0)
                    {
                        SPListItem orderItem = orderCNItems.GetItemById(int.Parse(orderCNRow[0]["ID"].ToString()));
                        orderItem[orderCNList.Fields["Documents Sent"].InternalName] = workflowProperties.Item["_x5ba2__x6237__x6587__x4ef6__x5b"];
                        orderItem.Update();
                    }
                    else if (orderUSRow.Count > 0)
                    {
                        SPListItem orderItem = orderUSItems.GetItemById(int.Parse(orderUSRow[0]["ID"].ToString()));
                        orderItem[orderUSList.Fields["Documents Sent"].InternalName] = workflowProperties.Item["_x5ba2__x6237__x6587__x4ef6__x5b"];
                        orderItem.Update();
                    }
                }
            }
        }
        #region Query Method
        private System.Data.DataTable getOrderCN(String PINo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/EngineeringandQuality/Lists/OrdersCN");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                              "<Eq>" +
                                "<FieldRef Name=\"" + ReviewList.Fields["FBV PI No."].InternalName + "\" />" +
                                "<Value Type=\"Text\">" + PINo + "</Value>" +
                              "</Eq>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private System.Data.DataTable getOrderUS(String PINo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/EngineeringandQuality/Lists/OrdersUS");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                              "<Eq>" +
                                "<FieldRef Name=\"" + ReviewList.Fields["FBV PI No."].InternalName + "\" />" +
                                "<Value Type=\"Text\">" + PINo + "</Value>" +
                              "</Eq>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private System.Data.DataTable getDrawing(String InquiryNo, String Quoted, SPWeb oWebSite)
        {
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
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/InquirySystem");
            String[] ViewFields = { InquiryList.Fields["Quoted By"].InternalName, InquiryList.Fields["Qty"].InternalName, InquiryList.Fields["完整描述"].InternalName, "Author", InquiryList.Fields["ID"].InternalName, InquiryList.Fields["价格"].InternalName, InquiryList.Fields["Model Number"].InternalName, InquiryList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiry + "</Value>" +
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
