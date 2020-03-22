using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using GridViewExtensions;
using GridViewExtensions.GridFilterFactories;
using System.Collections.Generic;

namespace FilterableTestApp
{
    public class FullTextSearchSample : System.Windows.Forms.Form
    {
        public class MyEmply
        {
            public string MyName { get; set; }
            public int MyAge { get; set; }

            public string MyClassName { get; set; }
        }

        private GridViewExtensions.GridFilterFactories.FullTextSearchGridFilterFactoryTextBox _tbFilterFactory;
        private System.Windows.Forms.Label _lblFilterText;
        private GridViewExtensions.FilterableDataGrid _grid3;
        private System.Windows.Forms.CheckBox _cbGrid3;
        private TableLayoutPanel _tableLayoutPanel;
        private Panel _panel3;
        private Panel _panel1;
        private FilterableDataGrid _grid1;
        private CheckBox _cbGrid1;
        private Panel _panel2;
        private FilterableDataGrid _grid2;
        private CheckBox _cbGrid2;
        private Panel _panel4;
        private FilterableDataGrid _grid4;
        private CheckBox _cbGrid4;
        private System.ComponentModel.Container components = null;

        public FullTextSearchSample()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _cbGrid1.Tag = _grid1;
            _cbGrid2.Tag = _grid2;
            _cbGrid3.Tag = _grid3;
            _cbGrid4.Tag = _grid4;

            _grid1.EmbeddedDataGridView.ReadOnly = true;
            _grid2.EmbeddedDataGridView.ReadOnly = true;
            _grid3.EmbeddedDataGridView.ReadOnly = true;
            _grid4.EmbeddedDataGridView.ReadOnly = true;

            var s = new BindingList<MyEmply>();
            s.Add(new MyEmply { MyAge = 1, MyClassName = "aaa", MyName = "bb" });
            s.Add(new MyEmply { MyAge = 2, MyClassName = "aewea", MyName = "bb" });
            s.Add(new MyEmply { MyAge = 3, MyClassName = "ee", MyName = "bb" });
            //_grid1.DataSource = s;

            //_grid1.DataSource = DataHelper.SampleData.Tables[1].DefaultView;
            //_grid2.DataSource = DataHelper.SampleData.Tables[2].DefaultView;
            //_grid3.DataSource = DataHelper.SampleData.Tables[3].DefaultView;
            //_grid4.DataSource = DataHelper.SampleData.Tables[4].DefaultView;

            OnEnabledFullTextSearchCheckedChanged(_cbGrid1, EventArgs.Empty);
            OnEnabledFullTextSearchCheckedChanged(_cbGrid2, EventArgs.Empty);
            OnEnabledFullTextSearchCheckedChanged(_cbGrid3, EventArgs.Empty);
            OnEnabledFullTextSearchCheckedChanged(_cbGrid4, EventArgs.Empty);
        }

        /// <summary>
        /// Die verwendeten Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory2 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory3 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory4 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this._lblFilterText = new System.Windows.Forms.Label();
            this._cbGrid3 = new System.Windows.Forms.CheckBox();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._panel3 = new System.Windows.Forms.Panel();
            this._grid3 = new GridViewExtensions.FilterableDataGrid();
            this._panel1 = new System.Windows.Forms.Panel();
            this._grid1 = new GridViewExtensions.FilterableDataGrid();
            this._cbGrid1 = new System.Windows.Forms.CheckBox();
            this._panel2 = new System.Windows.Forms.Panel();
            this._grid2 = new GridViewExtensions.FilterableDataGrid();
            this._cbGrid2 = new System.Windows.Forms.CheckBox();
            this._panel4 = new System.Windows.Forms.Panel();
            this._grid4 = new GridViewExtensions.FilterableDataGrid();
            this._cbGrid4 = new System.Windows.Forms.CheckBox();
            this._tbFilterFactory = new GridViewExtensions.GridFilterFactories.FullTextSearchGridFilterFactoryTextBox();
            this._tableLayoutPanel.SuspendLayout();
            this._panel3.SuspendLayout();
            this._panel1.SuspendLayout();
            this._panel2.SuspendLayout();
            this._panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lblFilterText
            // 
            this._lblFilterText.Location = new System.Drawing.Point(10, 9);
            this._lblFilterText.Name = "_lblFilterText";
            this._lblFilterText.Size = new System.Drawing.Size(67, 25);
            this._lblFilterText.TabIndex = 2;
            this._lblFilterText.Text = "Filter text:";
            this._lblFilterText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cbGrid3
            // 
            this._cbGrid3.BackColor = System.Drawing.SystemColors.Control;
            this._cbGrid3.Checked = true;
            this._cbGrid3.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbGrid3.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbGrid3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cbGrid3.Location = new System.Drawing.Point(0, 0);
            this._cbGrid3.Name = "_cbGrid3";
            this._cbGrid3.Size = new System.Drawing.Size(381, 17);
            this._cbGrid3.TabIndex = 1;
            this._cbGrid3.Text = "Enable full text search";
            this._cbGrid3.UseVisualStyleBackColor = false;
            this._cbGrid3.CheckedChanged += new System.EventHandler(this.OnEnabledFullTextSearchCheckedChanged);
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Controls.Add(this._panel3, 0, 1);
            this._tableLayoutPanel.Controls.Add(this._panel1, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._panel2, 1, 0);
            this._tableLayoutPanel.Controls.Add(this._panel4, 1, 1);
            this._tableLayoutPanel.Location = new System.Drawing.Point(13, 38);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(774, 632);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // _panel3
            // 
            this._panel3.Controls.Add(this._grid3);
            this._panel3.Controls.Add(this._cbGrid3);
            this._panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel3.Location = new System.Drawing.Point(3, 319);
            this._panel3.Name = "_panel3";
            this._panel3.Size = new System.Drawing.Size(381, 310);
            this._panel3.TabIndex = 5;
            // 
            // _grid3
            // 
            this._grid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid3.FilterBoxPosition = GridViewExtensions.FilterPosition.Off;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this._grid3.FilterFactory = defaultGridFilterFactory1;
            this._grid3.FilterTextVisible = false;
            this._grid3.Location = new System.Drawing.Point(0, 17);
            this._grid3.Name = "_grid3";
            this._grid3.Operator = GridViewExtensions.LogicalOperators.Or;
            this._grid3.Size = new System.Drawing.Size(381, 293);
            this._grid3.TabIndex = 0;
            // 
            // _panel1
            // 
            this._panel1.Controls.Add(this._grid1);
            this._panel1.Controls.Add(this._cbGrid1);
            this._panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel1.Location = new System.Drawing.Point(3, 3);
            this._panel1.Name = "_panel1";
            this._panel1.Size = new System.Drawing.Size(381, 310);
            this._panel1.TabIndex = 5;
            // 
            // _grid1
            // 
            this._grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid1.FilterBoxPosition = GridViewExtensions.FilterPosition.Off;
            defaultGridFilterFactory2.CreateDistinctGridFilters = false;
            defaultGridFilterFactory2.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory2.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory2.HandleEnumerationTypes = true;
            defaultGridFilterFactory2.MaximumDistinctValues = 20;
            this._grid1.FilterFactory = defaultGridFilterFactory2;
            this._grid1.FilterTextVisible = false;
            this._grid1.Location = new System.Drawing.Point(0, 17);
            this._grid1.Name = "_grid1";
            this._grid1.Operator = GridViewExtensions.LogicalOperators.Or;
            this._grid1.Size = new System.Drawing.Size(381, 293);
            this._grid1.TabIndex = 0;
            // 
            // _cbGrid1
            // 
            this._cbGrid1.BackColor = System.Drawing.SystemColors.Control;
            this._cbGrid1.Checked = true;
            this._cbGrid1.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbGrid1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cbGrid1.Location = new System.Drawing.Point(0, 0);
            this._cbGrid1.Name = "_cbGrid1";
            this._cbGrid1.Size = new System.Drawing.Size(381, 17);
            this._cbGrid1.TabIndex = 1;
            this._cbGrid1.Text = "Enable full text search";
            this._cbGrid1.UseVisualStyleBackColor = false;
            this._cbGrid1.CheckedChanged += new System.EventHandler(this.OnEnabledFullTextSearchCheckedChanged);
            // 
            // _panel2
            // 
            this._panel2.Controls.Add(this._grid2);
            this._panel2.Controls.Add(this._cbGrid2);
            this._panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel2.Location = new System.Drawing.Point(390, 3);
            this._panel2.Name = "_panel2";
            this._panel2.Size = new System.Drawing.Size(381, 310);
            this._panel2.TabIndex = 5;
            // 
            // _grid2
            // 
            this._grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid2.FilterBoxPosition = GridViewExtensions.FilterPosition.Off;
            defaultGridFilterFactory3.CreateDistinctGridFilters = false;
            defaultGridFilterFactory3.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory3.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory3.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory3.HandleEnumerationTypes = true;
            defaultGridFilterFactory3.MaximumDistinctValues = 20;
            this._grid2.FilterFactory = defaultGridFilterFactory3;
            this._grid2.FilterTextVisible = false;
            this._grid2.Location = new System.Drawing.Point(0, 17);
            this._grid2.Name = "_grid2";
            this._grid2.Operator = GridViewExtensions.LogicalOperators.Or;
            this._grid2.Size = new System.Drawing.Size(381, 293);
            this._grid2.TabIndex = 0;
            // 
            // _cbGrid2
            // 
            this._cbGrid2.BackColor = System.Drawing.SystemColors.Control;
            this._cbGrid2.Checked = true;
            this._cbGrid2.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbGrid2.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbGrid2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cbGrid2.Location = new System.Drawing.Point(0, 0);
            this._cbGrid2.Name = "_cbGrid2";
            this._cbGrid2.Size = new System.Drawing.Size(381, 17);
            this._cbGrid2.TabIndex = 1;
            this._cbGrid2.Text = "Enable full text search";
            this._cbGrid2.UseVisualStyleBackColor = false;
            this._cbGrid2.CheckedChanged += new System.EventHandler(this.OnEnabledFullTextSearchCheckedChanged);
            // 
            // _panel4
            // 
            this._panel4.Controls.Add(this._grid4);
            this._panel4.Controls.Add(this._cbGrid4);
            this._panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel4.Location = new System.Drawing.Point(390, 319);
            this._panel4.Name = "_panel4";
            this._panel4.Size = new System.Drawing.Size(381, 310);
            this._panel4.TabIndex = 5;
            // 
            // _grid4
            // 
            this._grid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid4.FilterBoxPosition = GridViewExtensions.FilterPosition.Off;
            defaultGridFilterFactory4.CreateDistinctGridFilters = false;
            defaultGridFilterFactory4.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory4.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory4.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory4.HandleEnumerationTypes = true;
            defaultGridFilterFactory4.MaximumDistinctValues = 20;
            this._grid4.FilterFactory = defaultGridFilterFactory4;
            this._grid4.FilterTextVisible = false;
            this._grid4.Location = new System.Drawing.Point(0, 17);
            this._grid4.Name = "_grid4";
            this._grid4.Operator = GridViewExtensions.LogicalOperators.Or;
            this._grid4.Size = new System.Drawing.Size(381, 293);
            this._grid4.TabIndex = 0;
            // 
            // _cbGrid4
            // 
            this._cbGrid4.BackColor = System.Drawing.SystemColors.Control;
            this._cbGrid4.Checked = true;
            this._cbGrid4.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbGrid4.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbGrid4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cbGrid4.Location = new System.Drawing.Point(0, 0);
            this._cbGrid4.Name = "_cbGrid4";
            this._cbGrid4.Size = new System.Drawing.Size(381, 17);
            this._cbGrid4.TabIndex = 1;
            this._cbGrid4.Text = "Enable full text search";
            this._cbGrid4.UseVisualStyleBackColor = false;
            this._cbGrid4.CheckedChanged += new System.EventHandler(this.OnEnabledFullTextSearchCheckedChanged);
            // 
            // _tbFilterFactory
            // 
            this._tbFilterFactory.Location = new System.Drawing.Point(86, 9);
            this._tbFilterFactory.Name = "_tbFilterFactory";
            this._tbFilterFactory.Size = new System.Drawing.Size(221, 21);
            this._tbFilterFactory.TabIndex = 1;
            this._tbFilterFactory.Text = "*";
            // 
            // FullTextSearchSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(801, 682);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._lblFilterText);
            this.Controls.Add(this._tbFilterFactory);
            this.Name = "FullTextSearchSample";
            this.Text = "Sample 3 - Full text search in one or many grids";
            this._tableLayoutPanel.ResumeLayout(false);
            this._panel3.ResumeLayout(false);
            this._panel1.ResumeLayout(false);
            this._panel2.ResumeLayout(false);
            this._panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void OnEnabledFullTextSearchCheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
                return;
            FilterableDataGrid grid = checkBox.Tag as FilterableDataGrid;
            if (grid == null)
                return;
            if (checkBox.Checked)
            {
                grid.FilterFactory = _tbFilterFactory;
                grid.FilterBoxPosition = FilterPosition.Off;
            }
            else
            {
                grid.FilterFactory = new DefaultGridFilterFactory();
                grid.FilterBoxPosition = FilterPosition.Top;
            }
        }
    }
}
