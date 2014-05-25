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
	public class ProbeForm : ObjectForm
	{
		#region Form Controls
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox ArmingTimeTextBox;
		private System.Windows.Forms.TextBox LifespanTextBox;
		private System.Windows.Forms.Label LifespanLabel;
		private System.Windows.Forms.Label ShotIntervaLabel;
		private System.Windows.Forms.TextBox ShotIntervalTextBox;
		private System.Windows.Forms.Label AccuracyLabel;
		private System.Windows.Forms.TextBox AccuracyTextBox;
		private System.Windows.Forms.Label LeadingLabel;
		private System.Windows.Forms.TextBox LeadingTextBox;
		private System.Windows.Forms.Label AmmoCapacityLabel;
		private System.Windows.Forms.TextBox AmmoCapacityTextBox;
		private System.Windows.Forms.Label ActivationDelayLabel;
		private System.Windows.Forms.TextBox ActivationDelayTextBox;
		private System.Windows.Forms.Panel WeaponsPanel;
		private System.Windows.Forms.Label WeaponsLabel;
		private System.Windows.Forms.Panel UsagePanel;
		private System.Windows.Forms.Label UseLabel;
		private System.Windows.Forms.Panel CargoPanel;
		private System.Windows.Forms.Label CargoLabel;
		private System.Windows.Forms.TextBox MassTextBox;
		private System.Windows.Forms.Label MassLabel;
		private System.Windows.Forms.TextBox CargoSizeTextBox;
		private System.Windows.Forms.Label CargoSizeLabel;
		private System.Windows.Forms.Panel HullPanel;
		private System.Windows.Forms.Label HullHeaderLabel;
		private System.Windows.Forms.Label ACLabel;
		private System.Windows.Forms.TextBox ACTextBox;
		private System.Windows.Forms.Label HitpointsLabel;
		private System.Windows.Forms.TextBox HitpointsTextBox;
		private System.Windows.Forms.Panel FeaturesPanel;
		private System.Windows.Forms.Label DropWarningLabel;
		private System.Windows.Forms.Label FeaturesLabel;
		private System.Windows.Forms.Label QuickReadyLabel;
		private System.Windows.Forms.Label ShootMissilesLabel;
		private System.Windows.Forms.Label CaptureLabel;
		private System.Windows.Forms.Label ShootTargetOnlyLabel;
		private System.Windows.Forms.Label ShootStationsLabel;
		private System.Windows.Forms.Label ShootShipsLabel;
		private System.Windows.Forms.Label RescueTeamLabel;
		private System.Windows.Forms.Label RescueAllLabel;
		private System.Windows.Forms.Label AlephResonatorLabel;
		private System.Windows.Forms.Label ArmingTimeLabel;
		private System.Windows.Forms.TextBox ShieldDamageTextBox;
		private System.Windows.Forms.Label ShieldDamageLabel;
		private System.Windows.Forms.TextBox HullDamageTextBox;
		private System.Windows.Forms.Label ActualDamageLabel;
		private System.Windows.Forms.TextBox BaseDamageTextBox;
		private System.Windows.Forms.Label BaseDamageLabel;
		private System.Windows.Forms.TextBox WeaponRangeTextBox;
		private System.Windows.Forms.Label WeaponRangeLabel;
		#endregion
		private System.Windows.Forms.Label KillsLabel;
		private System.Windows.Forms.TextBox KillBonusTextBox;
		private System.Windows.Forms.NumericUpDown KillCountNumericUpDown;
		private System.Windows.Forms.Label KillBonusLabel;

		Probe _probe;

		public ProbeForm (TekSettings settings, Probe probe) : base(settings, probe)
		{
			InitializeComponent();
			_probe = probe;
			probe.Updated += new EventHandler(UpdateHandler);
			probe.Closed += new EventHandler(ClosedHandler);
			_probe.Update();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ProbeForm));
			this.ArmingTimeLabel = new System.Windows.Forms.Label();
			this.ArmingTimeTextBox = new System.Windows.Forms.TextBox();
			this.LifespanTextBox = new System.Windows.Forms.TextBox();
			this.LifespanLabel = new System.Windows.Forms.Label();
			this.ShotIntervalTextBox = new System.Windows.Forms.TextBox();
			this.ShotIntervaLabel = new System.Windows.Forms.Label();
			this.AccuracyLabel = new System.Windows.Forms.Label();
			this.AccuracyTextBox = new System.Windows.Forms.TextBox();
			this.LeadingLabel = new System.Windows.Forms.Label();
			this.LeadingTextBox = new System.Windows.Forms.TextBox();
			this.AmmoCapacityLabel = new System.Windows.Forms.Label();
			this.AmmoCapacityTextBox = new System.Windows.Forms.TextBox();
			this.ActivationDelayLabel = new System.Windows.Forms.Label();
			this.ActivationDelayTextBox = new System.Windows.Forms.TextBox();
			this.WeaponsPanel = new System.Windows.Forms.Panel();
			this.KillsLabel = new System.Windows.Forms.Label();
			this.KillBonusTextBox = new System.Windows.Forms.TextBox();
			this.KillCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.KillBonusLabel = new System.Windows.Forms.Label();
			this.WeaponRangeTextBox = new System.Windows.Forms.TextBox();
			this.WeaponRangeLabel = new System.Windows.Forms.Label();
			this.BaseDamageTextBox = new System.Windows.Forms.TextBox();
			this.BaseDamageLabel = new System.Windows.Forms.Label();
			this.WeaponsLabel = new System.Windows.Forms.Label();
			this.UsagePanel = new System.Windows.Forms.Panel();
			this.UseLabel = new System.Windows.Forms.Label();
			this.CargoPanel = new System.Windows.Forms.Panel();
			this.MassTextBox = new System.Windows.Forms.TextBox();
			this.MassLabel = new System.Windows.Forms.Label();
			this.CargoSizeTextBox = new System.Windows.Forms.TextBox();
			this.CargoSizeLabel = new System.Windows.Forms.Label();
			this.CargoLabel = new System.Windows.Forms.Label();
			this.HullPanel = new System.Windows.Forms.Panel();
			this.ACLabel = new System.Windows.Forms.Label();
			this.ACTextBox = new System.Windows.Forms.TextBox();
			this.HitpointsLabel = new System.Windows.Forms.Label();
			this.HitpointsTextBox = new System.Windows.Forms.TextBox();
			this.HullHeaderLabel = new System.Windows.Forms.Label();
			this.FeaturesPanel = new System.Windows.Forms.Panel();
			this.RescueAllLabel = new System.Windows.Forms.Label();
			this.RescueTeamLabel = new System.Windows.Forms.Label();
			this.ShootShipsLabel = new System.Windows.Forms.Label();
			this.ShootStationsLabel = new System.Windows.Forms.Label();
			this.ShootTargetOnlyLabel = new System.Windows.Forms.Label();
			this.AlephResonatorLabel = new System.Windows.Forms.Label();
			this.CaptureLabel = new System.Windows.Forms.Label();
			this.ShootMissilesLabel = new System.Windows.Forms.Label();
			this.QuickReadyLabel = new System.Windows.Forms.Label();
			this.DropWarningLabel = new System.Windows.Forms.Label();
			this.FeaturesLabel = new System.Windows.Forms.Label();
			this.ShieldDamageTextBox = new System.Windows.Forms.TextBox();
			this.ShieldDamageLabel = new System.Windows.Forms.Label();
			this.HullDamageTextBox = new System.Windows.Forms.TextBox();
			this.ActualDamageLabel = new System.Windows.Forms.Label();
			this.SensorsPanel.SuspendLayout();
			this.WeaponsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.KillCountNumericUpDown)).BeginInit();
			this.UsagePanel.SuspendLayout();
			this.CargoPanel.SuspendLayout();
			this.HullPanel.SuspendLayout();
			this.FeaturesPanel.SuspendLayout();
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
			this.SensorsPanel.Size = new System.Drawing.Size(176, 64);
			// 
			// SensorsLabel
			// 
			this.SensorsLabel.Name = "SensorsLabel";
			this.SensorsLabel.Size = new System.Drawing.Size(176, 16);
			// 
			// ArmingTimeLabel
			// 
			this.ArmingTimeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ArmingTimeLabel.Location = new System.Drawing.Point(8, 24);
			this.ArmingTimeLabel.Name = "ArmingTimeLabel";
			this.ArmingTimeLabel.Size = new System.Drawing.Size(104, 16);
			this.ArmingTimeLabel.TabIndex = 13;
			this.ArmingTimeLabel.Text = "Arming Time (s):";
			this.InfoToolTip.SetToolTip(this.ArmingTimeLabel, "The amount of time it takes for this probe to load itself in a ship\'s \"pack\" slot" +
				"");
			// 
			// ArmingTimeTextBox
			// 
			this.ArmingTimeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ArmingTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ArmingTimeTextBox.ForeColor = System.Drawing.Color.White;
			this.ArmingTimeTextBox.Location = new System.Drawing.Point(128, 24);
			this.ArmingTimeTextBox.Name = "ArmingTimeTextBox";
			this.ArmingTimeTextBox.ReadOnly = true;
			this.ArmingTimeTextBox.Size = new System.Drawing.Size(40, 14);
			this.ArmingTimeTextBox.TabIndex = 14;
			this.ArmingTimeTextBox.Text = "0";
			this.ArmingTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ArmingTimeTextBox, "The amount of time it takes for this probe to load itself in a ship\'s \"pack\" slot" +
				"");
			// 
			// LifespanTextBox
			// 
			this.LifespanTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LifespanTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LifespanTextBox.ForeColor = System.Drawing.Color.White;
			this.LifespanTextBox.Location = new System.Drawing.Point(128, 56);
			this.LifespanTextBox.Name = "LifespanTextBox";
			this.LifespanTextBox.ReadOnly = true;
			this.LifespanTextBox.Size = new System.Drawing.Size(40, 14);
			this.LifespanTextBox.TabIndex = 16;
			this.LifespanTextBox.Text = "0";
			this.LifespanTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LifespanTextBox, "The amount of time this probe will remain on the map after deployment before self" +
				"-destructing");
			// 
			// LifespanLabel
			// 
			this.LifespanLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LifespanLabel.Location = new System.Drawing.Point(8, 56);
			this.LifespanLabel.Name = "LifespanLabel";
			this.LifespanLabel.Size = new System.Drawing.Size(80, 16);
			this.LifespanLabel.TabIndex = 15;
			this.LifespanLabel.Text = "Lifespan (s):";
			this.InfoToolTip.SetToolTip(this.LifespanLabel, "The amount of time this probe will remain on the map after deployment before self" +
				"-destructing");
			// 
			// ShotIntervalTextBox
			// 
			this.ShotIntervalTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShotIntervalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShotIntervalTextBox.ForeColor = System.Drawing.Color.White;
			this.ShotIntervalTextBox.Location = new System.Drawing.Point(128, 56);
			this.ShotIntervalTextBox.Name = "ShotIntervalTextBox";
			this.ShotIntervalTextBox.ReadOnly = true;
			this.ShotIntervalTextBox.Size = new System.Drawing.Size(40, 14);
			this.ShotIntervalTextBox.TabIndex = 22;
			this.ShotIntervalTextBox.Text = "0";
			this.ShotIntervalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ShotIntervalTextBox, "The amount of time between shots");
			// 
			// ShotIntervaLabel
			// 
			this.ShotIntervaLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShotIntervaLabel.Location = new System.Drawing.Point(8, 56);
			this.ShotIntervaLabel.Name = "ShotIntervaLabel";
			this.ShotIntervaLabel.Size = new System.Drawing.Size(104, 16);
			this.ShotIntervaLabel.TabIndex = 21;
			this.ShotIntervaLabel.Text = "Shot Interval (s):";
			this.InfoToolTip.SetToolTip(this.ShotIntervaLabel, "The amount of time between shots");
			// 
			// AccuracyLabel
			// 
			this.AccuracyLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AccuracyLabel.Location = new System.Drawing.Point(8, 24);
			this.AccuracyLabel.Name = "AccuracyLabel";
			this.AccuracyLabel.Size = new System.Drawing.Size(88, 16);
			this.AccuracyLabel.TabIndex = 23;
			this.AccuracyLabel.Text = "Accuracy (%):";
			this.InfoToolTip.SetToolTip(this.AccuracyLabel, "The amount of spread this probe\'s weapon fires with");
			// 
			// AccuracyTextBox
			// 
			this.AccuracyTextBox.BackColor = System.Drawing.Color.Maroon;
			this.AccuracyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AccuracyTextBox.ForeColor = System.Drawing.Color.White;
			this.AccuracyTextBox.Location = new System.Drawing.Point(128, 24);
			this.AccuracyTextBox.Name = "AccuracyTextBox";
			this.AccuracyTextBox.ReadOnly = true;
			this.AccuracyTextBox.Size = new System.Drawing.Size(40, 14);
			this.AccuracyTextBox.TabIndex = 24;
			this.AccuracyTextBox.Text = "0";
			this.AccuracyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.AccuracyTextBox, "The amount of spread this probe\'s weapon fires with");
			// 
			// LeadingLabel
			// 
			this.LeadingLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LeadingLabel.Location = new System.Drawing.Point(8, 40);
			this.LeadingLabel.Name = "LeadingLabel";
			this.LeadingLabel.Size = new System.Drawing.Size(80, 16);
			this.LeadingLabel.TabIndex = 25;
			this.LeadingLabel.Text = "Leading (%):";
			this.InfoToolTip.SetToolTip(this.LeadingLabel, "The ability for this probe to guess how far ahead of its target it should shoot i" +
				"n order for a hit to be registered");
			// 
			// LeadingTextBox
			// 
			this.LeadingTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LeadingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LeadingTextBox.ForeColor = System.Drawing.Color.White;
			this.LeadingTextBox.Location = new System.Drawing.Point(128, 40);
			this.LeadingTextBox.Name = "LeadingTextBox";
			this.LeadingTextBox.ReadOnly = true;
			this.LeadingTextBox.Size = new System.Drawing.Size(40, 14);
			this.LeadingTextBox.TabIndex = 26;
			this.LeadingTextBox.Text = "0";
			this.LeadingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LeadingTextBox, "The ability for this probe to guess how far ahead of its target it should shoot i" +
				"n order for a hit to be registered");
			// 
			// AmmoCapacityLabel
			// 
			this.AmmoCapacityLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AmmoCapacityLabel.Location = new System.Drawing.Point(8, 72);
			this.AmmoCapacityLabel.Name = "AmmoCapacityLabel";
			this.AmmoCapacityLabel.Size = new System.Drawing.Size(104, 16);
			this.AmmoCapacityLabel.TabIndex = 27;
			this.AmmoCapacityLabel.Text = "Ammo Capacity:";
			this.InfoToolTip.SetToolTip(this.AmmoCapacityLabel, "The total number of shots available to this probe");
			// 
			// AmmoCapacityTextBox
			// 
			this.AmmoCapacityTextBox.BackColor = System.Drawing.Color.Maroon;
			this.AmmoCapacityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AmmoCapacityTextBox.ForeColor = System.Drawing.Color.White;
			this.AmmoCapacityTextBox.Location = new System.Drawing.Point(128, 72);
			this.AmmoCapacityTextBox.Name = "AmmoCapacityTextBox";
			this.AmmoCapacityTextBox.ReadOnly = true;
			this.AmmoCapacityTextBox.Size = new System.Drawing.Size(40, 14);
			this.AmmoCapacityTextBox.TabIndex = 28;
			this.AmmoCapacityTextBox.Text = "0";
			this.AmmoCapacityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.AmmoCapacityTextBox, "The total number of shots available to this probe");
			// 
			// ActivationDelayLabel
			// 
			this.ActivationDelayLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ActivationDelayLabel.Location = new System.Drawing.Point(8, 40);
			this.ActivationDelayLabel.Name = "ActivationDelayLabel";
			this.ActivationDelayLabel.Size = new System.Drawing.Size(128, 16);
			this.ActivationDelayLabel.TabIndex = 29;
			this.ActivationDelayLabel.Text = "Activation Delay (s):";
			this.InfoToolTip.SetToolTip(this.ActivationDelayLabel, "The amount of time it takes for this teleport probe to activate after it\'s been d" +
				"ropped. If it\'s -1, then this is not a teleport probe.");
			// 
			// ActivationDelayTextBox
			// 
			this.ActivationDelayTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ActivationDelayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ActivationDelayTextBox.ForeColor = System.Drawing.Color.White;
			this.ActivationDelayTextBox.Location = new System.Drawing.Point(128, 40);
			this.ActivationDelayTextBox.Name = "ActivationDelayTextBox";
			this.ActivationDelayTextBox.ReadOnly = true;
			this.ActivationDelayTextBox.Size = new System.Drawing.Size(40, 14);
			this.ActivationDelayTextBox.TabIndex = 30;
			this.ActivationDelayTextBox.Text = "0";
			this.ActivationDelayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ActivationDelayTextBox, "The amount of time it takes for this teleport probe to activate after it\'s been d" +
				"ropped. If it\'s -1, then this is not a teleport probe.");
			// 
			// WeaponsPanel
			// 
			this.WeaponsPanel.Controls.Add(this.KillsLabel);
			this.WeaponsPanel.Controls.Add(this.KillBonusTextBox);
			this.WeaponsPanel.Controls.Add(this.KillCountNumericUpDown);
			this.WeaponsPanel.Controls.Add(this.KillBonusLabel);
			this.WeaponsPanel.Controls.Add(this.WeaponRangeTextBox);
			this.WeaponsPanel.Controls.Add(this.WeaponRangeLabel);
			this.WeaponsPanel.Controls.Add(this.BaseDamageTextBox);
			this.WeaponsPanel.Controls.Add(this.BaseDamageLabel);
			this.WeaponsPanel.Controls.Add(this.WeaponsLabel);
			this.WeaponsPanel.Controls.Add(this.LeadingLabel);
			this.WeaponsPanel.Controls.Add(this.AmmoCapacityTextBox);
			this.WeaponsPanel.Controls.Add(this.LeadingTextBox);
			this.WeaponsPanel.Controls.Add(this.ShotIntervalTextBox);
			this.WeaponsPanel.Controls.Add(this.AmmoCapacityLabel);
			this.WeaponsPanel.Controls.Add(this.ShotIntervaLabel);
			this.WeaponsPanel.Controls.Add(this.AccuracyLabel);
			this.WeaponsPanel.Controls.Add(this.AccuracyTextBox);
			this.WeaponsPanel.Location = new System.Drawing.Point(180, 56);
			this.WeaponsPanel.Name = "WeaponsPanel";
			this.WeaponsPanel.Size = new System.Drawing.Size(180, 134);
			this.WeaponsPanel.TabIndex = 35;
			// 
			// KillsLabel
			// 
			this.KillsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.KillsLabel.Location = new System.Drawing.Point(8, 120);
			this.KillsLabel.Name = "KillsLabel";
			this.KillsLabel.Size = new System.Drawing.Size(32, 16);
			this.KillsLabel.TabIndex = 37;
			this.KillsLabel.Text = "Kills:";
			this.InfoToolTip.SetToolTip(this.KillsLabel, "The number of kills posessed by the pilot of this ship");
			// 
			// KillBonusTextBox
			// 
			this.KillBonusTextBox.BackColor = System.Drawing.Color.Maroon;
			this.KillBonusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KillBonusTextBox.ForeColor = System.Drawing.Color.White;
			this.KillBonusTextBox.Location = new System.Drawing.Point(128, 120);
			this.KillBonusTextBox.Name = "KillBonusTextBox";
			this.KillBonusTextBox.ReadOnly = true;
			this.KillBonusTextBox.Size = new System.Drawing.Size(40, 14);
			this.KillBonusTextBox.TabIndex = 36;
			this.KillBonusTextBox.Text = "10";
			this.KillBonusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.KillBonusTextBox, "The percent damage added on to the base damage of this pilot\'s weapons");
			// 
			// KillCountNumericUpDown
			// 
			this.KillCountNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.KillCountNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KillCountNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.KillCountNumericUpDown.Location = new System.Drawing.Point(40, 120);
			this.KillCountNumericUpDown.Maximum = new System.Decimal(new int[] {
																				   1000,
																				   0,
																				   0,
																				   0});
			this.KillCountNumericUpDown.Name = "KillCountNumericUpDown";
			this.KillCountNumericUpDown.Size = new System.Drawing.Size(40, 14);
			this.KillCountNumericUpDown.TabIndex = 35;
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
			this.KillBonusLabel.Location = new System.Drawing.Point(104, 120);
			this.KillBonusLabel.Name = "KillBonusLabel";
			this.KillBonusLabel.Size = new System.Drawing.Size(32, 16);
			this.KillBonusLabel.TabIndex = 34;
			this.KillBonusLabel.Text = "KB:";
			this.InfoToolTip.SetToolTip(this.KillBonusLabel, "The percent damage added on to the base damage of this pilot\'s weapons");
			// 
			// WeaponRangeTextBox
			// 
			this.WeaponRangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.WeaponRangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.WeaponRangeTextBox.ForeColor = System.Drawing.Color.White;
			this.WeaponRangeTextBox.Location = new System.Drawing.Point(128, 104);
			this.WeaponRangeTextBox.Name = "WeaponRangeTextBox";
			this.WeaponRangeTextBox.ReadOnly = true;
			this.WeaponRangeTextBox.Size = new System.Drawing.Size(40, 14);
			this.WeaponRangeTextBox.TabIndex = 33;
			this.WeaponRangeTextBox.Text = "0";
			this.WeaponRangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.WeaponRangeTextBox, "The range of this probe\'s weapon");
			// 
			// WeaponRangeLabel
			// 
			this.WeaponRangeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WeaponRangeLabel.Location = new System.Drawing.Point(8, 104);
			this.WeaponRangeLabel.Name = "WeaponRangeLabel";
			this.WeaponRangeLabel.Size = new System.Drawing.Size(104, 16);
			this.WeaponRangeLabel.TabIndex = 32;
			this.WeaponRangeLabel.Text = "Weapon Range:";
			this.InfoToolTip.SetToolTip(this.WeaponRangeLabel, "The range of this probe\'s weapon");
			// 
			// BaseDamageTextBox
			// 
			this.BaseDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.BaseDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BaseDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.BaseDamageTextBox.Location = new System.Drawing.Point(128, 88);
			this.BaseDamageTextBox.Name = "BaseDamageTextBox";
			this.BaseDamageTextBox.ReadOnly = true;
			this.BaseDamageTextBox.Size = new System.Drawing.Size(40, 14);
			this.BaseDamageTextBox.TabIndex = 31;
			this.BaseDamageTextBox.Text = "0";
			this.BaseDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.BaseDamageTextBox, "The amount of damage dealt per second by this probe\'s weapon");
			// 
			// BaseDamageLabel
			// 
			this.BaseDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BaseDamageLabel.Location = new System.Drawing.Point(8, 88);
			this.BaseDamageLabel.Name = "BaseDamageLabel";
			this.BaseDamageLabel.Size = new System.Drawing.Size(128, 16);
			this.BaseDamageLabel.TabIndex = 30;
			this.BaseDamageLabel.Text = "Base Damage (hp/s):";
			this.InfoToolTip.SetToolTip(this.BaseDamageLabel, "The amount of damage dealt per second by this probe\'s weapon");
			// 
			// WeaponsLabel
			// 
			this.WeaponsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.WeaponsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.WeaponsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.WeaponsLabel.Location = new System.Drawing.Point(0, 5);
			this.WeaponsLabel.Name = "WeaponsLabel";
			this.WeaponsLabel.Size = new System.Drawing.Size(184, 16);
			this.WeaponsLabel.TabIndex = 29;
			this.WeaponsLabel.Text = "Weapon";
			// 
			// UsagePanel
			// 
			this.UsagePanel.Controls.Add(this.UseLabel);
			this.UsagePanel.Controls.Add(this.LifespanLabel);
			this.UsagePanel.Controls.Add(this.ArmingTimeLabel);
			this.UsagePanel.Controls.Add(this.ArmingTimeTextBox);
			this.UsagePanel.Controls.Add(this.LifespanTextBox);
			this.UsagePanel.Controls.Add(this.ActivationDelayTextBox);
			this.UsagePanel.Controls.Add(this.ActivationDelayLabel);
			this.UsagePanel.Location = new System.Drawing.Point(0, 56);
			this.UsagePanel.Name = "UsagePanel";
			this.UsagePanel.Size = new System.Drawing.Size(176, 72);
			this.UsagePanel.TabIndex = 36;
			// 
			// UseLabel
			// 
			this.UseLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UseLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.UseLabel.Location = new System.Drawing.Point(0, 5);
			this.UseLabel.Name = "UseLabel";
			this.UseLabel.Size = new System.Drawing.Size(184, 16);
			this.UseLabel.TabIndex = 29;
			this.UseLabel.Text = "Usage";
			// 
			// CargoPanel
			// 
			this.CargoPanel.Controls.Add(this.MassTextBox);
			this.CargoPanel.Controls.Add(this.MassLabel);
			this.CargoPanel.Controls.Add(this.CargoSizeTextBox);
			this.CargoPanel.Controls.Add(this.CargoSizeLabel);
			this.CargoPanel.Controls.Add(this.CargoLabel);
			this.CargoPanel.Location = new System.Drawing.Point(0, 128);
			this.CargoPanel.Name = "CargoPanel";
			this.CargoPanel.Size = new System.Drawing.Size(176, 58);
			this.CargoPanel.TabIndex = 37;
			// 
			// MassTextBox
			// 
			this.MassTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MassTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MassTextBox.ForeColor = System.Drawing.Color.White;
			this.MassTextBox.Location = new System.Drawing.Point(128, 40);
			this.MassTextBox.Name = "MassTextBox";
			this.MassTextBox.ReadOnly = true;
			this.MassTextBox.Size = new System.Drawing.Size(40, 14);
			this.MassTextBox.TabIndex = 31;
			this.MassTextBox.Text = "0";
			this.MassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.MassTextBox, "The mass of this probe");
			// 
			// MassLabel
			// 
			this.MassLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MassLabel.Location = new System.Drawing.Point(8, 40);
			this.MassLabel.Name = "MassLabel";
			this.MassLabel.Size = new System.Drawing.Size(64, 16);
			this.MassLabel.TabIndex = 30;
			this.MassLabel.Text = "Mass (kg):";
			this.InfoToolTip.SetToolTip(this.MassLabel, "The mass of this probe");
			// 
			// CargoSizeTextBox
			// 
			this.CargoSizeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.CargoSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CargoSizeTextBox.ForeColor = System.Drawing.Color.White;
			this.CargoSizeTextBox.Location = new System.Drawing.Point(128, 24);
			this.CargoSizeTextBox.Name = "CargoSizeTextBox";
			this.CargoSizeTextBox.ReadOnly = true;
			this.CargoSizeTextBox.Size = new System.Drawing.Size(40, 14);
			this.CargoSizeTextBox.TabIndex = 33;
			this.CargoSizeTextBox.Text = "0";
			this.CargoSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.CargoSizeTextBox, "The \"size\" of this probe in a cargo slot, determining how many of this probe can " +
				"fit in a single slot");
			// 
			// CargoSizeLabel
			// 
			this.CargoSizeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CargoSizeLabel.Location = new System.Drawing.Point(8, 24);
			this.CargoSizeLabel.Name = "CargoSizeLabel";
			this.CargoSizeLabel.Size = new System.Drawing.Size(112, 16);
			this.CargoSizeLabel.TabIndex = 32;
			this.CargoSizeLabel.Text = "Cargo Size (slots):";
			this.InfoToolTip.SetToolTip(this.CargoSizeLabel, "The \"size\" of this probe in a cargo slot, determining how many of this probe can " +
				"fit in a single slot");
			// 
			// CargoLabel
			// 
			this.CargoLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.CargoLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CargoLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.CargoLabel.Location = new System.Drawing.Point(0, 5);
			this.CargoLabel.Name = "CargoLabel";
			this.CargoLabel.Size = new System.Drawing.Size(176, 16);
			this.CargoLabel.TabIndex = 29;
			this.CargoLabel.Text = "Cargo";
			// 
			// HullPanel
			// 
			this.HullPanel.Controls.Add(this.ACLabel);
			this.HullPanel.Controls.Add(this.ACTextBox);
			this.HullPanel.Controls.Add(this.HitpointsLabel);
			this.HullPanel.Controls.Add(this.HitpointsTextBox);
			this.HullPanel.Controls.Add(this.HullHeaderLabel);
			this.HullPanel.Location = new System.Drawing.Point(180, 0);
			this.HullPanel.Name = "HullPanel";
			this.HullPanel.Size = new System.Drawing.Size(180, 56);
			this.HullPanel.TabIndex = 38;
			// 
			// ACLabel
			// 
			this.ACLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ACLabel.Location = new System.Drawing.Point(8, 40);
			this.ACLabel.Name = "ACLabel";
			this.ACLabel.Size = new System.Drawing.Size(24, 16);
			this.ACLabel.TabIndex = 35;
			this.ACLabel.Text = "AC:";
			this.InfoToolTip.SetToolTip(this.ACLabel, "The armor class of this probe");
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
			this.ACTextBox.TabIndex = 36;
			this.ACTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.ACTextBox, "The armor class of this probe");
			// 
			// HitpointsLabel
			// 
			this.HitpointsLabel.BackColor = System.Drawing.Color.Black;
			this.HitpointsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HitpointsLabel.Location = new System.Drawing.Point(8, 24);
			this.HitpointsLabel.Name = "HitpointsLabel";
			this.HitpointsLabel.Size = new System.Drawing.Size(64, 16);
			this.HitpointsLabel.TabIndex = 30;
			this.HitpointsLabel.Text = "Hitpoints:";
			this.InfoToolTip.SetToolTip(this.HitpointsLabel, "The number of hitpoints this probe has. When all hitpoints have been taken away b" +
				"y damage, the probe is destroyed");
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
			this.HitpointsTextBox.TabIndex = 31;
			this.HitpointsTextBox.Text = "0";
			this.HitpointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HitpointsTextBox, "The number of hitpoints this probe has. When all hitpoints have been taken away b" +
				"y damage, the probe is destroyed");
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
			// FeaturesPanel
			// 
			this.FeaturesPanel.Controls.Add(this.RescueAllLabel);
			this.FeaturesPanel.Controls.Add(this.RescueTeamLabel);
			this.FeaturesPanel.Controls.Add(this.ShootShipsLabel);
			this.FeaturesPanel.Controls.Add(this.ShootStationsLabel);
			this.FeaturesPanel.Controls.Add(this.ShootTargetOnlyLabel);
			this.FeaturesPanel.Controls.Add(this.AlephResonatorLabel);
			this.FeaturesPanel.Controls.Add(this.CaptureLabel);
			this.FeaturesPanel.Controls.Add(this.ShootMissilesLabel);
			this.FeaturesPanel.Controls.Add(this.QuickReadyLabel);
			this.FeaturesPanel.Controls.Add(this.DropWarningLabel);
			this.FeaturesPanel.Controls.Add(this.FeaturesLabel);
			this.FeaturesPanel.Location = new System.Drawing.Point(0, 188);
			this.FeaturesPanel.Name = "FeaturesPanel";
			this.FeaturesPanel.Size = new System.Drawing.Size(361, 72);
			this.FeaturesPanel.TabIndex = 39;
			// 
			// RescueAllLabel
			// 
			this.RescueAllLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RescueAllLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RescueAllLabel.Location = new System.Drawing.Point(256, 40);
			this.RescueAllLabel.Name = "RescueAllLabel";
			this.RescueAllLabel.Size = new System.Drawing.Size(96, 16);
			this.RescueAllLabel.TabIndex = 39;
			this.RescueAllLabel.Text = "Rescue All";
			this.RescueAllLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RescueAllLabel, "This probe will rescue any lifepod that collides with it, including enemies");
			// 
			// RescueTeamLabel
			// 
			this.RescueTeamLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RescueTeamLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.RescueTeamLabel.Location = new System.Drawing.Point(256, 24);
			this.RescueTeamLabel.Name = "RescueTeamLabel";
			this.RescueTeamLabel.Size = new System.Drawing.Size(96, 16);
			this.RescueTeamLabel.TabIndex = 38;
			this.RescueTeamLabel.Text = "Rescue Team";
			this.RescueTeamLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.RescueTeamLabel, "This probe will rescue any friendly lifepod that collides with it");
			// 
			// ShootShipsLabel
			// 
			this.ShootShipsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShootShipsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ShootShipsLabel.Location = new System.Drawing.Point(168, 56);
			this.ShootShipsLabel.Name = "ShootShipsLabel";
			this.ShootShipsLabel.Size = new System.Drawing.Size(88, 16);
			this.ShootShipsLabel.TabIndex = 37;
			this.ShootShipsLabel.Text = "Shoot Ships";
			this.ShootShipsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.ShootShipsLabel, "This probe can fire at ships");
			// 
			// ShootStationsLabel
			// 
			this.ShootStationsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShootStationsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ShootStationsLabel.Location = new System.Drawing.Point(8, 56);
			this.ShootStationsLabel.Name = "ShootStationsLabel";
			this.ShootStationsLabel.Size = new System.Drawing.Size(80, 16);
			this.ShootStationsLabel.TabIndex = 36;
			this.ShootStationsLabel.Text = "Shoot Stations";
			this.ShootStationsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.ShootStationsLabel, "This probe can fire at stations");
			// 
			// ShootTargetOnlyLabel
			// 
			this.ShootTargetOnlyLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShootTargetOnlyLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ShootTargetOnlyLabel.Location = new System.Drawing.Point(256, 56);
			this.ShootTargetOnlyLabel.Name = "ShootTargetOnlyLabel";
			this.ShootTargetOnlyLabel.Size = new System.Drawing.Size(96, 16);
			this.ShootTargetOnlyLabel.TabIndex = 35;
			this.ShootTargetOnlyLabel.Text = "Shoot Target Only";
			this.ShootTargetOnlyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.ShootTargetOnlyLabel, "This probe\'s weapon shoots the pilot\'s target only. It will not shoot at other ta" +
				"rgets");
			// 
			// AlephResonatorLabel
			// 
			this.AlephResonatorLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AlephResonatorLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.AlephResonatorLabel.Location = new System.Drawing.Point(168, 40);
			this.AlephResonatorLabel.Name = "AlephResonatorLabel";
			this.AlephResonatorLabel.Size = new System.Drawing.Size(88, 16);
			this.AlephResonatorLabel.TabIndex = 34;
			this.AlephResonatorLabel.Text = "Aleph Resonator";
			this.AlephResonatorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.AlephResonatorLabel, "This probe can resonate a nearby aleph");
			// 
			// CaptureLabel
			// 
			this.CaptureLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CaptureLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.CaptureLabel.Location = new System.Drawing.Point(96, 40);
			this.CaptureLabel.Name = "CaptureLabel";
			this.CaptureLabel.Size = new System.Drawing.Size(72, 16);
			this.CaptureLabel.TabIndex = 33;
			this.CaptureLabel.Text = "Capture";
			this.CaptureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.CaptureLabel, "This probe can capture enemy stations");
			// 
			// ShootMissilesLabel
			// 
			this.ShootMissilesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShootMissilesLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.ShootMissilesLabel.Location = new System.Drawing.Point(96, 56);
			this.ShootMissilesLabel.Name = "ShootMissilesLabel";
			this.ShootMissilesLabel.Size = new System.Drawing.Size(72, 16);
			this.ShootMissilesLabel.TabIndex = 32;
			this.ShootMissilesLabel.Text = "Shoot Missiles";
			this.ShootMissilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.ShootMissilesLabel, "This probe can fire at missiles in midflight");
			// 
			// QuickReadyLabel
			// 
			this.QuickReadyLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.QuickReadyLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.QuickReadyLabel.Location = new System.Drawing.Point(8, 24);
			this.QuickReadyLabel.Name = "QuickReadyLabel";
			this.QuickReadyLabel.Size = new System.Drawing.Size(80, 16);
			this.QuickReadyLabel.TabIndex = 31;
			this.QuickReadyLabel.Text = "Quick Ready";
			this.QuickReadyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.QuickReadyLabel, "This probe does not need re-arming time, and is ready instantly");
			// 
			// DropWarningLabel
			// 
			this.DropWarningLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DropWarningLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.DropWarningLabel.Location = new System.Drawing.Point(8, 40);
			this.DropWarningLabel.Name = "DropWarningLabel";
			this.DropWarningLabel.Size = new System.Drawing.Size(80, 16);
			this.DropWarningLabel.TabIndex = 30;
			this.DropWarningLabel.Text = "Drop Warning";
			this.DropWarningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.InfoToolTip.SetToolTip(this.DropWarningLabel, "A warning message will be displayed to all teams who detect this probe once it is" +
				" dropped");
			// 
			// FeaturesLabel
			// 
			this.FeaturesLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.FeaturesLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FeaturesLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.FeaturesLabel.Location = new System.Drawing.Point(0, 5);
			this.FeaturesLabel.Name = "FeaturesLabel";
			this.FeaturesLabel.Size = new System.Drawing.Size(368, 16);
			this.FeaturesLabel.TabIndex = 29;
			this.FeaturesLabel.Text = "Features";
			// 
			// ShieldDamageTextBox
			// 
			this.ShieldDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldDamageTextBox.Location = new System.Drawing.Point(312, 40);
			this.ShieldDamageTextBox.Name = "ShieldDamageTextBox";
			this.ShieldDamageTextBox.Size = new System.Drawing.Size(40, 13);
			this.ShieldDamageTextBox.TabIndex = 43;
			this.ShieldDamageTextBox.Text = "0";
			this.ShieldDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.ShieldDamageTextBox, "The real damage applied to this ship\'s target, taking the target\'s Armor Class in" +
				"to account");
			// 
			// ShieldDamageLabel
			// 
			this.ShieldDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldDamageLabel.Location = new System.Drawing.Point(219, 40);
			this.ShieldDamageLabel.Name = "ShieldDamageLabel";
			this.ShieldDamageLabel.Size = new System.Drawing.Size(96, 16);
			this.ShieldDamageLabel.TabIndex = 42;
			this.ShieldDamageLabel.Text = "Shield Damage:";
			// 
			// HullDamageTextBox
			// 
			this.HullDamageTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HullDamageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HullDamageTextBox.ForeColor = System.Drawing.Color.White;
			this.HullDamageTextBox.Location = new System.Drawing.Point(312, 24);
			this.HullDamageTextBox.Name = "HullDamageTextBox";
			this.HullDamageTextBox.Size = new System.Drawing.Size(40, 13);
			this.HullDamageTextBox.TabIndex = 41;
			this.HullDamageTextBox.Text = "0";
			this.HullDamageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HullDamageTextBox, "The real damage applied to this ship\'s target, taking the target\'s Armor Class in" +
				"to account");
			// 
			// ActualDamageLabel
			// 
			this.ActualDamageLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ActualDamageLabel.Location = new System.Drawing.Point(232, 24);
			this.ActualDamageLabel.Name = "ActualDamageLabel";
			this.ActualDamageLabel.Size = new System.Drawing.Size(88, 16);
			this.ActualDamageLabel.TabIndex = 40;
			this.ActualDamageLabel.Text = "Hull Damage:";
			// 
			// ProbeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(354, 263);
			this.Controls.Add(this.WeaponsPanel);
			this.Controls.Add(this.UsagePanel);
			this.Controls.Add(this.FeaturesPanel);
			this.Controls.Add(this.HullPanel);
			this.Controls.Add(this.CargoPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ProbeForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ProbeForm_Closing);
			this.Controls.SetChildIndex(this.SensorsPanel, 0);
			this.Controls.SetChildIndex(this.CargoPanel, 0);
			this.Controls.SetChildIndex(this.HullPanel, 0);
			this.Controls.SetChildIndex(this.FeaturesPanel, 0);
			this.Controls.SetChildIndex(this.UsagePanel, 0);
			this.Controls.SetChildIndex(this.WeaponsPanel, 0);
			this.SensorsPanel.ResumeLayout(false);
			this.WeaponsPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.KillCountNumericUpDown)).EndInit();
			this.UsagePanel.ResumeLayout(false);
			this.CargoPanel.ResumeLayout(false);
			this.HullPanel.ResumeLayout(false);
			this.FeaturesPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateHandler (object sender, EventArgs e)
		{
			this.ScanRangeTextBox.Text = _probe.CalculateScanrange().ToString();
			this.SigTextBox.Text = (_probe.CalculateSignature() * 100).ToString();
			this.HitpointsTextBox.Text = _probe.IGCProbe.Hitpoints.ToString();
			
			this.ACTextBox.Text = Enum.GetName(typeof(IGCArmorClass), _probe.IGCProbe.ArmorClass);
			this.CargoSizeTextBox.Text = _probe.IGCProbe.CargoPayload.ToString();
			this.ArmingTimeTextBox.Text = _probe.IGCProbe.ArmingTime.ToString();
			this.ActivationDelayTextBox.Text = _probe.IGCProbe.ActivationDelay.ToString();
			this.AccuracyTextBox.Text = _probe.IGCProbe.Accuracy.ToString();
			this.MassTextBox.Text = _probe.IGCProbe.Mass.ToString();
			this.LeadingTextBox.Text = _probe.IGCProbe.Leading.ToString();
			this.ShotIntervalTextBox.Text = _probe.IGCProbe.ShotInterval.ToString();
			this.AmmoCapacityTextBox.Text = _probe.IGCProbe.AmmoCapacity.ToString();

			if (_probe.IGCProbe.Features[(short)ProbeFeatures.Capture])
				EnableFeature(CaptureLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.ResonateAleph])
				EnableFeature(AlephResonatorLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.QuickReady])
				EnableFeature(QuickReadyLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.WarnWhenDrop])
				EnableFeature(DropWarningLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.ShootStations])
				EnableFeature(ShootStationsLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.ShootShips])
				EnableFeature(ShootShipsLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.ShootMissiles])
				EnableFeature(ShootMissilesLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.ShootOnlyTarget])
				EnableFeature(ShootTargetOnlyLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.RescueTeamPods])
				EnableFeature(RescueTeamLabel);
			if (_probe.IGCProbe.Features[(short)ProbeFeatures.RescueAllPods])
				EnableFeature(RescueAllLabel);

			this.KillCountNumericUpDown.Value = _probe.Kills;
			Comparison Comp = new Comparison(_probe, _probe.KillBonus, 100F, 0);
			this.WeaponRangeTextBox.Text = Comp.Range.ToString();
			this.BaseDamageTextBox.Text = Comp.Damage.ToString();
		}

		private void ClosedHandler (object sender, EventArgs e)
		{
			_probe.Updated -= new EventHandler(UpdateHandler);
			_probe.Closed -= new EventHandler(ClosedHandler);
			this.Close();
			this.Dispose();
		}

		private void ProbeForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_probe.Updated -= new EventHandler(UpdateHandler);
			_probe.Closed -= new EventHandler(ClosedHandler);
			_probe = null;
		}
		
		private void KillCountNumericUpDown_ValueChanged (object sender, System.EventArgs e)
		{
			NumericUpDown Sender = (NumericUpDown)sender;
			_probe.Kills = (int)Sender.Value;
			KillBonusTextBox.Text = _probe.KillBonus.ToString();
			_probe.Update();
		}
	}
}

