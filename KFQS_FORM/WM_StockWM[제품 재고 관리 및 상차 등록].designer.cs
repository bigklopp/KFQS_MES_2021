namespace KFQS_Form
{
    partial class WM_StockWM
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.sLabel2 = new DC00_Component.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel3 = new DC00_Component.SLabel();
            this.dtEnd_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.dtStart_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel4 = new DC00_Component.SLabel();
            this.lblDate = new DC00_Component.SLabel();
            this.cboShipFlag = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblItemCode = new DC00_Component.SLabel();
            this.sLabel32 = new DC00_Component.SLabel();
            this.sLabel20 = new DC00_Component.SLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustCode = new DC00_Component.SBtnTextEditor();
            this.sLabel5 = new DC00_Component.SLabel();
            this.txtWorkerName = new System.Windows.Forms.TextBox();
            this.txtWorkerId = new DC00_Component.SBtnTextEditor();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.txtItemCode = new DC00_Component.SBtnTextEditor();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.sLabel1 = new DC00_Component.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShipFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.cboShipFlag);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.dtEnd_H);
            this.gbxHeader.Controls.Add(this.dtStart_H);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Controls.Add(this.ultraGroupBox1);
            this.gbxHeader.Controls.Add(this.txtLotNo);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1130, 208);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(3, 211);
            this.gbxBody.Size = new System.Drawing.Size(1130, 564);
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance56.BackColor = System.Drawing.SystemColors.Window;
            appearance56.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance56;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance57.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance57.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance57;
            appearance58.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance58;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance59.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance59.BackColor2 = System.Drawing.SystemColors.Control;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance59.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance59;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance60.BackColor = System.Drawing.SystemColors.Window;
            appearance60.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance60;
            appearance61.BackColor = System.Drawing.SystemColors.Highlight;
            appearance61.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance61;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance62.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance62;
            appearance63.BorderColor = System.Drawing.Color.Silver;
            appearance63.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance63;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance64.BackColor = System.Drawing.SystemColors.Control;
            appearance64.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance64.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance64.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance64;
            appearance65.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance65;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance66.BackColor = System.Drawing.SystemColors.Window;
            appearance66.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance66;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance67.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance67;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1118, 552);
            this.grid1.TabIndex = 8;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtLotNo.Location = new System.Drawing.Point(112, 81);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(164, 30);
            this.txtLotNo.TabIndex = 5;
            // 
            // sLabel2
            // 
            appearance10.FontData.BoldAsString = "False";
            appearance10.FontData.UnderlineAsString = "False";
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance10;
            this.sLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(23, 81);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(83, 23);
            this.sLabel2.TabIndex = 236;
            this.sLabel2.Text = "LOT 번호";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(112, 20);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(145, 32);
            this.cboPlantCode.TabIndex = 0;
            this.cboPlantCode.Text = "cboPlantCode";
            // 
            // sLabel3
            // 
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.UnderlineAsString = "False";
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance18;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(23, 22);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(83, 23);
            this.sLabel3.TabIndex = 231;
            this.sLabel3.Text = "공장";
            // 
            // dtEnd_H
            // 
            this.dtEnd_H.DateButtons.Add(dateButton1);
            this.dtEnd_H.Location = new System.Drawing.Point(957, 16);
            this.dtEnd_H.Name = "dtEnd_H";
            this.dtEnd_H.NonAutoSizeHeight = 26;
            this.dtEnd_H.Size = new System.Drawing.Size(145, 29);
            this.dtEnd_H.TabIndex = 2;
            this.dtEnd_H.TextChanged += new System.EventHandler(this.dtStart_H_TextChanged);
            // 
            // dtStart_H
            // 
            this.dtStart_H.DateButtons.Add(dateButton2);
            this.dtStart_H.Location = new System.Drawing.Point(789, 16);
            this.dtStart_H.Name = "dtStart_H";
            this.dtStart_H.NonAutoSizeHeight = 26;
            this.dtStart_H.Size = new System.Drawing.Size(145, 29);
            this.dtStart_H.TabIndex = 1;
            this.dtStart_H.TextChanged += new System.EventHandler(this.dtStart_H_TextChanged);
            // 
            // sLabel4
            // 
            appearance7.FontData.BoldAsString = "False";
            appearance7.FontData.UnderlineAsString = "False";
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Center";
            this.sLabel4.Appearance = appearance7;
            this.sLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(937, 19);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(17, 26);
            this.sLabel4.TabIndex = 241;
            this.sLabel4.Text = "~";
            // 
            // lblDate
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance5;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(700, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(83, 23);
            this.lblDate.TabIndex = 240;
            this.lblDate.Text = "입고일자";
            // 
            // cboShipFlag
            // 
            this.cboShipFlag.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboShipFlag.Location = new System.Drawing.Point(390, 79);
            this.cboShipFlag.Name = "cboShipFlag";
            this.cboShipFlag.Size = new System.Drawing.Size(175, 32);
            this.cboShipFlag.TabIndex = 621;
            // 
            // lblItemCode
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance1;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(272, 21);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(83, 23);
            this.lblItemCode.TabIndex = 620;
            this.lblItemCode.Text = "품목";
            // 
            // sLabel32
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel32.Appearance = appearance3;
            this.sLabel32.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel32.DbField = null;
            this.sLabel32.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel32.Location = new System.Drawing.Point(19, 30);
            this.sLabel32.Name = "sLabel32";
            this.sLabel32.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel32.Size = new System.Drawing.Size(83, 23);
            this.sLabel32.TabIndex = 613;
            this.sLabel32.Text = "차량 번호";
            // 
            // sLabel20
            // 
            appearance9.FontData.BoldAsString = "False";
            appearance9.FontData.UnderlineAsString = "False";
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.sLabel20.Appearance = appearance9;
            this.sLabel20.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel20.DbField = null;
            this.sLabel20.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel20.Location = new System.Drawing.Point(295, 32);
            this.sLabel20.Name = "sLabel20";
            this.sLabel20.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel20.Size = new System.Drawing.Size(56, 23);
            this.sLabel20.TabIndex = 614;
            this.sLabel20.Text = "작업자";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.txtCustName);
            this.ultraGroupBox1.Controls.Add(this.txtCustCode);
            this.ultraGroupBox1.Controls.Add(this.sLabel5);
            this.ultraGroupBox1.Controls.Add(this.txtWorkerName);
            this.ultraGroupBox1.Controls.Add(this.txtWorkerId);
            this.ultraGroupBox1.Controls.Add(this.txtCarNo);
            this.ultraGroupBox1.Controls.Add(this.sLabel20);
            this.ultraGroupBox1.Controls.Add(this.sLabel32);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(4, 117);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1122, 87);
            this.ultraGroupBox1.TabIndex = 237;
            this.ultraGroupBox1.Text = "상차 실적 등록";
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtCustName.Location = new System.Drawing.Point(936, 31);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(181, 30);
            this.txtCustName.TabIndex = 628;
            // 
            // txtCustCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtCustCode.Appearance = appearance2;
            this.txtCustCode.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtCustCode.btnWidth = 26;
            this.txtCustCode.Location = new System.Drawing.Point(781, 30);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtCustCode.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtCustCode.Size = new System.Drawing.Size(149, 32);
            this.txtCustCode.TabIndex = 627;
            // 
            // sLabel5
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.sLabel5.Appearance = appearance32;
            this.sLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel5.DbField = null;
            this.sLabel5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel5.Location = new System.Drawing.Point(700, 33);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel5.Size = new System.Drawing.Size(75, 23);
            this.sLabel5.TabIndex = 626;
            this.sLabel5.Text = "거래처 명";
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkerName.Location = new System.Drawing.Point(512, 30);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(181, 30);
            this.txtWorkerName.TabIndex = 625;
            // 
            // txtWorkerId
            // 
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerId.Appearance = appearance8;
            this.txtWorkerId.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtWorkerId.btnWidth = 26;
            this.txtWorkerId.Location = new System.Drawing.Point(357, 29);
            this.txtWorkerId.Name = "txtWorkerId";
            this.txtWorkerId.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.Size = new System.Drawing.Size(149, 32);
            this.txtWorkerId.TabIndex = 625;
            // 
            // txtCarNo
            // 
            this.txtCarNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtCarNo.Location = new System.Drawing.Point(108, 28);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(181, 30);
            this.txtCarNo.TabIndex = 625;
            // 
            // txtItemCode
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.txtItemCode.Appearance = appearance6;
            this.txtItemCode.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtItemCode.btnWidth = 26;
            this.txtItemCode.Location = new System.Drawing.Point(361, 16);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtItemCode.Size = new System.Drawing.Size(149, 32);
            this.txtItemCode.TabIndex = 622;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName.Location = new System.Drawing.Point(516, 16);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(181, 30);
            this.txtItemName.TabIndex = 623;
            // 
            // sLabel1
            // 
            appearance29.FontData.BoldAsString = "False";
            appearance29.FontData.UnderlineAsString = "False";
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            appearance29.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance29;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(301, 84);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(83, 23);
            this.sLabel1.TabIndex = 624;
            this.sLabel1.Text = "상차 여부";
            // 
            // WM_StockWM
            // 
            this.ClientSize = new System.Drawing.Size(1136, 778);
            this.Name = "WM_StockWM";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "생산출고 등록/취소";
            this.Load += new System.EventHandler(this.WM_StockWM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShipFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotNo;
        private DC00_Component.SLabel sLabel2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.SLabel sLabel3;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtEnd_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtStart_H;
        private DC00_Component.SLabel sLabel4;
        private DC00_Component.SLabel lblDate;
        private DC00_Component.Grid grid1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboShipFlag;
        private DC00_Component.SLabel lblItemCode;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private DC00_Component.SLabel sLabel20;
        private DC00_Component.SLabel sLabel32;
        private DC00_Component.SLabel sLabel1;
        private System.Windows.Forms.TextBox txtItemName;
        private DC00_Component.SBtnTextEditor txtItemCode;
        private System.Windows.Forms.TextBox txtCustName;
        private DC00_Component.SBtnTextEditor txtCustCode;
        private DC00_Component.SLabel sLabel5;
        private System.Windows.Forms.TextBox txtWorkerName;
        private DC00_Component.SBtnTextEditor txtWorkerId;
        private System.Windows.Forms.TextBox txtCarNo;
    }
}
