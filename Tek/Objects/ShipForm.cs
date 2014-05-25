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
	public class ShipForm : ObjectForm
	{
		#region Form Controls
		private System.Windows.Forms.Panel HullPanel;
		private System.Windows.Forms.Label ACLabel;
		private System.Windows.Forms.TextBox ACTextBox;
		private System.Windows.Forms.Label HitpointsLabel;
		private System.Windows.Forms.TextBox HitpointsTextBox;
		private System.Windows.Forms.Panel ThrustPanel;
		private System.Windows.Forms.Label ThrustLabel;
		private System.Windows.Forms.Label MaxSpeedLabel;
		private System.Windows.Forms.TextBox MaxSpeedTextBox;
		private System.Windows.Forms.Panel ShipPanel;
		private System.Windows.Forms.Label ShipLabel;
		private System.Windows.Forms.Label FuelCapacityLabel;
		private System.Windows.Forms.TextBox FuelCapacityTextBox;
		private System.Windows.Forms.Label EnergyLabel;
		private System.Windows.Forms.TextBox EnergyTextBox;
		private System.Windows.Forms.Label EnergyRechargeLabel;
		private System.Windows.Forms.TextBox EnergyRechargeTextBox;
		private System.Windows.Forms.Label RipTimeLabel;
		private System.Windows.Forms.TextBox RipTimeTextBox;
		private System.Windows.Forms.Label RipCostLabel;
		private System.Windows.Forms.TextBox RipCostTextBox;
		private System.Windows.Forms.Label ECMLabel;
		private System.Windows.Forms.TextBox ECMTextBox;
		private System.Windows.Forms.Label AmmoCapacityLabel;
		private System.Windows.Forms.TextBox AmmoCapacityTextBox;
		private System.Windows.Forms.Panel RipcordPanel;
		private System.Windows.Forms.Label RipcordLabel;
		private System.Windows.Forms.Label SmallRipcordLabel;
		private System.Windows.Forms.Label CantRipcordLabel;
		private System.Windows.Forms.Label LargeRipcordLabel;
		private System.Windows.Forms.Label CanUseSmallRipLabel;
		private System.Windows.Forms.Panel TurnRatePanel;
		private System.Windows.Forms.Label TurnRateLabel;
		private System.Windows.Forms.Label PitchRateLabel;
		private System.Windows.Forms.TextBox PitchRateTextBox;
		private System.Windows.Forms.Label PitchDriftLabel;
		private System.Windows.Forms.TextBox PitchDriftTextBox;
		private System.Windows.Forms.TextBox YawDriftTextBox;
		private System.Windows.Forms.Label YawDriftLabel;
		private System.Windows.Forms.Label YawRateLabel;
		private System.Windows.Forms.TextBox YawRateTextBox;
		private System.Windows.Forms.TextBox RollDriftTextBox;
		private System.Windows.Forms.Label RollDriftLabel;
		private System.Windows.Forms.Label RollLabel;
		private System.Windows.Forms.TextBox RollRateTextBox;
		private System.Windows.Forms.Label NoEjectLabel;
		private System.Windows.Forms.Label IsLifepodLabel;
		private System.Windows.Forms.Label CanRescueLabel;
		private System.Windows.Forms.Label SmallShipLabel;
		private System.Windows.Forms.Label HasLeadIndicatorLabel;
		private System.Windows.Forms.Button ExpandCargoButton;
		private System.Windows.Forms.Panel CargoPanel;
		private System.Windows.Forms.Label CargoLabel;
		private System.Windows.Forms.Label Turr4Label;
		private System.Windows.Forms.Label Turr3Label;
		private System.Windows.Forms.Label Turr2Label;
		private System.Windows.Forms.Label Turr1Label;
		private System.Windows.Forms.Label MissileLabel;
		private System.Windows.Forms.Label BoosterLabel;
		private System.Windows.Forms.Label PackLabel;
		private System.Windows.Forms.Label CloakLabel;
		private System.Windows.Forms.TextBox CloakTextBox;
		private System.Windows.Forms.TextBox BoosterTextBox;
		private System.Windows.Forms.TextBox PackTextBox;
		private System.Windows.Forms.TextBox Turr2TextBox;
		private System.Windows.Forms.TextBox Turr1TextBox;
		private System.Windows.Forms.TextBox MissileTextBox;
		private System.Windows.Forms.TextBox Turr4TextBox;
		private System.Windows.Forms.TextBox Turr3TextBox;
		private System.Windows.Forms.TextBox Cargo1TextBox;
		private System.Windows.Forms.TextBox Cargo2TextBox;
		private System.Windows.Forms.TextBox Cargo3TextBox;
		private System.Windows.Forms.TextBox Cargo4TextBox;
		private System.Windows.Forms.TextBox Cargo5TextBox;
		private System.Windows.Forms.GroupBox CargoGroupBox;
		private System.Windows.Forms.Label Cargo1Label;
		private System.Windows.Forms.CheckBox UseTurr1CheckBox;
		private System.Windows.Forms.CheckBox UseTurr2CheckBox;
		private System.Windows.Forms.CheckBox UseTurr3CheckBox;
		private System.Windows.Forms.CheckBox UseTurr4CheckBox;
		private System.Windows.Forms.CheckBox UseBoosterCheckBox;
		private System.Windows.Forms.CheckBox UseCloakCheckBox;
		private System.Windows.Forms.Label MassLabel;
		private System.Windows.Forms.TextBox MassTextBox;
		private System.Windows.Forms.TextBox ShieldTextBox;
		private System.Windows.Forms.Label ShieldLabel;
		private System.Windows.Forms.Label RelaysLeadIndicatorLabel;
		private System.Windows.Forms.Label IsCarrierLabel;
		private System.Windows.Forms.Label IsMinerLabel;
		private System.Windows.Forms.Label IsConstructorLabel;
		private System.Windows.Forms.Label WarnStationAtRiskLabel;
		private System.Windows.Forms.Label HullHeaderLabel;
		private System.Windows.Forms.Panel TurretsPanel;
		private System.Windows.Forms.Panel TurretSlot1Panel;
		private System.Windows.Forms.Panel TurretSlot2Panel;
		private System.Windows.Forms.Panel TurretSlot3Panel;
		private System.Windows.Forms.Panel TurretSlot4Panel;
		private System.Windows.Forms.Panel MissilePanel;
		private System.Windows.Forms.Panel BoosterPanel;
		private System.Windows.Forms.Panel ShieldPanel;
		private System.Windows.Forms.Panel CloakPanel;
		private System.Windows.Forms.Panel PackPanel;
		private System.Windows.Forms.Panel ChaffPanel;
		private System.Windows.Forms.Label ChaffLabel;
		private System.Windows.Forms.TextBox ChaffTextBox;
		private System.Windows.Forms.Panel CargoItemsPanel;
		private System.Windows.Forms.ContextMenu AvailablePartsContextMenu;
		private System.Windows.Forms.Panel DamagePanel;
		private System.Windows.Forms.Label DamageHeaderLabel;
		private System.Windows.Forms.Label WeaponRangeLabel;
		private System.Windows.Forms.TextBox WeaponsRangeTextBox;
		private System.Windows.Forms.TextBox TotalDamageTextBox;
		private System.Windows.Forms.Label TotalDamageLabel;
		private System.Windows.Forms.PictureBox SensorEnvelopePictureBox;
		private System.Windows.Forms.Label ActualDamageLabel;
		private System.Windows.Forms.TextBox TimeToKillTextBox;
		private System.Windows.Forms.Panel ThrustGraphicPanel;
		private System.Windows.Forms.TextBox HullDamageTextBox;
		private System.Windows.Forms.Label TimeToKillLabel;
		private System.Windows.Forms.TextBox ShieldDamageTextBox;
		private System.Windows.Forms.Label ShieldDamageLabel;
		private System.Windows.Forms.Label KillBonusLabel;
		private System.Windows.Forms.TextBox AccelTextBox;
		private System.Windows.Forms.Label AccelLabel;
		private System.Windows.Forms.Label BearingLabel;
		private System.Windows.Forms.TextBox BearingTextBox;
		private System.Windows.Forms.Panel WeaponsPanel;
		private System.Windows.Forms.Panel WeaponSlot3Panel;
		private System.Windows.Forms.TextBox Wep3TextBox;
		private System.Windows.Forms.Label Wep3Label;
		private System.Windows.Forms.CheckBox UseWeapon3CheckBox;
		private System.Windows.Forms.Panel WeaponSlot4Panel;
		private System.Windows.Forms.TextBox Wep4TextBox;
		private System.Windows.Forms.Label Wep4Label;
		private System.Windows.Forms.CheckBox UseWeapon4CheckBox;
		private System.Windows.Forms.Panel WeaponSlot1Panel;
		private System.Windows.Forms.CheckBox UseWeapon1CheckBox;
		private System.Windows.Forms.TextBox Wep1TextBox;
		private System.Windows.Forms.Label Wep1Label;
		private System.Windows.Forms.Panel WeaponSlot2Panel;
		private System.Windows.Forms.CheckBox UseWeapon2CheckBox;
		private System.Windows.Forms.TextBox Wep2TextBox;
		private System.Windows.Forms.Label Wep2Label;
		private System.Windows.Forms.CheckBox UseMissileCheckBox;
		private System.Windows.Forms.NumericUpDown KillCountNumericUpDown;
		private System.Windows.Forms.TextBox KillBonusTextBox;
		private System.ComponentModel.IContainer components = null;
		#endregion
		private System.Windows.Forms.Label KillsLabel;
		private System.Windows.Forms.Label CapturesLabel;

		Ship _ship;
		AllegObject _target;

		double _bearing = 0;
		double _thrustAngle = 1.5707963267948966;
		int _thrustX = 28;
		int _thrustY = 1;

		ArrayList _partList;	// Used for the partlist context menu

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="game"></param>
		/// <param name="team"></param>
		/// <param name="ship"></param>
		public ShipForm (TekSettings settings, Ship ship) : this(settings, ship, null)
		{
		}

		public ShipForm (TekSettings settings, Ship ship, AllegObject target) : base(settings, ship)
		{
			InitializeComponent();
			_partList = new ArrayList();
			ship.Updated += new EventHandler(UpdateHandler);
			ship.Closed += new EventHandler(ClosedHandler);
			_ship = ship;
			_target = target;

			this.ForeColor = ship.Team.TeamColor;

			_ship.Update();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ShipForm));
			this.HullPanel = new System.Windows.Forms.Panel();
			this.ACLabel = new System.Windows.Forms.Label();
			this.ACTextBox = new System.Windows.Forms.TextBox();
			this.HitpointsLabel = new System.Windows.Forms.Label();
			this.HitpointsTextBox = new System.Windows.Forms.TextBox();
			this.HullHeaderLabel = new System.Windows.Forms.Label();
			this.ThrustPanel = new System.Windows.Forms.Panel();
			this.MassTextBox = new System.Windows.Forms.TextBox();
			this.AccelTextBox = new System.Windows.Forms.TextBox();
			this.MaxSpeedTextBox = new System.Windows.Forms.TextBox();
			this.ThrustGraphicPanel = new System.Windows.Forms.Panel();
			this.MaxSpeedLabel = new System.Windows.Forms.Label();
			this.ThrustLabel = new System.Windows.Forms.Label();
			this.MassLabel = new System.Windows.Forms.Label();
			this.AccelLabel = new System.Windows.Forms.Label();
			this.ShipPanel = new System.Windows.Forms.Panel();
			this.ExpandCargoButton = new System.Windows.Forms.Button();
			this.WarnStationAtRiskLabel = new System.Windows.Forms.Label();
			this.IsMinerLabel = new System.Windows.Forms.Label();
			this.IsCarrierLabel = new System.Windows.Forms.Label();
			this.RelaysLeadIndicatorLabel = new System.Windows.Forms.Label();
			this.SmallShipLabel = new System.Windows.Forms.Label();
			this.HasLeadIndicatorLabel = new System.Windows.Forms.Label();
			this.NoEjectLabel = new System.Windows.Forms.Label();
			this.IsLifepodLabel = new System.Windows.Forms.Label();
			this.CapturesLabel = new System.Windows.Forms.Label();
			this.CanRescueLabel = new System.Windows.Forms.Label();
			this.AmmoCapacityLabel = new System.Windows.Forms.Label();
			this.AmmoCapacityTextBox = new System.Windows.Forms.TextBox();
			this.ECMLabel = new System.Windows.Forms.Label();
			this.ECMTextBox = new System.Windows.Forms.TextBox();
			this.EnergyRechargeLabel = new System.Windows.Forms.Label();
			this.EnergyRechargeTextBox = new System.Windows.Forms.TextBox();
			this.EnergyLabel = new System.Windows.Forms.Label();
			this.EnergyTextBox = new System.Windows.Forms.TextBox();
			this.FuelCapacityLabel = new System.Windows.Forms.Label();
			this.FuelCapacityTextBox = new System.Windows.Forms.TextBox();
			this.ShipLabel = new System.Windows.Forms.Label();
			this.IsConstructorLabel = new System.Windows.Forms.Label();
			this.RipTimeLabel = new System.Windows.Forms.Label();
			this.RipTimeTextBox = new System.Windows.Forms.TextBox();
			this.RipCostLabel = new System.Windows.Forms.Label();
			this.RipCostTextBox = new System.Windows.Forms.TextBox();
			this.RipcordPanel = new System.Windows.Forms.Panel();
			this.SmallRipcordLabel = new System.Windows.Forms.Label();
			this.CanUseSmallRipLabel = new System.Windows.Forms.Label();
			this.CantRipcordLabel = new System.Windows.Forms.Label();
			this.LargeRipcordLabel = new System.Windows.Forms.Label();
			this.RipcordLabel = new System.Windows.Forms.Label();
			this.TurnRatePanel = new System.Windows.Forms.Panel();
			this.RollDriftTextBox = new System.Windows.Forms.TextBox();
			this.RollDriftLabel = new System.Windows.Forms.Label();
			this.RollLabel = new System.Windows.Forms.Label();
			this.RollRateTextBox = new System.Windows.Forms.TextBox();
			this.YawDriftTextBox = new System.Windows.Forms.TextBox();
			this.YawDriftLabel = new System.Windows.Forms.Label();
			this.YawRateLabel = new System.Windows.Forms.Label();
			this.YawRateTextBox = new System.Windows.Forms.TextBox();
			this.PitchDriftTextBox = new System.Windows.Forms.TextBox();
			this.PitchDriftLabel = new System.Windows.Forms.Label();
			this.PitchRateLabel = new System.Windows.Forms.Label();
			this.PitchRateTextBox = new System.Windows.Forms.TextBox();
			this.TurnRateLabel = new System.Windows.Forms.Label();
			this.CargoPanel = new System.Windows.Forms.Panel();
			this.WeaponsPanel = new System.Windows.Forms.Panel();
			this.WeaponSlot3Panel = new System.Windows.Forms.Panel();
			this.Wep3Label = new System.Windows.Forms.Label();
			this.UseWeapon3CheckBox = new System.Windows.Forms.CheckBox();
			this.Wep3TextBox = new System.Windows.Forms.TextBox();
			this.AvailablePartsContextMenu = new System.Windows.Forms.ContextMenu();
			this.WeaponSlot4Panel = new System.Windows.Forms.Panel();
			this.Wep4TextBox = new System.Windows.Forms.TextBox();
			this.Wep4Label = new System.Windows.Forms.Label();
			this.UseWeapon4CheckBox = new System.Windows.Forms.CheckBox();
			this.WeaponSlot1Panel = new System.Windows.Forms.Panel();
			this.UseWeapon1CheckBox = new System.Windows.Forms.CheckBox();
			this.Wep1TextBox = new System.Windows.Forms.TextBox();
			this.Wep1Label = new System.Windows.Forms.Label();
			this.WeaponSlot2Panel = new System.Windows.Forms.Panel();
			this.UseWeapon2CheckBox = new System.Windows.Forms.CheckBox();
			this.Wep2TextBox = new System.Windows.Forms.TextBox();
			this.Wep2Label = new System.Windows.Forms.Label();
			this.ChaffPanel = new System.Windows.Forms.Panel();
			this.ChaffLabel = new System.Windows.Forms.Label();
			this.ChaffTextBox = new System.Windows.Forms.TextBox();
			this.CargoGroupBox = new System.Windows.Forms.GroupBox();
			this.Cargo1Label = new System.Windows.Forms.Label();
			this.CargoItemsPanel = new System.Windows.Forms.Panel();
			this.Cargo1TextBox = new System.Windows.Forms.TextBox();
			this.Cargo2TextBox = new System.Windows.Forms.TextBox();
			this.Cargo3TextBox = new System.Windows.Forms.TextBox();
			this.Cargo4TextBox = new System.Windows.Forms.TextBox();
			this.Cargo5TextBox = new System.Windows.Forms.TextBox();
			this.CargoLabel = new System.Windows.Forms.Label();
			this.TurretsPanel = new System.Windows.Forms.Panel();
			this.TurretSlot1Panel = new System.Windows.Forms.Panel();
			this.UseTurr1CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr1Label = new System.Windows.Forms.Label();
			this.Turr1TextBox = new System.Windows.Forms.TextBox();
			this.TurretSlot2Panel = new System.Windows.Forms.Panel();
			this.UseTurr2CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr2Label = new System.Windows.Forms.Label();
			this.Turr2TextBox = new System.Windows.Forms.TextBox();
			this.TurretSlot3Panel = new System.Windows.Forms.Panel();
			this.UseTurr3CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr3Label = new System.Windows.Forms.Label();
			this.Turr3TextBox = new System.Windows.Forms.TextBox();
			this.TurretSlot4Panel = new System.Windows.Forms.Panel();
			this.UseTurr4CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr4Label = new System.Windows.Forms.Label();
			this.Turr4TextBox = new System.Windows.Forms.TextBox();
			this.MissilePanel = new System.Windows.Forms.Panel();
			this.UseMissileCheckBox = new System.Windows.Forms.CheckBox();
			this.MissileLabel = new System.Windows.Forms.Label();
			this.MissileTextBox = new System.Windows.Forms.TextBox();
			this.BoosterPanel = new System.Windows.Forms.Panel();
			this.UseBoosterCheckBox = new System.Windows.Forms.CheckBox();
			this.BoosterLabel = new System.Windows.Forms.Label();
			this.BoosterTextBox = new System.Windows.Forms.TextBox();
			this.ShieldPanel = new System.Windows.Forms.Panel();
			this.ShieldLabel = new System.Windows.Forms.Label();
			this.ShieldTextBox = new System.Windows.Forms.TextBox();
			this.CloakPanel = new System.Windows.Forms.Panel();
			this.UseCloakCheckBox = new System.Windows.Forms.CheckBox();
			this.CloakLabel = new System.Windows.Forms.Label();
			this.CloakTextBox = new System.Windows.Forms.TextBox();
			this.PackPanel = new System.Windows.Forms.Panel();
			this.PackLabel = new System.Windows.Forms.Label();
			this.PackTextBox = new System.Windows.Forms.TextBox();
			this.SensorEnvelopePictureBox = new System.Windows.Forms.PictureBox();
			this.BearingLabel = new System.Windows.Forms.Label();
			this.BearingTextBox = new System.Windows.Forms.TextBox();
			this.DamagePanel = new System.Windows.Forms.Panel();
			this.KillsLabel = new System.Windows.Forms.Label();
			this.KillBonusTextBox = new System.Windows.Forms.TextBox();
			this.KillCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.KillBonusLabel = new System.Windows.Forms.Label();
			this.TotalDamageTextBox = new System.Windows.Forms.TextBox();
			this.TotalDamageLabel = new System.Windows.Forms.Label();
			this.WeaponsRangeTextBox = new System.Windows.Forms.TextBox();
			this.WeaponRangeLabel = new System.Windows.Forms.Label();
			this.DamageHeaderLabel = new System.Windows.Forms.Label();
			this.HullDamageTextBox = new System.Windows.Forms.TextBox();
			this.ActualDamageLabel = new System.Windows.Forms.Label();
			this.TimeToKillTextBox = new System.Windows.Forms.TextBox();
			this.TimeToKillLabel = new System.Windows.Forms.Label();
			this.ShieldDamageTextBox = new System.Windows.Forms.TextBox();
			this.ShieldDamageLabel = new System.Windows.Forms.Label();
			this.SensorsPanel.SuspendLayout();
			this.HullPanel.SuspendLayout();
			this.ThrustPanel.SuspendLayout();
			this.ShipPanel.SuspendLayout();
			this.RipcordPanel.SuspendLayout();
			this.TurnRatePanel.SuspendLayout();
			this.CargoPanel.SuspendLayout();
			this.WeaponsPanel.SuspendLayout();
			this.WeaponSlot3Panel.SuspendLayout();
			this.WeaponSlot4Panel.SuspendLayout();
			this.WeaponSlot1Panel.SuspendLayout();
			this.WeaponSlot2Panel.SuspendLayout();
			this.ChaffPanel.SuspendLayout();
			this.CargoGroupBox.SuspendLayout();
			this.CargoItemsPanel.SuspendLayout();
			this.TurretsPanel.SuspendLayout();
			this.TurretSlot1Panel.SuspendLayout();
			this.TurretSlot2Panel.SuspendLayout();
			this.TurretSlot3Panel.SuspendLayout();
			this.TurretSlot4Panel.SuspendLayout();
			this.MissilePanel.SuspendLayout();
			this.BoosterPanel.SuspendLayout();
			this.ShieldPanel.SuspendLayout();
			this.CloakPanel.SuspendLayout();
			this.PackPanel.SuspendLayout();
			this.DamagePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.KillCountNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ScanrangeLabel
			// 
			this.ScanrangeLabel.Location = new System.Drawing.Point(60, 40);
			this.ScanrangeLabel.Name = "ScanrangeLabel";
			this.ScanrangeLabel.Size = new System.Drawing.Size(72, 15);
			this.ScanrangeLabel.TabIndex = 5;
			this.ScanrangeLabel.Text = "Range (m):";
			this.InfoToolTip.SetToolTip(this.ScanrangeLabel, "This object\'s detection range");
			// 
			// ScanRangeTextBox
			// 
			this.ScanRangeTextBox.Location = new System.Drawing.Point(128, 40);
			this.ScanRangeTextBox.Name = "ScanRangeTextBox";
			this.ScanRangeTextBox.TabIndex = 6;
			this.InfoToolTip.SetToolTip(this.ScanRangeTextBox, "This object\'s detection range");
			// 
			// SigTextBox
			// 
			this.SigTextBox.Location = new System.Drawing.Point(128, 24);
			this.SigTextBox.Name = "SigTextBox";
			this.SigTextBox.TabIndex = 4;
			this.InfoToolTip.SetToolTip(this.SigTextBox, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// SigLabel
			// 
			this.SigLabel.Location = new System.Drawing.Point(77, 24);
			this.SigLabel.Name = "SigLabel";
			this.SigLabel.Size = new System.Drawing.Size(56, 16);
			this.SigLabel.TabIndex = 3;
			this.SigLabel.Text = "Sig (%):";
			this.InfoToolTip.SetToolTip(this.SigLabel, "This object\'s Signature modifier. The higher the modifier, the easier it is for t" +
				"his object to be seen");
			// 
			// SensorsPanel
			// 
			this.SensorsPanel.Controls.Add(this.BearingTextBox);
			this.SensorsPanel.Controls.Add(this.BearingLabel);
			this.SensorsPanel.Controls.Add(this.SensorEnvelopePictureBox);
			this.SensorsPanel.Name = "SensorsPanel";
			this.SensorsPanel.Size = new System.Drawing.Size(176, 80);
			this.SensorsPanel.Controls.SetChildIndex(this.SensorEnvelopePictureBox, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.BearingLabel, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.BearingTextBox, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.SensorsLabel, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.SigLabel, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.ScanrangeLabel, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.SigTextBox, 0);
			this.SensorsPanel.Controls.SetChildIndex(this.ScanRangeTextBox, 0);
			// 
			// SensorsLabel
			// 
			this.SensorsLabel.Name = "SensorsLabel";
			this.SensorsLabel.Size = new System.Drawing.Size(174, 16);
			// 
			// HullPanel
			// 
			this.HullPanel.Controls.Add(this.ACLabel);
			this.HullPanel.Controls.Add(this.ACTextBox);
			this.HullPanel.Controls.Add(this.HitpointsLabel);
			this.HullPanel.Controls.Add(this.HitpointsTextBox);
			this.HullPanel.Controls.Add(this.HullHeaderLabel);
			this.HullPanel.Location = new System.Drawing.Point(176, 80);
			this.HullPanel.Name = "HullPanel";
			this.HullPanel.Size = new System.Drawing.Size(176, 56);
			this.HullPanel.TabIndex = 39;
			// 
			// ACLabel
			// 
			this.ACLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ACLabel.Location = new System.Drawing.Point(8, 40);
			this.ACLabel.Name = "ACLabel";
			this.ACLabel.Size = new System.Drawing.Size(24, 16);
			this.ACLabel.TabIndex = 4;
			this.ACLabel.Text = "AC:";
			this.InfoToolTip.SetToolTip(this.ACLabel, "This ship\'s armor class");
			// 
			// ACTextBox
			// 
			this.ACTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ACTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ACTextBox.ForeColor = System.Drawing.Color.White;
			this.ACTextBox.Location = new System.Drawing.Point(40, 40);
			this.ACTextBox.Name = "ACTextBox";
			this.ACTextBox.ReadOnly = true;
			this.ACTextBox.Size = new System.Drawing.Size(128, 14);
			this.ACTextBox.TabIndex = 5;
			this.ACTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.ACTextBox, "This ship\'s armor class");
			// 
			// HitpointsLabel
			// 
			this.HitpointsLabel.BackColor = System.Drawing.Color.Black;
			this.HitpointsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HitpointsLabel.Location = new System.Drawing.Point(8, 24);
			this.HitpointsLabel.Name = "HitpointsLabel";
			this.HitpointsLabel.Size = new System.Drawing.Size(64, 16);
			this.HitpointsLabel.TabIndex = 2;
			this.HitpointsLabel.Text = "Hitpoints:";
			this.InfoToolTip.SetToolTip(this.HitpointsLabel, "The amount of hitpoints this ship has");
			// 
			// HitpointsTextBox
			// 
			this.HitpointsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HitpointsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HitpointsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HitpointsTextBox.ForeColor = System.Drawing.Color.White;
			this.HitpointsTextBox.Location = new System.Drawing.Point(128, 24);
			this.HitpointsTextBox.Name = "HitpointsTextBox";
			this.HitpointsTextBox.ReadOnly = true;
			this.HitpointsTextBox.Size = new System.Drawing.Size(40, 14);
			this.HitpointsTextBox.TabIndex = 3;
			this.HitpointsTextBox.Text = "0";
			this.HitpointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HitpointsTextBox, "The amount of hitpoints this ship has");
			// 
			// HullHeaderLabel
			// 
			this.HullHeaderLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.HullHeaderLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HullHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.HullHeaderLabel.Location = new System.Drawing.Point(0, 5);
			this.HullHeaderLabel.Name = "HullHeaderLabel";
			this.HullHeaderLabel.Size = new System.Drawing.Size(174, 16);
			this.HullHeaderLabel.TabIndex = 1;
			this.HullHeaderLabel.Text = "Hull";
			// 
			// ThrustPanel
			// 
			this.ThrustPanel.Controls.Add(this.MassTextBox);
			this.ThrustPanel.Controls.Add(this.AccelTextBox);
			this.ThrustPanel.Controls.Add(this.MaxSpeedTextBox);
			this.ThrustPanel.Controls.Add(this.ThrustGraphicPanel);
			this.ThrustPanel.Controls.Add(this.MaxSpeedLabel);
			this.ThrustPanel.Controls.Add(this.ThrustLabel);
			this.ThrustPanel.Controls.Add(this.MassLabel);
			this.ThrustPanel.Controls.Add(this.AccelLabel);
			this.ThrustPanel.Location = new System.Drawing.Point(176, 0);
			this.ThrustPanel.Name = "ThrustPanel";
			this.ThrustPanel.Size = new System.Drawing.Size(176, 77);
			this.ThrustPanel.TabIndex = 40;
			// 
			// MassTextBox
			// 
			this.MassTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MassTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MassTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MassTextBox.ForeColor = System.Drawing.Color.White;
			this.MassTextBox.Location = new System.Drawing.Point(136, 56);
			this.MassTextBox.Name = "MassTextBox";
			this.MassTextBox.ReadOnly = true;
			this.MassTextBox.Size = new System.Drawing.Size(32, 14);
			this.MassTextBox.TabIndex = 13;
			this.MassTextBox.Text = "0";
			this.MassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.MassTextBox, "This ship\'s mass");
			// 
			// AccelTextBox
			// 
			this.AccelTextBox.BackColor = System.Drawing.Color.Maroon;
			this.AccelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AccelTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AccelTextBox.ForeColor = System.Drawing.Color.White;
			this.AccelTextBox.Location = new System.Drawing.Point(136, 40);
			this.AccelTextBox.Name = "AccelTextBox";
			this.AccelTextBox.ReadOnly = true;
			this.AccelTextBox.Size = new System.Drawing.Size(32, 14);
			this.AccelTextBox.TabIndex = 5;
			this.AccelTextBox.Text = "0";
			this.AccelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.AccelTextBox, "The rate at which this ship\'s speed increases in the specified direction. Use the" +
				" graphic to the left to set the ship\'s direction");
			// 
			// MaxSpeedTextBox
			// 
			this.MaxSpeedTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MaxSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MaxSpeedTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaxSpeedTextBox.ForeColor = System.Drawing.Color.White;
			this.MaxSpeedTextBox.Location = new System.Drawing.Point(136, 24);
			this.MaxSpeedTextBox.Name = "MaxSpeedTextBox";
			this.MaxSpeedTextBox.ReadOnly = true;
			this.MaxSpeedTextBox.Size = new System.Drawing.Size(32, 14);
			this.MaxSpeedTextBox.TabIndex = 3;
			this.MaxSpeedTextBox.Text = "0";
			this.MaxSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.MaxSpeedTextBox, "The maximum speed of this ship in the specified direction. Use the graphic to the" +
				" left to specify a direction");
			// 
			// ThrustGraphicPanel
			// 
			this.ThrustGraphicPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ThrustGraphicPanel.BackgroundImage")));
			this.ThrustGraphicPanel.Location = new System.Drawing.Point(4, 24);
			this.ThrustGraphicPanel.Name = "ThrustGraphicPanel";
			this.ThrustGraphicPanel.Size = new System.Drawing.Size(53, 53);
			this.ThrustGraphicPanel.TabIndex = 38;
			this.InfoToolTip.SetToolTip(this.ThrustGraphicPanel, "This is a graphic display of this ship\'s thrust. Click a corner to see the thrust" +
				" and speed values for this ship while thrusting in that direction");
			this.ThrustGraphicPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ThrustGraphicPanel_Paint);
			this.ThrustGraphicPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ThrustGraphicPanel_MouseMove);
			this.ThrustGraphicPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ThrustGraphicPanel_MouseDown);
			// 
			// MaxSpeedLabel
			// 
			this.MaxSpeedLabel.BackColor = System.Drawing.Color.Black;
			this.MaxSpeedLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MaxSpeedLabel.Location = new System.Drawing.Point(58, 24);
			this.MaxSpeedLabel.Name = "MaxSpeedLabel";
			this.MaxSpeedLabel.Size = new System.Drawing.Size(80, 16);
			this.MaxSpeedLabel.TabIndex = 2;
			this.MaxSpeedLabel.Text = "Speed (m/s):";
			this.InfoToolTip.SetToolTip(this.MaxSpeedLabel, "The maximum speed of this ship in the specified direction. Use the graphic to the" +
				" left to specify a direction");
			// 
			// ThrustLabel
			// 
			this.ThrustLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ThrustLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ThrustLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ThrustLabel.Location = new System.Drawing.Point(0, 5);
			this.ThrustLabel.Name = "ThrustLabel";
			this.ThrustLabel.Size = new System.Drawing.Size(176, 16);
			this.ThrustLabel.TabIndex = 29;
			this.ThrustLabel.Text = "Thrust";
			// 
			// MassLabel
			// 
			this.MassLabel.BackColor = System.Drawing.Color.Black;
			this.MassLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MassLabel.Location = new System.Drawing.Point(73, 56);
			this.MassLabel.Name = "MassLabel";
			this.MassLabel.Size = new System.Drawing.Size(64, 16);
			this.MassLabel.TabIndex = 12;
			this.MassLabel.Text = "Mass (kg):";
			this.InfoToolTip.SetToolTip(this.MassLabel, "This ship\'s mass");
			// 
			// AccelLabel
			// 
			this.AccelLabel.BackColor = System.Drawing.Color.Black;
			this.AccelLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AccelLabel.Location = new System.Drawing.Point(57, 40);
			this.AccelLabel.Name = "AccelLabel";
			this.AccelLabel.Size = new System.Drawing.Size(88, 16);
			this.AccelLabel.TabIndex = 4;
			this.AccelLabel.Text = "Accel (m/s²):";
			this.InfoToolTip.SetToolTip(this.AccelLabel, "The rate at which this ship\'s speed increases in the specified direction. Use the" +
				" graphic to the left to set the ship\'s direction");
			// 
			// ShipPanel
			// 
			this.ShipPanel.Controls.Add(this.CapturesLabel);
			this.ShipPanel.Controls.Add(this.ExpandCargoButton);
			this.ShipPanel.Controls.Add(this.WarnStationAtRiskLabel);
			this.ShipPanel.Controls.Add(this.IsMinerLabel);
			this.ShipPanel.Controls.Add(this.IsCarrierLabel);
			this.ShipPanel.Controls.Add(this.RelaysLeadIndicatorLabel);
			this.ShipPanel.Controls.Add(this.SmallShipLabel);
			this.ShipPanel.Controls.Add(this.HasLeadIndicatorLabel);
			this.ShipPanel.Controls.Add(this.NoEjectLabel);
			this.ShipPanel.Controls.Add(this.IsLifepodLabel);
			this.ShipPanel.Controls.Add(this.CanRescueLabel);
			this.ShipPanel.Controls.Add(this.AmmoCapacityLabel);
			this.ShipPanel.Controls.Add(this.AmmoCapacityTextBox);
			this.ShipPanel.Controls.Add(this.ECMLabel);
			this.ShipPanel.Controls.Add(this.ECMTextBox);
			this.ShipPanel.Controls.Add(this.EnergyRechargeLabel);
			this.ShipPanel.Controls.Add(this.EnergyRechargeTextBox);
			this.ShipPanel.Controls.Add(this.EnergyLabel);
			this.ShipPanel.Controls.Add(this.EnergyTextBox);
			this.ShipPanel.Controls.Add(this.FuelCapacityLabel);
			this.ShipPanel.Controls.Add(this.FuelCapacityTextBox);
			this.ShipPanel.Controls.Add(this.ShipLabel);
			this.ShipPanel.Controls.Add(this.IsConstructorLabel);
			this.ShipPanel.Location = new System.Drawing.Point(176, 136);
			this.ShipPanel.Name = "ShipPanel";
			this.ShipPanel.Size = new System.Drawing.Size(176, 208);
			this.ShipPanel.TabIndex = 41;
			// 
			// ExpandCargoButton
			// 
			this.ExpandCargoButton.BackColor = System.Drawing.Color.Maroon;
			this.ExpandCargoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExpandCargoButton.ForeColor = System.Drawing.Color.White;
			this.ExpandCargoButton.Location = new System.Drawing.Point(104, 176);
			this.ExpandCargoButton.Name = "ExpandCargoButton";
			this.ExpandCargoButton.Size = new System.Drawing.Size(64, 21);
			this.ExpandCargoButton.TabIndex = 26;
			this.ExpandCargoButton.Text = "Cargo »";
			this.InfoToolTip.SetToolTip(this.ExpandCargoButton, "This button toggles the cargo pane on and off.");
			this.ExpandCargoButton.Click += new System.EventHandler(this.ExpandCargoButton_Click);
			// 
			// WarnStationAtRiskLabel
			// 
			this.WarnStationAtRiskLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WarnStationAtRiskLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.WarnStationAtRiskLabel.Location = new System.Drawing.Point(56, 152);
			this.WarnStationAtRiskLabel.Name = "WarnStationAtRiskLabel";
			this.WarnStationAtRiskLabel.Size = new System.Drawing.Size(112, 16);
			this.WarnStationAtRiskLabel.TabIndex = 22;
			this.WarnStationAtRiskLabel.Text = "Warn Station at Risk";
			this.WarnStationAtRiskLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.InfoToolTip.SetToolTip(this.WarnStationAtRiskLabel, "When detected, this ship will sound a \"Station at Risk\" alert to enemy teams");
			// 
			// IsMinerLabel
			// 
			this.IsMinerLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IsMinerLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.IsMinerLabel.Location = new System.Drawing.Point(8, 152);
			this.IsMinerLabel.Name = "IsMinerLabel";
			this.IsMinerLabel.Size = new System.Drawing.Size(48, 16);
			this.IsMinerLabel.TabIndex = 21;
			this.IsMinerLabel.Text = "Is Miner";
			this.InfoToolTip.SetToolTip(this.IsMinerLabel, "This ship is a miner that retrieves HE3 from white rocks, and docks it in base gi" +
				"ving its team credits");
			// 
			// IsCarrierLabel
			// 
			this.IsCarrierLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IsCarrierLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.IsCarrierLabel.Location = new System.Drawing.Point(8, 168);
			this.IsCarrierLabel.Name = "IsCarrierLabel";
			this.IsCarrierLabel.Size = new System.Drawing.Size(56, 16);
			this.IsCarrierLabel.TabIndex = 23;
			this.IsCarrierLabel.Text = "Is Carrier";
			this.InfoToolTip.SetToolTip(this.IsCarrierLabel, "This ship is a carrier that can refuel and rearm friendly ships. It cannot assimi" +
				"late docked technology");
			// 
			// RelaysLeadIndicatorLabel
			// 
			this.RelaysLeadIndicatorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RelaysLeadIndicatorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RelaysLeadIndicatorLabel.Location = new System.Drawing.Point(80, 136);
			this.RelaysLeadIndicatorLabel.Name = "RelaysLeadIndicatorLabel";
			this.RelaysLeadIndicatorLabel.Size = new System.Drawing.Size(88, 16);
			this.RelaysLeadIndicatorLabel.TabIndex = 20;
			this.RelaysLeadIndicatorLabel.Text = "Relays Lead Ind.";
			this.RelaysLeadIndicatorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.InfoToolTip.SetToolTip(this.RelaysLeadIndicatorLabel, "This ship relays an aiming indicator to friendly ships for all targets within its" +
				" own scanrange");
			// 
			// SmallShipLabel
			// 
			this.SmallShipLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SmallShipLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.SmallShipLabel.Location = new System.Drawing.Point(112, 104);
			this.SmallShipLabel.Name = "SmallShipLabel";
			this.SmallShipLabel.Size = new System.Drawing.Size(56, 16);
			this.SmallShipLabel.TabIndex = 16;
			this.SmallShipLabel.Text = "Small Ship";
			this.SmallShipLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.InfoToolTip.SetToolTip(this.SmallShipLabel, "This ship is classified as \"Small\" and can dock in all stations with a docking ba" +
				"y");
			// 
			// HasLeadIndicatorLabel
			// 
			this.HasLeadIndicatorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HasLeadIndicatorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.HasLeadIndicatorLabel.Location = new System.Drawing.Point(88, 120);
			this.HasLeadIndicatorLabel.Name = "HasLeadIndicatorLabel";
			this.HasLeadIndicatorLabel.Size = new System.Drawing.Size(80, 16);
			this.HasLeadIndicatorLabel.TabIndex = 18;
			this.HasLeadIndicatorLabel.Text = "Has Lead Ind.";
			this.HasLeadIndicatorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.InfoToolTip.SetToolTip(this.HasLeadIndicatorLabel, "This ship displays an aim indicator that helps its pilot aim his guns");
			// 
			// NoEjectLabel
			// 
			this.NoEjectLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NoEjectLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.NoEjectLabel.Location = new System.Drawing.Point(57, 104);
			this.NoEjectLabel.Name = "NoEjectLabel";
			this.NoEjectLabel.Size = new System.Drawing.Size(56, 16);
			this.NoEjectLabel.TabIndex = 15;
			this.NoEjectLabel.Text = "No Eject";
			this.NoEjectLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.NoEjectLabel, "While flying this ship, the pilot can not eject using the Ctrl+Shift+DDD key comb" +
				"ination");
			// 
			// IsLifepodLabel
			// 
			this.IsLifepodLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IsLifepodLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.IsLifepodLabel.Location = new System.Drawing.Point(8, 136);
			this.IsLifepodLabel.Name = "IsLifepodLabel";
			this.IsLifepodLabel.Size = new System.Drawing.Size(64, 16);
			this.IsLifepodLabel.TabIndex = 19;
			this.IsLifepodLabel.Text = "Is Lifepod";
			this.InfoToolTip.SetToolTip(this.IsLifepodLabel, "This ship is a lifepod");
			// 
			// CapturesLabel
			// 
			this.CapturesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CapturesLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CapturesLabel.Location = new System.Drawing.Point(8, 104);
			this.CapturesLabel.Name = "CapturesLabel";
			this.CapturesLabel.Size = new System.Drawing.Size(48, 16);
			this.CapturesLabel.TabIndex = 14;
			this.CapturesLabel.Text = "Captures";
			this.InfoToolTip.SetToolTip(this.CapturesLabel, "This ship can capture enemy stations by docking when its shields are down");
			// 
			// CanRescueLabel
			// 
			this.CanRescueLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CanRescueLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CanRescueLabel.Location = new System.Drawing.Point(8, 120);
			this.CanRescueLabel.Name = "CanRescueLabel";
			this.CanRescueLabel.Size = new System.Drawing.Size(64, 16);
			this.CanRescueLabel.TabIndex = 17;
			this.CanRescueLabel.Text = "Can Rescue";
			this.InfoToolTip.SetToolTip(this.CanRescueLabel, "This ship will rescue friendly lifepods when it collides with them");
			// 
			// AmmoCapacityLabel
			// 
			this.AmmoCapacityLabel.BackColor = System.Drawing.Color.Black;
			this.AmmoCapacityLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AmmoCapacityLabel.Location = new System.Drawing.Point(8, 24);
			this.AmmoCapacityLabel.Name = "AmmoCapacityLabel";
			this.AmmoCapacityLabel.Size = new System.Drawing.Size(104, 16);
			this.AmmoCapacityLabel.TabIndex = 2;
			this.AmmoCapacityLabel.Text = "Ammo Capacity:";
			this.InfoToolTip.SetToolTip(this.AmmoCapacityLabel, "The amount of ammo this ship can hold in one clip");
			// 
			// AmmoCapacityTextBox
			// 
			this.AmmoCapacityTextBox.BackColor = System.Drawing.Color.Maroon;
			this.AmmoCapacityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AmmoCapacityTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AmmoCapacityTextBox.ForeColor = System.Drawing.Color.White;
			this.AmmoCapacityTextBox.Location = new System.Drawing.Point(128, 24);
			this.AmmoCapacityTextBox.Name = "AmmoCapacityTextBox";
			this.AmmoCapacityTextBox.ReadOnly = true;
			this.AmmoCapacityTextBox.Size = new System.Drawing.Size(40, 14);
			this.AmmoCapacityTextBox.TabIndex = 3;
			this.AmmoCapacityTextBox.Text = "0";
			this.AmmoCapacityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.AmmoCapacityTextBox, "The amount of ammo this ship can hold in one clip");
			// 
			// ECMLabel
			// 
			this.ECMLabel.BackColor = System.Drawing.Color.Black;
			this.ECMLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ECMLabel.Location = new System.Drawing.Point(8, 88);
			this.ECMLabel.Name = "ECMLabel";
			this.ECMLabel.Size = new System.Drawing.Size(40, 16);
			this.ECMLabel.TabIndex = 10;
			this.ECMLabel.Text = "ECM:";
			this.InfoToolTip.SetToolTip(this.ECMLabel, "The Electronic CounterMeasure modifier for this ship. The higher the value, the h" +
				"arder it is for missiles to lock");
			// 
			// ECMTextBox
			// 
			this.ECMTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ECMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ECMTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ECMTextBox.ForeColor = System.Drawing.Color.White;
			this.ECMTextBox.Location = new System.Drawing.Point(128, 88);
			this.ECMTextBox.Name = "ECMTextBox";
			this.ECMTextBox.ReadOnly = true;
			this.ECMTextBox.Size = new System.Drawing.Size(40, 14);
			this.ECMTextBox.TabIndex = 11;
			this.ECMTextBox.Text = "0";
			this.ECMTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ECMTextBox, "The Electronic CounterMeasure modifier for this ship. The higher the value, the h" +
				"arder it is for missiles to lock");
			// 
			// EnergyRechargeLabel
			// 
			this.EnergyRechargeLabel.BackColor = System.Drawing.Color.Black;
			this.EnergyRechargeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EnergyRechargeLabel.Location = new System.Drawing.Point(8, 72);
			this.EnergyRechargeLabel.Name = "EnergyRechargeLabel";
			this.EnergyRechargeLabel.Size = new System.Drawing.Size(112, 16);
			this.EnergyRechargeLabel.TabIndex = 8;
			this.EnergyRechargeLabel.Text = "Energy Recharge:";
			this.InfoToolTip.SetToolTip(this.EnergyRechargeLabel, "The rate that this ship\'s batteries recharge (per second)");
			// 
			// EnergyRechargeTextBox
			// 
			this.EnergyRechargeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.EnergyRechargeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.EnergyRechargeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EnergyRechargeTextBox.ForeColor = System.Drawing.Color.White;
			this.EnergyRechargeTextBox.Location = new System.Drawing.Point(128, 72);
			this.EnergyRechargeTextBox.Name = "EnergyRechargeTextBox";
			this.EnergyRechargeTextBox.ReadOnly = true;
			this.EnergyRechargeTextBox.Size = new System.Drawing.Size(40, 14);
			this.EnergyRechargeTextBox.TabIndex = 9;
			this.EnergyRechargeTextBox.Text = "0";
			this.EnergyRechargeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.EnergyRechargeTextBox, "The rate that this ship\'s batteries recharge (per second)");
			// 
			// EnergyLabel
			// 
			this.EnergyLabel.BackColor = System.Drawing.Color.Black;
			this.EnergyLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EnergyLabel.Location = new System.Drawing.Point(8, 56);
			this.EnergyLabel.Name = "EnergyLabel";
			this.EnergyLabel.Size = new System.Drawing.Size(72, 16);
			this.EnergyLabel.TabIndex = 6;
			this.EnergyLabel.Text = "Energy (J):";
			this.InfoToolTip.SetToolTip(this.EnergyLabel, "The amount of energy this ship can hold in its batteries");
			// 
			// EnergyTextBox
			// 
			this.EnergyTextBox.BackColor = System.Drawing.Color.Maroon;
			this.EnergyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.EnergyTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.EnergyTextBox.ForeColor = System.Drawing.Color.White;
			this.EnergyTextBox.Location = new System.Drawing.Point(128, 56);
			this.EnergyTextBox.Name = "EnergyTextBox";
			this.EnergyTextBox.ReadOnly = true;
			this.EnergyTextBox.Size = new System.Drawing.Size(40, 14);
			this.EnergyTextBox.TabIndex = 7;
			this.EnergyTextBox.Text = "0";
			this.EnergyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.EnergyTextBox, "The amount of energy this ship can hold in its batteries");
			// 
			// FuelCapacityLabel
			// 
			this.FuelCapacityLabel.BackColor = System.Drawing.Color.Black;
			this.FuelCapacityLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FuelCapacityLabel.Location = new System.Drawing.Point(8, 40);
			this.FuelCapacityLabel.Name = "FuelCapacityLabel";
			this.FuelCapacityLabel.Size = new System.Drawing.Size(88, 16);
			this.FuelCapacityLabel.TabIndex = 4;
			this.FuelCapacityLabel.Text = "Fuel Capacity:";
			this.InfoToolTip.SetToolTip(this.FuelCapacityLabel, "The amount of fuel this ship can hold in its booster");
			// 
			// FuelCapacityTextBox
			// 
			this.FuelCapacityTextBox.BackColor = System.Drawing.Color.Maroon;
			this.FuelCapacityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.FuelCapacityTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FuelCapacityTextBox.ForeColor = System.Drawing.Color.White;
			this.FuelCapacityTextBox.Location = new System.Drawing.Point(128, 40);
			this.FuelCapacityTextBox.Name = "FuelCapacityTextBox";
			this.FuelCapacityTextBox.ReadOnly = true;
			this.FuelCapacityTextBox.Size = new System.Drawing.Size(40, 14);
			this.FuelCapacityTextBox.TabIndex = 5;
			this.FuelCapacityTextBox.Text = "0";
			this.FuelCapacityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.FuelCapacityTextBox, "The amount of fuel this ship can hold in its booster");
			// 
			// ShipLabel
			// 
			this.ShipLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ShipLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShipLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ShipLabel.Location = new System.Drawing.Point(0, 5);
			this.ShipLabel.Name = "ShipLabel";
			this.ShipLabel.Size = new System.Drawing.Size(176, 16);
			this.ShipLabel.TabIndex = 1;
			this.ShipLabel.Text = "Ship";
			// 
			// IsConstructorLabel
			// 
			this.IsConstructorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.IsConstructorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.IsConstructorLabel.Location = new System.Drawing.Point(8, 184);
			this.IsConstructorLabel.Name = "IsConstructorLabel";
			this.IsConstructorLabel.Size = new System.Drawing.Size(80, 16);
			this.IsConstructorLabel.TabIndex = 25;
			this.IsConstructorLabel.Text = "Is Constructor";
			this.InfoToolTip.SetToolTip(this.IsConstructorLabel, "This ship is a constructor that will build a station in a rock");
			// 
			// RipTimeLabel
			// 
			this.RipTimeLabel.BackColor = System.Drawing.Color.Black;
			this.RipTimeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipTimeLabel.Location = new System.Drawing.Point(8, 24);
			this.RipTimeLabel.Name = "RipTimeLabel";
			this.RipTimeLabel.Size = new System.Drawing.Size(80, 16);
			this.RipTimeLabel.TabIndex = 2;
			this.RipTimeLabel.Text = "Rip Time (s):";
			this.InfoToolTip.SetToolTip(this.RipTimeLabel, "The amount of time it takes for this ship to complete a ripcord after starting");
			// 
			// RipTimeTextBox
			// 
			this.RipTimeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RipTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RipTimeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipTimeTextBox.ForeColor = System.Drawing.Color.White;
			this.RipTimeTextBox.Location = new System.Drawing.Point(128, 24);
			this.RipTimeTextBox.Name = "RipTimeTextBox";
			this.RipTimeTextBox.ReadOnly = true;
			this.RipTimeTextBox.Size = new System.Drawing.Size(40, 14);
			this.RipTimeTextBox.TabIndex = 3;
			this.RipTimeTextBox.Text = "0";
			this.RipTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RipTimeTextBox, "The amount of time it takes for this ship to complete a ripcord after starting");
			// 
			// RipCostLabel
			// 
			this.RipCostLabel.BackColor = System.Drawing.Color.Black;
			this.RipCostLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipCostLabel.Location = new System.Drawing.Point(8, 40);
			this.RipCostLabel.Name = "RipCostLabel";
			this.RipCostLabel.Size = new System.Drawing.Size(80, 16);
			this.RipCostLabel.TabIndex = 4;
			this.RipCostLabel.Text = "Rip Cost (J):";
			this.InfoToolTip.SetToolTip(this.RipCostLabel, "The amount of energy removed from the teleport\'s battery when this ship teleports" +
				" to it");
			// 
			// RipCostTextBox
			// 
			this.RipCostTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RipCostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RipCostTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipCostTextBox.ForeColor = System.Drawing.Color.White;
			this.RipCostTextBox.Location = new System.Drawing.Point(128, 40);
			this.RipCostTextBox.Name = "RipCostTextBox";
			this.RipCostTextBox.ReadOnly = true;
			this.RipCostTextBox.Size = new System.Drawing.Size(40, 14);
			this.RipCostTextBox.TabIndex = 5;
			this.RipCostTextBox.Text = "0";
			this.RipCostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RipCostTextBox, "The amount of energy removed from the teleport\'s battery when this ship teleports" +
				" to it");
			// 
			// RipcordPanel
			// 
			this.RipcordPanel.Controls.Add(this.SmallRipcordLabel);
			this.RipcordPanel.Controls.Add(this.CanUseSmallRipLabel);
			this.RipcordPanel.Controls.Add(this.CantRipcordLabel);
			this.RipcordPanel.Controls.Add(this.LargeRipcordLabel);
			this.RipcordPanel.Controls.Add(this.RipcordLabel);
			this.RipcordPanel.Controls.Add(this.RipCostTextBox);
			this.RipcordPanel.Controls.Add(this.RipCostLabel);
			this.RipcordPanel.Controls.Add(this.RipTimeLabel);
			this.RipcordPanel.Controls.Add(this.RipTimeTextBox);
			this.RipcordPanel.Location = new System.Drawing.Point(0, 240);
			this.RipcordPanel.Name = "RipcordPanel";
			this.RipcordPanel.Size = new System.Drawing.Size(176, 96);
			this.RipcordPanel.TabIndex = 42;
			// 
			// SmallRipcordLabel
			// 
			this.SmallRipcordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SmallRipcordLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.SmallRipcordLabel.Location = new System.Drawing.Point(96, 80);
			this.SmallRipcordLabel.Name = "SmallRipcordLabel";
			this.SmallRipcordLabel.Size = new System.Drawing.Size(72, 16);
			this.SmallRipcordLabel.TabIndex = 9;
			this.SmallRipcordLabel.Text = "Small Ripcord";
			this.SmallRipcordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CanUseSmallRipLabel
			// 
			this.CanUseSmallRipLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CanUseSmallRipLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CanUseSmallRipLabel.Location = new System.Drawing.Point(72, 64);
			this.CanUseSmallRipLabel.Name = "CanUseSmallRipLabel";
			this.CanUseSmallRipLabel.Size = new System.Drawing.Size(96, 16);
			this.CanUseSmallRipLabel.TabIndex = 7;
			this.CanUseSmallRipLabel.Text = "Can Use SmallRip";
			this.CanUseSmallRipLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// CantRipcordLabel
			// 
			this.CantRipcordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CantRipcordLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CantRipcordLabel.Location = new System.Drawing.Point(0, 64);
			this.CantRipcordLabel.Name = "CantRipcordLabel";
			this.CantRipcordLabel.Size = new System.Drawing.Size(80, 16);
			this.CantRipcordLabel.TabIndex = 6;
			this.CantRipcordLabel.Text = "Can\'t Ripcord";
			// 
			// LargeRipcordLabel
			// 
			this.LargeRipcordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LargeRipcordLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.LargeRipcordLabel.Location = new System.Drawing.Point(0, 80);
			this.LargeRipcordLabel.Name = "LargeRipcordLabel";
			this.LargeRipcordLabel.Size = new System.Drawing.Size(88, 16);
			this.LargeRipcordLabel.TabIndex = 8;
			this.LargeRipcordLabel.Text = "Large Ripcord";
			// 
			// RipcordLabel
			// 
			this.RipcordLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.RipcordLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RipcordLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.RipcordLabel.Location = new System.Drawing.Point(0, 5);
			this.RipcordLabel.Name = "RipcordLabel";
			this.RipcordLabel.Size = new System.Drawing.Size(174, 16);
			this.RipcordLabel.TabIndex = 1;
			this.RipcordLabel.Text = "Ripcord";
			// 
			// TurnRatePanel
			// 
			this.TurnRatePanel.Controls.Add(this.RollDriftTextBox);
			this.TurnRatePanel.Controls.Add(this.RollDriftLabel);
			this.TurnRatePanel.Controls.Add(this.RollLabel);
			this.TurnRatePanel.Controls.Add(this.RollRateTextBox);
			this.TurnRatePanel.Controls.Add(this.YawDriftTextBox);
			this.TurnRatePanel.Controls.Add(this.YawDriftLabel);
			this.TurnRatePanel.Controls.Add(this.YawRateLabel);
			this.TurnRatePanel.Controls.Add(this.YawRateTextBox);
			this.TurnRatePanel.Controls.Add(this.PitchDriftTextBox);
			this.TurnRatePanel.Controls.Add(this.PitchDriftLabel);
			this.TurnRatePanel.Controls.Add(this.PitchRateLabel);
			this.TurnRatePanel.Controls.Add(this.PitchRateTextBox);
			this.TurnRatePanel.Controls.Add(this.TurnRateLabel);
			this.TurnRatePanel.Location = new System.Drawing.Point(0, 160);
			this.TurnRatePanel.Name = "TurnRatePanel";
			this.TurnRatePanel.Size = new System.Drawing.Size(176, 72);
			this.TurnRatePanel.TabIndex = 43;
			// 
			// RollDriftTextBox
			// 
			this.RollDriftTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RollDriftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RollDriftTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RollDriftTextBox.ForeColor = System.Drawing.Color.White;
			this.RollDriftTextBox.Location = new System.Drawing.Point(128, 56);
			this.RollDriftTextBox.Name = "RollDriftTextBox";
			this.RollDriftTextBox.ReadOnly = true;
			this.RollDriftTextBox.Size = new System.Drawing.Size(40, 14);
			this.RollDriftTextBox.TabIndex = 13;
			this.RollDriftTextBox.Text = "0";
			this.RollDriftTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RollDriftTextBox, "The amount of extra rolling performed after the turn has stopped");
			// 
			// RollDriftLabel
			// 
			this.RollDriftLabel.BackColor = System.Drawing.Color.Black;
			this.RollDriftLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RollDriftLabel.Location = new System.Drawing.Point(92, 56);
			this.RollDriftLabel.Name = "RollDriftLabel";
			this.RollDriftLabel.Size = new System.Drawing.Size(40, 16);
			this.RollDriftLabel.TabIndex = 12;
			this.RollDriftLabel.Text = "Torq:";
			this.InfoToolTip.SetToolTip(this.RollDriftLabel, "The amount of extra rolling performed after the turn has stopped");
			// 
			// RollLabel
			// 
			this.RollLabel.BackColor = System.Drawing.Color.Black;
			this.RollLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RollLabel.Location = new System.Drawing.Point(8, 56);
			this.RollLabel.Name = "RollLabel";
			this.RollLabel.Size = new System.Drawing.Size(40, 16);
			this.RollLabel.TabIndex = 10;
			this.RollLabel.Text = "Roll:";
			this.InfoToolTip.SetToolTip(this.RollLabel, "The rate at which this ship can roll around its centre");
			// 
			// RollRateTextBox
			// 
			this.RollRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RollRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RollRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RollRateTextBox.ForeColor = System.Drawing.Color.White;
			this.RollRateTextBox.Location = new System.Drawing.Point(48, 56);
			this.RollRateTextBox.Name = "RollRateTextBox";
			this.RollRateTextBox.ReadOnly = true;
			this.RollRateTextBox.Size = new System.Drawing.Size(40, 14);
			this.RollRateTextBox.TabIndex = 11;
			this.RollRateTextBox.Text = "0";
			this.RollRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RollRateTextBox, "The rate at which this ship can roll around its centre");
			// 
			// YawDriftTextBox
			// 
			this.YawDriftTextBox.BackColor = System.Drawing.Color.Maroon;
			this.YawDriftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.YawDriftTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.YawDriftTextBox.ForeColor = System.Drawing.Color.White;
			this.YawDriftTextBox.Location = new System.Drawing.Point(128, 40);
			this.YawDriftTextBox.Name = "YawDriftTextBox";
			this.YawDriftTextBox.ReadOnly = true;
			this.YawDriftTextBox.Size = new System.Drawing.Size(40, 14);
			this.YawDriftTextBox.TabIndex = 9;
			this.YawDriftTextBox.Text = "0";
			this.YawDriftTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.YawDriftTextBox, "The amount of extra up/down turning performed after the turn has stopped");
			// 
			// YawDriftLabel
			// 
			this.YawDriftLabel.BackColor = System.Drawing.Color.Black;
			this.YawDriftLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.YawDriftLabel.Location = new System.Drawing.Point(92, 40);
			this.YawDriftLabel.Name = "YawDriftLabel";
			this.YawDriftLabel.Size = new System.Drawing.Size(40, 16);
			this.YawDriftLabel.TabIndex = 8;
			this.YawDriftLabel.Text = "Torq:";
			this.InfoToolTip.SetToolTip(this.YawDriftLabel, "The amount of extra up/down turning performed after the turn has stopped");
			// 
			// YawRateLabel
			// 
			this.YawRateLabel.BackColor = System.Drawing.Color.Black;
			this.YawRateLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.YawRateLabel.Location = new System.Drawing.Point(8, 40);
			this.YawRateLabel.Name = "YawRateLabel";
			this.YawRateLabel.Size = new System.Drawing.Size(40, 16);
			this.YawRateLabel.TabIndex = 6;
			this.YawRateLabel.Text = "Yaw:";
			this.InfoToolTip.SetToolTip(this.YawRateLabel, "The rate at which this ship can turn left/right");
			// 
			// YawRateTextBox
			// 
			this.YawRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.YawRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.YawRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.YawRateTextBox.ForeColor = System.Drawing.Color.White;
			this.YawRateTextBox.Location = new System.Drawing.Point(48, 40);
			this.YawRateTextBox.Name = "YawRateTextBox";
			this.YawRateTextBox.ReadOnly = true;
			this.YawRateTextBox.Size = new System.Drawing.Size(40, 14);
			this.YawRateTextBox.TabIndex = 7;
			this.YawRateTextBox.Text = "0";
			this.YawRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.YawRateTextBox, "The rate at which this ship can turn left/right");
			// 
			// PitchDriftTextBox
			// 
			this.PitchDriftTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PitchDriftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PitchDriftTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PitchDriftTextBox.ForeColor = System.Drawing.Color.White;
			this.PitchDriftTextBox.Location = new System.Drawing.Point(128, 24);
			this.PitchDriftTextBox.Name = "PitchDriftTextBox";
			this.PitchDriftTextBox.ReadOnly = true;
			this.PitchDriftTextBox.Size = new System.Drawing.Size(40, 14);
			this.PitchDriftTextBox.TabIndex = 5;
			this.PitchDriftTextBox.Text = "0";
			this.PitchDriftTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PitchDriftTextBox, "The amount of extra left/right turning performed after the turn has stopped");
			// 
			// PitchDriftLabel
			// 
			this.PitchDriftLabel.BackColor = System.Drawing.Color.Black;
			this.PitchDriftLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PitchDriftLabel.Location = new System.Drawing.Point(92, 24);
			this.PitchDriftLabel.Name = "PitchDriftLabel";
			this.PitchDriftLabel.Size = new System.Drawing.Size(40, 16);
			this.PitchDriftLabel.TabIndex = 4;
			this.PitchDriftLabel.Text = "Torq:";
			this.InfoToolTip.SetToolTip(this.PitchDriftLabel, "The amount of extra left/right turning performed after the turn has stopped");
			// 
			// PitchRateLabel
			// 
			this.PitchRateLabel.BackColor = System.Drawing.Color.Black;
			this.PitchRateLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PitchRateLabel.Location = new System.Drawing.Point(8, 24);
			this.PitchRateLabel.Name = "PitchRateLabel";
			this.PitchRateLabel.Size = new System.Drawing.Size(40, 16);
			this.PitchRateLabel.TabIndex = 2;
			this.PitchRateLabel.Text = "Pitch:";
			this.InfoToolTip.SetToolTip(this.PitchRateLabel, "The rate at which this ship can turn up/down");
			// 
			// PitchRateTextBox
			// 
			this.PitchRateTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PitchRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PitchRateTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PitchRateTextBox.ForeColor = System.Drawing.Color.White;
			this.PitchRateTextBox.Location = new System.Drawing.Point(48, 24);
			this.PitchRateTextBox.Name = "PitchRateTextBox";
			this.PitchRateTextBox.ReadOnly = true;
			this.PitchRateTextBox.Size = new System.Drawing.Size(40, 14);
			this.PitchRateTextBox.TabIndex = 3;
			this.PitchRateTextBox.Text = "0";
			this.PitchRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.PitchRateTextBox, "The rate at which this ship can turn up/down");
			// 
			// TurnRateLabel
			// 
			this.TurnRateLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.TurnRateLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TurnRateLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.TurnRateLabel.Location = new System.Drawing.Point(0, 5);
			this.TurnRateLabel.Name = "TurnRateLabel";
			this.TurnRateLabel.Size = new System.Drawing.Size(174, 16);
			this.TurnRateLabel.TabIndex = 1;
			this.TurnRateLabel.Text = "Turn Rate";
			// 
			// CargoPanel
			// 
			this.CargoPanel.Controls.Add(this.WeaponsPanel);
			this.CargoPanel.Controls.Add(this.ChaffPanel);
			this.CargoPanel.Controls.Add(this.CargoGroupBox);
			this.CargoPanel.Controls.Add(this.CargoLabel);
			this.CargoPanel.Controls.Add(this.TurretsPanel);
			this.CargoPanel.Controls.Add(this.MissilePanel);
			this.CargoPanel.Controls.Add(this.BoosterPanel);
			this.CargoPanel.Controls.Add(this.ShieldPanel);
			this.CargoPanel.Controls.Add(this.CloakPanel);
			this.CargoPanel.Controls.Add(this.PackPanel);
			this.CargoPanel.Location = new System.Drawing.Point(0, 336);
			this.CargoPanel.Name = "CargoPanel";
			this.CargoPanel.Size = new System.Drawing.Size(352, 188);
			this.CargoPanel.TabIndex = 45;
			// 
			// WeaponsPanel
			// 
			this.WeaponsPanel.Controls.Add(this.WeaponSlot3Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot4Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot1Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot2Panel);
			this.WeaponsPanel.Location = new System.Drawing.Point(0, 24);
			this.WeaponsPanel.Name = "WeaponsPanel";
			this.WeaponsPanel.Size = new System.Drawing.Size(176, 64);
			this.WeaponsPanel.TabIndex = 63;
			// 
			// WeaponSlot3Panel
			// 
			this.WeaponSlot3Panel.Controls.Add(this.Wep3Label);
			this.WeaponSlot3Panel.Controls.Add(this.UseWeapon3CheckBox);
			this.WeaponSlot3Panel.Controls.Add(this.Wep3TextBox);
			this.WeaponSlot3Panel.Enabled = false;
			this.WeaponSlot3Panel.Location = new System.Drawing.Point(0, 32);
			this.WeaponSlot3Panel.Name = "WeaponSlot3Panel";
			this.WeaponSlot3Panel.Size = new System.Drawing.Size(172, 16);
			this.WeaponSlot3Panel.TabIndex = 48;
			// 
			// Wep3Label
			// 
			this.Wep3Label.BackColor = System.Drawing.Color.Black;
			this.Wep3Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep3Label.Location = new System.Drawing.Point(16, 0);
			this.Wep3Label.Name = "Wep3Label";
			this.Wep3Label.Size = new System.Drawing.Size(49, 16);
			this.Wep3Label.TabIndex = 1;
			this.Wep3Label.Text = "Wep 3:";
			this.InfoToolTip.SetToolTip(this.Wep3Label, "Shows the weapon loaded in this gun slot");
			// 
			// UseWeapon3CheckBox
			// 
			this.UseWeapon3CheckBox.AutoCheck = false;
			this.UseWeapon3CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon3CheckBox.Location = new System.Drawing.Point(0, -1);
			this.UseWeapon3CheckBox.Name = "UseWeapon3CheckBox";
			this.UseWeapon3CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon3CheckBox.TabIndex = 65;
			this.UseWeapon3CheckBox.Tag = "2";
			this.InfoToolTip.SetToolTip(this.UseWeapon3CheckBox, "Check this box to fire this weapon. Check it again to unlink weapons");
			this.UseWeapon3CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// Wep3TextBox
			// 
			this.Wep3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep3TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep3TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep3TextBox.Location = new System.Drawing.Point(64, 0);
			this.Wep3TextBox.Name = "Wep3TextBox";
			this.Wep3TextBox.ReadOnly = true;
			this.Wep3TextBox.Size = new System.Drawing.Size(104, 14);
			this.Wep3TextBox.TabIndex = 2;
			this.Wep3TextBox.Tag = "2";
			this.Wep3TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep3TextBox, "Shows the weapon loaded in this gun slot");
			// 
			// AvailablePartsContextMenu
			// 
			this.AvailablePartsContextMenu.Popup += new System.EventHandler(this.AvailablePartsContextMenu_Popup);
			// 
			// WeaponSlot4Panel
			// 
			this.WeaponSlot4Panel.Controls.Add(this.Wep4TextBox);
			this.WeaponSlot4Panel.Controls.Add(this.Wep4Label);
			this.WeaponSlot4Panel.Controls.Add(this.UseWeapon4CheckBox);
			this.WeaponSlot4Panel.Enabled = false;
			this.WeaponSlot4Panel.Location = new System.Drawing.Point(0, 48);
			this.WeaponSlot4Panel.Name = "WeaponSlot4Panel";
			this.WeaponSlot4Panel.Size = new System.Drawing.Size(172, 16);
			this.WeaponSlot4Panel.TabIndex = 48;
			// 
			// Wep4TextBox
			// 
			this.Wep4TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep4TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep4TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep4TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep4TextBox.Location = new System.Drawing.Point(64, 0);
			this.Wep4TextBox.Name = "Wep4TextBox";
			this.Wep4TextBox.ReadOnly = true;
			this.Wep4TextBox.Size = new System.Drawing.Size(104, 14);
			this.Wep4TextBox.TabIndex = 2;
			this.Wep4TextBox.Tag = "3";
			this.Wep4TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep4TextBox, "Shows the weapon loaded in this gun slot");
			// 
			// Wep4Label
			// 
			this.Wep4Label.BackColor = System.Drawing.Color.Black;
			this.Wep4Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep4Label.Location = new System.Drawing.Point(16, 0);
			this.Wep4Label.Name = "Wep4Label";
			this.Wep4Label.Size = new System.Drawing.Size(40, 16);
			this.Wep4Label.TabIndex = 1;
			this.Wep4Label.Text = "Wep 4:";
			this.InfoToolTip.SetToolTip(this.Wep4Label, "Shows the weapon loaded in this gun slot");
			// 
			// UseWeapon4CheckBox
			// 
			this.UseWeapon4CheckBox.AutoCheck = false;
			this.UseWeapon4CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon4CheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseWeapon4CheckBox.Name = "UseWeapon4CheckBox";
			this.UseWeapon4CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon4CheckBox.TabIndex = 66;
			this.UseWeapon4CheckBox.Tag = "3";
			this.InfoToolTip.SetToolTip(this.UseWeapon4CheckBox, "Check this box to fire this weapon. Check it again to unlink weapons");
			this.UseWeapon4CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// WeaponSlot1Panel
			// 
			this.WeaponSlot1Panel.Controls.Add(this.UseWeapon1CheckBox);
			this.WeaponSlot1Panel.Controls.Add(this.Wep1TextBox);
			this.WeaponSlot1Panel.Controls.Add(this.Wep1Label);
			this.WeaponSlot1Panel.Enabled = false;
			this.WeaponSlot1Panel.Location = new System.Drawing.Point(0, 0);
			this.WeaponSlot1Panel.Name = "WeaponSlot1Panel";
			this.WeaponSlot1Panel.Size = new System.Drawing.Size(172, 16);
			this.WeaponSlot1Panel.TabIndex = 46;
			// 
			// UseWeapon1CheckBox
			// 
			this.UseWeapon1CheckBox.AutoCheck = false;
			this.UseWeapon1CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon1CheckBox.Location = new System.Drawing.Point(0, -1);
			this.UseWeapon1CheckBox.Name = "UseWeapon1CheckBox";
			this.UseWeapon1CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon1CheckBox.TabIndex = 64;
			this.UseWeapon1CheckBox.Tag = "0";
			this.InfoToolTip.SetToolTip(this.UseWeapon1CheckBox, "Check this box to fire this weapon. Check it again to unlink weapons");
			this.UseWeapon1CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// Wep1TextBox
			// 
			this.Wep1TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep1TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep1TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep1TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep1TextBox.Location = new System.Drawing.Point(64, 0);
			this.Wep1TextBox.Name = "Wep1TextBox";
			this.Wep1TextBox.ReadOnly = true;
			this.Wep1TextBox.Size = new System.Drawing.Size(104, 14);
			this.Wep1TextBox.TabIndex = 2;
			this.Wep1TextBox.Tag = "0";
			this.Wep1TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep1TextBox, "Shows the weapon loaded in this gun slot");
			// 
			// Wep1Label
			// 
			this.Wep1Label.BackColor = System.Drawing.Color.Black;
			this.Wep1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep1Label.Location = new System.Drawing.Point(16, 0);
			this.Wep1Label.Name = "Wep1Label";
			this.Wep1Label.Size = new System.Drawing.Size(48, 16);
			this.Wep1Label.TabIndex = 1;
			this.Wep1Label.Text = "Wep 1:";
			this.InfoToolTip.SetToolTip(this.Wep1Label, "Shows the weapon loaded in this gun slot");
			// 
			// WeaponSlot2Panel
			// 
			this.WeaponSlot2Panel.Controls.Add(this.UseWeapon2CheckBox);
			this.WeaponSlot2Panel.Controls.Add(this.Wep2TextBox);
			this.WeaponSlot2Panel.Controls.Add(this.Wep2Label);
			this.WeaponSlot2Panel.Enabled = false;
			this.WeaponSlot2Panel.Location = new System.Drawing.Point(0, 16);
			this.WeaponSlot2Panel.Name = "WeaponSlot2Panel";
			this.WeaponSlot2Panel.Size = new System.Drawing.Size(172, 16);
			this.WeaponSlot2Panel.TabIndex = 48;
			// 
			// UseWeapon2CheckBox
			// 
			this.UseWeapon2CheckBox.AutoCheck = false;
			this.UseWeapon2CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon2CheckBox.Location = new System.Drawing.Point(0, -1);
			this.UseWeapon2CheckBox.Name = "UseWeapon2CheckBox";
			this.UseWeapon2CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon2CheckBox.TabIndex = 64;
			this.UseWeapon2CheckBox.Tag = "1";
			this.InfoToolTip.SetToolTip(this.UseWeapon2CheckBox, "Check this box to fire this weapon. Check it again to unlink weapons");
			this.UseWeapon2CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// Wep2TextBox
			// 
			this.Wep2TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep2TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep2TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep2TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep2TextBox.Location = new System.Drawing.Point(64, 0);
			this.Wep2TextBox.Name = "Wep2TextBox";
			this.Wep2TextBox.ReadOnly = true;
			this.Wep2TextBox.Size = new System.Drawing.Size(104, 14);
			this.Wep2TextBox.TabIndex = 2;
			this.Wep2TextBox.Tag = "1";
			this.Wep2TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep2TextBox, "Shows the weapon loaded in this gun slot");
			// 
			// Wep2Label
			// 
			this.Wep2Label.BackColor = System.Drawing.Color.Black;
			this.Wep2Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep2Label.Location = new System.Drawing.Point(16, 0);
			this.Wep2Label.Name = "Wep2Label";
			this.Wep2Label.Size = new System.Drawing.Size(49, 16);
			this.Wep2Label.TabIndex = 1;
			this.Wep2Label.Text = "Wep 2:";
			this.InfoToolTip.SetToolTip(this.Wep2Label, "Shows the weapon loaded in this gun slot");
			// 
			// ChaffPanel
			// 
			this.ChaffPanel.Controls.Add(this.ChaffLabel);
			this.ChaffPanel.Controls.Add(this.ChaffTextBox);
			this.ChaffPanel.Enabled = false;
			this.ChaffPanel.Location = new System.Drawing.Point(176, 88);
			this.ChaffPanel.Name = "ChaffPanel";
			this.ChaffPanel.Size = new System.Drawing.Size(176, 16);
			this.ChaffPanel.TabIndex = 46;
			// 
			// ChaffLabel
			// 
			this.ChaffLabel.BackColor = System.Drawing.Color.Black;
			this.ChaffLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ChaffLabel.Location = new System.Drawing.Point(16, 0);
			this.ChaffLabel.Name = "ChaffLabel";
			this.ChaffLabel.Size = new System.Drawing.Size(40, 16);
			this.ChaffLabel.TabIndex = 1;
			this.ChaffLabel.Text = "Chaff:";
			this.InfoToolTip.SetToolTip(this.ChaffLabel, "Shows the chaff (countermeasure) in this slot");
			// 
			// ChaffTextBox
			// 
			this.ChaffTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ChaffTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChaffTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.ChaffTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ChaffTextBox.ForeColor = System.Drawing.Color.White;
			this.ChaffTextBox.Location = new System.Drawing.Point(72, 0);
			this.ChaffTextBox.Name = "ChaffTextBox";
			this.ChaffTextBox.ReadOnly = true;
			this.ChaffTextBox.Size = new System.Drawing.Size(96, 14);
			this.ChaffTextBox.TabIndex = 2;
			this.ChaffTextBox.Tag = "8";
			this.ChaffTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.ChaffTextBox, "Shows the chaff (countermeasure) in this slot");
			// 
			// CargoGroupBox
			// 
			this.CargoGroupBox.Controls.Add(this.Cargo1Label);
			this.CargoGroupBox.Controls.Add(this.CargoItemsPanel);
			this.CargoGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CargoGroupBox.Location = new System.Drawing.Point(191, 97);
			this.CargoGroupBox.Name = "CargoGroupBox";
			this.CargoGroupBox.Size = new System.Drawing.Size(155, 90);
			this.CargoGroupBox.TabIndex = 62;
			this.CargoGroupBox.TabStop = false;
			// 
			// Cargo1Label
			// 
			this.Cargo1Label.BackColor = System.Drawing.Color.Black;
			this.Cargo1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo1Label.Location = new System.Drawing.Point(2, 8);
			this.Cargo1Label.Name = "Cargo1Label";
			this.Cargo1Label.Size = new System.Drawing.Size(48, 16);
			this.Cargo1Label.TabIndex = 1;
			this.Cargo1Label.Text = "Cargo:";
			this.InfoToolTip.SetToolTip(this.Cargo1Label, "This ship\'s cargo");
			// 
			// CargoItemsPanel
			// 
			this.CargoItemsPanel.Controls.Add(this.Cargo1TextBox);
			this.CargoItemsPanel.Controls.Add(this.Cargo2TextBox);
			this.CargoItemsPanel.Controls.Add(this.Cargo3TextBox);
			this.CargoItemsPanel.Controls.Add(this.Cargo4TextBox);
			this.CargoItemsPanel.Controls.Add(this.Cargo5TextBox);
			this.CargoItemsPanel.Location = new System.Drawing.Point(56, 10);
			this.CargoItemsPanel.Name = "CargoItemsPanel";
			this.CargoItemsPanel.Size = new System.Drawing.Size(97, 78);
			this.CargoItemsPanel.TabIndex = 46;
			// 
			// Cargo1TextBox
			// 
			this.Cargo1TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Cargo1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Cargo1TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Cargo1TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo1TextBox.ForeColor = System.Drawing.Color.White;
			this.Cargo1TextBox.Location = new System.Drawing.Point(0, 0);
			this.Cargo1TextBox.Name = "Cargo1TextBox";
			this.Cargo1TextBox.ReadOnly = true;
			this.Cargo1TextBox.Size = new System.Drawing.Size(96, 14);
			this.Cargo1TextBox.TabIndex = 2;
			this.Cargo1TextBox.Tag = "16";
			this.Cargo1TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Cargo1TextBox, "Shows the part loaded in this cargo bay slot");
			// 
			// Cargo2TextBox
			// 
			this.Cargo2TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Cargo2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Cargo2TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Cargo2TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo2TextBox.ForeColor = System.Drawing.Color.White;
			this.Cargo2TextBox.Location = new System.Drawing.Point(0, 16);
			this.Cargo2TextBox.Name = "Cargo2TextBox";
			this.Cargo2TextBox.ReadOnly = true;
			this.Cargo2TextBox.Size = new System.Drawing.Size(96, 14);
			this.Cargo2TextBox.TabIndex = 3;
			this.Cargo2TextBox.Tag = "17";
			this.Cargo2TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Cargo2TextBox, "Shows the part loaded in this cargo bay slot");
			// 
			// Cargo3TextBox
			// 
			this.Cargo3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Cargo3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Cargo3TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Cargo3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo3TextBox.ForeColor = System.Drawing.Color.White;
			this.Cargo3TextBox.Location = new System.Drawing.Point(0, 32);
			this.Cargo3TextBox.Name = "Cargo3TextBox";
			this.Cargo3TextBox.ReadOnly = true;
			this.Cargo3TextBox.Size = new System.Drawing.Size(96, 14);
			this.Cargo3TextBox.TabIndex = 5;
			this.Cargo3TextBox.Tag = "18";
			this.Cargo3TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Cargo3TextBox, "Shows the part loaded in this cargo bay slot");
			// 
			// Cargo4TextBox
			// 
			this.Cargo4TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Cargo4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Cargo4TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Cargo4TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo4TextBox.ForeColor = System.Drawing.Color.White;
			this.Cargo4TextBox.Location = new System.Drawing.Point(0, 48);
			this.Cargo4TextBox.Name = "Cargo4TextBox";
			this.Cargo4TextBox.ReadOnly = true;
			this.Cargo4TextBox.Size = new System.Drawing.Size(96, 14);
			this.Cargo4TextBox.TabIndex = 60;
			this.Cargo4TextBox.Tag = "19";
			this.Cargo4TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Cargo4TextBox, "Shows the part loaded in this cargo bay slot");
			// 
			// Cargo5TextBox
			// 
			this.Cargo5TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Cargo5TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Cargo5TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Cargo5TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Cargo5TextBox.ForeColor = System.Drawing.Color.White;
			this.Cargo5TextBox.Location = new System.Drawing.Point(0, 64);
			this.Cargo5TextBox.Name = "Cargo5TextBox";
			this.Cargo5TextBox.ReadOnly = true;
			this.Cargo5TextBox.Size = new System.Drawing.Size(96, 14);
			this.Cargo5TextBox.TabIndex = 6;
			this.Cargo5TextBox.Tag = "20";
			this.Cargo5TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Cargo5TextBox, "Shows the part loaded in this cargo bay slot");
			// 
			// CargoLabel
			// 
			this.CargoLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.CargoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CargoLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.CargoLabel.Location = new System.Drawing.Point(0, 5);
			this.CargoLabel.Name = "CargoLabel";
			this.CargoLabel.Size = new System.Drawing.Size(352, 16);
			this.CargoLabel.TabIndex = 29;
			this.CargoLabel.Text = "Cargo";
			// 
			// TurretsPanel
			// 
			this.TurretsPanel.Controls.Add(this.TurretSlot1Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot2Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot3Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot4Panel);
			this.TurretsPanel.Location = new System.Drawing.Point(0, 120);
			this.TurretsPanel.Name = "TurretsPanel";
			this.TurretsPanel.Size = new System.Drawing.Size(176, 64);
			this.TurretsPanel.TabIndex = 46;
			// 
			// TurretSlot1Panel
			// 
			this.TurretSlot1Panel.Controls.Add(this.UseTurr1CheckBox);
			this.TurretSlot1Panel.Controls.Add(this.Turr1Label);
			this.TurretSlot1Panel.Controls.Add(this.Turr1TextBox);
			this.TurretSlot1Panel.Enabled = false;
			this.TurretSlot1Panel.Location = new System.Drawing.Point(0, 0);
			this.TurretSlot1Panel.Name = "TurretSlot1Panel";
			this.TurretSlot1Panel.Size = new System.Drawing.Size(172, 16);
			this.TurretSlot1Panel.TabIndex = 47;
			// 
			// UseTurr1CheckBox
			// 
			this.UseTurr1CheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseTurr1CheckBox.Name = "UseTurr1CheckBox";
			this.UseTurr1CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr1CheckBox.TabIndex = 1;
			this.UseTurr1CheckBox.Tag = "0";
			this.InfoToolTip.SetToolTip(this.UseTurr1CheckBox, "Fires this turret, updating the calculated values as necessary");
			this.UseTurr1CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Click);
			// 
			// Turr1Label
			// 
			this.Turr1Label.BackColor = System.Drawing.Color.Black;
			this.Turr1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr1Label.Location = new System.Drawing.Point(16, 0);
			this.Turr1Label.Name = "Turr1Label";
			this.Turr1Label.Size = new System.Drawing.Size(48, 16);
			this.Turr1Label.TabIndex = 2;
			this.Turr1Label.Text = "Turr 1:";
			this.InfoToolTip.SetToolTip(this.Turr1Label, "Shows the weapon mounted in this slot");
			// 
			// Turr1TextBox
			// 
			this.Turr1TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr1TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr1TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr1TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr1TextBox.Location = new System.Drawing.Point(64, 0);
			this.Turr1TextBox.Name = "Turr1TextBox";
			this.Turr1TextBox.ReadOnly = true;
			this.Turr1TextBox.Size = new System.Drawing.Size(104, 14);
			this.Turr1TextBox.TabIndex = 3;
			this.Turr1TextBox.Tag = "4";
			this.Turr1TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr1TextBox, "Shows the weapon mounted in this slot");
			// 
			// TurretSlot2Panel
			// 
			this.TurretSlot2Panel.Controls.Add(this.UseTurr2CheckBox);
			this.TurretSlot2Panel.Controls.Add(this.Turr2Label);
			this.TurretSlot2Panel.Controls.Add(this.Turr2TextBox);
			this.TurretSlot2Panel.Enabled = false;
			this.TurretSlot2Panel.Location = new System.Drawing.Point(0, 16);
			this.TurretSlot2Panel.Name = "TurretSlot2Panel";
			this.TurretSlot2Panel.Size = new System.Drawing.Size(172, 16);
			this.TurretSlot2Panel.TabIndex = 47;
			// 
			// UseTurr2CheckBox
			// 
			this.UseTurr2CheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseTurr2CheckBox.Name = "UseTurr2CheckBox";
			this.UseTurr2CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr2CheckBox.TabIndex = 1;
			this.UseTurr2CheckBox.Tag = "1";
			this.InfoToolTip.SetToolTip(this.UseTurr2CheckBox, "Fires this turret, updating the calculated values as necessary");
			this.UseTurr2CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Click);
			// 
			// Turr2Label
			// 
			this.Turr2Label.BackColor = System.Drawing.Color.Black;
			this.Turr2Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr2Label.Location = new System.Drawing.Point(16, 0);
			this.Turr2Label.Name = "Turr2Label";
			this.Turr2Label.Size = new System.Drawing.Size(48, 16);
			this.Turr2Label.TabIndex = 2;
			this.Turr2Label.Text = "Turr 2:";
			this.InfoToolTip.SetToolTip(this.Turr2Label, "Shows the weapon mounted in this slot");
			// 
			// Turr2TextBox
			// 
			this.Turr2TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr2TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr2TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr2TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr2TextBox.Location = new System.Drawing.Point(64, 0);
			this.Turr2TextBox.Name = "Turr2TextBox";
			this.Turr2TextBox.ReadOnly = true;
			this.Turr2TextBox.Size = new System.Drawing.Size(104, 14);
			this.Turr2TextBox.TabIndex = 3;
			this.Turr2TextBox.Tag = "5";
			this.Turr2TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr2TextBox, "Shows the weapon mounted in this slot");
			// 
			// TurretSlot3Panel
			// 
			this.TurretSlot3Panel.Controls.Add(this.UseTurr3CheckBox);
			this.TurretSlot3Panel.Controls.Add(this.Turr3Label);
			this.TurretSlot3Panel.Controls.Add(this.Turr3TextBox);
			this.TurretSlot3Panel.Enabled = false;
			this.TurretSlot3Panel.Location = new System.Drawing.Point(0, 32);
			this.TurretSlot3Panel.Name = "TurretSlot3Panel";
			this.TurretSlot3Panel.Size = new System.Drawing.Size(172, 16);
			this.TurretSlot3Panel.TabIndex = 47;
			// 
			// UseTurr3CheckBox
			// 
			this.UseTurr3CheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseTurr3CheckBox.Name = "UseTurr3CheckBox";
			this.UseTurr3CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr3CheckBox.TabIndex = 1;
			this.UseTurr3CheckBox.Tag = "2";
			this.InfoToolTip.SetToolTip(this.UseTurr3CheckBox, "Fires this turret, updating the calculated values as necessary");
			this.UseTurr3CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Click);
			// 
			// Turr3Label
			// 
			this.Turr3Label.BackColor = System.Drawing.Color.Black;
			this.Turr3Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr3Label.Location = new System.Drawing.Point(16, 0);
			this.Turr3Label.Name = "Turr3Label";
			this.Turr3Label.Size = new System.Drawing.Size(48, 16);
			this.Turr3Label.TabIndex = 2;
			this.Turr3Label.Text = "Turr 3:";
			this.InfoToolTip.SetToolTip(this.Turr3Label, "Shows the weapon mounted in this slot");
			// 
			// Turr3TextBox
			// 
			this.Turr3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr3TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr3TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr3TextBox.Location = new System.Drawing.Point(64, 0);
			this.Turr3TextBox.Name = "Turr3TextBox";
			this.Turr3TextBox.ReadOnly = true;
			this.Turr3TextBox.Size = new System.Drawing.Size(104, 14);
			this.Turr3TextBox.TabIndex = 3;
			this.Turr3TextBox.Tag = "6";
			this.Turr3TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr3TextBox, "Shows the weapon mounted in this slot");
			// 
			// TurretSlot4Panel
			// 
			this.TurretSlot4Panel.Controls.Add(this.UseTurr4CheckBox);
			this.TurretSlot4Panel.Controls.Add(this.Turr4Label);
			this.TurretSlot4Panel.Controls.Add(this.Turr4TextBox);
			this.TurretSlot4Panel.Enabled = false;
			this.TurretSlot4Panel.Location = new System.Drawing.Point(0, 48);
			this.TurretSlot4Panel.Name = "TurretSlot4Panel";
			this.TurretSlot4Panel.Size = new System.Drawing.Size(172, 16);
			this.TurretSlot4Panel.TabIndex = 47;
			// 
			// UseTurr4CheckBox
			// 
			this.UseTurr4CheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseTurr4CheckBox.Name = "UseTurr4CheckBox";
			this.UseTurr4CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr4CheckBox.TabIndex = 1;
			this.UseTurr4CheckBox.Tag = "3";
			this.InfoToolTip.SetToolTip(this.UseTurr4CheckBox, "Fires this turret, updating the calculated values as necessary");
			this.UseTurr4CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Click);
			// 
			// Turr4Label
			// 
			this.Turr4Label.BackColor = System.Drawing.Color.Black;
			this.Turr4Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr4Label.Location = new System.Drawing.Point(16, 0);
			this.Turr4Label.Name = "Turr4Label";
			this.Turr4Label.Size = new System.Drawing.Size(48, 16);
			this.Turr4Label.TabIndex = 2;
			this.Turr4Label.Text = "Turr 4:";
			this.InfoToolTip.SetToolTip(this.Turr4Label, "Shows the weapon mounted in this slot");
			// 
			// Turr4TextBox
			// 
			this.Turr4TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr4TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr4TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr4TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr4TextBox.Location = new System.Drawing.Point(64, 0);
			this.Turr4TextBox.Name = "Turr4TextBox";
			this.Turr4TextBox.ReadOnly = true;
			this.Turr4TextBox.Size = new System.Drawing.Size(104, 14);
			this.Turr4TextBox.TabIndex = 3;
			this.Turr4TextBox.Tag = "7";
			this.Turr4TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr4TextBox, "Shows the weapon mounted in this slot");
			// 
			// MissilePanel
			// 
			this.MissilePanel.Controls.Add(this.UseMissileCheckBox);
			this.MissilePanel.Controls.Add(this.MissileLabel);
			this.MissilePanel.Controls.Add(this.MissileTextBox);
			this.MissilePanel.Enabled = false;
			this.MissilePanel.Location = new System.Drawing.Point(0, 96);
			this.MissilePanel.Name = "MissilePanel";
			this.MissilePanel.Size = new System.Drawing.Size(176, 16);
			this.MissilePanel.TabIndex = 46;
			// 
			// UseMissileCheckBox
			// 
			this.UseMissileCheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseMissileCheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseMissileCheckBox.Name = "UseMissileCheckBox";
			this.UseMissileCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseMissileCheckBox.TabIndex = 67;
			this.UseMissileCheckBox.Tag = "3";
			this.InfoToolTip.SetToolTip(this.UseMissileCheckBox, "Check this box to fire this ship\'s missile");
			this.UseMissileCheckBox.Click += new System.EventHandler(this.UseMissileCheckBox_Click);
			// 
			// MissileLabel
			// 
			this.MissileLabel.BackColor = System.Drawing.Color.Black;
			this.MissileLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MissileLabel.Location = new System.Drawing.Point(15, 0);
			this.MissileLabel.Name = "MissileLabel";
			this.MissileLabel.Size = new System.Drawing.Size(48, 16);
			this.MissileLabel.TabIndex = 1;
			this.MissileLabel.Text = "Missile:";
			// 
			// MissileTextBox
			// 
			this.MissileTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MissileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MissileTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.MissileTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MissileTextBox.ForeColor = System.Drawing.Color.White;
			this.MissileTextBox.Location = new System.Drawing.Point(64, 0);
			this.MissileTextBox.Name = "MissileTextBox";
			this.MissileTextBox.ReadOnly = true;
			this.MissileTextBox.Size = new System.Drawing.Size(104, 14);
			this.MissileTextBox.TabIndex = 2;
			this.MissileTextBox.Tag = "10";
			this.MissileTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.MissileTextBox, "Shows the missile mounted in this slot");
			// 
			// BoosterPanel
			// 
			this.BoosterPanel.Controls.Add(this.UseBoosterCheckBox);
			this.BoosterPanel.Controls.Add(this.BoosterLabel);
			this.BoosterPanel.Controls.Add(this.BoosterTextBox);
			this.BoosterPanel.Enabled = false;
			this.BoosterPanel.Location = new System.Drawing.Point(176, 24);
			this.BoosterPanel.Name = "BoosterPanel";
			this.BoosterPanel.Size = new System.Drawing.Size(176, 16);
			this.BoosterPanel.TabIndex = 46;
			// 
			// UseBoosterCheckBox
			// 
			this.UseBoosterCheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseBoosterCheckBox.Name = "UseBoosterCheckBox";
			this.UseBoosterCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseBoosterCheckBox.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UseBoosterCheckBox, "Check this box to fire this ship\'s booster");
			this.UseBoosterCheckBox.Click += new System.EventHandler(this.UseBoosterCheckBox_Click);
			// 
			// BoosterLabel
			// 
			this.BoosterLabel.BackColor = System.Drawing.Color.Black;
			this.BoosterLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BoosterLabel.Location = new System.Drawing.Point(16, 0);
			this.BoosterLabel.Name = "BoosterLabel";
			this.BoosterLabel.Size = new System.Drawing.Size(56, 16);
			this.BoosterLabel.TabIndex = 2;
			this.BoosterLabel.Text = "Booster:";
			this.InfoToolTip.SetToolTip(this.BoosterLabel, "Shows the booster in this slot");
			// 
			// BoosterTextBox
			// 
			this.BoosterTextBox.BackColor = System.Drawing.Color.Maroon;
			this.BoosterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BoosterTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.BoosterTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BoosterTextBox.ForeColor = System.Drawing.Color.White;
			this.BoosterTextBox.Location = new System.Drawing.Point(72, 0);
			this.BoosterTextBox.Name = "BoosterTextBox";
			this.BoosterTextBox.ReadOnly = true;
			this.BoosterTextBox.Size = new System.Drawing.Size(96, 14);
			this.BoosterTextBox.TabIndex = 3;
			this.BoosterTextBox.Tag = "15";
			this.BoosterTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.BoosterTextBox, "Shows the booster in this slot");
			// 
			// ShieldPanel
			// 
			this.ShieldPanel.Controls.Add(this.ShieldLabel);
			this.ShieldPanel.Controls.Add(this.ShieldTextBox);
			this.ShieldPanel.Enabled = false;
			this.ShieldPanel.Location = new System.Drawing.Point(176, 40);
			this.ShieldPanel.Name = "ShieldPanel";
			this.ShieldPanel.Size = new System.Drawing.Size(176, 16);
			this.ShieldPanel.TabIndex = 46;
			// 
			// ShieldLabel
			// 
			this.ShieldLabel.BackColor = System.Drawing.Color.Black;
			this.ShieldLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldLabel.Location = new System.Drawing.Point(16, 0);
			this.ShieldLabel.Name = "ShieldLabel";
			this.ShieldLabel.Size = new System.Drawing.Size(48, 16);
			this.ShieldLabel.TabIndex = 1;
			this.ShieldLabel.Text = "Shield:";
			this.InfoToolTip.SetToolTip(this.ShieldLabel, "Shows the shield in this slot");
			// 
			// ShieldTextBox
			// 
			this.ShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.ShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldTextBox.Location = new System.Drawing.Point(72, 0);
			this.ShieldTextBox.Name = "ShieldTextBox";
			this.ShieldTextBox.ReadOnly = true;
			this.ShieldTextBox.Size = new System.Drawing.Size(96, 14);
			this.ShieldTextBox.TabIndex = 2;
			this.ShieldTextBox.Tag = "12";
			this.ShieldTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.ShieldTextBox, "Shows the shield in this slot");
			// 
			// CloakPanel
			// 
			this.CloakPanel.Controls.Add(this.UseCloakCheckBox);
			this.CloakPanel.Controls.Add(this.CloakLabel);
			this.CloakPanel.Controls.Add(this.CloakTextBox);
			this.CloakPanel.Enabled = false;
			this.CloakPanel.Location = new System.Drawing.Point(176, 56);
			this.CloakPanel.Name = "CloakPanel";
			this.CloakPanel.Size = new System.Drawing.Size(176, 16);
			this.CloakPanel.TabIndex = 46;
			// 
			// UseCloakCheckBox
			// 
			this.UseCloakCheckBox.Location = new System.Drawing.Point(0, 0);
			this.UseCloakCheckBox.Name = "UseCloakCheckBox";
			this.UseCloakCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseCloakCheckBox.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UseCloakCheckBox, "Check this box to enable this ship\'s cloak");
			this.UseCloakCheckBox.Click += new System.EventHandler(this.UseCloakCheckBox_Click);
			// 
			// CloakLabel
			// 
			this.CloakLabel.BackColor = System.Drawing.Color.Black;
			this.CloakLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CloakLabel.Location = new System.Drawing.Point(16, 0);
			this.CloakLabel.Name = "CloakLabel";
			this.CloakLabel.Size = new System.Drawing.Size(40, 16);
			this.CloakLabel.TabIndex = 2;
			this.CloakLabel.Text = "Cloak:";
			this.InfoToolTip.SetToolTip(this.CloakLabel, "Shows the cloak in this slot");
			// 
			// CloakTextBox
			// 
			this.CloakTextBox.BackColor = System.Drawing.Color.Maroon;
			this.CloakTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CloakTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.CloakTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CloakTextBox.ForeColor = System.Drawing.Color.White;
			this.CloakTextBox.Location = new System.Drawing.Point(72, 0);
			this.CloakTextBox.Name = "CloakTextBox";
			this.CloakTextBox.ReadOnly = true;
			this.CloakTextBox.Size = new System.Drawing.Size(96, 14);
			this.CloakTextBox.TabIndex = 3;
			this.CloakTextBox.Tag = "13";
			this.CloakTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.CloakTextBox, "Shows the cloak in this slot");
			// 
			// PackPanel
			// 
			this.PackPanel.Controls.Add(this.PackLabel);
			this.PackPanel.Controls.Add(this.PackTextBox);
			this.PackPanel.Enabled = false;
			this.PackPanel.Location = new System.Drawing.Point(176, 72);
			this.PackPanel.Name = "PackPanel";
			this.PackPanel.Size = new System.Drawing.Size(176, 16);
			this.PackPanel.TabIndex = 46;
			// 
			// PackLabel
			// 
			this.PackLabel.BackColor = System.Drawing.Color.Black;
			this.PackLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PackLabel.Location = new System.Drawing.Point(16, 0);
			this.PackLabel.Name = "PackLabel";
			this.PackLabel.Size = new System.Drawing.Size(40, 16);
			this.PackLabel.TabIndex = 1;
			this.PackLabel.Text = "Pack:";
			this.InfoToolTip.SetToolTip(this.PackLabel, "Shows the mines or probes in this slot");
			// 
			// PackTextBox
			// 
			this.PackTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PackTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PackTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.PackTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PackTextBox.ForeColor = System.Drawing.Color.White;
			this.PackTextBox.Location = new System.Drawing.Point(72, 0);
			this.PackTextBox.Name = "PackTextBox";
			this.PackTextBox.ReadOnly = true;
			this.PackTextBox.Size = new System.Drawing.Size(96, 14);
			this.PackTextBox.TabIndex = 2;
			this.PackTextBox.Tag = "11";
			this.PackTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.PackTextBox, "Shows the mines or probes in this slot");
			// 
			// SensorEnvelopePictureBox
			// 
			this.SensorEnvelopePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SensorEnvelopePictureBox.Image")));
			this.SensorEnvelopePictureBox.Location = new System.Drawing.Point(0, 20);
			this.SensorEnvelopePictureBox.Name = "SensorEnvelopePictureBox";
			this.SensorEnvelopePictureBox.Size = new System.Drawing.Size(57, 57);
			this.SensorEnvelopePictureBox.TabIndex = 19;
			this.SensorEnvelopePictureBox.TabStop = false;
			this.InfoToolTip.SetToolTip(this.SensorEnvelopePictureBox, "Scanrange behind a ship is only a fraction of the forward scan range. This graphi" +
				"c represents the ship\'s \"Sensor Envelope.\" Click somewhere within this area to c" +
				"alculate the detection range at this angle");
			this.SensorEnvelopePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SensorEnvelopePictureBox_Paint);
			this.SensorEnvelopePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SensorEnvelopePictureBox_MouseMove);
			this.SensorEnvelopePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SensorEnvelopePictureBox_MouseDown);
			// 
			// BearingLabel
			// 
			this.BearingLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BearingLabel.Location = new System.Drawing.Point(57, 56);
			this.BearingLabel.Name = "BearingLabel";
			this.BearingLabel.Size = new System.Drawing.Size(72, 16);
			this.BearingLabel.TabIndex = 7;
			this.BearingLabel.Text = "Bearing (°):";
			this.InfoToolTip.SetToolTip(this.BearingLabel, "The angle at which the target is located. Use the graphic at the left to specify " +
				"an angle");
			// 
			// BearingTextBox
			// 
			this.BearingTextBox.BackColor = System.Drawing.Color.Maroon;
			this.BearingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BearingTextBox.ForeColor = System.Drawing.Color.White;
			this.BearingTextBox.Location = new System.Drawing.Point(128, 56);
			this.BearingTextBox.Name = "BearingTextBox";
			this.BearingTextBox.ReadOnly = true;
			this.BearingTextBox.Size = new System.Drawing.Size(40, 14);
			this.BearingTextBox.TabIndex = 8;
			this.BearingTextBox.Text = "0";
			this.BearingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.BearingTextBox, "The angle at which the target is located. Use the graphic at the left to specify " +
				"an angle");
			// 
			// DamagePanel
			// 
			this.DamagePanel.Controls.Add(this.KillsLabel);
			this.DamagePanel.Controls.Add(this.KillBonusTextBox);
			this.DamagePanel.Controls.Add(this.KillCountNumericUpDown);
			this.DamagePanel.Controls.Add(this.KillBonusLabel);
			this.DamagePanel.Controls.Add(this.TotalDamageTextBox);
			this.DamagePanel.Controls.Add(this.TotalDamageLabel);
			this.DamagePanel.Controls.Add(this.WeaponsRangeTextBox);
			this.DamagePanel.Controls.Add(this.WeaponRangeLabel);
			this.DamagePanel.Controls.Add(this.DamageHeaderLabel);
			this.DamagePanel.Location = new System.Drawing.Point(0, 80);
			this.DamagePanel.Name = "DamagePanel";
			this.DamagePanel.Size = new System.Drawing.Size(176, 77);
			this.DamagePanel.TabIndex = 46;
			this.InfoToolTip.SetToolTip(this.DamagePanel, "Fire a weapon to see this ship\'s weaponrange and damage calculations");
			// 
			// KillsLabel
			// 
			this.KillsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.KillsLabel.Location = new System.Drawing.Point(8, 56);
			this.KillsLabel.Name = "KillsLabel";
			this.KillsLabel.Size = new System.Drawing.Size(32, 16);
			this.KillsLabel.TabIndex = 33;
			this.KillsLabel.Text = "Kills:";
			this.InfoToolTip.SetToolTip(this.KillsLabel, "The number of kills posessed by the pilot of this ship");
			// 
			// KillBonusTextBox
			// 
			this.KillBonusTextBox.BackColor = System.Drawing.Color.Maroon;
			this.KillBonusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KillBonusTextBox.ForeColor = System.Drawing.Color.White;
			this.KillBonusTextBox.Location = new System.Drawing.Point(128, 56);
			this.KillBonusTextBox.Name = "KillBonusTextBox";
			this.KillBonusTextBox.ReadOnly = true;
			this.KillBonusTextBox.Size = new System.Drawing.Size(40, 14);
			this.KillBonusTextBox.TabIndex = 32;
			this.KillBonusTextBox.Text = "10";
			this.KillBonusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.KillBonusTextBox, "The percent damage added on to the base damage of this pilot\'s weapons");
			// 
			// KillCountNumericUpDown
			// 
			this.KillCountNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.KillCountNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KillCountNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.KillCountNumericUpDown.Location = new System.Drawing.Point(40, 56);
			this.KillCountNumericUpDown.Maximum = new System.Decimal(new int[] {
																				   1000,
																				   0,
																				   0,
																				   0});
			this.KillCountNumericUpDown.Name = "KillCountNumericUpDown";
			this.KillCountNumericUpDown.Size = new System.Drawing.Size(40, 14);
			this.KillCountNumericUpDown.TabIndex = 31;
			this.InfoToolTip.SetToolTip(this.KillCountNumericUpDown, "The number of kills posessed by the pilot of this ship");
			this.KillCountNumericUpDown.Value = new System.Decimal(new int[] {
																				 1,
																				 0,
																				 0,
																				 0});
			this.KillCountNumericUpDown.ValueChanged += new System.EventHandler(this.KillCountNumericUpDown_ValueChanged);
			// 
			// KillBonusLabel
			// 
			this.KillBonusLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.KillBonusLabel.Location = new System.Drawing.Point(88, 56);
			this.KillBonusLabel.Name = "KillBonusLabel";
			this.KillBonusLabel.Size = new System.Drawing.Size(32, 16);
			this.KillBonusLabel.TabIndex = 30;
			this.KillBonusLabel.Text = "KB:";
			this.InfoToolTip.SetToolTip(this.KillBonusLabel, "The percent damage added on to the base damage of this pilot\'s weapons");
			// 
			// TotalDamageTextBox
			// 
			this.TotalDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.TotalDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TotalDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.TotalDamageTextBox.Location = new System.Drawing.Point(128, 40);
			this.TotalDamageTextBox.Name = "TotalDamageTextBox";
			this.TotalDamageTextBox.ReadOnly = true;
			this.TotalDamageTextBox.Size = new System.Drawing.Size(40, 14);
			this.TotalDamageTextBox.TabIndex = 5;
			this.TotalDamageTextBox.Text = "0";
			this.TotalDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.TotalDamageTextBox, "The total amount of hitpoints-per-second that this ship\'s firing weapons will dea" +
				"l to another");
			// 
			// TotalDamageLabel
			// 
			this.TotalDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TotalDamageLabel.Location = new System.Drawing.Point(8, 40);
			this.TotalDamageLabel.Name = "TotalDamageLabel";
			this.TotalDamageLabel.Size = new System.Drawing.Size(112, 16);
			this.TotalDamageLabel.TabIndex = 4;
			this.TotalDamageLabel.Text = "Total Dmg (hp/s):";
			this.InfoToolTip.SetToolTip(this.TotalDamageLabel, "The total amount of hitpoints-per-second that this ship\'s firing weapons will dea" +
				"l to another");
			// 
			// WeaponsRangeTextBox
			// 
			this.WeaponsRangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.WeaponsRangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WeaponsRangeTextBox.ForeColor = System.Drawing.Color.White;
			this.WeaponsRangeTextBox.Location = new System.Drawing.Point(128, 24);
			this.WeaponsRangeTextBox.Name = "WeaponsRangeTextBox";
			this.WeaponsRangeTextBox.ReadOnly = true;
			this.WeaponsRangeTextBox.Size = new System.Drawing.Size(40, 14);
			this.WeaponsRangeTextBox.TabIndex = 3;
			this.WeaponsRangeTextBox.Text = "0";
			this.WeaponsRangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.WeaponsRangeTextBox, "The range of the furthest-shooting weapon being fired. use the checkbox beside th" +
				"e weapon to fire it");
			// 
			// WeaponRangeLabel
			// 
			this.WeaponRangeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WeaponRangeLabel.Location = new System.Drawing.Point(8, 24);
			this.WeaponRangeLabel.Name = "WeaponRangeLabel";
			this.WeaponRangeLabel.Size = new System.Drawing.Size(104, 16);
			this.WeaponRangeLabel.TabIndex = 2;
			this.WeaponRangeLabel.Text = "Wep. Range (m):";
			this.InfoToolTip.SetToolTip(this.WeaponRangeLabel, "The range of the furthest-shooting weapon being fired. use the checkbox beside th" +
				"e weapon to fire it");
			// 
			// DamageHeaderLabel
			// 
			this.DamageHeaderLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.DamageHeaderLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DamageHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.DamageHeaderLabel.Location = new System.Drawing.Point(0, 5);
			this.DamageHeaderLabel.Name = "DamageHeaderLabel";
			this.DamageHeaderLabel.Size = new System.Drawing.Size(174, 16);
			this.DamageHeaderLabel.TabIndex = 29;
			this.DamageHeaderLabel.Text = "Damage";
			this.InfoToolTip.SetToolTip(this.DamageHeaderLabel, "Fire a weapon to see this ship\'s weaponrange and damage calculations");
			// 
			// HullDamageTextBox
			// 
			this.HullDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HullDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HullDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.HullDamageTextBox.Location = new System.Drawing.Point(640, 24);
			this.HullDamageTextBox.Name = "HullDamageTextBox";
			this.HullDamageTextBox.ReadOnly = true;
			this.HullDamageTextBox.Size = new System.Drawing.Size(40, 13);
			this.HullDamageTextBox.TabIndex = 24;
			this.HullDamageTextBox.Text = "0";
			this.HullDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HullDamageTextBox, "The real damage applied to this ship\'s target, taking the target\'s Armor Class in" +
				"to account");
			// 
			// ActualDamageLabel
			// 
			this.ActualDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ActualDamageLabel.Location = new System.Drawing.Point(542, 24);
			this.ActualDamageLabel.Name = "ActualDamageLabel";
			this.ActualDamageLabel.Size = new System.Drawing.Size(101, 16);
			this.ActualDamageLabel.TabIndex = 23;
			this.ActualDamageLabel.Text = "Hull Dmg (hp/s):";
			// 
			// TimeToKillTextBox
			// 
			this.TimeToKillTextBox.BackColor = System.Drawing.Color.Maroon;
			this.TimeToKillTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeToKillTextBox.ForeColor = System.Drawing.Color.White;
			this.TimeToKillTextBox.Location = new System.Drawing.Point(304, 24);
			this.TimeToKillTextBox.Name = "TimeToKillTextBox";
			this.TimeToKillTextBox.ReadOnly = true;
			this.TimeToKillTextBox.Size = new System.Drawing.Size(40, 13);
			this.TimeToKillTextBox.TabIndex = 19;
			this.TimeToKillTextBox.Text = "0";
			this.TimeToKillTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.TimeToKillTextBox, "The total time it would take to kill this target, including reload and recharge t" +
				"imes.");
			// 
			// TimeToKillLabel
			// 
			this.TimeToKillLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TimeToKillLabel.Location = new System.Drawing.Point(213, 24);
			this.TimeToKillLabel.Name = "TimeToKillLabel";
			this.TimeToKillLabel.Size = new System.Drawing.Size(96, 16);
			this.TimeToKillLabel.TabIndex = 18;
			this.TimeToKillLabel.Text = "Time To Kill (s):";
			// 
			// ShieldDamageTextBox
			// 
			this.ShieldDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldDamageTextBox.Location = new System.Drawing.Point(640, 40);
			this.ShieldDamageTextBox.Name = "ShieldDamageTextBox";
			this.ShieldDamageTextBox.ReadOnly = true;
			this.ShieldDamageTextBox.Size = new System.Drawing.Size(40, 13);
			this.ShieldDamageTextBox.TabIndex = 26;
			this.ShieldDamageTextBox.Text = "0";
			this.ShieldDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ShieldDamageTextBox, "The real damage applied to this ship\'s target, taking the target\'s Armor Class in" +
				"to account");
			// 
			// ShieldDamageLabel
			// 
			this.ShieldDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldDamageLabel.Location = new System.Drawing.Point(529, 40);
			this.ShieldDamageLabel.Name = "ShieldDamageLabel";
			this.ShieldDamageLabel.Size = new System.Drawing.Size(120, 16);
			this.ShieldDamageLabel.TabIndex = 25;
			this.ShieldDamageLabel.Text = "Shield Dmg (hp/s):";
			// 
			// ShipForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(350, 338);
			this.Controls.Add(this.CargoPanel);
			this.Controls.Add(this.TurnRatePanel);
			this.Controls.Add(this.RipcordPanel);
			this.Controls.Add(this.ShipPanel);
			this.Controls.Add(this.ThrustPanel);
			this.Controls.Add(this.HullPanel);
			this.Controls.Add(this.DamagePanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ShipForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ShipForm_Closing);
			this.Controls.SetChildIndex(this.DamagePanel, 0);
			this.Controls.SetChildIndex(this.SensorsPanel, 0);
			this.Controls.SetChildIndex(this.HullPanel, 0);
			this.Controls.SetChildIndex(this.ThrustPanel, 0);
			this.Controls.SetChildIndex(this.ShipPanel, 0);
			this.Controls.SetChildIndex(this.RipcordPanel, 0);
			this.Controls.SetChildIndex(this.TurnRatePanel, 0);
			this.Controls.SetChildIndex(this.CargoPanel, 0);
			this.SensorsPanel.ResumeLayout(false);
			this.HullPanel.ResumeLayout(false);
			this.ThrustPanel.ResumeLayout(false);
			this.ShipPanel.ResumeLayout(false);
			this.RipcordPanel.ResumeLayout(false);
			this.TurnRatePanel.ResumeLayout(false);
			this.CargoPanel.ResumeLayout(false);
			this.WeaponsPanel.ResumeLayout(false);
			this.WeaponSlot3Panel.ResumeLayout(false);
			this.WeaponSlot4Panel.ResumeLayout(false);
			this.WeaponSlot1Panel.ResumeLayout(false);
			this.WeaponSlot2Panel.ResumeLayout(false);
			this.ChaffPanel.ResumeLayout(false);
			this.CargoGroupBox.ResumeLayout(false);
			this.CargoItemsPanel.ResumeLayout(false);
			this.TurretsPanel.ResumeLayout(false);
			this.TurretSlot1Panel.ResumeLayout(false);
			this.TurretSlot2Panel.ResumeLayout(false);
			this.TurretSlot3Panel.ResumeLayout(false);
			this.TurretSlot4Panel.ResumeLayout(false);
			this.MissilePanel.ResumeLayout(false);
			this.BoosterPanel.ResumeLayout(false);
			this.ShieldPanel.ResumeLayout(false);
			this.CloakPanel.ResumeLayout(false);
			this.PackPanel.ResumeLayout(false);
			this.DamagePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.KillCountNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Updates the form with the latest data from the objects
		/// </summary>
		public void UpdateHandler (object sender, EventArgs e)
		{
			string NoneString = "<None>";

			// Update parts
			if (_ship.CanUseSlot(ShipSlots.Weapon1))
			{
				WeaponSlot1Panel.Enabled = true;
				
				UseWeapon1CheckBox.Checked = false;
				if (_ship.Weapons[0] != null)
				{
					Wep1TextBox.Text = _ship.Weapons[0].Name;
					if (_ship.FireWeapons == true && (_ship.WeaponToFire == 0 || _ship.WeaponToFire == -1))
						UseWeapon1CheckBox.Checked = true;
				}
				else
					Wep1TextBox.Text = NoneString;
			}
			else
			{
				UseWeapon1CheckBox.Checked = false;
				Wep1TextBox.Text = NoneString;
				WeaponSlot1Panel.Enabled = false;
			}

			if (_ship.CanUseSlot(ShipSlots.Weapon2))
			{
				WeaponSlot2Panel.Enabled = true;
				
				UseWeapon2CheckBox.Checked = false;
				if (_ship.Weapons[1] != null)
				{
					Wep2TextBox.Text = _ship.Weapons[1].Name;
					if (_ship.FireWeapons == true && (_ship.WeaponToFire == 1 || _ship.WeaponToFire == -1))
						UseWeapon2CheckBox.Checked = true;
				}
				else
					Wep2TextBox.Text = NoneString;
			}
			else
			{
				UseWeapon2CheckBox.Checked = false;
				Wep2TextBox.Text = NoneString;
				WeaponSlot2Panel.Enabled = false;
			}

			if (_ship.CanUseSlot(ShipSlots.Weapon3))
			{
				WeaponSlot3Panel.Enabled = true;
				UseWeapon3CheckBox.Checked = false;
				if (_ship.Weapons[2] != null)
				{
					Wep3TextBox.Text = _ship.Weapons[2].Name;
					if (_ship.FireWeapons == true && (_ship.WeaponToFire == 2 || _ship.WeaponToFire == -1))
						UseWeapon3CheckBox.Checked = true;
				}
				else
					Wep3TextBox.Text = NoneString;
			}
			else
			{
				UseWeapon3CheckBox.Checked = false;
				Wep3TextBox.Text = NoneString;
				WeaponSlot3Panel.Enabled = false;
			}

			if (_ship.CanUseSlot(ShipSlots.Weapon4))
			{
				WeaponSlot4Panel.Enabled = true;
				UseWeapon4CheckBox.Checked = false;
				if (_ship.Weapons[3] != null)
				{
					Wep4TextBox.Text = _ship.Weapons[3].Name;
					if (_ship.FireWeapons == true && (_ship.WeaponToFire == 3 || _ship.WeaponToFire == -1))
						UseWeapon4CheckBox.Checked = true;
				}
				else
					Wep4TextBox.Text = NoneString;
			}
			else
			{
				UseWeapon4CheckBox.Checked = false;
				Wep4TextBox.Text = NoneString;
				WeaponSlot4Panel.Enabled = false;
			}

			UseTurr1CheckBox.Checked = _ship.FireTurrets[0];
			if (_ship.CanUseSlot(ShipSlots.Turret1))
			{
				TurretSlot1Panel.Enabled = true;
				if (_ship.Turrets[0] != null)
				{
					Turr1TextBox.Text = _ship.Turrets[0].Name;
					UseTurr1CheckBox.Checked = _ship.FireTurrets[0];
				}
				else
				{
					UseTurr1CheckBox.Checked = false;
					Turr1TextBox.Text = NoneString;
				}
			}
			else
			{
				UseTurr1CheckBox.Checked = false;
				Turr1TextBox.Text = NoneString;
				TurretSlot1Panel.Enabled = false;
			}

			UseTurr2CheckBox.Checked = _ship.FireTurrets[1];
			if (_ship.CanUseSlot(ShipSlots.Turret2))
			{
				TurretSlot2Panel.Enabled = true;
				if (_ship.Turrets[1] != null)
				{
					Turr2TextBox.Text = _ship.Turrets[1].Name;
					UseTurr2CheckBox.Checked = _ship.FireTurrets[1];
				}
				else
				{
					UseTurr2CheckBox.Checked = false;
					Turr2TextBox.Text = NoneString;
				}
			}
			else
			{
				UseTurr2CheckBox.Checked = false;
				Turr2TextBox.Text = NoneString;
				TurretSlot2Panel.Enabled = false;
			}

			UseTurr3CheckBox.Checked = _ship.FireTurrets[2];
			if (_ship.CanUseSlot(ShipSlots.Turret3))
			{
				TurretSlot3Panel.Enabled = true;
				if (_ship.Turrets[2] != null)
				{
					Turr3TextBox.Text = _ship.Turrets[2].Name;
					UseTurr3CheckBox.Checked = _ship.FireTurrets[2];
				}
				else
				{
					UseTurr3CheckBox.Checked = false;
					Turr3TextBox.Text = NoneString;
				}
			}
			else
			{
				UseTurr3CheckBox.Checked = false;
				Turr3TextBox.Text = NoneString;
				TurretSlot3Panel.Enabled = false;
			}

			UseTurr4CheckBox.Checked = _ship.FireTurrets[3];
			if (_ship.CanUseSlot(ShipSlots.Turret4))
			{
				TurretSlot4Panel.Enabled = true;
				if (_ship.Turrets[3] != null)
				{
					Turr4TextBox.Text = _ship.Turrets[3].Name;
					UseTurr4CheckBox.Checked = _ship.FireTurrets[3];
				}
				else
				{
					UseTurr4CheckBox.Checked = false;
					Turr4TextBox.Text = NoneString;
				}
			}
			else
			{
				UseTurr4CheckBox.Checked = false;
				Turr4TextBox.Text = NoneString;
				TurretSlot4Panel.Enabled = false;
			}
			
			UseMissileCheckBox.Checked = _ship.FireMissile;
			if (_ship.CanUseSlot(ShipSlots.Missile))
			{
				MissilePanel.Enabled = true;
				if (_ship.Missile != null)
					MissileTextBox.Text = _ship.Missile.Name;
				else
					MissileTextBox.Text = NoneString;
			}
			else
			{
				UseMissileCheckBox.Checked = false;
				MissileTextBox.Text = NoneString;
				MissilePanel.Enabled = false;
			}

			UseBoosterCheckBox.Checked = _ship.FireBooster;
			if (_ship.CanUseSlot(ShipSlots.Booster))
			{
				BoosterPanel.Enabled = true;
				if (_ship.Booster != null)
					BoosterTextBox.Text = _ship.Booster.Name;
				else
					BoosterTextBox.Text = NoneString;
			}
			else
			{
				UseBoosterCheckBox.Checked = false;
				BoosterPanel.Enabled = false;
				BoosterTextBox.Text = NoneString;
			}

			if (_ship.CanUseSlot(ShipSlots.Shield))
			{
				ShieldPanel.Enabled = true;
				if (_ship.Shield != null)
					ShieldTextBox.Text = _ship.Shield.Name;
				else
					ShieldTextBox.Text = NoneString;
			}
			else
			{
				ShieldPanel.Enabled = false;
				ShieldTextBox.Text = NoneString;
			}
			
			UseCloakCheckBox.Checked = _ship.UseCloak;
			if (_ship.CanUseSlot(ShipSlots.Cloak))
			{
				CloakPanel.Enabled = true;
				if (_ship.Cloak != null)
					CloakTextBox.Text = _ship.Cloak.Name;
				else
					CloakTextBox.Text = NoneString;
			}
			else
			{
				UseCloakCheckBox.Checked = false;
				CloakPanel.Enabled = false;
				CloakTextBox.Text = NoneString;
			}

			if (_ship.Cargo[0] == null)
				Cargo1TextBox.Text = NoneString;
			else
				Cargo1TextBox.Text = _ship.Cargo[0].Name;

			if (_ship.Cargo[1] == null)
				Cargo2TextBox.Text = NoneString;
			else
				Cargo2TextBox.Text = _ship.Cargo[1].Name;
			
			if (_ship.Cargo[2] == null)
				Cargo3TextBox.Text = NoneString;
			else
				Cargo3TextBox.Text = _ship.Cargo[2].Name;
			
			if (_ship.Cargo[3] == null)
				Cargo4TextBox.Text = NoneString;
			else
				Cargo4TextBox.Text = _ship.Cargo[3].Name;
			
			if (_ship.Cargo[4] == null)
				Cargo5TextBox.Text = NoneString;
			else
				Cargo5TextBox.Text = _ship.Cargo[4].Name;

			/////////////////////////////////////////////////////////////////
			ScanRangeTextBox.Text = _ship.CalculateScanrange().ToString();
			BearingTextBox.Text = _ship.BearingDegrees.ToString();
			
			SigTextBox.Text = (_ship.CalculateSignature() * 100).ToString();
			
			HitpointsTextBox.Text = _ship.IGCShip.Hitpoints.ToString();
			ACTextBox.Text = Enum.GetName(typeof(IGCArmorClass), _ship.IGCShip.ArmorClass);
			
			PitchRateTextBox.Text = _ship.CalculatePitch().ToString();
			YawRateTextBox.Text = _ship.CalculateYaw().ToString();
			RollRateTextBox.Text = _ship.CalculateRoll().ToString();
			PitchDriftTextBox.Text = _ship.CalculatePitchTorque().ToString();
			YawDriftTextBox.Text = _ship.CalculateYawTorque().ToString();
			RollDriftTextBox.Text = _ship.CalculateRollTorque().ToString();

			RipTimeTextBox.Text = _ship.CalculateRipTime().ToString();
			RipCostTextBox.Text = _ship.IGCShip.RipcordCost.ToString();
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.CantRipcord])
				EnableFeature(CantRipcordLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.LargeRipcord])
				EnableFeature(LargeRipcordLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.CanUseSmallRip])
				EnableFeature(CanUseSmallRipLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.SmallRipcord])
				EnableFeature(SmallRipcordLabel);

			CalculateThrust(_thrustX, _thrustY);

			AmmoCapacityTextBox.Text = _ship.IGCShip.AmmoCapacity.ToString();
			FuelCapacityTextBox.Text = _ship.IGCShip.Fuel.ToString();
			EnergyTextBox.Text = _ship.CalculateEnergy().ToString();
			EnergyRechargeTextBox.Text = _ship.IGCShip.RechargeRate.ToString();
			ECMTextBox.Text = _ship.IGCShip.ECM.ToString();
			KillCountNumericUpDown.Value = _ship.Kills;

			MassTextBox.Text = _ship.CalculateMass().ToString();

			if (_ship.IGCShip.Abilities[(short)ShipAbilities.Captures])
				EnableFeature(CapturesLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.CanRescue])
				EnableFeature(CanRescueLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.IsLifepod])
				EnableFeature(IsLifepodLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.NoEjection])
				EnableFeature(NoEjectLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.SmallShip])
				EnableFeature(SmallShipLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.HasLeadIndicator])
				EnableFeature(HasLeadIndicatorLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.RelaysLeadIndicator])
				EnableFeature(RelaysLeadIndicatorLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.Carrier])
				EnableFeature(IsCarrierLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.Miner])
				EnableFeature(IsMinerLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.Constructor])
				EnableFeature(IsConstructorLabel);
			if (_ship.IGCShip.Abilities[(short)ShipAbilities.WarnStationAtRisk])
				EnableFeature(WarnStationAtRiskLabel);
//			WarnBaseCaptured
//			if (_ship.Abilities[(short)ShipAbilities.F2])
//				EnableFeature(WarnBaseCaptureLabel);
			
			Comparison Comp = null;
			if (_target == null)
				Comp = new Comparison(_ship, _ship.KillBonus, 100F, 0F);
			else
				Comp = new Comparison(_ship, _ship.KillBonus, 100F, 0F, _target);
			WeaponsRangeTextBox.Text = Comp.Range.ToString();
			TotalDamageTextBox.Text = Comp.Damage.ToString();
		}

		public void ClosedHandler (object sender, EventArgs e)
		{
			_ship.Updated -= new EventHandler(UpdateHandler);
			_ship.Closed -= new EventHandler(ClosedHandler);
			this.Close();
			this.Dispose();
		}

		private void UseWeaponCheckBox_Click (object sender, System.EventArgs e)
		{
			CheckBox Sender = (CheckBox)sender;
			if (_ship.FireWeapons == false)
			{	// Fire All
				_ship.WeaponToFire = -1;
				_ship.FireWeapons = true;
			}
			else
			{	// I'm already firing...
				if (_ship.GetWeaponCount() > 1)
				{
					if (_ship.WeaponToFire == -1)
					{	// Fire Single
						_ship.WeaponToFire = int.Parse(Sender.Tag.ToString());
						_ship.FireWeapons = true;
					}
					else
					{	
						if (_ship.WeaponToFire.ToString().Equals(Sender.Tag.ToString()))
						{	// Disable guns
							_ship.WeaponToFire = -1;
							Sender.Checked = false;
							_ship.FireWeapons = false;
						}
						else
						{	// Set gun
							_ship.WeaponToFire = int.Parse(Sender.Tag.ToString());
							_ship.Update();
						}
					}
				}
				else
				{
					_ship.FireWeapons = false;
				}
			}
		}

		private void UseTurretCheckBox_Click (object sender, System.EventArgs e)
		{
			CheckBox Sender = (CheckBox)sender;
			_ship.FireTurrets[int.Parse(Sender.Tag.ToString())] = Sender.Checked;
			_ship.Update();
		}

		private void UseMissileCheckBox_Click (object sender, System.EventArgs e)
		{
			_ship.FireMissile = UseMissileCheckBox.Checked;
		}

		private void UseBoosterCheckBox_Click (object sender, System.EventArgs e)
		{
			_ship.FireBooster = UseBoosterCheckBox.Checked;
		}

		private void UseCloakCheckBox_Click (object sender, System.EventArgs e)
		{
			_ship.UseCloak = UseCloakCheckBox.Checked;
		}

		/// <summary>
		/// Returns the real weapon ranges and damages applied to the specified target.
		/// The first index is weapons range, 2nd is hull damage, and the 3nd is shield damage.
		/// </summary>
		/// <param name="coreObject"></param>
		/// <returns></returns>
		public float[] GetRealWeaponStats (ObjectForm coreObject)
		{
//			float WeaponsRange = 0;
//			float HullDamage = 0;
//			float ShieldDamage = 0;
//
//			DamageIndex[] Indexes = _ship.Team.Game.Core.Constants.DamageIndexes;
//
//			Factors Mods = _ship.Team.CalculateFactors();
//
//			int HullAC = -1;
//			int ShieldAC = -1;
//
//			// Get ACs
//			if (coreObject != null)
//			{
//				if (coreObject is StationForm)
//				{
//					StationForm TargetStation = (StationForm)coreObject;
//					HullAC = ((IGCCoreStationType)TargetStation.Module).HullArmorClass;
//					ShieldAC = ((IGCCoreStationType)TargetStation.Module).ShieldArmorClass;
//				}
//				if (coreObject is ProbeForm)
//				{
//					ProbeForm TargetProbe = (ProbeForm)coreObject;
//					HullAC = (int)((IGCCoreProbe)TargetProbe.Module).ArmorClass;
//				}
//				if (coreObject is ShipForm)
//				{
//					ShipForm TargetShip = (ShipForm)coreObject;
//					HullAC = (int)((IGCCoreShip)TargetShip.Module).ArmorClass;
//					if (TargetShip._shield != null)
//						ShieldAC = (int)TargetShip._shield.ArmorClass;
//				}
//			}
//
//			// calculate the damage applied by the fired guns
//			if (UseWeaponsCheckBox.Checked == true ||
//				UseTurr1CheckBox.Checked == true ||
//				UseTurr2CheckBox.Checked == true ||
//				UseTurr3CheckBox.Checked == true ||
//				UseTurr4CheckBox.Checked == true)
//			{
//				for (int i = 0; i < _weapons.Length; i++)
//				{
//					IGCCorePartWeapon Weapon = _weapons[i];
//					if (Weapon == null)
//						continue;
//					if (i < 4)
//					{
//						if (UseWeaponsCheckBox.Checked == false)
//							continue;
//					}
//					else
//					{	// Weapon's a turret. If the turret's not being fired, skip it.
//						Panel TurretPanel = (Panel)TurretsPanel.Controls[i - 4];
//						CheckBox TurretCheckbox = (CheckBox)TurretPanel.Controls[0];
//						if (TurretCheckbox.Checked == false)
//							continue;
//					}
//
//					// The weapon is being used! Calculate it's range/damage
//					IGCCoreProjectile Proj = (IGCCoreProjectile)_team.Game.Core.Projectiles.GetModule(Weapon.ProjectileUID);
//					float ProjRange = 0;
//					float ProjDamage = 0;
//					if (Proj != null)
//					{
//						ProjRange = Proj.Speed * Proj.Lifespan * Mods.PWRange;
//						if (ProjRange > WeaponsRange)
//							WeaponsRange = ProjRange;
//
//						float ShotsPerSecond = (1 / Weapon.ShotInterval);
//						float AmmoConsumptionPerSecond = ShotsPerSecond * Weapon.AmmoConsumption;
//						float EnergyConsumptionPerSecond = ShotsPerSecond * Weapon.EnergyConsumption;
//						float DirectDamage = ShotsPerSecond * Proj.ShotDamage * ((float)AccuracyProgressBar.Value / 100F);
//						float AreaDamage = ShotsPerSecond * Proj.AreaDamage;
//						
//						ProjDamage = (DirectDamage + AreaDamage) * Mods.PWDamage;
//
//						if (HullAC != -1)
//							HullDamage += (ProjDamage * (Indexes[Proj.DamageIndex].Damages[HullAC]));
//						else
//							HullDamage += ProjDamage;
//
//						if (Proj.ShotDamage >= 0 && Proj.AreaDamage >= 0)
//						{
//							if (ShieldAC != -1)
//								ShieldDamage += (ProjDamage * (Indexes[Proj.DamageIndex].Damages[ShieldAC]));
//							else
//								ShieldDamage += ProjDamage;
//						}
//					}
//				}
//			}
//			HullDamage += HullDamage * (float)(KillBonusNumericUpDown.Value / 100);
//			ShieldDamage += ShieldDamage * (float)(KillBonusNumericUpDown.Value / 100);

			float[] Results = new float[3];
//			Results[0] = WeaponsRange;
//			Results[1] = HullDamage;
//			Results[2] = ShieldDamage;

			return Results;
		}

		private void ExpandCargoButton_Click (object sender, System.EventArgs e)
		{
			if (ExpandCargoButton.Text.Equals("Cargo »"))
			{
				this.ClientSize = new Size(this.ClientSize.Width, 526);
				ExpandCargoButton.Text = "« Cargo";
			}
			else
			{
				this.ClientSize = new Size(this.ClientSize.Width, 338);
				ExpandCargoButton.Text = "Cargo »";
			}
		}

		/// <summary>
		/// Builds the partlist menu for swapping parts
		/// </summary>
		private void AvailablePartsContextMenu_Popup (object sender, System.EventArgs e)
		{
			ContextMenu Context = (ContextMenu)sender;
			Context.MenuItems.Clear();

			TextBox PartBox = (TextBox)Context.SourceControl;
			int SlotIndex = int.Parse(PartBox.Tag.ToString());

			_partList.Clear();
			_partList.Add(null); // add "<None>" to top of list
			Context.MenuItems.Add("<None>", new EventHandler(AvailablePartsContextMenu_Click));

			BitArray CurrentDefs = _ship.Team.CalculateDefs();
			foreach (IGCCorePart Part in _ship.Team.Game.Core.Parts)
			{
				if (!_settings.ShowOverridden)
				{
					short OverridingID = Part.OverridingUID;
					if (OverridingID > -1)
					{
						IGCCorePart OverridingPart = _ship.GetOverriddenPart((ushort)OverridingID);
						if (OverridingPart != null)
						{
							BitArray WorkingDefs = (BitArray)CurrentDefs.Clone();
							WorkingDefs.And(OverridingPart.Techtree.Pres);
							if (OverridingPart.Techtree.PreEquals(WorkingDefs))
								continue;
						}
					}
				}
				if (_ship.CanMountPart(Part, (ShipSlots)SlotIndex))
				{

					MenuItem Menu = new MenuItem(Part.Name, new EventHandler(AvailablePartsContextMenu_Click));
					Context.MenuItems.Add(Menu);
					_partList.Add(Part);
				}
			}
		}

		/// <summary>
		/// Fills the selected slot with the chosen part
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AvailablePartsContextMenu_Click (object sender, System.EventArgs e)
		{
			MenuItem Item = (MenuItem)sender;
			TextBox Box = (TextBox)((ContextMenu)Item.Parent).SourceControl;
			int SlotIndex = int.Parse(Box.Tag.ToString());

			IGCCorePart Part = null;
			Part = (IGCCorePart)_partList[Item.Index];

			if (SlotIndex < 4)
				_ship.Weapons[SlotIndex] = (IGCCorePartWeapon)Part;
			else
			{
				if (SlotIndex < 8)
					_ship.Turrets[SlotIndex - 4] = (IGCCorePartWeapon)Part;
				else
				{
					if (SlotIndex < 16)
					{
						switch (SlotIndex)
						{
							case 8:
								_ship.Chaff = (IGCCoreCounter)Part;
								break;
							case 10:
								_ship.Missile = (IGCCoreMissile)Part;
								break;
							case 11:
								_ship.Pack = Part;
								break;
							case 12:
								_ship.Shield = (IGCCorePartShield)Part;
								break;
							case 13:
								_ship.Cloak = (IGCCorePartCloak)Part;
								break;
							case 15:
								_ship.Booster = (IGCCorePartAfterburner)Part;
								break;
							default:
								break;
						}
					}
					else
					{ // it's a cargo slot
						_ship.Cargo[SlotIndex - 16] = Part;
					}
				}
			}

			_ship.Update();
		}

		/// <summary>
		/// Updates the RearRange value as the user clicks the sensor envelope
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SensorEnvelopePictureBox_MouseMove (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				UpdateBearing(e.X, e.Y);
		}

		private void SensorEnvelopePictureBox_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				UpdateBearing(e.X, e.Y);
		}

		private void SensorEnvelopePictureBox_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
		{
			PictureBox Box = (PictureBox)sender;
			double TrueBearing = (_bearing > (2 * Math.PI)) ? _bearing - (2 * Math.PI) : _bearing;
			TrueBearing += Math.PI / 2;
			int CenterX = Box.Width / 2;
			int CenterY = Box.Height / 2;
			int X = (int)(Math.Cos(TrueBearing) * -26);
			int Y = (int)(Math.Sin(TrueBearing) * 26);

			e.Graphics.DrawLine(Pens.Maroon, CenterX, CenterY, CenterX + X, CenterY - Y);
		}

		/// <summary>
		/// Calculates the sensor range at the specified coordinate relative to the center of the SensorEnvelopePictureBox
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void UpdateBearing (int x, int y)
		{
			_bearing = Math.Atan2(28 - y, 28 - x);
			_bearing -= Math.PI / 2;
			if (_bearing < 0)
				_bearing += 2 * Math.PI;
			_ship.Bearing = _bearing;
			BearingTextBox.Text = _ship.BearingDegrees.ToString();
			_ship.Update();
			SensorEnvelopePictureBox.Refresh();
		}

		/// <summary>
		/// Paints the visual thrust indicator on the panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ThrustGraphicPanel_Paint (object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Panel panel = (Panel)sender;
			int BarLength = 25;
			float SideThrustMultiplier = _ship.IGCShip.SideThrustMultiplier;
			float ReverseThrustMultiplier = _ship.IGCShip.ReverseThrustMultiplier;

			int CenterX = panel.Width / 2;
			int CenterY = panel.Height / 2;
			Point CenterPoint = new Point(CenterX, CenterY);
			Point TopPoint = new Point(CenterX, CenterY - BarLength);
			Point RightPoint = new Point(CenterX + (int)(BarLength * SideThrustMultiplier), CenterY);
			Point LeftPoint = new Point(CenterX - (int)(BarLength * SideThrustMultiplier), CenterY);
			Point BottomPoint = new Point(CenterX, CenterY + (int)(BarLength * ReverseThrustMultiplier));

			Pen ThrustPen = new Pen(Brushes.Maroon, 5F);
			Pen DiamondPen = new Pen(Brushes.Maroon, 1F);
			Pen DirectionPen = new Pen(Brushes.LightYellow, 1F);
			
			// Draw Cross
			e.Graphics.DrawLine(ThrustPen, CenterPoint, TopPoint);
			e.Graphics.DrawLine(ThrustPen, CenterPoint, RightPoint);
			e.Graphics.DrawLine(ThrustPen, CenterPoint, BottomPoint);
			e.Graphics.DrawLine(ThrustPen, CenterPoint, LeftPoint);

			// Draw Diamond
			e.Graphics.DrawLine(DiamondPen, TopPoint, RightPoint);
			e.Graphics.DrawLine(DiamondPen, RightPoint, BottomPoint);
			e.Graphics.DrawLine(DiamondPen, BottomPoint, LeftPoint);
			e.Graphics.DrawLine(DiamondPen, LeftPoint, TopPoint);

			int X = (int)(Math.Cos(_thrustAngle) * 26);
			int Y = (int)(Math.Sin(_thrustAngle) * 26);
			e.Graphics.DrawLine(DirectionPen, CenterX, CenterY, CenterX + X, CenterY - Y);

			ThrustPen.Dispose();
			DiamondPen.Dispose();
			DirectionPen.Dispose();
		}

		private void ThrustGraphicPanel_MouseMove (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
			{
				_thrustX = e.X;
				_thrustY = e.Y;
				CalculateThrust(_thrustX, _thrustY);
			}
		}

		private void ThrustGraphicPanel_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
			{
				_thrustX = e.X;
				_thrustY = e.Y;
				CalculateThrust(_thrustX, _thrustY);
			}
		}

		/// <summary>
		/// Calculates the thrust for the selected coordinate relative to the center of the ThrustGraphicPanel
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void CalculateThrust (int x, int y)
		{
			int CenterX = ThrustGraphicPanel.Width / 2;
			int CenterY = ThrustGraphicPanel.Height / 2;
			
			int DeltaX = x - CenterX;
			int DeltaY = CenterY - y;

			float Thrust = _ship.IGCShip.MaxThrust;
			float MaxSpeed = _ship.IGCShip.MaxSpeed;

			if (Math.Abs(DeltaX) > Math.Abs(DeltaY))
			{ // One of the sides
				Thrust *= _ship.IGCShip.SideThrustMultiplier;
				MaxSpeed *= _ship.IGCShip.SideThrustMultiplier;
				if (DeltaX < 0)
					_thrustAngle = (-180 * Math.PI / 180);
				else
					_thrustAngle = 0;
			}
			else
			{ // Front or back
				if (DeltaY < 0)
				{ // Back
					Thrust *= _ship.IGCShip.ReverseThrustMultiplier;
					MaxSpeed *= _ship.IGCShip.ReverseThrustMultiplier;
					_thrustAngle = (270 * Math.PI / 180);
				}
				else
				{
					_thrustAngle = (90 * Math.PI / 180);
				}
			}

			if (_ship.Booster != null & _ship.FireBooster == true)
			{
				Thrust += _ship.Booster.Thrust;
				MaxSpeed += (_ship.Booster.Thrust / _ship.IGCShip.MaxThrust) * MaxSpeed;
			}

			Factors Mods = _ship.Team.CalculateFactors();
			MaxSpeed *= Mods.ShipSpeed;
			Thrust *= Mods.ShipAcceleration;

			float Mass = _ship.CalculateMass();
			float Accel = Thrust / Mass;

			AccelTextBox.Text = Math.Round(Accel, 2).ToString();
			MaxSpeedTextBox.Text = Math.Round(MaxSpeed, 2).ToString();
			ThrustGraphicPanel.Refresh();
		}

		private void KillCountNumericUpDown_ValueChanged (object sender, System.EventArgs e)
		{
			NumericUpDown Sender = (NumericUpDown)sender;
			_ship.Kills = (int)Sender.Value;
			KillBonusTextBox.Text = _ship.KillBonus.ToString();
			_ship.Update();
		}

		private void ShipForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_ship.Updated -= new EventHandler(UpdateHandler);
			_ship.Closed -= new EventHandler(ClosedHandler);
			_ship = null;
		}	
	}
}

