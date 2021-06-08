#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_StockOUT
//   Form Name    : 자재 재고관리 
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Windows.Forms;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class MM_StockOUT : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public MM_StockOUT()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void MM_StockOUT_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "선택",                    true, GridColDataType_emu.CheckBox, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",             true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "입고일자",           true, GridColDataType_emu.YearMonthDay, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목",            true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명",               true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO", "LOTNO",       true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "수량",                    true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위",        true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "창고",          true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "입고자",          true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장 기준 코드의 플랜트코드 데이터를 모두 가져와 데이터 테이블에 넣는다.
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            // 헤더 영역의 콤보박스에 데이터를 넣는다.
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME"); 
            // 그리드 영역의 콤보박스에 데이터를 넣는다.

            rtnDtTemp = _Common.Standard_CODE("WHCODE","MINORCODE = 'WH003'");
            Common.FillComboboxMaster(this.cboWhCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("STORAGELOCCODE", "RELCODE1 = 'WH003'");     // 지시 종료 여부
            Common.FillComboboxMaster(this.cboStorageLocCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_ItemCodeFERT_Code("ROH"); // FERT는 완제품의 속성. 완제품만 가져와서 콤보 박스에 채우기
            Common.FillComboboxMaster(this.cboItemName_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");


            dtpStart.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
            dtpEnd.Value = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            /*
             * rtnDtTemp = _Common.GET_Workcenter_Code();     //작업장
            Common.FillComboboxMaster(this.cboItemName_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            */
            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
           

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            cboWhCode.Value = "WH003";

            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1); // 데이터가 원래 남아 있는 경우 클리어하고 다시 보이기
                string sPlantCode        = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode         = Convert.ToString(this.cboItemName_H.Value);
                string sLotNo            = Convert.ToString(txtLotNo.Text);
                string sWhCode           = Convert.ToString(cboWhCode.Value);
                string sStorageLocCode   = Convert.ToString(cboStorageLocCode.Value);
                string sStart            = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEnd              = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);

                rtnDtTemp = helper.FillTable("17MM_StockOUT_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE"      , sPlantCode,           DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ITEMCODE"       , sItemCode,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("LOTNO"          , sLotNo,             DbType.String, ParameterDirection.Input)
                                    //, helper.CreateParameter("WHCODE"         , sWhCode,      DbType.String, ParameterDirection.Input)
                                    //, helper.CreateParameter("STORAGELOCCODE" , sStorageLocCode,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("START"          , sStart,      DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("END"            , sEnd, DbType.String, ParameterDirection.Input)
                                    );

               this.ClosePrgForm();
               this.grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(),DialogForm.DialogType.OK);    
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            base.DoNew();
            try
            {
                this.grid1.InsertRow();
                this.grid1.SetDefaultValue("PLANTCODE", this.plantCode);
                grid1.ActiveRow.Cells["PLANNO"].Activation      = Activation.NoEdit;
                grid1.ActiveRow.Cells["CHK"].Activation         = Activation.NoEdit;
                grid1.ActiveRow.Cells["ORDERNO"].Activation     = Activation.NoEdit;
                grid1.ActiveRow.Cells["ORDERWORKER"].Activation = Activation.NoEdit;
            }
            catch(Exception ex)
            {
                ShowDialog(ex.ToString());
            }

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           if(Convert.ToString(grid1.ActiveRow.Cells["CHK"].Value) == "1")
            {
                ShowDialog("작업지시 확정 내역을 취소 후 삭제하세요.", DialogForm.DialogType.OK);
                return;
            }
            base.DoDelete();
            grid1.DeleteRow();

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        { 
            // 그리드에 표현된 내용을 소스 바인딩에 포함한다.
            this.grid1.UpdateData();

            DataTable dtTemp = new DataTable();

            dtTemp = grid1.chkChange();

            if (dtTemp == null) return;

            DBHelper helper = new DBHelper("", true);

            try
            {
                this.Focus();

                // C:Q00009는 등록한 데이터를 저장하시겠습니까? 라는 구문을 정해놨고, 호출하는 것.
                if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dtTemp.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("17MM_StockOUT_D1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("PLANNO", drRow["PLANNO"], DbType.String, ParameterDirection.Input)
                                                                    );

                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            string sErrorMsg = string.Empty;
                            if (Convert.ToString(drRow["ITEMCODE"]) == "")
                            {
                                sErrorMsg += "품목 ";
                            }
                            if (Convert.ToString(drRow["PLANQTY"]) == "")
                            {
                                sErrorMsg += "수량 ";
                            }
                            if (Convert.ToString(drRow["WORKCENTERCODE"]) == "")
                            {
                                sErrorMsg += "작업장 ";
                            }
                            if (sErrorMsg != "")
                            {
                                this.ClosePrgForm();
                                ShowDialog(sErrorMsg + "을 입력하지 않았습니다", DialogForm.DialogType.OK);
                                return;
                            }
                            helper.ExecuteNoneQuery("17MM_StockOUT_I1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ITEMCODE", drRow["ITEMCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("PLANQTY", Convert.ToString(drRow["PLANQTY"]).Replace(",", ""), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("UNITCODE", drRow["UNITCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("WORKCENTERCODE", drRow["WORKCENTERCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );

                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            string sOrderFalg = string.Empty;
                            // 체크가 되어 있었는데 체크를 해제하면 작업을 취소할 거고
                            // 체크가 안 되어 있었는데 체크를 하면 작업을 확정할 것이다.
                            if (Convert.ToString(drRow["CHK"]).ToUpper() == "1") sOrderFalg = "Y"; 
                            else sOrderFalg = "N";

                            helper.ExecuteNoneQuery("17MM_StockOUT_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE", drRow["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("PLANNO", drRow["PLANNO"].ToString(), DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ORDERFLAG", sOrderFalg, DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                  );


                            #endregion
                            break;
                    }
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
                this.ShowDialog("R00002", DialogForm.DialogType.OK);    // 데이터가 저장 되었습니다.
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

        

       
    }
}




