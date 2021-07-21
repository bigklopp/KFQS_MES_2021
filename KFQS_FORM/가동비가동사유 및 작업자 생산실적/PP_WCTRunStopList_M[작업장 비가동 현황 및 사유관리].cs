#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WCTRunStopList_M
//   Form Name    : 작업장 비가동 현황 및 사유관리
//   Name Space   : KFQS_Form
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class PP_WCTRunStopList_M : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_WCTRunStopList_M()
        {
            InitializeComponent();
        }
        #endregion 

        #region < FORM EVENTS >
        private void PP_WCTRunStopList_M_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",                true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSEQ",          "작업장지시별 순번",   true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",              true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",            true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호",        true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목코드",            true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",                true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자",              true, GridColDataType_emu.VarChar,    100, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS",         "가동/비가동",         true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSNAME",     "가동/비가동",         true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSTARTDATE",    "시작일시",            true, GridColDataType_emu.VarChar,    150, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSENDDATE",      "종료일시",            true, GridColDataType_emu.VarChar,    150, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TIMEDIFF",       "소요시간(분)",        true, GridColDataType_emu.Double,      90, 120, Infragistics.Win.HAlign.Right,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",            true, GridColDataType_emu.Double,      80,  120, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",            true, GridColDataType_emu.Double,      80,  120, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",         "사유",                true, GridColDataType_emu.VarChar,    250, 120, Infragistics.Win.HAlign.Left,    true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",          "등록자",              true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "등록일시",            true, GridColDataType_emu.DateTime24, 150, 120, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",         "수정자",              true, GridColDataType_emu.VarChar,    120, 120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",       "수정일시",            true, GridColDataType_emu.DateTime24, 150, 120, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            //this.grid1.DisplayLayout.Override.MergedCellContentArea                     = MergedCellContentArea.VisibleRect;
            //this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle      = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always; 
            //this.grid1.DisplayLayout.Bands[0].Columns["ORDERNO"].MergedCellStyle        = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle       = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle       = MergedCellStyle.Always;


            #endregion



            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_Workcenter_Code();  //작업장
            Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            dtStart_H.Value    = string.Format("{0:yyyy-MM-01}", DateTime.Now);
            #endregion
        }
        #endregion

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("ORDERNO", "ITEMCODE"); 
            //e.Layout.Bands[0].Columns["ITEMCODE"].MergedCellEvaluator = CM1;
            //e.Layout.Bands[0].Columns["ITEMNAME"].MergedCellEvaluator = CM1;
        }

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
                _GridUtil.Grid_Clear(grid1);
                
                
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sWorkcenterCode = DBHelper.nvlString(this.cboWorkcenterCode.Value);
                string sStartDate      = string.Format("{0:yyyy-MM-dd}" ,dtStart_H.Value);
                string sSendDate       = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);

                rtnDtTemp = helper.FillTable("00PP_WCTRunStopList_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",      sPlantCode,        DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode,   DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("RSSTARTDATE",    sStartDate,        DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("RSENDDATE",      sSendDate,         DbType.String, ParameterDirection.Input)
                                    );

               this.ClosePrgForm();
                if (rtnDtTemp.Rows.Count != 0)
                {
                    this.grid1.DataSource = rtnDtTemp;
                    //for (int i = 0; i < this.grid1.Rows.Count; i++)
                    //{
                    //    if (Convert.ToString(grid1.Rows[i].Cells["STATUS"].Value) == "S")
                    //    {
                    //        grid1.Rows[i].Appearance.BackColor = System.Drawing.Color.Orange;
                    //    }
                    //}
                }
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
            
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            this.grid1.UpdateData();
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return; 
            DBHelper helper = new DBHelper("", true);
            try
            {  
                if (this.ShowDialog("비가동 사유를 등록 하시겠습니까 ?") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

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
                            helper.ExecuteNoneQuery("00PP_WCTRunStopList_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE",      Convert.ToString(drRow["PLANTCODE"]),       DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"]),  DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("ORDERNO",        Convert.ToString(drRow["ORDERNO"]),         DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("RSSEQ",          Convert.ToInt32(drRow["RSSEQ"]),            DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("REMARK",        Convert.ToString(drRow["REMARK"]),           DbType.String, ParameterDirection.Input)
                                                  , helper.CreateParameter("EDITOR",         LoginInfo.UserID,                           DbType.String, ParameterDirection.Input)
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
    }
}




