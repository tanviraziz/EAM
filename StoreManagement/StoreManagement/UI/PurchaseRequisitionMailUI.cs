using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.DAL.GATEWAY;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class PurchaseRequisitionMailUI : Form
    {
        #region Veriables
            private PurchaseManager purchaseManager = null;
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControll = null;
            private Requisition requisition = null;
            private string reqToTender = null;
            private bool IsEdit = false;
        #endregion

        public PurchaseRequisitionMailUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            purchaseManager = new PurchaseManager();
            settingsManager = new MasterSetupManager();
            fillControll = new DynamicControlFill();
        }

        public PurchaseRequisitionMailUI(string reqNo):this()
        {
            reqToTender = reqNo;
        }

        private void PurchaseRequisitionMailUI_Load(object sender, EventArgs e)
        {
            fillControll.fillListView(supplierListView, settingsManager.GetSupplierList("4", null), "Supplier,", "256,",true);
            fillControll.fillListView(requisitionListView, purchaseManager.GetPurchaseRequistionList("5", reqToTender), "Item,Unit,ReqQty,", "350,100,120,",true);
            
            SetUpdateData(reqToTender);
        }

        private void SetUpdateData(string reqNo)
        {
            DataTable purchaseReq;
            purchaseReq = purchaseManager.GetPurchaseRequistionList("6", reqNo);

            
        }
    }
}
