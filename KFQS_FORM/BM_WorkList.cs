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
    public partial class BM_WorkList : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 세팅할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();

        //공장 변수 입력
        //private sPlantCode= LoginInfo. 
        
        public BM_WorkList()
        {
            InitializeComponent();
        }

        private void BM_WorkList_Load(object sender, EventArgs e)
        {
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "작업자ID", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자 명", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "BANCODE", "작업반", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "GRPID", "그룹", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE", "부서", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "PHONE", "연락처", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입사일", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE", "퇴사일", true, GridColDataType_emu.VarChar,
                                               130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", true, GridColDataType_emu.VarChar,
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
                                          "ALL","");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

                // BANCODE 기준정보 가져와서 데이터 테이블에 추가
                dtTemp = _Common.Standard_CODE("BANCODE");
                Common.FillComboboxMaster(this.cboBanCode_H, dtTemp,
                                          dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName,
                                          "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "BANCODE", dtTemp, "CODE_ID", "CODE_NAME");

                // USEFLAG 기준정보 가져와서 데이터 테이블에 추가
                dtTemp = _Common.Standard_CODE("USEFLAG");
                Common.FillComboboxMaster(this.cboUserFlag_H, dtTemp,
                                          dtTemp.Columns["CODE_ID"].ColumnName,
                                          dtTemp.Columns["CODE_NAME"].ColumnName,
                                          "ALL", "");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "USEFLAG", dtTemp, "CODE_ID", "CODE_NAME");

                // 부서
                dtTemp = _Common.Standard_CODE("DEPTCODE");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "DEPTCODE", dtTemp, "CODE_ID", "CODE_NAME");
                // 그룹
                dtTemp = _Common.Standard_CODE("GRPID");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "GRPID", dtTemp, "CODE_ID", "CODE_NAME");


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
                string sWorkerId = txtWorkerID_H.Text.ToString();
                string sWorkerName = txtWorkerName_H.Text.ToString();
                string sBanCode = cboBanCode_H.Value.ToString();
                string sUseflag = cboUserFlag_H.Value.ToString();

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("17BM_WorkList_S1", CommandType.StoredProcedure,
                         helper.CreateParameter("PLANTCODE",  sPlantCode,  DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("WORKERID",   sWorkerId,   DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("WORKERNAME", sWorkerName, DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("BANCODE",    sBanCode,    DbType.String,    ParameterDirection.Input),
                         helper.CreateParameter("USEFLAG",    sUseflag,    DbType.String,    ParameterDirection.Input));
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

            this.grid1.ActiveRow.Cells["PLANTCODE"].Value   = "1000";
            this.grid1.ActiveRow.Cells["GRPID"].Value       = "SW";
            this.grid1.ActiveRow.Cells["USEFLAG"].Value     = "Y";
            this.grid1.ActiveRow.Cells["INDATE"].Value      = DateTime.Now.ToString("yyyy-MM-dd");

            grid1.ActiveRow.Cells["MAKER"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
        }

        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }
        public override void DoSave()
        {
            base.DoSave();
            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange();
            if (dtTemp.Rows.Count == 0) return;

            DBHelper helper = new DBHelper("", true);  // 트랜잭션 시 이렇게 "", true 해야 됨.

            try
            {
                if (ShowDialog("해당 사항을 저장하시겠습니까?", DC00_WinForm.DialogForm.DialogType.YESNO) == DialogResult.No) return;
                foreach (DataRow drRow in dtTemp.Rows)
                {
                    if (Convert.ToString(drRow["WORKERID"]) == string.Empty)
                    {
                        this.ClosePrgForm();
                        this.ShowDialog("작업자 ID를 입력하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                        return;
                    }
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            drRow.RejectChanges();
                            helper.ExecuteNoneQuery("17BM_WorkList_D1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("17BM_WorkList_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE" , Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID"  , Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drRow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID"     , Convert.ToString(drRow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE"  , Convert.ToString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE"   , Convert.ToString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG"   , Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO"   , Convert.ToString(drRow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE"    , Convert.ToString(drRow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE"   , Convert.ToString(drRow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER"     , LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                                                    );
                            break;
                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("17BM_WorkList_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID", Convert.ToString(drRow["WORKERID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drRow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID", Convert.ToString(drRow["GRPID"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE", Convert.ToString(drRow["DEPTCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE", Convert.ToString(drRow["BANCODE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG", Convert.ToString(drRow["USEFLAG"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO", Convert.ToString(drRow["PHONENO"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE", Convert.ToString(drRow["INDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE", Convert.ToString(drRow["OUTDATE"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
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
                
                ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
