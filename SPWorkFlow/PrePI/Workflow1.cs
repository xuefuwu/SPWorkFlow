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

namespace PrePI
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public String PINUM = default(String);
        public String ReviewID = default(String);


        #region 查询方法 Query Method
        private DataTable getPrepareByPI(String PINo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/PI%20Prepare");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["PI No"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private DataTable getInquiryByID(String id, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/InquirySystem");
            String[] ViewFields = { InquiryList.Fields["Quoted By"].InternalName, InquiryList.Fields["Qty"].InternalName, InquiryList.Fields["ID"].InternalName, InquiryList.Fields["询单号"].InternalName, InquiryList.Fields["完整描述"].InternalName, "Author", InquiryList.Fields["价格"].InternalName, InquiryList.Fields["Model Number"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["ID"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + id + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
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

        private DataTable getPINUM(String docid, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList PressureList = oWebSite.GetList("/teamwork/Lists/Doc%20Id%20Control");
            String[] ViewFields = { PressureList.Fields["Doc Id String"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + PressureList.Fields["Doc Id"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + docid + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, PressureList, oWebSite);
        }

        private DataTable getReview(String PINo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Contract%20Review");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["评审编号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getComReview(String PINo, String Quoted, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/List5");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<And>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["评审编号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["供应商"].InternalName + "\" />" +
                            "<Value Type=\"Lookup\">" + Quoted + "</Value>" +
                          "</Eq>" +
                          "</And>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

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

        private DataTable getOrderItems(string InquiryNo, string ModelNumber,string Id, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Order%20Items");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<And>" +
                          "<And>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryNo + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Model Number"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + ModelNumber + "</Value>" +
                          "</Eq>" +
                          "</And>" +
                           "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Identity"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Id + "</Value>" +
                          "</Eq>" +
                        "</And>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private DataTable getContractNo(String inquiry, String quotedBy, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/List5");
            String[] ViewFields = { InquiryList.Fields["合同编号"].InternalName };
            String Query = "<Where>" +
                          "<And>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiry + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["供应商"].InternalName + "\"  LookupId='True' />" +
                            "<Value Type=\"Lookup\">" + quotedBy + "</Value>" +
                          "</Eq>" +
                          "</And>" +
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
        }
        private DataTable getPIByPI(String PINo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Proforma%20Invoice");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"Title\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getPVSNum(String DateString, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/PVS%20Number%20Control");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"Title\" />" +
                            "<Value Type=\"Text\">" + DateString + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private DataTable getInquiryByNo(String InquiryNo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Order%20Items");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryNo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private DataTable getQuotationByInquiry(String InquiryNo, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Quotation%20System");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["Quote No"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Inquiry No"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryNo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
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

        private String PVSNum(int Qty)
        {
            SPList PVSNumList = workflowProperties.Web.GetList("/teamwork/Lists/PVS%20Number%20Control");
            SPListItemCollection PVSItems = PVSNumList.Items;
            String rtn = "";
            int pvsnum = 1;
            String dateString = string.Format("{0:yyMMdd}", DateTime.Now);
            DataRowCollection PVSRows = getPVSNum(dateString, workflowProperties.Web).Rows;
            if (PVSRows.Count > 0)
            {
                SPListItem PVSItem = PVSItems.GetItemById(int.Parse(PVSRows[0]["ID"].ToString()));
                pvsnum = int.Parse(PVSItem["PVS_x0020_Num"].ToString());
                PVSItem["PVS_x0020_Num"] = pvsnum + Qty;
                PVSItem.Update();
            }
            else
            {
                SPListItem PVSItem = PVSItems.Add();
                PVSItem["Title"] = dateString;
                PVSItem["PVS_x0020_Num"] = pvsnum + Qty;
                PVSItem.Update();
            }
            if (pvsnum >= 1000)
            {
                rtn = dateString + pvsnum;
            }
            else if (pvsnum > 100 && pvsnum <= 999)
            {
                rtn = dateString + "0" + pvsnum;
            }
            else if (pvsnum > 10 && pvsnum <= 99)
            {
                rtn = dateString + "00" + pvsnum;
            }
            else
            {
                rtn = dateString + "000" + pvsnum;
            }
            return rtn;
        }
        private static SPFieldLookupValue ConvertToLookupValue(string lookupField)
        {
            if (string.IsNullOrEmpty(lookupField)) return null;
            string[] vals = lookupField.Split(";#".ToArray());
            return (vals.Length == 3) ? new SPFieldLookupValue(Convert.ToInt32(vals[0]), vals[2]) : null;
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            if (workflowProperties.Item["Order Items"] != null && !workflowProperties.Item["Order Items"].Equals(""))
            {
                using (SPWeb web = workflowProperties.Web)
                {
                    SPList InquiryList = web.GetList("/teamwork/Lists/InquirySystem");
                    SPList ReviewList = web.GetList("/teamwork/Lists/Contract%20Review");
                    SPList ComReviewList = web.GetList("/teamwork/Lists/List5");
                    String inquiryNo = workflowProperties.Item["Inquiry Number"].ToString();
                    //SPFieldLookupValueCollection ItemsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["Inquiry Items"];
                    String OrderItems = workflowProperties.Item["Order Items"].ToString();
                    DataTable QuotedBy = getQuoted(inquiryNo, web);
                    SPListItemCollection ComReview = ComReviewList.Items;
                    SPListItemCollection Review = ReviewList.Items;
                    int row_index = 1;
                    //foreach (DataRow row in QuotedBy.Rows)
                    String[] orderItems = new string[1];
                    if (OrderItems.IndexOf("#") > -1)
                    {
                        orderItems = OrderItems.Split('#');
                    }
                    else
                    {
                        orderItems[0] = OrderItems;
                    }
                    foreach (String orderItem in orderItems)
                    {
                        DataRowCollection Rows = getInquiryByID(orderItem.Split(';')[0], web).Rows;
                        //if (Rows.Count > 0)
                        //{
                        DataRow row = Rows[0];
                        String ContractNo = "RG" + PINUM.Substring(5) + "." + row_index;
                        DataRowCollection ComReviewRows = getComReview(PINUM, row[InquiryList.Fields["Quoted By"].InternalName].ToString().Split('#')[1], web).Rows;
                        if (ComReviewRows.Count == 0)
                        {
                            SPListItem item = ComReview.Add();
                            item["_x4f9b__x5e94__x5546_"] = row["Quoted_x0020_By"];
                            item["Title"] = PINUM;
                            item["_x5408__x540c__x7f16__x53f7_"] = ContractNo;
                            item["_x8be2__x5355__x53f7_"] = inquiryNo;
                            item["_x6570__x91cf_"] = orderItem.Split(';')[1];
                            item["_x4e1a__x52a1__x5458_"] = row["Author"];
                            item["Author"] = row["Author"];
                            item.Update();
                            row_index++;
                        }
                        else
                        {

                            SPListItem item = ComReview.GetItemById(int.Parse(ComReviewRows[0]["ID"].ToString()));
                            item["_x6570__x91cf_"] = int.Parse(item["_x6570__x91cf_"].ToString()) + int.Parse(orderItem.Split(';')[1].ToString());
                            item.Update();
                        }
                        DataRowCollection ReviewRows = getReview(PINUM, web).Rows;
                        if (ReviewRows.Count == 0)
                        {
                            SPListItem item = Review.Add();
                            item["_x4f9b__x5e94__x5546_"] = row["Quoted_x0020_By"];
                            item["Title"] = PINUM;
                            item["_x8bc4__x5ba1__x7f16__x53f7_"] = "RG" + PINUM.Substring(5);
                            item["_x8be2__x5355__x53f7_"] = inquiryNo;
                            item["Qty"] = orderItem.Split(';')[1];
                            item["_x6280__x672f__x90e8__x8bc4__x5b0"] = row["Author"];
                            item["Author"] = row["Author"];
                            item.Update();
                            ReviewID = item.ID.ToString();
                            SPWorkflowManager manager = web.Site.WorkflowManager;
                            SPWorkflowAssociation iscompleted = ReviewList.WorkflowAssociations.GetAssociationByName("Review Contact", new System.Globalization.CultureInfo("en-US"));
                            manager.StartWorkflow(item, iscompleted, iscompleted.AssociationData, true);
                        }
                        else
                        {

                            SPListItem item = Review.GetItemById(int.Parse(ReviewRows[0]["ID"].ToString()));
                            item["Qty"] = int.Parse(item["Qty"].ToString()) + int.Parse(orderItem.Split(';')[1].ToString());
                            item.Update();
                        }
                        // }
                    }
                }
            }
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            if (workflowProperties.Item["Order From"] != null)
            {
                string docid = "PI" + workflowProperties.Item["Order From"].ToString();
                DataRow pirow = getPINUM(docid, workflowProperties.Web).Rows[0];
                PINUM = pirow["Doc_x0020_Id_x0020_String"].ToString().Split('#')[1];
                using (SPWeb web = workflowProperties.Web)
                {
                    SPList dicList = web.GetList("/teamwork/Lists/Doc%20Id%20Control");
                    SPListItem item = dicList.GetItemById(int.Parse(pirow["ID"].ToString()));
                    item["DocNum"] = int.Parse(item["DocNum"].ToString()) + 1;
                    item.Update();
                }

            }
            workflowProperties.Item["PI No"] = PINUM;
            workflowProperties.Item["isUpgrade"] = "5";
            workflowProperties.Item.SystemUpdate();
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            if (workflowProperties.Item["For Drawing"] != null && !workflowProperties.Item["For Drawing"].Equals(""))
            {
                String inquiryNo = workflowProperties.Item["Inquiry Number"].ToString();
                using (SPSite site = new SPSite("http://localhost/"))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        DataTable QuotedBy = getQuoted(inquiryNo, workflowProperties.Web);
                        SPList InquiryList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");
                        SPList drawingList = web.GetList("/EngineeringandQuality/Lists/Request%20For%20Drawings");
                        SPList drawingInfoList = web.GetList("/EngineeringandQuality/Lists/Drawing%20Information");
                        SPListItemCollection drawingItems = drawingList.Items;
                        SPListItemCollection drawingInfoItems = drawingInfoList.Items;
                        //SPFieldLookupValueCollection ItemsCollection = (SPFieldLookupValueCollection)this.workflowProperties.Item["For Drawing"];
                        String ForDrawings = workflowProperties.Item["For Drawing"].ToString();

                        //foreach (DataRow row in QuotedBy.Rows)
                        String[] forDrawings = new string[1];
                        if (ForDrawings.IndexOf("#") > -1)
                        {
                            forDrawings = ForDrawings.Split('#');
                        }
                        else
                        {
                            forDrawings[0] = ForDrawings;
                        }
                        foreach (String oItem in forDrawings)
                        {
                            DataRowCollection Rows = getInquiryByID(oItem, workflowProperties.Web).Rows;
                            //if (Rows.Count > 0)
                            //{
                            SPFieldLookupValueCollection draw_id = new SPFieldLookupValueCollection();

                            DataRow row = Rows[0];
                            DataRowCollection drawingRows = getDrawing(inquiryNo, row[InquiryList.Fields["Quoted By"].InternalName].ToString().Split('#')[1], web).Rows;
                            if (drawingRows.Count == 0)
                            {
                                SPListItem drawingItem = drawingItems.Add();
                                drawingItem["Title"] = PINUM;
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
                                SPListItem drawingItem = drawingItems.GetItemById(int.Parse(drawingRows[0]["ID"].ToString()));
                                drawingItem["Title"] = PINUM;
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
                        }
                        // }
                    }
                }
            }
        }

        private void codeActivity3_ExecuteCode_1(object sender, EventArgs e)
        {
            SPList PrepareList = workflowProperties.Web.GetList("/teamwork/Lists/PI%20Prepare");
            SPList PIList = workflowProperties.Web.GetList("/teamwork/Lists/Proforma%20Invoice");
            SPList OIList = workflowProperties.Web.GetList("/teamwork/Lists/Order%20Items");
            SPList InquriyList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");
            SPListItemCollection PrepareItems = PrepareList.Items;
            SPListItemCollection PIItems = PIList.Items;
            SPListItemCollection OrderItems = OIList.Items;
            SPListItemCollection InquiryItems = InquriyList.Items;
            SPListItem pItem = PrepareItems.GetItemById(int.Parse(getPrepareByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web).Rows[0]["ID"].ToString()));
            String OItems = pItem[PrepareList.Fields["Order Items"].InternalName].ToString();
            String[] orderItems = new string[1];
            if (OItems.IndexOf("#") > -1)
            {
                orderItems = OItems.Split(new char[]{'#'});
            }
            else
            {
                orderItems[0] = OItems;
            }
            foreach (String oItem in orderItems)
            {
                SPListItem InquiryItem = InquiryItems.GetItemById(int.Parse(oItem.Split(';')[0]));
                SPListItem OrderItem;

                DataTable ExistItems = getOrderItems(InquiryItem[InquriyList.Fields["询单号"].InternalName].ToString(), InquiryItem[InquriyList.Fields["Model Number"].InternalName].ToString(),InquiryItem.ID.ToString(), workflowProperties.Web);
                if (ExistItems.Rows.Count == 0)
                {
                    OrderItem = OrderItems.Add();
                }
                else
                {
                    OrderItem = OrderItems.GetItemById(int.Parse(ExistItems.Rows[0]["ID"].ToString()));
                }

                foreach (SPField field in InquiryItem.Fields)
                {
                    if (OrderItem.Fields.ContainsField(field.InternalName) == true &&
                        field.ReadOnlyField == false && field.InternalName != "Attachments")
                    {
                        OrderItem[field.InternalName] = InquiryItem[field.InternalName];
                    }
                }
                OrderItem["Author"] = pItem["Author"].ToString();
                OrderItem["Qty"] = oItem.Split(';')[1];
                OrderItem["ReviewId"] = ReviewID;
                OrderItem.Update();
            }

            //添加PI
            DataRowCollection PIRows = getPIByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web).Rows;
            SPListItem PIItem;
            if (PIRows.Count == 0)
            {
                PIItem = PIItems.Add();
            }
            else
            {
                PIItem = PIItems.GetItemById(int.Parse(PIRows[0]["ID"].ToString()));
            }
            PIItem["Title"] = pItem["Title"];

            SPFieldLookupValue i_id = new SPFieldLookupValue(int.Parse(getInquiryByNo(pItem[PrepareList.Fields["Inquiry Number"].InternalName].ToString(), workflowProperties.Web).Rows[0]["ID"].ToString()), getInquiryByNo(pItem[PrepareList.Fields["Inquiry Number"].InternalName].ToString(), workflowProperties.Web).Rows[0][InquriyList.Fields["询单号"].InternalName].ToString());
            PIItem["Inquiry No"] = i_id;
            SPFieldLookupValue q_id = new SPFieldLookupValue(int.Parse(getQuotationByInquiry(pItem[PrepareList.Fields["Inquiry Number"].InternalName].ToString(), workflowProperties.Web).Rows[0]["ID"].ToString()), getQuotationByInquiry(pItem[PrepareList.Fields["Inquiry Number"].InternalName].ToString(), workflowProperties.Web).Rows[0]["Title"].ToString());
            PIItem["Quote No"] = q_id;
            PIItem["Purchase Order"] = pItem[PrepareList.Fields["Purchase Order"].InternalName];
            PIItem["Customers"] = pItem["Customers"];
            //PIItem["Lead Time"] = Delivery;
            PIItem["Order From"] = pItem[PrepareList.Fields["Order From"].InternalName];
            PIItem["Author"] = pItem["Author"].ToString();
            PIItem.Update();
        }
    }
}
