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
    }
}
