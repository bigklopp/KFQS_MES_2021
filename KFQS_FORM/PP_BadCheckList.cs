#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_BadCheckList
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
    public partial class PP_BadCheckList : DC00_WinForm.BaseMDIChildForm
    {
        #region [ 생성자 ]
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        DataTable grid2rtnDtTemp = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        #endregion

        #region [ 선언자 ]
        public PP_BadCheckList()
        {
            InitializeComponent();
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { "1000", "" });
        }

        #endregion

        #region [ Form Load ]
        private void PP_BadCheckList_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INLOTNO", "INLOTNO", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTYTOTAL", "최초불량수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NOWBADQTY", "현재불량수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "재검양품수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODRATIO", "불량해결률", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHECKNUM", "재검사횟수", true, GridColDataType_emu.Integer, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADTYPE", "불량사유", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADRESULT", "판정결과", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER", "작업자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "생산일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "COMFLAG", "판정완료", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BADTYPE", "불량사유", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Center, true, true);
            //_GridUtil.InitColumnUltraGrid(grid2, "INLOTNO", "INLOTNO", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BADQTYTOTAL", "최초불량수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "NOWBADQTY", "현재불량수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PRODQTY", "재검양품수량", true, GridColDataType_emu.Double, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "PRODRATIO", "불량해결률", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CHECKNUM", "재검사횟수", true, GridColDataType_emu.Integer, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INLOTNO", "INLOTNO", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BADRESULT", "판정결과", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKCENTERNAME", "작업장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKER", "작업자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "생산일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일시", true, GridColDataType_emu.VarChar, 150, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "COMFLAG", "판정완료", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
            this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["INLOTNO"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["BADQTYTOTAL"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["NOWBADQTY"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["PRODQTY"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["PRODRATIO"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["CHECKNUM"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["BADTYPE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["BADRESULT"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["MAKEDATE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["EDITOR"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["EDITDATE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid1.DisplayLayout.Bands[0].Columns["COMFLAG"].MergedCellStyle = MergedCellStyle.Always;



            this.grid2.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
            this.grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["INLOTNO"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["BADQTYTOTAL"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["NOWBADQTY"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["PRODQTY"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["PRODRATIO"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["CHECKNUM"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["BADTYPE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["BADRESULT"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["MAKEDATE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["EDITOR"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["EDITDATE"].MergedCellStyle = MergedCellStyle.Always;
            this.grid2.DisplayLayout.Bands[0].Columns["COMFLAG"].MergedCellStyle = MergedCellStyle.Always;



            #region ▶ COMBOBOX ◀
            Common _Common = new Common();
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("BADTYPE");     //불량사유
            Common.FillComboboxMaster(this.cboBadType, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "BADTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

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
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
                string sItemCode = Convert.ToString(txtItemCode_H.Text);
                string sBadType = Convert.ToString(this.cboBadType.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);


                rtnDtTemp = helper.FillTable("PS_BADDETAIL_S", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("BADTYPE", sBadType, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                             );

                grid2rtnDtTemp = helper.FillTable("PS_BADDETAIL_S", CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("BADTYPE", sBadType, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                             );

                if (rtnDtTemp.Rows.Count != 0)
                {
                    #region ▶▶ SUB-TOTAL LOGIC ◀◀

                    DataTable dtSubTotal = rtnDtTemp.Clone(); // 데이터 테이블 서식 복사
                    DataTable dtSubTotal2 = grid2rtnDtTemp.Clone();


                    string sItemCode2 = Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]);
                    string sBadtypepe = Convert.ToString(rtnDtTemp.Rows[0]["BADTYPE"]);
                    double sProdqty = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTYTOTAL"]);
                    double sBadqty = Convert.ToDouble(rtnDtTemp.Rows[0]["NOWBADQTY"]);
                    double sBADTOTAL = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTYTOTAL"]);
                    int sCheckNum = Convert.ToInt32(rtnDtTemp.Rows[0]["CHECKNUM"]);
                    dtSubTotal.Rows.Add(new object[] {         Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["INLOTNO"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTYTOTAL"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["NOWBADQTY"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["PRODRATIO"]),
                                                               Convert.ToInt32(rtnDtTemp.Rows [0]["CHECKNUM"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["BADTYPE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["BADRESULT"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["MAKEDATE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["EDITOR"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["EDITDATE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["COMFLAG"])
                                                       });

                    dtSubTotal2.Rows.Add(new object[] {        Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["INLOTNO"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTYTOTAL"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["NOWBADQTY"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["PRODRATIO"]),
                                                               Convert.ToInt32(rtnDtTemp.Rows [0]["CHECKNUM"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["BADTYPE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["BADRESULT"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["MAKEDATE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["EDITOR"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["EDITDATE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[0]["COMFLAG"])
                                                       });

                    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                    {
                        if (sItemCode2 == Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]))
                        {
                            sBadqty = sBadqty + Convert.ToDouble(rtnDtTemp.Rows[i]["NOWBADQTY"]);
                            sBADTOTAL = sBADTOTAL + Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTYTOTAL"]);
                            sCheckNum = sCheckNum + Convert.ToInt32(rtnDtTemp.Rows[i]["CHECKNUM"]);
                            dtSubTotal.Rows.Add(new object[] { Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["INLOTNO"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTYTOTAL"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["NOWBADQTY"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["PRODRATIO"]),
                                                                                   Convert.ToInt32(rtnDtTemp.Rows [i]["CHECKNUM"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["BADTYPE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["BADRESULT"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["EDITOR"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["EDITDATE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["COMFLAG"])
                                                                                   });
                            continue;
                        }
                        else
                        {
                            dtSubTotal.Rows.Add(new object[] { "", "합 계  : ", sBADTOTAL, sBadqty, sBADTOTAL - sBadqty, Convert.ToString(Math.Round((sBADTOTAL - sBadqty) * 100 / sBADTOTAL, 1)) + "%", sCheckNum });
                            sProdqty = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTYTOTAL"]);
                            sBadqty = Convert.ToDouble(rtnDtTemp.Rows[i]["NOWBADQTY"]);
                            sBADTOTAL = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTYTOTAL"]);
                            sCheckNum = Convert.ToInt32(rtnDtTemp.Rows[i]["CHECKNUM"]);
                            sBadtypepe = Convert.ToString(rtnDtTemp.Rows[i]["BADTYPE"]);
                            dtSubTotal.Rows.Add(new object[] {                     Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["INLOTNO"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTYTOTAL"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["NOWBADQTY"]),
                                                                                   Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["PRODRATIO"]),
                                                                                   Convert.ToInt32(rtnDtTemp.Rows [i]["CHECKNUM"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["BADTYPE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["BADRESULT"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["EDITOR"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["EDITDATE"]),
                                                                                   Convert.ToString(rtnDtTemp.Rows[i]["COMFLAG"])
                                                                                   });



                            sItemCode2 = Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]);
                        }
                    }
                    dtSubTotal.Rows.Add(new object[] { "", "합 계  : ", sBADTOTAL, sBadqty, sBADTOTAL - sBadqty, Convert.ToString(Math.Round((sBADTOTAL - sBadqty) * 100 / sBADTOTAL, 1)) + "%", sCheckNum });

                    sBadtypepe = Convert.ToString(rtnDtTemp.Rows[0]["BADTYPE"]);
                    sBADTOTAL = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTYTOTAL"]);
                    sBadqty = Convert.ToDouble(rtnDtTemp.Rows[0]["NOWBADQTY"]);
                    sCheckNum = Convert.ToInt32(rtnDtTemp.Rows[0]["CHECKNUM"]);

                    for (int k = 1; k < rtnDtTemp.Rows.Count; k++)
                    {
                        if (sBadtypepe == Convert.ToString(rtnDtTemp.Rows[k]["BADTYPE"]))
                        {
                            sBadqty = sBadqty + Convert.ToDouble(rtnDtTemp.Rows[k]["NOWBADQTY"]);
                            sBADTOTAL = sBADTOTAL + Convert.ToDouble(rtnDtTemp.Rows[k]["BADQTYTOTAL"]);
                            sCheckNum = sCheckNum + Convert.ToInt32(rtnDtTemp.Rows[k]["CHECKNUM"]);
                            dtSubTotal2.Rows.Add(new object[] {Convert.ToString(rtnDtTemp.Rows[k]["PLANTCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["INLOTNO"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["BADQTYTOTAL"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["NOWBADQTY"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["PRODQTY"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["PRODRATIO"]),
                                                               Convert.ToInt32(rtnDtTemp.Rows [k]["CHECKNUM"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["ITEMCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["ITEMNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["BADTYPE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["BADRESULT"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["EDITOR"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["EDITDATE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["COMFLAG"])
                                                       });

                            continue;
                        }
                        else
                        {
                            dtSubTotal2.Rows.Add(new object[] { "", "", sBADTOTAL, sBadqty, sBADTOTAL - sBadqty, Convert.ToString(Math.Round((sBADTOTAL - sBadqty) * 100 / sBADTOTAL, 1)) + "%", sCheckNum, "", "", "합 계 :" });
                            sProdqty = Convert.ToDouble(rtnDtTemp.Rows[k]["BADQTYTOTAL"]);
                            sBadqty = Convert.ToDouble(rtnDtTemp.Rows[k]["NOWBADQTY"]);
                            sBADTOTAL = Convert.ToDouble(rtnDtTemp.Rows[k]["BADQTYTOTAL"]);
                            sCheckNum = Convert.ToInt32(rtnDtTemp.Rows[k]["CHECKNUM"]);
                            sBadtypepe = Convert.ToString(rtnDtTemp.Rows[k]["BADTYPE"]);
                            dtSubTotal2.Rows.Add(new object[] {Convert.ToString(rtnDtTemp.Rows[k]["PLANTCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["INLOTNO"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["BADQTYTOTAL"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["NOWBADQTY"]),
                                                               Convert.ToDouble(rtnDtTemp.Rows[k]["PRODQTY"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["PRODRATIO"]),
                                                               Convert.ToInt32(rtnDtTemp.Rows [k]["CHECKNUM"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["ITEMCODE"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["ITEMNAME"]),
                                                               Convert.ToString(rtnDtTemp.Rows[k]["BADTYPE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["BADRESULT"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["EDITOR"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["EDITDATE"]),
                                                               null,//Convert.ToString(rtnDtTemp.Rows[i]["COMFLAG"])
                                                       });



                            sBadtypepe = Convert.ToString(rtnDtTemp.Rows[k]["BADTYPE"]);
                        }
                    }
                    dtSubTotal2.Rows.Add(new object[] { "", "", sBADTOTAL, sBadqty, sBADTOTAL - sBadqty, Convert.ToString(Math.Round((sBADTOTAL - sBadqty) * 100 / sBADTOTAL, 1)) + "%", sCheckNum, "", "", "합 계 :" });

                    this.grid1.DataSource = dtSubTotal;
                    this.grid2.DataSource = dtSubTotal2;
                    #endregion
                }
                if (rtnDtTemp.Rows.Count > 0)
                {
                    //grid1.DataSource = rtnDtTemp;
                    //grid1.DataBinds(rtnDtTemp);
                    this.ShowDialog("조회가 완료 되었습니다", DialogForm.DialogType.OK);
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

        }

        #endregion

        #region [ User Method Area ]
        #endregion

    }
}   