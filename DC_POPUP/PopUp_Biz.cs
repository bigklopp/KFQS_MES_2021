using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Infragistics.Win.UltraWinEditors;
using DC00_assm;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace DC_POPUP
{
    public class PopUp_Biz
    {
        DataSet rtnDsTemp   = new DataSet();   
        DataTable rtnDtTemp = new DataTable(); 
        DataTable DtTemp    = new DataTable();

        public PopUp_Biz()
        {

        }


        #region 품목 팝업
        public DataTable SEL_ItemMaster_POP(string sPlantCD, string sItemCD, string sItemNM, string sItemType)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("SPROC_ITEMMASTER_POP", CommandType.StoredProcedure
                                             , helper.CreateParameter("PLANTCODE", sPlantCD, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMCODE", sItemCD, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMNAME", sItemNM, DbType.String, ParameterDirection.Input)
                                             , helper.CreateParameter("ITEMTYPE", sItemType, DbType.String, ParameterDirection.Input));
                                 
                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 품목 팝업
        
        #region 품목
        public void TBM0100_POP(string ITEM_CD, string ITEM_NAME, string PLANT_CD, string ITEM_TYPE, object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_ItemMaster_POP(PLANT_CD, ITEM_CD, ITEM_NAME, ITEM_TYPE);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["ItemCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["itemname"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (ITEM_CD.Trim() != "" || ITEM_NAME != "")
                        {
                            SetText(Code_ID, string.Empty);
                            SetText(Code_Name, string.Empty);
                        }
                    }

                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("ITEM_MASTER", new string[] { PLANT_CD, ITEM_TYPE, ITEM_CD, ITEM_NAME }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["ItemCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["itemname"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region 품목 Grid
        public void ItemMaster_POP_Grid(string ITEM_CD, string ITEM_NAME, string PLANT_CD, string ITEM_TYPE, UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_ItemMaster_POP(PLANT_CD, ITEM_CD, ITEM_NAME, ITEM_TYPE);

                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["ItemCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["itemname"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        if (ITEM_CD.Trim() != "" || ITEM_NAME != "")
                        {
                        }
                    }
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("ITEM_MASTER", new string[] { PLANT_CD, ITEM_TYPE, ITEM_CD, ITEM_NAME }); // 품목 조회 POP-UP창 Parameter(비가동코드, 비가동명, 비가동그룹)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["ItemCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["itemname"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #region 작업자((WorkerID) 팝업
        /// <summary>
        /// 작업자 정보 팝업
        /// </summary>
        /// <param name="sPlantCode">공장(사업장)</param>
        /// <param name="sOPCode">공정코드</param>
        /// <param name="sLineCode">라인코드</param>
        /// <param name="sWorkCenterCode">작업장코드</param>
        /// <param name="sWorkerID">작업자 ID</param>
        /// <param name="sWorkerName">작업자명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="RS_CODE">리턴 코드</param>
        /// <param name="RS_MSG">리턴 메시지</param>
        /// <returns></returns>
        /// 
        public DataTable SEL_TBM0200(string sPlantCode, string sOPCode, string sLineCode, string sWorkCenterCode, string sWorkerID, string sWorkerName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_WorkerList_POP", CommandType.StoredProcedure
                                                                  , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input)
                                                                  , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("@Lang", SAMMI.Common.Lang, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 작업자  팝업

        #region 작업자
        /// <summary>
        /// 작업자 팝업 데이타 가져오기
        /// </summary>
        /// <param name="PlantCode">사업장</param>
        /// <param name="OPCode">공정코드</param>
        /// <param name="LineCode">라인코드</param>
        /// <param name="WorkCenterCode">작업장코드</param>
        /// <param name="WorkerID">작업자</param>
        /// <param name="WorkerName">작업자명</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_NAME)</param>
        public void TBM0200_POP(string PlantCode, string OPCode, string LineCode, string WorkCenterCode, string WorkerID, string WorkerName, string UseFlag,
                                object Code_ID, object Code_Name, string[] sList = null, string[] objList = null)
        {
            try
            {
                DtTemp = SEL_TBM0200(PlantCode, OPCode, LineCode, WorkCenterCode, WorkerID, WorkerName, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["WorkerID"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["WorkerName"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                        try
                        {
                            WorkerID = "";
                            WorkerName = "";
                        }
                        catch { }
                        //  MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }


                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("WORKER_MASTER", new string[] { PlantCode, OPCode, LineCode, WorkCenterCode, WorkerID, WorkerName, UseFlag }); // 작업  POP-UP창 Parameter(작업자 ID, 작업자명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["WorkerID"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["WorkerName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 작업자 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM200", new string[] { PlantCode, OPCode, LineCode, WorkCenterCode, WorkerID, WorkerName, UseFlag }); // 작업  POP-UP창 Parameter(작업자 ID, 작업자명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);

                        //if (sList != null && objList != null)
                        //{
                        //    if (sList.Count() == objList.Count())
                        //    {
                        //        for (int i = 0; i < sList.Count(); i++)
                        //        {
                        //            TextBox t = (TextBox)objList[i];
                        //            t.Text = DBHelper.nvlString(DtTemp.Rows[0][sList[i]]);
                        //        }
                        //    }
                        //}
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
        #endregion

        #region 작업자  Grid
        /// <summary>
        /// 작업자 가져오기
        /// </summary>
        /// <param name="sPlantCode">공장(사업장)</param>
        /// <param name="sOPCode">공정코드</param>
        /// <param name="sLineCode">라인코드</param>
        /// <param name="sWorkCenterCode">작업장코드</param>
        /// <param name="sWorkerID">작업자 ID</param>
        /// <param name="sWorkerName">작업자명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="Grid">대상 그리드</param>
        /// <param name="Column1">리턴 품목 코드(그리드 해당 컬럼 명)</param>
        /// <param name="Column2">리턴 품목 명(그리드 해당 컬럼 명)</param>

        public void TBM0200_POP_Grid(string sPlantCode, string sOPCode, string sLineCode, string sWorkCenterCode, string sWorkerID, string sWorkerName, string sUseFlag
                , UltraGrid Grid, string Column1, string Column2, string[] sParam = null)
        {
            try
            {
                DBHelper helper = new DBHelper(false);
                DtTemp = SEL_TBM0200(sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        //MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("WORKER_MASTER", new string[] { sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag }); // 작업자  POP-UP창 Parameter(작업자ID, 작업자명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM200", new string[] { sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag }); // 작업자  POP-UP창 Parameter(작업자ID, 작업자명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);

                        if (sParam != null)
                        {
                            foreach (string s in sParam)
                            {
                                string[] sA = s.Split('|');

                                if (sA.Length == 2)
                                {
                                    Grid.ActiveRow.Cells[sA[0]].Value = DBHelper.nvlString(DtTemp.Rows[0][sA[1]]);
                                }
                                else
                                {
                                    Grid.ActiveRow.Cells[s].Value = DBHelper.nvlString(DtTemp.Rows[0][s]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["WorkerID"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["WorkerName"]);

                        if (sParam != null)
                        {
                            foreach (string s in sParam)
                            {
                                string[] sA = s.Split('|');

                                if (sA.Length == 2)
                                {
                                    Grid.ActiveRow.Cells[sA[0]].Value = DBHelper.nvlString(DtTemp.Rows[0][sA[1]]);
                                }
                                else
                                {
                                    Grid.ActiveRow.Cells[s].Value = DBHelper.nvlString(DtTemp.Rows[0][s]);
                                }
                            }
                        }
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }
                  */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        #region 작업장(OPCODE) 공정 팝업 
        public DataTable SEL_TBM0400(string sPlantCode, string sOpCode, string sOpName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_WorkcenterMaster_POP", CommandType.StoredProcedure
                , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("OPNAME", sOpName, DbType.String, ParameterDirection.Input)
                , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                //,helper.CreateParameter("@Lang", SAMMI.Common.Lang, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 작업장 팝업

        #region 공정(작업장)
        /// <summary>
        /// 공정 작업장 팝업 데이타 가져오기
        /// </summary>
        /// <param name="PlantCode">사업장</param>
        /// <param name="OPCode">공정코드</param>
        /// <param name="OPName">공정명</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_NAME)</param>
        public void TBM0400_POP(string PlantCode, string OPCode, string OPName, string UseFlag,
                                object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0400(PlantCode, OPCode, OPName, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["OPCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["OPName"]));
                }
                else
                {
                    SetText(Code_ID, string.Empty);
                    SetText(Code_Name, string.Empty);
                    //MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    // 작업자 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("WORKCENTER_MASTER", new string[] { PlantCode, OPCode, OPName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["OPCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["OPName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 작업자 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM400", new string[] { PlantCode, OPCode, OPName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
        #endregion 공정(작업장)

        #region 공정(작업장) Grid
        /// <summary>
        /// 공정(작업장) 가져오기
        /// </summary>
        /// <param name="PlantCode">사업장</param>
        /// <param name="OPCode">공정코드</param>
        /// <param name="OPName">공정명</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">대상 그리드</param>
        /// <param name="Column1">리턴 품목 코드(그리드 해당 컬럼 명)</param>
        /// <param name="Column2">리턴 품목 명(그리드 해당 컬럼 명)</param>
        public void TBM0400_POP_Grid(string PlantCode, string OPCode, string OPName, string UseFlag, UltraGrid Grid, string Column1, string Column2)
        {

            try
            {

                DtTemp = SEL_TBM0400(PlantCode, OPCode, OPName, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                }
                else
                {
                    //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                    //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    // MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("WORKCENTER_MASTER", new string[] { PlantCode, OPCode, OPName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM400", new string[] { PlantCode, OPCode, OPName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        //#region 공정(작업장)
        ///// <summary>
        ///// 커스터 마이즈 공정 (작업장 가저오기 )  -- 대원강업_2013.11.04_김두환
        ///// </summary>
        ///// <param name="PlantCode">사업장</param>
        ///// <param name="OPCode">공정코드</param>
        ///// <param name="OPName">공정명</param>
        ///// <param name="UseFlag">사용여부</param>
        ///// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        ///// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_NAME)</param>
        //public void XBM0400_POP(string PlantCode, string OPCode, string OPName, string UseFlag,
        //                        TextBox Code_ID, TextBox Code_Name)
        //{
        //    try
        //    {
        //        DtTemp = SEL_TBM0400(PlantCode, OPCode, OPName, UseFlag);

        //        if (DtTemp.Rows.Count > 1)
        //        {
        //            // 작업자 POP-UP 창 처리
        //            PopUpManager pu = new PopUpManager();
        //            DtTemp = pu.OpenPopUp("XBM400", new string[] { PlantCode, OPCode, OPName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

        //            if (DtTemp != null && DtTemp.Rows.Count > 0)
        //            {
        //                Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
        //                Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
        //            }
        //        }
        //        else
        //        {
        //            if (DtTemp.Rows.Count == 1)
        //            {
        //                Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
        //                Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
        //            }
        //            else
        //            {
        //                Code_ID.Text = string.Empty;
        //                Code_Name.Text = string.Empty;
        //                MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "ERROR");
        //    }

        //}
        //#endregion 공정(작업장)

        #region 작업장(OPCODE) 공정 팝업 
        public DataTable SEL_TBM0401(string sPlantCode, string sOpCode, string sOpName, string ItemCode, string ItemName, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0401_POP", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("OPCODE", sOpCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("OPNAME", sOpName, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMCODE", ItemCode, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("ITEMNAME", ItemName, DbType.String, ParameterDirection.Input)
                                                             , helper.CreateParameter("USEFLAG", sUseFlag, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("@Lang", SAMMI.Common.Lang, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 작업장 팝업

        #region 공정(작업장)
        /// <summary>
        /// 공정 작업장 팝업 데이타 가져오기
        /// </summary>
        /// <param name="PlantCode">사업장</param>
        /// <param name="OPCode">공정코드</param>
        /// <param name="OPName">공정명</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_NAME)</param>
        public void TBM0401_POP(string PlantCode, string OPCode, string OPName, string UseFlag,
                                string ItemCode, string ItemName,
                                object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);
                if (DtTemp.Rows.Count == 0)
                {
                    ItemCode = "";
                    ItemName = "";
                    DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);
                }


                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["OPCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["OPName"]));
                }
                else
                {
                    SetText(Code_ID, string.Empty);
                    SetText(Code_Name, string.Empty);
                    // MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    // 작업자 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM401", new string[] { PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["OPCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["OPName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count == 0)
                {
                    ItemCode = "";
                    ItemName = "";
                }

                DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);

                if (DtTemp.Rows.Count > 1)
                {
                    // 작업자 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM401", new string[] { PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
        #endregion 공정(작업장)

        #region 공정(작업장) Grid
        /// <summary>
        /// 공정(작업장) 가져오기
        /// </summary>
        /// <param name="PlantCode">사업장</param>
        /// <param name="OPCode">공정코드</param>
        /// <param name="OPName">공정명</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">대상 그리드</param>
        /// <param name="Column1">리턴 품목 코드(그리드 해당 컬럼 명)</param>
        /// <param name="Column2">리턴 품목 명(그리드 해당 컬럼 명)</param>
        public void TBM0400_POP_Grid(string PlantCode, string OPCode, string OPName, string UseFlag
                        , string ItemCode, string ItemName, UltraGrid Grid, string Column1, string Column2)
        {

            try
            {

                DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                }
                else
                {
                    //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                    //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    // MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM401", new string[] { PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                /*
               if (DtTemp.Rows.Count == 0)
                {
                    ItemCode = "";
                    ItemName = "";
                    DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);
                }
                if (DtTemp.Rows.Count == 0)
                {
                    ItemCode = "";
                    ItemName = "";
                }

                DtTemp = SEL_TBM0401(PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag);

                if (DtTemp.Rows.Count > 1)
                {
                    // 품목 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM401", new string[] { PlantCode, OPCode, OPName, ItemCode, ItemName, UseFlag }); // 작업  POP-UP창 Parameter(공정, 공정명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["OPCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["OPName"]);
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        #region 거래선-업체  (CustCode) 팝업
        /// <summary>
        /// 거래선(업체) 정보 팝업
        /// </summary>
        /// <param name="sCustType">거래처구분</param>
        /// <param name="sCustCode">거래처코드</param>
        /// <param name="sCustName">거래처명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="RS_CODE">리턴 코드</param>
        /// <param name="RS_MSG">리턴 메시지</param>
        /// <returns></returns>
        /// 
        public DataTable SEL_TBM0300(string sCustCode, string sCustName, string sCustType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_CUSTMASTER_POP", CommandType.StoredProcedure
                                                           , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("CustName", sCustName, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("CustType", sCustType, DbType.String, ParameterDirection.Input)
                                                           , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("@Lang", SAMMI.Common.Lang, DbType.String, ParameterDirection.Input));


                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 거래선  팝업

        #region 거래선(업체)
        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_ID)</param>
        public void TBM0300_POP(string CustCode, string CustName, string sPlantcode, string CustType, string UseFlag
                               , object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                        //MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_ID)</param>
        public void TBM0300_POP(string CustCode, string CustName, string CustType, string UseFlag
                               , object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                        //MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("CUST_MASTER", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">적용할 Grid</param>
        /// <param name="Column1">Return 컬럼 ( Code )</param>
        /// <param name="Column2">Return 컬럼 ( Name )</param>
        public void TBM0300_POP_Grid(string CustCode, string CustName, string sPlantCode, string CustType, string UseFlag
                                    , UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    }
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }

                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">적용할 Grid</param>
        /// <param name="Column1">Return 컬럼 ( Code )</param>
        /// <param name="Column2">Return 컬럼 ( Name )</param>
        public void TBM0300_POP_Grid(string CustCode, string CustName, string CustType, string UseFlag
                                    , UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        // MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("CUST_MASTER", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM300", new string[] { CustCode, CustName, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #region 거래선-업체  ( CustCode) 팝업 - PlantCode 포함
        /// <summary>
        /// 거래선(업체) 정보 팝업
        /// </summary>
        /// <param name="sCustType">거래처구분</param>
        /// <param name="sCustCode">거래처코드</param>
        /// <param name="sCustName">거래처명</param>
        /// <param name="sUseFlag">사용여부</param>
        /// <param name="RS_CODE">리턴 코드</param>
        /// <param name="RS_MSG">리턴 메시지</param>
        /// <returns></returns>
        /// 
        public DataTable SEL_TBM0301(string sCustCode, string sCustName, string sPlantCode, string sCustType, string sUseFlag)
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                rtnDtTemp = helper.FillTable("USP_BM0301_POP", CommandType.StoredProcedure
                                              , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("CustCode", sCustCode, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("CustName", sCustName, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("CustType", sCustType, DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                //, helper.CreateParameter("@Lang", SAMMI.Common.Lang, DbType.String, ParameterDirection.Input));

                return rtnDtTemp;
            }
            catch (Exception)
            {

                return new DataTable();
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion 거래선  팝업

        #region ▶ 거래선-협력사 선택 팝업창(mskwon, 2015.10.20, 추가)

        /// <summary>
        /// 거래선-협력사 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_ID)</param>
        public void TBM0310Y_POP(string CustCode, string CustName, string UseFlag, object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, "V", UseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                    }

                    // 거래처(협력업체) POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM310Y", new string[] { CustCode, CustName, "V", UseFlag });

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// 거래선-협력사 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">적용할 Grid</param>
        /// <param name="Column1">Return 컬럼 ( Code )</param>
        /// <param name="Column2">Return 컬럼 ( Name )</param>
        public void TBM0310Y_POP_Grid(string CustCode, string CustName, string UseFlag, UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, "V", UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    }

                    // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM310Y", new string[] { CustCode, CustName, "V", UseFlag });

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #region ▶ 거래선-고객사 선택 팝업창(mskwon, 2015.10.20, 추가)

        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_ID)</param>
        public void TBM0320Y_POP(string CustCode, string CustName, string UseFlag, object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, "C", UseFlag);

                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                    }

                    // 거래처(협력업체) POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM320Y", new string[] { CustCode, CustName, "C", UseFlag });

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// 거래선-협력사 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">적용할 Grid</param>
        /// <param name="Column1">Return 컬럼 ( Code )</param>
        /// <param name="Column2">Return 컬럼 ( Name )</param>
        public void TBM0320Y_POP_Grid(string CustCode, string CustName, string UseFlag, UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_TBM0300(CustCode, CustName, "C", UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]);
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    }

                    // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM320Y", new string[] { CustCode, CustName, "C", UseFlag });

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CUSTCODE"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CUSTNAME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #region 거래선(업체)
        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Code_ID">Return TextBox 컨트롤 이름(CODE_ID)</param>
        /// <param name="Code_Name">Return TextBox 컨트롤 이름(CODE_ID)</param>
        public void TBM0301_POP(string CustCode, string CustName, string PlantCode, string CustType, string UseFlag, string CustTypeEnabled
                               , object Code_ID, object Code_Name)
        {
            try
            {
                DtTemp = SEL_TBM0301(CustCode, CustName, PlantCode, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                    SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                }
                else
                {
                    if (DtTemp.Rows.Count == 0)
                    {
                        SetText(Code_ID, string.Empty);
                        SetText(Code_Name, string.Empty);
                        //MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM301", new string[] { CustCode, CustName, PlantCode, CustType, UseFlag, CustTypeEnabled }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        SetText(Code_ID, Convert.ToString(DtTemp.Rows[0]["CustCode"]));
                        SetText(Code_Name, Convert.ToString(DtTemp.Rows[0]["CustName"]));
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM301", new string[] { CustCode, CustName, PlantCode, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Code_ID.Text = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Code_Name.Text = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Code_ID.Text = string.Empty;
                        Code_Name.Text = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        /// <summary>
        /// 거래선(업체) 팝업 데이타 가져오기
        /// </summary>
        /// <param name="CustCode">거래처 코드</param>
        /// <param name="CustName">거래처 명</param>
        /// <param name="CustType">거래처 구분</param>
        /// <param name="UseFlag">사용여부</param>
        /// <param name="Grid">적용할 Grid</param>
        /// <param name="Column1">Return 컬럼 ( Code )</param>
        /// <param name="Column2">Return 컬럼 ( Name )</param>
        public void TBM0301_POP_Grid(string CustCode, string CustName, string PlantCode, string CustType, string UseFlag
                                    , UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DtTemp = SEL_TBM0301(CustCode, CustName, PlantCode, CustType, UseFlag);
                if (DtTemp.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                }
                else
                {
                    //Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                    //Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    // MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM301", new string[] { CustCode, CustName, PlantCode, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                /*
                if (DtTemp.Rows.Count > 1)
                {
                    // 거래선 POP-UP 창 처리
                    PopUpManager pu = new PopUpManager();
                    DtTemp = pu.OpenPopUp("TBM301", new string[] { CustCode, CustName, PlantCode, CustType, UseFlag }); // 거래처  POP-UP창 Parameter(거래처코드, 거래처명)

                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                }
                else
                {
                    if (DtTemp.Rows.Count == 1)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(DtTemp.Rows[0]["CustCode"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(DtTemp.Rows[0]["CustName"]);
                    }
                    else
                    {
                        Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                        Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                        MessageBox.Show("입력하신 정보는 없는 정보입니다.", "ERROR");
                    }

                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        #endregion

        #endregion


        #endregion


        private void SetText(object objControl, string sValue)
        {
            if (objControl.GetType().Name.Equals("TextBox"))
                ((TextBox)objControl).Text = sValue;
            else
                ((UltraTextEditor)objControl).Text = sValue;
        }


    }
}
