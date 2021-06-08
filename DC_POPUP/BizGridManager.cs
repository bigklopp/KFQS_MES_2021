using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC00_Component;
namespace DC_POPUP

{
    public class BizGridManager : DC00_PuMan.BizGridManagerBase
    {
        static DC_POPUP.PopUp_Biz _biz = new PopUp_Biz();

        public BizGridManager(DC00_Component.Grid grid0)
        {
            base.init(grid0);
        }        
 
        public override void getPopupGrid(string sFunctionName, string sCode, string sName, string sValueCode, string sValueName, string[] aParam1, string[] sParam2)
        {
            switch (sFunctionName)
            {
                case "ITEM_MASTER":
                    _biz.ItemMaster_POP_Grid(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
                    break;
                case "WORKER_MASTER":
                    _biz.TBM0200_POP_Grid(aParam1[0], aParam1[1], aParam1[2], aParam1[3], sValueCode, sValueName, aParam1[4], grid, sCode, sName, sParam2);
                    break;
                case "WORKCENTER_MASTER":
                    _biz.TBM0400_POP_Grid(aParam1[0], sValueCode, sValueName, aParam1[1], grid, sCode, sName);
                    break;
                case "CUST_MASTER":
                    _biz.TBM0300_POP_Grid(sValueCode, sValueName, aParam1[0], aParam1[1], grid, sCode, sName);
                    break;
                default:
                   DC00_WinForm.DialogForm dialogform= new DC00_WinForm.DialogForm("C:S00014");

                    dialogform.ShowDialog();

                    break;
            }
        }
    }
}
