#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_BadList
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
using System.Drawing;
using System.Security;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KFQS_Form
{
    public partial class PP_BadList : DC00_WinForm.BaseMDIChildForm
    {

        #region [ 생성자 ]
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region [ 선언자 ]
        public PP_BadList()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { "1000", "" });
        }

        #endregion

        #region [ Form Load ]
        private void PP_BadList_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADRECSEQ",   "불량시퀀스", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO", "INLOTNO", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTYTOTAL", "최초불량수량", true, GridColDataType_emu.Double, 60, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWBADQTY", "현재불량수량", true, GridColDataType_emu.Double, 60, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "재검양품수량", true, GridColDataType_emu.Double, 60, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODRATIO", "불량해결률", true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHECKNUM", "재검사횟수", true, GridColDataType_emu.VarChar, 60, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADTYPE", "불량사유", true, GridColDataType_emu.VarChar, 70, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BADRESULT", "판정결과", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER", "작업자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생산일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMFLAG", "판정완료", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

           //this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
           //this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
           //this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

            #region ▶ COMBOBOX ◀
            Common _Common = new Common();
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //rtnDtTemp = _Common.Standard_CODE("BADTYPE");     //불량사유
            //Common.FillComboboxMaster(this.cboBadType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //UltraGridUtil.SetComboUltraGrid(this.grid1, "BADTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            // rtnDtTemp = _Common.Standard_CODE("YESNO");     //상차 여부
            //Common.FillComboboxMaster(this.cboShipFlag, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region ▶ POP-UP ◀B
            BizTextBoxManager btbManager = new BizTextBoxManager();
            // btbManager.PopUpAdd(txtWorker_H, txtWorkerName_H, "WORKER_MASTER", new object[] { "", "", "", "", "" });
            // btbManager.PopUpAdd(txtCustCode_H, txtCustName_H, "CUST_MASTER", new object[] { cboPlantCode_H, "", "", "" });
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = "1000";
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

                string sPlantCode = Convert.ToString(this.cboPlantCode.Value);
                string sItemCode = Convert.ToString(txtItemCode_H.Text);                
                string sLotNo = Convert.ToString(txtLotNo.Text);
                string sStartDate = string.Format("{0:yyyy-MM-01}", dtStartDate.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);
                // string sShipFlag  = Convert.ToString(cboShipFlag.Value);

                rtnDtTemp = helper.FillTable("PS_BADDETAIL_S2", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("LOTNO", sLotNo, DbType.String, ParameterDirection.Input)
                                                             );
                //if (rtnDtTemp.Rows.Count > 0)
                //{
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds(rtnDtTemp);
                //}
                /*                else
                                {
                                    _GridUtil.Grid_Clear(grid1);
                                    this.ShowDialog("R00111", DialogForm.DialogType.OK);    // 조회할 데이터가 없습니다.
                                    return;
                                }*/
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

        }

        #endregion

        #region [ User Method Area ]
        #endregion

        
    }
}



