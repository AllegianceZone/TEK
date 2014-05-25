using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	public class StationForm : ObjectForm
	{
		#region Form Controls
		private System.Windows.Forms.Label HullACLabel;
		private System.Windows.Forms.Label HullRepairRateLabel;
		private System.Windows.Forms.Label ShieldACLabel;
		private System.Windows.Forms.Label ShieldRepairRateLabel;
		private System.Windows.Forms.TextBox IncomeTextBox;
		private System.Windows.Forms.TextBox HullRepairRateTextBox;
		private System.Windows.Forms.TextBox HullACTextBox;
		private System.Windows.Forms.TextBox ShieldACTextBox;
		private System.Windows.Forms.TextBox ShieldRepairRateTextBox;
		private System.Windows.Forms.Panel HullPanel;
		private System.Windows.Forms.Label HullHeaderLabel;
		private System.Windows.Forms.Label ShieldHitpointsLabel;
		private System.Windows.Forms.Label HullHitpointsLabel;
		private System.Windows.Forms.TextBox HullHitpointsTextBox;
		private System.Windows.Forms.Panel ShieldPanel;
		private System.Windows.Forms.Panel StationPanel;
		private System.Windows.Forms.Label StationLabel;
		private System.Windows.Forms.TextBox ClassTextBox;
		private System.Windows.Forms.Label ClassLabel;
		private System.Windows.Forms.Panel AbilitiesPanel;
		private System.Windows.Forms.Label AbilitiesLabel;
		private System.Windows.Forms.Label DockableLabel;
		private System.Windows.Forms.Label CapturableLabel;
		private System.Windows.Forms.Label StartingBaseLabel;
		private System.Windows.Forms.Label MinerTeleOffloadLabel;
		private System.Windows.Forms.Label MinersOffloadLabel;
		private System.Windows.Forms.Label LeadIndicatorLabel;
		private System.Windows.Forms.Label RepairableLabel;
		private System.Windows.Forms.Label CountsForVictoryLabel;
		private System.Windows.Forms.Label CapitalDockableLabel;
		private System.Windows.Forms.Label FlagPedestalLabel;
		private System.Windows.Forms.Label RipcordLabel;
		private System.Windows.Forms.TextBox ShieldHitpointsTextBox;
		private System.Windows.Forms.Label ShieldLabel;
		private System.Windows.Forms.Label IncomeLabel;
		private System.Windows.Forms.Label RestartingBaseLabel;
		private System.Windows.Forms.Label RescuesAllPodsLabel;
		private System.Windows.Forms.Label RescuesTeamsPodsLabel;
		private System.Windows.Forms.Label ReloadShipsLabel;
		private System.ComponentModel.IContainer components = null;
		#endregion

		Station _station = null;

		public StationForm (TekSettings settings, Station station) : base(settings, station)
		{
			InitializeComponent();
			
			_station = station;
			station.Updated += new EventHandler(UpdateHandler);
			station.Closed += new EventHandler(ClosedHandler);

			_station.Update();
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StationForm));
			this.HullACLabel = new System.Windows.Forms.Label();
			this.HullRepairRateLabel = new System.Windows.Forms.Label();
			this.ShieldHitpointsLabel = new System.Windows.Forms.Label();
			this.ShieldACLabel = new System.Windows.Forms.Label();
			this.ShieldRepairRateLabel = new System.Windows.Forms.Label();
			this.IncomeLabel = new System.Windows.Forms.Label();
			this.IncomeTextBox = new System.Windows.Forms.TextBox();
			this.HullRepairRateTextBox = new System.Windows.Forms.TextBox();
			this.ShieldHitpointsTextBox = new System.Windows.Forms.TextBox();
			this.HullACTextBox = new System.Windows.Forms.TextBox();
			this.ShieldACTextBox = new System.Windows.Forms.TextBox();
			this.ShieldRepairRateTextBox = new System.Windows.Forms.TextBox();
			this.HullPanel = new System.Windows.Forms.Panel();
			this.HullHitpointsLabel = new System.Windows.Forms.Label();
			this.HullHitpointsTextBox = new System.Windows.Forms.TextBox();
			this.HullHeaderLabel = new System.Windows.Forms.Label();
			this.ShieldPanel = new System.Windows.Forms.Panel();
			this.ShieldLabel = new System.Windows.Forms.Label();
			this.StationPanel = new System.Windows.Forms.Panel();
			this.ClassTextBox = new System.Windows.Forms.TextBox();
			this.ClassLabel = new System.Windows.Forms.Label();
			this.StationLabel = new System.Windows.Forms.Label();
			this.AbilitiesPanel = new System.Windows.Forms.Panel();
			this.RescuesAllPodsLabel = new System.Windows.Forms.Label();
			this.RipcordLabel = new System.Windows.Forms.Label();
			this.RescuesTeamsPodsLabel = new System.Windows.Forms.Label();
			this.FlagPedestalLabel = new System.Windows.Forms.Label();
			this.CapitalDockableLabel = new System.Windows.Forms.Label();
			this.DockableLabel = new System.Windows.Forms.Label();
			this.CapturableLabel = new System.Windows.Forms.Label();
			this.ReloadShipsLabel = new System.Windows.Forms.Label();
			this.LeadIndicatorLabel = new System.Windows.Forms.Label();
			this.RepairableLabel = new System.Windows.Forms.Label();
			this.RestartingBaseLabel = new System.Windows.Forms.Label();
			this.StartingBaseLabel = new System.Windows.Forms.Label();
			this.CountsForVictoryLabel = new System.Windows.Forms.Label();
			this.MinerTeleOffloadLabel = new System.Windows.Forms.Label();
			this.MinersOffloadLabel = new System.Windows.Forms.Label();
			this.AbilitiesLabel = new System.Windows.Forms.Label();
			this.SensorsPanel.SuspendLayout();
			this.HullPanel.SuspendLayout();
			this.ShieldPanel.SuspendLayout();
			this.StationPanel.SuspendLayout();
			this.AbilitiesPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ScanrangeLabel
			// 
			this.ScanrangeLabel.Name = "ScanrangeLabel";
			this.InfoToolTip.SetToolTip(this.ScanrangeLabel, "This object\'s detection range");
			// 
			// ScanRangeTextBox
			// 
			this.ScanRangeTextBox.Location = new System.Drawing.Point(128, 24);
			this.ScanRangeTextBox.Name = "ScanRangeTextBox";
			this.InfoToolTip.SetToolTip(this.ScanRangeTextBox, "This object\'s detection range");
			// 
			// SigTextBox
			// 
			this.SigTextBox.Location = new System.Drawing.Point(128, 40);
			this.SigTextBox.Name = "SigTextBox";
			this.InfoToolTip.SetToolTip(this.SigTextBox, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// SigLabel
			// 
			this.SigLabel.Name = "SigLabel";
			this.InfoToolTip.SetToolTip(this.SigLabel, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// SensorsPanel
			// 
			this.SensorsPanel.Name = "SensorsPanel";
			this.SensorsPanel.Size = new System.Drawing.Size(180, 64);
			// 
			// SensorsLabel
			// 
			this.SensorsLabel.Name = "SensorsLabel";
			// 
			// HullACLabel
			// 
			this.HullACLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullACLabel.Location = new System.Drawing.Point(8, 56);
			this.HullACLabel.Name = "HullACLabel";
			this.HullACLabel.Size = new System.Drawing.Size(24, 16);
			this.HullACLabel.TabIndex = 3;
			this.HullACLabel.Text = "AC:";
			this.InfoToolTip.SetToolTip(this.HullACLabel, "The armor class of this station");
			// 
			// HullRepairRateLabel
			// 
			this.HullRepairRateLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullRepairRateLabel.Location = new System.Drawing.Point(8, 40);
			this.HullRepairRateLabel.Name = "HullRepairRateLabel";
			this.HullRepairRateLabel.Size = new System.Drawing.Size(120, 16);
			this.HullRepairRateLabel.TabIndex = 4;
			this.HullRepairRateLabel.Text = "Repair Rate (hp/s):";
			this.InfoToolTip.SetToolTip(this.HullRepairRateLabel, "The rate at which this station\'s hull regenerates (in hitpoints per second)");
			// 
			// ShieldHitpointsLabel
			// 
			this.ShieldHitpointsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldHitpointsLabel.Location = new System.Drawing.Point(8, 24);
			this.ShieldHitpointsLabel.Name = "ShieldHitpointsLabel";
			this.ShieldHitpointsLabel.Size = new System.Drawing.Size(72, 16);
			this.ShieldHitpointsLabel.TabIndex = 6;
			this.ShieldHitpointsLabel.Text = "Hitpoints:";
			this.InfoToolTip.SetToolTip(this.ShieldHitpointsLabel, "The amount of damage required to drop this station\'s shields");
			// 
			// ShieldACLabel
			// 
			this.ShieldACLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldACLabel.Location = new System.Drawing.Point(8, 56);
			this.ShieldACLabel.Name = "ShieldACLabel";
			this.ShieldACLabel.Size = new System.Drawing.Size(24, 16);
			this.ShieldACLabel.TabIndex = 9;
			this.ShieldACLabel.Text = "AC:";
			this.InfoToolTip.SetToolTip(this.ShieldACLabel, "The armor class of this station\'s shields");
			// 
			// ShieldRepairRateLabel
			// 
			this.ShieldRepairRateLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldRepairRateLabel.Location = new System.Drawing.Point(8, 40);
			this.ShieldRepairRateLabel.Name = "ShieldRepairRateLabel";
			this.ShieldRepairRateLabel.Size = new System.Drawing.Size(120, 16);
			this.ShieldRepairRateLabel.TabIndex = 10;
			this.ShieldRepairRateLabel.Text = "Repair Rate (hp/s):";
			this.InfoToolTip.SetToolTip(this.ShieldRepairRateLabel, "The repair rate of this station\'s shields (in hitpoints per second)");
			// 
			// IncomeLabel
			// 
			this.IncomeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IncomeLabel.Location = new System.Drawing.Point(8, 24);
			this.IncomeLabel.Name = "IncomeLabel";
			this.IncomeLabel.Size = new System.Drawing.Size(128, 16);
			this.IncomeLabel.TabIndex = 12;
			this.IncomeLabel.Text = "Income (cr/payday):";
			this.InfoToolTip.SetToolTip(this.IncomeLabel, "The amount of credits per payday this station yields its team");
			// 
			// IncomeTextBox
			// 
			this.IncomeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.IncomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.IncomeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IncomeTextBox.ForeColor = System.Drawing.Color.White;
			this.IncomeTextBox.Location = new System.Drawing.Point(128, 24);
			this.IncomeTextBox.Name = "IncomeTextBox";
			this.IncomeTextBox.ReadOnly = true;
			this.IncomeTextBox.Size = new System.Drawing.Size(40, 14);
			this.IncomeTextBox.TabIndex = 13;
			this.IncomeTextBox.Text = "0";
			this.IncomeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.IncomeTextBox, "The amount of credits per payday this station yields its team");
			// 
			// HullRepairRateTextBox
			// 
			this.HullRepairRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HullRepairRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HullRepairRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullRepairRateTextBox.ForeColor = System.Drawing.Color.White;
			this.HullRepairRateTextBox.Location = new System.Drawing.Point(128, 40);
			this.HullRepairRateTextBox.Name = "HullRepairRateTextBox";
			this.HullRepairRateTextBox.ReadOnly = true;
			this.HullRepairRateTextBox.Size = new System.Drawing.Size(40, 14);
			this.HullRepairRateTextBox.TabIndex = 14;
			this.HullRepairRateTextBox.Text = "0";
			this.HullRepairRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HullRepairRateTextBox, "The rate at which this station\'s hull regenerates (in hitpoints per second)");
			// 
			// ShieldHitpointsTextBox
			// 
			this.ShieldHitpointsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldHitpointsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldHitpointsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldHitpointsTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldHitpointsTextBox.Location = new System.Drawing.Point(128, 24);
			this.ShieldHitpointsTextBox.Name = "ShieldHitpointsTextBox";
			this.ShieldHitpointsTextBox.ReadOnly = true;
			this.ShieldHitpointsTextBox.Size = new System.Drawing.Size(40, 14);
			this.ShieldHitpointsTextBox.TabIndex = 15;
			this.ShieldHitpointsTextBox.Text = "0";
			this.ShieldHitpointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ShieldHitpointsTextBox, "The amount of damage required to drop this station\'s shields");
			// 
			// HullACTextBox
			// 
			this.HullACTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HullACTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HullACTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullACTextBox.ForeColor = System.Drawing.Color.White;
			this.HullACTextBox.Location = new System.Drawing.Point(56, 56);
			this.HullACTextBox.Name = "HullACTextBox";
			this.HullACTextBox.ReadOnly = true;
			this.HullACTextBox.Size = new System.Drawing.Size(112, 14);
			this.HullACTextBox.TabIndex = 16;
			this.HullACTextBox.Text = "Light Base";
			this.InfoToolTip.SetToolTip(this.HullACTextBox, "The armor class of this station");
			// 
			// ShieldACTextBox
			// 
			this.ShieldACTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldACTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldACTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldACTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldACTextBox.Location = new System.Drawing.Point(56, 56);
			this.ShieldACTextBox.Name = "ShieldACTextBox";
			this.ShieldACTextBox.ReadOnly = true;
			this.ShieldACTextBox.Size = new System.Drawing.Size(112, 14);
			this.ShieldACTextBox.TabIndex = 17;
			this.ShieldACTextBox.Text = "Light Base";
			this.InfoToolTip.SetToolTip(this.ShieldACTextBox, "The armor class of this station\'s shields");
			// 
			// ShieldRepairRateTextBox
			// 
			this.ShieldRepairRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldRepairRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldRepairRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldRepairRateTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldRepairRateTextBox.Location = new System.Drawing.Point(128, 40);
			this.ShieldRepairRateTextBox.Name = "ShieldRepairRateTextBox";
			this.ShieldRepairRateTextBox.ReadOnly = true;
			this.ShieldRepairRateTextBox.Size = new System.Drawing.Size(40, 14);
			this.ShieldRepairRateTextBox.TabIndex = 18;
			this.ShieldRepairRateTextBox.Text = "0";
			this.ShieldRepairRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ShieldRepairRateTextBox, "The repair rate of this station\'s shields (in hitpoints per second)");
			// 
			// HullPanel
			// 
			this.HullPanel.Controls.Add(this.HullHitpointsLabel);
			this.HullPanel.Controls.Add(this.HullHitpointsTextBox);
			this.HullPanel.Controls.Add(this.HullHeaderLabel);
			this.HullPanel.Controls.Add(this.HullRepairRateTextBox);
			this.HullPanel.Controls.Add(this.HullACTextBox);
			this.HullPanel.Controls.Add(this.HullRepairRateLabel);
			this.HullPanel.Controls.Add(this.HullACLabel);
			this.HullPanel.Location = new System.Drawing.Point(0, 64);
			this.HullPanel.Name = "HullPanel";
			this.HullPanel.Size = new System.Drawing.Size(180, 72);
			this.HullPanel.TabIndex = 39;
			// 
			// HullHitpointsLabel
			// 
			this.HullHitpointsLabel.BackColor = System.Drawing.Color.Black;
			this.HullHitpointsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullHitpointsLabel.Location = new System.Drawing.Point(8, 24);
			this.HullHitpointsLabel.Name = "HullHitpointsLabel";
			this.HullHitpointsLabel.Size = new System.Drawing.Size(64, 16);
			this.HullHitpointsLabel.TabIndex = 30;
			this.HullHitpointsLabel.Text = "Hitpoints:";
			this.InfoToolTip.SetToolTip(this.HullHitpointsLabel, "The amount of damage required to drop this station\'s hull");
			// 
			// HullHitpointsTextBox
			// 
			this.HullHitpointsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HullHitpointsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HullHitpointsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullHitpointsTextBox.ForeColor = System.Drawing.Color.White;
			this.HullHitpointsTextBox.Location = new System.Drawing.Point(128, 24);
			this.HullHitpointsTextBox.Name = "HullHitpointsTextBox";
			this.HullHitpointsTextBox.ReadOnly = true;
			this.HullHitpointsTextBox.Size = new System.Drawing.Size(40, 14);
			this.HullHitpointsTextBox.TabIndex = 31;
			this.HullHitpointsTextBox.Text = "0";
			this.HullHitpointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HullHitpointsTextBox, "The amount of damage required to drop this station\'s hull");
			// 
			// HullHeaderLabel
			// 
			this.HullHeaderLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.HullHeaderLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.HullHeaderLabel.Location = new System.Drawing.Point(0, 5);
			this.HullHeaderLabel.Name = "HullHeaderLabel";
			this.HullHeaderLabel.Size = new System.Drawing.Size(184, 16);
			this.HullHeaderLabel.TabIndex = 29;
			this.HullHeaderLabel.Text = "Hull";
			// 
			// ShieldPanel
			// 
			this.ShieldPanel.Controls.Add(this.ShieldRepairRateTextBox);
			this.ShieldPanel.Controls.Add(this.ShieldLabel);
			this.ShieldPanel.Controls.Add(this.ShieldRepairRateLabel);
			this.ShieldPanel.Controls.Add(this.ShieldHitpointsLabel);
			this.ShieldPanel.Controls.Add(this.ShieldACLabel);
			this.ShieldPanel.Controls.Add(this.ShieldHitpointsTextBox);
			this.ShieldPanel.Controls.Add(this.ShieldACTextBox);
			this.ShieldPanel.Location = new System.Drawing.Point(184, 64);
			this.ShieldPanel.Name = "ShieldPanel";
			this.ShieldPanel.Size = new System.Drawing.Size(184, 72);
			this.ShieldPanel.TabIndex = 40;
			// 
			// ShieldLabel
			// 
			this.ShieldLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ShieldLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ShieldLabel.Location = new System.Drawing.Point(0, 5);
			this.ShieldLabel.Name = "ShieldLabel";
			this.ShieldLabel.Size = new System.Drawing.Size(184, 16);
			this.ShieldLabel.TabIndex = 29;
			this.ShieldLabel.Text = "Shield";
			// 
			// StationPanel
			// 
			this.StationPanel.Controls.Add(this.ClassTextBox);
			this.StationPanel.Controls.Add(this.ClassLabel);
			this.StationPanel.Controls.Add(this.IncomeTextBox);
			this.StationPanel.Controls.Add(this.StationLabel);
			this.StationPanel.Controls.Add(this.IncomeLabel);
			this.StationPanel.Location = new System.Drawing.Point(184, 0);
			this.StationPanel.Name = "StationPanel";
			this.StationPanel.Size = new System.Drawing.Size(184, 64);
			this.StationPanel.TabIndex = 41;
			// 
			// ClassTextBox
			// 
			this.ClassTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ClassTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ClassTextBox.ForeColor = System.Drawing.Color.White;
			this.ClassTextBox.Location = new System.Drawing.Point(56, 40);
			this.ClassTextBox.Name = "ClassTextBox";
			this.ClassTextBox.ReadOnly = true;
			this.ClassTextBox.Size = new System.Drawing.Size(112, 14);
			this.ClassTextBox.TabIndex = 31;
			this.ClassTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.ClassTextBox, "The type of station");
			// 
			// ClassLabel
			// 
			this.ClassLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ClassLabel.Location = new System.Drawing.Point(8, 40);
			this.ClassLabel.Name = "ClassLabel";
			this.ClassLabel.Size = new System.Drawing.Size(40, 16);
			this.ClassLabel.TabIndex = 30;
			this.ClassLabel.Text = "Class:";
			this.InfoToolTip.SetToolTip(this.ClassLabel, "The type of station");
			// 
			// StationLabel
			// 
			this.StationLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.StationLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.StationLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.StationLabel.Location = new System.Drawing.Point(0, 5);
			this.StationLabel.Name = "StationLabel";
			this.StationLabel.Size = new System.Drawing.Size(184, 16);
			this.StationLabel.TabIndex = 29;
			this.StationLabel.Text = "Station";
			// 
			// AbilitiesPanel
			// 
			this.AbilitiesPanel.Controls.Add(this.RescuesAllPodsLabel);
			this.AbilitiesPanel.Controls.Add(this.RipcordLabel);
			this.AbilitiesPanel.Controls.Add(this.RescuesTeamsPodsLabel);
			this.AbilitiesPanel.Controls.Add(this.FlagPedestalLabel);
			this.AbilitiesPanel.Controls.Add(this.CapitalDockableLabel);
			this.AbilitiesPanel.Controls.Add(this.DockableLabel);
			this.AbilitiesPanel.Controls.Add(this.CapturableLabel);
			this.AbilitiesPanel.Controls.Add(this.ReloadShipsLabel);
			this.AbilitiesPanel.Controls.Add(this.LeadIndicatorLabel);
			this.AbilitiesPanel.Controls.Add(this.RepairableLabel);
			this.AbilitiesPanel.Controls.Add(this.RestartingBaseLabel);
			this.AbilitiesPanel.Controls.Add(this.StartingBaseLabel);
			this.AbilitiesPanel.Controls.Add(this.CountsForVictoryLabel);
			this.AbilitiesPanel.Controls.Add(this.MinerTeleOffloadLabel);
			this.AbilitiesPanel.Controls.Add(this.MinersOffloadLabel);
			this.AbilitiesPanel.Controls.Add(this.AbilitiesLabel);
			this.AbilitiesPanel.Location = new System.Drawing.Point(0, 136);
			this.AbilitiesPanel.Name = "AbilitiesPanel";
			this.AbilitiesPanel.Size = new System.Drawing.Size(368, 104);
			this.AbilitiesPanel.TabIndex = 42;
			// 
			// RescuesAllPodsLabel
			// 
			this.RescuesAllPodsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RescuesAllPodsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RescuesAllPodsLabel.Location = new System.Drawing.Point(240, 88);
			this.RescuesAllPodsLabel.Name = "RescuesAllPodsLabel";
			this.RescuesAllPodsLabel.Size = new System.Drawing.Size(112, 16);
			this.RescuesAllPodsLabel.TabIndex = 44;
			this.RescuesAllPodsLabel.Text = "Rescues All Pods";
			this.RescuesAllPodsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RescuesAllPodsLabel, "This station will rescue all lifepods when they collide with it, even enemy lifep" +
				"ods");
			// 
			// RipcordLabel
			// 
			this.RipcordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipcordLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RipcordLabel.Location = new System.Drawing.Point(240, 24);
			this.RipcordLabel.Name = "RipcordLabel";
			this.RipcordLabel.Size = new System.Drawing.Size(112, 16);
			this.RipcordLabel.TabIndex = 43;
			this.RipcordLabel.Text = "Ripcord";
			this.RipcordLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RipcordLabel, "This station acts as a teleport receiver, allowing any friendly ripcordable ship " +
				"to instantly ripcord to it");
			// 
			// RescuesTeamsPodsLabel
			// 
			this.RescuesTeamsPodsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RescuesTeamsPodsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RescuesTeamsPodsLabel.Location = new System.Drawing.Point(240, 72);
			this.RescuesTeamsPodsLabel.Name = "RescuesTeamsPodsLabel";
			this.RescuesTeamsPodsLabel.Size = new System.Drawing.Size(112, 16);
			this.RescuesTeamsPodsLabel.TabIndex = 42;
			this.RescuesTeamsPodsLabel.Text = "Rescues Team\'s Pods";
			this.RescuesTeamsPodsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RescuesTeamsPodsLabel, "This station will rescue friendly lifepods when they collide with it");
			// 
			// FlagPedestalLabel
			// 
			this.FlagPedestalLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FlagPedestalLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.FlagPedestalLabel.Location = new System.Drawing.Point(8, 72);
			this.FlagPedestalLabel.Name = "FlagPedestalLabel";
			this.FlagPedestalLabel.Size = new System.Drawing.Size(104, 16);
			this.FlagPedestalLabel.TabIndex = 41;
			this.FlagPedestalLabel.Text = "Flag Pedestal";
			this.FlagPedestalLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.FlagPedestalLabel, "This station supports a flag above it in \"Capture the Flag\" mode");
			// 
			// CapitalDockableLabel
			// 
			this.CapitalDockableLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CapitalDockableLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CapitalDockableLabel.Location = new System.Drawing.Point(120, 72);
			this.CapitalDockableLabel.Name = "CapitalDockableLabel";
			this.CapitalDockableLabel.Size = new System.Drawing.Size(112, 16);
			this.CapitalDockableLabel.TabIndex = 40;
			this.CapitalDockableLabel.Text = "Capital Dockable";
			this.CapitalDockableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.CapitalDockableLabel, "Ships without the \"Small Ship\" flag (Capital ships) are able to dock in this stat" +
				"ion");
			// 
			// DockableLabel
			// 
			this.DockableLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DockableLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.DockableLabel.Location = new System.Drawing.Point(120, 56);
			this.DockableLabel.Name = "DockableLabel";
			this.DockableLabel.Size = new System.Drawing.Size(112, 16);
			this.DockableLabel.TabIndex = 39;
			this.DockableLabel.Text = "Dockable";
			this.DockableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.DockableLabel, "Ships classified as \"Small Ships\" are able to dock in this station");
			// 
			// CapturableLabel
			// 
			this.CapturableLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CapturableLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CapturableLabel.Location = new System.Drawing.Point(240, 40);
			this.CapturableLabel.Name = "CapturableLabel";
			this.CapturableLabel.Size = new System.Drawing.Size(112, 16);
			this.CapturableLabel.TabIndex = 38;
			this.CapturableLabel.Text = "Capturable";
			this.CapturableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.CapturableLabel, "This station can be captured by enemy teams");
			// 
			// ReloadShipsLabel
			// 
			this.ReloadShipsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ReloadShipsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ReloadShipsLabel.Location = new System.Drawing.Point(120, 88);
			this.ReloadShipsLabel.Name = "ReloadShipsLabel";
			this.ReloadShipsLabel.Size = new System.Drawing.Size(112, 16);
			this.ReloadShipsLabel.TabIndex = 37;
			this.ReloadShipsLabel.Text = "Reloads Ships";
			this.ReloadShipsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.ReloadShipsLabel, "The ship\'s ammo, fuel, and other depletables are replenished when it docks in thi" +
				"s station");
			// 
			// LeadIndicatorLabel
			// 
			this.LeadIndicatorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LeadIndicatorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.LeadIndicatorLabel.Location = new System.Drawing.Point(240, 56);
			this.LeadIndicatorLabel.Name = "LeadIndicatorLabel";
			this.LeadIndicatorLabel.Size = new System.Drawing.Size(112, 16);
			this.LeadIndicatorLabel.TabIndex = 36;
			this.LeadIndicatorLabel.Text = "Relays Lead Indicator";
			this.LeadIndicatorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.LeadIndicatorLabel, "This station relays an aim-helping lead indicator for all targets within its scan" +
				"range to teammates");
			// 
			// RepairableLabel
			// 
			this.RepairableLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RepairableLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RepairableLabel.Location = new System.Drawing.Point(8, 88);
			this.RepairableLabel.Name = "RepairableLabel";
			this.RepairableLabel.Size = new System.Drawing.Size(104, 16);
			this.RepairableLabel.TabIndex = 35;
			this.RepairableLabel.Text = "Repairable";
			this.RepairableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RepairableLabel, "This station can be repaired by healing weapons");
			// 
			// RestartingBaseLabel
			// 
			this.RestartingBaseLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RestartingBaseLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RestartingBaseLabel.Location = new System.Drawing.Point(8, 56);
			this.RestartingBaseLabel.Name = "RestartingBaseLabel";
			this.RestartingBaseLabel.Size = new System.Drawing.Size(104, 16);
			this.RestartingBaseLabel.TabIndex = 34;
			this.RestartingBaseLabel.Text = "Restarting Base";
			this.RestartingBaseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RestartingBaseLabel, "This staiton is where players end up after their lifepods are destroyed");
			// 
			// StartingBaseLabel
			// 
			this.StartingBaseLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.StartingBaseLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.StartingBaseLabel.Location = new System.Drawing.Point(8, 40);
			this.StartingBaseLabel.Name = "StartingBaseLabel";
			this.StartingBaseLabel.Size = new System.Drawing.Size(104, 16);
			this.StartingBaseLabel.TabIndex = 33;
			this.StartingBaseLabel.Text = "Starting Base";
			this.StartingBaseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.StartingBaseLabel, "This base is where players start in when joining a game");
			// 
			// CountsForVictoryLabel
			// 
			this.CountsForVictoryLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CountsForVictoryLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CountsForVictoryLabel.Location = new System.Drawing.Point(8, 24);
			this.CountsForVictoryLabel.Name = "CountsForVictoryLabel";
			this.CountsForVictoryLabel.Size = new System.Drawing.Size(104, 16);
			this.CountsForVictoryLabel.TabIndex = 32;
			this.CountsForVictoryLabel.Text = "Counts for Victory";
			this.CountsForVictoryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.CountsForVictoryLabel, "This station will keep a team alive if the game mode is \"Conquest\"");
			// 
			// MinerTeleOffloadLabel
			// 
			this.MinerTeleOffloadLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MinerTeleOffloadLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.MinerTeleOffloadLabel.Location = new System.Drawing.Point(120, 24);
			this.MinerTeleOffloadLabel.Name = "MinerTeleOffloadLabel";
			this.MinerTeleOffloadLabel.Size = new System.Drawing.Size(112, 16);
			this.MinerTeleOffloadLabel.TabIndex = 31;
			this.MinerTeleOffloadLabel.Text = "Miners Tele-Offload";
			this.MinerTeleOffloadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.MinerTeleOffloadLabel, "Miners are able to \"beam\" their HE³ to this station without physically docking in" +
				" it");
			// 
			// MinersOffloadLabel
			// 
			this.MinersOffloadLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MinersOffloadLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.MinersOffloadLabel.Location = new System.Drawing.Point(120, 40);
			this.MinersOffloadLabel.Name = "MinersOffloadLabel";
			this.MinersOffloadLabel.Size = new System.Drawing.Size(112, 16);
			this.MinersOffloadLabel.TabIndex = 30;
			this.MinersOffloadLabel.Text = "Miners Can Offload";
			this.MinersOffloadLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.MinersOffloadLabel, "Miners are able to dock in this station, manually offloading their HE3");
			// 
			// AbilitiesLabel
			// 
			this.AbilitiesLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.AbilitiesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AbilitiesLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.AbilitiesLabel.Location = new System.Drawing.Point(0, 5);
			this.AbilitiesLabel.Name = "AbilitiesLabel";
			this.AbilitiesLabel.Size = new System.Drawing.Size(368, 16);
			this.AbilitiesLabel.TabIndex = 29;
			this.AbilitiesLabel.Text = "Abilities";
			// 
			// StationForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(358, 239);
			this.Controls.Add(this.AbilitiesPanel);
			this.Controls.Add(this.StationPanel);
			this.Controls.Add(this.HullPanel);
			this.Controls.Add(this.ShieldPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "StationForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.StationForm_Closing);
			this.Controls.SetChildIndex(this.ShieldPanel, 0);
			this.Controls.SetChildIndex(this.HullPanel, 0);
			this.Controls.SetChildIndex(this.StationPanel, 0);
			this.Controls.SetChildIndex(this.SensorsPanel, 0);
			this.Controls.SetChildIndex(this.AbilitiesPanel, 0);
			this.SensorsPanel.ResumeLayout(false);
			this.HullPanel.ResumeLayout(false);
			this.ShieldPanel.ResumeLayout(false);
			this.StationPanel.ResumeLayout(false);
			this.AbilitiesPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateHandler (object sender, EventArgs e)
		{
			ScanRangeTextBox.Text = _station.CalculateScanrange().ToString();
			SigTextBox.Text = (_station.CalculateSignature() * 100).ToString();
			IncomeTextBox.Text = _station.IGCStation.Income.ToString();
			ClassTextBox.Text = Enum.GetName(typeof(StationType), _station.IGCStation.Type);
			HullHitpointsTextBox.Text = _station.CalculateHullHitpoints().ToString();
			HullRepairRateTextBox.Text = _station.CalculateHullRepairRate().ToString();
			HullACTextBox.Text = Enum.GetName(typeof(IGCArmorClass), _station.IGCStation.HullArmorClass);
			ShieldHitpointsTextBox.Text = _station.CalculateShieldHitpoints().ToString();
			ShieldRepairRateTextBox.Text = _station.CalculateShieldRepairRate().ToString();
			ShieldACTextBox.Text = Enum.GetName(typeof(IGCArmorClass), _station.IGCStation.ShieldArmorClass);

			if (_station.IGCStation.StationAbility[(ushort)StationAbility.CountsForVictory])
				EnableFeature(CountsForVictoryLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.StartingBase])
				EnableFeature(StartingBaseLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.RestartingBase])
				EnableFeature(RestartingBaseLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.FlagPedestal])
				EnableFeature(FlagPedestalLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.Repairable])
				EnableFeature(RepairableLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.MinersCanTeleOffload])
				EnableFeature(MinerTeleOffloadLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.MinersCanOffload])
				EnableFeature(MinersOffloadLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.Dockable])
				EnableFeature(DockableLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.CapitalDockable])
				EnableFeature(CapitalDockableLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.ReloadShips])
				EnableFeature(ReloadShipsLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.Ripcord])
				EnableFeature(RipcordLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.Capturable])
				EnableFeature(CapturableLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.RelaysLeadIndicator])
				EnableFeature(LeadIndicatorLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.RescuesTeamPods])
				EnableFeature(RescuesTeamsPodsLabel);
			if (_station.IGCStation.StationAbility[(ushort)StationAbility.RescuesAllPods])
				EnableFeature(RescuesAllPodsLabel);
		}

		private void ClosedHandler (object sender, EventArgs e)
		{
			_station.Updated -= new EventHandler(UpdateHandler);
			_station.Closed -= new EventHandler(ClosedHandler);
			this.Close();
			this.Dispose();
		}

		private void StationForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_station.Updated -= new EventHandler(UpdateHandler);
			_station.Closed -= new EventHandler(ClosedHandler);
			_station = null;
		}
	}
}

