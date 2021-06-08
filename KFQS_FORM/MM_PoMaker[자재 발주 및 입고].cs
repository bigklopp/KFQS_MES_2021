using DC00_assm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KFQS_Form
{
    public partial class MM_PoMaker : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 세팅할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //공장 변수 입력
        //private sPlantCode= LoginInfo. 
        
        public MM_PoMaker()
        {
            InitializeComponent();
        }

        private void MM_PoMaker_Load(object sender, EventArgs e)
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PONO", "발주번호", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "발주품목코드", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "발주품목명", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PODATE", "발주일자", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "POQTY", "발주수량", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "거래처", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "CHK", "입고선택", true, GridColDataType_emu.CheckBox,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOT번호", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INWORKER", "입고자", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, false);
                //셋팅 내역 그리드와 바인딩
                _GridUtil.SetInitUltraGridBind(grid1); //셋팅 내역 그리드와 바인딩

                Common _Common = new Common();
                DataTable dtTemp = new DataTable();

                // PLANTCODE 기준정보 가져와서 데이터 테이블에 추가
                dtTemp = _Common.Standard_CODE("PLANTCODE");
                // FillComboboxMaster(콤보박스, 데이터 소스, 받아올 값, 보여줄 값, ?, ?) 
                Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp,
                                          dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName,
                                          "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");



                dtTemp = _Common.Standard_CODE("UNITCODE");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", dtTemp, "CODE_ID", "CODE_NAME");


                // TB_CUSTMATTER_CODE라는 테이블의 데이터를 dtTemp에 집어 넣음
                dtTemp = _Common.GET_TB_CUSTMATTER_CODE("");
                // 조회 에 있는 콤보박스 컨트롤 에 데이터 등록
                Common.FillComboboxMaster(this.cboCust_H, dtTemp,
                                          dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName,
                                          "ALL", "");
                // 그리드 에 있는 해당 컬럼에 콤보박스 형태로 데이터 등록
                UltraGridUtil.SetComboUltraGrid(this.grid1, "CUSTCODE", dtTemp, "CODE_ID", "CODE_NAME");


                dtTemp = _Common.GET_ItemCodeFERT_Code("ROH");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", dtTemp, "CODE_ID", "CODE_NAME");

                cboPlantCode_H.Value = LoginInfo.PlantCode;
                dtpStart.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
                dtpEnd.Value = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
        }
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantCode = cboPlantCode_H.Value.ToString();
                string sPono      = txtPoNo.Text.ToString();
                string sCustcode  = cboCust_H.Value.ToString();
                string sStart     = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEnd       = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("17MM_PoMaker_S1", CommandType.StoredProcedure,
                         helper.CreateParameter("PLANTCODE",   sPlantCode,  DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("CUSTCODE",    sCustcode,   DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("PONO",        sPono,       DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("STARTDATE",   sStart,      DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("ENDDATE",     sEnd,        DbType.String,    ParameterDirection.Input));
                this.ClosePrgForm(); // (조회가 끝나고) 조회 중이라는 창을 닫는다. base.DoInquire()에 포함된 창이다.
                
                if (dtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = dtTemp; // dtTemp 변경되면 grid1도 변경. 반대도 그렇다. (DataSource로 연결하면 그렇다.)
                    grid1.DataBinds(dtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }

            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();
            this.grid1.InsertRow();

            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = LoginInfo.PlantCode;

            grid1.ActiveRow.Cells["PONO"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["CHK"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["LOTNO"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["INDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["INWORKER"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            grid1.ActiveRow.Cells["MAKER"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        public override void DoDelete()
        {
            base.DoDelete();
            if (Convert.ToString(this.grid1.ActiveRow.Cells["CHK"].Value)=="1")
            {
                ShowDialog("입고된 발주 내역은 삭제할 수 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                return;
            }
            this.grid1.DeleteRow();
        }
        public override void DoSave()
        {
            base.DoSave();
            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange();
            if (dtTemp == null) return;

            DBHelper helper = new DBHelper("", true);  // 트랜잭션 시 이렇게 "", true 해야 됨.

            try
            {
                if (ShowDialog("해당 사항을 저장하시겠습니까?", DC00_WinForm.DialogForm.DialogType.YESNO) == DialogResult.No) return;
                foreach (DataRow drRow in dtTemp.Rows)
                {
                    
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("17MM_PoMaker_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PONO"     , Convert.ToString(drRow["PONO"])     , DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Added:
                            string sErrorMsg = string.Empty;
                            if (Convert.ToString(drRow["ITEMCODE"]) == "")
                            {
                                sErrorMsg += "품목 ";
                            }
                            if (Convert.ToString(drRow["POQTY"]) == "")
                            {
                                sErrorMsg += "발주수량 ";
                            }
                            if (Convert.ToString(drRow["CUSTCODE"]) == "")
                            {
                                sErrorMsg += "거래처 ";
                            }
                            if (sErrorMsg != "")
                            {
                                this.ClosePrgForm();
                                this.ShowDialog(sErrorMsg + "을 입력하지 않았습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                                helper.Rollback();
                                return;
                            }
                            
                            helper.ExecuteNoneQuery("17MM_PoMaker_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE" , Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("ITEMCODE"  , Convert.ToString(drRow["ITEMCODE"]),  DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("POQTY"     , Convert.ToString(drRow["POQTY"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("UNITCODE"  , Convert.ToString(drRow["UNITCODE"]),  DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("CUSTCODE"  , Convert.ToString(drRow["CUSTCODE"]),  DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER"     , LoginInfo.UserID,                     DbType.String, ParameterDirection.Input)
                                                    );
                            break;
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("17MM_PoMaker_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PONO", Convert.ToString(drRow["PONO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INQTY", Convert.ToString(drRow["INQTY"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    );
                            break;
                    }
                }
                if(helper.RSCODE == "S")
                {
                    helper.Commit();
                    ShowDialog("정상적으로 등록되었습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                    DoInquire();
                }
                

            }
            catch (Exception ex)
            {
                
                ShowDialog("조회할 데이터가 없습니다."+ex.ToString(), DC00_WinForm.DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

       
    }
}
