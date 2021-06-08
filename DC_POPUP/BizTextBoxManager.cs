using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DC_POPUP
{
    public class BizTextBoxManager : DC00_PuMan.BizTextBoxManagerBase
    {
        static DC_POPUP.PopUp_Biz _biz = new PopUp_Biz();

        public override void Bz_Pop(string sFunctionName, object tCodeBox, object tNameBox, string sValueCode, string sValueName, string[] aParam, string[] ColumnList, object[] ObjectList)
        {
            switch (sFunctionName)
            {

                case "ITEM_MASTER":
                    // ITEM_CD, ITEM_NAME, PLANT_CD, ITEM_TYPE, TextBox1, TextBox2 
                    _biz.TBM0100_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
                    break;
                case "WORKER_MASTER":
                    // PlantCode, OPCode, LineCode, WorkCenterCode, WorkerID, WorkerName, UseFlag, TextBox1, TextBox2
                    _biz.TBM0200_POP(aParam[0], aParam[1], aParam[2], aParam[3], sValueCode, sValueName, aParam[4], tCodeBox, tNameBox);
                    break;
                case "WORKCENTER_MASTER":
                    // PlantCode, OPCode, OPName, UseFlag, TextBox1, TextBox2
                    _biz.TBM0400_POP(aParam[0], sValueCode, sValueName, aParam[1], tCodeBox, tNameBox);
                    break;
                case "CUST_MASTER":
                    // CustCode, CustName, CustType, UseFlag, TextBox1, TextBox2
                    _biz.TBM0300_POP(sValueCode, sValueName, aParam[0], aParam[1], tCodeBox, tNameBox);
                    break;
                default:
                    DC00_WinForm.DialogForm dialogform = new DC00_WinForm.DialogForm("C:S00014");
                    dialogform.ShowDialog();

                    break;
            }
        }
    }
}
