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
	/// Summary description for ConstantsForm.
	/// </summary>
	public class ConstantsForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.Panel SectorPanel;
		private System.Windows.Forms.Label SectorLabel;
		private System.Windows.Forms.Label SectorRadiusLabel;
		private System.Windows.Forms.TextBox SectorRadiusTextBox;
		private System.Windows.Forms.TextBox LensMultiplierTextBox;
		private System.Windows.Forms.Label LensMultiplierLabel;
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.Windows.Forms.Panel PointsPanel;
		private System.Windows.Forms.TextBox PointsTechTextBox;
		private System.Windows.Forms.Label PointsTechLabel;
		private System.Windows.Forms.TextBox PointsAsteroidTextBox;
		private System.Windows.Forms.Label PointsAsteroidLabel;
		private System.Windows.Forms.TextBox PointsAlephTextBox;
		private System.Windows.Forms.Label PointsAlephLabel;
		private System.Windows.Forms.Label PointsLabel;
		private System.Windows.Forms.TextBox OutofBoundsTextBox;
		private System.Windows.Forms.Label OutofBoundsLabel;
		private System.Windows.Forms.TextBox PointsMinerTextBox;
		private System.Windows.Forms.Label PointsMinerLabel;
		private System.Windows.Forms.TextBox PointsBuilderTextBox;
		private System.Windows.Forms.Label DestroyConstructorLabel;
		private System.Windows.Forms.TextBox PointsLayerTextBox;
		private System.Windows.Forms.Label PointsLayerLabel;
		private System.Windows.Forms.TextBox PointsCarrierTextBox;
		private System.Windows.Forms.Label PointsCarrierLabel;
		private System.Windows.Forms.TextBox PointsPilotTextBox;
		private System.Windows.Forms.Label PointsPilotLabel;
		private System.Windows.Forms.TextBox PointsBaseKillTextBox;
		private System.Windows.Forms.Label PointsBaseKillLabel;
		private System.Windows.Forms.TextBox PointsBaseCaptureTextBox;
		private System.Windows.Forms.Label PointsBaseCaptureLabel;
		private System.Windows.Forms.TextBox PointsFlagTextBox;
		private System.Windows.Forms.Label PointsFlagLabel;
		private System.Windows.Forms.TextBox PointsArtifactTextBox;
		private System.Windows.Forms.Label PointsArtifactLabel;
		private System.Windows.Forms.TextBox PointsRescueTextBox;
		private System.Windows.Forms.Label PointsRescueLabel;
		private System.Windows.Forms.Panel He3Panel;
		private System.Windows.Forms.Label He3Label;
		private System.Windows.Forms.TextBox AmountHe3TextBox;
		private System.Windows.Forms.Label AmountHe3Label;
		private System.Windows.Forms.TextBox ValueHe3TextBox;
		private System.Windows.Forms.Label ValueHe3Label;
		private System.Windows.Forms.TextBox CapacityHe3TextBox;
		private System.Windows.Forms.Label CapacityHe3Label;
		private System.Windows.Forms.TextBox He3RegenerationTextBox;
		private System.Windows.Forms.Label He3RegenerationLabel;
		private System.Windows.Forms.TextBox RipcordTimeTextBox;
		private System.Windows.Forms.Label RipcordTimeLabel;
		private System.Windows.Forms.TextBox DownedShieldTextBox;
		private System.Windows.Forms.Label DownedShieldLabel;
		private System.Windows.Forms.TextBox ExitStationSpeedTextBox;
		private System.Windows.Forms.Label ExitStationSpeedLabel;
		private System.Windows.Forms.TextBox ExitWarpSpeedTextBox;
		private System.Windows.Forms.Label ExitWarpSpeedLabel;
		private System.Windows.Forms.TextBox MountRateTextBox;
		private System.Windows.Forms.Label MountRateLabel;
		private System.Windows.Forms.TextBox LifepodEnduranceTextBox;
		private System.Windows.Forms.Label LifepodEnduranceLabel;
		private System.Windows.Forms.Panel ShipPanel;
		private System.Windows.Forms.Label ShipLabel;
		private System.Windows.Forms.TextBox LifepodCostTextBox;
		private System.Windows.Forms.Label LifepodCostLabel;
		private System.Windows.Forms.TextBox PlayerCostTextBox;
		private System.Windows.Forms.Label PlayerCostLabel;
		private System.Windows.Forms.TextBox TurretCostTextBox;
		private System.Windows.Forms.Label TurretCostLabel;
		private System.Windows.Forms.TextBox DroneCostTextBox;
		private System.Windows.Forms.Label DroneCostLabel;
		private System.Windows.Forms.TextBox WarpBombDelayTextBox;
		private System.Windows.Forms.Label WarpBombDelayLabel;
		private System.Windows.Forms.Panel CreditsPanel;
		private System.Windows.Forms.TextBox IncomeTextBox;
		private System.Windows.Forms.Label IncomeLabel;
		private System.Windows.Forms.TextBox WinTheGameMoneyTextBox;
		private System.Windows.Forms.Label WinTheGameMoneyLabel;
		private System.Windows.Forms.TextBox StartingMoneyTextBox;
		private System.Windows.Forms.Label StartingMoneyLabel;
		private System.Windows.Forms.TextBox SecondsBetweenPaydaysTextBox;
		private System.Windows.Forms.Label SecondsBetweenPaydaysLabel;
		private System.Windows.Forms.Label CreditsLabel;
		private System.Windows.Forms.TextBox RatingAddTextBox;
		private System.Windows.Forms.Label RatingAddLabel;
		private System.Windows.Forms.TextBox RatingDivideTextBox;
		private System.Windows.Forms.Label RatingDivideLabel;
		private System.Windows.Forms.TextBox BaseClusterCostTextBox;
		private System.Windows.Forms.Label BaseClusterCostLabel;
		private System.Windows.Forms.TextBox ClusterDivisorTextBox;
		private System.Windows.Forms.Label ClusterDivisorLabel;
		private System.Windows.Forms.TextBox UnknownTextBox;
		private System.Windows.Forms.Label UnknownLabel;
		private System.ComponentModel.IContainer components;
		#endregion

		private IGCCoreConstants	_constants;

		public ConstantsForm (MainForm mainForm)
		{
			InitializeComponent();

			this.Icon = mainForm.Icon;
			_constants = mainForm.Game.Core.Constants;
			InfoToolTip.Active = mainForm.Settings.ShowToolTips;

			BindControls();
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
			this.SectorPanel = new System.Windows.Forms.Panel();
			this.ClusterDivisorTextBox = new System.Windows.Forms.TextBox();
			this.ClusterDivisorLabel = new System.Windows.Forms.Label();
			this.BaseClusterCostTextBox = new System.Windows.Forms.TextBox();
			this.BaseClusterCostLabel = new System.Windows.Forms.Label();
			this.WarpBombDelayTextBox = new System.Windows.Forms.TextBox();
			this.WarpBombDelayLabel = new System.Windows.Forms.Label();
			this.DroneCostTextBox = new System.Windows.Forms.TextBox();
			this.DroneCostLabel = new System.Windows.Forms.Label();
			this.TurretCostTextBox = new System.Windows.Forms.TextBox();
			this.TurretCostLabel = new System.Windows.Forms.Label();
			this.PlayerCostTextBox = new System.Windows.Forms.TextBox();
			this.PlayerCostLabel = new System.Windows.Forms.Label();
			this.LifepodCostTextBox = new System.Windows.Forms.TextBox();
			this.LifepodCostLabel = new System.Windows.Forms.Label();
			this.OutofBoundsTextBox = new System.Windows.Forms.TextBox();
			this.OutofBoundsLabel = new System.Windows.Forms.Label();
			this.LensMultiplierTextBox = new System.Windows.Forms.TextBox();
			this.LensMultiplierLabel = new System.Windows.Forms.Label();
			this.SectorRadiusTextBox = new System.Windows.Forms.TextBox();
			this.SectorRadiusLabel = new System.Windows.Forms.Label();
			this.SectorLabel = new System.Windows.Forms.Label();
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.PointsTechTextBox = new System.Windows.Forms.TextBox();
			this.PointsAsteroidTextBox = new System.Windows.Forms.TextBox();
			this.PointsAlephTextBox = new System.Windows.Forms.TextBox();
			this.PointsMinerTextBox = new System.Windows.Forms.TextBox();
			this.PointsBuilderTextBox = new System.Windows.Forms.TextBox();
			this.PointsLayerTextBox = new System.Windows.Forms.TextBox();
			this.PointsCarrierTextBox = new System.Windows.Forms.TextBox();
			this.PointsPilotTextBox = new System.Windows.Forms.TextBox();
			this.PointsBaseKillTextBox = new System.Windows.Forms.TextBox();
			this.PointsBaseCaptureTextBox = new System.Windows.Forms.TextBox();
			this.PointsFlagTextBox = new System.Windows.Forms.TextBox();
			this.PointsArtifactTextBox = new System.Windows.Forms.TextBox();
			this.PointsRescueTextBox = new System.Windows.Forms.TextBox();
			this.AmountHe3TextBox = new System.Windows.Forms.TextBox();
			this.ValueHe3TextBox = new System.Windows.Forms.TextBox();
			this.CapacityHe3TextBox = new System.Windows.Forms.TextBox();
			this.He3RegenerationTextBox = new System.Windows.Forms.TextBox();
			this.RipcordTimeTextBox = new System.Windows.Forms.TextBox();
			this.DownedShieldTextBox = new System.Windows.Forms.TextBox();
			this.ExitStationSpeedTextBox = new System.Windows.Forms.TextBox();
			this.ExitWarpSpeedTextBox = new System.Windows.Forms.TextBox();
			this.MountRateTextBox = new System.Windows.Forms.TextBox();
			this.LifepodEnduranceTextBox = new System.Windows.Forms.TextBox();
			this.IncomeTextBox = new System.Windows.Forms.TextBox();
			this.WinTheGameMoneyTextBox = new System.Windows.Forms.TextBox();
			this.StartingMoneyTextBox = new System.Windows.Forms.TextBox();
			this.SecondsBetweenPaydaysTextBox = new System.Windows.Forms.TextBox();
			this.RatingAddTextBox = new System.Windows.Forms.TextBox();
			this.RatingDivideTextBox = new System.Windows.Forms.TextBox();
			this.UnknownTextBox = new System.Windows.Forms.TextBox();
			this.PointsRescueLabel = new System.Windows.Forms.Label();
			this.PointsArtifactLabel = new System.Windows.Forms.Label();
			this.PointsFlagLabel = new System.Windows.Forms.Label();
			this.PointsBaseCaptureLabel = new System.Windows.Forms.Label();
			this.PointsBaseKillLabel = new System.Windows.Forms.Label();
			this.PointsPilotLabel = new System.Windows.Forms.Label();
			this.PointsCarrierLabel = new System.Windows.Forms.Label();
			this.PointsLayerLabel = new System.Windows.Forms.Label();
			this.DestroyConstructorLabel = new System.Windows.Forms.Label();
			this.PointsMinerLabel = new System.Windows.Forms.Label();
			this.PointsTechLabel = new System.Windows.Forms.Label();
			this.PointsAsteroidLabel = new System.Windows.Forms.Label();
			this.PointsAlephLabel = new System.Windows.Forms.Label();
			this.UnknownLabel = new System.Windows.Forms.Label();
			this.He3RegenerationLabel = new System.Windows.Forms.Label();
			this.AmountHe3Label = new System.Windows.Forms.Label();
			this.ValueHe3Label = new System.Windows.Forms.Label();
			this.CapacityHe3Label = new System.Windows.Forms.Label();
			this.RatingDivideLabel = new System.Windows.Forms.Label();
			this.RatingAddLabel = new System.Windows.Forms.Label();
			this.LifepodEnduranceLabel = new System.Windows.Forms.Label();
			this.MountRateLabel = new System.Windows.Forms.Label();
			this.RipcordTimeLabel = new System.Windows.Forms.Label();
			this.DownedShieldLabel = new System.Windows.Forms.Label();
			this.ExitStationSpeedLabel = new System.Windows.Forms.Label();
			this.ExitWarpSpeedLabel = new System.Windows.Forms.Label();
			this.IncomeLabel = new System.Windows.Forms.Label();
			this.WinTheGameMoneyLabel = new System.Windows.Forms.Label();
			this.SecondsBetweenPaydaysLabel = new System.Windows.Forms.Label();
			this.StartingMoneyLabel = new System.Windows.Forms.Label();
			this.PointsPanel = new System.Windows.Forms.Panel();
			this.PointsLabel = new System.Windows.Forms.Label();
			this.He3Panel = new System.Windows.Forms.Panel();
			this.He3Label = new System.Windows.Forms.Label();
			this.ShipPanel = new System.Windows.Forms.Panel();
			this.ShipLabel = new System.Windows.Forms.Label();
			this.CreditsPanel = new System.Windows.Forms.Panel();
			this.CreditsLabel = new System.Windows.Forms.Label();
			this.SectorPanel.SuspendLayout();
			this.PointsPanel.SuspendLayout();
			this.He3Panel.SuspendLayout();
			this.ShipPanel.SuspendLayout();
			this.CreditsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// SectorPanel
			// 
			this.SectorPanel.Controls.Add(this.ClusterDivisorTextBox);
			this.SectorPanel.Controls.Add(this.ClusterDivisorLabel);
			this.SectorPanel.Controls.Add(this.BaseClusterCostTextBox);
			this.SectorPanel.Controls.Add(this.BaseClusterCostLabel);
			this.SectorPanel.Controls.Add(this.WarpBombDelayTextBox);
			this.SectorPanel.Controls.Add(this.WarpBombDelayLabel);
			this.SectorPanel.Controls.Add(this.DroneCostTextBox);
			this.SectorPanel.Controls.Add(this.DroneCostLabel);
			this.SectorPanel.Controls.Add(this.TurretCostTextBox);
			this.SectorPanel.Controls.Add(this.TurretCostLabel);
			this.SectorPanel.Controls.Add(this.PlayerCostTextBox);
			this.SectorPanel.Controls.Add(this.PlayerCostLabel);
			this.SectorPanel.Controls.Add(this.LifepodCostTextBox);
			this.SectorPanel.Controls.Add(this.LifepodCostLabel);
			this.SectorPanel.Controls.Add(this.OutofBoundsTextBox);
			this.SectorPanel.Controls.Add(this.OutofBoundsLabel);
			this.SectorPanel.Controls.Add(this.LensMultiplierTextBox);
			this.SectorPanel.Controls.Add(this.LensMultiplierLabel);
			this.SectorPanel.Controls.Add(this.SectorRadiusTextBox);
			this.SectorPanel.Controls.Add(this.SectorRadiusLabel);
			this.SectorPanel.Controls.Add(this.SectorLabel);
			this.SectorPanel.Location = new System.Drawing.Point(0, 0);
			this.SectorPanel.Name = "SectorPanel";
			this.SectorPanel.Size = new System.Drawing.Size(328, 104);
			this.SectorPanel.TabIndex = 0;
			// 
			// ClusterDivisorTextBox
			// 
			this.ClusterDivisorTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ClusterDivisorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClusterDivisorTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ClusterDivisorTextBox.ForeColor = System.Drawing.Color.White;
			this.ClusterDivisorTextBox.Location = new System.Drawing.Point(120, 88);
			this.ClusterDivisorTextBox.Name = "ClusterDivisorTextBox";
			this.ClusterDivisorTextBox.ReadOnly = true;
			this.ClusterDivisorTextBox.Size = new System.Drawing.Size(48, 14);
			this.ClusterDivisorTextBox.TabIndex = 10;
			this.ClusterDivisorTextBox.Text = "0";
			this.ClusterDivisorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ClusterDivisorTextBox, "Determines the time difference between sector overload damage applications");
			// 
			// ClusterDivisorLabel
			// 
			this.ClusterDivisorLabel.Location = new System.Drawing.Point(8, 88);
			this.ClusterDivisorLabel.Name = "ClusterDivisorLabel";
			this.ClusterDivisorLabel.Size = new System.Drawing.Size(96, 16);
			this.ClusterDivisorLabel.TabIndex = 9;
			this.ClusterDivisorLabel.Text = "Cluster Divisor:";
			this.InfoToolTip.SetToolTip(this.ClusterDivisorLabel, "Determines the time difference between sector overload damage applications");
			// 
			// BaseClusterCostTextBox
			// 
			this.BaseClusterCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.BaseClusterCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BaseClusterCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BaseClusterCostTextBox.ForeColor = System.Drawing.Color.White;
			this.BaseClusterCostTextBox.Location = new System.Drawing.Point(120, 72);
			this.BaseClusterCostTextBox.Name = "BaseClusterCostTextBox";
			this.BaseClusterCostTextBox.ReadOnly = true;
			this.BaseClusterCostTextBox.Size = new System.Drawing.Size(48, 14);
			this.BaseClusterCostTextBox.TabIndex = 8;
			this.BaseClusterCostTextBox.Text = "0";
			this.BaseClusterCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.BaseClusterCostTextBox, "The starting point for Sector Overload calculations. Add the \"cost\" of each playe" +
				"r in a sector to this, and if it\'s > 0, a sector overload occurs");
			// 
			// BaseClusterCostLabel
			// 
			this.BaseClusterCostLabel.Location = new System.Drawing.Point(8, 72);
			this.BaseClusterCostLabel.Name = "BaseClusterCostLabel";
			this.BaseClusterCostLabel.Size = new System.Drawing.Size(112, 16);
			this.BaseClusterCostLabel.TabIndex = 7;
			this.BaseClusterCostLabel.Text = "Base Cluster Cost:";
			this.InfoToolTip.SetToolTip(this.BaseClusterCostLabel, "The starting point for Sector Overload calculations. Add the \"cost\" of each playe" +
				"r in a sector to this, and if it\'s > 0, a sector overload occurs");
			// 
			// WarpBombDelayTextBox
			// 
			this.WarpBombDelayTextBox.BackColor = System.Drawing.Color.Maroon;
			this.WarpBombDelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WarpBombDelayTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WarpBombDelayTextBox.ForeColor = System.Drawing.Color.White;
			this.WarpBombDelayTextBox.Location = new System.Drawing.Point(120, 56);
			this.WarpBombDelayTextBox.Name = "WarpBombDelayTextBox";
			this.WarpBombDelayTextBox.ReadOnly = true;
			this.WarpBombDelayTextBox.Size = new System.Drawing.Size(48, 14);
			this.WarpBombDelayTextBox.TabIndex = 6;
			this.WarpBombDelayTextBox.Text = "0";
			this.WarpBombDelayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.WarpBombDelayTextBox, "The number of seconds between a resonator hit and its explosion");
			// 
			// WarpBombDelayLabel
			// 
			this.WarpBombDelayLabel.Location = new System.Drawing.Point(8, 56);
			this.WarpBombDelayLabel.Name = "WarpBombDelayLabel";
			this.WarpBombDelayLabel.Size = new System.Drawing.Size(104, 16);
			this.WarpBombDelayLabel.TabIndex = 5;
			this.WarpBombDelayLabel.Text = "Resonator Delay:";
			this.InfoToolTip.SetToolTip(this.WarpBombDelayLabel, "The number of seconds between a resonator hit and its explosion");
			// 
			// DroneCostTextBox
			// 
			this.DroneCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.DroneCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DroneCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DroneCostTextBox.ForeColor = System.Drawing.Color.White;
			this.DroneCostTextBox.Location = new System.Drawing.Point(272, 88);
			this.DroneCostTextBox.Name = "DroneCostTextBox";
			this.DroneCostTextBox.ReadOnly = true;
			this.DroneCostTextBox.Size = new System.Drawing.Size(48, 14);
			this.DroneCostTextBox.TabIndex = 20;
			this.DroneCostTextBox.Text = "0";
			this.DroneCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.DroneCostTextBox, "The \"Sector Overload\" value of an AI-controlled ship");
			// 
			// DroneCostLabel
			// 
			this.DroneCostLabel.Location = new System.Drawing.Point(176, 88);
			this.DroneCostLabel.Name = "DroneCostLabel";
			this.DroneCostLabel.Size = new System.Drawing.Size(80, 16);
			this.DroneCostLabel.TabIndex = 19;
			this.DroneCostLabel.Text = "Drone Cost:";
			this.InfoToolTip.SetToolTip(this.DroneCostLabel, "The \"Sector Overload\" value of an AI-controlled ship");
			// 
			// TurretCostTextBox
			// 
			this.TurretCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.TurretCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TurretCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TurretCostTextBox.ForeColor = System.Drawing.Color.White;
			this.TurretCostTextBox.Location = new System.Drawing.Point(272, 72);
			this.TurretCostTextBox.Name = "TurretCostTextBox";
			this.TurretCostTextBox.ReadOnly = true;
			this.TurretCostTextBox.Size = new System.Drawing.Size(48, 14);
			this.TurretCostTextBox.TabIndex = 18;
			this.TurretCostTextBox.Text = "0";
			this.TurretCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.TurretCostTextBox, "The \"Sector Overload\" value of a turret");
			// 
			// TurretCostLabel
			// 
			this.TurretCostLabel.Location = new System.Drawing.Point(176, 72);
			this.TurretCostLabel.Name = "TurretCostLabel";
			this.TurretCostLabel.Size = new System.Drawing.Size(72, 16);
			this.TurretCostLabel.TabIndex = 17;
			this.TurretCostLabel.Text = "Turret Cost:";
			this.InfoToolTip.SetToolTip(this.TurretCostLabel, "The \"Sector Overload\" value of a turret");
			// 
			// PlayerCostTextBox
			// 
			this.PlayerCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PlayerCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PlayerCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PlayerCostTextBox.ForeColor = System.Drawing.Color.White;
			this.PlayerCostTextBox.Location = new System.Drawing.Point(272, 56);
			this.PlayerCostTextBox.Name = "PlayerCostTextBox";
			this.PlayerCostTextBox.ReadOnly = true;
			this.PlayerCostTextBox.Size = new System.Drawing.Size(48, 14);
			this.PlayerCostTextBox.TabIndex = 16;
			this.PlayerCostTextBox.Text = "0";
			this.PlayerCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PlayerCostTextBox, "The \"Sector Overload\" value of a pilot");
			// 
			// PlayerCostLabel
			// 
			this.PlayerCostLabel.Location = new System.Drawing.Point(176, 56);
			this.PlayerCostLabel.Name = "PlayerCostLabel";
			this.PlayerCostLabel.Size = new System.Drawing.Size(64, 16);
			this.PlayerCostLabel.TabIndex = 15;
			this.PlayerCostLabel.Text = "Pilot Cost:";
			this.InfoToolTip.SetToolTip(this.PlayerCostLabel, "The \"Sector Overload\" value of a pilot");
			// 
			// LifepodCostTextBox
			// 
			this.LifepodCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LifepodCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LifepodCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LifepodCostTextBox.ForeColor = System.Drawing.Color.White;
			this.LifepodCostTextBox.Location = new System.Drawing.Point(272, 40);
			this.LifepodCostTextBox.Name = "LifepodCostTextBox";
			this.LifepodCostTextBox.ReadOnly = true;
			this.LifepodCostTextBox.Size = new System.Drawing.Size(48, 14);
			this.LifepodCostTextBox.TabIndex = 14;
			this.LifepodCostTextBox.Text = "0";
			this.LifepodCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LifepodCostTextBox, "The \"Sector Overload\" value of a lifepod");
			// 
			// LifepodCostLabel
			// 
			this.LifepodCostLabel.Location = new System.Drawing.Point(176, 40);
			this.LifepodCostLabel.Name = "LifepodCostLabel";
			this.LifepodCostLabel.Size = new System.Drawing.Size(80, 16);
			this.LifepodCostLabel.TabIndex = 13;
			this.LifepodCostLabel.Text = "Lifepod Cost:";
			this.InfoToolTip.SetToolTip(this.LifepodCostLabel, "The \"Sector Overload\" value of a lifepod");
			// 
			// OutofBoundsTextBox
			// 
			this.OutofBoundsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.OutofBoundsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutofBoundsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OutofBoundsTextBox.ForeColor = System.Drawing.Color.White;
			this.OutofBoundsTextBox.Location = new System.Drawing.Point(272, 24);
			this.OutofBoundsTextBox.Name = "OutofBoundsTextBox";
			this.OutofBoundsTextBox.ReadOnly = true;
			this.OutofBoundsTextBox.Size = new System.Drawing.Size(48, 14);
			this.OutofBoundsTextBox.TabIndex = 12;
			this.OutofBoundsTextBox.Text = "0";
			this.OutofBoundsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.OutofBoundsTextBox, "Determines how far from the sector\'s center you can go before going out of bounds" +
				". The square root of this value + SectorRadius gives the out of bounds distance");
			// 
			// OutofBoundsLabel
			// 
			this.OutofBoundsLabel.Location = new System.Drawing.Point(176, 24);
			this.OutofBoundsLabel.Name = "OutofBoundsLabel";
			this.OutofBoundsLabel.Size = new System.Drawing.Size(96, 16);
			this.OutofBoundsLabel.TabIndex = 11;
			this.OutofBoundsLabel.Text = "Out of Bounds:";
			this.InfoToolTip.SetToolTip(this.OutofBoundsLabel, "Determines how far from the sector\'s center you can go before going out of bounds" +
				". The square root of this value + SectorRadius gives the out of bounds distance");
			// 
			// LensMultiplierTextBox
			// 
			this.LensMultiplierTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LensMultiplierTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LensMultiplierTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LensMultiplierTextBox.ForeColor = System.Drawing.Color.White;
			this.LensMultiplierTextBox.Location = new System.Drawing.Point(120, 40);
			this.LensMultiplierTextBox.Name = "LensMultiplierTextBox";
			this.LensMultiplierTextBox.ReadOnly = true;
			this.LensMultiplierTextBox.Size = new System.Drawing.Size(48, 14);
			this.LensMultiplierTextBox.TabIndex = 4;
			this.LensMultiplierTextBox.Text = "0";
			this.LensMultiplierTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LensMultiplierTextBox, "A modifier that determines the distribution of rocks & powerups above and below t" +
				"he center plane");
			// 
			// LensMultiplierLabel
			// 
			this.LensMultiplierLabel.Location = new System.Drawing.Point(8, 40);
			this.LensMultiplierLabel.Name = "LensMultiplierLabel";
			this.LensMultiplierLabel.Size = new System.Drawing.Size(96, 16);
			this.LensMultiplierLabel.TabIndex = 3;
			this.LensMultiplierLabel.Text = "Lens Multiplier:";
			this.InfoToolTip.SetToolTip(this.LensMultiplierLabel, "Determines the size of a sector above and below the center plane");
			// 
			// SectorRadiusTextBox
			// 
			this.SectorRadiusTextBox.BackColor = System.Drawing.Color.Maroon;
			this.SectorRadiusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SectorRadiusTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SectorRadiusTextBox.ForeColor = System.Drawing.Color.White;
			this.SectorRadiusTextBox.Location = new System.Drawing.Point(120, 24);
			this.SectorRadiusTextBox.Name = "SectorRadiusTextBox";
			this.SectorRadiusTextBox.ReadOnly = true;
			this.SectorRadiusTextBox.Size = new System.Drawing.Size(48, 14);
			this.SectorRadiusTextBox.TabIndex = 2;
			this.SectorRadiusTextBox.Text = "0";
			this.SectorRadiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.SectorRadiusTextBox, "The distance from the center of the sector to the outer edge");
			// 
			// SectorRadiusLabel
			// 
			this.SectorRadiusLabel.Location = new System.Drawing.Point(8, 24);
			this.SectorRadiusLabel.Name = "SectorRadiusLabel";
			this.SectorRadiusLabel.Size = new System.Drawing.Size(112, 16);
			this.SectorRadiusLabel.TabIndex = 1;
			this.SectorRadiusLabel.Text = "Sector Radius (m):";
			this.InfoToolTip.SetToolTip(this.SectorRadiusLabel, "The distance from the center of the sector to the outer edge");
			// 
			// SectorLabel
			// 
			this.SectorLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.SectorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SectorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.SectorLabel.Location = new System.Drawing.Point(0, 5);
			this.SectorLabel.Name = "SectorLabel";
			this.SectorLabel.Size = new System.Drawing.Size(325, 16);
			this.SectorLabel.TabIndex = 0;
			this.SectorLabel.Text = "Sector";
			// 
			// PointsTechTextBox
			// 
			this.PointsTechTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsTechTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsTechTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsTechTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsTechTextBox.Location = new System.Drawing.Point(448, 88);
			this.PointsTechTextBox.Name = "PointsTechTextBox";
			this.PointsTechTextBox.ReadOnly = true;
			this.PointsTechTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsTechTextBox.TabIndex = 26;
			this.PointsTechTextBox.Text = "0";
			this.PointsTechTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsTechTextBox, "The points earned for docking unresearched technology in base");
			// 
			// PointsAsteroidTextBox
			// 
			this.PointsAsteroidTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsAsteroidTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsAsteroidTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsAsteroidTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsAsteroidTextBox.Location = new System.Drawing.Point(120, 40);
			this.PointsAsteroidTextBox.Name = "PointsAsteroidTextBox";
			this.PointsAsteroidTextBox.ReadOnly = true;
			this.PointsAsteroidTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsAsteroidTextBox.TabIndex = 4;
			this.PointsAsteroidTextBox.Text = "0";
			this.PointsAsteroidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsAsteroidTextBox, "The points earned for spotting an Tech Rock");
			// 
			// PointsAlephTextBox
			// 
			this.PointsAlephTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsAlephTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsAlephTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsAlephTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsAlephTextBox.Location = new System.Drawing.Point(120, 24);
			this.PointsAlephTextBox.Name = "PointsAlephTextBox";
			this.PointsAlephTextBox.ReadOnly = true;
			this.PointsAlephTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsAlephTextBox.TabIndex = 2;
			this.PointsAlephTextBox.Text = "0";
			this.PointsAlephTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsAlephTextBox, "The points earned for spotting an aleph");
			// 
			// PointsMinerTextBox
			// 
			this.PointsMinerTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsMinerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsMinerTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsMinerTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsMinerTextBox.Location = new System.Drawing.Point(448, 24);
			this.PointsMinerTextBox.Name = "PointsMinerTextBox";
			this.PointsMinerTextBox.ReadOnly = true;
			this.PointsMinerTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsMinerTextBox.TabIndex = 18;
			this.PointsMinerTextBox.Text = "0";
			this.PointsMinerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsMinerTextBox, "The points earned for killing a miner");
			// 
			// PointsBuilderTextBox
			// 
			this.PointsBuilderTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsBuilderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsBuilderTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsBuilderTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsBuilderTextBox.Location = new System.Drawing.Point(448, 40);
			this.PointsBuilderTextBox.Name = "PointsBuilderTextBox";
			this.PointsBuilderTextBox.ReadOnly = true;
			this.PointsBuilderTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsBuilderTextBox.TabIndex = 20;
			this.PointsBuilderTextBox.Text = "0";
			this.PointsBuilderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsBuilderTextBox, "The points earned for killing a constructor");
			// 
			// PointsLayerTextBox
			// 
			this.PointsLayerTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsLayerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsLayerTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsLayerTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsLayerTextBox.Location = new System.Drawing.Point(448, 56);
			this.PointsLayerTextBox.Name = "PointsLayerTextBox";
			this.PointsLayerTextBox.ReadOnly = true;
			this.PointsLayerTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsLayerTextBox.TabIndex = 22;
			this.PointsLayerTextBox.Text = "0";
			this.PointsLayerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsLayerTextBox, "The points earned for destroying a Mine Layer");
			// 
			// PointsCarrierTextBox
			// 
			this.PointsCarrierTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsCarrierTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsCarrierTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsCarrierTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsCarrierTextBox.Location = new System.Drawing.Point(448, 72);
			this.PointsCarrierTextBox.Name = "PointsCarrierTextBox";
			this.PointsCarrierTextBox.ReadOnly = true;
			this.PointsCarrierTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsCarrierTextBox.TabIndex = 24;
			this.PointsCarrierTextBox.Text = "0";
			this.PointsCarrierTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsCarrierTextBox, "The points earned for destroying a Carrier");
			// 
			// PointsPilotTextBox
			// 
			this.PointsPilotTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsPilotTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsPilotTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsPilotTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsPilotTextBox.Location = new System.Drawing.Point(272, 24);
			this.PointsPilotTextBox.Name = "PointsPilotTextBox";
			this.PointsPilotTextBox.ReadOnly = true;
			this.PointsPilotTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsPilotTextBox.TabIndex = 10;
			this.PointsPilotTextBox.Text = "0";
			this.PointsPilotTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsPilotTextBox, "The points earned for causing a pilot to eject");
			// 
			// PointsBaseKillTextBox
			// 
			this.PointsBaseKillTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsBaseKillTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsBaseKillTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsBaseKillTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsBaseKillTextBox.Location = new System.Drawing.Point(272, 40);
			this.PointsBaseKillTextBox.Name = "PointsBaseKillTextBox";
			this.PointsBaseKillTextBox.ReadOnly = true;
			this.PointsBaseKillTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsBaseKillTextBox.TabIndex = 12;
			this.PointsBaseKillTextBox.Text = "0";
			this.PointsBaseKillTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsBaseKillTextBox, "The points earned for destroying a Station");
			// 
			// PointsBaseCaptureTextBox
			// 
			this.PointsBaseCaptureTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsBaseCaptureTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsBaseCaptureTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsBaseCaptureTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsBaseCaptureTextBox.Location = new System.Drawing.Point(272, 56);
			this.PointsBaseCaptureTextBox.Name = "PointsBaseCaptureTextBox";
			this.PointsBaseCaptureTextBox.ReadOnly = true;
			this.PointsBaseCaptureTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsBaseCaptureTextBox.TabIndex = 14;
			this.PointsBaseCaptureTextBox.Text = "0";
			this.PointsBaseCaptureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsBaseCaptureTextBox, "The points earned for capturing a station");
			// 
			// PointsFlagTextBox
			// 
			this.PointsFlagTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsFlagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsFlagTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsFlagTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsFlagTextBox.Location = new System.Drawing.Point(120, 56);
			this.PointsFlagTextBox.Name = "PointsFlagTextBox";
			this.PointsFlagTextBox.ReadOnly = true;
			this.PointsFlagTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsFlagTextBox.TabIndex = 6;
			this.PointsFlagTextBox.Text = "0";
			this.PointsFlagTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsFlagTextBox, "The points earned for capturing a flag");
			// 
			// PointsArtifactTextBox
			// 
			this.PointsArtifactTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsArtifactTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsArtifactTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsArtifactTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsArtifactTextBox.Location = new System.Drawing.Point(120, 72);
			this.PointsArtifactTextBox.Name = "PointsArtifactTextBox";
			this.PointsArtifactTextBox.ReadOnly = true;
			this.PointsArtifactTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsArtifactTextBox.TabIndex = 8;
			this.PointsArtifactTextBox.Text = "0";
			this.PointsArtifactTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsArtifactTextBox, "The points earned for picking up an artifact");
			// 
			// PointsRescueTextBox
			// 
			this.PointsRescueTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PointsRescueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PointsRescueTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsRescueTextBox.ForeColor = System.Drawing.Color.White;
			this.PointsRescueTextBox.Location = new System.Drawing.Point(272, 72);
			this.PointsRescueTextBox.Name = "PointsRescueTextBox";
			this.PointsRescueTextBox.ReadOnly = true;
			this.PointsRescueTextBox.Size = new System.Drawing.Size(48, 14);
			this.PointsRescueTextBox.TabIndex = 16;
			this.PointsRescueTextBox.Text = "0";
			this.PointsRescueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PointsRescueTextBox, "The points earned for rescuing a lifepod");
			// 
			// AmountHe3TextBox
			// 
			this.AmountHe3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AmountHe3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AmountHe3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AmountHe3TextBox.ForeColor = System.Drawing.Color.White;
			this.AmountHe3TextBox.Location = new System.Drawing.Point(120, 56);
			this.AmountHe3TextBox.Name = "AmountHe3TextBox";
			this.AmountHe3TextBox.ReadOnly = true;
			this.AmountHe3TextBox.Size = new System.Drawing.Size(48, 14);
			this.AmountHe3TextBox.TabIndex = 6;
			this.AmountHe3TextBox.Text = "0";
			this.AmountHe3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.AmountHe3TextBox, "The default amount of Helium³ on the map, divided by the total # of teams");
			// 
			// ValueHe3TextBox
			// 
			this.ValueHe3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.ValueHe3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ValueHe3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ValueHe3TextBox.ForeColor = System.Drawing.Color.White;
			this.ValueHe3TextBox.Location = new System.Drawing.Point(120, 40);
			this.ValueHe3TextBox.Name = "ValueHe3TextBox";
			this.ValueHe3TextBox.ReadOnly = true;
			this.ValueHe3TextBox.Size = new System.Drawing.Size(48, 14);
			this.ValueHe3TextBox.TabIndex = 4;
			this.ValueHe3TextBox.Text = "0";
			this.ValueHe3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ValueHe3TextBox, "The value (in credits) of each unit of Helium³");
			// 
			// CapacityHe3TextBox
			// 
			this.CapacityHe3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.CapacityHe3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CapacityHe3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CapacityHe3TextBox.ForeColor = System.Drawing.Color.White;
			this.CapacityHe3TextBox.Location = new System.Drawing.Point(120, 24);
			this.CapacityHe3TextBox.Name = "CapacityHe3TextBox";
			this.CapacityHe3TextBox.ReadOnly = true;
			this.CapacityHe3TextBox.Size = new System.Drawing.Size(48, 14);
			this.CapacityHe3TextBox.TabIndex = 2;
			this.CapacityHe3TextBox.Text = "0";
			this.CapacityHe3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.CapacityHe3TextBox, "The default amount of Helium³ a miner can hold");
			// 
			// He3RegenerationTextBox
			// 
			this.He3RegenerationTextBox.BackColor = System.Drawing.Color.Maroon;
			this.He3RegenerationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.He3RegenerationTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.He3RegenerationTextBox.ForeColor = System.Drawing.Color.White;
			this.He3RegenerationTextBox.Location = new System.Drawing.Point(120, 72);
			this.He3RegenerationTextBox.Name = "He3RegenerationTextBox";
			this.He3RegenerationTextBox.ReadOnly = true;
			this.He3RegenerationTextBox.Size = new System.Drawing.Size(48, 14);
			this.He3RegenerationTextBox.TabIndex = 8;
			this.He3RegenerationTextBox.Text = "0";
			this.He3RegenerationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.He3RegenerationTextBox, "The rate at which Helium³ regenerates per rock");
			// 
			// RipcordTimeTextBox
			// 
			this.RipcordTimeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RipcordTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RipcordTimeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipcordTimeTextBox.ForeColor = System.Drawing.Color.White;
			this.RipcordTimeTextBox.Location = new System.Drawing.Point(120, 72);
			this.RipcordTimeTextBox.Name = "RipcordTimeTextBox";
			this.RipcordTimeTextBox.ReadOnly = true;
			this.RipcordTimeTextBox.Size = new System.Drawing.Size(48, 14);
			this.RipcordTimeTextBox.TabIndex = 8;
			this.RipcordTimeTextBox.Text = "0";
			this.RipcordTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RipcordTimeTextBox, "The default length of time for a ship to ripcord");
			// 
			// DownedShieldTextBox
			// 
			this.DownedShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.DownedShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DownedShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DownedShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.DownedShieldTextBox.Location = new System.Drawing.Point(120, 56);
			this.DownedShieldTextBox.Name = "DownedShieldTextBox";
			this.DownedShieldTextBox.ReadOnly = true;
			this.DownedShieldTextBox.Size = new System.Drawing.Size(48, 14);
			this.DownedShieldTextBox.TabIndex = 6;
			this.DownedShieldTextBox.Text = "0";
			this.DownedShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.DownedShieldTextBox, "The amount of time without damage before a shield starts regenerating");
			// 
			// ExitStationSpeedTextBox
			// 
			this.ExitStationSpeedTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ExitStationSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ExitStationSpeedTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ExitStationSpeedTextBox.ForeColor = System.Drawing.Color.White;
			this.ExitStationSpeedTextBox.Location = new System.Drawing.Point(120, 40);
			this.ExitStationSpeedTextBox.Name = "ExitStationSpeedTextBox";
			this.ExitStationSpeedTextBox.ReadOnly = true;
			this.ExitStationSpeedTextBox.Size = new System.Drawing.Size(48, 14);
			this.ExitStationSpeedTextBox.TabIndex = 4;
			this.ExitStationSpeedTextBox.Text = "0";
			this.ExitStationSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ExitStationSpeedTextBox, "The speed a ship travels when launching from a station");
			// 
			// ExitWarpSpeedTextBox
			// 
			this.ExitWarpSpeedTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ExitWarpSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ExitWarpSpeedTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ExitWarpSpeedTextBox.ForeColor = System.Drawing.Color.White;
			this.ExitWarpSpeedTextBox.Location = new System.Drawing.Point(120, 24);
			this.ExitWarpSpeedTextBox.Name = "ExitWarpSpeedTextBox";
			this.ExitWarpSpeedTextBox.ReadOnly = true;
			this.ExitWarpSpeedTextBox.Size = new System.Drawing.Size(48, 14);
			this.ExitWarpSpeedTextBox.TabIndex = 2;
			this.ExitWarpSpeedTextBox.Text = "0";
			this.ExitWarpSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ExitWarpSpeedTextBox, "The speed increase applied to a ship passing through an aleph");
			// 
			// MountRateTextBox
			// 
			this.MountRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MountRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MountRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MountRateTextBox.ForeColor = System.Drawing.Color.White;
			this.MountRateTextBox.Location = new System.Drawing.Point(272, 24);
			this.MountRateTextBox.Name = "MountRateTextBox";
			this.MountRateTextBox.ReadOnly = true;
			this.MountRateTextBox.Size = new System.Drawing.Size(48, 14);
			this.MountRateTextBox.TabIndex = 10;
			this.MountRateTextBox.Text = "0";
			this.MountRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.MountRateTextBox, "The default amount of time it takes to mount a weapon");
			// 
			// LifepodEnduranceTextBox
			// 
			this.LifepodEnduranceTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LifepodEnduranceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LifepodEnduranceTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LifepodEnduranceTextBox.ForeColor = System.Drawing.Color.White;
			this.LifepodEnduranceTextBox.Location = new System.Drawing.Point(272, 40);
			this.LifepodEnduranceTextBox.Name = "LifepodEnduranceTextBox";
			this.LifepodEnduranceTextBox.ReadOnly = true;
			this.LifepodEnduranceTextBox.Size = new System.Drawing.Size(48, 14);
			this.LifepodEnduranceTextBox.TabIndex = 12;
			this.LifepodEnduranceTextBox.Text = "0";
			this.LifepodEnduranceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LifepodEnduranceTextBox, "The number of seconds worth of O² in lifepods");
			// 
			// IncomeTextBox
			// 
			this.IncomeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.IncomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.IncomeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IncomeTextBox.ForeColor = System.Drawing.Color.White;
			this.IncomeTextBox.Location = new System.Drawing.Point(120, 56);
			this.IncomeTextBox.Name = "IncomeTextBox";
			this.IncomeTextBox.ReadOnly = true;
			this.IncomeTextBox.Size = new System.Drawing.Size(48, 14);
			this.IncomeTextBox.TabIndex = 6;
			this.IncomeTextBox.Text = "0";
			this.IncomeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.IncomeTextBox, "The number of credits earned per player each payday");
			// 
			// WinTheGameMoneyTextBox
			// 
			this.WinTheGameMoneyTextBox.BackColor = System.Drawing.Color.Maroon;
			this.WinTheGameMoneyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WinTheGameMoneyTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WinTheGameMoneyTextBox.ForeColor = System.Drawing.Color.White;
			this.WinTheGameMoneyTextBox.Location = new System.Drawing.Point(120, 72);
			this.WinTheGameMoneyTextBox.Name = "WinTheGameMoneyTextBox";
			this.WinTheGameMoneyTextBox.ReadOnly = true;
			this.WinTheGameMoneyTextBox.Size = new System.Drawing.Size(48, 14);
			this.WinTheGameMoneyTextBox.TabIndex = 8;
			this.WinTheGameMoneyTextBox.Text = "0";
			this.WinTheGameMoneyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.WinTheGameMoneyTextBox, "The amount of credits required to declare a win when in Prosperity mode");
			// 
			// StartingMoneyTextBox
			// 
			this.StartingMoneyTextBox.BackColor = System.Drawing.Color.Maroon;
			this.StartingMoneyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.StartingMoneyTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.StartingMoneyTextBox.ForeColor = System.Drawing.Color.White;
			this.StartingMoneyTextBox.Location = new System.Drawing.Point(120, 24);
			this.StartingMoneyTextBox.Name = "StartingMoneyTextBox";
			this.StartingMoneyTextBox.ReadOnly = true;
			this.StartingMoneyTextBox.Size = new System.Drawing.Size(48, 14);
			this.StartingMoneyTextBox.TabIndex = 2;
			this.StartingMoneyTextBox.Text = "0";
			this.StartingMoneyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.StartingMoneyTextBox, "The default amount of credits awarded to a team at game start");
			// 
			// SecondsBetweenPaydaysTextBox
			// 
			this.SecondsBetweenPaydaysTextBox.BackColor = System.Drawing.Color.Maroon;
			this.SecondsBetweenPaydaysTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SecondsBetweenPaydaysTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SecondsBetweenPaydaysTextBox.ForeColor = System.Drawing.Color.White;
			this.SecondsBetweenPaydaysTextBox.Location = new System.Drawing.Point(120, 40);
			this.SecondsBetweenPaydaysTextBox.Name = "SecondsBetweenPaydaysTextBox";
			this.SecondsBetweenPaydaysTextBox.ReadOnly = true;
			this.SecondsBetweenPaydaysTextBox.Size = new System.Drawing.Size(48, 14);
			this.SecondsBetweenPaydaysTextBox.TabIndex = 4;
			this.SecondsBetweenPaydaysTextBox.Text = "0";
			this.SecondsBetweenPaydaysTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.SecondsBetweenPaydaysTextBox, "The number of seconds between paydays");
			// 
			// RatingAddTextBox
			// 
			this.RatingAddTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RatingAddTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RatingAddTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RatingAddTextBox.ForeColor = System.Drawing.Color.White;
			this.RatingAddTextBox.Location = new System.Drawing.Point(272, 56);
			this.RatingAddTextBox.Name = "RatingAddTextBox";
			this.RatingAddTextBox.ReadOnly = true;
			this.RatingAddTextBox.Size = new System.Drawing.Size(48, 14);
			this.RatingAddTextBox.TabIndex = 14;
			this.RatingAddTextBox.Text = "0";
			this.RatingAddTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RatingAddTextBox, "Used when calculating Kill Bonuses. CurrentBonus + RatingAdd");
			// 
			// RatingDivideTextBox
			// 
			this.RatingDivideTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RatingDivideTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RatingDivideTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RatingDivideTextBox.ForeColor = System.Drawing.Color.White;
			this.RatingDivideTextBox.Location = new System.Drawing.Point(272, 72);
			this.RatingDivideTextBox.Name = "RatingDivideTextBox";
			this.RatingDivideTextBox.ReadOnly = true;
			this.RatingDivideTextBox.Size = new System.Drawing.Size(48, 14);
			this.RatingDivideTextBox.TabIndex = 16;
			this.RatingDivideTextBox.Text = "0";
			this.RatingDivideTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RatingDivideTextBox, "Used when calculating kill bonuses");
			// 
			// UnknownTextBox
			// 
			this.UnknownTextBox.BackColor = System.Drawing.Color.Maroon;
			this.UnknownTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UnknownTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UnknownTextBox.ForeColor = System.Drawing.Color.White;
			this.UnknownTextBox.Location = new System.Drawing.Point(120, 88);
			this.UnknownTextBox.Name = "UnknownTextBox";
			this.UnknownTextBox.ReadOnly = true;
			this.UnknownTextBox.Size = new System.Drawing.Size(48, 14);
			this.UnknownTextBox.TabIndex = 28;
			this.UnknownTextBox.Text = "0";
			this.UnknownTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.UnknownTextBox, "UNKNOWN! (Unused?)");
			// 
			// PointsRescueLabel
			// 
			this.PointsRescueLabel.Location = new System.Drawing.Point(176, 72);
			this.PointsRescueLabel.Name = "PointsRescueLabel";
			this.PointsRescueLabel.Size = new System.Drawing.Size(96, 16);
			this.PointsRescueLabel.TabIndex = 15;
			this.PointsRescueLabel.Text = "Rescue Lifepod:";
			this.InfoToolTip.SetToolTip(this.PointsRescueLabel, "The points earned for rescuing a lifepod");
			// 
			// PointsArtifactLabel
			// 
			this.PointsArtifactLabel.Location = new System.Drawing.Point(8, 72);
			this.PointsArtifactLabel.Name = "PointsArtifactLabel";
			this.PointsArtifactLabel.Size = new System.Drawing.Size(88, 16);
			this.PointsArtifactLabel.TabIndex = 7;
			this.PointsArtifactLabel.Text = "Grab Artifact:";
			this.InfoToolTip.SetToolTip(this.PointsArtifactLabel, "The points earned for picking up an artifact");
			// 
			// PointsFlagLabel
			// 
			this.PointsFlagLabel.Location = new System.Drawing.Point(8, 56);
			this.PointsFlagLabel.Name = "PointsFlagLabel";
			this.PointsFlagLabel.Size = new System.Drawing.Size(88, 16);
			this.PointsFlagLabel.TabIndex = 5;
			this.PointsFlagLabel.Text = "Capture Flag:";
			this.InfoToolTip.SetToolTip(this.PointsFlagLabel, "The points earned for capturing a flag");
			// 
			// PointsBaseCaptureLabel
			// 
			this.PointsBaseCaptureLabel.Location = new System.Drawing.Point(176, 56);
			this.PointsBaseCaptureLabel.Name = "PointsBaseCaptureLabel";
			this.PointsBaseCaptureLabel.Size = new System.Drawing.Size(104, 16);
			this.PointsBaseCaptureLabel.TabIndex = 13;
			this.PointsBaseCaptureLabel.Text = "Capture Station:";
			this.InfoToolTip.SetToolTip(this.PointsBaseCaptureLabel, "The points earned for capturing a station");
			// 
			// PointsBaseKillLabel
			// 
			this.PointsBaseKillLabel.Location = new System.Drawing.Point(176, 40);
			this.PointsBaseKillLabel.Name = "PointsBaseKillLabel";
			this.PointsBaseKillLabel.Size = new System.Drawing.Size(104, 16);
			this.PointsBaseKillLabel.TabIndex = 11;
			this.PointsBaseKillLabel.Text = "Destroy Station:";
			this.InfoToolTip.SetToolTip(this.PointsBaseKillLabel, "The points earned for destroying a Station");
			// 
			// PointsPilotLabel
			// 
			this.PointsPilotLabel.Location = new System.Drawing.Point(176, 24);
			this.PointsPilotLabel.Name = "PointsPilotLabel";
			this.PointsPilotLabel.Size = new System.Drawing.Size(72, 16);
			this.PointsPilotLabel.TabIndex = 9;
			this.PointsPilotLabel.Text = "Eject Pilot:";
			this.InfoToolTip.SetToolTip(this.PointsPilotLabel, "The points earned for causing a pilot to eject");
			// 
			// PointsCarrierLabel
			// 
			this.PointsCarrierLabel.Location = new System.Drawing.Point(336, 72);
			this.PointsCarrierLabel.Name = "PointsCarrierLabel";
			this.PointsCarrierLabel.Size = new System.Drawing.Size(96, 16);
			this.PointsCarrierLabel.TabIndex = 23;
			this.PointsCarrierLabel.Text = "Destroy Carrier:";
			this.InfoToolTip.SetToolTip(this.PointsCarrierLabel, "The points earned for destroying a Carrier");
			// 
			// PointsLayerLabel
			// 
			this.PointsLayerLabel.Location = new System.Drawing.Point(336, 56);
			this.PointsLayerLabel.Name = "PointsLayerLabel";
			this.PointsLayerLabel.Size = new System.Drawing.Size(88, 16);
			this.PointsLayerLabel.TabIndex = 21;
			this.PointsLayerLabel.Text = "Destroy Layer:";
			this.InfoToolTip.SetToolTip(this.PointsLayerLabel, "The points earned for destroying a Mine Layer");
			// 
			// DestroyConstructorLabel
			// 
			this.DestroyConstructorLabel.Location = new System.Drawing.Point(336, 40);
			this.DestroyConstructorLabel.Name = "DestroyConstructorLabel";
			this.DestroyConstructorLabel.Size = new System.Drawing.Size(104, 16);
			this.DestroyConstructorLabel.TabIndex = 19;
			this.DestroyConstructorLabel.Text = "Destroy Builder:";
			this.InfoToolTip.SetToolTip(this.DestroyConstructorLabel, "The points earned for killing a constructor");
			// 
			// PointsMinerLabel
			// 
			this.PointsMinerLabel.Location = new System.Drawing.Point(336, 24);
			this.PointsMinerLabel.Name = "PointsMinerLabel";
			this.PointsMinerLabel.Size = new System.Drawing.Size(88, 16);
			this.PointsMinerLabel.TabIndex = 17;
			this.PointsMinerLabel.Text = "Destroy Miner:";
			this.InfoToolTip.SetToolTip(this.PointsMinerLabel, "The points earned for killing a miner");
			// 
			// PointsTechLabel
			// 
			this.PointsTechLabel.Location = new System.Drawing.Point(336, 88);
			this.PointsTechLabel.Name = "PointsTechLabel";
			this.PointsTechLabel.Size = new System.Drawing.Size(104, 16);
			this.PointsTechLabel.TabIndex = 25;
			this.PointsTechLabel.Text = "Assimilate Tech:";
			this.InfoToolTip.SetToolTip(this.PointsTechLabel, "The points earned for docking unresearched technology in base");
			// 
			// PointsAsteroidLabel
			// 
			this.PointsAsteroidLabel.Location = new System.Drawing.Point(8, 40);
			this.PointsAsteroidLabel.Name = "PointsAsteroidLabel";
			this.PointsAsteroidLabel.Size = new System.Drawing.Size(96, 16);
			this.PointsAsteroidLabel.TabIndex = 3;
			this.PointsAsteroidLabel.Text = "Spot TechRock:";
			this.InfoToolTip.SetToolTip(this.PointsAsteroidLabel, "The points earned for spotting an Tech Rock");
			// 
			// PointsAlephLabel
			// 
			this.PointsAlephLabel.Location = new System.Drawing.Point(8, 24);
			this.PointsAlephLabel.Name = "PointsAlephLabel";
			this.PointsAlephLabel.Size = new System.Drawing.Size(80, 16);
			this.PointsAlephLabel.TabIndex = 1;
			this.PointsAlephLabel.Text = "Spot Aleph:";
			this.InfoToolTip.SetToolTip(this.PointsAlephLabel, "The points earned for spotting an aleph");
			// 
			// UnknownLabel
			// 
			this.UnknownLabel.Location = new System.Drawing.Point(8, 88);
			this.UnknownLabel.Name = "UnknownLabel";
			this.UnknownLabel.Size = new System.Drawing.Size(72, 16);
			this.UnknownLabel.TabIndex = 27;
			this.UnknownLabel.Text = "UNKNOWN:";
			this.InfoToolTip.SetToolTip(this.UnknownLabel, "UNKNOWN! (Unused?)");
			// 
			// He3RegenerationLabel
			// 
			this.He3RegenerationLabel.Location = new System.Drawing.Point(8, 72);
			this.He3RegenerationLabel.Name = "He3RegenerationLabel";
			this.He3RegenerationLabel.Size = new System.Drawing.Size(112, 16);
			this.He3RegenerationLabel.TabIndex = 7;
			this.He3RegenerationLabel.Text = "He³ Regeneration:";
			this.InfoToolTip.SetToolTip(this.He3RegenerationLabel, "The rate at which Helium³ regenerates per rock");
			// 
			// AmountHe3Label
			// 
			this.AmountHe3Label.Location = new System.Drawing.Point(8, 56);
			this.AmountHe3Label.Name = "AmountHe3Label";
			this.AmountHe3Label.Size = new System.Drawing.Size(96, 16);
			this.AmountHe3Label.TabIndex = 5;
			this.AmountHe3Label.Text = "He³ on Map:";
			this.InfoToolTip.SetToolTip(this.AmountHe3Label, "The default amount of Helium³ on the map, divided by the total # of teams");
			// 
			// ValueHe3Label
			// 
			this.ValueHe3Label.Location = new System.Drawing.Point(8, 40);
			this.ValueHe3Label.Name = "ValueHe3Label";
			this.ValueHe3Label.Size = new System.Drawing.Size(120, 16);
			this.ValueHe3Label.TabIndex = 3;
			this.ValueHe3Label.Text = "Helium³ Value (cr):";
			this.InfoToolTip.SetToolTip(this.ValueHe3Label, "The value (in credits) of each unit of Helium³");
			// 
			// CapacityHe3Label
			// 
			this.CapacityHe3Label.Location = new System.Drawing.Point(8, 24);
			this.CapacityHe3Label.Name = "CapacityHe3Label";
			this.CapacityHe3Label.Size = new System.Drawing.Size(96, 16);
			this.CapacityHe3Label.TabIndex = 1;
			this.CapacityHe3Label.Text = "Miner Capacity:";
			this.InfoToolTip.SetToolTip(this.CapacityHe3Label, "The default amount of Helium³ a miner can hold");
			// 
			// RatingDivideLabel
			// 
			this.RatingDivideLabel.Location = new System.Drawing.Point(176, 72);
			this.RatingDivideLabel.Name = "RatingDivideLabel";
			this.RatingDivideLabel.Size = new System.Drawing.Size(88, 16);
			this.RatingDivideLabel.TabIndex = 15;
			this.RatingDivideLabel.Text = "Rating Divide:";
			this.InfoToolTip.SetToolTip(this.RatingDivideLabel, "Used when calculating kill bonuses");
			// 
			// RatingAddLabel
			// 
			this.RatingAddLabel.Location = new System.Drawing.Point(176, 56);
			this.RatingAddLabel.Name = "RatingAddLabel";
			this.RatingAddLabel.Size = new System.Drawing.Size(72, 16);
			this.RatingAddLabel.TabIndex = 13;
			this.RatingAddLabel.Text = "Rating Add:";
			this.InfoToolTip.SetToolTip(this.RatingAddLabel, "Used when calculating Kill Bonuses. CurrentBonus + RatingAdd");
			// 
			// LifepodEnduranceLabel
			// 
			this.LifepodEnduranceLabel.Location = new System.Drawing.Point(176, 40);
			this.LifepodEnduranceLabel.Name = "LifepodEnduranceLabel";
			this.LifepodEnduranceLabel.Size = new System.Drawing.Size(88, 16);
			this.LifepodEnduranceLabel.TabIndex = 11;
			this.LifepodEnduranceLabel.Text = "Lifepod O² (s):";
			this.InfoToolTip.SetToolTip(this.LifepodEnduranceLabel, "The number of seconds worth of O² in lifepods");
			// 
			// MountRateLabel
			// 
			this.MountRateLabel.Location = new System.Drawing.Point(176, 24);
			this.MountRateLabel.Name = "MountRateLabel";
			this.MountRateLabel.Size = new System.Drawing.Size(96, 16);
			this.MountRateLabel.TabIndex = 9;
			this.MountRateLabel.Text = "Mount Rate (s):";
			this.InfoToolTip.SetToolTip(this.MountRateLabel, "The default amount of time it takes to mount a weapon");
			// 
			// RipcordTimeLabel
			// 
			this.RipcordTimeLabel.Location = new System.Drawing.Point(8, 72);
			this.RipcordTimeLabel.Name = "RipcordTimeLabel";
			this.RipcordTimeLabel.Size = new System.Drawing.Size(104, 16);
			this.RipcordTimeLabel.TabIndex = 7;
			this.RipcordTimeLabel.Text = "Ripcord Time (s):";
			this.InfoToolTip.SetToolTip(this.RipcordTimeLabel, "The default length of time for a ship to ripcord");
			// 
			// DownedShieldLabel
			// 
			this.DownedShieldLabel.Location = new System.Drawing.Point(8, 56);
			this.DownedShieldLabel.Name = "DownedShieldLabel";
			this.DownedShieldLabel.Size = new System.Drawing.Size(120, 16);
			this.DownedShieldLabel.TabIndex = 5;
			this.DownedShieldLabel.Text = "Downed Shield (s):";
			this.InfoToolTip.SetToolTip(this.DownedShieldLabel, "The amount of time without damage before a shield starts regenerating");
			// 
			// ExitStationSpeedLabel
			// 
			this.ExitStationSpeedLabel.Location = new System.Drawing.Point(8, 40);
			this.ExitStationSpeedLabel.Name = "ExitStationSpeedLabel";
			this.ExitStationSpeedLabel.Size = new System.Drawing.Size(120, 16);
			this.ExitStationSpeedLabel.TabIndex = 3;
			this.ExitStationSpeedLabel.Text = "Station Exit Speed:";
			this.InfoToolTip.SetToolTip(this.ExitStationSpeedLabel, "The speed a ship travels when launching from a station");
			// 
			// ExitWarpSpeedLabel
			// 
			this.ExitWarpSpeedLabel.Location = new System.Drawing.Point(8, 24);
			this.ExitWarpSpeedLabel.Name = "ExitWarpSpeedLabel";
			this.ExitWarpSpeedLabel.Size = new System.Drawing.Size(104, 16);
			this.ExitWarpSpeedLabel.TabIndex = 1;
			this.ExitWarpSpeedLabel.Text = "Aleph Exit Speed:";
			this.InfoToolTip.SetToolTip(this.ExitWarpSpeedLabel, "The speed increase applied to a ship passing through an aleph");
			// 
			// IncomeLabel
			// 
			this.IncomeLabel.Location = new System.Drawing.Point(8, 56);
			this.IncomeLabel.Name = "IncomeLabel";
			this.IncomeLabel.Size = new System.Drawing.Size(120, 16);
			this.IncomeLabel.TabIndex = 5;
			this.IncomeLabel.Text = "Income per Player:";
			this.InfoToolTip.SetToolTip(this.IncomeLabel, "The number of credits earned per player each payday");
			// 
			// WinTheGameMoneyLabel
			// 
			this.WinTheGameMoneyLabel.Location = new System.Drawing.Point(8, 72);
			this.WinTheGameMoneyLabel.Name = "WinTheGameMoneyLabel";
			this.WinTheGameMoneyLabel.Size = new System.Drawing.Size(120, 16);
			this.WinTheGameMoneyLabel.TabIndex = 7;
			this.WinTheGameMoneyLabel.Text = "Prosperity Amount:";
			this.InfoToolTip.SetToolTip(this.WinTheGameMoneyLabel, "The amount of credits required to declare a win when in Prosperity mode");
			// 
			// SecondsBetweenPaydaysLabel
			// 
			this.SecondsBetweenPaydaysLabel.Location = new System.Drawing.Point(8, 40);
			this.SecondsBetweenPaydaysLabel.Name = "SecondsBetweenPaydaysLabel";
			this.SecondsBetweenPaydaysLabel.Size = new System.Drawing.Size(96, 16);
			this.SecondsBetweenPaydaysLabel.TabIndex = 3;
			this.SecondsBetweenPaydaysLabel.Text = "Payday Period:";
			this.InfoToolTip.SetToolTip(this.SecondsBetweenPaydaysLabel, "The number of seconds between paydays");
			// 
			// StartingMoneyLabel
			// 
			this.StartingMoneyLabel.Location = new System.Drawing.Point(8, 24);
			this.StartingMoneyLabel.Name = "StartingMoneyLabel";
			this.StartingMoneyLabel.Size = new System.Drawing.Size(104, 16);
			this.StartingMoneyLabel.TabIndex = 1;
			this.StartingMoneyLabel.Text = "Starting Credits:";
			this.InfoToolTip.SetToolTip(this.StartingMoneyLabel, "The default amount of credits awarded to a team at game start");
			// 
			// PointsPanel
			// 
			this.PointsPanel.Controls.Add(this.PointsRescueTextBox);
			this.PointsPanel.Controls.Add(this.PointsRescueLabel);
			this.PointsPanel.Controls.Add(this.PointsArtifactTextBox);
			this.PointsPanel.Controls.Add(this.PointsArtifactLabel);
			this.PointsPanel.Controls.Add(this.PointsFlagTextBox);
			this.PointsPanel.Controls.Add(this.PointsFlagLabel);
			this.PointsPanel.Controls.Add(this.PointsBaseCaptureTextBox);
			this.PointsPanel.Controls.Add(this.PointsBaseCaptureLabel);
			this.PointsPanel.Controls.Add(this.PointsBaseKillTextBox);
			this.PointsPanel.Controls.Add(this.PointsBaseKillLabel);
			this.PointsPanel.Controls.Add(this.PointsPilotTextBox);
			this.PointsPanel.Controls.Add(this.PointsPilotLabel);
			this.PointsPanel.Controls.Add(this.PointsCarrierTextBox);
			this.PointsPanel.Controls.Add(this.PointsCarrierLabel);
			this.PointsPanel.Controls.Add(this.PointsLayerTextBox);
			this.PointsPanel.Controls.Add(this.PointsLayerLabel);
			this.PointsPanel.Controls.Add(this.PointsBuilderTextBox);
			this.PointsPanel.Controls.Add(this.DestroyConstructorLabel);
			this.PointsPanel.Controls.Add(this.PointsMinerTextBox);
			this.PointsPanel.Controls.Add(this.PointsMinerLabel);
			this.PointsPanel.Controls.Add(this.PointsTechTextBox);
			this.PointsPanel.Controls.Add(this.PointsTechLabel);
			this.PointsPanel.Controls.Add(this.PointsAsteroidTextBox);
			this.PointsPanel.Controls.Add(this.PointsAsteroidLabel);
			this.PointsPanel.Controls.Add(this.PointsAlephTextBox);
			this.PointsPanel.Controls.Add(this.PointsAlephLabel);
			this.PointsPanel.Controls.Add(this.PointsLabel);
			this.PointsPanel.Controls.Add(this.UnknownTextBox);
			this.PointsPanel.Controls.Add(this.UnknownLabel);
			this.PointsPanel.Location = new System.Drawing.Point(0, 192);
			this.PointsPanel.Name = "PointsPanel";
			this.PointsPanel.Size = new System.Drawing.Size(512, 104);
			this.PointsPanel.TabIndex = 2;
			// 
			// PointsLabel
			// 
			this.PointsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.PointsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PointsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.PointsLabel.Location = new System.Drawing.Point(0, 5);
			this.PointsLabel.Name = "PointsLabel";
			this.PointsLabel.Size = new System.Drawing.Size(512, 16);
			this.PointsLabel.TabIndex = 0;
			this.PointsLabel.Text = "Points";
			// 
			// He3Panel
			// 
			this.He3Panel.Controls.Add(this.He3RegenerationTextBox);
			this.He3Panel.Controls.Add(this.He3RegenerationLabel);
			this.He3Panel.Controls.Add(this.AmountHe3TextBox);
			this.He3Panel.Controls.Add(this.AmountHe3Label);
			this.He3Panel.Controls.Add(this.ValueHe3TextBox);
			this.He3Panel.Controls.Add(this.ValueHe3Label);
			this.He3Panel.Controls.Add(this.CapacityHe3TextBox);
			this.He3Panel.Controls.Add(this.CapacityHe3Label);
			this.He3Panel.Controls.Add(this.He3Label);
			this.He3Panel.Location = new System.Drawing.Point(328, 104);
			this.He3Panel.Name = "He3Panel";
			this.He3Panel.Size = new System.Drawing.Size(184, 88);
			this.He3Panel.TabIndex = 4;
			// 
			// He3Label
			// 
			this.He3Label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.He3Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.He3Label.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.He3Label.Location = new System.Drawing.Point(0, 5);
			this.He3Label.Name = "He3Label";
			this.He3Label.Size = new System.Drawing.Size(184, 16);
			this.He3Label.TabIndex = 0;
			this.He3Label.Text = "Helium³";
			// 
			// ShipPanel
			// 
			this.ShipPanel.Controls.Add(this.RatingDivideTextBox);
			this.ShipPanel.Controls.Add(this.RatingDivideLabel);
			this.ShipPanel.Controls.Add(this.RatingAddTextBox);
			this.ShipPanel.Controls.Add(this.RatingAddLabel);
			this.ShipPanel.Controls.Add(this.LifepodEnduranceTextBox);
			this.ShipPanel.Controls.Add(this.LifepodEnduranceLabel);
			this.ShipPanel.Controls.Add(this.MountRateTextBox);
			this.ShipPanel.Controls.Add(this.MountRateLabel);
			this.ShipPanel.Controls.Add(this.RipcordTimeTextBox);
			this.ShipPanel.Controls.Add(this.RipcordTimeLabel);
			this.ShipPanel.Controls.Add(this.DownedShieldTextBox);
			this.ShipPanel.Controls.Add(this.DownedShieldLabel);
			this.ShipPanel.Controls.Add(this.ExitStationSpeedTextBox);
			this.ShipPanel.Controls.Add(this.ExitStationSpeedLabel);
			this.ShipPanel.Controls.Add(this.ExitWarpSpeedTextBox);
			this.ShipPanel.Controls.Add(this.ExitWarpSpeedLabel);
			this.ShipPanel.Controls.Add(this.ShipLabel);
			this.ShipPanel.Location = new System.Drawing.Point(0, 104);
			this.ShipPanel.Name = "ShipPanel";
			this.ShipPanel.Size = new System.Drawing.Size(328, 88);
			this.ShipPanel.TabIndex = 1;
			// 
			// ShipLabel
			// 
			this.ShipLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ShipLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShipLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ShipLabel.Location = new System.Drawing.Point(0, 5);
			this.ShipLabel.Name = "ShipLabel";
			this.ShipLabel.Size = new System.Drawing.Size(325, 16);
			this.ShipLabel.TabIndex = 0;
			this.ShipLabel.Text = "Ship";
			// 
			// CreditsPanel
			// 
			this.CreditsPanel.Controls.Add(this.IncomeTextBox);
			this.CreditsPanel.Controls.Add(this.IncomeLabel);
			this.CreditsPanel.Controls.Add(this.WinTheGameMoneyTextBox);
			this.CreditsPanel.Controls.Add(this.WinTheGameMoneyLabel);
			this.CreditsPanel.Controls.Add(this.SecondsBetweenPaydaysTextBox);
			this.CreditsPanel.Controls.Add(this.SecondsBetweenPaydaysLabel);
			this.CreditsPanel.Controls.Add(this.CreditsLabel);
			this.CreditsPanel.Controls.Add(this.StartingMoneyTextBox);
			this.CreditsPanel.Controls.Add(this.StartingMoneyLabel);
			this.CreditsPanel.Location = new System.Drawing.Point(328, 0);
			this.CreditsPanel.Name = "CreditsPanel";
			this.CreditsPanel.Size = new System.Drawing.Size(184, 88);
			this.CreditsPanel.TabIndex = 3;
			// 
			// CreditsLabel
			// 
			this.CreditsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.CreditsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CreditsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.CreditsLabel.Location = new System.Drawing.Point(0, 5);
			this.CreditsLabel.Name = "CreditsLabel";
			this.CreditsLabel.Size = new System.Drawing.Size(184, 16);
			this.CreditsLabel.TabIndex = 0;
			this.CreditsLabel.Text = "Credits";
			// 
			// ConstantsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(506, 297);
			this.Controls.Add(this.He3Panel);
			this.Controls.Add(this.CreditsPanel);
			this.Controls.Add(this.ShipPanel);
			this.Controls.Add(this.SectorPanel);
			this.Controls.Add(this.PointsPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "ConstantsForm";
			this.ShowInTaskbar = false;
			this.Text = "Global Constants";
			this.Closed += new System.EventHandler(this.ConstantsForm_Closed);
			this.SectorPanel.ResumeLayout(false);
			this.PointsPanel.ResumeLayout(false);
			this.He3Panel.ResumeLayout(false);
			this.ShipPanel.ResumeLayout(false);
			this.CreditsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BindControls ()
		{
			string Text = "Text";
			SectorRadiusTextBox.DataBindings.Add(Text, _constants, "RadiusUniverse");
			LensMultiplierTextBox.DataBindings.Add(Text, _constants, "LensMultiplier");
			WarpBombDelayTextBox.DataBindings.Add(Text, _constants, "WarpBombDelay");
			BaseClusterCostTextBox.DataBindings.Add(Text, _constants, "BaseClusterCost");
			ClusterDivisorTextBox.DataBindings.Add(Text, _constants, "ClusterDivisor");
			OutofBoundsTextBox.DataBindings.Add(Text, _constants, "OutOfBounds");
			LifepodCostTextBox.DataBindings.Add(Text, _constants, "LifepodCost");
			PlayerCostTextBox.DataBindings.Add(Text, _constants, "PlayerCost");
			TurretCostTextBox.DataBindings.Add(Text, _constants, "TurretCost");
			DroneCostTextBox.DataBindings.Add(Text, _constants, "DroneCost");
			StartingMoneyTextBox.DataBindings.Add(Text, _constants, "StartingMoney");
			SecondsBetweenPaydaysTextBox.DataBindings.Add(Text, _constants, "SecondsBetweenPaydays");
			IncomeTextBox.DataBindings.Add(Text, _constants, "Income");
			WinTheGameMoneyTextBox.DataBindings.Add(Text, _constants, "WinTheGameMoney");
			ExitWarpSpeedTextBox.DataBindings.Add(Text, _constants, "ExitWarpSpeed");
			ExitStationSpeedTextBox.DataBindings.Add(Text, _constants, "ExitStationSpeed");
			DownedShieldTextBox.DataBindings.Add(Text, _constants, "DownedShield");
			RipcordTimeTextBox.DataBindings.Add(Text, _constants, "RipcordTime");
			MountRateTextBox.DataBindings.Add(Text, _constants, "MountRate");
			LifepodEnduranceTextBox.DataBindings.Add(Text, _constants, "LifepodEndurance");
			RatingAddTextBox.DataBindings.Add(Text, _constants, "RatingAdd");
			RatingDivideTextBox.DataBindings.Add(Text, _constants, "RatingDivide");
			CapacityHe3TextBox.DataBindings.Add(Text, _constants, "CapacityHe3");
			ValueHe3TextBox.DataBindings.Add(Text, _constants, "ValueHe3");
			AmountHe3TextBox.DataBindings.Add(Text, _constants, "AmountHe3");
			He3RegenerationTextBox.DataBindings.Add(Text, _constants, "He3Regeneration");
			PointsAlephTextBox.DataBindings.Add(Text, _constants, "PointsAleph");
			PointsAsteroidTextBox.DataBindings.Add(Text, _constants, "PointsAsteroid");
			PointsFlagTextBox.DataBindings.Add(Text, _constants, "PointsFlags");
			PointsArtifactTextBox.DataBindings.Add(Text, _constants, "PointsArtifacts");
			PointsPilotTextBox.DataBindings.Add(Text, _constants, "PointsPlayer");
			PointsBaseKillTextBox.DataBindings.Add(Text, _constants, "PointsBaseKill");
			PointsBaseCaptureTextBox.DataBindings.Add(Text, _constants, "PointsBaseCapture");
			PointsRescueTextBox.DataBindings.Add(Text, _constants, "PointsRescue");
			UnknownTextBox.DataBindings.Add(Text, _constants, "Unused");
			PointsMinerTextBox.DataBindings.Add(Text, _constants, "PointsMiner");
			PointsBuilderTextBox.DataBindings.Add(Text, _constants, "PointsBuilder");
			PointsLayerTextBox.DataBindings.Add(Text, _constants, "PointsLayer");
			PointsCarrierTextBox.DataBindings.Add(Text, _constants, "PointsCarrier");
			PointsTechTextBox.DataBindings.Add(Text, _constants, "PointsTech");
		}

		private void ConstantsForm_Closed (object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}
	}
}
