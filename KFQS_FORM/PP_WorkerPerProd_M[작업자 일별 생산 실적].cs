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

                rtnDtTemp = helper.FillTable("17PP_WorkerPerProd_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",  sPlantCode,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("WORKER",     sWorker,     DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("STARTDATE",  sStartDate,  DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("ENDDATE",    sEndDate,    DbType.String, ParameterDirection.Input)
                                    );

               this.ClosePrgForm();
                
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
        #endregion
    }
}




