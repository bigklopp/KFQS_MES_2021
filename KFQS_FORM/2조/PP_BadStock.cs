#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_BadStock
//   Form Name    : 제품 재고 관리
//   Name Space   : DC_WM
//   Created Date : 2021.05
//   Made By      : 
//   Description  : 제품관리 제품 재고 관리.
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DC00_assm;
using DC_POPUP;
using DC00_WinForm;
using DC00_Component;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
#endregion

namespace KFQS_Form
{
    public partial class PP_BadStock : DC00_WinForm.BaseMDIChildForm
    {
        #region [ 생성자 ]
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region [ 선언자 ]
        public PP_BadStock()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER",  new object[] { "1000", "" }); 
        }

        #endregion

        #region [ Form Load ]
        private void PP_BadStock_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",           "공장",       true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",            "품목",       true, GridColDataType_emu.VarChar,  120, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",            "품명",       true, GridColDataType_emu.VarChar,  120, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "YESCOM",              "합격 여부",  true, GridColDataType_emu.CheckBox,  100, 120, Infragistics.Win.HAlign.Center,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",              "불량수량",   true, GridColDataType_emu.Double,  140, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADTYPE",             "불량사유",   true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO",             "INLOTNO",    true, GridColDataType_emu.VarChar,  120, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",              "작업자",     true, GridColDataType_emu.VarChar,  120, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",      "작업장",     true, GridColDataType_emu.VarChar,  120, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMFLAG",             "판정종료",   true, GridColDataType_emu.CheckBox,   100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",            "등록일시",   true, GridColDataType_emu.VarChar,  150, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",               "등록자",     true, GridColDataType_emu.VarChar,  150, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",            "수정일시",   true, GridColDataType_emu.VarChar,  100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",              "수정자",     true, GridColDataType_emu.VarChar,  100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            Common _Common = new Common();
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //수정하기
            rtnDtTemp = _Common.Standard_CODE("ERRORTYPE");  // 불량사유
            Common.FillComboboxMaster(this.cboBadType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "BADTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            //rtnDtTemp = _Common.Standard_CODE("YESNO");     //상차 여부
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "YESCOM", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.Standard_CODE("YESNO");     //상차 여부
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "COMFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.Standard_CODE("WHCODE");     //입고 창고
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            //btbManager.PopUpAdd(txtWorker_H, txtWorkerName_H, "WORKER_MASTER", new object[] { "", "", "", "", "" });
            //btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "CUST_MASTER", new object[] { cboPlantCode_H, "", "", "" });
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode_H.Value = "1000";
            #endregion
        }
        #endregion

        #region [ TOOL BAR AREA ]
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>

        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {   
                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sBadType = Convert.ToString(this.cboBadType.Value);
                string sItemCode  = Convert.ToString(txtItemCode_H.Text);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("02QM_BadsStock_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE",  sPlantCode,  DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("BADTYPE",    sBadType,    DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMCODE",   sItemCode,   DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("STARTDATE",  sStartDate,  DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ENDDATE",    sEndDate,    DbType.String, ParameterDirection.Input)
                                                             );
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog("R00111", DialogForm.DialogType.OK);    // 조회할 데이터가 없습니다.
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                helper.Close();
            }
        }
        public override void DoSave()
        {
            this.grid1.UpdateData();
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper("", true);
            try
            {
                if (this.ShowDialog("변경 내용을 저장하시겠습니까 ?") == System.Windows.Forms.DialogResult.Cancel) return;

                string sBadRemark     = cboBadType.Text;
                if (sBadRemark == "")
                {
                    ShowDialog("불량사유를 입력하지 않았습니다.", DialogForm.DialogType.OK);
                    return;
                }

                string sShipNo = string.Empty;
                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정 
                            helper.ExecuteNoneQuery("", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE",  Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("LOTNO",      Convert.ToString(drRow["LOTNO"]),     DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ITEMCODE",   Convert.ToString(drRow["ITEMCODE"]),  DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("SHIPQTY",    Convert.ToString(drRow["STOCKQTY"]),  DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("SHIPNO",     sShipNo,                              DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("MAKER",      LoginInfo.UserID,                     DbType.String, ParameterDirection.Input)
                                                  );

                            if (helper.RSCODE == "S")
                            {
                                sShipNo = helper.RSMSG;
                            }
                            else break;
                            #endregion
                            break;
                    }
                    if (helper.RSCODE != "S") break;
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                helper.Commit();
                this.ClosePrgForm();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        #endregion

        #region [ User Method Area ]
        #endregion
    }
}