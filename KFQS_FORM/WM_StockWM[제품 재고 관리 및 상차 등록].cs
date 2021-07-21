#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 생산출고 등록/취소
//   Name Space   : 
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DC00_assm;
using DC_POPUP;
using DC00_WinForm;
using DC00_Component;
#endregion

namespace KFQS_Form
{
    public partial class WM_StockWM : DC00_WinForm.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table         = new DataTable();
        DataTable rtnDtTemp     = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public WM_StockWM()
        {
            InitializeComponent();
           

        }
        #endregion

        #region  WM_StockWM
        private void WM_StockWM_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region 
            
            _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",             "상차 등록",        false, GridColDataType_emu.CheckBox,100, 100, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "공장",             false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목 코드",        false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품명",             false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPFLAG",        "상차여부",         false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",           "LOTNO",            false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",          "창고 번호",        false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",        "재고 수량",        false, GridColDataType_emu.Double, 100, 100, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BASEUNIT",        "단위",             false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",          "입고 일자",        false, GridColDataType_emu.DateTime, 110, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",        "등록 일시",        false, GridColDataType_emu.DateTime24, 110,100,Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",           "등록자",           false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  //사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("WHCODE");  //사업장
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("YESNO");     // 지시 종료 여부
            UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            Common.FillComboboxMaster(this.cboShipFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            dtStart_H.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
            /*dtEnd_H.Value   = string.Format("{0:yyyyMMdd}", DateTime.Now);*/

            string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
            this.cboPlantCode.Value = "1000";
            #endregion

            #region POP-UP
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorkerId, txtWorkerName, "WORKER_MASTER", new object[] { "", "", "", "", "" });

            BizTextBoxManager btbManager1 = new BizTextBoxManager();
            btbManager1.PopUpAdd(txtItemCode, txtItemName, "ITEM_MASTER", new object[] { "1000", "" });

            BizTextBoxManager btbManager2 = new BizTextBoxManager();

            btbManager2.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER", new object[] { cboPlantCode, "", "", "" });


            #endregion


        }
        #endregion  WM_StockWM_Load

        #region <TOOL BAR AREA >




        public override void DoInquire()
        {   
            this._GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sSrart     = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnd       = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sLotNo     = this.txtLotNo.Text;
                string sItemCode  = txtItemCode.Text;
                string sShipFlag  = cboShipFlag.Value.ToString();

                rtnDtTemp = helper.FillTable("17WM_StockWM_S1", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE",  sPlantCode,      DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE",   sItemCode,      DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("LOTNO",      sLotNo,         DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("SHIPFLAG",   sShipFlag,      DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("STARTDATE",  sSrart,          DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ENDDATE",    sEnd,            DbType.String, ParameterDirection.Input)
                                              );

                


                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                this.ClosePrgForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            string sStart = Convert.ToString(dtStart_H.Value);
            int sSrart = Convert.ToInt32(sStart.Replace("-",""));
            int sEnd   = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog("조회 시작일자가 종료일자보다 큽니다.", DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        #region <METHOD AREA>
        #endregion
        public override void DoSave()
        {

            DataTable dt = new DataTable();

                dt = grid1.chkChange();
                if (dt == null)
                    return;

                /*if (this.cboWhCode.Value.ToString() == "")
                {
                    this.ShowDialog("창고를 선택하세요", DialogForm.DialogType.OK);
                    return;
                } */
            DBHelper helper = new DBHelper("", false);

            try
            {
                //base.DoSave();

                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++ )
                {
                    if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue; 

                    helper.ExecuteNoneQuery("17WM_StockWM_I1"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("PLANTCODE",      Convert.ToString(dt.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("LOTNO",          Convert.ToString(dt.Rows[i]["LOTNO"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("ITEMCODE",       Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WHCODE",            Convert.ToString(dt.Rows[i]["WHCODE"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("STOCKQTY",            Convert.ToString(dt.Rows[i]["STOCKQTY"]), DbType.String, ParameterDirection.Input)
                                            //, helper.CreateParameter("BASEUNIT",       Convert.ToString(dt.Rows[i]["BASEUNIT"]), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CARNO",         Convert.ToString(txtCarNo.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("CUSTCODE",      Convert.ToString(txtCustCode.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("WORKERID",      Convert.ToString(txtWorkerId.Text), DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("MAKER",       LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                            );
                    

                    if (helper.RSCODE == "E")
                    {
                        this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                        helper.Rollback();
                        return;
                    }
                }

                helper.Commit();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                this.ClosePrgForm();
                DoInquire();
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

    }
}

