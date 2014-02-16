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
using System.Text;

namespace CacheModelNumber
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        StringBuilder descEN = new StringBuilder();
        StringBuilder descCN = new StringBuilder();
        StringBuilder descLine = new StringBuilder();

        private String splitCalcColumn(String columnStr)
        {
            String rtn = default(String);
            if (columnStr.Length > 0)
            {
                rtn = columnStr.Split('#')[1];
            }
            return rtn;
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

        private DataTable getConstruction(String MN_E, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Construction");
            String[] ViewFields = { cList.Fields["ConstructionCN"].InternalName, cList.Fields["ConstructionEN"].InternalName, cList.Fields["ConstructionDescEN"].InternalName, cList.Fields["ConstructionDescCN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["BE"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_E) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getConnection(String MN_D, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Connection");
            String[] ViewFields = { cList.Fields["ConnectionCN"].InternalName, cList.Fields["ConnectionEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_D) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getValveType(String MN_B, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/ValveType");
            String[] ViewFields = { cList.Fields["ValveTypeCN"].InternalName, cList.Fields["ValveTypeEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_B) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getSize(String MN_A, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Size");
            String[] ViewFields = { cList.Fields["SizeDescCN"].InternalName, cList.Fields["SizeDescEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_A) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getRating(String MN_C, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Rating");
            String[] ViewFields = { cList.Fields["RatingDescCN"].InternalName, cList.Fields["RatingDescEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_C) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getBodyMaterial(String MN_F, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/BodyMaterial");
            String[] ViewFields = { cList.Fields["BodyMaterialCN"].InternalName, cList.Fields["BodyMaterialEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_F) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getTrim(String MN_G, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Trim");
            String[] ViewFields = { cList.Fields["DiscSurface"].InternalName, cList.Fields["DiscSurfaceCN"].InternalName, cList.Fields["SeatSurface"].InternalName, cList.Fields["SeatSurfaceCN"].InternalName, cList.Fields["Stem"].InternalName, cList.Fields["StemCN"].InternalName, cList.Fields["TrimCN"].InternalName, cList.Fields["TrimEN"].InternalName, cList.Fields["TrimDesc"].InternalName, cList.Fields["TrimDescCN"].InternalName, cList.Fields["Code"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_G) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getSeat(String MN_H, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Seat");
            String[] ViewFields = { cList.Fields["SeatCN"].InternalName, cList.Fields["SeatEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_H) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getORing(String MN_I, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/ORing");
            String[] ViewFields = { cList.Fields["ORingCN"].InternalName, cList.Fields["ORingEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_I) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private DataTable getOperation(String MN_J, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/Operation");
            String[] ViewFields = { cList.Fields["OperationCN"].InternalName, cList.Fields["OperationEN"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Code"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + splitCalcColumn(MN_J) + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private void onFloatBA(object sender, ConditionalEventArgs e)
        {
            if (splitCalcColumn(this.workflowProperties.Item["B"].ToString()).Equals("BA"))
            {
                if (getConstruction(this.workflowProperties.Item["E"].ToString(), this.workflowProperties.Web).Rows[0]["ConstructionEN"].ToString().IndexOf("FLOATING") > -1)
                {
                    e.Result = true;
                }
            }
            else
            {
                e.Result = false;
            }
        }

        private void onTurnnionBA(object sender, ConditionalEventArgs e)
        {
            if (splitCalcColumn(this.workflowProperties.Item["B"].ToString()).Equals("BA"))
            {
                if (getConstruction(this.workflowProperties.Item["E"].ToString(), this.workflowProperties.Web).Rows[0]["ConstructionEN"].ToString().IndexOf("FLOATING") <= -1)
                {
                    e.Result = true;
                }
            }
            else
            {
                e.Result = false;
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            workflowProperties.Item["Full_x0020_Description"] = descEN.ToString();
            workflowProperties.Item["_x5b8c__x6574__x63cf__x8ff0_"] = descCN.ToString();
            workflowProperties.Item["Description_x0020_Line"] = descLine.ToString();
            workflowProperties.Item["upgrade"] = "5";
            workflowProperties.Item.SystemUpdate();
        }

        private void onUpgrade(object sender, ConditionalEventArgs e)
        {
            e.Result = false;
            if (workflowProperties.Item["upgrade"] != null && workflowProperties.Item["upgrade"].ToString().Equals("5"))
            {
                e.Result = true;
            }
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND CLOSURE MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF CLOSURE MEMBER (BALL):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (BALL):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            //descEN.Append("</td></tr><tr><td>STEM:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>O-RING (STEM/SEAT):</td><td>" + getORing(item["I"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("球体密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀杆/阀杆密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("球体:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("O形圈:" + getORing(item["I"].ToString(), web).Rows[0]["ORingCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Cover " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Ball " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("O-ring " + getORing(item["I"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);


        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                 "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND CLOSURE MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF CLOSURE MEMBER (BALL):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF SEAT RETAINER:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (BALL):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RETAINER:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>STEM:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>O-RING (STEM/SEAT):</td><td>" + getORing(item["I"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("球体密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座支撑圈密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("球体:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座支撑圈" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("O形圈:" + getORing(item["I"].ToString(), web).Rows[0]["ORingCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);


            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Cover " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Ball " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ",Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ", Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat Insert " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("O-ring " + getORing(item["I"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private void codeActivity4_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF CLOSURE MEMBER (DISC):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- SHAFT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("蝶板密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("蝶板:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            //descCN.Append("阀座:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Bonnet " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Disc " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);

        }

        private void codeActivity5_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND/OR BONNET/COVER MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATINGSURFACE OF CLOSURE MEMBER (DISC/GATE):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY SEAT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC/GATE):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀板/闸阀密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("阀瓣:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座:" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Cover " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Disc " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private void codeActivity6_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND/OR BONNET/COVER MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATINGSURFACE OF CLOSURE MEMBER (DISC/GATE):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY SEAT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC/GATE):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀板/闸阀密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("阀瓣:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座:" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Bonnet " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Disc " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ",  Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private void codeActivity7_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND/OR BONNET/COVER MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATINGSURFACE OF CLOSURE MEMBER (DISC/GATE):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY SEAT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC/GATE):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀板/闸阀密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("阀瓣:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座:" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Bonnet " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Disc " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ",  Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private void codeActivity8_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND/OR BONNET/COVER MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATINGSURFACE OF CLOSURE MEMBER (DISC/GATE):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY SEAT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC/GATE):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀板/闸阀密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("阀瓣:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座:" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Bonnet " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Plug " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ",  Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("O-ring " + getORing(item["I"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private void codeActivity9_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            SPItem item = workflowProperties.Item;
            descEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">" +
                "<tr><td style=\"width:50%\">MODEL NUMBER:</td><td style=\"width:50%\">" + item["Model Number"]);
            descEN.Append("</td></tr><tr><td>VALVE TYPE:</td><td>" + getValveType(item["B"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>NOMINAL SIZE:</td><td>" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>PRESSURE RATING:</td><td>" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()));
            descEN.Append("</td></tr><tr><td>END CONNECTION:</td><td>" + getConnection(item["D"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>CONSTRUCTION:</td><td>" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"]);
            descEN.Append("</td></tr><tr><td>BODY AND/OR BONNET/COVER MATERIAL:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>TRIM DESCRIPTION:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["TrimEN"]);
            descEN.Append("</td></tr><tr><td>- SEATINGSURFACE OF CLOSURE MEMBER (DISC/GATE):</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"]);
            descEN.Append("</td></tr><tr><td>- SEATING SURFACE OF BODY SEAT:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"]);
            descEN.Append("</td></tr><tr><td>- STEM:</td><td>" + getTrim(item["G"].ToString(), web).Rows[0]["Stem"]);
            //descEN.Append("</td></tr><tr><td>CLOSURE MEMBER (DISC/GATE):</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            //descEN.Append("</td></tr><tr><td>SEAT RING:</td><td>" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"]);
            descEN.Append("</td></tr><tr><td>SEAT SEAL:</td><td>" + getSeat(item["H"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr><tr><td>OPERATION MODE:</td><td>" + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
            descEN.Append("</td></tr></table>");

            descCN.Append("阀门类型:" + getValveType(item["B"].ToString(), web).Rows[0]["ValveTypeCN"] + ", ");
            descCN.Append("尺寸:" + splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescCN"].ToString()) + ", ");
            descCN.Append("压力:" + splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescCN"].ToString()) + ", ");
            descCN.Append("连接:" + getConnection(item["D"].ToString(), web).Rows[0]["ConnectionCN"] + ", ");
            descCN.AppendLine("结构:" + getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionCN"]);
            descCN.Append("阀体和阀盖:" + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialCN"] + ", ");
            descCN.Append("阀板/闸阀密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurfaceCN"] + ", ");
            descCN.Append("阀座密封面:" + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurfaceCN"] + ", ");
            descCN.Append("阀杆:" + getTrim(item["G"].ToString(), web).Rows[0]["StemCN"] + ", ");
            //descCN.Append("阀瓣:" + splitCalcColumn(item["_x9600__x74e3_"].ToString()) + ", ");
            //descCN.Append("阀座:" + splitCalcColumn(item["_x9600__x5ea7_"].ToString()) + ", ");
            descCN.Append("阀座密封:" + getSeat(item["H"].ToString(), web).Rows[0]["SeatCN"] + ", ");
            descCN.Append("操作:" + getOperation(item["J"].ToString(), web).Rows[0]["OperationCN"]);

            descLine.AppendLine("Model Number:" + item["Model Number"] + "<br/>");
            descLine.Append(getValveType(item["B"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(splitCalcColumn(getSize(item["A"].ToString(), web).Rows[0]["SizeDescEN"].ToString()) + ", ");
            descLine.Append(splitCalcColumn(getRating(item["C"].ToString(), web).Rows[0]["RatingDescEN"].ToString()) + ", ");
            descLine.Append(getConnection(item["D"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append(getConstruction(item["E"].ToString(), web).Rows[0]["ConstructionEN"] + ", ");
            descLine.Append("Body/Bonnet " + getBodyMaterial(item["F"].ToString(), web).Rows[0]["BodyMaterialEN"] + ", ");
            descLine.Append("Trim (as applicable) " + getTrim(item["G"].ToString(), web).Rows[0]["Title"] + " (as applicable): Disc " + getTrim(item["G"].ToString(), web).Rows[0]["DiscSurface"] + ", Seat " + getTrim(item["G"].ToString(), web).Rows[0]["SeatSurface"] + ",  Stem " + getTrim(item["G"].ToString(), web).Rows[0]["Stem"] + ", ");
            descLine.Append("Seat " + getSeat(item["H"].ToString(), web).Rows[0]["Title"] + ", ");
            descLine.Append("OPERATION " + getOperation(item["J"].ToString(), web).Rows[0]["Title"]);
        }

        private static SPFieldLookupValue ConvertToLookupValue(string lookupField)
        {
            if (string.IsNullOrEmpty(lookupField)) return null;
            string[] vals = lookupField.Split(";#".ToArray());
            return (vals.Length == 3) ? new SPFieldLookupValue(Convert.ToInt32(vals[0]), vals[2]) : null;
        }


        private void onIdentity(object sender, ConditionalEventArgs e)
        {
            e.Result = false;
            if (ConvertToLookupValue(workflowProperties.Item["Identity"].ToString()).LookupValue != null && ConvertToLookupValue(workflowProperties.Item["Identity"].ToString()).LookupValue.Trim().Length > 0)
            {
                e.Result = true;
            }
        }

        private DataTable getReinquiry(String inquiryId, SPWeb oWebSite)
        {
            SPSiteDataQuery query = new SPSiteDataQuery();
            SPList cList = oWebSite.GetList("/teamwork/Lists/List");
            String[] ViewFields = { cList.Fields["ID"].InternalName };
            String Query = "<Where>" +
                          "<Eq>" +
                            "<FieldRef Name=\"" + cList.Fields["Identity"].InternalName + "\" />" +
                            "<Value Type=\"Text\">" + inquiryId + "</Value>" +
                          "</Eq>" +
                          "</Where>";
            return getSiteDataQuery(Query, ViewFields, cList, oWebSite);
        }

        private void codeActivity10_ExecuteCode(object sender, EventArgs e)
        {
            string inquiryId = ConvertToLookupValue(workflowProperties.Item["Identity"].ToString()).LookupValue;
            using (SPWeb web = workflowProperties.Web)
            {
                StringBuilder inDescCN = new StringBuilder(descCN.ToString()), inDescEN = new StringBuilder(descEN.ToString()), inDescLine = new StringBuilder(descLine.ToString());
                SPList inquiry = web.GetList("/teamwork/Lists/InquirySystem");
                SPItem inquiryItem = inquiry.GetItemById(int.Parse(inquiryId));
                SPFieldLookupValueCollection standardsCollection = (SPFieldLookupValueCollection)inquiryItem["Standards"];


                if (splitCalcColumn(workflowProperties.Item["B"].ToString()).Equals("BA"))
                {
                    if (getConstruction(workflowProperties.Item["E"].ToString(), web).Rows[0]["ConstructionEN"].ToString().IndexOf("FLOATING") > -1)
                    {
                        inDescCN.Append(",<br/>");
                        if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                            inDescCN.Append(" 球体:").Append(inquiryItem["_x9600__x74e3_"]);
                        inDescCN.Append("<br/>相关标准:");
                        foreach (SPFieldLookupValue standards in standardsCollection)
                        {
                            inDescCN.Append(standards.LookupValue + "; ");
                        }
                        inDescCN.Append("<br/>其他信息:").Append(inquiryItem["_x5176__x4ed6__x4fe1__x606f_"]);

                        inDescEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top\">");
                        if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                        {
                            inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">CLOSURE MEMBER (BALL):</td><td style=\"width:50%\" valign=\"top\">");
                            inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x74e3_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                            inDescEN.Append("</td></tr>");
                        }
                        if (inquiryItem["_x9600__x6746_"] != null && !inquiryItem["_x9600__x6746_"].ToString().Equals("0;#"))
                        {
                            inDescEN.Append("<tr><td valign=\"top\">STEM:</td><td valign=\"top\">");
                            inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x6746_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                            inDescEN.Append("</td></tr>");
                        }
                        inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">STANDARDS:</td><td style=\"width:50%\" valign=\"top\">");
                        
                        foreach (SPFieldLookupValue standards in standardsCollection)
                        {
                            inDescEN.Append(standards.LookupValue+"; ");
                        }
                        
                        inDescEN.Append("</td></tr><tr><td valign=\"top\">ADDITIONAL INFORMATION:</td><td>");
                        inDescEN.Append(inquiryItem["Additional_x0020_Information"]);
                        inDescEN.Append("</td></tr><tr><td valign=\"top\">EXCEPTIONS/DEVIATIONS:</td><td style=\"color:red\">");
                        inDescEN.Append(inquiryItem["Deviations"]);
                        inDescEN.Append("</td></tr></table>");

                    }
                    else
                    {
                        inDescCN.Append(",<br/>");
                        if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                            inDescCN.Append(" 球体:").Append(inquiryItem["_x9600__x74e3_"]);
                        if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                            inDescCN.Append(", 阀座支撑圈:").Append(inquiryItem["_x9600__x5ea7_"]);
                        inDescCN.Append("<br/>相关标准:");
                        foreach (SPFieldLookupValue standards in standardsCollection)
                        {
                            inDescCN.Append(standards.LookupValue + "; ");
                        }
                        inDescCN.Append("<br/>其他信息:").Append(inquiryItem["_x5176__x4ed6__x4fe1__x606f_"]);

                        inDescEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top;\">");
                        if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                        {
                            inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">CLOSURE MEMBER (BALL):</td><td style=\"width:50%\" valign=\"top\">");
                            inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x74e3_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                            inDescEN.Append("</td></tr>");
                        }
                        if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                        {
                            inDescEN.Append("<tr><td valign=\"top\">SEAT RETAINER:</td><td valign=\"top\">");
                            inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x5ea7_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                            inDescEN.Append("</td></tr>");
                        }
                        if (inquiryItem["_x9600__x6746_"] != null && !inquiryItem["_x9600__x6746_"].ToString().Equals("0;#"))
                        {
                            inDescEN.Append("<tr><td valign=\"top\">STEM:</td><td valign=\"top\">");
                            inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x6746_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                            inDescEN.Append("</td></tr>");
                        }
                        inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">STANDARDS:</td><td style=\"width:50%\" valign=\"top\">");
                        foreach (SPFieldLookupValue standards in standardsCollection)
                        {
                            inDescEN.Append(standards.LookupValue + "; ");
                        }
                        inDescEN.Append("</td></tr><tr><td valign=\"top\">ADDITIONAL INFORMATION:</td><td>");
                        inDescEN.Append(inquiryItem["Additional_x0020_Information"]);
                        inDescEN.Append("</td></tr><tr><td valign=\"top\">EXCEPTIONS/DEVIATIONS:</td><td style=\"color:red\">");
                        inDescEN.Append(inquiryItem["Deviations"]);
                        inDescEN.Append("</td></tr></table>");
                    }
                }
                else if (splitCalcColumn(workflowProperties.Item["B"].ToString()).Equals("BU"))
                {
                    inDescCN.Append(",<br/>");
                    if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                        inDescCN.Append(" 蝶板:").Append(inquiryItem["_x9600__x74e3_"]);
                    if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                        inDescCN.Append(", 阀座:").Append(inquiryItem["_x9600__x5ea7_"]);
                    inDescCN.Append("<br/>相关标准:");
                    foreach (SPFieldLookupValue standards in standardsCollection)
                    {
                        inDescCN.Append(standards.LookupValue + "; ");
                    }
                    inDescCN.Append("<br/>其他信息:").Append(inquiryItem["_x5176__x4ed6__x4fe1__x606f_"]);


                    inDescEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top;\">");
                    if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                    {
                        inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">CLOSURE MEMBER (DISC):</td><td style=\"width:50%\" valign=\"top\">");
                        inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x74e3_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                        inDescEN.Append("</td></tr>");
                    }
                    if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                    {
                        inDescEN.Append("<tr><td valign=\"top\">SEAT RING:</td><td valign=\"top\">");
                        inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x5ea7_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                        inDescEN.Append("</td></tr>");
                    }
                    inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">STANDARDS:</td><td style=\"width:50%\" valign=\"top\">");
                    foreach (SPFieldLookupValue standards in standardsCollection)
                    {
                        inDescEN.Append(standards.LookupValue + "; ");
                    }
                    inDescEN.Append("</td></tr><tr><td valign=\"top\">ADDITIONAL INFORMATION:</td><td>");
                    inDescEN.Append(inquiryItem["Additional_x0020_Information"]);
                    inDescEN.Append("</td></tr><tr><td valign=\"top\">EXCEPTIONS/DEVIATIONS:</td><td style=\"color:red\">");
                    inDescEN.Append(inquiryItem["Deviations"]);
                    inDescEN.Append("</td></tr></table>");
                }
                else
                {
                    inDescCN.Append(",<br/>");
                    if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                        inDescCN.Append(" 阀瓣:").Append(inquiryItem["_x9600__x74e3_"]);
                    if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                        inDescCN.Append(", 阀座:").Append(inquiryItem["_x9600__x5ea7_"]);
                    inDescCN.Append("<br/>相关标准:");
                    foreach (SPFieldLookupValue standards in standardsCollection)
                    {
                        inDescCN.Append(standards.LookupValue + "; ");
                    }
                    inDescCN.Append("<br/>其他信息:").Append(inquiryItem["_x5176__x4ed6__x4fe1__x606f_"]);


                    inDescEN.Append("<table cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%; font-size:7pt; vertical-align:top;\">");
                    if (inquiryItem["_x9600__x74e3_"] != null && !inquiryItem["_x9600__x74e3_"].ToString().Equals("0;#"))
                    {
                        inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">CLOSURE MEMBER (DISC/GATE):</td><td style=\"width:50%\" valign=\"top\">");
                        inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x74e3_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                        inDescEN.Append("</td></tr>");
                    }
                    if (inquiryItem["_x9600__x5ea7_"] != null && !inquiryItem["_x9600__x5ea7_"].ToString().Equals("0;#"))
                    {
                        inDescEN.Append("<tr><td valign=\"top\">SEAT RING:</td><td valign=\"top\">");
                        inDescEN.Append(getBodyMaterial(inquiryItem["_x9600__x5ea7_"].ToString(), web).Rows[0]["BodyMaterialEN"]);
                        inDescEN.Append("</td></tr>");
                    }
                    inDescEN.Append("<tr><td style=\"width:50%\" valign=\"top\">STANDARDS:</td><td style=\"width:50%\" valign=\"top\">");
                    foreach (SPFieldLookupValue standards in standardsCollection)
                    {
                        inDescEN.Append(standards.LookupValue + "; ");
                    }
                    inDescEN.Append("</td></tr><tr><td valign=\"top\">ADDITIONAL INFORMATION:</td><td>");
                    inDescEN.Append(inquiryItem["Additional_x0020_Information"]);
                    inDescEN.Append("</td></tr><tr><td valign=\"top\">EXCEPTIONS/DEVIATIONS:</td><td style=\"color:red\">");
                    inDescEN.Append(inquiryItem["Deviations"]);
                    inDescEN.Append("</td></tr></table>");
                }

                inDescLine.Append("<br/>Standards:");
                foreach (SPFieldLookupValue standards in standardsCollection)
                {
                    inDescLine.Append(standards.LookupValue + "; ");
                }
                inDescLine.Append("<br/>Additional Information:").Append(inquiryItem["Additional_x0020_Information"])
                    .Append("<br/>Deviations:").Append(inquiryItem["Deviations"]);

                inquiryItem["Full_x0020_Description"] = inDescEN.ToString();
                inquiryItem["_x5b8c__x6574__x63cf__x8ff0_"] = inDescCN.ToString();
                inquiryItem["Description_x0020_Line"] = inDescLine.ToString();
                //inquiryItem["NewFlow_x0020_Flag"] = "5";
                inquiryItem.Update();

                SPList reInquiry = web.GetList("/teamwork/Lists/List");
                SPItem reInquiryItem = reInquiry.GetItemById(int.Parse(getReinquiry(ConvertToLookupValue(inquiryItem["Identity"].ToString()).LookupValue, web).Rows[0]["ID"].ToString()));
                reInquiryItem["Full_x0020_Description"] = inDescEN.ToString();
                reInquiryItem["_x5b8c__x6574__x63cf__x8ff0_"] = inDescCN.ToString();
                reInquiryItem.Update();

            }
        }


    }
}
