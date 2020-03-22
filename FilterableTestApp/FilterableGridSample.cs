using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using GridViewExtensions;
using GridViewExtensions.GridFilters;
using GridViewExtensions.GridFilterFactories;

namespace FilterableTestApp
{
	public class FilterableGridSample : System.Windows.Forms.Form
	{
        private System.Windows.Forms.CheckBox _cbKeepFilters;
		private System.Windows.Forms.Button _btnLoadFilters;
		private System.Windows.Forms.Button _btnSaveFilters;
		private System.Windows.Forms.ComboBox _cmbTables;
		private GridViewExtensions.FilterableDataGrid _grid;
		private System.Windows.Forms.GroupBox _gbFilterPosition;
		private System.Windows.Forms.RadioButton _rbFilterPositionTop;
		private System.Windows.Forms.RadioButton _rbFilterPositionBottom;
		private System.Windows.Forms.RadioButton _rbFilterPositionOff;
		private System.Windows.Forms.GroupBox _gbOperator;
		private System.Windows.Forms.RadioButton _rbOperatorOr;
		private System.Windows.Forms.RadioButton _rbOperatorAnd;
		private System.Windows.Forms.Button _btnClear;
		private System.Windows.Forms.Button _btnRefresh;
		private System.Windows.Forms.ListBox _lbSavedFilters;
		private System.Windows.Forms.Label _lblSelectTable;
		private System.Windows.Forms.GroupBox _gbCurrentFilter;
		private System.Windows.Forms.Label _lblCurrentFilter;
		private System.Windows.Forms.CheckBox _cbShowFilterText;
		private System.Windows.Forms.TextBox _tbFilterText;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox _gbRightToLeft;
		private System.Windows.Forms.RadioButton _rbRightToLeftYes;
		private System.Windows.Forms.RadioButton _rbRightToLeftNo;
		private System.Windows.Forms.ComboBox _cmbFilterFactories;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel _pnlDefaultFactoryProperties;
		private System.Windows.Forms.CheckBox _chkCreateDistinctFilters;
		private System.Windows.Forms.NumericUpDown _nudDistinctFilterMaximum;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox _chkHandleEnumTypes;
        private TextBox _tbSetDefaults;
        private Button _btnSetDefaults;
        private CheckBox _chkShowInBetweenOperator;
        private CheckBox _chkBaseFiltersEnabled;
        private TextBox _tbCurrentBaseFilter;
        private Button _btnApplyCurrentBaseFilter;
        private bool _listMode;
        private ComboBox _cmbRefreshMode;
        private Label _lblRefreshMode;

		private string[] _savedFilters;

		public FilterableGridSample(bool listMode)
		{
			InitializeComponent();
            _listMode = listMode;
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_listMode)
            {
                _grid.DataSource = new GridViewExtensions.BindingListView<Order>(DataHelper.SampleList);
                _cmbTables.Visible = false;
            }
            else
            {
                foreach (DataTable table in DataHelper.SampleData.Tables)
                    _cmbTables.Items.Add(table.TableName);
                _cmbTables.SelectedIndex = 1;
            }

            _grid.EmbeddedDataGridView.ReadOnly = true;
            _grid.EmbeddedDataGridView.AllowUserToOrderColumns = true;

            _grid.EmbeddedDataGridView.MouseUp += new MouseEventHandler(OnEmbeddedDataGridViewMouseUp);

            _cmbFilterFactories.Items.Add(_grid.FilterFactory);
            _cmbFilterFactories.SelectedIndex = 0;
            _cmbFilterFactories.Items.Add(new NullGridFilterFactory());
            _cmbFilterFactories.Items.Add(new DistinctValuesGridFilterFactory());

            _cmbFilterFactories.SelectedIndexChanged += new EventHandler(OnFilterFactoriesSelectedIndexChanged);

            foreach (RefreshMode mode in Enum.GetValues(typeof(RefreshMode)))
                _cmbRefreshMode.Items.Add(mode);
            _cmbRefreshMode.SelectedItem = RefreshMode.OnInput;
        }

        private void OnEmbeddedDataGridViewMouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = _grid.EmbeddedDataGridView.HitTest(e.X, e.Y);
            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewColumn column = _grid.EmbeddedDataGridView.Columns[hti.ColumnIndex];
                    column.Visible = !column.Visible;
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    foreach (DataGridViewColumn column in _grid.EmbeddedDataGridView.Columns)
                        column.Visible = true;
                }
            }
        }

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this._grid = new GridViewExtensions.FilterableDataGrid();
            this._gbFilterPosition = new System.Windows.Forms.GroupBox();
            this._rbFilterPositionTop = new System.Windows.Forms.RadioButton();
            this._rbFilterPositionBottom = new System.Windows.Forms.RadioButton();
            this._rbFilterPositionOff = new System.Windows.Forms.RadioButton();
            this._gbOperator = new System.Windows.Forms.GroupBox();
            this._rbOperatorOr = new System.Windows.Forms.RadioButton();
            this._rbOperatorAnd = new System.Windows.Forms.RadioButton();
            this._btnClear = new System.Windows.Forms.Button();
            this._cbKeepFilters = new System.Windows.Forms.CheckBox();
            this._btnRefresh = new System.Windows.Forms.Button();
            this._btnLoadFilters = new System.Windows.Forms.Button();
            this._btnSaveFilters = new System.Windows.Forms.Button();
            this._lbSavedFilters = new System.Windows.Forms.ListBox();
            this._cmbTables = new System.Windows.Forms.ComboBox();
            this._lblSelectTable = new System.Windows.Forms.Label();
            this._gbCurrentFilter = new System.Windows.Forms.GroupBox();
            this._lblCurrentFilter = new System.Windows.Forms.Label();
            this._cbShowFilterText = new System.Windows.Forms.CheckBox();
            this._tbFilterText = new System.Windows.Forms.TextBox();
            this._gbRightToLeft = new System.Windows.Forms.GroupBox();
            this._rbRightToLeftYes = new System.Windows.Forms.RadioButton();
            this._rbRightToLeftNo = new System.Windows.Forms.RadioButton();
            this._cmbFilterFactories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._pnlDefaultFactoryProperties = new System.Windows.Forms.Panel();
            this._nudDistinctFilterMaximum = new System.Windows.Forms.NumericUpDown();
            this._chkCreateDistinctFilters = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this._chkHandleEnumTypes = new System.Windows.Forms.CheckBox();
            this._tbSetDefaults = new System.Windows.Forms.TextBox();
            this._btnSetDefaults = new System.Windows.Forms.Button();
            this._chkShowInBetweenOperator = new System.Windows.Forms.CheckBox();
            this._chkBaseFiltersEnabled = new System.Windows.Forms.CheckBox();
            this._tbCurrentBaseFilter = new System.Windows.Forms.TextBox();
            this._btnApplyCurrentBaseFilter = new System.Windows.Forms.Button();
            this._cmbRefreshMode = new System.Windows.Forms.ComboBox();
            this._lblRefreshMode = new System.Windows.Forms.Label();
            this._gbFilterPosition.SuspendLayout();
            this._gbOperator.SuspendLayout();
            this._gbCurrentFilter.SuspendLayout();
            this._gbRightToLeft.SuspendLayout();
            this._pnlDefaultFactoryProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._nudDistinctFilterMaximum)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ConsoleErrorMode = ((GridViewExtensions.FilterErrorModes)(((GridViewExtensions.FilterErrorModes.General | GridViewExtensions.FilterErrorModes.ExceptionMessage) 
            | GridViewExtensions.FilterErrorModes.StackTrace)));
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this._grid.FilterFactory = defaultGridFilterFactory1;
            this._grid.Location = new System.Drawing.Point(10, 200);
            this._grid.MessageErrorMode = ((GridViewExtensions.FilterErrorModes)(((GridViewExtensions.FilterErrorModes.General | GridViewExtensions.FilterErrorModes.ExceptionMessage) 
            | GridViewExtensions.FilterErrorModes.StackTrace)));
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(780, 290);
            this._grid.TabIndex = 1000;
            this._grid.AfterFiltersChanged += new System.EventHandler(this.OnAfterFiltersChanged);
            this._grid.BeforeFiltersChanging += new System.EventHandler(this.OnBeforeFiltersChanged);
            this._grid.GridFilterBound += new GridViewExtensions.GridFilterEventHandler(this.OnGridFilterBound);
            this._grid.GridFilterUnbound += new GridViewExtensions.GridFilterEventHandler(this.OnGridFilterUnbound);
            this._grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnGridKeyDown);
            this._grid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnGridKeyPress);
            this._grid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnGridKeyUp);
            this._grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnGridMouseDown);
            this._grid.MouseEnter += new System.EventHandler(this.OnGridMouseEnter);
            this._grid.MouseLeave += new System.EventHandler(this.OnGridMouseLeave);
            this._grid.MouseHover += new System.EventHandler(this.OnGridMouseHover);
            this._grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnGridMouseUp);
            this._grid.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnGridPreviewKeyDown);
            // 
            // _gbFilterPosition
            // 
            this._gbFilterPosition.Controls.Add(this._rbFilterPositionTop);
            this._gbFilterPosition.Controls.Add(this._rbFilterPositionBottom);
            this._gbFilterPosition.Controls.Add(this._rbFilterPositionOff);
            this._gbFilterPosition.Location = new System.Drawing.Point(10, 9);
            this._gbFilterPosition.Name = "_gbFilterPosition";
            this._gbFilterPosition.Size = new System.Drawing.Size(115, 103);
            this._gbFilterPosition.TabIndex = 1;
            this._gbFilterPosition.TabStop = false;
            this._gbFilterPosition.Text = "Filter Position";
            // 
            // _rbFilterPositionTop
            // 
            this._rbFilterPositionTop.Checked = true;
            this._rbFilterPositionTop.Location = new System.Drawing.Point(19, 26);
            this._rbFilterPositionTop.Name = "_rbFilterPositionTop";
            this._rbFilterPositionTop.Size = new System.Drawing.Size(87, 17);
            this._rbFilterPositionTop.TabIndex = 0;
            this._rbFilterPositionTop.TabStop = true;
            this._rbFilterPositionTop.Text = "Top";
            this._rbFilterPositionTop.CheckedChanged += new System.EventHandler(this.OnFilterPositionCheckedChanged);
            // 
            // _rbFilterPositionBottom
            // 
            this._rbFilterPositionBottom.Location = new System.Drawing.Point(19, 43);
            this._rbFilterPositionBottom.Name = "_rbFilterPositionBottom";
            this._rbFilterPositionBottom.Size = new System.Drawing.Size(87, 17);
            this._rbFilterPositionBottom.TabIndex = 0;
            this._rbFilterPositionBottom.Text = "Bottom";
            this._rbFilterPositionBottom.CheckedChanged += new System.EventHandler(this.OnFilterPositionCheckedChanged);
            // 
            // _rbFilterPositionOff
            // 
            this._rbFilterPositionOff.Location = new System.Drawing.Point(19, 78);
            this._rbFilterPositionOff.Name = "_rbFilterPositionOff";
            this._rbFilterPositionOff.Size = new System.Drawing.Size(87, 17);
            this._rbFilterPositionOff.TabIndex = 0;
            this._rbFilterPositionOff.Text = "Off";
            this._rbFilterPositionOff.CheckedChanged += new System.EventHandler(this.OnFilterPositionCheckedChanged);
            // 
            // _gbOperator
            // 
            this._gbOperator.Controls.Add(this._rbOperatorOr);
            this._gbOperator.Controls.Add(this._rbOperatorAnd);
            this._gbOperator.Location = new System.Drawing.Point(163, 103);
            this._gbOperator.Name = "_gbOperator";
            this._gbOperator.Size = new System.Drawing.Size(87, 61);
            this._gbOperator.TabIndex = 2;
            this._gbOperator.TabStop = false;
            this._gbOperator.Text = "Operator";
            // 
            // _rbOperatorOr
            // 
            this._rbOperatorOr.Location = new System.Drawing.Point(19, 34);
            this._rbOperatorOr.Name = "_rbOperatorOr";
            this._rbOperatorOr.Size = new System.Drawing.Size(58, 18);
            this._rbOperatorOr.TabIndex = 0;
            this._rbOperatorOr.Text = "Or";
            this._rbOperatorOr.CheckedChanged += new System.EventHandler(this.OnOperatorCheckedChanged);
            // 
            // _rbOperatorAnd
            // 
            this._rbOperatorAnd.Checked = true;
            this._rbOperatorAnd.Location = new System.Drawing.Point(19, 17);
            this._rbOperatorAnd.Name = "_rbOperatorAnd";
            this._rbOperatorAnd.Size = new System.Drawing.Size(58, 17);
            this._rbOperatorAnd.TabIndex = 0;
            this._rbOperatorAnd.TabStop = true;
            this._rbOperatorAnd.Text = "And";
            this._rbOperatorAnd.CheckedChanged += new System.EventHandler(this.OnOperatorCheckedChanged);
            // 
            // _btnClear
            // 
            this._btnClear.Location = new System.Drawing.Point(257, 138);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(67, 25);
            this._btnClear.TabIndex = 3;
            this._btnClear.Text = "Clear";
            this._btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // _cbKeepFilters
            // 
            this._cbKeepFilters.Location = new System.Drawing.Point(132, 13);
            this._cbKeepFilters.Name = "_cbKeepFilters";
            this._cbKeepFilters.Size = new System.Drawing.Size(96, 17);
            this._cbKeepFilters.TabIndex = 21;
            this._cbKeepFilters.Text = "Keep filters";
            this._cbKeepFilters.CheckedChanged += new System.EventHandler(this.OnKeepFiltersCheckedChanged);
            // 
            // _btnRefresh
            // 
            this._btnRefresh.Location = new System.Drawing.Point(259, 103);
            this._btnRefresh.Name = "_btnRefresh";
            this._btnRefresh.Size = new System.Drawing.Size(67, 25);
            this._btnRefresh.TabIndex = 3;
            this._btnRefresh.Text = "Refresh";
            this._btnRefresh.Click += new System.EventHandler(this.OnRefreshClick);
            // 
            // _btnLoadFilters
            // 
            this._btnLoadFilters.Enabled = false;
            this._btnLoadFilters.Location = new System.Drawing.Point(269, 43);
            this._btnLoadFilters.Name = "_btnLoadFilters";
            this._btnLoadFilters.Size = new System.Drawing.Size(67, 25);
            this._btnLoadFilters.TabIndex = 23;
            this._btnLoadFilters.Text = "Load <<";
            this._btnLoadFilters.Click += new System.EventHandler(this.OnLoadFiltersClick);
            // 
            // _btnSaveFilters
            // 
            this._btnSaveFilters.Location = new System.Drawing.Point(269, 9);
            this._btnSaveFilters.Name = "_btnSaveFilters";
            this._btnSaveFilters.Size = new System.Drawing.Size(67, 24);
            this._btnSaveFilters.TabIndex = 22;
            this._btnSaveFilters.Text = "Save >>";
            this._btnSaveFilters.Click += new System.EventHandler(this.OnSaveFiltersClick);
            // 
            // _lbSavedFilters
            // 
            this._lbSavedFilters.HorizontalScrollbar = true;
            this._lbSavedFilters.ItemHeight = 12;
            this._lbSavedFilters.Location = new System.Drawing.Point(336, 9);
            this._lbSavedFilters.Name = "_lbSavedFilters";
            this._lbSavedFilters.Size = new System.Drawing.Size(326, 136);
            this._lbSavedFilters.TabIndex = 24;
            // 
            // _cmbTables
            // 
            this._cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTables.Location = new System.Drawing.Point(672, 26);
            this._cmbTables.Name = "_cmbTables";
            this._cmbTables.Size = new System.Drawing.Size(173, 20);
            this._cmbTables.TabIndex = 25;
            this._cmbTables.SelectedIndexChanged += new System.EventHandler(this.OnSelectedTableChanged);
            // 
            // _lblSelectTable
            // 
            this._lblSelectTable.Location = new System.Drawing.Point(672, 9);
            this._lblSelectTable.Name = "_lblSelectTable";
            this._lblSelectTable.Size = new System.Drawing.Size(173, 17);
            this._lblSelectTable.TabIndex = 26;
            this._lblSelectTable.Text = "Select table:";
            // 
            // _gbCurrentFilter
            // 
            this._gbCurrentFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbCurrentFilter.Controls.Add(this._lblCurrentFilter);
            this._gbCurrentFilter.Location = new System.Drawing.Point(10, 499);
            this._gbCurrentFilter.Name = "_gbCurrentFilter";
            this._gbCurrentFilter.Size = new System.Drawing.Size(780, 69);
            this._gbCurrentFilter.TabIndex = 27;
            this._gbCurrentFilter.TabStop = false;
            this._gbCurrentFilter.Text = "Current filter";
            // 
            // _lblCurrentFilter
            // 
            this._lblCurrentFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblCurrentFilter.Location = new System.Drawing.Point(19, 17);
            this._lblCurrentFilter.Name = "_lblCurrentFilter";
            this._lblCurrentFilter.Size = new System.Drawing.Size(752, 45);
            this._lblCurrentFilter.TabIndex = 0;
            // 
            // _cbShowFilterText
            // 
            this._cbShowFilterText.Checked = true;
            this._cbShowFilterText.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbShowFilterText.Location = new System.Drawing.Point(10, 121);
            this._cbShowFilterText.Name = "_cbShowFilterText";
            this._cbShowFilterText.Size = new System.Drawing.Size(124, 17);
            this._cbShowFilterText.TabIndex = 28;
            this._cbShowFilterText.Text = "Show filter text";
            this._cbShowFilterText.CheckedChanged += new System.EventHandler(this.OnShowFilterTextCheckedChanged);
            // 
            // _tbFilterText
            // 
            this._tbFilterText.Location = new System.Drawing.Point(29, 138);
            this._tbFilterText.Name = "_tbFilterText";
            this._tbFilterText.Size = new System.Drawing.Size(86, 21);
            this._tbFilterText.TabIndex = 29;
            this._tbFilterText.Text = "Filter";
            this._tbFilterText.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
            // 
            // _gbRightToLeft
            // 
            this._gbRightToLeft.Controls.Add(this._rbRightToLeftYes);
            this._gbRightToLeft.Controls.Add(this._rbRightToLeftNo);
            this._gbRightToLeft.Location = new System.Drawing.Point(854, 9);
            this._gbRightToLeft.Name = "_gbRightToLeft";
            this._gbRightToLeft.Size = new System.Drawing.Size(96, 60);
            this._gbRightToLeft.TabIndex = 2;
            this._gbRightToLeft.TabStop = false;
            this._gbRightToLeft.Text = "RightToLeft";
            // 
            // _rbRightToLeftYes
            // 
            this._rbRightToLeftYes.Location = new System.Drawing.Point(19, 34);
            this._rbRightToLeftYes.Name = "_rbRightToLeftYes";
            this._rbRightToLeftYes.Size = new System.Drawing.Size(58, 18);
            this._rbRightToLeftYes.TabIndex = 0;
            this._rbRightToLeftYes.Text = "Yes";
            this._rbRightToLeftYes.CheckedChanged += new System.EventHandler(this.OnRightToLeftCheckedChanged);
            // 
            // _rbRightToLeftNo
            // 
            this._rbRightToLeftNo.Checked = true;
            this._rbRightToLeftNo.Location = new System.Drawing.Point(19, 17);
            this._rbRightToLeftNo.Name = "_rbRightToLeftNo";
            this._rbRightToLeftNo.Size = new System.Drawing.Size(58, 17);
            this._rbRightToLeftNo.TabIndex = 0;
            this._rbRightToLeftNo.TabStop = true;
            this._rbRightToLeftNo.Text = "No";
            this._rbRightToLeftNo.CheckedChanged += new System.EventHandler(this.OnRightToLeftCheckedChanged);
            // 
            // _cmbFilterFactories
            // 
            this._cmbFilterFactories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbFilterFactories.Location = new System.Drawing.Point(672, 69);
            this._cmbFilterFactories.Name = "_cmbFilterFactories";
            this._cmbFilterFactories.Size = new System.Drawing.Size(173, 20);
            this._cmbFilterFactories.TabIndex = 1001;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(672, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Select filter factory:";
            // 
            // _pnlDefaultFactoryProperties
            // 
            this._pnlDefaultFactoryProperties.Controls.Add(this._nudDistinctFilterMaximum);
            this._pnlDefaultFactoryProperties.Controls.Add(this._chkCreateDistinctFilters);
            this._pnlDefaultFactoryProperties.Controls.Add(this.label2);
            this._pnlDefaultFactoryProperties.Controls.Add(this._chkHandleEnumTypes);
            this._pnlDefaultFactoryProperties.Location = new System.Drawing.Point(672, 95);
            this._pnlDefaultFactoryProperties.Name = "_pnlDefaultFactoryProperties";
            this._pnlDefaultFactoryProperties.Size = new System.Drawing.Size(182, 77);
            this._pnlDefaultFactoryProperties.TabIndex = 1002;
            // 
            // _nudDistinctFilterMaximum
            // 
            this._nudDistinctFilterMaximum.Location = new System.Drawing.Point(86, 43);
            this._nudDistinctFilterMaximum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudDistinctFilterMaximum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudDistinctFilterMaximum.Name = "_nudDistinctFilterMaximum";
            this._nudDistinctFilterMaximum.Size = new System.Drawing.Size(87, 21);
            this._nudDistinctFilterMaximum.TabIndex = 1;
            this._nudDistinctFilterMaximum.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._nudDistinctFilterMaximum.ValueChanged += new System.EventHandler(this.OnMaximumDistinctValuesChanged);
            // 
            // _chkCreateDistinctFilters
            // 
            this._chkCreateDistinctFilters.Location = new System.Drawing.Point(10, 26);
            this._chkCreateDistinctFilters.Name = "_chkCreateDistinctFilters";
            this._chkCreateDistinctFilters.Size = new System.Drawing.Size(163, 17);
            this._chkCreateDistinctFilters.TabIndex = 0;
            this._chkCreateDistinctFilters.Text = "Distinct filter creation";
            this._chkCreateDistinctFilters.CheckedChanged += new System.EventHandler(this.OnCreateDistinctFiltersCheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max values:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _chkHandleEnumTypes
            // 
            this._chkHandleEnumTypes.Checked = true;
            this._chkHandleEnumTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkHandleEnumTypes.Location = new System.Drawing.Point(10, 9);
            this._chkHandleEnumTypes.Name = "_chkHandleEnumTypes";
            this._chkHandleEnumTypes.Size = new System.Drawing.Size(163, 17);
            this._chkHandleEnumTypes.TabIndex = 0;
            this._chkHandleEnumTypes.Text = "Handle enum types";
            this._chkHandleEnumTypes.CheckedChanged += new System.EventHandler(this.OnHandleEnumTypesCheckedChanged);
            // 
            // _tbSetDefaults
            // 
            this._tbSetDefaults.Location = new System.Drawing.Point(860, 106);
            this._tbSetDefaults.Name = "_tbSetDefaults";
            this._tbSetDefaults.Size = new System.Drawing.Size(90, 21);
            this._tbSetDefaults.TabIndex = 1003;
            this._tbSetDefaults.Text = "*";
            // 
            // _btnSetDefaults
            // 
            this._btnSetDefaults.Location = new System.Drawing.Point(860, 79);
            this._btnSetDefaults.Name = "_btnSetDefaults";
            this._btnSetDefaults.Size = new System.Drawing.Size(90, 24);
            this._btnSetDefaults.TabIndex = 1004;
            this._btnSetDefaults.Text = "SetDefaults";
            this._btnSetDefaults.UseVisualStyleBackColor = true;
            this._btnSetDefaults.Click += new System.EventHandler(this.OnSetDefaultsClick);
            // 
            // _chkShowInBetweenOperator
            // 
            this._chkShowInBetweenOperator.Location = new System.Drawing.Point(860, 155);
            this._chkShowInBetweenOperator.Name = "_chkShowInBetweenOperator";
            this._chkShowInBetweenOperator.Size = new System.Drawing.Size(96, 17);
            this._chkShowInBetweenOperator.TabIndex = 21;
            this._chkShowInBetweenOperator.Text = "In between";
            this._chkShowInBetweenOperator.CheckedChanged += new System.EventHandler(this.OnShowInBetweenOperatorCheckedChanged);
            // 
            // _chkBaseFiltersEnabled
            // 
            this._chkBaseFiltersEnabled.Checked = true;
            this._chkBaseFiltersEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkBaseFiltersEnabled.Location = new System.Drawing.Point(14, 177);
            this._chkBaseFiltersEnabled.Name = "_chkBaseFiltersEnabled";
            this._chkBaseFiltersEnabled.Size = new System.Drawing.Size(125, 17);
            this._chkBaseFiltersEnabled.TabIndex = 28;
            this._chkBaseFiltersEnabled.Text = "Base filters";
            this._chkBaseFiltersEnabled.CheckedChanged += new System.EventHandler(this.OnBaseFiltersEnabledCheckedChanged);
            // 
            // _tbCurrentBaseFilter
            // 
            this._tbCurrentBaseFilter.Location = new System.Drawing.Point(108, 174);
            this._tbCurrentBaseFilter.Name = "_tbCurrentBaseFilter";
            this._tbCurrentBaseFilter.Size = new System.Drawing.Size(218, 21);
            this._tbCurrentBaseFilter.TabIndex = 29;
            this._tbCurrentBaseFilter.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
            // 
            // _btnApplyCurrentBaseFilter
            // 
            this._btnApplyCurrentBaseFilter.Location = new System.Drawing.Point(334, 172);
            this._btnApplyCurrentBaseFilter.Name = "_btnApplyCurrentBaseFilter";
            this._btnApplyCurrentBaseFilter.Size = new System.Drawing.Size(37, 25);
            this._btnApplyCurrentBaseFilter.TabIndex = 3;
            this._btnApplyCurrentBaseFilter.Text = "OK";
            this._btnApplyCurrentBaseFilter.Click += new System.EventHandler(this.OnApplyCurrentBaseFilterClick);
            // 
            // _cmbRefreshMode
            // 
            this._cmbRefreshMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbRefreshMode.FormattingEnabled = true;
            this._cmbRefreshMode.Location = new System.Drawing.Point(132, 74);
            this._cmbRefreshMode.Name = "_cmbRefreshMode";
            this._cmbRefreshMode.Size = new System.Drawing.Size(192, 20);
            this._cmbRefreshMode.TabIndex = 1005;
            this._cmbRefreshMode.SelectedIndexChanged += new System.EventHandler(this.OnSelectedAutoRefreshModeChanged);
            // 
            // _lblRefreshMode
            // 
            this._lblRefreshMode.Location = new System.Drawing.Point(132, 58);
            this._lblRefreshMode.Name = "_lblRefreshMode";
            this._lblRefreshMode.Size = new System.Drawing.Size(118, 16);
            this._lblRefreshMode.TabIndex = 26;
            this._lblRefreshMode.Text = "AutoRefreshMode:";
            // 
            // FilterableGridSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this._cmbRefreshMode);
            this.Controls.Add(this._btnSetDefaults);
            this.Controls.Add(this._tbSetDefaults);
            this.Controls.Add(this._pnlDefaultFactoryProperties);
            this.Controls.Add(this._cmbFilterFactories);
            this.Controls.Add(this._tbCurrentBaseFilter);
            this.Controls.Add(this._tbFilterText);
            this.Controls.Add(this._chkBaseFiltersEnabled);
            this.Controls.Add(this._cbShowFilterText);
            this.Controls.Add(this._gbCurrentFilter);
            this.Controls.Add(this._lblRefreshMode);
            this.Controls.Add(this._lblSelectTable);
            this.Controls.Add(this._cmbTables);
            this.Controls.Add(this._lbSavedFilters);
            this.Controls.Add(this._btnLoadFilters);
            this.Controls.Add(this._btnSaveFilters);
            this.Controls.Add(this._chkShowInBetweenOperator);
            this.Controls.Add(this._cbKeepFilters);
            this.Controls.Add(this._btnApplyCurrentBaseFilter);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._gbOperator);
            this.Controls.Add(this._gbFilterPosition);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._btnRefresh);
            this.Controls.Add(this._gbRightToLeft);
            this.Controls.Add(this.label1);
            this.Name = "FilterableGridSample";
            this.Text = "Sample 1 - FilterableGrid functionalities";
            this._gbFilterPosition.ResumeLayout(false);
            this._gbOperator.ResumeLayout(false);
            this._gbCurrentFilter.ResumeLayout(false);
            this._gbRightToLeft.ResumeLayout(false);
            this._pnlDefaultFactoryProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._nudDistinctFilterMaximum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void OnFilterPositionCheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton != null)
				_grid.FilterBoxPosition = (FilterPosition)Enum.Parse(typeof(FilterPosition), radioButton.Text, true);
		}

		private void OnSelectedTableChanged(object sender, System.EventArgs e)
		{
			_grid.DataSource = DataHelper.SampleData.Tables[_cmbTables.SelectedItem.ToString()].DefaultView;
		}

		private void OnOperatorCheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			if (radioButton != null)
				_grid.Operator = (LogicalOperators)Enum.Parse(typeof(LogicalOperators), radioButton.Text, true);
		}

		private void OnClearClick(object sender, System.EventArgs e)
		{
			_grid.ClearFilters();
		}

		private void OnRefreshClick(object sender, System.EventArgs e)
		{
			_grid.RefreshFilters();
		}

		private void OnKeepFiltersCheckedChanged(object sender, System.EventArgs e)
		{
			_grid.KeepFilters = _cbKeepFilters.Checked;
		}

		private void OnSaveFiltersClick(object sender, System.EventArgs e)
		{
			_savedFilters = _grid.GetFilters();
			_lbSavedFilters.Items.Clear();
			_btnLoadFilters.Enabled = _savedFilters != null && _savedFilters.Length > 0;
			if (_btnLoadFilters.Enabled)
			{
				for (int i = 0; i < _savedFilters.Length; i++)
				{
					string s = _savedFilters[i];
					if (s == null || s.Length == 0)
						_lbSavedFilters.Items.Add(i + ": {Empty}");
					else
						_lbSavedFilters.Items.Add(i + ": " + s);
				}
			}
		}

		private void OnLoadFiltersClick(object sender, System.EventArgs e)
		{
			_grid.SetFilters(_savedFilters);
		}

		private void OnShowFilterTextCheckedChanged(object sender, System.EventArgs e)
		{
			_grid.FilterTextVisible = _cbShowFilterText.Checked;
			_tbFilterText.Enabled = _grid.FilterTextVisible;
		}

		private void OnFilterTextChanged(object sender, System.EventArgs e)
		{
			_grid.FilterText = _tbFilterText.Text;
		}

		private void OnRightToLeftCheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                _grid.RightToLeft = (RightToLeft)Enum.Parse(typeof(RightToLeft), radioButton.Text, true);
            }
		}

		private void OnFilterFactoriesSelectedIndexChanged(object sender, EventArgs e)
		{
			_grid.FilterFactory = (IGridFilterFactory)_cmbFilterFactories.SelectedItem;
			_pnlDefaultFactoryProperties.Enabled = _grid.FilterFactory is DefaultGridFilterFactory;
		}

		private void OnCreateDistinctFiltersCheckedChanged(object sender, System.EventArgs e)
		{
			(_grid.FilterFactory as DefaultGridFilterFactory).CreateDistinctGridFilters = _chkCreateDistinctFilters.Checked;
		}

		private void OnMaximumDistinctValuesChanged(object sender, System.EventArgs e)
		{
			(_grid.FilterFactory as DefaultGridFilterFactory).MaximumDistinctValues = Convert.ToInt32(_nudDistinctFilterMaximum.Value);
		}

		private void OnHandleEnumTypesCheckedChanged(object sender, System.EventArgs e)
		{
			(_grid.FilterFactory as DefaultGridFilterFactory).HandleEnumerationTypes = _chkHandleEnumTypes.Checked;
        }

        private void OnSetDefaultsClick(object sender, System.EventArgs e)
        {
            RefreshMode oldRefreshMode = _grid.AutoRefreshMode;
            _grid.AutoRefreshMode = RefreshMode.Off; //speeds up because filtering isn't reapplied for every change
            foreach (TextGridFilter tgf in _grid.GetGridFilters().FilterByGridFilterType(typeof(TextGridFilter), false))
                tgf.Text = _tbSetDefaults.Text;
            _grid.AutoRefreshMode = oldRefreshMode;
        }

        private void OnShowInBetweenOperatorCheckedChanged(object sender, EventArgs e)
        {
            (_grid.FilterFactory as DefaultGridFilterFactory).DefaultShowDateInBetweenOperator = true;
            (_grid.FilterFactory as DefaultGridFilterFactory).DefaultShowNumericInBetweenOperator = true;
        }

        private void OnApplyCurrentBaseFilterClick(object sender, EventArgs e)
        {
            _grid.CurrentTableBaseFilter = _tbCurrentBaseFilter.Text;
            _tbCurrentBaseFilter.Text = "";
        }

        private void OnBaseFiltersEnabledCheckedChanged(object sender, EventArgs e)
        {
            _grid.BaseFilterEnabled = _chkBaseFiltersEnabled.Checked;
        }

        private void OnSelectedAutoRefreshModeChanged(object sender, EventArgs e)
        {
            _grid.AutoRefreshMode = (RefreshMode)_cmbRefreshMode.SelectedItem;
        }

        private void OnAfterFiltersChanged(object sender, System.EventArgs e)
        {
            _gbCurrentFilter.Text = "Current Filter - " + (_grid.DataSource == null ? " No " : _grid.DataSource.Count.ToString()) + " rows";
            _lblCurrentFilter.Text = _grid.DataSource == null ? "" : _grid.DataSource.Filter;

            System.Diagnostics.Debug.WriteLine("OnAfterFiltersChanged");
        }

        private void OnBeforeFiltersChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnBeforeFiltersChanged");
        }

        private void OnGridFilterBound(object sender, GridFilterEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("OnGridFilterBound: " + args.ColumnName + " | " + args.GridFilter.GetType().Name);
        }

        private void OnGridFilterUnbound(object sender, GridFilterEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("OnGridFilterUnbound: " + args.ColumnName + " | " + args.GridFilter.GetType().Name);
        }

        private void OnGridKeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridKeyDown");
        }

        private void OnGridKeyPress(object sender, KeyPressEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridKeyPress");
        }

        private void OnGridKeyUp(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridKeyUp");
        }

        private void OnGridPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridPreviewKeyDown");
        }

        private void OnGridMouseDown(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridMouseDown");
        }

        private void OnGridMouseEnter(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridMouseEnter");
        }

        private void OnGridMouseHover(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridMouseHover");
        }

        private void OnGridMouseLeave(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridMouseLeave");
        }

        private void OnGridMouseUp(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnGridMouseUp");
        }
	}
}
