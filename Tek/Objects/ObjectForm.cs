using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for ObjectForm.
	/// </summary>
	public class ObjectForm : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.Label ScanrangeLabel;
		protected System.Windows.Forms.TextBox ScanRangeTextBox;
		protected System.Windows.Forms.TextBox SigTextBox;
		protected System.Windows.Forms.Label SigLabel;
		protected System.Windows.Forms.Panel SensorsPanel;
		protected System.Windows.Forms.Label SensorsLabel;
		protected System.Windows.Forms.ToolTip InfoToolTip;
		private System.ComponentModel.IContainer components;

		protected AllegObject	_object;
		protected TekSettings	_settings;

		public ObjectForm () {InitializeComponent();}

		public ObjectForm (TekSettings settings, AllegObject obj) : this()
		{
			_settings = settings;
			_object = obj;
			this.ForeColor = obj.Team.TeamColor;

			this.Text = string.Concat(obj.Team.Faction.Name, ": ", obj.Name);
			InfoToolTip.Active = settings.ShowToolTips;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose (bool disposing)
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.SensorsPanel = new System.Windows.Forms.Panel();
			this.SensorsLabel = new System.Windows.Forms.Label();
			this.ScanrangeLabel = new System.Windows.Forms.Label();
			this.ScanRangeTextBox = new System.Windows.Forms.TextBox();
			this.SigTextBox = new System.Windows.Forms.TextBox();
			this.SigLabel = new System.Windows.Forms.Label();
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SensorsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SensorsPanel
			// 
			this.SensorsPanel.Controls.Add(this.SensorsLabel);
			this.SensorsPanel.Controls.Add(this.ScanrangeLabel);
			this.SensorsPanel.Controls.Add(this.ScanRangeTextBox);
			this.SensorsPanel.Controls.Add(this.SigTextBox);
			this.SensorsPanel.Controls.Add(this.SigLabel);
			this.SensorsPanel.Location = new System.Drawing.Point(0, 0);
			this.SensorsPanel.Name = "SensorsPanel";
			this.SensorsPanel.Size = new System.Drawing.Size(184, 64);
			this.SensorsPanel.TabIndex = 14;
			// 
			// SensorsLabel
			// 
			this.SensorsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.SensorsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SensorsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.SensorsLabel.Location = new System.Drawing.Point(0, 5);
			this.SensorsLabel.Name = "SensorsLabel";
			this.SensorsLabel.Size = new System.Drawing.Size(184, 16);
			this.SensorsLabel.TabIndex = 14;
			this.SensorsLabel.Text = "Sensors";
			// 
			// ScanrangeLabel
			// 
			this.ScanrangeLabel.BackColor = System.Drawing.Color.Black;
			this.ScanrangeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ScanrangeLabel.Location = new System.Drawing.Point(8, 24);
			this.ScanrangeLabel.Name = "ScanrangeLabel";
			this.ScanrangeLabel.Size = new System.Drawing.Size(104, 15);
			this.ScanrangeLabel.TabIndex = 13;
			this.ScanrangeLabel.Text = "Scan Range (m):";
			this.InfoToolTip.SetToolTip(this.ScanrangeLabel, "This object\'s detection range");
			// 
			// ScanRangeTextBox
			// 
			this.ScanRangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ScanRangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ScanRangeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ScanRangeTextBox.ForeColor = System.Drawing.Color.White;
			this.ScanRangeTextBox.Location = new System.Drawing.Point(136, 24);
			this.ScanRangeTextBox.Name = "ScanRangeTextBox";
			this.ScanRangeTextBox.ReadOnly = true;
			this.ScanRangeTextBox.Size = new System.Drawing.Size(40, 14);
			this.ScanRangeTextBox.TabIndex = 17;
			this.ScanRangeTextBox.Text = "0";
			this.ScanRangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ScanRangeTextBox, "This object\'s detection range");
			// 
			// SigTextBox
			// 
			this.SigTextBox.BackColor = System.Drawing.Color.Maroon;
			this.SigTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SigTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SigTextBox.ForeColor = System.Drawing.Color.White;
			this.SigTextBox.Location = new System.Drawing.Point(136, 40);
			this.SigTextBox.Name = "SigTextBox";
			this.SigTextBox.ReadOnly = true;
			this.SigTextBox.Size = new System.Drawing.Size(40, 14);
			this.SigTextBox.TabIndex = 18;
			this.SigTextBox.Text = "0";
			this.SigTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.SigTextBox, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// SigLabel
			// 
			this.SigLabel.BackColor = System.Drawing.Color.Black;
			this.SigLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SigLabel.Location = new System.Drawing.Point(8, 40);
			this.SigLabel.Name = "SigLabel";
			this.SigLabel.Size = new System.Drawing.Size(96, 16);
			this.SigLabel.TabIndex = 15;
			this.SigLabel.Text = "Signature (%):";
			this.InfoToolTip.SetToolTip(this.SigLabel, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// ObjectForm
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(218, 95);
			this.Controls.Add(this.SensorsPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ObjectForm";
			this.Text = "Faction: ObjectName";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ObjectForm_Closing);
			this.SensorsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected void EnableFeature (Label label)
		{
			label.ForeColor = this.ForeColor;
			label.Font = new Font("Tahoma", 8.25F);
		}

		private void ObjectForm_Closing (object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Dispose();
		}

		public AllegObject Object
		{
			get {return _object;}
			set {_object = value;}
		}
	}
}
