using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DC_POPUP
{
    public class PopUpManager : DC00_PuMan.PopManagerBase
    {
        public override System.Data.DataTable OpenPopUp(string strPopUpName, string[] param)
        {
            System.Data.DataTable rtnDtTemp = null;
            switch (strPopUpName.Trim().ToUpper())
            {

                // 품목 검색
                case "ITEM_MASTER":
                    rtnDtTemp = OpenPopupShow("DC_POPUP", "POP_TBM0100", "품목 팝업", param);
                    break;
                //작업자 검색
                case "WORKER_MASTER":
                    rtnDtTemp = OpenPopupShow("DC_POPUP", "POP_TBM0200", "작업자정보 검색", param);
                    break;
                //공정(작업장) 검색
                case "WORKCENTER_MASTER":
                    rtnDtTemp = OpenPopupShow("DC_POPUP", "POP_TBM0400", "공정(작업장( 검색", param);
                    break;
                //거래선 검색
                case "CUST_MASTER":
                    rtnDtTemp = OpenPopupShow("DC_POPUP", "POP_TBM0300", "거래선정보 검색", param);
                    break;
            }
            return rtnDtTemp;
        }
    }
}
