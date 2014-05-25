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
	/// Summary description for ComparisonForm.
	/// </summary>
	public class ComparisonForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.Panel Object1Panel;
		private System.Windows.Forms.TextBox DetectionRangeTextBox;
		private System.Windows.Forms.Button Object1DetailsButton;
		private System.Windows.Forms.Panel Object2Panel;
		private System.Windows.Forms.Button Object2DetailsButton;
		private System.Windows.Forms.Label Object2BearingLabel;
		private System.Windows.Forms.TextBox Object2BearingTextBox;
		private System.Windows.Forms.Panel ComparisonPanel;
		private System.Windows.Forms.Label Object1BearingLabel;
		private System.Windows.Forms.TextBox NumMissilesTextBox;
		private System.Windows.Forms.TextBox TimeToKillTextBox;
		private System.Windows.Forms.Label NumMissilesLabel;
		private System.Windows.Forms.Label TimeToKillLabel;
		private System.Windows.Forms.TextBox NumBatteriesTextBox;
		private System.Windows.Forms.TextBox NumAmmoClipsTextBox;
		private System.Windows.Forms.Label NumBatteriesLabel;
		private System.Windows.Forms.ProgressBar ProjectileAccuracyProgressBar;
		private System.Windows.Forms.Label AccuracyLabelLabel;
		private System.Windows.Forms.Label AccuracyLabel;
		private System.Windows.Forms.Panel CargoPanel;
		private System.Windows.Forms.Panel WeaponsPanel;
		private System.Windows.Forms.Panel WeaponSlot1Panel;
		private System.Windows.Forms.Label Wep1Label;
		private System.Windows.Forms.TextBox Wep1TextBox;
		private System.Windows.Forms.Panel WeaponSlot2Panel;
		private System.Windows.Forms.Label Wep2Label;
		private System.Windows.Forms.TextBox Wep2TextBox;
		private System.Windows.Forms.Panel WeaponSlot3Panel;
		private System.Windows.Forms.Label Wep3Label;
		private System.Windows.Forms.TextBox Wep3TextBox;
		private System.Windows.Forms.Panel WeaponSlot4Panel;
		private System.Windows.Forms.Label Wep4Label;
		private System.Windows.Forms.TextBox Wep4TextBox;
		private System.Windows.Forms.Panel TurretsPanel;
		private System.Windows.Forms.Panel TurretSlot1Panel;
		private System.Windows.Forms.CheckBox UseTurr1CheckBox;
		private System.Windows.Forms.TextBox Turr1TextBox;
		private System.Windows.Forms.Panel TurretSlot2Panel;
		private System.Windows.Forms.CheckBox UseTurr2CheckBox;
		private System.Windows.Forms.TextBox Turr2TextBox;
		private System.Windows.Forms.Panel TurretSlot3Panel;
		private System.Windows.Forms.CheckBox UseTurr3CheckBox;
		private System.Windows.Forms.TextBox Turr3TextBox;
		private System.Windows.Forms.Panel TurretSlot4Panel;
		private System.Windows.Forms.CheckBox UseTurr4CheckBox;
		private System.Windows.Forms.TextBox Turr4TextBox;
		private System.Windows.Forms.Panel BoosterPanel;
		private System.Windows.Forms.CheckBox UseBoosterCheckBox;
		private System.Windows.Forms.TextBox BoosterTextBox;
		private System.Windows.Forms.Panel ShieldPanel;
		private System.Windows.Forms.TextBox ShieldTextBox;
		private System.Windows.Forms.Panel CloakPanel;
		private System.Windows.Forms.CheckBox UseCloakCheckBox;
		private System.Windows.Forms.TextBox CloakTextBox;
		private System.Windows.Forms.Label GunsLabel;
		private System.Windows.Forms.Label TurretsLabel;
		private System.Windows.Forms.TextBox Object1BearingTextBox;
		private System.Windows.Forms.Label MissileLabel;
		private System.Windows.Forms.Label BoosterLabel;
		private System.Windows.Forms.Panel MissilePanel;
		private System.Windows.Forms.TextBox MissileTextBox;
		private System.Windows.Forms.CheckBox UseMissileCheckBox;
		private System.Windows.Forms.Label CloakLabel;
		private System.Windows.Forms.Label ShieldLlabel;
		private System.Windows.Forms.Label KBLabel;
		private System.Windows.Forms.Label Object1LabelLabel;
		private System.Windows.Forms.Label NumClipsLabel;
		private System.Windows.Forms.Label Object1Label;
		private System.Windows.Forms.Label Object2SeesObject1Label;
		private System.Windows.Forms.Label Object1SeesObject2Label;
		private System.Windows.Forms.Label Object2Label;
		private System.Windows.Forms.Label Object2LabelLabel;
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.Windows.Forms.TextBox DetectedRangeTextBox;
		private System.Windows.Forms.ContextMenu AvailablePartsContextMenu;
		private System.Windows.Forms.NumericUpDown Object1KillsNumericUpDown;
		private System.Windows.Forms.TextBox KBTextBox;
		private System.Windows.Forms.CheckBox UseWeapon1CheckBox;
		private System.Windows.Forms.CheckBox UseWeapon2CheckBox;
		private System.Windows.Forms.CheckBox UseWeapon3CheckBox;
		private System.Windows.Forms.CheckBox UseWeapon4CheckBox;
		private System.Windows.Forms.TextBox HitpointsTextBox;
		private System.Windows.Forms.Label HitpointsLabel;
		private System.Windows.Forms.TextBox RangeTextBox;
		private System.Windows.Forms.Label RangeLabel;
		private System.Windows.Forms.Label KillsLabel;
		private System.ComponentModel.IContainer components;
		#endregion
		private System.Windows.Forms.Timer ComparisonTimer;
		private System.Windows.Forms.TextBox LaunchSpeedTextBox;
		private System.Windows.Forms.Label label1;

		const int COLLAPSEDSIZE = 162;
		const int EXPANDEDSIZE = 326;

		Game		_game = null;
		AllegObject _object1 = null;
		AllegObject _object2 = null;
		Ship		_selectedShip = null;
		ArrayList	_partList = null;
		AngleChooser _chooser1 = null;
		AngleChooser _chooser2 = null;
		private System.Windows.Forms.Panel SeparatorPanel;
		private System.Windows.Forms.Panel panel1;
		TekSettings _settings = null;

		public ComparisonForm (Game game, AllegObject object1, TekSettings settings)
		{
			InitializeComponent();
			_settings = settings;
			InfoToolTip.Active = settings.ShowToolTips;
			object1.Team.OpenObjects.Add(object1);
			object1.Updated += new EventHandler(Object1ChangedHandler);
			object1.Closed += new EventHandler(Object1ClosedHandler);
			this.ClientSize = new Size(this.ClientSize.Width, COLLAPSEDSIZE);

			_partList = new ArrayList();
			_game = game;
			_object1 = object1;
			_game.Comparisons.Add(this);
			UpdateObjects();
		}

		public ComparisonForm (Game game, AllegObject object1, AllegObject object2, TekSettings settings)
		{
			InitializeComponent();
			_settings = settings;
			InfoToolTip.Active = settings.ShowToolTips;
			object1.Team.OpenObjects.Add(object1);
			object2.Team.OpenObjects.Add(object2);
			if (object1 == game.Me && object2 == game.Target)
			{	
				this.Text = "My Comparison";
				game.MeChanged += new EventHandler(MeChangedHandler);
				game.TargetChanged += new EventHandler(TargetChangedHandler);
				game.Comparisons.Insert(0, this);
			}
			else
			{
				game.Comparisons.Add(this);
			}
			
			object1.Updated += new EventHandler(Object1ChangedHandler);
			object1.Closed += new EventHandler(Object1ClosedHandler);
			object2.Updated += new EventHandler(Object2ChangedHandler);
			object2.Closed += new EventHandler(Object2ClosedHandler);

			this.ClientSize = new Size(this.ClientSize.Width, COLLAPSEDSIZE);

			_partList = new ArrayList();
			_game = game;
			_object1 = object1;

			_object2 = object2;
			UpdateObjects();
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
			this.Object1Panel = new System.Windows.Forms.Panel();
			this.KBTextBox = new System.Windows.Forms.TextBox();
			this.Object1BearingTextBox = new System.Windows.Forms.TextBox();
			this.Object1BearingLabel = new System.Windows.Forms.Label();
			this.Object1DetailsButton = new System.Windows.Forms.Button();
			this.Object1Label = new System.Windows.Forms.Label();
			this.Object1LabelLabel = new System.Windows.Forms.Label();
			this.Object1KillsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.KillsLabel = new System.Windows.Forms.Label();
			this.KBLabel = new System.Windows.Forms.Label();
			this.DetectionRangeTextBox = new System.Windows.Forms.TextBox();
			this.DetectedRangeTextBox = new System.Windows.Forms.TextBox();
			this.Object2Panel = new System.Windows.Forms.Panel();
			this.HitpointsTextBox = new System.Windows.Forms.TextBox();
			this.HitpointsLabel = new System.Windows.Forms.Label();
			this.Object2BearingTextBox = new System.Windows.Forms.TextBox();
			this.Object2BearingLabel = new System.Windows.Forms.Label();
			this.Object2DetailsButton = new System.Windows.Forms.Button();
			this.Object2Label = new System.Windows.Forms.Label();
			this.Object2LabelLabel = new System.Windows.Forms.Label();
			this.ComparisonPanel = new System.Windows.Forms.Panel();
			this.RangeTextBox = new System.Windows.Forms.TextBox();
			this.RangeLabel = new System.Windows.Forms.Label();
			this.ProjectileAccuracyProgressBar = new System.Windows.Forms.ProgressBar();
			this.AccuracyLabel = new System.Windows.Forms.Label();
			this.AccuracyLabelLabel = new System.Windows.Forms.Label();
			this.NumBatteriesTextBox = new System.Windows.Forms.TextBox();
			this.NumAmmoClipsTextBox = new System.Windows.Forms.TextBox();
			this.NumBatteriesLabel = new System.Windows.Forms.Label();
			this.NumClipsLabel = new System.Windows.Forms.Label();
			this.NumMissilesTextBox = new System.Windows.Forms.TextBox();
			this.TimeToKillTextBox = new System.Windows.Forms.TextBox();
			this.NumMissilesLabel = new System.Windows.Forms.Label();
			this.TimeToKillLabel = new System.Windows.Forms.Label();
			this.Object2SeesObject1Label = new System.Windows.Forms.Label();
			this.Object1SeesObject2Label = new System.Windows.Forms.Label();
			this.CargoPanel = new System.Windows.Forms.Panel();
			this.LaunchSpeedTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CloakPanel = new System.Windows.Forms.Panel();
			this.UseCloakCheckBox = new System.Windows.Forms.CheckBox();
			this.CloakTextBox = new System.Windows.Forms.TextBox();
			this.AvailablePartsContextMenu = new System.Windows.Forms.ContextMenu();
			this.CloakLabel = new System.Windows.Forms.Label();
			this.ShieldLlabel = new System.Windows.Forms.Label();
			this.BoosterPanel = new System.Windows.Forms.Panel();
			this.UseBoosterCheckBox = new System.Windows.Forms.CheckBox();
			this.BoosterTextBox = new System.Windows.Forms.TextBox();
			this.MissilePanel = new System.Windows.Forms.Panel();
			this.MissileTextBox = new System.Windows.Forms.TextBox();
			this.UseMissileCheckBox = new System.Windows.Forms.CheckBox();
			this.BoosterLabel = new System.Windows.Forms.Label();
			this.MissileLabel = new System.Windows.Forms.Label();
			this.TurretsLabel = new System.Windows.Forms.Label();
			this.TurretsPanel = new System.Windows.Forms.Panel();
			this.TurretSlot4Panel = new System.Windows.Forms.Panel();
			this.UseTurr4CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr4TextBox = new System.Windows.Forms.TextBox();
			this.TurretSlot3Panel = new System.Windows.Forms.Panel();
			this.UseTurr3CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr3TextBox = new System.Windows.Forms.TextBox();
			this.TurretSlot1Panel = new System.Windows.Forms.Panel();
			this.Turr1TextBox = new System.Windows.Forms.TextBox();
			this.UseTurr1CheckBox = new System.Windows.Forms.CheckBox();
			this.TurretSlot2Panel = new System.Windows.Forms.Panel();
			this.UseTurr2CheckBox = new System.Windows.Forms.CheckBox();
			this.Turr2TextBox = new System.Windows.Forms.TextBox();
			this.GunsLabel = new System.Windows.Forms.Label();
			this.ShieldPanel = new System.Windows.Forms.Panel();
			this.ShieldTextBox = new System.Windows.Forms.TextBox();
			this.WeaponsPanel = new System.Windows.Forms.Panel();
			this.WeaponSlot3Panel = new System.Windows.Forms.Panel();
			this.Wep3TextBox = new System.Windows.Forms.TextBox();
			this.Wep3Label = new System.Windows.Forms.Label();
			this.UseWeapon3CheckBox = new System.Windows.Forms.CheckBox();
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
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ComparisonTimer = new System.Windows.Forms.Timer(this.components);
			this.SeparatorPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Object1Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Object1KillsNumericUpDown)).BeginInit();
			this.Object2Panel.SuspendLayout();
			this.ComparisonPanel.SuspendLayout();
			this.CargoPanel.SuspendLayout();
			this.CloakPanel.SuspendLayout();
			this.BoosterPanel.SuspendLayout();
			this.MissilePanel.SuspendLayout();
			this.TurretsPanel.SuspendLayout();
			this.TurretSlot4Panel.SuspendLayout();
			this.TurretSlot3Panel.SuspendLayout();
			this.TurretSlot1Panel.SuspendLayout();
			this.TurretSlot2Panel.SuspendLayout();
			this.ShieldPanel.SuspendLayout();
			this.WeaponsPanel.SuspendLayout();
			this.WeaponSlot3Panel.SuspendLayout();
			this.WeaponSlot4Panel.SuspendLayout();
			this.WeaponSlot1Panel.SuspendLayout();
			this.WeaponSlot2Panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Object1Panel
			// 
			this.Object1Panel.Controls.Add(this.KBTextBox);
			this.Object1Panel.Controls.Add(this.Object1BearingTextBox);
			this.Object1Panel.Controls.Add(this.Object1BearingLabel);
			this.Object1Panel.Controls.Add(this.Object1DetailsButton);
			this.Object1Panel.Controls.Add(this.Object1Label);
			this.Object1Panel.Controls.Add(this.Object1LabelLabel);
			this.Object1Panel.Controls.Add(this.Object1KillsNumericUpDown);
			this.Object1Panel.Controls.Add(this.KillsLabel);
			this.Object1Panel.Controls.Add(this.KBLabel);
			this.Object1Panel.Location = new System.Drawing.Point(0, 86);
			this.Object1Panel.Name = "Object1Panel";
			this.Object1Panel.Size = new System.Drawing.Size(224, 36);
			this.Object1Panel.TabIndex = 1;
			this.Object1Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// KBTextBox
			// 
			this.KBTextBox.BackColor = System.Drawing.Color.Maroon;
			this.KBTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.KBTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.KBTextBox.ForeColor = System.Drawing.Color.White;
			this.KBTextBox.Location = new System.Drawing.Point(190, 22);
			this.KBTextBox.Name = "KBTextBox";
			this.KBTextBox.ReadOnly = true;
			this.KBTextBox.Size = new System.Drawing.Size(25, 14);
			this.KBTextBox.TabIndex = 8;
			this.KBTextBox.Text = "0";
			this.KBTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.KBTextBox, "The KillBonus posessed by the pilot of this ship calculated by their #Kills");
			this.KBTextBox.Visible = false;
			// 
			// Object1BearingTextBox
			// 
			this.Object1BearingTextBox.BackColor = System.Drawing.Color.Maroon;
			this.Object1BearingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Object1BearingTextBox.Enabled = false;
			this.Object1BearingTextBox.ForeColor = System.Drawing.Color.White;
			this.Object1BearingTextBox.Location = new System.Drawing.Point(56, 22);
			this.Object1BearingTextBox.Name = "Object1BearingTextBox";
			this.Object1BearingTextBox.Size = new System.Drawing.Size(40, 14);
			this.Object1BearingTextBox.TabIndex = 4;
			this.Object1BearingTextBox.Tag = "1";
			this.Object1BearingTextBox.Text = "";
			this.Object1BearingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.Object1BearingTextBox, "The angle at which Object2 is located in relation to Object1\'s heading. Click her" +
				"e to change");
			this.Object1BearingTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BearingTextBox_MouseDown);
			this.Object1BearingTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BearingTextBox_KeyUp);
			// 
			// Object1BearingLabel
			// 
			this.Object1BearingLabel.Enabled = false;
			this.Object1BearingLabel.Location = new System.Drawing.Point(0, 22);
			this.Object1BearingLabel.Name = "Object1BearingLabel";
			this.Object1BearingLabel.Size = new System.Drawing.Size(52, 16);
			this.Object1BearingLabel.TabIndex = 3;
			this.Object1BearingLabel.Text = "Bearing:";
			this.InfoToolTip.SetToolTip(this.Object1BearingLabel, "The angle at which Object2 is located in relation to Object1\'s heading. Click the" +
				" textbox to change");
			this.Object1BearingLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object1DetailsButton
			// 
			this.Object1DetailsButton.BackColor = System.Drawing.Color.Maroon;
			this.Object1DetailsButton.Enabled = false;
			this.Object1DetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Object1DetailsButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object1DetailsButton.Location = new System.Drawing.Point(194, 3);
			this.Object1DetailsButton.Name = "Object1DetailsButton";
			this.Object1DetailsButton.Size = new System.Drawing.Size(20, 18);
			this.Object1DetailsButton.TabIndex = 2;
			this.Object1DetailsButton.Text = "»";
			this.InfoToolTip.SetToolTip(this.Object1DetailsButton, "Click to show this ship\'s cargo below");
			this.Object1DetailsButton.Visible = false;
			this.Object1DetailsButton.Click += new System.EventHandler(this.Object1DetailsButton_Click);
			// 
			// Object1Label
			// 
			this.Object1Label.AllowDrop = true;
			this.Object1Label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object1Label.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object1Label.Location = new System.Drawing.Point(23, 4);
			this.Object1Label.Name = "Object1Label";
			this.Object1Label.Size = new System.Drawing.Size(217, 16);
			this.Object1Label.TabIndex = 1;
			this.Object1Label.Text = "<Drag an object here!>";
			this.InfoToolTip.SetToolTip(this.Object1Label, "Drag another object here, or doubleclick to show this object\'s info");
			this.Object1Label.MouseEnter += new System.EventHandler(this.ObjectLabel_MouseEnter);
			this.Object1Label.DragDrop += new System.Windows.Forms.DragEventHandler(this.Object1Label_DragDrop);
			this.Object1Label.DoubleClick += new System.EventHandler(this.Object1Label_DoubleClick);
			this.Object1Label.DragOver += new System.Windows.Forms.DragEventHandler(this.Object1Label_DragOver);
			this.Object1Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object1LabelLabel
			// 
			this.Object1LabelLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object1LabelLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object1LabelLabel.Location = new System.Drawing.Point(0, 4);
			this.Object1LabelLabel.Name = "Object1LabelLabel";
			this.Object1LabelLabel.Size = new System.Drawing.Size(25, 16);
			this.Object1LabelLabel.TabIndex = 0;
			this.Object1LabelLabel.Text = "Me:";
			this.Object1LabelLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object1KillsNumericUpDown
			// 
			this.Object1KillsNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.Object1KillsNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Object1KillsNumericUpDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object1KillsNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.Object1KillsNumericUpDown.Location = new System.Drawing.Point(132, 22);
			this.Object1KillsNumericUpDown.Maximum = new System.Decimal(new int[] {
																					  1000,
																					  0,
																					  0,
																					  0});
			this.Object1KillsNumericUpDown.Name = "Object1KillsNumericUpDown";
			this.Object1KillsNumericUpDown.Size = new System.Drawing.Size(34, 14);
			this.Object1KillsNumericUpDown.TabIndex = 6;
			this.Object1KillsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.Object1KillsNumericUpDown, "The number of kills posessed by the pilot of this ship");
			this.Object1KillsNumericUpDown.Visible = false;
			this.Object1KillsNumericUpDown.ValueChanged += new System.EventHandler(this.Object1KillsNumericUpDown_ValueChanged);
			// 
			// KillsLabel
			// 
			this.KillsLabel.Location = new System.Drawing.Point(100, 22);
			this.KillsLabel.Name = "KillsLabel";
			this.KillsLabel.Size = new System.Drawing.Size(32, 16);
			this.KillsLabel.TabIndex = 5;
			this.KillsLabel.Text = "Kills:";
			this.InfoToolTip.SetToolTip(this.KillsLabel, "The number of kills posessed by the pilot of this ship");
			this.KillsLabel.Visible = false;
			// 
			// KBLabel
			// 
			this.KBLabel.Location = new System.Drawing.Point(167, 22);
			this.KBLabel.Name = "KBLabel";
			this.KBLabel.Size = new System.Drawing.Size(24, 16);
			this.KBLabel.TabIndex = 7;
			this.KBLabel.Text = "KB:";
			this.InfoToolTip.SetToolTip(this.KBLabel, "The KillBonus posessed by the pilot of this ship calculated by their #Kills");
			this.KBLabel.Visible = false;
			// 
			// DetectionRangeTextBox
			// 
			this.DetectionRangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.DetectionRangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DetectionRangeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DetectionRangeTextBox.ForeColor = System.Drawing.Color.White;
			this.DetectionRangeTextBox.Location = new System.Drawing.Point(4, 17);
			this.DetectionRangeTextBox.Name = "DetectionRangeTextBox";
			this.DetectionRangeTextBox.ReadOnly = true;
			this.DetectionRangeTextBox.Size = new System.Drawing.Size(46, 14);
			this.DetectionRangeTextBox.TabIndex = 1;
			this.DetectionRangeTextBox.Text = "0";
			this.DetectionRangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.DetectionRangeTextBox, "Object1 will see Object2 when it is this far away, or closer");
			// 
			// DetectedRangeTextBox
			// 
			this.DetectedRangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.DetectedRangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DetectedRangeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DetectedRangeTextBox.ForeColor = System.Drawing.Color.White;
			this.DetectedRangeTextBox.Location = new System.Drawing.Point(83, 17);
			this.DetectedRangeTextBox.Name = "DetectedRangeTextBox";
			this.DetectedRangeTextBox.ReadOnly = true;
			this.DetectedRangeTextBox.Size = new System.Drawing.Size(46, 14);
			this.DetectedRangeTextBox.TabIndex = 3;
			this.DetectedRangeTextBox.Text = "0";
			this.DetectedRangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.DetectedRangeTextBox, "Object2 will spot Object1 when it is this far away, or closer");
			// 
			// Object2Panel
			// 
			this.Object2Panel.Controls.Add(this.HitpointsTextBox);
			this.Object2Panel.Controls.Add(this.HitpointsLabel);
			this.Object2Panel.Controls.Add(this.Object2BearingTextBox);
			this.Object2Panel.Controls.Add(this.Object2BearingLabel);
			this.Object2Panel.Controls.Add(this.Object2DetailsButton);
			this.Object2Panel.Controls.Add(this.Object2Label);
			this.Object2Panel.Controls.Add(this.Object2LabelLabel);
			this.Object2Panel.Location = new System.Drawing.Point(0, 122);
			this.Object2Panel.Name = "Object2Panel";
			this.Object2Panel.Size = new System.Drawing.Size(224, 38);
			this.Object2Panel.TabIndex = 2;
			this.Object2Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// HitpointsTextBox
			// 
			this.HitpointsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HitpointsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HitpointsTextBox.Enabled = false;
			this.HitpointsTextBox.ForeColor = System.Drawing.Color.White;
			this.HitpointsTextBox.Location = new System.Drawing.Point(174, 22);
			this.HitpointsTextBox.Name = "HitpointsTextBox";
			this.HitpointsTextBox.ReadOnly = true;
			this.HitpointsTextBox.Size = new System.Drawing.Size(40, 14);
			this.HitpointsTextBox.TabIndex = 6;
			this.HitpointsTextBox.Tag = "2";
			this.HitpointsTextBox.Text = "";
			this.HitpointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.HitpointsTextBox, "The number of hitpoints this object has (hull and shield combined)");
			this.HitpointsTextBox.Visible = false;
			// 
			// HitpointsLabel
			// 
			this.HitpointsLabel.Enabled = false;
			this.HitpointsLabel.Location = new System.Drawing.Point(112, 22);
			this.HitpointsLabel.Name = "HitpointsLabel";
			this.HitpointsLabel.Size = new System.Drawing.Size(60, 16);
			this.HitpointsLabel.TabIndex = 5;
			this.HitpointsLabel.Text = "Hitpoints:";
			this.InfoToolTip.SetToolTip(this.HitpointsLabel, "The number of hitpoints this object has (hull and shield combined)");
			this.HitpointsLabel.Visible = false;
			// 
			// Object2BearingTextBox
			// 
			this.Object2BearingTextBox.BackColor = System.Drawing.Color.Maroon;
			this.Object2BearingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Object2BearingTextBox.Enabled = false;
			this.Object2BearingTextBox.ForeColor = System.Drawing.Color.White;
			this.Object2BearingTextBox.Location = new System.Drawing.Point(56, 22);
			this.Object2BearingTextBox.Name = "Object2BearingTextBox";
			this.Object2BearingTextBox.Size = new System.Drawing.Size(40, 14);
			this.Object2BearingTextBox.TabIndex = 4;
			this.Object2BearingTextBox.Tag = "2";
			this.Object2BearingTextBox.Text = "";
			this.Object2BearingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.Object2BearingTextBox, "The angle at which Object1 is located in relation to Object2\'s heading. Click her" +
				"e to change");
			this.Object2BearingTextBox.Visible = false;
			this.Object2BearingTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BearingTextBox_MouseDown);
			this.Object2BearingTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BearingTextBox_KeyUp);
			// 
			// Object2BearingLabel
			// 
			this.Object2BearingLabel.Enabled = false;
			this.Object2BearingLabel.Location = new System.Drawing.Point(0, 22);
			this.Object2BearingLabel.Name = "Object2BearingLabel";
			this.Object2BearingLabel.Size = new System.Drawing.Size(52, 16);
			this.Object2BearingLabel.TabIndex = 3;
			this.Object2BearingLabel.Text = "Bearing:";
			this.InfoToolTip.SetToolTip(this.Object2BearingLabel, "The angle at which Object1 is located in relation to Object2\'s heading. Click the" +
				" textbox to change");
			this.Object2BearingLabel.Visible = false;
			this.Object2BearingLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object2DetailsButton
			// 
			this.Object2DetailsButton.BackColor = System.Drawing.Color.Maroon;
			this.Object2DetailsButton.Enabled = false;
			this.Object2DetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Object2DetailsButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object2DetailsButton.Location = new System.Drawing.Point(194, 3);
			this.Object2DetailsButton.Name = "Object2DetailsButton";
			this.Object2DetailsButton.Size = new System.Drawing.Size(20, 18);
			this.Object2DetailsButton.TabIndex = 2;
			this.Object2DetailsButton.Text = "»";
			this.InfoToolTip.SetToolTip(this.Object2DetailsButton, "Click to show this ship\'s cargo below");
			this.Object2DetailsButton.Visible = false;
			this.Object2DetailsButton.Click += new System.EventHandler(this.Object2DetailsButton_Click);
			// 
			// Object2Label
			// 
			this.Object2Label.AllowDrop = true;
			this.Object2Label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object2Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object2Label.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object2Label.Location = new System.Drawing.Point(14, 4);
			this.Object2Label.Name = "Object2Label";
			this.Object2Label.Size = new System.Drawing.Size(226, 16);
			this.Object2Label.TabIndex = 1;
			this.Object2Label.Text = "<Drag an object here!>";
			this.InfoToolTip.SetToolTip(this.Object2Label, "Drag another object here, or doubleclick to show this object\'s info");
			this.Object2Label.MouseEnter += new System.EventHandler(this.ObjectLabel_MouseEnter);
			this.Object2Label.DragDrop += new System.Windows.Forms.DragEventHandler(this.Object2Label_DragDrop);
			this.Object2Label.DoubleClick += new System.EventHandler(this.Object2Label_DoubleClick);
			this.Object2Label.DragOver += new System.Windows.Forms.DragEventHandler(this.Object2Label_DragOver);
			this.Object2Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object2LabelLabel
			// 
			this.Object2LabelLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object2LabelLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object2LabelLabel.Location = new System.Drawing.Point(0, 4);
			this.Object2LabelLabel.Name = "Object2LabelLabel";
			this.Object2LabelLabel.Size = new System.Drawing.Size(16, 16);
			this.Object2LabelLabel.TabIndex = 0;
			this.Object2LabelLabel.Text = "2:";
			this.Object2LabelLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// ComparisonPanel
			// 
			this.ComparisonPanel.Controls.Add(this.RangeTextBox);
			this.ComparisonPanel.Controls.Add(this.RangeLabel);
			this.ComparisonPanel.Controls.Add(this.ProjectileAccuracyProgressBar);
			this.ComparisonPanel.Controls.Add(this.AccuracyLabel);
			this.ComparisonPanel.Controls.Add(this.AccuracyLabelLabel);
			this.ComparisonPanel.Controls.Add(this.NumBatteriesTextBox);
			this.ComparisonPanel.Controls.Add(this.NumAmmoClipsTextBox);
			this.ComparisonPanel.Controls.Add(this.NumBatteriesLabel);
			this.ComparisonPanel.Controls.Add(this.NumClipsLabel);
			this.ComparisonPanel.Controls.Add(this.NumMissilesTextBox);
			this.ComparisonPanel.Controls.Add(this.TimeToKillTextBox);
			this.ComparisonPanel.Controls.Add(this.NumMissilesLabel);
			this.ComparisonPanel.Controls.Add(this.TimeToKillLabel);
			this.ComparisonPanel.Controls.Add(this.DetectedRangeTextBox);
			this.ComparisonPanel.Controls.Add(this.DetectionRangeTextBox);
			this.ComparisonPanel.Controls.Add(this.Object2SeesObject1Label);
			this.ComparisonPanel.Controls.Add(this.Object1SeesObject2Label);
			this.ComparisonPanel.Location = new System.Drawing.Point(0, 4);
			this.ComparisonPanel.Name = "ComparisonPanel";
			this.ComparisonPanel.Size = new System.Drawing.Size(224, 84);
			this.ComparisonPanel.TabIndex = 0;
			this.ComparisonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// RangeTextBox
			// 
			this.RangeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.RangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RangeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RangeTextBox.ForeColor = System.Drawing.Color.White;
			this.RangeTextBox.Location = new System.Drawing.Point(60, 65);
			this.RangeTextBox.Name = "RangeTextBox";
			this.RangeTextBox.ReadOnly = true;
			this.RangeTextBox.Size = new System.Drawing.Size(34, 14);
			this.RangeTextBox.TabIndex = 10;
			this.RangeTextBox.Text = "0";
			this.RangeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.RangeTextBox, "The range of the furthest-reaching fired weapon is shown here");
			// 
			// RangeLabel
			// 
			this.RangeLabel.Location = new System.Drawing.Point(2, 65);
			this.RangeLabel.Name = "RangeLabel";
			this.RangeLabel.Size = new System.Drawing.Size(45, 16);
			this.RangeLabel.TabIndex = 9;
			this.RangeLabel.Text = "Range:";
			// 
			// ProjectileAccuracyProgressBar
			// 
			this.ProjectileAccuracyProgressBar.Location = new System.Drawing.Point(4, 33);
			this.ProjectileAccuracyProgressBar.Name = "ProjectileAccuracyProgressBar";
			this.ProjectileAccuracyProgressBar.Size = new System.Drawing.Size(124, 13);
			this.ProjectileAccuracyProgressBar.Step = 1;
			this.ProjectileAccuracyProgressBar.TabIndex = 6;
			this.InfoToolTip.SetToolTip(this.ProjectileAccuracyProgressBar, "Sets the accuracy of DirectDamage weapons. This does not affect AreaEffect weapon" +
				"s");
			this.ProjectileAccuracyProgressBar.Value = 80;
			this.ProjectileAccuracyProgressBar.MouseEnter += new System.EventHandler(this.ProjectileAccuracyProgressBar_MouseEnter);
			this.ProjectileAccuracyProgressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AccuracyProgressBar_MouseMove);
			this.ProjectileAccuracyProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AccuracyProgressBar_MouseDown);
			// 
			// AccuracyLabel
			// 
			this.AccuracyLabel.Location = new System.Drawing.Point(60, 49);
			this.AccuracyLabel.Name = "AccuracyLabel";
			this.AccuracyLabel.Size = new System.Drawing.Size(40, 16);
			this.AccuracyLabel.TabIndex = 8;
			this.AccuracyLabel.Text = "80%";
			this.InfoToolTip.SetToolTip(this.AccuracyLabel, "The chosen weapon accuracy is shown here. Click and drag the slider above to set " +
				"the accuracy");
			this.AccuracyLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// AccuracyLabelLabel
			// 
			this.AccuracyLabelLabel.Location = new System.Drawing.Point(2, 49);
			this.AccuracyLabelLabel.Name = "AccuracyLabelLabel";
			this.AccuracyLabelLabel.Size = new System.Drawing.Size(64, 16);
			this.AccuracyLabelLabel.TabIndex = 7;
			this.AccuracyLabelLabel.Text = "Accuracy:";
			this.InfoToolTip.SetToolTip(this.AccuracyLabelLabel, "The chosen weapon accuracy is shown here. Click and drag the slider above to set " +
				"the accuracy");
			this.AccuracyLabelLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// NumBatteriesTextBox
			// 
			this.NumBatteriesTextBox.BackColor = System.Drawing.Color.Maroon;
			this.NumBatteriesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NumBatteriesTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NumBatteriesTextBox.ForeColor = System.Drawing.Color.White;
			this.NumBatteriesTextBox.Location = new System.Drawing.Point(178, 65);
			this.NumBatteriesTextBox.Name = "NumBatteriesTextBox";
			this.NumBatteriesTextBox.ReadOnly = true;
			this.NumBatteriesTextBox.Size = new System.Drawing.Size(36, 14);
			this.NumBatteriesTextBox.TabIndex = 16;
			this.NumBatteriesTextBox.Text = "0";
			this.NumBatteriesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.NumBatteriesTextBox, "The number of this ship\'s batteries required to kill the target with the specifie" +
				"d weapons. Choose the weapons to fire by checking the boxes beside the weapon na" +
				"me below");
			// 
			// NumAmmoClipsTextBox
			// 
			this.NumAmmoClipsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.NumAmmoClipsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NumAmmoClipsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NumAmmoClipsTextBox.ForeColor = System.Drawing.Color.White;
			this.NumAmmoClipsTextBox.Location = new System.Drawing.Point(178, 33);
			this.NumAmmoClipsTextBox.Name = "NumAmmoClipsTextBox";
			this.NumAmmoClipsTextBox.ReadOnly = true;
			this.NumAmmoClipsTextBox.Size = new System.Drawing.Size(36, 14);
			this.NumAmmoClipsTextBox.TabIndex = 12;
			this.NumAmmoClipsTextBox.Text = "0";
			this.NumAmmoClipsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.NumAmmoClipsTextBox, "The number of ammo clips required to kill the target with the selected weapons is" +
				" shown here. Choose the weapons to fire with the checkboxes below");
			// 
			// NumBatteriesLabel
			// 
			this.NumBatteriesLabel.Location = new System.Drawing.Point(108, 65);
			this.NumBatteriesLabel.Name = "NumBatteriesLabel";
			this.NumBatteriesLabel.Size = new System.Drawing.Size(72, 16);
			this.NumBatteriesLabel.TabIndex = 15;
			this.NumBatteriesLabel.Text = "#Batteries:";
			this.InfoToolTip.SetToolTip(this.NumBatteriesLabel, "The number of this ship\'s batteries required to kill the target with the specifie" +
				"d weapons. Choose the weapons to fire by checking the boxes beside the weapon na" +
				"me below");
			this.NumBatteriesLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// NumClipsLabel
			// 
			this.NumClipsLabel.Location = new System.Drawing.Point(135, 33);
			this.NumClipsLabel.Name = "NumClipsLabel";
			this.NumClipsLabel.Size = new System.Drawing.Size(45, 16);
			this.NumClipsLabel.TabIndex = 11;
			this.NumClipsLabel.Text = "#Clips:";
			this.InfoToolTip.SetToolTip(this.NumClipsLabel, "The number of ammo clips required to kill the target with the selected weapons is" +
				" shown here. Choose the weapons to fire with the checkboxes below");
			this.NumClipsLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// NumMissilesTextBox
			// 
			this.NumMissilesTextBox.BackColor = System.Drawing.Color.Maroon;
			this.NumMissilesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NumMissilesTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NumMissilesTextBox.ForeColor = System.Drawing.Color.White;
			this.NumMissilesTextBox.Location = new System.Drawing.Point(178, 49);
			this.NumMissilesTextBox.Name = "NumMissilesTextBox";
			this.NumMissilesTextBox.ReadOnly = true;
			this.NumMissilesTextBox.Size = new System.Drawing.Size(36, 14);
			this.NumMissilesTextBox.TabIndex = 14;
			this.NumMissilesTextBox.Text = "0";
			this.NumMissilesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.NumMissilesTextBox, "The number of missiles required to kill the target is shown here. You must fire t" +
				"he missiles below by checking the box next to the missile name");
			// 
			// TimeToKillTextBox
			// 
			this.TimeToKillTextBox.BackColor = System.Drawing.Color.Maroon;
			this.TimeToKillTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TimeToKillTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TimeToKillTextBox.ForeColor = System.Drawing.Color.White;
			this.TimeToKillTextBox.Location = new System.Drawing.Point(178, 17);
			this.TimeToKillTextBox.Name = "TimeToKillTextBox";
			this.TimeToKillTextBox.ReadOnly = true;
			this.TimeToKillTextBox.Size = new System.Drawing.Size(36, 14);
			this.TimeToKillTextBox.TabIndex = 5;
			this.TimeToKillTextBox.Text = "0";
			this.TimeToKillTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.TimeToKillTextBox, "The #seconds it takes to kill the target with the selected weapons is shown here." +
				" Select weapons by checking the boxes beside the part name below");
			// 
			// NumMissilesLabel
			// 
			this.NumMissilesLabel.Location = new System.Drawing.Point(117, 49);
			this.NumMissilesLabel.Name = "NumMissilesLabel";
			this.NumMissilesLabel.Size = new System.Drawing.Size(62, 16);
			this.NumMissilesLabel.TabIndex = 13;
			this.NumMissilesLabel.Text = "#Missiles:";
			this.InfoToolTip.SetToolTip(this.NumMissilesLabel, "The number of missiles required to kill the target is shown here. You must fire t" +
				"he missiles below by checking the box next to the missile name");
			this.NumMissilesLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// TimeToKillLabel
			// 
			this.TimeToKillLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.TimeToKillLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.TimeToKillLabel.Location = new System.Drawing.Point(178, 0);
			this.TimeToKillLabel.Name = "TimeToKillLabel";
			this.TimeToKillLabel.Size = new System.Drawing.Size(30, 16);
			this.TimeToKillLabel.TabIndex = 4;
			this.TimeToKillLabel.Text = "TTK:";
			this.InfoToolTip.SetToolTip(this.TimeToKillLabel, "The #seconds it takes to kill the target with the selected weapons is shown here." +
				" Select weapons by checking the boxes beside the part name below");
			this.TimeToKillLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object2SeesObject1Label
			// 
			this.Object2SeesObject1Label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object2SeesObject1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object2SeesObject1Label.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object2SeesObject1Label.Location = new System.Drawing.Point(80, 0);
			this.Object2SeesObject1Label.Name = "Object2SeesObject1Label";
			this.Object2SeesObject1Label.Size = new System.Drawing.Size(64, 16);
			this.Object2SeesObject1Label.TabIndex = 2;
			this.Object2SeesObject1Label.Text = "T sees Me:";
			this.InfoToolTip.SetToolTip(this.Object2SeesObject1Label, "Object2 will spot Object1 when it is this far away, or closer");
			this.Object2SeesObject1Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// Object1SeesObject2Label
			// 
			this.Object1SeesObject2Label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.Object1SeesObject2Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Object1SeesObject2Label.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Object1SeesObject2Label.Location = new System.Drawing.Point(1, 0);
			this.Object1SeesObject2Label.Name = "Object1SeesObject2Label";
			this.Object1SeesObject2Label.Size = new System.Drawing.Size(223, 16);
			this.Object1SeesObject2Label.TabIndex = 0;
			this.Object1SeesObject2Label.Text = "I see T:";
			this.InfoToolTip.SetToolTip(this.Object1SeesObject2Label, "Object1 will see Object2 when it is this far away, or closer");
			this.Object1SeesObject2Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			// 
			// CargoPanel
			// 
			this.CargoPanel.Controls.Add(this.LaunchSpeedTextBox);
			this.CargoPanel.Controls.Add(this.label1);
			this.CargoPanel.Controls.Add(this.CloakPanel);
			this.CargoPanel.Controls.Add(this.CloakLabel);
			this.CargoPanel.Controls.Add(this.ShieldLlabel);
			this.CargoPanel.Controls.Add(this.BoosterPanel);
			this.CargoPanel.Controls.Add(this.MissilePanel);
			this.CargoPanel.Controls.Add(this.BoosterLabel);
			this.CargoPanel.Controls.Add(this.MissileLabel);
			this.CargoPanel.Controls.Add(this.TurretsLabel);
			this.CargoPanel.Controls.Add(this.TurretsPanel);
			this.CargoPanel.Controls.Add(this.GunsLabel);
			this.CargoPanel.Controls.Add(this.ShieldPanel);
			this.CargoPanel.Controls.Add(this.WeaponsPanel);
			this.CargoPanel.Location = new System.Drawing.Point(2, 158);
			this.CargoPanel.Name = "CargoPanel";
			this.CargoPanel.Size = new System.Drawing.Size(224, 172);
			this.CargoPanel.TabIndex = 3;
			// 
			// LaunchSpeedTextBox
			// 
			this.LaunchSpeedTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LaunchSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LaunchSpeedTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LaunchSpeedTextBox.ForeColor = System.Drawing.Color.White;
			this.LaunchSpeedTextBox.Location = new System.Drawing.Point(89, 92);
			this.LaunchSpeedTextBox.Name = "LaunchSpeedTextBox";
			this.LaunchSpeedTextBox.Size = new System.Drawing.Size(20, 14);
			this.LaunchSpeedTextBox.TabIndex = 5;
			this.LaunchSpeedTextBox.Text = "0";
			this.LaunchSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InfoToolTip.SetToolTip(this.LaunchSpeedTextBox, "The speed of this ship when launching missiles");
			this.LaunchSpeedTextBox.TextChanged += new System.EventHandler(this.LaunchSpeedTextBox_TextChanged);
			this.LaunchSpeedTextBox.MouseEnter += new System.EventHandler(this.LaunchSpeedTextBox_MouseEnter);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(106, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(8, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = ")";
			// 
			// CloakPanel
			// 
			this.CloakPanel.Controls.Add(this.UseCloakCheckBox);
			this.CloakPanel.Controls.Add(this.CloakTextBox);
			this.CloakPanel.Enabled = false;
			this.CloakPanel.Location = new System.Drawing.Point(116, 152);
			this.CloakPanel.Name = "CloakPanel";
			this.CloakPanel.Size = new System.Drawing.Size(104, 16);
			this.CloakPanel.TabIndex = 12;
			// 
			// UseCloakCheckBox
			// 
			this.UseCloakCheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseCloakCheckBox.Name = "UseCloakCheckBox";
			this.UseCloakCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseCloakCheckBox.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UseCloakCheckBox, "Check this box to use this cloak");
			this.UseCloakCheckBox.Click += new System.EventHandler(this.UseCloakCheckBox_Clicked);
			// 
			// CloakTextBox
			// 
			this.CloakTextBox.BackColor = System.Drawing.Color.Maroon;
			this.CloakTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CloakTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.CloakTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CloakTextBox.ForeColor = System.Drawing.Color.White;
			this.CloakTextBox.Location = new System.Drawing.Point(0, 0);
			this.CloakTextBox.Name = "CloakTextBox";
			this.CloakTextBox.ReadOnly = true;
			this.CloakTextBox.Size = new System.Drawing.Size(84, 14);
			this.CloakTextBox.TabIndex = 0;
			this.CloakTextBox.Tag = "13";
			this.CloakTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.CloakTextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// AvailablePartsContextMenu
			// 
			this.AvailablePartsContextMenu.Popup += new System.EventHandler(this.AvailablePartsContextMenu_Popup);
			// 
			// CloakLabel
			// 
			this.CloakLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.CloakLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CloakLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.CloakLabel.Location = new System.Drawing.Point(116, 132);
			this.CloakLabel.Name = "CloakLabel";
			this.CloakLabel.Size = new System.Drawing.Size(40, 16);
			this.CloakLabel.TabIndex = 11;
			this.CloakLabel.Text = "Cloak:";
			// 
			// ShieldLlabel
			// 
			this.ShieldLlabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ShieldLlabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldLlabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ShieldLlabel.Location = new System.Drawing.Point(0, 132);
			this.ShieldLlabel.Name = "ShieldLlabel";
			this.ShieldLlabel.Size = new System.Drawing.Size(224, 16);
			this.ShieldLlabel.TabIndex = 9;
			this.ShieldLlabel.Text = "Shield:";
			// 
			// BoosterPanel
			// 
			this.BoosterPanel.Controls.Add(this.UseBoosterCheckBox);
			this.BoosterPanel.Controls.Add(this.BoosterTextBox);
			this.BoosterPanel.Enabled = false;
			this.BoosterPanel.Location = new System.Drawing.Point(116, 112);
			this.BoosterPanel.Name = "BoosterPanel";
			this.BoosterPanel.Size = new System.Drawing.Size(104, 16);
			this.BoosterPanel.TabIndex = 8;
			// 
			// UseBoosterCheckBox
			// 
			this.UseBoosterCheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseBoosterCheckBox.Name = "UseBoosterCheckBox";
			this.UseBoosterCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseBoosterCheckBox.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UseBoosterCheckBox, "Check this box to fire this booster");
			this.UseBoosterCheckBox.Click += new System.EventHandler(this.UseBoosterCheckBox_Clicked);
			// 
			// BoosterTextBox
			// 
			this.BoosterTextBox.BackColor = System.Drawing.Color.Maroon;
			this.BoosterTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BoosterTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.BoosterTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BoosterTextBox.ForeColor = System.Drawing.Color.White;
			this.BoosterTextBox.Location = new System.Drawing.Point(0, 0);
			this.BoosterTextBox.Name = "BoosterTextBox";
			this.BoosterTextBox.ReadOnly = true;
			this.BoosterTextBox.Size = new System.Drawing.Size(84, 14);
			this.BoosterTextBox.TabIndex = 0;
			this.BoosterTextBox.Tag = "15";
			this.BoosterTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.BoosterTextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// MissilePanel
			// 
			this.MissilePanel.Controls.Add(this.MissileTextBox);
			this.MissilePanel.Controls.Add(this.UseMissileCheckBox);
			this.MissilePanel.Enabled = false;
			this.MissilePanel.Location = new System.Drawing.Point(0, 108);
			this.MissilePanel.Name = "MissilePanel";
			this.MissilePanel.Size = new System.Drawing.Size(112, 20);
			this.MissilePanel.TabIndex = 6;
			// 
			// MissileTextBox
			// 
			this.MissileTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MissileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MissileTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.MissileTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MissileTextBox.ForeColor = System.Drawing.Color.White;
			this.MissileTextBox.Location = new System.Drawing.Point(14, 4);
			this.MissileTextBox.Name = "MissileTextBox";
			this.MissileTextBox.ReadOnly = true;
			this.MissileTextBox.Size = new System.Drawing.Size(84, 14);
			this.MissileTextBox.TabIndex = 0;
			this.MissileTextBox.Tag = "10";
			this.MissileTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.MissileTextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// UseMissileCheckBox
			// 
			this.UseMissileCheckBox.Location = new System.Drawing.Point(98, 3);
			this.UseMissileCheckBox.Name = "UseMissileCheckBox";
			this.UseMissileCheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseMissileCheckBox.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UseMissileCheckBox, "Check this box to fire this missile");
			this.UseMissileCheckBox.Click += new System.EventHandler(this.UseMissileCheckBox_Clicked);
			// 
			// BoosterLabel
			// 
			this.BoosterLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.BoosterLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BoosterLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.BoosterLabel.Location = new System.Drawing.Point(116, 92);
			this.BoosterLabel.Name = "BoosterLabel";
			this.BoosterLabel.Size = new System.Drawing.Size(61, 16);
			this.BoosterLabel.TabIndex = 7;
			this.BoosterLabel.Text = "Booster:";
			// 
			// MissileLabel
			// 
			this.MissileLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.MissileLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MissileLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.MissileLabel.Location = new System.Drawing.Point(0, 92);
			this.MissileLabel.Name = "MissileLabel";
			this.MissileLabel.Size = new System.Drawing.Size(224, 16);
			this.MissileLabel.TabIndex = 4;
			this.MissileLabel.Text = "Missile:       (LS:";
			// 
			// TurretsLabel
			// 
			this.TurretsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.TurretsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TurretsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.TurretsLabel.Location = new System.Drawing.Point(116, 5);
			this.TurretsLabel.Name = "TurretsLabel";
			this.TurretsLabel.Size = new System.Drawing.Size(61, 16);
			this.TurretsLabel.TabIndex = 2;
			this.TurretsLabel.Text = "Turrets:";
			// 
			// TurretsPanel
			// 
			this.TurretsPanel.Controls.Add(this.TurretSlot4Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot3Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot1Panel);
			this.TurretsPanel.Controls.Add(this.TurretSlot2Panel);
			this.TurretsPanel.Location = new System.Drawing.Point(116, 24);
			this.TurretsPanel.Name = "TurretsPanel";
			this.TurretsPanel.Size = new System.Drawing.Size(104, 64);
			this.TurretsPanel.TabIndex = 3;
			// 
			// TurretSlot4Panel
			// 
			this.TurretSlot4Panel.Controls.Add(this.UseTurr4CheckBox);
			this.TurretSlot4Panel.Controls.Add(this.Turr4TextBox);
			this.TurretSlot4Panel.Enabled = false;
			this.TurretSlot4Panel.Location = new System.Drawing.Point(0, 48);
			this.TurretSlot4Panel.Name = "TurretSlot4Panel";
			this.TurretSlot4Panel.Size = new System.Drawing.Size(106, 16);
			this.TurretSlot4Panel.TabIndex = 3;
			// 
			// UseTurr4CheckBox
			// 
			this.UseTurr4CheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseTurr4CheckBox.Name = "UseTurr4CheckBox";
			this.UseTurr4CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr4CheckBox.TabIndex = 1;
			this.UseTurr4CheckBox.Tag = "3";
			this.InfoToolTip.SetToolTip(this.UseTurr4CheckBox, "Check this box to fire this turret");
			this.UseTurr4CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Clicked);
			// 
			// Turr4TextBox
			// 
			this.Turr4TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr4TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr4TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr4TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr4TextBox.Location = new System.Drawing.Point(0, 0);
			this.Turr4TextBox.Name = "Turr4TextBox";
			this.Turr4TextBox.ReadOnly = true;
			this.Turr4TextBox.Size = new System.Drawing.Size(84, 14);
			this.Turr4TextBox.TabIndex = 0;
			this.Turr4TextBox.Tag = "7";
			this.Turr4TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr4TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// TurretSlot3Panel
			// 
			this.TurretSlot3Panel.Controls.Add(this.UseTurr3CheckBox);
			this.TurretSlot3Panel.Controls.Add(this.Turr3TextBox);
			this.TurretSlot3Panel.Enabled = false;
			this.TurretSlot3Panel.Location = new System.Drawing.Point(0, 32);
			this.TurretSlot3Panel.Name = "TurretSlot3Panel";
			this.TurretSlot3Panel.Size = new System.Drawing.Size(106, 16);
			this.TurretSlot3Panel.TabIndex = 2;
			// 
			// UseTurr3CheckBox
			// 
			this.UseTurr3CheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseTurr3CheckBox.Name = "UseTurr3CheckBox";
			this.UseTurr3CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr3CheckBox.TabIndex = 1;
			this.UseTurr3CheckBox.Tag = "2";
			this.InfoToolTip.SetToolTip(this.UseTurr3CheckBox, "Check this box to fire this turret");
			this.UseTurr3CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Clicked);
			// 
			// Turr3TextBox
			// 
			this.Turr3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr3TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr3TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr3TextBox.Location = new System.Drawing.Point(0, 0);
			this.Turr3TextBox.Name = "Turr3TextBox";
			this.Turr3TextBox.ReadOnly = true;
			this.Turr3TextBox.Size = new System.Drawing.Size(84, 14);
			this.Turr3TextBox.TabIndex = 0;
			this.Turr3TextBox.Tag = "6";
			this.Turr3TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr3TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// TurretSlot1Panel
			// 
			this.TurretSlot1Panel.Controls.Add(this.Turr1TextBox);
			this.TurretSlot1Panel.Controls.Add(this.UseTurr1CheckBox);
			this.TurretSlot1Panel.Enabled = false;
			this.TurretSlot1Panel.Location = new System.Drawing.Point(0, 0);
			this.TurretSlot1Panel.Name = "TurretSlot1Panel";
			this.TurretSlot1Panel.Size = new System.Drawing.Size(106, 16);
			this.TurretSlot1Panel.TabIndex = 0;
			// 
			// Turr1TextBox
			// 
			this.Turr1TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr1TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr1TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr1TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr1TextBox.Location = new System.Drawing.Point(0, 0);
			this.Turr1TextBox.Name = "Turr1TextBox";
			this.Turr1TextBox.ReadOnly = true;
			this.Turr1TextBox.Size = new System.Drawing.Size(84, 14);
			this.Turr1TextBox.TabIndex = 0;
			this.Turr1TextBox.Tag = "4";
			this.Turr1TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr1TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// UseTurr1CheckBox
			// 
			this.UseTurr1CheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseTurr1CheckBox.Name = "UseTurr1CheckBox";
			this.UseTurr1CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr1CheckBox.TabIndex = 1;
			this.UseTurr1CheckBox.Tag = "0";
			this.InfoToolTip.SetToolTip(this.UseTurr1CheckBox, "Check this box to fire this turret");
			this.UseTurr1CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Clicked);
			// 
			// TurretSlot2Panel
			// 
			this.TurretSlot2Panel.Controls.Add(this.UseTurr2CheckBox);
			this.TurretSlot2Panel.Controls.Add(this.Turr2TextBox);
			this.TurretSlot2Panel.Enabled = false;
			this.TurretSlot2Panel.Location = new System.Drawing.Point(0, 16);
			this.TurretSlot2Panel.Name = "TurretSlot2Panel";
			this.TurretSlot2Panel.Size = new System.Drawing.Size(106, 16);
			this.TurretSlot2Panel.TabIndex = 1;
			// 
			// UseTurr2CheckBox
			// 
			this.UseTurr2CheckBox.Location = new System.Drawing.Point(84, -1);
			this.UseTurr2CheckBox.Name = "UseTurr2CheckBox";
			this.UseTurr2CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseTurr2CheckBox.TabIndex = 1;
			this.UseTurr2CheckBox.Tag = "1";
			this.InfoToolTip.SetToolTip(this.UseTurr2CheckBox, "Check this box to fire this turret");
			this.UseTurr2CheckBox.Click += new System.EventHandler(this.UseTurretCheckBox_Clicked);
			// 
			// Turr2TextBox
			// 
			this.Turr2TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Turr2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Turr2TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Turr2TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Turr2TextBox.ForeColor = System.Drawing.Color.White;
			this.Turr2TextBox.Location = new System.Drawing.Point(0, 0);
			this.Turr2TextBox.Name = "Turr2TextBox";
			this.Turr2TextBox.ReadOnly = true;
			this.Turr2TextBox.Size = new System.Drawing.Size(84, 14);
			this.Turr2TextBox.TabIndex = 0;
			this.Turr2TextBox.Tag = "5";
			this.Turr2TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Turr2TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// GunsLabel
			// 
			this.GunsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.GunsLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GunsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.GunsLabel.Location = new System.Drawing.Point(0, 5);
			this.GunsLabel.Name = "GunsLabel";
			this.GunsLabel.Size = new System.Drawing.Size(224, 16);
			this.GunsLabel.TabIndex = 0;
			this.GunsLabel.Text = "Guns:";
			// 
			// ShieldPanel
			// 
			this.ShieldPanel.Controls.Add(this.ShieldTextBox);
			this.ShieldPanel.Enabled = false;
			this.ShieldPanel.Location = new System.Drawing.Point(0, 152);
			this.ShieldPanel.Name = "ShieldPanel";
			this.ShieldPanel.Size = new System.Drawing.Size(104, 16);
			this.ShieldPanel.TabIndex = 10;
			// 
			// ShieldTextBox
			// 
			this.ShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ShieldTextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.ShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.ShieldTextBox.Location = new System.Drawing.Point(14, 0);
			this.ShieldTextBox.Name = "ShieldTextBox";
			this.ShieldTextBox.ReadOnly = true;
			this.ShieldTextBox.Size = new System.Drawing.Size(84, 14);
			this.ShieldTextBox.TabIndex = 2;
			this.ShieldTextBox.Tag = "12";
			this.ShieldTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.ShieldTextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// WeaponsPanel
			// 
			this.WeaponsPanel.Controls.Add(this.WeaponSlot3Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot4Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot1Panel);
			this.WeaponsPanel.Controls.Add(this.WeaponSlot2Panel);
			this.WeaponsPanel.Location = new System.Drawing.Point(0, 24);
			this.WeaponsPanel.Name = "WeaponsPanel";
			this.WeaponsPanel.Size = new System.Drawing.Size(120, 64);
			this.WeaponsPanel.TabIndex = 1;
			// 
			// WeaponSlot3Panel
			// 
			this.WeaponSlot3Panel.Controls.Add(this.Wep3TextBox);
			this.WeaponSlot3Panel.Controls.Add(this.Wep3Label);
			this.WeaponSlot3Panel.Controls.Add(this.UseWeapon3CheckBox);
			this.WeaponSlot3Panel.Enabled = false;
			this.WeaponSlot3Panel.Location = new System.Drawing.Point(0, 32);
			this.WeaponSlot3Panel.Name = "WeaponSlot3Panel";
			this.WeaponSlot3Panel.Size = new System.Drawing.Size(120, 16);
			this.WeaponSlot3Panel.TabIndex = 2;
			// 
			// Wep3TextBox
			// 
			this.Wep3TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep3TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep3TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep3TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep3TextBox.Location = new System.Drawing.Point(14, 0);
			this.Wep3TextBox.Name = "Wep3TextBox";
			this.Wep3TextBox.ReadOnly = true;
			this.Wep3TextBox.Size = new System.Drawing.Size(84, 14);
			this.Wep3TextBox.TabIndex = 1;
			this.Wep3TextBox.Tag = "2";
			this.Wep3TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep3TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// Wep3Label
			// 
			this.Wep3Label.BackColor = System.Drawing.Color.Black;
			this.Wep3Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep3Label.Location = new System.Drawing.Point(-1, 0);
			this.Wep3Label.Name = "Wep3Label";
			this.Wep3Label.Size = new System.Drawing.Size(16, 16);
			this.Wep3Label.TabIndex = 0;
			this.Wep3Label.Text = "3:";
			// 
			// UseWeapon3CheckBox
			// 
			this.UseWeapon3CheckBox.AutoCheck = false;
			this.UseWeapon3CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon3CheckBox.Location = new System.Drawing.Point(98, -1);
			this.UseWeapon3CheckBox.Name = "UseWeapon3CheckBox";
			this.UseWeapon3CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon3CheckBox.TabIndex = 2;
			this.UseWeapon3CheckBox.Tag = "2";
			this.InfoToolTip.SetToolTip(this.UseWeapon3CheckBox, "Check this box to fire this weapon. Multiple checks link weapons or unlink them");
			this.UseWeapon3CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// WeaponSlot4Panel
			// 
			this.WeaponSlot4Panel.Controls.Add(this.Wep4TextBox);
			this.WeaponSlot4Panel.Controls.Add(this.Wep4Label);
			this.WeaponSlot4Panel.Controls.Add(this.UseWeapon4CheckBox);
			this.WeaponSlot4Panel.Enabled = false;
			this.WeaponSlot4Panel.Location = new System.Drawing.Point(0, 48);
			this.WeaponSlot4Panel.Name = "WeaponSlot4Panel";
			this.WeaponSlot4Panel.Size = new System.Drawing.Size(120, 16);
			this.WeaponSlot4Panel.TabIndex = 3;
			// 
			// Wep4TextBox
			// 
			this.Wep4TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep4TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep4TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep4TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep4TextBox.Location = new System.Drawing.Point(14, 0);
			this.Wep4TextBox.Name = "Wep4TextBox";
			this.Wep4TextBox.ReadOnly = true;
			this.Wep4TextBox.Size = new System.Drawing.Size(84, 14);
			this.Wep4TextBox.TabIndex = 1;
			this.Wep4TextBox.Tag = "3";
			this.Wep4TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep4TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// Wep4Label
			// 
			this.Wep4Label.BackColor = System.Drawing.Color.Black;
			this.Wep4Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep4Label.Location = new System.Drawing.Point(-1, 0);
			this.Wep4Label.Name = "Wep4Label";
			this.Wep4Label.Size = new System.Drawing.Size(16, 16);
			this.Wep4Label.TabIndex = 0;
			this.Wep4Label.Text = "4:";
			// 
			// UseWeapon4CheckBox
			// 
			this.UseWeapon4CheckBox.AutoCheck = false;
			this.UseWeapon4CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon4CheckBox.Location = new System.Drawing.Point(98, -1);
			this.UseWeapon4CheckBox.Name = "UseWeapon4CheckBox";
			this.UseWeapon4CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon4CheckBox.TabIndex = 2;
			this.UseWeapon4CheckBox.Tag = "3";
			this.InfoToolTip.SetToolTip(this.UseWeapon4CheckBox, "Check this box to fire this weapon. Multiple checks link weapons or unlink them");
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
			this.WeaponSlot1Panel.Size = new System.Drawing.Size(120, 16);
			this.WeaponSlot1Panel.TabIndex = 0;
			// 
			// UseWeapon1CheckBox
			// 
			this.UseWeapon1CheckBox.AutoCheck = false;
			this.UseWeapon1CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon1CheckBox.Location = new System.Drawing.Point(98, -1);
			this.UseWeapon1CheckBox.Name = "UseWeapon1CheckBox";
			this.UseWeapon1CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon1CheckBox.TabIndex = 2;
			this.UseWeapon1CheckBox.Tag = "0";
			this.InfoToolTip.SetToolTip(this.UseWeapon1CheckBox, "Check this box to fire this weapon. Multiple checks link weapons or unlink them");
			this.UseWeapon1CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// Wep1TextBox
			// 
			this.Wep1TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep1TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep1TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep1TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep1TextBox.Location = new System.Drawing.Point(14, 0);
			this.Wep1TextBox.Name = "Wep1TextBox";
			this.Wep1TextBox.ReadOnly = true;
			this.Wep1TextBox.Size = new System.Drawing.Size(84, 14);
			this.Wep1TextBox.TabIndex = 1;
			this.Wep1TextBox.Tag = "0";
			this.Wep1TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep1TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// Wep1Label
			// 
			this.Wep1Label.BackColor = System.Drawing.Color.Black;
			this.Wep1Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep1Label.Location = new System.Drawing.Point(-1, 0);
			this.Wep1Label.Name = "Wep1Label";
			this.Wep1Label.Size = new System.Drawing.Size(16, 16);
			this.Wep1Label.TabIndex = 0;
			this.Wep1Label.Text = "1:";
			// 
			// WeaponSlot2Panel
			// 
			this.WeaponSlot2Panel.Controls.Add(this.UseWeapon2CheckBox);
			this.WeaponSlot2Panel.Controls.Add(this.Wep2TextBox);
			this.WeaponSlot2Panel.Controls.Add(this.Wep2Label);
			this.WeaponSlot2Panel.Enabled = false;
			this.WeaponSlot2Panel.Location = new System.Drawing.Point(0, 16);
			this.WeaponSlot2Panel.Name = "WeaponSlot2Panel";
			this.WeaponSlot2Panel.Size = new System.Drawing.Size(120, 16);
			this.WeaponSlot2Panel.TabIndex = 1;
			// 
			// UseWeapon2CheckBox
			// 
			this.UseWeapon2CheckBox.AutoCheck = false;
			this.UseWeapon2CheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UseWeapon2CheckBox.Location = new System.Drawing.Point(98, -1);
			this.UseWeapon2CheckBox.Name = "UseWeapon2CheckBox";
			this.UseWeapon2CheckBox.Size = new System.Drawing.Size(16, 16);
			this.UseWeapon2CheckBox.TabIndex = 2;
			this.UseWeapon2CheckBox.Tag = "1";
			this.InfoToolTip.SetToolTip(this.UseWeapon2CheckBox, "Check this box to fire this weapon. Multiple checks link weapons or unlink them");
			this.UseWeapon2CheckBox.Click += new System.EventHandler(this.UseWeaponCheckBox_Click);
			// 
			// Wep2TextBox
			// 
			this.Wep2TextBox.BackColor = System.Drawing.Color.Maroon;
			this.Wep2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Wep2TextBox.ContextMenu = this.AvailablePartsContextMenu;
			this.Wep2TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep2TextBox.ForeColor = System.Drawing.Color.White;
			this.Wep2TextBox.Location = new System.Drawing.Point(14, 0);
			this.Wep2TextBox.Name = "Wep2TextBox";
			this.Wep2TextBox.ReadOnly = true;
			this.Wep2TextBox.Size = new System.Drawing.Size(84, 14);
			this.Wep2TextBox.TabIndex = 1;
			this.Wep2TextBox.Tag = "1";
			this.Wep2TextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.Wep2TextBox, "Rightclick to see a list of available parts that can be mounted in this slot. Res" +
				"earch more tech on the main screen to make more tech available");
			// 
			// Wep2Label
			// 
			this.Wep2Label.BackColor = System.Drawing.Color.Black;
			this.Wep2Label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Wep2Label.Location = new System.Drawing.Point(-1, 0);
			this.Wep2Label.Name = "Wep2Label";
			this.Wep2Label.Size = new System.Drawing.Size(16, 16);
			this.Wep2Label.TabIndex = 0;
			this.Wep2Label.Text = "2:";
			// 
			// InfoToolTip
			// 
			this.InfoToolTip.AutomaticDelay = 0;
			this.InfoToolTip.AutoPopDelay = 60000;
			this.InfoToolTip.InitialDelay = 500;
			this.InfoToolTip.ReshowDelay = 100;
			// 
			// ComparisonTimer
			// 
			this.ComparisonTimer.Enabled = true;
			this.ComparisonTimer.Tick += new System.EventHandler(this.ComparisonTimer_Tick);
			// 
			// SeparatorPanel
			// 
			this.SeparatorPanel.BackColor = System.Drawing.Color.DimGray;
			this.SeparatorPanel.Location = new System.Drawing.Point(0, 85);
			this.SeparatorPanel.Name = "SeparatorPanel";
			this.SeparatorPanel.Size = new System.Drawing.Size(256, 2);
			this.SeparatorPanel.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DimGray;
			this.panel1.Location = new System.Drawing.Point(0, 161);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 2);
			this.panel1.TabIndex = 5;
			// 
			// ComparisonForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(217, 326);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.SeparatorPanel);
			this.Controls.Add(this.CargoPanel);
			this.Controls.Add(this.ComparisonPanel);
			this.Controls.Add(this.Object1Panel);
			this.Controls.Add(this.Object2Panel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ComparisonForm";
			this.ShowInTaskbar = false;
			this.Text = "Comparison";
			this.TopMost = true;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComparisonForm_MouseDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ComparisonForm_Closing);
			this.Load += new System.EventHandler(this.ComparisonForm_Load);
			this.Object1Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Object1KillsNumericUpDown)).EndInit();
			this.Object2Panel.ResumeLayout(false);
			this.ComparisonPanel.ResumeLayout(false);
			this.CargoPanel.ResumeLayout(false);
			this.CloakPanel.ResumeLayout(false);
			this.BoosterPanel.ResumeLayout(false);
			this.MissilePanel.ResumeLayout(false);
			this.TurretsPanel.ResumeLayout(false);
			this.TurretSlot4Panel.ResumeLayout(false);
			this.TurretSlot3Panel.ResumeLayout(false);
			this.TurretSlot1Panel.ResumeLayout(false);
			this.TurretSlot2Panel.ResumeLayout(false);
			this.ShieldPanel.ResumeLayout(false);
			this.WeaponsPanel.ResumeLayout(false);
			this.WeaponSlot3Panel.ResumeLayout(false);
			this.WeaponSlot4Panel.ResumeLayout(false);
			this.WeaponSlot1Panel.ResumeLayout(false);
			this.WeaponSlot2Panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void MeChangedHandler (object sender, EventArgs e)
		{
			if (sender == null)
			{
//				_game.Me.Updated -= new EventHandler(MeChangedHandler);
//				_game.Target.Updated -= new EventHandler(TargetChangedHandler);
				this.Close();
			}
			else
			{
				this.Object1 = (Ship)sender;
			}
		}

		private void TargetChangedHandler (object sender, EventArgs e)
		{
			if (sender == null)
			{
//				_game.Me.Updated -= new EventHandler(MeChangedHandler);
//				_game.Target.Updated -= new EventHandler(TargetChangedHandler);
				this.Close();
			}
			else
			{
				this.Object2 = (AllegObject)sender;
			}
		}

		private void Object1ChangedHandler (object sender, EventArgs e)
		{
			UpdateComparison();
		}
		
		private void Object2ChangedHandler (object sender, EventArgs e)
		{
			UpdateComparison();
		}
		
		private void Object1ClosedHandler (object sender, EventArgs e)
		{
			if (_object1 == _game.Me)
				this.Close();

			if (_selectedShip == _object1)
				HideObject1Details();

			_object1 = null;

			if (_object2 == null)
				this.Close();
			else
				UpdateObjects();
		}

		private void Object2ClosedHandler (object sender, EventArgs e)
		{
			if (_selectedShip == _object2)
				HideObject2Details();

			if (_object1 == _game.Me && _object2 == _game.Target)
				this.Close();

			_object2 = null;

			if (_object1 == null)
				this.Close();
			else
				UpdateObjects();
		}

		private void UpdateComparison ()
		{
			float DetectionRange = 0F;
			float DetectedRange = 0F;
			float LaunchSpeed = 0F;
			Comparison Comp = null;

			if (_object1 != null)
			{
				if (_object1 is Ship)
				{
					Ship Ship1 = (Ship)_object1;
					try
					{
						LaunchSpeed = float.Parse(LaunchSpeedTextBox.Text);
					}
					catch (Exception)
					{
					}

					Object1KillsNumericUpDown.Value = Ship1.Kills;
					if (Ship1.FireWeapons == true || Ship1.FireTurrets[0] == true ||
						Ship1.FireTurrets[1] == true || Ship1.FireTurrets[2] == true ||
						Ship1.FireTurrets[3] == true)
					{
						AccuracyLabelLabel.Enabled = true;
						AccuracyLabel.Enabled = true;
						ProjectileAccuracyProgressBar.Enabled = true;
					}
					else
					{
						AccuracyLabelLabel.Enabled = false;
						AccuracyLabel.Enabled = false;
						ProjectileAccuracyProgressBar.Enabled = false;
					}
					Object1BearingTextBox.Text = Ship1.BearingDegrees.ToString() + "°";
				}
				else if (_object1 is Probe)
				{
					Object1KillsNumericUpDown.Value = ((Probe)_object1).Kills;
				}

				TimeToKillTextBox.Text = "Infinity";
				KBTextBox.Text = _object1.GetKillBonus().ToString();
			}

			if (_object1 != null && _object2 != null)
			{
				DetectionRange = _object1.CalculateScanrange() * _object2.CalculateSignature();
				DetectionRange += _object1.DetectionScale();
				DetectionRange += _object2.DetectionScale();

				DetectedRange = _object2.CalculateScanrange() * _object1.CalculateSignature();
				DetectedRange += _object2.DetectionScale();
				DetectedRange += _object1.DetectionScale();

				Comp = new Comparison(_object1, _object1.GetKillBonus(), ProjectileAccuracyProgressBar.Value, LaunchSpeed, _object2);
				NumMissilesTextBox.Text = Comp.MissilesUsed.ToString();
				float AmmoUsed = Comp.AmmoUsed;
				if (_object1 is Probe)
					AmmoUsed = (((Probe)_object1).IGCProbe.AmmoCapacity > 0) ? AmmoUsed / ((Probe)_object1).IGCProbe.AmmoCapacity : 0F;
				if (_object1 is Ship)
					AmmoUsed = (((Ship)_object1).IGCShip.AmmoCapacity > 0) ? AmmoUsed / ((Ship)_object1).IGCShip.AmmoCapacity : 0F;
				NumAmmoClipsTextBox.Text = Math.Round(AmmoUsed, 2).ToString();

				float EnergyUsed = Comp.EnergyUsed;
				if (_object1 is Ship)
					EnergyUsed = (((Ship)_object1).IGCShip.Energy > 0) ? EnergyUsed / ((Ship)_object1).IGCShip.Energy : 0;
				NumBatteriesTextBox.Text = Math.Round(EnergyUsed, 2).ToString();
				RangeTextBox.Text = Math.Round(Comp.Range, 1).ToString();
				TimeToKillTextBox.Text = Math.Round(Comp.TimeToKill, 2).ToString();
			}

			if (_object2 == null)
			{
				Comp = new Comparison(_object1, _object1.GetKillBonus(), ProjectileAccuracyProgressBar.Value, LaunchSpeed);
				RangeTextBox.Text = Math.Round(Comp.Range, 1).ToString();
			}
			if (_object2 != null)
				HitpointsTextBox.Text = (_object2.CalculateHullHitpoints() + _object2.CalculateShieldHitpoints()).ToString();

			DetectionRangeTextBox.Text = Math.Round(DetectionRange, 1).ToString();
			DetectedRangeTextBox.Text = Math.Round(DetectedRange, 1).ToString();

			if (_selectedShip != null)
				ShowParts(_selectedShip);
		}

		private void UpdateObjects ()
		{
			AccuracyLabelLabel.Enabled = false;
			AccuracyLabel.Enabled = false;
			ProjectileAccuracyProgressBar.Enabled = false;
			if (_object1 == null)
			{
				Object1Label.ForeColor = Color.FromArgb(255, 255, 192);
				Object1Label.BackColor = Color.FromArgb(64, 0, 0);
				Object1Label.Text = "<Drag an object here!>";
				Object1DetailsButton.Enabled = false;
				Object1DetailsButton.Visible = false;
				Object1BearingLabel.Enabled = false;
				Object1BearingTextBox.Enabled = false;
				Object1BearingLabel.Visible = false;
				Object1BearingTextBox.Visible = false;
				Object1BearingTextBox.Text = "0°";
			}
			else
			{
				Object1Label.BackColor = _object1.Team.TeamColor;
				Object1Label.ForeColor = Color.Black;
				if (_object1 is Ship)
				{
					Ship Ship1 = (Ship)_object1;
					Object1DetailsButton.Enabled = true;
					Object1DetailsButton.Visible = true;
					Object1BearingLabel.Enabled = true;
					Object1BearingTextBox.Enabled = true;
					Object1BearingLabel.Visible = true;
					Object1BearingTextBox.Visible = true;
					Object1BearingTextBox.Text = Ship1.BearingDegrees.ToString() + "°";
				}
				else
				{
					Object1DetailsButton.Enabled = false;
					Object1DetailsButton.Visible = false;
					Object1BearingLabel.Enabled = false;
					Object1BearingTextBox.Enabled = false;
					Object1BearingLabel.Visible = false;
					Object1BearingTextBox.Visible = false;
					Object1BearingTextBox.Text = "0°";
				}
			
				if (_object1 is Ship || _object1 is Probe)
				{
					if (_object1 is Ship)
						Object1KillsNumericUpDown.Value = ((Ship)_object1).Kills;
					else
						Object1KillsNumericUpDown.Value = ((Probe)_object1).Kills;

					KBLabel.Visible = true;
					KillsLabel.Visible = true;
					Object1KillsNumericUpDown.Visible = true;
					KBTextBox.Visible = true;
					RangeLabel.Enabled = true;
					RangeTextBox.Enabled = true;
					TimeToKillLabel.Enabled = true;
					TimeToKillTextBox.Enabled = true;
					NumClipsLabel.Enabled = true;
					NumClipsLabel.Visible = true;
					NumMissilesLabel.Enabled = true;
					NumMissilesTextBox.Enabled = true;
					NumBatteriesLabel.Enabled = true;
					NumBatteriesTextBox.Enabled = true;
				}
				else
				{
					KBLabel.Visible = false;
					KillsLabel.Visible = false;
					Object1KillsNumericUpDown.Visible = false;
					KBTextBox.Visible = false;
					RangeLabel.Enabled = false;
					RangeTextBox.Enabled = false;
					TimeToKillLabel.Enabled = false;
					TimeToKillTextBox.Enabled = false;
					NumClipsLabel.Enabled = false;
					NumClipsLabel.Visible = false;
					NumMissilesLabel.Enabled = false;
					NumMissilesTextBox.Enabled = false;
					NumBatteriesLabel.Enabled = false;
					NumBatteriesTextBox.Enabled = false;
				}

				if (_game.Me == _object1)
				{
					Object1LabelLabel.Text = "Me:";
					Object1Label.Left = 23;
					Object1SeesObject2Label.Text = "I see ";
					Object2SeesObject1Label.Text = " sees Me:";
				}
				else
				{
					Object1LabelLabel.Text = "1:";
					Object1Label.Left = 14;
					Object1SeesObject2Label.Text = "1 sees ";
					Object2SeesObject1Label.Text = " sees 1:";
				}

				Object1Label.Text = _object1.ToString();
			}

			if (_object2 == null)
			{
				Object2Label.ForeColor = Color.FromArgb(255, 255, 192);
				Object2Label.BackColor = Color.FromArgb(64, 0, 0);
				Object2Label.Text = "<Drag an object here!>";
				Object2DetailsButton.Enabled = false;
				Object2DetailsButton.Visible = false;
				Object2BearingLabel.Enabled = false;
				Object2BearingTextBox.Enabled = false;
				Object2BearingLabel.Visible = false;
				Object2BearingTextBox.Visible = false;
				Object2BearingTextBox.Text = "0°";
				HitpointsLabel.Visible = false;
				HitpointsLabel.Enabled = false;
				HitpointsTextBox.Visible = false;
				HitpointsTextBox.Enabled = false;
			}
			else
			{
				Object2Label.BackColor = _object2.Team.TeamColor;
				Object2Label.ForeColor = Color.Black;
				HitpointsLabel.Visible = true;
				HitpointsLabel.Enabled = true;
				HitpointsTextBox.Visible = true;
				HitpointsTextBox.Enabled = true;
				if (_object2 is Ship)
				{
				
					Object2DetailsButton.Enabled = true;
					Object2DetailsButton.Visible = true;
					Object2BearingLabel.Enabled = true;
					Object2BearingTextBox.Enabled = true;
					Object2BearingLabel.Visible = true;
					Object2BearingTextBox.Visible = true;
					Object2BearingTextBox.Text = ((Ship)_object2).BearingDegrees.ToString() + "°";
				}
				else
				{
					Object2DetailsButton.Enabled = false;
					Object2DetailsButton.Visible = false;
					Object2BearingLabel.Enabled = false;
					Object2BearingTextBox.Enabled = false;
					Object2BearingLabel.Visible = false;
					Object2BearingTextBox.Visible = false;
					Object2BearingTextBox.Text = "0°";
				}

				if (_game.Target == _object2)
				{
					Object2LabelLabel.Text = "T:";
					Object1SeesObject2Label.Text += "T:";
					Object2SeesObject1Label.Text = "T" + Object2SeesObject1Label.Text;
				}
				else
				{
					Object2LabelLabel.Text = "2:";
					Object1SeesObject2Label.Text += "2:";
					Object2SeesObject1Label.Text = "2" + Object2SeesObject1Label.Text;
				}
				Object2Label.Text = _object2.ToString();
			}
			UpdateComparison();
		}

		private void ShowParts (Ship ship)
		{
			if (ship == _object1)
				Object1Label.ForeColor = Color.Red;
			if (ship == _object2)
				Object2Label.ForeColor = Color.Red;

			CargoPanel.Enabled = true;
			string NoneString = "<None>";

			if (ship.CanUseSlot(ShipSlots.Weapon1))
			{
				WeaponSlot1Panel.Enabled = true;
				
				UseWeapon1CheckBox.Checked = false;
				if (ship.Weapons[0] != null)
				{
					Wep1TextBox.Text = ship.Weapons[0].Name;
					if (ship.FireWeapons == true && (ship.WeaponToFire == 0 || ship.WeaponToFire == -1))
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

			if (ship.CanUseSlot(ShipSlots.Weapon2))
			{
				WeaponSlot2Panel.Enabled = true;
				
				UseWeapon2CheckBox.Checked = false;
				if (ship.Weapons[1] != null)
				{
					Wep2TextBox.Text = ship.Weapons[1].Name;
					if (ship.FireWeapons == true && (ship.WeaponToFire == 1 || ship.WeaponToFire == -1))
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

			if (ship.CanUseSlot(ShipSlots.Weapon3))
			{
				WeaponSlot3Panel.Enabled = true;
				UseWeapon3CheckBox.Checked = false;
				if (ship.Weapons[2] != null)
				{
					Wep3TextBox.Text = ship.Weapons[2].Name;
					if (ship.FireWeapons == true && (ship.WeaponToFire == 2 || ship.WeaponToFire == -1))
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

			if (ship.CanUseSlot(ShipSlots.Weapon4))
			{
				WeaponSlot4Panel.Enabled = true;
				UseWeapon4CheckBox.Checked = false;
				if (ship.Weapons[3] != null)
				{
					Wep4TextBox.Text = ship.Weapons[3].Name;
					if (ship.FireWeapons == true && (ship.WeaponToFire == 3 || ship.WeaponToFire == -1))
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
			//UseWeaponsCheckBox.Checked = ship.FireWeapons;

			UseTurr1CheckBox.Checked = ship.FireTurrets[0];
			if (ship.CanUseSlot(ShipSlots.Turret1))
			{
				TurretSlot1Panel.Enabled = true;
				if (ship.Turrets[0] != null)
				{
					Turr1TextBox.Text = ship.Turrets[0].Name;
					UseTurr1CheckBox.Checked = ship.FireTurrets[0];
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

			UseTurr2CheckBox.Checked = ship.FireTurrets[1];
			if (ship.CanUseSlot(ShipSlots.Turret2))
			{
				TurretSlot2Panel.Enabled = true;
				if (ship.Turrets[1] != null)
				{
					Turr2TextBox.Text = ship.Turrets[1].Name;
					UseTurr2CheckBox.Checked = ship.FireTurrets[1];
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

			UseTurr3CheckBox.Checked = ship.FireTurrets[2];
			if (ship.CanUseSlot(ShipSlots.Turret3))
			{
				TurretSlot3Panel.Enabled = true;
				if (ship.Turrets[2] != null)
				{
					Turr3TextBox.Text = ship.Turrets[2].Name;
					UseTurr3CheckBox.Checked = ship.FireTurrets[2];
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

			UseTurr4CheckBox.Checked = ship.FireTurrets[3];
			if (ship.CanUseSlot(ShipSlots.Turret4))
			{
				TurretSlot4Panel.Enabled = true;
				if (ship.Turrets[3] != null)
				{
					Turr4TextBox.Text = ship.Turrets[3].Name;
					UseTurr4CheckBox.Checked = ship.FireTurrets[3];
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
			
			UseMissileCheckBox.Checked = ship.FireMissile;
			if (ship.CanUseSlot(ShipSlots.Missile))
			{
				MissilePanel.Enabled = true;
				if (ship.Missile != null)
					MissileTextBox.Text = ship.Missile.Name;
				else
					MissileTextBox.Text = NoneString;
			}
			else
			{
				UseMissileCheckBox.Checked = false;
				MissileTextBox.Text = NoneString;
				MissilePanel.Enabled = false;
			}

			UseBoosterCheckBox.Checked = ship.FireBooster;
			if (ship.CanUseSlot(ShipSlots.Booster))
			{
				BoosterPanel.Enabled = true;
				if (ship.Booster != null)
					BoosterTextBox.Text = ship.Booster.Name;
				else
					BoosterTextBox.Text = NoneString;
			}
			else
			{
				UseBoosterCheckBox.Checked = false;
				BoosterPanel.Enabled = false;
				BoosterTextBox.Text = NoneString;
			}

			if (ship.CanUseSlot(ShipSlots.Shield))
			{
				ShieldPanel.Enabled = true;
				if (ship.Shield != null)
					ShieldTextBox.Text = ship.Shield.Name;
				else
					ShieldTextBox.Text = NoneString;
			}
			else
			{
				ShieldPanel.Enabled = false;
				ShieldTextBox.Text = NoneString;
			}
			
			UseCloakCheckBox.Checked = ship.UseCloak;
			if (ship.CanUseSlot(ShipSlots.Cloak))
			{
				CloakPanel.Enabled = true;
				if (ship.Cloak != null)
					CloakTextBox.Text = ship.Cloak.Name;
				else
					CloakTextBox.Text = NoneString;
			}
			else
			{
				UseCloakCheckBox.Checked = false;
				CloakPanel.Enabled = false;
				CloakTextBox.Text = NoneString;
			}
		}

		private void ShowObject1Details ()
		{
			Object1Label.Font = new Font(Object1Label.Font.FontFamily, Object1Label.Font.Size, FontStyle.Bold);
			ShowParts((Ship)_object1);
			if (this.ClientSize.Height != EXPANDEDSIZE)
				this.ClientSize = new Size(this.ClientSize.Width, EXPANDEDSIZE);
		}

		private void HideObject1Details ()
		{
			if (_object1 == null)
				Object1Label.ForeColor = Color.FromArgb(255, 255, 192);
			else
				Object1Label.ForeColor = Color.Black;
			Object1Label.Font = new Font(Object1Label.Font.FontFamily, Object1Label.Font.Size, FontStyle.Regular);
			if (_selectedShip == null)
				this.ClientSize = new Size(this.ClientSize.Width, COLLAPSEDSIZE);
		}

		private void ShowObject2Details ()
		{
			Object2Label.Font = new Font(Object2Label.Font.FontFamily, Object2Label.Font.Size, FontStyle.Bold);
			ShowParts((Ship)_object2);
			if (this.ClientSize.Height != EXPANDEDSIZE)
				this.ClientSize = new Size(this.ClientSize.Width, EXPANDEDSIZE);
		}

		private void HideObject2Details ()
		{
			if (_object2 == null)
				Object2Label.ForeColor = Color.FromArgb(255, 255, 192);
			else
				Object2Label.ForeColor = Color.Black;

			Object2Label.Font = new Font(Object2Label.Font.FontFamily, Object2Label.Font.Size, FontStyle.Regular);
			if (_selectedShip == null)
				this.ClientSize = new Size(this.ClientSize.Width, COLLAPSEDSIZE);
		}

		private void Object1DetailsButton_Click (object sender, System.EventArgs e)
		{
			if (_selectedShip == _object1)
			{
				_selectedShip = null;
				HideObject1Details();
				HideObject2Details();
			} 
			else 
			{
				_selectedShip = (Ship)_object1;
				HideObject2Details();
				ShowObject1Details();
			}
		}

		private void Object2DetailsButton_Click (object sender, System.EventArgs e)
		{
			if (_selectedShip == _object2)
			{
				_selectedShip = null;
				HideObject1Details();
				HideObject2Details();
			} 
			else 
			{
				_selectedShip = (Ship)_object2;
				HideObject1Details();
				ShowObject2Details();
			}
		}

		private void AccuracyProgressBar_MouseMove (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgressBar Bar = (ProgressBar)sender;
				int CalcValue = (e.X * 100) / Bar.Width;
				if (CalcValue > 100)
					CalcValue = 100;
				if (CalcValue < 1)
					CalcValue = 1;
				Bar.Value = CalcValue;
				AccuracyLabel.Text = Bar.Value.ToString() + "%";
				UpdateComparison();
			}
		}

		private void AccuracyProgressBar_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ProgressBar Bar = (ProgressBar)sender;
				int CalcValue = (e.X * 100) / Bar.Width;
				if (CalcValue > 100)
					CalcValue = 100;
				if (CalcValue < 1)
					CalcValue = 1;
				Bar.Value = CalcValue;
				AccuracyLabel.Text = Bar.Value.ToString() + "%";

				UpdateComparison();
			}
		}

		private void ComparisonForm_Load (object sender, System.EventArgs e)
		{
			if (Screen.AllScreens.Length == 1)
				this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
		}

		

		private void ComparisonForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_game.MeChanged -= new EventHandler(MeChangedHandler);
			_game.TargetChanged -= new EventHandler(TargetChangedHandler);

			if (_object1 != null)
			{
				_object1.Updated -= new EventHandler(Object1ChangedHandler);
				_object1.Closed -= new EventHandler(Object1ClosedHandler);
				_object1 = null;
			}
			if (_object2 != null)
			{
				_object2.Updated -= new EventHandler(Object2ChangedHandler);
				_object2.Closed -= new EventHandler(Object2ClosedHandler);
				_object2 = null;
			}
			_game.Comparisons.Remove(this);
			this.Dispose();
		}

		private void BearingTextBox_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TextBox Sender = (TextBox)sender;
			if (Sender.Enabled == false)
				return;

			AngleChooser Chooser = null;
			Ship ShipObj = null;

			if (Sender == Object1BearingTextBox)
			{
				ShipObj = (Ship)_object1;
				Chooser = _chooser1;
			}
			else
			{
				ShipObj = (Ship)_object2;
				Chooser = _chooser2;
			}

			if (Chooser == null)
			{
				Chooser = new AngleChooser(ShipObj, Sender);
				if (Sender == Object1BearingTextBox)
					_chooser1 = Chooser;
				else
					_chooser2 = Chooser;

				this.Controls.Add(Chooser);
				Chooser.Left = Sender.Left + Sender.Width;
				Chooser.Top = (Sender.Parent.Top + Sender.Top + Sender.Height) - Chooser.Height;;
				Chooser.Show();
				Chooser.BringToFront();
			}
			else
			{
				Chooser.Hide();
				this.Controls.Remove(Chooser);
				Chooser.Dispose();
				if (Sender == Object1BearingTextBox)
					_chooser1 = null;
				else
					_chooser2 = null;

			}
		}

		private void BearingTextBox_KeyUp (object sender, System.Windows.Forms.KeyEventArgs e)
		{
			TextBox Sender = (TextBox)sender;
			try
			{
				string BearingText = Sender.Text;
				if (BearingText.EndsWith("°"))
					BearingText = BearingText.TrimEnd(new char[1]{'°'});

				int Value = int.Parse(BearingText);
				if (Value > 360)
					Value = 360;
				if (Value < 0)
					Value = 0;

				if (Sender == Object1BearingTextBox)
					((Ship)_object1).BearingDegrees = Value;
				else
					((Ship)_object2).BearingDegrees = Value;
			}
			catch (Exception)
			{
				return;
			}
		}

		private void UseTurretCheckBox_Clicked (object sender, System.EventArgs e)
		{
			CheckBox Sender = (CheckBox)sender;
			_selectedShip.FireTurrets[int.Parse(Sender.Tag.ToString())] = Sender.Checked;
			_selectedShip.Update();
		}

		private void UseMissileCheckBox_Clicked(object sender, System.EventArgs e)
		{
			_selectedShip.FireMissile = UseMissileCheckBox.Checked;
		}

		private void UseBoosterCheckBox_Clicked(object sender, System.EventArgs e)
		{
			_selectedShip.FireBooster = UseBoosterCheckBox.Checked;
		}

		private void UseCloakCheckBox_Clicked(object sender, System.EventArgs e)
		{
			_selectedShip.UseCloak = UseCloakCheckBox.Checked;
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

			BitArray CurrentDefs = _selectedShip.Team.CalculateDefs();
			foreach (IGCCorePart Part in _game.Core.Parts)
			{
				if (!_settings.ShowOverridden)
				{
					short OverridingID = Part.OverridingUID;
					if (OverridingID > -1)
					{
						IGCCorePart OverridingPart = _selectedShip.GetOverriddenPart((ushort)OverridingID);
						if (OverridingPart != null)
						{
							BitArray WorkingDefs = (BitArray)CurrentDefs.Clone();
							WorkingDefs.And(OverridingPart.Techtree.Pres);
							if (OverridingPart.Techtree.PreEquals(WorkingDefs))
								continue;
						}
					}
				}
				if (_selectedShip.CanMountPart(Part, (ShipSlots)SlotIndex))
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

			if (SlotIndex < 8)
			{
				if (SlotIndex < 4)
					_selectedShip.Weapons[SlotIndex] = (IGCCorePartWeapon)Part;
				else
					_selectedShip.Turrets[SlotIndex - 4] = (IGCCorePartWeapon)Part;

				_selectedShip.Update();
			}
			else
			{
				if (SlotIndex < 16)
				{
					switch (SlotIndex)
					{
						case 8:
							_selectedShip.Chaff = (IGCCoreCounter)Part;
							break;
						case 10:
							_selectedShip.Missile = (IGCCoreMissile)Part;
							break;
						case 11:
							_selectedShip.Pack = Part;
							break;
						case 12:
							_selectedShip.Shield = (IGCCorePartShield)Part;
							break;
						case 13:
							_selectedShip.Cloak = (IGCCorePartCloak)Part;
							break;
						case 15:
							_selectedShip.Booster = (IGCCorePartAfterburner)Part;
							break;
						default:
							break;
					}
				}
			}
		}

		private void Object1KillsNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			NumericUpDown Sender = (NumericUpDown)sender;
			if (_object1 is Ship)
				((Ship)_object1).Kills = (int)Sender.Value;
			if (_object1 is Probe)
				((Probe)_object1).Kills = (int)Sender.Value;

			_object1.Update();
		}

		private void UseWeaponCheckBox_Click (object sender, System.EventArgs e)
		{
			CheckBox Sender = (CheckBox)sender;
			if (_selectedShip.FireWeapons == false)
			{	// Fire All
				_selectedShip.WeaponToFire = -1;
				_selectedShip.FireWeapons = true;
			}
			else
			{	// I'm already firing...
				if (_selectedShip.GetWeaponCount() > 1)
				{
					if (_selectedShip.WeaponToFire == -1)
					{	// Fire Single
						_selectedShip.WeaponToFire = int.Parse(Sender.Tag.ToString());
						_selectedShip.FireWeapons = true;
					}
					else
					{	
						if (_selectedShip.WeaponToFire.ToString().Equals(Sender.Tag.ToString()))
						{	// Disable guns
							_selectedShip.WeaponToFire = -1;
							Sender.Checked = false;
							_selectedShip.FireWeapons = false;
						}
						else
						{	// Set gun
							_selectedShip.WeaponToFire = int.Parse(Sender.Tag.ToString());
							_selectedShip.Update();
						}
					}
				}
				else
				{
					_selectedShip.FireWeapons = false;
				}
			}
		}

		private void Object2Label_DragOver (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			AllegObject DroppedObject = null;
			if (DroppedIndex == -2)
				DroppedObject = _game.Target;
			else if (DroppedIndex == -1)
				DroppedObject = _game.Me;
			else
				DroppedObject = ((MainForm)MainForm.ActiveForm).SelectedObject();

			if (DroppedObject != null && !(_object1 == _game.Me && _object2 == _game.Target))
				e.Effect = DragDropEffects.Link;
		}

		private void Object2Label_DragDrop (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			AllegObject DroppedObject = null;
			if (DroppedIndex == -2)
				DroppedObject = _game.Target;
			else if (DroppedIndex == -1)
				DroppedObject = _game.Me;
			else
				DroppedObject = ((MainForm)MainForm.ActiveForm).SelectedObject();

			this.Object2 = DroppedObject;
//			bool WasSelected = false;
//			if (_object2 != null)
//			{
//				if (_selectedShip == _object2)
//					WasSelected = true;
//				_object2.Updated -= new EventHandler(Object2ChangedHandler);
//				_object2.Closed -= new EventHandler(Object2ClosedHandler);
//			}
//			_object2 = DroppedObject;
//			_object2.Updated += new EventHandler(Object2ChangedHandler);
//			_object2.Closed += new EventHandler(Object2ClosedHandler);
//			_object2.Team.OpenObjects.Add(_object2);
//
//			Object2Label.BackColor = _object2.Team.TeamColor;
//			if (WasSelected == true)
//			{
//				_selectedShip = (Ship)_object2;
//				ShowParts(_selectedShip);
//			}
//			else
//			{
//				Object2Label.ForeColor = Color.Black;
//			}
//			UpdateObjects();
		}

		private void Object1Label_DragOver (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			AllegObject DroppedObject = null;
			if (DroppedIndex == -2)
				DroppedObject = _game.Target;
			else if (DroppedIndex == -1)
				DroppedObject = _game.Me;
			else
				DroppedObject = ((MainForm)MainForm.ActiveForm).SelectedObject();

			if (DroppedObject != null)
				e.Effect = DragDropEffects.Link;
		}

		private void Object1Label_DragDrop (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			AllegObject DroppedObject = null;
			if (DroppedIndex == -1)
				DroppedObject = _game.Me;
			else
				DroppedObject = ((MainForm)MainForm.ActiveForm).SelectedObject();

			this.Object1 = DroppedObject;
//			bool WasSelected = false;
//			if (_object1 != null)
//			{
//				if (_selectedShip == _object1)
//					WasSelected = true;
//				_object1.Updated -= new EventHandler(Object1ChangedHandler);
//				_object1.Closed -= new EventHandler(Object1ClosedHandler);
//			}
//
//			_object1 = DroppedObject;
//			_object1.Updated += new EventHandler(Object1ChangedHandler);
//			_object1.Closed += new EventHandler(Object1ClosedHandler);
//
//			_object1.Team.OpenObjects.Add(_object1);
//			Object1Label.BackColor = _object1.Team.TeamColor;
//			if (WasSelected == true)
//			{
//				_selectedShip = (Ship)_object1;
//				ShowParts(_selectedShip);
//			}
//			else
//			{
//				Object1Label.ForeColor = Color.Black;
//			}
//			UpdateObjects();
		}

		private void Object1Label_DoubleClick (object sender, System.EventArgs e)
		{
			if (_object1 == null)
				return;

			ObjectForm ObjForm = null;
			if (_object1 is Ship)
				ObjForm = new ShipForm(_settings, (Ship)_object1, _object2);
			if (_object1 is Probe)
				ObjForm = new ProbeForm(_settings, (Probe)_object1);
			if (_object1 is Station)
				ObjForm = new StationForm(_settings, (Station)_object1);

			if (ObjForm != null)
				ObjForm.Show();
		}

		private void Object2Label_DoubleClick (object sender, System.EventArgs e)
		{
			if (_object2 == null)
				return;

			ObjectForm ObjForm = null;
			if (_object2 is Ship)
				ObjForm = new ShipForm(_settings, (Ship)_object2);
			if (_object2 is Probe)
				ObjForm = new ProbeForm(_settings, (Probe)_object2);
			if (_object2 is Station)
				ObjForm = new StationForm(_settings, (Station)_object2);

			if (ObjForm != null)
				ObjForm.Show();
		}

		private void ComparisonTimer_Tick (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.ComparisonHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>These values update as weapons are fired</b>\r\n<hr=100%>\r\nIt takes an infinite time to kill a target if you're\r\nnot firing any weapons!!\r\n\r\nExpand the ship's cargo below, and choose\r\nwhich weapons to fire. These values are\r\naccurate to the weapons you've choosen";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, TimeToKillTextBox, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.ComparisonHelpShown = true;
			}
		}

		private void ProjectileAccuracyProgressBar_MouseEnter(object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.AccuracyHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Set Direct-Damage weapons' accuracy</b>\r\n<hr=100%>\r\nThis slider allows you to set how accurate\r\nyour direct-damage weapons are.\r\n\r\nThis does not affect missiles or area-effect\r\nweapons since area-effect weapons deal\r\ndamage even if your shots miss";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, ProjectileAccuracyProgressBar, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.AccuracyHelpShown = true;
			}
		}

		private void ObjectLabel_MouseEnter(object sender, System.EventArgs e)
		{
			Control Sender = (Control)sender;
			if (_settings.ShowBalloonHelp == true && !(_object1 == _game.Me && _object2 == _game.Target) && HelpBalloon.ObjectLabelHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Drag objects here to change the comparison</b>\r\n<hr=100%>\r\nDrag another object from the Object list on the\r\nmain window onto these words to reset the\r\ncurrent comparison.\r\n\r\nYou can also doubleclick these words to open\r\nup its Info screen";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, Sender, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.ObjectLabelHelpShown = true;
			}
		}

		private void LaunchSpeedTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				float Whatever = float.Parse(LaunchSpeedTextBox.Text);
			}
			catch (Exception)
			{
				LaunchSpeedTextBox.Text = "0";
			}
			_object1.Update();
		}

		private void LaunchSpeedTextBox_MouseEnter(object sender, System.EventArgs e)
		{
			Control Sender = (Control)sender;
			if (_settings.ShowBalloonHelp == true && HelpBalloon.LaunchSpeedHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Set your ship's speed here</b>\r\n<hr=100%>\r\nLaunching missiles at higher speeds\r\nmakes them travel further.\r\n\r\nSet the speed that your ship is\r\ntravelling when you pull the trigger";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, Sender, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.LaunchSpeedHelpShown = true;
			}
		}

		private void ComparisonForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_chooser1 != null)
			{
				_chooser1.Hide();
				this.Controls.Remove(_chooser1);
				_chooser1.Dispose();
				_chooser1 = null;
			}

			if (_chooser2 != null)
			{
				_chooser2.Hide();
				this.Controls.Remove(_chooser2);
				_chooser2.Dispose();
				_chooser2 = null;
			}
		}

		public AllegObject Object1
		{
			get {return _object1;}
			set
			{
				if (_object1 != null)
				{
					_object1.Updated -= new EventHandler(Object1ChangedHandler);
					_object1.Closed -= new EventHandler(Object1ClosedHandler);
				}
				
				if (_selectedShip == _object1)
				{
					if (value is Ship)
					{
						_selectedShip = (Ship)value;
					}
					else
					{
						_selectedShip = null;
						HideObject1Details();
					}
				}

				_object1 = value;
				if (value != null)
				{
					_object1.Updated += new EventHandler(Object1ChangedHandler);
					_object1.Closed += new EventHandler(Object1ClosedHandler);
					if (!_object1.Team.OpenObjects.Contains(_object1))
						_object1.Team.OpenObjects.Add(_object1);
					UpdateObjects();
				}
			}
		}
		
		public AllegObject Object2
		{
			get {return _object2;}
			set
			{
				if (_object2 != null)
				{
					_object2.Updated -= new EventHandler(Object2ChangedHandler);
					_object2.Closed -= new EventHandler(Object2ClosedHandler);
				}

				if (_selectedShip == _object2)
				{
					if (value is Ship)
					{
						_selectedShip = (Ship)value;
					}
					else
					{
						_selectedShip = null;
						HideObject2Details();
					}
				}

				_object2 = value;
				if (value != null)
				{
					_object2.Updated += new EventHandler(Object2ChangedHandler);
					_object2.Closed += new EventHandler(Object2ClosedHandler);
					if (!_object2.Team.OpenObjects.Contains(_object2))
						_object2.Team.OpenObjects.Add(_object2);
					UpdateObjects();
				}
			}
		}

		public AngleChooser Chooser1
		{
			get {return _chooser1;}
			set {_chooser1 = value;}
		}

		public AngleChooser Chooser2
		{
			get {return _chooser2;}
			set {_chooser2 = value;}
		}
	}
}
