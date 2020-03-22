using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FilterableTestApp
{
	public class ExtenderSample : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGridView _grid;
		private GridViewExtensions.DataGridFilterExtender _extender;
        private System.ComponentModel.IContainer components;
        private BindingSource _source;

		public ExtenderSample()
		{
			InitializeComponent();
            _source = new BindingSource();
            (_extender.FilterFactory as GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory).CreateDistinctGridFilters = true;
            _grid.DataSource = _source;
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //_source.DataSource = DataHelper.SampleData.Tables[1].DefaultView;
            //_source.DataSource = DataHelper.SampleData.Tables[1];
            _source.DataSource = DataHelper.SampleData;
            _source.DataMember = "Orders";
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
            this.components = new System.ComponentModel.Container();
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this._grid = new System.Windows.Forms.DataGridView();
            this._extender = new GridViewExtensions.DataGridFilterExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._extender)).BeginInit();
            this.SuspendLayout();
            // 
            // _grid
            // 
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.Location = new System.Drawing.Point(10, 28);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(580, 308);
            this._grid.TabIndex = 0;
            // 
            // _extender
            // 
            this._extender.DataGridView = this._grid;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this._extender.FilterFactory = defaultGridFilterFactory1;
            // 
            // ExtenderSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(600, 341);
            this.Controls.Add(this._grid);
            this.Name = "ExtenderSample";
            this.Text = "Sample 2 - Filtering an ExtendedDataGrid with the DataGridFilterExtender ";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._extender)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	}
}
