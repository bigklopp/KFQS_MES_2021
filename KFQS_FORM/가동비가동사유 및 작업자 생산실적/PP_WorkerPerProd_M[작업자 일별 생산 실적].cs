#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WorkerPerProd_M
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
    public partial class PP_WorkerPerProd_M : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        Common _Common             = new Common();
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_WorkerPerProd_M()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_WorkerPerProd_M_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
 

            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",     true, GridColDataType_emu.VarChar,   100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자",   true, GridColDataType_emu.VarChar,   100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE",       "생산일자", true, GridColDataType_emu.VarChar,   100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",   true, GridColDataType_emu.VarChar,   100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", true, GridColDataType_emu.VarChar,   150, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",     true, GridColDataType_emu.VarChar,   100, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",     true, GridColDataType_emu.VarChar,   150, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "생산수량", true, GridColDataType_emu.Double,     90, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량", true, GridColDataType_emu.Double,     90, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALQTY",       "총생산량", true, GridColDataType_emu.VarChar,    90, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORPERCENT",   "불량율",   true, GridColDataType_emu.VarChar,    90, 120, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "생산일시", true, GridColDataType_emu.VarChar,   150, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion


            //this.grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
            //this.grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle      = MergedCellStyle.Always; 
            //this.grid1.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle         = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["PRODDATE"].MergedCellStyle       = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle       = MergedCellStyle.Always;
            //this.grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle       = MergedCellStyle.Always;


            #region ▶ COMBOBOX ◀
            rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWorker_H, txtWorkerName_H, "WORKER_MASTER", new object[] { "", "", "", "", "" }); 
            cboPlantCode.Value = plantCode;
            dtStartDate.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
            #endregion
        }
        #endregion

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {

            //if (Convert.ToString(e.Row.Cells["PLANTCODE"].Value) == "")
            //{
            //    if (Convert.ToString(e.Row.Cells["ITEMNAME"].Value) == "합   계 :")
            //    {
            //        e.Row.Appearance.BackColor = Color.Azure;
            //    }
            //}
        }


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode  = Convert.ToString(cboPlantCode.Value); 
                string sWorker     = Convert.ToString(txtWorker_H.Text);
                string sStartDate  = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
                string sEndDate    = string.Format("{0:yyyy-MM-dd}", dtEnddate.Value);

                rtnDtTemp = helper.FillTable("00PP_WorkerPerProd_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",  sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WORKER",     sWorker,     DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE",  sStartDate,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ENDDATE",    sEndDate,    DbType.String, ParameterDirection.Input)
                                    );

               this.ClosePrgForm();
                //if (rtnDtTemp.Rows.Count != 0)
                //{
                //    #region ▶▶ SUB-TOTAL LOGIC ◀◀

                //    DataTable dtSubTotal = rtnDtTemp.Clone(); // 데이터 테이블 서식 복사

                //    string sWorkerRow = Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]);
                //    double sProdqty   = Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]);
                //    double sBadqty    = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTY"]);
                //    double sTotalqty  = Convert.ToDouble(rtnDtTemp.Rows[0]["TOTALQTY"]);
                //    dtSubTotal.Rows.Add(new object[] { Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]) ,
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["PRODDATE"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]),
                //                                       Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]),
                //                                       Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTY"]),
                //                                       Convert.ToDouble(rtnDtTemp.Rows[0]["TOTALQTY"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["ERRORPERCENT"]),
                //                                       Convert.ToString(rtnDtTemp.Rows[0]["MAKEDATE"])});

                //    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                //    {
                //        if (sWorkerRow == Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]))
                //        {
                //            sProdqty  = sProdqty  + Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                //            sBadqty   = sBadqty   + Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                //            sTotalqty = sTotalqty + Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]);
                //            dtSubTotal.Rows.Add(new object[] { Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]) ,
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["PRODDATE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ERRORPERCENT"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"])}); 
                //            continue;
                //        }
                //        else
                //        { 
                //            dtSubTotal.Rows.Add(new object[] {"","","","","","","합   계 :",  sProdqty, sBadqty, sTotalqty, Convert.ToString(Math.Round(sBadqty * 100 / sProdqty, 1)) + " %","" });
                //            sProdqty  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                //            sBadqty   = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                //            sTotalqty = Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]);
                //            dtSubTotal.Rows.Add(new object[] { Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]) ,
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["PRODDATE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]),
                //                                               Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["ERRORPERCENT"]),
                //                                               Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"])});
                //            sWorkerRow = Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]);
                //        }
                //    }
                //    dtSubTotal.Rows.Add(new object[] { "", "", "", "", "", "", "합   계 :", sProdqty, sBadqty, sTotalqty, Convert.ToString(Math.Round(sBadqty * 100 / sProdqty, 1)) + " %", "" });

                //    this.grid1.DataSource = dtSubTotal;
                //    #endregion
                //}
                grid1.DataSource = rtnDtTemp;

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
             
        }
        #endregion 
    }
}




