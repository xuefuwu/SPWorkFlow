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

namespace SyncReview
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

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

        private DataTable getComReviewByPI(String PINo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/List5");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["交货期"].InternalName, ReviewList.Fields["合同编号"].InternalName, ReviewList.Fields["供应商"].InternalName, ReviewList.Fields["业务员"].InternalName, "Title","Author" };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["评审编号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getReviewByPI(String PINo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Contract%20Review");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["Review Completed"].InternalName, ReviewList.Fields["评审交货期"].InternalName, ReviewList.Fields["合同编号"].InternalName, ReviewList.Fields["供应商"].InternalName, ReviewList.Fields["业务员"].InternalName, "Title" };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["评审编号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getQuoted(String inquiry, SPWeb oWebSite)
        {
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

        private DataTable getContractNo(String inquiry,String quotedBy, SPWeb oWebSite)
        {
            
            SPList InquiryList = oWebSite.GetList("/teamwork/Lists/List5");
            String[] ViewFields = { InquiryList.Fields["合同编号"].InternalName };
            String Query = "<Where>" +
                          "<And>"+
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiry + "</Value>" +
                          "</Eq>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + InquiryList.Fields["供应商"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + quotedBy.Split('#')[1] + "</Value>" +
                          "</Eq>" +
                          "</And>"+
                           "</Where>";
            return getSiteDataQuery(Query, ViewFields, InquiryList, oWebSite);
        }


        private DataTable getPrepareByPI(String PINo, SPWeb oWebSite)
        {
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

        private DataTable getPIByPI(String PINo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Proforma%20Invoice");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName, ReviewList.Fields["Quote No"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"Title\" />" +
                            "<Value Type=\"Text\">" + PINo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

        private DataTable getInquiryByNo(String InquiryNo, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Order%20Items");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName,ReviewList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["询单号"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryNo + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getOrderItems(String InquiryId, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Order%20Items");
            String[] ViewFields = { ReviewList.Fields["ID"].InternalName,ReviewList.Fields["询单号"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Identity"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + InquiryId + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }
        private DataTable getQuotationByInquiry(String InquiryNo, SPWeb oWebSite)
        {
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
        private DataTable getPVSNum(String DateString, SPWeb oWebSite)
        {
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
        private DataTable getRequirements(String Customer, SPWeb oWebSite)
        {
            SPList ReviewList = oWebSite.GetList("/teamwork/Lists/Customer%20Demand");
            String[] ViewFields = { ReviewList.Fields["Demand"].InternalName, ReviewList.Fields["Request For Paint"].InternalName, ReviewList.Fields["Other Requirements"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + ReviewList.Fields["Customer"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + Customer + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, ReviewList, oWebSite);
        }

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
            else if (pvsnum > 100 && pvsnum<=999)
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

        private void onCompleted(object sender, ConditionalEventArgs e)
        {
            e.Result = false;
            Boolean ReviewCompletedAll = true;
            using (SPWeb web = workflowProperties.Web)
            {
                SPList ReviewList = web.GetList("/teamwork/Lists/Contract%20Review");
                DataTable ReviewTable = getReviewByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web);
                if (workflowProperties.Item["Review Completed"] != null && workflowProperties.Item["Review Completed"].ToString().Equals("Yes"))
                {
                    foreach (DataRow ReviewRow in ReviewTable.Rows)
                    {
                        if (ReviewRow[ReviewList.Fields["Review Completed"].InternalName] != null && ReviewRow[ReviewList.Fields["Review Completed"].InternalName].ToString().Equals("No"))
                        {
                            ReviewCompletedAll = false;
                        }

                    }
                    if (ReviewCompletedAll && workflowProperties.Item["Review Completed"].ToString().Equals("Yes") && !workflowProperties.Item["评审交货期"].ToString().Equals(""))
                    {
                        e.Result = true;
                    }

                }
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            int Delivery = 0;
            Boolean ReviewCompletedAll = true;
            SPList ReviewList = workflowProperties.Web.GetList("/teamwork/Lists/Contract%20Review");
            SPList ComReviewList = workflowProperties.Web.GetList("/teamwork/Lists/List5");
            SPList PrepareList = workflowProperties.Web.GetList("/teamwork/Lists/PI%20Prepare");
            SPList PIList = workflowProperties.Web.GetList("/teamwork/Lists/Proforma%20Invoice");
            SPList OIList = workflowProperties.Web.GetList("/teamwork/Lists/Order%20Items");
            SPList InquriyList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");

            SPListItemCollection PrepareItems = PrepareList.Items;
            SPListItemCollection PIItems = PIList.Items;
            SPListItemCollection OrderItems = OIList.Items;
            SPListItemCollection InquiryItems = InquriyList.Items;
            SPListItemCollection ComReviewItems = ComReviewList.Items;

            DataTable ReviewTable = getReviewByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web);
            foreach (DataRow ReviewRow in ReviewTable.Rows)
            {
                if (ReviewRow[ReviewList.Fields["评审交货期"].InternalName] != null && !ReviewRow[ReviewList.Fields["评审交货期"].InternalName].ToString().Equals(""))
                {
                    if (int.Parse(ReviewRow[ReviewList.Fields["评审交货期"].InternalName].ToString()) > Delivery)
                    {
                        Delivery = int.Parse(ReviewRow[ReviewList.Fields["评审交货期"].InternalName].ToString());
                    }
                }
                if (ReviewRow[ReviewList.Fields["Review Completed"].InternalName].ToString().Equals("No"))
                {
                    ReviewCompletedAll = false;
                }

            }
            if (ReviewCompletedAll && workflowProperties.Item["Review Completed"].ToString().Equals("Yes") && !workflowProperties.Item["评审交货期"].ToString().Equals(""))
            {
                //更新prepare
                SPListItem pItem = PrepareItems.GetItemById(int.Parse(getPrepareByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web).Rows[0]["ID"].ToString()));
                if (pItem[PrepareList.Fields["Review Approved Date"].InternalName] == null || pItem[PrepareList.Fields["Review Approved Date"].InternalName].ToString().Equals(""))
                {
                    pItem[PrepareList.Fields["Review Approved Date"].InternalName] = DateTime.Now.ToLongDateString();
                    pItem.Update();
                }

                DataRowCollection PIRows = getPIByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web).Rows;
                SPListItem PIItem = PIItems.GetItemById(int.Parse(PIRows[0]["ID"].ToString()));
                PIItem["Lead Time"] = Delivery;
                PIItem.Update();

                
                /*
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
                PIItem["Lead Time"] = Delivery;
                PIItem["Order From"] = pItem[PrepareList.Fields["Order From"].InternalName];
                PIItem["Author"] = pItem["Author"].ToString();
                PIItem.Update();
                */
            }
        }

        public Guid TaskId1 = default(System.Guid);
        public SPWorkflowTaskProperties TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            TaskId1 = Guid.NewGuid();
            TaskProperties1.Title = workflowProperties.Item["Title"].ToString();
            TaskProperties1.AssignedTo = workflowProperties.Item["Author"].ToString();
        }

        private void completeTask1_MethodInvoking(object sender, EventArgs e)
        {
            SPList ReviewList = workflowProperties.Web.GetList("/teamwork/Lists/Contract%20Review");
            SPList ComReviewList = workflowProperties.Web.GetList("/teamwork/Lists/List5");
            SPList ContractList = workflowProperties.Web.GetList("/teamwork/Lists/Purchasing%20Contract");
            SPList PrepareList = workflowProperties.Web.GetList("/teamwork/Lists/PI%20Prepare");
            SPList PIList = workflowProperties.Web.GetList("/teamwork/Lists/Proforma%20Invoice");
            SPList OIList = workflowProperties.Web.GetList("/teamwork/Lists/Order%20Items");
            SPList InquriyList = workflowProperties.Web.GetList("/teamwork/Lists/InquirySystem");

            SPListItemCollection ContractItems = ContractList.Items;
            SPListItemCollection PrepareItems = PrepareList.Items;
            SPListItemCollection PIItems = PIList.Items;
            SPListItemCollection ComReviewItems = ComReviewList.Items;
            SPListItemCollection OrderItems = OIList.Items;
            SPListItemCollection InquiryItems = InquriyList.Items;

            DataTable ComReviewTable = getComReviewByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web);
            SPListItem pItem = PrepareItems.GetItemById(int.Parse(getPrepareByPI(workflowProperties.Item["Title"].ToString(), workflowProperties.Web).Rows[0]["ID"].ToString()));
            foreach (DataRow ReviewRow in ComReviewTable.Rows)
            {
                SPListItem ContractItem = ContractItems.Add();
                ContractItem["Title"] = ReviewRow[ComReviewList.Fields["合同编号"].InternalName].ToString();
                DataRowCollection PIRows = getPIByPI(ReviewRow["Title"].ToString(), workflowProperties.Web).Rows;
                DataRowCollection Requirements = getRequirements(pItem["Customers"].ToString(),workflowProperties.Web).Rows;
                if (Requirements.Count > 0)
                {
                    ContractItem["Revision_x0020_Comments "] = Requirements[0]["Demand"];
                    ContractItem["Paint_x0020_Requirement"] = Requirements[0]["Request_x0020_For_x0020_Paint"];
                }
                ContractItem["Other_x0020_Requirements"] = "图纸要求";
                ContractItem["Proforma_x0020_Invoice"] = PIRows[0]["ID"];
                ContractItem["Quote_x0020_No"] = PIRows[0]["Quote_x0020_No"];
                ContractItem["Customers"] = pItem["Customers"];
                ContractItem["Supplier"] = ReviewRow[ComReviewList.Fields["供应商"].InternalName];
                ContractItem["Quoted_x0020_By"] = ReviewRow[ComReviewList.Fields["供应商"].InternalName];
                ContractItem["Sales_x0020_Representative"] = ReviewRow["Author"];
                ContractItem.Update();
            }
            //修改order item

            String OItems = pItem[PrepareList.Fields["Order Items"].InternalName].ToString();

            String[] orderItems = new string[1];
            if (OItems.IndexOf("#") > -1)
            {
                orderItems = OItems.Split('#');
            }
            else
            {
                orderItems[0] = OItems;
            }
            foreach (String oItem in orderItems)
            {
                SPListItem InquiryItem = InquiryItems.GetItemById(int.Parse(oItem.Split(';')[0]));
                SPListItem OrderItem;

                DataTable ExistItems = getOrderItems(oItem.Split(';')[0], workflowProperties.Web);
                if (ExistItems.Rows.Count == 0)
                {
                    OrderItem = OrderItems.Add();
                }
                else
                {
                    OrderItem = OrderItems.GetItemById(int.Parse(ExistItems.Rows[0]["ID"].ToString()));
                }
                OrderItem["Contract No"] = getContractNo(OrderItem[OrderItem.Fields["询单号"].InternalName].ToString(), OrderItem[OrderItem.Fields["Quoted By"].InternalName].ToString(), workflowProperties.Web).Rows[0][ComReviewList.Fields["合同编号"].InternalName];
                OrderItem["Serial_x0020_Number_x0020_Start"] = PVSNum(int.Parse(OrderItem["Qty"].ToString()));
                OrderItem.Update();
            }
        }
    }
}
