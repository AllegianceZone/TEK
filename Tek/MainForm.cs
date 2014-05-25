using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;
//using Balloon.NET;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// The Main Form that gives access to all of the Kneeboard functions
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.Windows.Forms.Button ConstantsButton;
		private System.Windows.Forms.Button DamageIndicesButton;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel TeamsPanel;
		private System.Windows.Forms.RadioButton ResearchRadioButton;
		private System.Windows.Forms.RadioButton ObjectsRadioButton;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Panel MorePanel;
		private System.Windows.Forms.ContextMenu ChangeFactionContextMenu;
		private System.Windows.Forms.Panel ResearchPanel;
		private System.Windows.Forms.CheckedListBox ResearchCheckedListBox;
		private System.Windows.Forms.Button ResearchNoneButton;
		private System.Windows.Forms.Button ResearchAllButton;
		private System.Windows.Forms.Button ResearchMK2Button;
		private System.Windows.Forms.Button ResearchMK1Button;
		private System.Windows.Forms.Panel TechPanel;
		private System.Windows.Forms.Label ExpansionLabel;
		private System.Windows.Forms.Label ConstructionLabel;
		private System.Windows.Forms.Label TacticalLabel;
		private System.Windows.Forms.Label ShipyardLabel;
		private System.Windows.Forms.Label SupremacyLabel;
		private System.Windows.Forms.Label GarrisonLabel;
		private System.Windows.Forms.Panel DevelopmentsPanel;
		private System.Windows.Forms.Panel QuickDevelPanel;
		private System.Windows.Forms.Panel ObjectBrowserPanel;
		private System.Windows.Forms.ListBox ObjectsListBox;
		private System.Windows.Forms.Panel MePanel;
		private System.Windows.Forms.TextBox MeTextBox;
		private System.Windows.Forms.Label MeLabel;
		private System.Windows.Forms.MenuItem DetailsMenuItem;
		private System.Windows.Forms.Panel ObjectTypePanel;
		private System.Windows.Forms.RadioButton ProbeRadioButton;
		private System.Windows.Forms.RadioButton StationRadioButton;
		private System.Windows.Forms.RadioButton ShipRadioButton;
		private System.Windows.Forms.Panel TargetPanel;
		private System.Windows.Forms.TextBox TargetTextBox;
		private System.Windows.Forms.Label TargetLabel;
		private System.Windows.Forms.Button NewGameButton;
		private System.Windows.Forms.Button OptionsButton;
		private System.Windows.Forms.ImageList IconImageList;
		private System.Windows.Forms.Label ResearchCostLabel;
		private System.Windows.Forms.Button CompareMeButton;
		private System.Windows.Forms.RadioButton Team1RadioButton;
		private System.Windows.Forms.RadioButton Team2RadioButton;
		private System.Windows.Forms.RadioButton Team3RadioButton;
		private System.Windows.Forms.RadioButton Team4RadioButton;
		private System.Windows.Forms.RadioButton Team5RadioButton;
		private System.Windows.Forms.RadioButton Team6RadioButton;
		private System.Windows.Forms.ContextMenu ObjectsListBoxContextMenu;
		private System.Windows.Forms.MenuItem ObjectInfoMenuItem;
		private System.Windows.Forms.MenuItem SetMeMenuItem;
		private System.Windows.Forms.MenuItem SetTargetMenuItem;
		private System.Windows.Forms.MenuItem Separator1MenuItem;
		private System.Windows.Forms.MenuItem CompareToMenuItem;
		private System.Windows.Forms.Label TotalCostLabel;
		#endregion
		private System.Windows.Forms.Timer TeamBalloonTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer ResearchCostTimer;

		const string ALLEGIANCEKEY = @"SOFTWARE\Microsoft\Microsoft Games\Allegiance\1.0";

		string			_settingsPath = string.Empty;
		string			_corePath = string.Empty;
		Game			_game = null;
		TekSettings		_settings = null;

		Team			_selectedTeam = null;
		TreeRoot		_selectedTech = TreeRoot.Construction;

		public MainForm ()
		{
			InitializeComponent();
			LoadSettings();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ResearchNoneButton = new System.Windows.Forms.Button();
			this.ResearchAllButton = new System.Windows.Forms.Button();
			this.ResearchMK2Button = new System.Windows.Forms.Button();
			this.ResearchMK1Button = new System.Windows.Forms.Button();
			this.CompareMeButton = new System.Windows.Forms.Button();
			this.ExpansionLabel = new System.Windows.Forms.Label();
			this.IconImageList = new System.Windows.Forms.ImageList(this.components);
			this.ConstructionLabel = new System.Windows.Forms.Label();
			this.TacticalLabel = new System.Windows.Forms.Label();
			this.ShipyardLabel = new System.Windows.Forms.Label();
			this.SupremacyLabel = new System.Windows.Forms.Label();
			this.GarrisonLabel = new System.Windows.Forms.Label();
			this.TotalCostLabel = new System.Windows.Forms.Label();
			this.ResearchCostLabel = new System.Windows.Forms.Label();
			this.ProbeRadioButton = new System.Windows.Forms.RadioButton();
			this.StationRadioButton = new System.Windows.Forms.RadioButton();
			this.ShipRadioButton = new System.Windows.Forms.RadioButton();
			this.TargetTextBox = new System.Windows.Forms.TextBox();
			this.TargetLabel = new System.Windows.Forms.Label();
			this.MeTextBox = new System.Windows.Forms.TextBox();
			this.MeLabel = new System.Windows.Forms.Label();
			this.Team1RadioButton = new System.Windows.Forms.RadioButton();
			this.ChangeFactionContextMenu = new System.Windows.Forms.ContextMenu();
			this.Team2RadioButton = new System.Windows.Forms.RadioButton();
			this.Team3RadioButton = new System.Windows.Forms.RadioButton();
			this.Team4RadioButton = new System.Windows.Forms.RadioButton();
			this.Team5RadioButton = new System.Windows.Forms.RadioButton();
			this.Team6RadioButton = new System.Windows.Forms.RadioButton();
			this.ConstantsButton = new System.Windows.Forms.Button();
			this.DamageIndicesButton = new System.Windows.Forms.Button();
			this.TeamsPanel = new System.Windows.Forms.Panel();
			this.MorePanel = new System.Windows.Forms.Panel();
			this.ObjectBrowserPanel = new System.Windows.Forms.Panel();
			this.MePanel = new System.Windows.Forms.Panel();
			this.TargetPanel = new System.Windows.Forms.Panel();
			this.ObjectsListBox = new System.Windows.Forms.ListBox();
			this.ObjectsListBoxContextMenu = new System.Windows.Forms.ContextMenu();
			this.CompareToMenuItem = new System.Windows.Forms.MenuItem();
			this.ObjectInfoMenuItem = new System.Windows.Forms.MenuItem();
			this.Separator1MenuItem = new System.Windows.Forms.MenuItem();
			this.SetMeMenuItem = new System.Windows.Forms.MenuItem();
			this.SetTargetMenuItem = new System.Windows.Forms.MenuItem();
			this.ObjectTypePanel = new System.Windows.Forms.Panel();
			this.ObjectsRadioButton = new System.Windows.Forms.RadioButton();
			this.ResearchRadioButton = new System.Windows.Forms.RadioButton();
			this.ResearchPanel = new System.Windows.Forms.Panel();
			this.DevelopmentsPanel = new System.Windows.Forms.Panel();
			this.ResearchCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.QuickDevelPanel = new System.Windows.Forms.Panel();
			this.TechPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.DetailsMenuItem = new System.Windows.Forms.MenuItem();
			this.NewGameButton = new System.Windows.Forms.Button();
			this.OptionsButton = new System.Windows.Forms.Button();
			this.TeamBalloonTimer = new System.Windows.Forms.Timer(this.components);
			this.ResearchCostTimer = new System.Windows.Forms.Timer(this.components);
			this.TeamsPanel.SuspendLayout();
			this.MorePanel.SuspendLayout();
			this.ObjectBrowserPanel.SuspendLayout();
			this.MePanel.SuspendLayout();
			this.TargetPanel.SuspendLayout();
			this.ObjectTypePanel.SuspendLayout();
			this.ResearchPanel.SuspendLayout();
			this.DevelopmentsPanel.SuspendLayout();
			this.QuickDevelPanel.SuspendLayout();
			this.TechPanel.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ResearchNoneButton
			// 
			this.ResearchNoneButton.BackColor = System.Drawing.Color.Maroon;
			this.ResearchNoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResearchNoneButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ResearchNoneButton.Location = new System.Drawing.Point(4, 4);
			this.ResearchNoneButton.Name = "ResearchNoneButton";
			this.ResearchNoneButton.Size = new System.Drawing.Size(40, 18);
			this.ResearchNoneButton.TabIndex = 0;
			this.ResearchNoneButton.Text = "Clear";
			this.InfoToolTip.SetToolTip(this.ResearchNoneButton, "Clears all research and restores the techtree to the game-starting defaults");
			this.ResearchNoneButton.Click += new System.EventHandler(this.ResearchNoneButton_Click);
			// 
			// ResearchAllButton
			// 
			this.ResearchAllButton.BackColor = System.Drawing.Color.Maroon;
			this.ResearchAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResearchAllButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ResearchAllButton.Location = new System.Drawing.Point(128, 4);
			this.ResearchAllButton.Name = "ResearchAllButton";
			this.ResearchAllButton.Size = new System.Drawing.Size(26, 18);
			this.ResearchAllButton.TabIndex = 3;
			this.ResearchAllButton.Text = "All";
			this.InfoToolTip.SetToolTip(this.ResearchAllButton, "Maxes out all research and developments");
			this.ResearchAllButton.Click += new System.EventHandler(this.ResearchAllButton_Click);
			// 
			// ResearchMK2Button
			// 
			this.ResearchMK2Button.BackColor = System.Drawing.Color.Maroon;
			this.ResearchMK2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResearchMK2Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ResearchMK2Button.Location = new System.Drawing.Point(88, 4);
			this.ResearchMK2Button.Name = "ResearchMK2Button";
			this.ResearchMK2Button.Size = new System.Drawing.Size(36, 18);
			this.ResearchMK2Button.TabIndex = 2;
			this.ResearchMK2Button.Text = "MK2";
			this.InfoToolTip.SetToolTip(this.ResearchMK2Button, "Researches all developments by two levels");
			this.ResearchMK2Button.Click += new System.EventHandler(this.ResearchMK2Button_Click);
			// 
			// ResearchMK1Button
			// 
			this.ResearchMK1Button.BackColor = System.Drawing.Color.Maroon;
			this.ResearchMK1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResearchMK1Button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ResearchMK1Button.Location = new System.Drawing.Point(48, 4);
			this.ResearchMK1Button.Name = "ResearchMK1Button";
			this.ResearchMK1Button.Size = new System.Drawing.Size(36, 18);
			this.ResearchMK1Button.TabIndex = 1;
			this.ResearchMK1Button.Text = "MK1";
			this.InfoToolTip.SetToolTip(this.ResearchMK1Button, "Researches all developments by one level");
			this.ResearchMK1Button.Click += new System.EventHandler(this.ResearchMK1Button_Click);
			// 
			// CompareMeButton
			// 
			this.CompareMeButton.BackColor = System.Drawing.Color.Maroon;
			this.CompareMeButton.Enabled = false;
			this.CompareMeButton.Location = new System.Drawing.Point(194, 1);
			this.CompareMeButton.Name = "CompareMeButton";
			this.CompareMeButton.Size = new System.Drawing.Size(20, 33);
			this.CompareMeButton.TabIndex = 2;
			this.CompareMeButton.Text = "»";
			this.InfoToolTip.SetToolTip(this.CompareMeButton, "Opens the \"My Comparison\" window to show you compared to your target");
			this.CompareMeButton.Click += new System.EventHandler(this.CompareMeButton_Click);
			// 
			// ExpansionLabel
			// 
			this.ExpansionLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ExpansionLabel.ImageIndex = 7;
			this.ExpansionLabel.ImageList = this.IconImageList;
			this.ExpansionLabel.Location = new System.Drawing.Point(0, 92);
			this.ExpansionLabel.Name = "ExpansionLabel";
			this.ExpansionLabel.Size = new System.Drawing.Size(16, 16);
			this.ExpansionLabel.TabIndex = 4;
			this.ExpansionLabel.Tag = "4";
			this.ExpansionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.ExpansionLabel, "Shows all available Expansion research");
			this.ExpansionLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// IconImageList
			// 
			this.IconImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
			this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ConstructionLabel
			// 
			this.ConstructionLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ConstructionLabel.ImageIndex = 3;
			this.ConstructionLabel.ImageList = this.IconImageList;
			this.ConstructionLabel.Location = new System.Drawing.Point(0, 0);
			this.ConstructionLabel.Name = "ConstructionLabel";
			this.ConstructionLabel.Size = new System.Drawing.Size(16, 16);
			this.ConstructionLabel.TabIndex = 0;
			this.ConstructionLabel.Tag = "0";
			this.ConstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.ConstructionLabel, "Shows you available stations to build");
			this.ConstructionLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// TacticalLabel
			// 
			this.TacticalLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TacticalLabel.ImageIndex = 6;
			this.TacticalLabel.ImageList = this.IconImageList;
			this.TacticalLabel.Location = new System.Drawing.Point(0, 69);
			this.TacticalLabel.Name = "TacticalLabel";
			this.TacticalLabel.Size = new System.Drawing.Size(16, 16);
			this.TacticalLabel.TabIndex = 3;
			this.TacticalLabel.Tag = "3";
			this.TacticalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.TacticalLabel, "Shows all available Tactical research");
			this.TacticalLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// ShipyardLabel
			// 
			this.ShipyardLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShipyardLabel.ImageIndex = 8;
			this.ShipyardLabel.ImageList = this.IconImageList;
			this.ShipyardLabel.Location = new System.Drawing.Point(0, 114);
			this.ShipyardLabel.Name = "ShipyardLabel";
			this.ShipyardLabel.Size = new System.Drawing.Size(16, 16);
			this.ShipyardLabel.TabIndex = 5;
			this.ShipyardLabel.Tag = "5";
			this.ShipyardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.ShipyardLabel, "Shows all available Shipyard research");
			this.ShipyardLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// SupremacyLabel
			// 
			this.SupremacyLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.SupremacyLabel.ImageIndex = 5;
			this.SupremacyLabel.ImageList = this.IconImageList;
			this.SupremacyLabel.Location = new System.Drawing.Point(0, 46);
			this.SupremacyLabel.Name = "SupremacyLabel";
			this.SupremacyLabel.Size = new System.Drawing.Size(16, 16);
			this.SupremacyLabel.TabIndex = 2;
			this.SupremacyLabel.Tag = "2";
			this.SupremacyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.SupremacyLabel, "Shows all available Supremacy research");
			this.SupremacyLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// GarrisonLabel
			// 
			this.GarrisonLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GarrisonLabel.ImageIndex = 4;
			this.GarrisonLabel.ImageList = this.IconImageList;
			this.GarrisonLabel.Location = new System.Drawing.Point(0, 23);
			this.GarrisonLabel.Name = "GarrisonLabel";
			this.GarrisonLabel.Size = new System.Drawing.Size(16, 16);
			this.GarrisonLabel.TabIndex = 1;
			this.GarrisonLabel.Tag = "1";
			this.GarrisonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.GarrisonLabel, "Shows all available Garrison research");
			this.GarrisonLabel.Click += new System.EventHandler(this.TechLabel_Click);
			// 
			// TotalCostLabel
			// 
			this.TotalCostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.TotalCostLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.TotalCostLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TotalCostLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.TotalCostLabel.Location = new System.Drawing.Point(0, 153);
			this.TotalCostLabel.Name = "TotalCostLabel";
			this.TotalCostLabel.Size = new System.Drawing.Size(64, 16);
			this.TotalCostLabel.TabIndex = 3;
			this.TotalCostLabel.Text = "0 cr";
			this.TotalCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.TotalCostLabel, "The total cost of all purchased stations and researched developments");
			this.TotalCostLabel.MouseEnter += new System.EventHandler(this.ResearchCostTimer_Tick);
			// 
			// ResearchCostLabel
			// 
			this.ResearchCostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ResearchCostLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.ResearchCostLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResearchCostLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ResearchCostLabel.Location = new System.Drawing.Point(0, 138);
			this.ResearchCostLabel.Name = "ResearchCostLabel";
			this.ResearchCostLabel.Size = new System.Drawing.Size(64, 16);
			this.ResearchCostLabel.TabIndex = 2;
			this.ResearchCostLabel.Text = "0 cr";
			this.ResearchCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoToolTip.SetToolTip(this.ResearchCostLabel, "The cost of the selected developments or station");
			this.ResearchCostLabel.MouseEnter += new System.EventHandler(this.ResearchCostLabel_MouseEnter);
			// 
			// ProbeRadioButton
			// 
			this.ProbeRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ProbeRadioButton.BackColor = System.Drawing.Color.Maroon;
			this.ProbeRadioButton.ImageIndex = 2;
			this.ProbeRadioButton.ImageList = this.IconImageList;
			this.ProbeRadioButton.Location = new System.Drawing.Point(4, 38);
			this.ProbeRadioButton.Name = "ProbeRadioButton";
			this.ProbeRadioButton.Size = new System.Drawing.Size(32, 32);
			this.ProbeRadioButton.TabIndex = 1;
			this.ProbeRadioButton.Tag = "1";
			this.ProbeRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.ProbeRadioButton, "Populates the list with this team\'s probes/drones");
			this.ProbeRadioButton.Click += new System.EventHandler(this.ObjectRadioButton_Click);
			// 
			// StationRadioButton
			// 
			this.StationRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.StationRadioButton.BackColor = System.Drawing.Color.Maroon;
			this.StationRadioButton.ImageIndex = 0;
			this.StationRadioButton.ImageList = this.IconImageList;
			this.StationRadioButton.Location = new System.Drawing.Point(4, 74);
			this.StationRadioButton.Name = "StationRadioButton";
			this.StationRadioButton.Size = new System.Drawing.Size(32, 32);
			this.StationRadioButton.TabIndex = 2;
			this.StationRadioButton.Tag = "2";
			this.StationRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.StationRadioButton, "Populates the list with this team\'s stations");
			this.StationRadioButton.Click += new System.EventHandler(this.ObjectRadioButton_Click);
			// 
			// ShipRadioButton
			// 
			this.ShipRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ShipRadioButton.BackColor = System.Drawing.Color.Maroon;
			this.ShipRadioButton.ImageIndex = 1;
			this.ShipRadioButton.ImageList = this.IconImageList;
			this.ShipRadioButton.Location = new System.Drawing.Point(4, 2);
			this.ShipRadioButton.Name = "ShipRadioButton";
			this.ShipRadioButton.Size = new System.Drawing.Size(32, 32);
			this.ShipRadioButton.TabIndex = 0;
			this.ShipRadioButton.Tag = "0";
			this.ShipRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.ShipRadioButton, "Populate the list with this team\'s ships");
			this.ShipRadioButton.Click += new System.EventHandler(this.ObjectRadioButton_Click);
			// 
			// TargetTextBox
			// 
			this.TargetTextBox.BackColor = System.Drawing.Color.Maroon;
			this.TargetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TargetTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.TargetTextBox.ForeColor = System.Drawing.Color.White;
			this.TargetTextBox.Location = new System.Drawing.Point(52, 3);
			this.TargetTextBox.Name = "TargetTextBox";
			this.TargetTextBox.ReadOnly = true;
			this.TargetTextBox.Size = new System.Drawing.Size(140, 14);
			this.TargetTextBox.TabIndex = 1;
			this.TargetTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.TargetTextBox, "Shows you which object is currently set as your target. Drag any object here to s" +
				"et it as your target");
			this.TargetTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TargetTextBox_MouseDown);
			// 
			// TargetLabel
			// 
			this.TargetLabel.Location = new System.Drawing.Point(4, 4);
			this.TargetLabel.Name = "TargetLabel";
			this.TargetLabel.Size = new System.Drawing.Size(52, 16);
			this.TargetLabel.TabIndex = 0;
			this.TargetLabel.Text = "Target:";
			this.InfoToolTip.SetToolTip(this.TargetLabel, "Shows you which object is currently set as your tartet. Drag any object here to s" +
				"et it as your target");
			// 
			// MeTextBox
			// 
			this.MeTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MeTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MeTextBox.ForeColor = System.Drawing.Color.White;
			this.MeTextBox.Location = new System.Drawing.Point(52, 3);
			this.MeTextBox.Name = "MeTextBox";
			this.MeTextBox.ReadOnly = true;
			this.MeTextBox.Size = new System.Drawing.Size(140, 14);
			this.MeTextBox.TabIndex = 1;
			this.MeTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.MeTextBox, "Shows you which ship is currently set as \"Me.\" Drag a ship from your team here to" +
				" set it as \"Me\"");
			this.MeTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MeTextBox_MouseDown);
			// 
			// MeLabel
			// 
			this.MeLabel.Location = new System.Drawing.Point(4, 3);
			this.MeLabel.Name = "MeLabel";
			this.MeLabel.Size = new System.Drawing.Size(32, 16);
			this.MeLabel.TabIndex = 0;
			this.MeLabel.Text = "Me:";
			this.InfoToolTip.SetToolTip(this.MeLabel, "Shows you which ship is currently set as \"Me.\" Drag a ship from your team here to" +
				" set it as \"Me\"");
			// 
			// Team1RadioButton
			// 
			this.Team1RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team1RadioButton.BackColor = System.Drawing.Color.Gold;
			this.Team1RadioButton.Checked = true;
			this.Team1RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team1RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team1RadioButton.Location = new System.Drawing.Point(1, 1);
			this.Team1RadioButton.Name = "Team1RadioButton";
			this.Team1RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team1RadioButton.TabIndex = 0;
			this.Team1RadioButton.TabStop = true;
			this.Team1RadioButton.Tag = "0";
			this.Team1RadioButton.Text = "Iron Coalition";
			this.Team1RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team1RadioButton, "Right-click to change this team\'s faction");
			this.Team1RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// ChangeFactionContextMenu
			// 
			this.ChangeFactionContextMenu.Popup += new System.EventHandler(this.ChangeFactionContextMenu_Popup);
			// 
			// Team2RadioButton
			// 
			this.Team2RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team2RadioButton.BackColor = System.Drawing.Color.DodgerBlue;
			this.Team2RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team2RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team2RadioButton.Location = new System.Drawing.Point(1, 25);
			this.Team2RadioButton.Name = "Team2RadioButton";
			this.Team2RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team2RadioButton.TabIndex = 1;
			this.Team2RadioButton.Tag = "1";
			this.Team2RadioButton.Text = "BIOS";
			this.Team2RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team2RadioButton, "Right-click to change this team\'s faction");
			this.Team2RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// Team3RadioButton
			// 
			this.Team3RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team3RadioButton.BackColor = System.Drawing.Color.DarkMagenta;
			this.Team3RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team3RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team3RadioButton.Location = new System.Drawing.Point(1, 49);
			this.Team3RadioButton.Name = "Team3RadioButton";
			this.Team3RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team3RadioButton.TabIndex = 2;
			this.Team3RadioButton.Tag = "2";
			this.Team3RadioButton.Text = "Technoflux";
			this.Team3RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team3RadioButton, "Right-click to change this team\'s faction");
			this.Team3RadioButton.Visible = false;
			this.Team3RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// Team4RadioButton
			// 
			this.Team4RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team4RadioButton.BackColor = System.Drawing.Color.Green;
			this.Team4RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team4RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team4RadioButton.Location = new System.Drawing.Point(1, 73);
			this.Team4RadioButton.Name = "Team4RadioButton";
			this.Team4RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team4RadioButton.TabIndex = 3;
			this.Team4RadioButton.Tag = "3";
			this.Team4RadioButton.Text = "Dregkhlar";
			this.Team4RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team4RadioButton, "Right-click to change this team\'s faction");
			this.Team4RadioButton.Visible = false;
			this.Team4RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// Team5RadioButton
			// 
			this.Team5RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team5RadioButton.BackColor = System.Drawing.Color.Salmon;
			this.Team5RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team5RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team5RadioButton.Location = new System.Drawing.Point(1, 97);
			this.Team5RadioButton.Name = "Team5RadioButton";
			this.Team5RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team5RadioButton.TabIndex = 4;
			this.Team5RadioButton.Tag = "4";
			this.Team5RadioButton.Text = "Ga\'Tarran";
			this.Team5RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team5RadioButton, "Right-click to change this team\'s faction");
			this.Team5RadioButton.Visible = false;
			this.Team5RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// Team6RadioButton
			// 
			this.Team6RadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.Team6RadioButton.BackColor = System.Drawing.Color.Turquoise;
			this.Team6RadioButton.ContextMenu = this.ChangeFactionContextMenu;
			this.Team6RadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Team6RadioButton.ForeColor = System.Drawing.Color.DarkGray;
			this.Team6RadioButton.Location = new System.Drawing.Point(1, 121);
			this.Team6RadioButton.Name = "Team6RadioButton";
			this.Team6RadioButton.Size = new System.Drawing.Size(100, 24);
			this.Team6RadioButton.TabIndex = 5;
			this.Team6RadioButton.Tag = "5";
			this.Team6RadioButton.Text = "Gigacorp";
			this.Team6RadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.InfoToolTip.SetToolTip(this.Team6RadioButton, "Right-click to change this team\'s faction");
			this.Team6RadioButton.Visible = false;
			this.Team6RadioButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TeamRadioButton_MouseDown);
			// 
			// ConstantsButton
			// 
			this.ConstantsButton.BackColor = System.Drawing.Color.Maroon;
			this.ConstantsButton.Location = new System.Drawing.Point(116, 58);
			this.ConstantsButton.Name = "ConstantsButton";
			this.ConstantsButton.Size = new System.Drawing.Size(103, 23);
			this.ConstantsButton.TabIndex = 2;
			this.ConstantsButton.Text = "Constants";
			this.ConstantsButton.Click += new System.EventHandler(this.ConstantsButton_Click);
			// 
			// DamageIndicesButton
			// 
			this.DamageIndicesButton.BackColor = System.Drawing.Color.Maroon;
			this.DamageIndicesButton.Location = new System.Drawing.Point(116, 34);
			this.DamageIndicesButton.Name = "DamageIndicesButton";
			this.DamageIndicesButton.Size = new System.Drawing.Size(103, 23);
			this.DamageIndicesButton.TabIndex = 1;
			this.DamageIndicesButton.Text = "DM/AC";
			this.DamageIndicesButton.Click += new System.EventHandler(this.DamageIndicesButton_Click);
			// 
			// TeamsPanel
			// 
			this.TeamsPanel.BackColor = System.Drawing.Color.White;
			this.TeamsPanel.Controls.Add(this.Team1RadioButton);
			this.TeamsPanel.Controls.Add(this.Team2RadioButton);
			this.TeamsPanel.Controls.Add(this.Team3RadioButton);
			this.TeamsPanel.Controls.Add(this.Team4RadioButton);
			this.TeamsPanel.Controls.Add(this.Team5RadioButton);
			this.TeamsPanel.Controls.Add(this.Team6RadioButton);
			this.TeamsPanel.Location = new System.Drawing.Point(8, 33);
			this.TeamsPanel.Name = "TeamsPanel";
			this.TeamsPanel.Size = new System.Drawing.Size(102, 146);
			this.TeamsPanel.TabIndex = 0;
			// 
			// MorePanel
			// 
			this.MorePanel.Controls.Add(this.ObjectBrowserPanel);
			this.MorePanel.Controls.Add(this.ObjectsRadioButton);
			this.MorePanel.Controls.Add(this.ResearchRadioButton);
			this.MorePanel.Controls.Add(this.ResearchPanel);
			this.MorePanel.Location = new System.Drawing.Point(0, 82);
			this.MorePanel.Name = "MorePanel";
			this.MorePanel.Size = new System.Drawing.Size(224, 206);
			this.MorePanel.TabIndex = 3;
			this.MorePanel.Visible = false;
			// 
			// ObjectBrowserPanel
			// 
			this.ObjectBrowserPanel.Controls.Add(this.CompareMeButton);
			this.ObjectBrowserPanel.Controls.Add(this.MePanel);
			this.ObjectBrowserPanel.Controls.Add(this.TargetPanel);
			this.ObjectBrowserPanel.Controls.Add(this.ObjectsListBox);
			this.ObjectBrowserPanel.Controls.Add(this.ObjectTypePanel);
			this.ObjectBrowserPanel.Enabled = false;
			this.ObjectBrowserPanel.Location = new System.Drawing.Point(0, 30);
			this.ObjectBrowserPanel.Name = "ObjectBrowserPanel";
			this.ObjectBrowserPanel.Size = new System.Drawing.Size(224, 174);
			this.ObjectBrowserPanel.TabIndex = 3;
			this.ObjectBrowserPanel.Visible = false;
			// 
			// MePanel
			// 
			this.MePanel.AllowDrop = true;
			this.MePanel.Controls.Add(this.MeTextBox);
			this.MePanel.Controls.Add(this.MeLabel);
			this.MePanel.Location = new System.Drawing.Point(0, -2);
			this.MePanel.Name = "MePanel";
			this.MePanel.Size = new System.Drawing.Size(200, 20);
			this.MePanel.TabIndex = 0;
			this.MePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.MePanel_DragDrop);
			this.MePanel.DragOver += new System.Windows.Forms.DragEventHandler(this.MePanel_DragOver);
			// 
			// TargetPanel
			// 
			this.TargetPanel.AllowDrop = true;
			this.TargetPanel.Controls.Add(this.TargetTextBox);
			this.TargetPanel.Controls.Add(this.TargetLabel);
			this.TargetPanel.Location = new System.Drawing.Point(0, 16);
			this.TargetPanel.Name = "TargetPanel";
			this.TargetPanel.Size = new System.Drawing.Size(196, 20);
			this.TargetPanel.TabIndex = 1;
			this.TargetPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.TargetPanel_DragDrop);
			this.TargetPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.TargetPanel_DragOver);
			// 
			// ObjectsListBox
			// 
			this.ObjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.ObjectsListBox.BackColor = System.Drawing.Color.Maroon;
			this.ObjectsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ObjectsListBox.ContextMenu = this.ObjectsListBoxContextMenu;
			this.ObjectsListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ObjectsListBox.ForeColor = System.Drawing.Color.White;
			this.ObjectsListBox.Location = new System.Drawing.Point(40, 40);
			this.ObjectsListBox.Name = "ObjectsListBox";
			this.ObjectsListBox.Size = new System.Drawing.Size(174, 130);
			this.ObjectsListBox.Sorted = true;
			this.ObjectsListBox.TabIndex = 4;
			this.ObjectsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ObjectsListBox_MouseDown);
			this.ObjectsListBox.DoubleClick += new System.EventHandler(this.ObjectsListBox_DoubleClick);
			this.ObjectsListBox.MouseEnter += new System.EventHandler(this.ObjectsListBox_MouseEnter);
			// 
			// ObjectsListBoxContextMenu
			// 
			this.ObjectsListBoxContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																									  this.CompareToMenuItem,
																									  this.ObjectInfoMenuItem,
																									  this.Separator1MenuItem,
																									  this.SetMeMenuItem,
																									  this.SetTargetMenuItem});
			this.ObjectsListBoxContextMenu.Popup += new System.EventHandler(this.ObjectsListBoxContextMenu_Popup);
			// 
			// CompareToMenuItem
			// 
			this.CompareToMenuItem.Index = 0;
			this.CompareToMenuItem.Text = "Compare to...";
			this.CompareToMenuItem.Click += new System.EventHandler(this.CompareToMenuItem_Click);
			// 
			// ObjectInfoMenuItem
			// 
			this.ObjectInfoMenuItem.Index = 1;
			this.ObjectInfoMenuItem.Text = "Info...";
			this.ObjectInfoMenuItem.Click += new System.EventHandler(this.ObjectInfoMenuItem_Click);
			// 
			// Separator1MenuItem
			// 
			this.Separator1MenuItem.Index = 2;
			this.Separator1MenuItem.Text = "-";
			// 
			// SetMeMenuItem
			// 
			this.SetMeMenuItem.Index = 3;
			this.SetMeMenuItem.Text = "Set Me";
			this.SetMeMenuItem.Click += new System.EventHandler(this.SetMeMenuItem_Click);
			// 
			// SetTargetMenuItem
			// 
			this.SetTargetMenuItem.Index = 4;
			this.SetTargetMenuItem.Text = "Set Target";
			this.SetTargetMenuItem.Click += new System.EventHandler(this.SetTargetMenuItem_Click);
			// 
			// ObjectTypePanel
			// 
			this.ObjectTypePanel.Controls.Add(this.ProbeRadioButton);
			this.ObjectTypePanel.Controls.Add(this.StationRadioButton);
			this.ObjectTypePanel.Controls.Add(this.ShipRadioButton);
			this.ObjectTypePanel.Location = new System.Drawing.Point(0, 40);
			this.ObjectTypePanel.Name = "ObjectTypePanel";
			this.ObjectTypePanel.Size = new System.Drawing.Size(40, 114);
			this.ObjectTypePanel.TabIndex = 3;
			// 
			// ObjectsRadioButton
			// 
			this.ObjectsRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ObjectsRadioButton.BackColor = System.Drawing.Color.Maroon;
			this.ObjectsRadioButton.Location = new System.Drawing.Point(112, 3);
			this.ObjectsRadioButton.Name = "ObjectsRadioButton";
			this.ObjectsRadioButton.Size = new System.Drawing.Size(103, 24);
			this.ObjectsRadioButton.TabIndex = 1;
			this.ObjectsRadioButton.Tag = "0";
			this.ObjectsRadioButton.Text = "Objects";
			this.ObjectsRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ObjectsRadioButton.Click += new System.EventHandler(this.ObjectsRadioButton_Click);
			this.ObjectsRadioButton.CheckedChanged += new System.EventHandler(this.ObjectsRadioButton_CheckedChanged);
			// 
			// ResearchRadioButton
			// 
			this.ResearchRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ResearchRadioButton.BackColor = System.Drawing.Color.Maroon;
			this.ResearchRadioButton.Location = new System.Drawing.Point(4, 3);
			this.ResearchRadioButton.Name = "ResearchRadioButton";
			this.ResearchRadioButton.Size = new System.Drawing.Size(102, 24);
			this.ResearchRadioButton.TabIndex = 0;
			this.ResearchRadioButton.Tag = "0";
			this.ResearchRadioButton.Text = "Research";
			this.ResearchRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ResearchRadioButton.Click += new System.EventHandler(this.ResearchRadioButton_Click);
			this.ResearchRadioButton.CheckedChanged += new System.EventHandler(this.ResearchRadioButton_CheckedChanged);
			// 
			// ResearchPanel
			// 
			this.ResearchPanel.Controls.Add(this.DevelopmentsPanel);
			this.ResearchPanel.Controls.Add(this.QuickDevelPanel);
			this.ResearchPanel.Controls.Add(this.TechPanel);
			this.ResearchPanel.Controls.Add(this.TotalCostLabel);
			this.ResearchPanel.Controls.Add(this.ResearchCostLabel);
			this.ResearchPanel.Enabled = false;
			this.ResearchPanel.Location = new System.Drawing.Point(0, 30);
			this.ResearchPanel.Name = "ResearchPanel";
			this.ResearchPanel.Size = new System.Drawing.Size(224, 166);
			this.ResearchPanel.TabIndex = 2;
			this.ResearchPanel.Visible = false;
			// 
			// DevelopmentsPanel
			// 
			this.DevelopmentsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.DevelopmentsPanel.Controls.Add(this.ResearchCheckedListBox);
			this.DevelopmentsPanel.Location = new System.Drawing.Point(20, 0);
			this.DevelopmentsPanel.Name = "DevelopmentsPanel";
			this.DevelopmentsPanel.Size = new System.Drawing.Size(198, 140);
			this.DevelopmentsPanel.TabIndex = 1;
			// 
			// ResearchCheckedListBox
			// 
			this.ResearchCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.ResearchCheckedListBox.CheckOnClick = true;
			this.ResearchCheckedListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ResearchCheckedListBox.Location = new System.Drawing.Point(4, 4);
			this.ResearchCheckedListBox.Name = "ResearchCheckedListBox";
			this.ResearchCheckedListBox.Size = new System.Drawing.Size(189, 132);
			this.ResearchCheckedListBox.TabIndex = 0;
			this.ResearchCheckedListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ResearchCheckedListBox_KeyUp);
			this.ResearchCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ResearchCheckedListBox_SelectedIndexChanged);
			this.ResearchCheckedListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResearchCheckedListBox_MouseUp);
			this.ResearchCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ResearchCheckedListBox_ItemCheck);
			// 
			// QuickDevelPanel
			// 
			this.QuickDevelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.QuickDevelPanel.Controls.Add(this.ResearchNoneButton);
			this.QuickDevelPanel.Controls.Add(this.ResearchAllButton);
			this.QuickDevelPanel.Controls.Add(this.ResearchMK2Button);
			this.QuickDevelPanel.Controls.Add(this.ResearchMK1Button);
			this.QuickDevelPanel.Location = new System.Drawing.Point(58, 140);
			this.QuickDevelPanel.Name = "QuickDevelPanel";
			this.QuickDevelPanel.Size = new System.Drawing.Size(157, 26);
			this.QuickDevelPanel.TabIndex = 4;
			this.QuickDevelPanel.MouseEnter += new System.EventHandler(this.QuickDevelPanel_MouseEnter);
			// 
			// TechPanel
			// 
			this.TechPanel.BackColor = System.Drawing.Color.White;
			this.TechPanel.Controls.Add(this.ExpansionLabel);
			this.TechPanel.Controls.Add(this.ConstructionLabel);
			this.TechPanel.Controls.Add(this.TacticalLabel);
			this.TechPanel.Controls.Add(this.ShipyardLabel);
			this.TechPanel.Controls.Add(this.SupremacyLabel);
			this.TechPanel.Controls.Add(this.GarrisonLabel);
			this.TechPanel.Controls.Add(this.label1);
			this.TechPanel.Controls.Add(this.label2);
			this.TechPanel.Controls.Add(this.label3);
			this.TechPanel.Controls.Add(this.label4);
			this.TechPanel.Controls.Add(this.label5);
			this.TechPanel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.TechPanel.Location = new System.Drawing.Point(4, 4);
			this.TechPanel.Name = "TechPanel";
			this.TechPanel.Size = new System.Drawing.Size(16, 130);
			this.TechPanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 8);
			this.label1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(-4, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 8);
			this.label2.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(-4, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 8);
			this.label3.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(0, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 8);
			this.label4.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(0, 107);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 8);
			this.label5.TabIndex = 9;
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.TeamsPanel);
			this.MainPanel.Controls.Add(this.DamageIndicesButton);
			this.MainPanel.Controls.Add(this.ConstantsButton);
			this.MainPanel.Enabled = false;
			this.MainPanel.Location = new System.Drawing.Point(-4, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(222, 206);
			this.MainPanel.TabIndex = 2;
			// 
			// DetailsMenuItem
			// 
			this.DetailsMenuItem.Index = -1;
			this.DetailsMenuItem.Text = "&Details...";
			// 
			// NewGameButton
			// 
			this.NewGameButton.BackColor = System.Drawing.Color.Maroon;
			this.NewGameButton.Location = new System.Drawing.Point(4, 5);
			this.NewGameButton.Name = "NewGameButton";
			this.NewGameButton.Size = new System.Drawing.Size(102, 23);
			this.NewGameButton.TabIndex = 0;
			this.NewGameButton.Text = "New Game";
			this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
			// 
			// OptionsButton
			// 
			this.OptionsButton.BackColor = System.Drawing.Color.Maroon;
			this.OptionsButton.Location = new System.Drawing.Point(112, 5);
			this.OptionsButton.Name = "OptionsButton";
			this.OptionsButton.Size = new System.Drawing.Size(103, 23);
			this.OptionsButton.TabIndex = 1;
			this.OptionsButton.Text = "Options";
			this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
			// 
			// TeamBalloonTimer
			// 
			this.TeamBalloonTimer.Tick += new System.EventHandler(this.TeamBalloonTimer_Tick);
			// 
			// ResearchCostTimer
			// 
			this.ResearchCostTimer.Tick += new System.EventHandler(this.ResearchCostTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(216, 287);
			this.Controls.Add(this.MorePanel);
			this.Controls.Add(this.NewGameButton);
			this.Controls.Add(this.OptionsButton);
			this.Controls.Add(this.MainPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "TE\'s Kneeboard";
			this.TopMost = true;
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.TeamsPanel.ResumeLayout(false);
			this.MorePanel.ResumeLayout(false);
			this.ObjectBrowserPanel.ResumeLayout(false);
			this.MePanel.ResumeLayout(false);
			this.TargetPanel.ResumeLayout(false);
			this.ObjectTypePanel.ResumeLayout(false);
			this.ResearchPanel.ResumeLayout(false);
			this.DevelopmentsPanel.ResumeLayout(false);
			this.QuickDevelPanel.ResumeLayout(false);
			this.TechPanel.ResumeLayout(false);
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
#if !DEBUG
			try
			{
#endif
			//AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			Application.Run(new MainForm());
#if !DEBUG
			}
			catch (Exception e)
			{
				FileStream FS = new FileStream(string.Concat(Application.StartupPath, "\\error.txt"), FileMode.Create);
				StreamWriter SW = new StreamWriter(FS);
				SW.WriteLine(e.Message);
				SW.WriteLine();
				SW.Write(e.StackTrace);
				SW.WriteLine();
				SW.Close();
				FS.Close();
				MessageBox.Show("An unhandled error has occured, and an error log has been created in this program's folder.\nPlease email or ForumPM the contents to Tigereye and tell him what you did to cause this! Thanks!\n\nTek will now close.", Application.ProductName);
			}
#endif
		}

//		/// <summary>
//		/// Intercepts the "Assembly Not Found" exception on load, and loads
//		/// IGCCore.dll from resources
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="args"></param>
//		/// <returns>the loaded IGCCore.dll assembly</returns>
//		private static Assembly CurrentDomain_AssemblyResolve (object sender, ResolveEventArgs args)
//		{
//			Assembly ReturnAssembly = null;
//			if (args.Name.Substring(0, args.Name.IndexOf(",")).Equals("IGCCore"))
//			{
//				string IGCCoreResourceName = "FreeAllegiance.Tek.Resources.IGCCore.dll";
//				Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();
//				Stream IGCCoreStream = ExecutingAssembly.GetManifestResourceStream(IGCCoreResourceName);
//				long StreamLength = IGCCoreStream.Length;
//				BinaryReader IGCCoreReader = new BinaryReader(IGCCoreStream);
//				byte[] IGCCoreBytes = IGCCoreReader.ReadBytes((int)StreamLength);
//				IGCCoreReader.Close();
//				ReturnAssembly = Assembly.Load(IGCCoreBytes);
//			}
//			return ReturnAssembly;
//		}

		/// <summary>
		/// Loads the settings and corepath
		/// </summary>
		private void LoadSettings ()
		{
			_settingsPath = string.Concat(Application.StartupPath, "\\options.xml");
			try
			{
				if (!File.Exists(_settingsPath))
					new TekSettings().Serialize(_settingsPath);

				_settings = TekSettings.Deserialize(_settingsPath);

				InfoToolTip.Active = _settings.ShowToolTips;
				if (_settings.DefaultCoreLocation.Length == 0)
				{	// No DefaultCorePath specified, so load it from Registry
					RegistryKey Key = Registry.LocalMachine.OpenSubKey(ALLEGIANCEKEY);
					if (Key != null)
						_corePath = (string)Key.GetValue("ArtPath");

					Key.Close();
				}
				else
				{
					_corePath = _settings.DefaultCoreLocation;
				}

				if (_corePath.Equals(string.Empty))
					_corePath = Path.GetDirectoryName(Application.StartupPath);
			}
			catch (System.Security.SecurityException e)
			{
				MessageBox.Show(this, "You do not have permission to read from the Allegiance registry key.", Application.ProductName);
				_corePath = _settings.DefaultCoreLocation;
			}
			catch (Exception e)
			{
				MessageBox.Show(this, "Error while loading settings! Default Settings will be overwritten.\n" + e.Message, Application.ProductName);
				_settings = new TekSettings();
				_settings.Serialize(_settingsPath);
			}
		}
		
		private void DoStartup ()
		{
			string CoreToLoad = string.Empty;
			switch ((StartupAction)_settings.Startup)
			{
				case StartupAction.DoNothing:
					return;
				case StartupAction.LoadLastPlayed:
					CoreToLoad = GetLastPlayedCore();
					break;
				case StartupAction.LoadLastUsed:
					CoreToLoad = _settings.LastCore;
					break;
				case StartupAction.LoadSpecified:
					CoreToLoad = _settings.SpecifiedCore;
					break;
				default:
					break;
			}

			if(CoreToLoad.Equals(string.Empty))
				return;

			if (!_settings.RecentCores.Contains(CoreToLoad))
				_settings.RecentCores.Add(CoreToLoad);

			LoadNewGame(CoreToLoad, _settings.NumTeams, 1, true, true, false, false, false, false);
		}

		/// <summary>
		/// Retrieves the path to the core file with the latest access date
		/// </summary>
		/// <returns></returns>
		private string GetLastPlayedCore ()
		{
			string Result = string.Empty;
			DateTime ResultLastAccess = DateTime.Now;
			string[] Cores = Directory.GetFiles(_corePath, "*.igc");

			for (int i = 0; i < Cores.Length; i++)
			{
				DateTime LastAccess = File.GetLastAccessTime(Cores[i]);
				if (LastAccess.CompareTo(ResultLastAccess) < 0)
				{
					Result = Cores[i];
					ResultLastAccess = LastAccess;
				}
			}

			return Result;
		}
		
		/// <summary>
		/// Places the main form at topright of screen if user has only 1 screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load (object sender, System.EventArgs e)
		{
			MorePanel.Height = 30;
			this.ClientSize = new Size(this.ClientSize.Width, 32);
			if (Screen.AllScreens.Length == 1)
			{
				this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
				this.Top = Screen.PrimaryScreen.WorkingArea.Y;
			}
			
			DoStartup();
		}

		private void MainForm_Closing (object sender, System.ComponentModel.CancelEventArgs e)
		{
			_settings.Serialize(_settingsPath);
			if (_game != null)
				_game.Dispose();
		}

		private void MainForm_Resize (object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				if (this.Width != 224)
					this.Width = 224;

				ArrangeComparisions();
			}

			if (this.WindowState == FormWindowState.Minimized)
			{
				if (_game == null)
					return;

				foreach (ComparisonForm Comp in _game.Comparisons)
				{
					Comp.WindowState = FormWindowState.Minimized;
				}
			}
		}

		private void NewGameButton_Click (object sender, System.EventArgs e)
		{
			if (_game != null)
			{
				bool PromptMe = false;
				foreach (Team team in _game.Teams)
				{
					if (team.OpenObjects.Count > 0)
					{
						PromptMe = true;
						break;
					}
				}
				if (PromptMe == true)
				{
					DialogResult Res = MessageBox.Show(this, "Starting a new game will erase all work in the current game\nDo you wish to continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					switch (Res)
					{
						case DialogResult.Yes:
							break;
						case DialogResult.No:
						default:
							return;
					}
				}
			}

			NewGameForm NewGame = new NewGameForm(_settings, _corePath);
			
			string OldLocation = _settings.DefaultCoreLocation;
			_settings.DefaultCoreLocation = _corePath;

			DialogResult Result = NewGame.ShowDialog(this);
			switch (Result)
			{
				case DialogResult.OK:
//					string Str = "Artwork=" + _corePath + "\n";
//					Str = Str + "Path=" + NewGame.CorePath + "\n";
//					Str = Str +"DefaultLocation=" + OldLocation;
//					MessageBox.Show(Str);
					LoadNewGame(NewGame.CorePath, NewGame.NumberOfTeams, NewGame.MyTeam, NewGame.AllowDevelopment, NewGame.AllowShipyards, NewGame.DeathMatch, NewGame.CaptureTheFlag, NewGame.AllowArtifacts, NewGame.Prosperity);
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
			_settings.DefaultCoreLocation = OldLocation;
			NewGame.Dispose();
		}

		private void LoadNewGame (string corePath, int numTeams, int myTeam, bool allowDevelopment, bool allowShipyards, bool deathMatch, bool captureTheFlag, bool allowArtifacts, bool prosperity)
		{
			if (_game != null)
			{
				_game.Dispose();
				MeTextBox.Text = string.Empty;
				TargetTextBox.Text = string.Empty;
			}
			_selectedTech = TreeRoot.Construction;
			ConstructionLabel.BackColor = Color.Red;
			_game = new Game(corePath, numTeams, myTeam, allowDevelopment, allowShipyards, deathMatch, captureTheFlag, allowArtifacts, prosperity);
			_game.MeChanged += new EventHandler(MeChangedHandler);
			_game.TargetChanged += new EventHandler(TargetChangedHandler);
			MainPanel.Enabled = true;
			MorePanel.Visible = true;
			MorePanel.Top = TeamsPanel.Top + (numTeams * (Team1RadioButton.Height)) + 2;
			if (numTeams > 2)
				Team3RadioButton.Visible = true;
			else
				Team3RadioButton.Visible = false;

			if (numTeams > 3)
				Team4RadioButton.Visible = true;
			else
				Team4RadioButton.Visible = false;

			if (numTeams > 4)
				Team5RadioButton.Visible = true;
			else
				Team5RadioButton.Visible = false;

			if (numTeams > 5)
				Team6RadioButton.Visible = true;
			else
				Team6RadioButton.Visible = false;

			this.ClientSize = new Size(this.ClientSize.Width, MorePanel.Top + MorePanel.Height);

			for (int i = 0; i < numTeams; i++)
			{
				string FactionName = ((Team)_game.Teams[i]).Faction.Name;
				TeamsPanel.Controls[i].Text = FactionName;
			}
			_settings.LastCore = corePath;
			ObjectsListBox.Tag = _game.Core.Ships;
			SelectTeam(0);

			TeamBalloonTimer.Enabled = true;
		}

		private void TeamBalloonTimer_Tick (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.TeamHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Select teams here</b>\r\n<hr=100%>\r\nYour team is shown in <b>bold<//b> and\r\nall other teams are shown in <ct=0x696969>grey</ct>";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, Team1RadioButton, true, BalloonDirection.BALLOON_RIGHT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.TeamHelpShown = true;
			}
			TeamBalloonTimer.Enabled = false;
		}

		private void OptionsButton_Click (object sender, System.EventArgs e)
		{
			OptionsForm Options = new OptionsForm(this);
			DialogResult Result = Options.ShowDialog(this);
			switch (Result)
			{
				case DialogResult.OK:
					_settings.Serialize(_settingsPath);
					if (!_settings.DefaultCoreLocation.Equals(string.Empty))
						_corePath = _settings.DefaultCoreLocation;
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
			Options.Dispose();
		}

		private void ConstantsButton_Click (object sender, System.EventArgs e)
		{
			ConstantsForm Constants = new ConstantsForm(this);
			Constants.Show();
		}

		private void DamageIndicesButton_Click (object sender, System.EventArgs e)
		{
			DamageIndexForm Damage = new DamageIndexForm(this);
			Damage.Show();
		}

		private void SelectTeam(int teamNumber)
		{
			RadioButton Sender = (RadioButton)TeamsPanel.Controls[teamNumber];
			_selectedTeam = (Team)_game.Teams[teamNumber];
			foreach (Control control in TeamsPanel.Controls)
			{
				if (control is RadioButton)
				{
					RadioButton RB = (RadioButton)control;
					int TeamNumber = int.Parse(RB.Tag.ToString());
					if (TeamNumber >= Game.Teams.Count)
						break;

					if (_game.Teams[TeamNumber] == _game.MyTeam)
					{
						RB.ForeColor = Color.Black;
						RB.Font = new Font("Tahoma", 10, FontStyle.Bold);
					}
					else
					{
						RB.ForeColor = Color.DimGray;
						RB.Font = new Font("Tahoma", 10, FontStyle.Regular);
					}
				}
			}

			ResearchPanel.Enabled = true;
			ObjectBrowserPanel.Enabled = true;

			TechPanel.BackColor = _selectedTeam.TeamColor;
			ShipRadioButton.BackColor = _selectedTeam.TeamColor;
			ProbeRadioButton.BackColor = _selectedTeam.TeamColor;
			StationRadioButton.BackColor = _selectedTeam.TeamColor;
			UpdateResearchList();
		}

		private void TeamRadioButton_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			RadioButton Sender = (RadioButton)sender;
			SelectTeam(int.Parse(Sender.Tag.ToString()));
		}

		private void ChangeFactionContextMenu_Popup (object sender, System.EventArgs e)
		{
			ContextMenu Menu = (ContextMenu)sender;
			RadioButton RB = (RadioButton)Menu.SourceControl;;

			ChangeFactionContextMenu.MenuItems.Clear();
			foreach (IGCCoreObject Faction in _game.Core.Factions)
			{
				MenuItem Item = new MenuItem(Faction.Name, new EventHandler(ChangeFactionMenuItem_Click));
				ChangeFactionContextMenu.MenuItems.Add(Item);
			}
		}

		private void ChangeFactionMenuItem_Click (object sender, System.EventArgs e)
		{
			MenuItem Menu = (MenuItem)sender;
			string FactionName = Menu.Text;
			RadioButton RB = (RadioButton)Menu.GetContextMenu().SourceControl;
			int TeamNumber = int.Parse(RB.Tag.ToString());
			Team ClickedTeam = (Team)_game.Teams[TeamNumber];

			if (ClickedTeam == null)
				return;

			if (ClickedTeam.OpenObjects.Count > 0)
			{
				DialogResult Result = MessageBox.Show(this, "Changing this team's faction will close all open objects currently being compared.\nDo you want to continue?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				switch (Result)
				{
					case DialogResult.Yes:
						while (ClickedTeam.OpenObjects.Count > 0)
						{
							AllegObject Obj = (AllegObject)ClickedTeam.OpenObjects[0];
							if (Obj == _game.Me)
							{
								_game.Me = null;
								MeTextBox.Text = string.Empty;
								CompareMeButton.Enabled = false;
							}
							if (Obj == _game.Target)
							{
								_game.Target = null;
								TargetTextBox.Text = string.Empty;
								CompareMeButton.Enabled = false;
							}
							Obj.Close();
						}
						break;
					case DialogResult.No:
					default:
						return;
				}
			}

			if (_game.Me != null)
			{
				if (_game.Me.Team == ClickedTeam)
					_game.Me = null;
			}
			if (_game.Target != null)
			{
				if (_game.Target.Team == ClickedTeam)
					_game.Target = null;
			}

			ClickedTeam.Faction = (IGCCoreCiv)_game.Core.Factions[Menu.Index];
			RB.Text = ClickedTeam.Faction.Name;
			UpdateResearchList();
		}

		private void ResearchRadioButton_CheckedChanged (object sender, System.EventArgs e)
		{
			if (ResearchRadioButton.Checked == true)
			{
				ResearchRadioButton.Tag = "1";
				ResearchPanel.Visible = true;
				MorePanel.Height = ResearchPanel.Top + ResearchPanel.Height;
				this.ClientSize = new Size(this.ClientSize.Width, MorePanel.Top + MorePanel.Height);
				this.FormBorderStyle = FormBorderStyle.Sizable;
				ResearchPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
				MorePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

				if (_settings.ShowBalloonHelp == true && HelpBalloon.ResearchHelpShown == false)
				{
					Application.DoEvents();
					string HelpString = "<b>Build Stations and Research Technology</b>\r\n<hr=100%>\r\nCheck the stations owned by the selected\r\nteam, and its research will become available.\r\nTo build another one, hold down <u>Shift</u> while\r\nclicking the station.\r\n\r\nUse the station icons at the left to browse\r\nand research technology.";
					HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, ResearchCheckedListBox, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
					BHelp.ShowBalloon();
					HelpBalloon.ResearchHelpShown = true;
				}
				
			}
			else
			{
				ResearchPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				MorePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				MorePanel.Height = ResearchPanel.Top;
				ResearchPanel.Visible = false;
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				this.ClientSize = new Size(this.ClientSize.Width, MorePanel.Top + MorePanel.Height);
			}
		}

		private void ResearchRadioButton_Click (object sender, System.EventArgs e)
		{
			if (ResearchRadioButton.Tag.ToString().Equals("1"))
			{
				ResearchRadioButton.Tag = "0";
				return;
			}

			if (ResearchRadioButton.Checked == true)
				ResearchRadioButton.Checked = false;
		}

		private void ObjectsRadioButton_CheckedChanged (object sender, System.EventArgs e)
		{
			if (ObjectsRadioButton.Checked == true)
			{
				ObjectsRadioButton.Tag = "1";
				ObjectBrowserPanel.Visible = true;
				MorePanel.Height = ObjectBrowserPanel.Top + ObjectBrowserPanel.Height;
				this.ClientSize = new Size(this.ClientSize.Width, MorePanel.Top + MorePanel.Height);
				this.FormBorderStyle = FormBorderStyle.Sizable;
				ObjectBrowserPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
				MorePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

				if (_settings.ShowBalloonHelp == true && HelpBalloon.MeTargetHelpShown == false)
				{
					Application.DoEvents();
					string HelpString = "<b>Choose what to look at</b>\r\n<hr=100%>\r\nUse these buttons to list Ships,\r\nStations, and Probes.\r\n\r\nOnly the available items from the\r\n<u>Team</u> selected above will be listed.";
					HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, ObjectTypePanel, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
					BHelp.ShowBalloon();
					HelpBalloon.MeTargetHelpShown = true;
				}
			}
			else
			{
				ObjectBrowserPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				MorePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
				MorePanel.Height = ResearchPanel.Top;
				ObjectBrowserPanel.Visible = false;
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				this.ClientSize = new Size(this.ClientSize.Width, MorePanel.Top + MorePanel.Height);
			}
		}

		private void ObjectsRadioButton_Click (object sender, System.EventArgs e)
		{
			if (ObjectsRadioButton.Tag.ToString().Equals("1"))
			{
				ObjectsRadioButton.Tag = "0";
				return;
			}

			if (ObjectsRadioButton.Checked == true)
				ObjectsRadioButton.Checked = false;
		}

		#region Research Pane
		
		private void TechLabel_Click (object sender, System.EventArgs e)
		{
			Control Sender = (Control)sender;
			foreach (Control control in TechPanel.Controls)
				if (!control.Name.StartsWith("label"))
					control.BackColor = Color.Empty;

			Sender.BackColor = Color.Red;
			DevelopmentsPanel.BackColor = Color.Maroon;
			ResearchCheckedListBox.Enabled = true;
			_selectedTech = (TreeRoot)int.Parse(Sender.Tag.ToString());

			UpdateResearchList();
		}

		/// <summary>
		/// Updates the Research list with the appropriate items
		/// </summary>
		private void UpdateResearchList ()
		{
			if (_selectedTeam == null)
				return;

			PopulateObjectList(_selectedTeam, (ObjectList)ObjectsListBox.Tag);
			if (_selectedTech == TreeRoot.None)
				return;

			ResearchCheckedListBox.SuspendLayout();
			ItemCheckEventHandler Handler = new ItemCheckEventHandler(ResearchCheckedListBox_ItemCheck);

			ResearchCheckedListBox.ItemCheck -= Handler;
			ResearchCheckedListBox.Items.Clear();
			
			BitArray CalculatedDefs = _selectedTeam.CalculateDefs();
			if (_selectedTech == TreeRoot.Construction)
			{	// Show stations
				foreach (IGCCoreStationType Station in _game.Core.StationTypes)
				{
					BitArray Compared = (BitArray)CalculatedDefs.Clone();
					Compared.And(Station.Techtree.Pres);
					if (Station.Techtree.PreEquals(Compared))
					{
						// If the overriding station is already bought, don't show this one!
						IGCCoreObject OverridingStation = _game.Core.StationTypes.GetObject((ushort)Station.OverridingUID);
						if (_selectedTeam.Stations.Contains(OverridingStation))
							continue;

						CheckState State = CheckState.Unchecked;
						int StationCount = 0;
						foreach (IGCCoreStationType Stat in _selectedTeam.Stations)
						{
							if (Stat.UID == Station.UID)
								StationCount++;
						}
						if (StationCount > 0)
						{
							State = CheckState.Checked;

							for (int i = 0; i < StationCount; i++)
								ResearchCheckedListBox.Items.Add(Station, State);
						}
						else
						{
							ResearchCheckedListBox.Items.Add(Station, State);
						}
					}
				}
			}
			else
			{	// Show research
				BitArray Empty = new BitArray(400, false);
				foreach (IGCCoreDevel Devel in _game.Core.Developments)
				{
					BitArray Compared = (BitArray)CalculatedDefs.Clone();
					Compared.And(Devel.Techtree.Pres);
					if (Devel.Root_Tree == _selectedTech)
					{ // If devel is in current techtree...
						if (Devel.Techtree.PreEquals(Compared))
						{ // If development is available
							CheckState State = CheckState.Unchecked;
							if (Devel.Techtree.DefEquals(Empty))
							{ // Devel doesn't define anything, so check it only if it's been researched.
								State = (_selectedTeam.Research.Contains(Devel)) ? CheckState.Checked : CheckState.Unchecked;
							}
							else
							{ // Devel defines stuff! Check it if that stuff is defined
								Compared = (BitArray)CalculatedDefs.Clone();
								Compared.And(Devel.Techtree.Defs);
								State = (Devel.Techtree.DefEquals(Compared)) ? CheckState.Checked : CheckState.Unchecked;
							}
							ResearchCheckedListBox.Items.Add(Devel, State);
						}
					}
				}
			}
			ResearchCheckedListBox.ItemCheck += Handler;
			ResearchCheckedListBox.ResumeLayout();
			TotalCostLabel.Text = _selectedTeam.CalculateTotalCost().ToString() + "cr";
		}

		/// <summary>
		/// Adds and removes the selected station or development item from the team
		/// </summary>
		private void ResearchCheckedListBox_ItemCheck (object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (Control.ModifierKeys != Keys.None)
				return;		// If user is adding/removing a station manually, don't process!

			IGCCoreObject Module = (IGCCoreObject)ResearchCheckedListBox.Items[e.Index];
			ObjectList List = null;

			if (_selectedTech == TreeRoot.Construction)
				List = _selectedTeam.Stations;
			else
				List = _selectedTeam.Research;

			if (e.NewValue == CheckState.Checked)
			{	// User checked the box. 
				if (!List.Contains(Module))
				{	// Add the item to the list
					List.Add(Module);

					if (Module is IGCCoreDevel)
					{
						// Check to see if this devel upgraded a station
						BitArray CurrentDefs = _selectedTeam.CalculateDefs();
						BitArray WorkingDefs;
						for (int i = 0; i < _selectedTeam.Stations.Count; i++)
						{
							IGCCoreStationType Station = (IGCCoreStationType)_selectedTeam.Stations[i];
							short OverrideID = Station.OverridingUID;
							if (OverrideID != -1)
							{	// If the station has an upgrade, check it...
								IGCCoreStationType OverridingStation = (IGCCoreStationType)_game.Core.StationTypes.GetObject((ushort)OverrideID);
								if (!_selectedTeam.Stations.Contains(OverridingStation))
								{	// If we don't already have it...
									WorkingDefs = (BitArray)CurrentDefs.Clone();
									WorkingDefs.And(OverridingStation.Techtree.Pres);
									if (OverridingStation.Techtree.PreEquals(WorkingDefs))	// If we have all the prereqs
										_selectedTeam.Stations.Add(OverridingStation);		// Add it!
								}
							}
						}
					}
				}
			}
			else
			{
				if (Module.ModuleType == AGCObjectType.AGC_StationType)
				{
					if (List.Count == 1)	// Prevent user from removing the last base!
					{
						e.NewValue = CheckState.Checked;
						DevelopmentsPanel.Tag = ResearchCheckedListBox.TopIndex;
						ResearchCheckedListBox.Tag = ResearchCheckedListBox.SelectedItem;
						return;
					}
				}
				List.Remove(Module);
				// Remove any dependant developments...
				if (_selectedTech != TreeRoot.Construction)
				{
					BitArray CurrentDefs = _selectedTeam.CalculateDefs();
					for (int i = 0; i < _selectedTeam.Research.Count; i++)
					{
						BitArray WorkingDefs = (BitArray)CurrentDefs.Clone();
						IGCCoreDevel Dev = (IGCCoreDevel)_selectedTeam.Research[i];
						WorkingDefs.And(Dev.Techtree.Pres);
						if (!Dev.Techtree.PreEquals(WorkingDefs))
						{
							_selectedTeam.Research.Remove(Dev);
							i--;
						}
					}
				}
			}
			foreach (Team Team in _game.Teams)
				foreach (AllegObject Obj in Team.OpenObjects)
					Obj.Update();

			DevelopmentsPanel.Tag = ResearchCheckedListBox.TopIndex;
			ResearchCheckedListBox.Tag = ResearchCheckedListBox.SelectedItem;
		}

		private void ResearchCheckedListBox_SelectedIndexChanged (object sender, System.EventArgs e)
		{
			Object obj = ResearchCheckedListBox.SelectedItem;
			if (obj is IGCCoreDevel)
				ResearchCostLabel.Text = ((IGCCoreDevel)obj).Cost.ToString() + "cr";
			else if (obj is IGCCoreStationType)
				ResearchCostLabel.Text = ((IGCCoreStationType)obj).Cost.ToString() + "cr";
		}

		private void ResearchCheckedListBox_MouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_selectedTeam == null || _selectedTech == TreeRoot.None || DevelopmentsPanel.Tag == null || ResearchCheckedListBox.Tag == null)
				return;

			if (_selectedTech == TreeRoot.Construction && Control.ModifierKeys != Keys.None)
			{
				int SelectedIndex = ResearchCheckedListBox.SelectedIndex;
				if (SelectedIndex < 0)
					return;
		
				IGCCoreStationType Station = (IGCCoreStationType)ResearchCheckedListBox.Items[SelectedIndex];

				if (Control.ModifierKeys == Keys.Shift)
					_selectedTeam.Stations.Add(Station);

				Application.DoEvents();
			}

			UpdateResearchList();
			ResearchCheckedListBox.TopIndex = int.Parse(DevelopmentsPanel.Tag.ToString());
			ResearchCheckedListBox.SelectedItem = ResearchCheckedListBox.Tag;
		}

		private void ResearchCheckedListBox_KeyUp (object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (_selectedTeam == null || _selectedTech == TreeRoot.None || e.KeyCode != Keys.Space)
				return;

			UpdateResearchList();
			ResearchCheckedListBox.TopIndex = int.Parse(DevelopmentsPanel.Tag.ToString());
			ResearchCheckedListBox.SelectedItem = ResearchCheckedListBox.Tag;
		}

		/// <summary>
		/// Builds all possible stations, and their overrides if specified
		/// </summary>
		/// <param name="buildOverrides"></param>
		private void BuildStations (bool buildOverrides)
		{
			BitArray CurrentDefs = _selectedTeam.CalculateDefs();
			foreach (IGCCoreStationType Station in _game.Core.StationTypes)
			{
				BitArray WorkingDefs = (BitArray)CurrentDefs.Clone();
				WorkingDefs.And(Station.Techtree.Pres);
				if (Station.Techtree.PreEquals(WorkingDefs))
				{	// Station is available!
					if (!_selectedTeam.Stations.Contains(Station))
						_selectedTeam.Stations.Add(Station);

					if (buildOverrides == true)
					{	// Add all overriding stations
						IGCCoreStationType OverridingStation = Station;
						while ((OverridingStation = (IGCCoreStationType)_game.Core.StationTypes.GetObject((ushort)OverridingStation.OverridingUID)) != null)
						{
							if (!_selectedTeam.Stations.Contains(OverridingStation))
								_selectedTeam.Stations.Add(OverridingStation);
						}
					}
				}
			}
		}

		/// <summary>
		/// Researches all of the next-available developments, or all if specified.
		/// </summary>
		private void ResearchDevelopments (bool researchAll)
		{
			bool ResearchAdded = true;
			while (researchAll == false || (researchAll == true && ResearchAdded == true))
			{
				ResearchAdded = false;
				BitArray CalculatedDefs = _selectedTeam.CalculateDefs();
				foreach (IGCCoreDevel Devel in _game.Core.Developments)
				{
					BitArray Compared = (BitArray)CalculatedDefs.Clone();
					Compared.And(Devel.Techtree.Pres);
					if (Devel.Techtree.PreEquals(Compared))
					{	// Development is available
						if (!_selectedTeam.Research.Contains(Devel))	// Add it!
						{
							_selectedTeam.Research.Add(Devel);
							ResearchAdded = true;
						}

					}
				}
				if (researchAll == false)
					break;
			}
		}

		private void ResearchNoneButton_Click (object sender, System.EventArgs e)
		{
			_selectedTeam.Stations.Clear();
			_selectedTeam.Research.Clear();
			_selectedTeam.Stations.Add(_game.Core.StationTypes.GetObject(_selectedTeam.Faction.Garrison_UID));
			
			UpdateResearchList();
			foreach (AllegObject Obj in _selectedTeam.OpenObjects)
				Obj.Update();
		}

		private void ResearchMK1Button_Click (object sender, System.EventArgs e)
		{
			_selectedTeam.Research.Clear();
			_selectedTeam.Stations.Clear();
			_selectedTeam.Stations.Add(_game.Core.StationTypes.GetObject(_selectedTeam.Faction.Garrison_UID));

			BuildStations(false);
			ResearchDevelopments(false);

			UpdateResearchList();
			foreach (AllegObject Obj in _selectedTeam.OpenObjects)
				Obj.Update();
		}

		private void ResearchMK2Button_Click (object sender, System.EventArgs e)
		{
			_selectedTeam.Research.Clear();
			_selectedTeam.Stations.Clear();
			_selectedTeam.Stations.Add(_game.Core.StationTypes.GetObject(_selectedTeam.Faction.Garrison_UID));

			BuildStations(true);
			ResearchDevelopments(false);
			BuildStations(true);
			ResearchDevelopments(false);

			UpdateResearchList();
			foreach (AllegObject Obj in _selectedTeam.OpenObjects)
				Obj.Update();
		}

		private void ResearchAllButton_Click (object sender, System.EventArgs e)
		{
			// Clear current stations/defs
			_selectedTeam.Stations.Clear();
			_selectedTeam.Research.Clear();
			_selectedTeam.Stations.Add(_game.Core.StationTypes.GetObject(_selectedTeam.Faction.Garrison_UID));

			// Add all stations
			BuildStations(true);
			BuildStations(true);	// Doubled for shipyard/other stations that require MK2 buildings

			// Research all developments
			ResearchDevelopments(true);
			BuildStations(true);	// Added for RPS-like stations that require research first
			ResearchDevelopments(true);

			UpdateResearchList();
			foreach (AllegObject Obj in _selectedTeam.OpenObjects)
				Obj.Update();
		}

		private void QuickDevelPanel_MouseEnter (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.QuickDevelHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Quickly research Mark 1, 2, or all tech</b>\r\n<hr=100%>\r\nUse these buttons to quickly develop\r\neverything by 1 level, 2 levels, or\r\nmax out research with a single click";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, QuickDevelPanel, true, BalloonDirection.BALLOON_LEFT_BOTTOM, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.QuickDevelHelpShown = true;
			}
		}

		private void ResearchCostLabel_MouseEnter (object sender, System.EventArgs e)
		{
			ResearchCostTimer.Enabled = true;
		}

		private void ResearchCostTimer_Tick(object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.ResearchCostHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Research cost is shown here</b>\r\n<hr=100%>\r\nThe selected item's cost is shown on top\r\nand the total cost is shown below\r\n\r\nTIP: You can research multiples of each base\r\nby holding <u>Shift<//u> while clicking it";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, TotalCostLabel, true, BalloonDirection.BALLOON_LEFT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.ResearchCostHelpShown = true;
			}
		}
		#endregion

		#region Object Browser Pane

		private void PopulateObjectList (Team team, ObjectList list)
		{
			ObjectsListBox.Items.Clear();
			BitArray CurrentDefs = team.CalculateDefs();
			foreach (IGCCoreObject Obj in list)
			{
				BitArray WorkingDefs = (BitArray)CurrentDefs.Clone();
				WorkingDefs.And(Obj.Techtree.Pres);
				if (Obj.Techtree.PreEquals(WorkingDefs))
				{
					if (!_settings.ShowOverridden)
					{
						IGCCoreObject OverridingObj = null;
						if (Obj is IGCCoreShip)
							OverridingObj = _game.Core.Ships.GetObject((ushort)((IGCCoreShip)Obj).OverridingUID);
						if (Obj is IGCCoreProbe)
							OverridingObj = _game.Core.Probes.GetObject((ushort)((IGCCoreProbe)Obj).OverridingUID);
						if (Obj is IGCCoreStationType)
							OverridingObj = _game.Core.StationTypes.GetObject((ushort)((IGCCoreStationType)Obj).OverridingUID);

						if (OverridingObj != null)
						{
							WorkingDefs = (BitArray)CurrentDefs.Clone();
							WorkingDefs.And(OverridingObj.Techtree.Pres);
							if (OverridingObj.Techtree.PreEquals(WorkingDefs))
								continue;
						}
					}

					ObjectsListBox.Items.Add(Obj);
				}
			}
			ObjectsListBox.Tag = list;
		}

		private void ArrangeComparisions ()
		{
			if (_game == null)
				return;

			int InitialPosition = this.Top + this.Height;
			int PrevTop = InitialPosition;
			int PrevHeight = 0;
			for (int i = 0; i < _game.Comparisons.Count; i++)
			{
				ComparisonForm Comp = (ComparisonForm)_game.Comparisons[i];
				int NewTop = PrevTop + PrevHeight;
				if (NewTop > Screen.PrimaryScreen.WorkingArea.Height)
					NewTop = InitialPosition;

				Comp.Top = NewTop;
				PrevHeight = Comp.Height;
				PrevTop = Comp.Top;
			}
		}

		private void ObjectRadioButton_Click(object sender, System.EventArgs e)
		{
			RadioButton Button = (RadioButton)sender;
			int ListIndex = int.Parse(Button.Tag.ToString());
			ObjectList List;
			switch (ListIndex)
			{
				case 0:
					List = _game.Core.Ships;
					break;
				case 1:
					List = _game.Core.Probes;
					break;
				default:
					List = _game.Core.StationTypes;
					break;
			}
			if (Button.Checked)
				PopulateObjectList(_selectedTeam, List);
		}

		private void ObjectsListBox_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Clicks < 2)
			{
				ListBox List = (ListBox)sender;
				List.SelectedIndex = List.IndexFromPoint(e.X, e.Y);
				if (List.SelectedIndex < 0)
					return;

				IGCCoreObject ClickedObject = (IGCCoreObject)List.Items[List.SelectedIndex];
				if (e.Button == MouseButtons.Left && List.SelectedIndex != -1)
					List.DoDragDrop(List.SelectedIndex.ToString(), DragDropEffects.Link);
			}
		}

		/// <summary>
		/// Retrieves an AllegObject built from the selected object in the ObjectBrowser
		/// </summary>
		/// <returns></returns>
		public AllegObject SelectedObject ()
		{
			if (ObjectsListBox.SelectedIndex < 0)
				return null;

			IGCCoreObject IGCObj = (IGCCoreObject)ObjectsListBox.Items[ObjectsListBox.SelectedIndex];
			AllegObject Obj = null;

			if (IGCObj is IGCCoreShip)
				Obj = new Ship(_selectedTeam, (IGCCoreShip)IGCObj);
			if (IGCObj is IGCCoreStationType)
				Obj = new Station(_selectedTeam, (IGCCoreStationType)IGCObj);
			if (IGCObj is IGCCoreProbe)
				Obj = new Probe(_selectedTeam, (IGCCoreProbe)IGCObj);

			return Obj;
		}

		private void MePanel_DragOver (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			IGCCoreObject DroppedObject = (IGCCoreObject)ObjectsListBox.Items[DroppedIndex];
			if (_selectedTeam == _game.MyTeam && DroppedObject is IGCCoreShip)
				e.Effect = DragDropEffects.Link;
		}

		private void MePanel_DragDrop (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			IGCCoreObject DroppedObject = (IGCCoreObject)ObjectsListBox.Items[DroppedIndex];
			if (_selectedTeam == _game.MyTeam && DroppedObject is IGCCoreShip)
				_game.Me = new Ship(_selectedTeam, (IGCCoreShip)DroppedObject);
		}

		private void TargetPanel_DragOver (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			IGCCoreObject DroppedObject = (IGCCoreObject)ObjectsListBox.Items[DroppedIndex];
			e.Effect = DragDropEffects.Link;
		}

		private void TargetPanel_DragDrop (object sender, System.Windows.Forms.DragEventArgs e)
		{
			int DroppedIndex = int.Parse((string)e.Data.GetData(DataFormats.StringFormat));
			IGCCoreObject DroppedObject = (IGCCoreObject)ObjectsListBox.Items[DroppedIndex];
			if (DroppedObject is IGCCoreShip)
				_game.Target = new Ship(_selectedTeam, (IGCCoreShip)DroppedObject);
			if (DroppedObject is IGCCoreStationType)
				_game.Target = new Station(_selectedTeam, (IGCCoreStationType)DroppedObject);
			if (DroppedObject is IGCCoreProbe)
				_game.Target = new Probe(_selectedTeam, (IGCCoreProbe)DroppedObject);
		}

		private void MeTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_game.Me == null)
				return;

			TextBox Box = (TextBox)sender;
			Box.DoDragDrop((-1).ToString(), DragDropEffects.Link);
		}
		
		private void TargetTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_game.Target == null)
				return;

			TextBox Box = (TextBox)sender;
			Box.DoDragDrop((-2).ToString(), DragDropEffects.Link);
		}

		private void CompareMeButton_Click (object sender, System.EventArgs e)
		{
			ComparisonForm CompForm = null;
			foreach (ComparisonForm Form in _game.Comparisons)
			{
				if (Form.Object1 == _game.Me && Form.Object2 == _game.Target)
				{
					CompForm = Form;
					break;
				}
			}
			if (CompForm == null)
				CompForm = new ComparisonForm(_game, _game.Me, _game.Target, _settings);

			CompForm.Show();
			ArrangeComparisions();
		}

		private void ObjectsListBoxContextMenu_Popup (object sender, System.EventArgs e)
		{
			if (_selectedTeam == _game.MyTeam && (ObjectList)ObjectsListBox.Tag == _game.Core.Ships)
				SetMeMenuItem.Visible = true;
			else
				SetMeMenuItem.Visible = false;
		}

		private void ObjectInfoMenuItem_Click (object sender, System.EventArgs e)
		{
			if (ObjectsListBox.SelectedIndex < 0)
				return;

			ObjectForm OForm = null;
			IGCCoreObject Obj = (IGCCoreObject)ObjectsListBox.Items[ObjectsListBox.SelectedIndex];
			if (Obj is IGCCoreShip)
			{
				Ship NewShip = new Ship(_selectedTeam, (IGCCoreShip)Obj);
				_selectedTeam.OpenObjects.Add(NewShip);
				OForm = new ShipForm(_settings, NewShip);
			}
			if (Obj is IGCCoreStationType)
			{
				Station NewStation = new Station(_selectedTeam, (IGCCoreStationType)Obj);
				_selectedTeam.OpenObjects.Add(NewStation);
				OForm = new StationForm(_settings, NewStation);
			}
			if (Obj is IGCCoreProbe)
			{
				Probe NewProbe = new Probe(_selectedTeam, (IGCCoreProbe)Obj);
				_selectedTeam.OpenObjects.Add(NewProbe);
				OForm = new ProbeForm(_settings, NewProbe);
			}

			if (OForm != null)
				OForm.Show();
		}

		private void SetMeMenuItem_Click (object sender, System.EventArgs e)
		{
			if (ObjectsListBox.SelectedIndex < 0 || _selectedTeam != _game.MyTeam)
				return;

			IGCCoreObject Obj = (IGCCoreObject)ObjectsListBox.Items[ObjectsListBox.SelectedIndex];
			if (Obj is IGCCoreShip)
			{
				_game.Me = new Ship(_selectedTeam, (IGCCoreShip)Obj);
			}
		}

		private void SetTargetMenuItem_Click (object sender, System.EventArgs e)
		{
			if (ObjectsListBox.SelectedIndex < 0)
				return;

			IGCCoreObject Obj = (IGCCoreObject)ObjectsListBox.Items[ObjectsListBox.SelectedIndex];
			if (Obj is IGCCoreShip)
				_game.Target = new Ship(_selectedTeam, (IGCCoreShip)Obj);
			if (Obj is IGCCoreStationType)
				_game.Target = new Station(_selectedTeam, (IGCCoreStationType)Obj);
			if (Obj is IGCCoreProbe)
				_game.Target = new Probe(_selectedTeam, (IGCCoreProbe)Obj);
		}

		private void CompareToMenuItem_Click (object sender, System.EventArgs e)
		{
			if (ObjectsListBox.SelectedIndex < 0)
				return;
			
			AllegObject AObj = null;
			IGCCoreObject Obj = (IGCCoreObject)ObjectsListBox.Items[ObjectsListBox.SelectedIndex];
			if (Obj is IGCCoreShip)
				AObj = new Ship(_selectedTeam, (IGCCoreShip)Obj);
			if (Obj is IGCCoreStationType)
				AObj = new Station(_selectedTeam, (IGCCoreStationType)Obj);
			if (Obj is IGCCoreProbe)
				AObj = new Probe(_selectedTeam, (IGCCoreProbe)Obj);


			ComparisonForm Comp = new ComparisonForm(_game, AObj, _settings);
			Comp.Left = this.Left;
			Comp.Show();
			ArrangeComparisions();
		}

		#endregion

		private void MainForm_Activated (object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				if (_game == null)
					return;
				foreach (ComparisonForm Comp in _game.Comparisons)
					if (Comp.WindowState == FormWindowState.Minimized)
						Comp.WindowState = FormWindowState.Normal;
			}
		}

		private void MeChangedHandler (object sender, EventArgs e)
		{
			AllegObject obj = (AllegObject)sender;

			if (_game.Me != null && _game.Target != null)
				this.CompareMeButton.Enabled = true;
			else
				this.CompareMeButton.Enabled = false;

			if (_game.Me != null)
				MeTextBox.Text = _game.Me.ToString();
			else
				MeTextBox.Text = string.Empty;
		}

		private void TargetChangedHandler (object sender, EventArgs e)
		{
			AllegObject obj = (AllegObject)sender;

			if (_game.Me != null && _game.Target != null)
				this.CompareMeButton.Enabled = true;
			else
				this.CompareMeButton.Enabled = false;

			if (_game.Target != null)
				TargetTextBox.Text = _game.Target.ToString();
			else
				TargetTextBox.Text = string.Empty;
		}

		private void ObjectsListBox_MouseEnter (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.ObjectBrowserHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Rightclick these items to do stuff!</b>\r\n<hr=100%>\r\nYou can view it's info, and launch a \r\nnew comparison with \"<u>Compare to...</u>\"\r\n\r\nYou can also drag these items above to\r\nset \"<u>Me</u>\" or \"<u>Target</u>\"";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, ObjectsListBox, true, BalloonDirection.BALLOON_LEFT_BOTTOM, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.ObjectBrowserHelpShown = true;
			}
		}

		private void ObjectsListBox_DoubleClick (object sender, System.EventArgs e)
		{
			AllegObject NewObj = this.SelectedObject();
			ObjectForm ObjForm = null;
			if (NewObj != null)
			{
				if (NewObj is Probe)
					ObjForm = new ProbeForm(_settings, (Probe)NewObj);
				if (NewObj is Ship)
					ObjForm = new ShipForm(_settings, (Ship)NewObj);
				if (NewObj is Station)
					ObjForm = new StationForm(_settings, (Station)NewObj);

				if (ObjForm != null)
					ObjForm.Show();

				_selectedTeam.OpenObjects.Add(NewObj);
			}
		}

		/// <summary>
		/// Exposes the TekSettings object to child forms
		/// </summary>
		public TekSettings Settings
		{
			get {return _settings;}
		}

		/// <summary>
		/// Exposes the user-chosen core path
		/// </summary>
		public string CorePath
		{
			get {return _corePath;}
		}

		/// <summary>
		/// Exposes the current Allegiance Game
		/// </summary>
		public Game Game
		{
			get {return _game;}
		}
	}
}
