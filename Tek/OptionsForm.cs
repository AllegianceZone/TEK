using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// The form that allows the user to change the Kneeboard's settings
	/// </summary>
	public class OptionsForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.Panel StartupOptionsPanel;
		private System.Windows.Forms.Label StartupOptionsLabel;
		private System.Windows.Forms.RadioButton LoadPreviousCoreRadioButton;
		private System.Windows.Forms.RadioButton LoadLastPlayedRadioButton;
		private System.Windows.Forms.RadioButton LoadThisCoreRadioButton;
		private System.Windows.Forms.TextBox LoadThisCoreTextBox;
		private System.Windows.Forms.Button BrowseCoreButton;
		private System.Windows.Forms.Panel RecentCoresPanel;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.Label RecentCoresLabel;
		private System.Windows.Forms.Button OptionsCancelButton;
		private System.Windows.Forms.Button OptionsOKButton;
		private System.Windows.Forms.RadioButton DoNothingRadioButton;
		private System.Windows.Forms.CheckBox RememberRecentCoresCheckBox;
		private System.Windows.Forms.OpenFileDialog CoreOpenFileDialog;
		private System.Windows.Forms.Label NumTeamsLabel;
		private System.Windows.Forms.NumericUpDown NumberOfTeamsNumericUpDown;
		private System.Windows.Forms.Panel CoreLocationPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.Windows.Forms.TextBox DefaultCoreLocationTextBox;
		private System.Windows.Forms.FolderBrowserDialog DefaultCoreLocationFolderBrowserDialog;
		private System.Windows.Forms.Button BrowseDefaultCoreLocationButton;
		private System.Windows.Forms.CheckBox ShowToolTipsCheckBox;
		private System.ComponentModel.IContainer components;
		#endregion
		private System.Windows.Forms.CheckBox ShowBalloonHelpCheckBox;
		private System.Windows.Forms.Timer HelpBalloonTimer;
		private System.Windows.Forms.Button AboutButton;
		private System.Windows.Forms.Button ClearHelpButton;
		private System.Windows.Forms.CheckBox ShowOverriddenCheckBox;

		TekSettings _settings;
		bool _clearRecent = false;

		public OptionsForm (MainForm mainForm)
		{
			InitializeComponent();
			this.Icon = mainForm.Icon;
			_settings = mainForm.Settings;
			CoreOpenFileDialog.InitialDirectory = mainForm.CorePath;
			LoadSettings(_settings);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OptionsForm));
			this.StartupOptionsPanel = new System.Windows.Forms.Panel();
			this.ClearHelpButton = new System.Windows.Forms.Button();
			this.ShowBalloonHelpCheckBox = new System.Windows.Forms.CheckBox();
			this.ShowToolTipsCheckBox = new System.Windows.Forms.CheckBox();
			this.NumTeamsLabel = new System.Windows.Forms.Label();
			this.NumberOfTeamsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.DoNothingRadioButton = new System.Windows.Forms.RadioButton();
			this.BrowseCoreButton = new System.Windows.Forms.Button();
			this.LoadThisCoreTextBox = new System.Windows.Forms.TextBox();
			this.LoadThisCoreRadioButton = new System.Windows.Forms.RadioButton();
			this.LoadLastPlayedRadioButton = new System.Windows.Forms.RadioButton();
			this.LoadPreviousCoreRadioButton = new System.Windows.Forms.RadioButton();
			this.StartupOptionsLabel = new System.Windows.Forms.Label();
			this.RecentCoresPanel = new System.Windows.Forms.Panel();
			this.ClearButton = new System.Windows.Forms.Button();
			this.RecentCoresLabel = new System.Windows.Forms.Label();
			this.RememberRecentCoresCheckBox = new System.Windows.Forms.CheckBox();
			this.OptionsCancelButton = new System.Windows.Forms.Button();
			this.OptionsOKButton = new System.Windows.Forms.Button();
			this.CoreOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CoreLocationPanel = new System.Windows.Forms.Panel();
			this.BrowseDefaultCoreLocationButton = new System.Windows.Forms.Button();
			this.DefaultCoreLocationTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.DefaultCoreLocationFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.AboutButton = new System.Windows.Forms.Button();
			this.HelpBalloonTimer = new System.Windows.Forms.Timer(this.components);
			this.ShowOverriddenCheckBox = new System.Windows.Forms.CheckBox();
			this.StartupOptionsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumberOfTeamsNumericUpDown)).BeginInit();
			this.RecentCoresPanel.SuspendLayout();
			this.CoreLocationPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// StartupOptionsPanel
			// 
			this.StartupOptionsPanel.Controls.Add(this.AboutButton);
			this.StartupOptionsPanel.Controls.Add(this.ClearHelpButton);
			this.StartupOptionsPanel.Controls.Add(this.ShowBalloonHelpCheckBox);
			this.StartupOptionsPanel.Controls.Add(this.ShowToolTipsCheckBox);
			this.StartupOptionsPanel.Controls.Add(this.NumTeamsLabel);
			this.StartupOptionsPanel.Controls.Add(this.NumberOfTeamsNumericUpDown);
			this.StartupOptionsPanel.Controls.Add(this.DoNothingRadioButton);
			this.StartupOptionsPanel.Controls.Add(this.BrowseCoreButton);
			this.StartupOptionsPanel.Controls.Add(this.LoadThisCoreTextBox);
			this.StartupOptionsPanel.Controls.Add(this.LoadThisCoreRadioButton);
			this.StartupOptionsPanel.Controls.Add(this.LoadLastPlayedRadioButton);
			this.StartupOptionsPanel.Controls.Add(this.LoadPreviousCoreRadioButton);
			this.StartupOptionsPanel.Controls.Add(this.StartupOptionsLabel);
			this.StartupOptionsPanel.Location = new System.Drawing.Point(0, 0);
			this.StartupOptionsPanel.Name = "StartupOptionsPanel";
			this.StartupOptionsPanel.Size = new System.Drawing.Size(264, 112);
			this.StartupOptionsPanel.TabIndex = 0;
			// 
			// ClearHelpButton
			// 
			this.ClearHelpButton.BackColor = System.Drawing.Color.Maroon;
			this.ClearHelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClearHelpButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ClearHelpButton.Location = new System.Drawing.Point(208, 40);
			this.ClearHelpButton.Name = "ClearHelpButton";
			this.ClearHelpButton.Size = new System.Drawing.Size(40, 18);
			this.ClearHelpButton.TabIndex = 11;
			this.ClearHelpButton.Text = "Clear";
			this.InfoToolTip.SetToolTip(this.ClearHelpButton, "Resets this session\'s HelpBalloon usage data so HelpBalloons are once again shown" +
				"");
			this.ClearHelpButton.Click += new System.EventHandler(this.ClearHelpButton_Click);
			// 
			// ShowBalloonHelpCheckBox
			// 
			this.ShowBalloonHelpCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShowBalloonHelpCheckBox.Location = new System.Drawing.Point(132, 40);
			this.ShowBalloonHelpCheckBox.Name = "ShowBalloonHelpCheckBox";
			this.ShowBalloonHelpCheckBox.Size = new System.Drawing.Size(80, 16);
			this.ShowBalloonHelpCheckBox.TabIndex = 8;
			this.ShowBalloonHelpCheckBox.Text = "Show Help";
			this.InfoToolTip.SetToolTip(this.ShowBalloonHelpCheckBox, "Shows or hides the tutorial HelpBalloons");
			// 
			// ShowToolTipsCheckBox
			// 
			this.ShowToolTipsCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShowToolTipsCheckBox.Location = new System.Drawing.Point(132, 24);
			this.ShowToolTipsCheckBox.Name = "ShowToolTipsCheckBox";
			this.ShowToolTipsCheckBox.Size = new System.Drawing.Size(104, 16);
			this.ShowToolTipsCheckBox.TabIndex = 7;
			this.ShowToolTipsCheckBox.Text = "Show ToolTips";
			this.InfoToolTip.SetToolTip(this.ShowToolTipsCheckBox, "Show ToolTips when hovering the mouse over controls");
			// 
			// NumTeamsLabel
			// 
			this.NumTeamsLabel.Location = new System.Drawing.Point(144, 66);
			this.NumTeamsLabel.Name = "NumTeamsLabel";
			this.NumTeamsLabel.Size = new System.Drawing.Size(64, 16);
			this.NumTeamsLabel.TabIndex = 9;
			this.NumTeamsLabel.Text = "# Teams:";
			// 
			// NumberOfTeamsNumericUpDown
			// 
			this.NumberOfTeamsNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.NumberOfTeamsNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NumberOfTeamsNumericUpDown.Enabled = false;
			this.NumberOfTeamsNumericUpDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NumberOfTeamsNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.NumberOfTeamsNumericUpDown.Location = new System.Drawing.Point(208, 64);
			this.NumberOfTeamsNumericUpDown.Maximum = new System.Decimal(new int[] {
																					   6,
																					   0,
																					   0,
																					   0});
			this.NumberOfTeamsNumericUpDown.Minimum = new System.Decimal(new int[] {
																					   2,
																					   0,
																					   0,
																					   0});
			this.NumberOfTeamsNumericUpDown.Name = "NumberOfTeamsNumericUpDown";
			this.NumberOfTeamsNumericUpDown.Size = new System.Drawing.Size(40, 21);
			this.NumberOfTeamsNumericUpDown.TabIndex = 10;
			this.InfoToolTip.SetToolTip(this.NumberOfTeamsNumericUpDown, "The number of teams in the automatically-created game");
			this.NumberOfTeamsNumericUpDown.Value = new System.Decimal(new int[] {
																					 2,
																					 0,
																					 0,
																					 0});
			// 
			// DoNothingRadioButton
			// 
			this.DoNothingRadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DoNothingRadioButton.Location = new System.Drawing.Point(8, 24);
			this.DoNothingRadioButton.Name = "DoNothingRadioButton";
			this.DoNothingRadioButton.Size = new System.Drawing.Size(80, 16);
			this.DoNothingRadioButton.TabIndex = 1;
			this.DoNothingRadioButton.Text = "Do Nothing";
			this.InfoToolTip.SetToolTip(this.DoNothingRadioButton, "TEK will launch and not load anything once started");
			this.DoNothingRadioButton.CheckedChanged += new System.EventHandler(this.DoNothingRadioButton_CheckedChanged);
			// 
			// BrowseCoreButton
			// 
			this.BrowseCoreButton.BackColor = System.Drawing.Color.Maroon;
			this.BrowseCoreButton.Enabled = false;
			this.BrowseCoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BrowseCoreButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BrowseCoreButton.Location = new System.Drawing.Point(216, 92);
			this.BrowseCoreButton.Name = "BrowseCoreButton";
			this.BrowseCoreButton.Size = new System.Drawing.Size(32, 16);
			this.BrowseCoreButton.TabIndex = 6;
			this.BrowseCoreButton.Text = "...";
			this.BrowseCoreButton.Click += new System.EventHandler(this.BrowseCoreButton_Click);
			// 
			// LoadThisCoreTextBox
			// 
			this.LoadThisCoreTextBox.AutoSize = false;
			this.LoadThisCoreTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LoadThisCoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LoadThisCoreTextBox.Enabled = false;
			this.LoadThisCoreTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LoadThisCoreTextBox.ForeColor = System.Drawing.Color.White;
			this.LoadThisCoreTextBox.Location = new System.Drawing.Point(8, 92);
			this.LoadThisCoreTextBox.Name = "LoadThisCoreTextBox";
			this.LoadThisCoreTextBox.Size = new System.Drawing.Size(200, 16);
			this.LoadThisCoreTextBox.TabIndex = 5;
			this.LoadThisCoreTextBox.Text = "";
			// 
			// LoadThisCoreRadioButton
			// 
			this.LoadThisCoreRadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LoadThisCoreRadioButton.Location = new System.Drawing.Point(8, 72);
			this.LoadThisCoreRadioButton.Name = "LoadThisCoreRadioButton";
			this.LoadThisCoreRadioButton.Size = new System.Drawing.Size(104, 16);
			this.LoadThisCoreRadioButton.TabIndex = 4;
			this.LoadThisCoreRadioButton.Text = "Load This Core:";
			this.InfoToolTip.SetToolTip(this.LoadThisCoreRadioButton, "TEK will always load the core specified below");
			this.LoadThisCoreRadioButton.CheckedChanged += new System.EventHandler(this.LoadThisCoreRadioButton_CheckedChanged);
			// 
			// LoadLastPlayedRadioButton
			// 
			this.LoadLastPlayedRadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LoadLastPlayedRadioButton.Location = new System.Drawing.Point(8, 56);
			this.LoadLastPlayedRadioButton.Name = "LoadLastPlayedRadioButton";
			this.LoadLastPlayedRadioButton.Size = new System.Drawing.Size(136, 16);
			this.LoadLastPlayedRadioButton.TabIndex = 3;
			this.LoadLastPlayedRadioButton.Text = "Load Last-Played Core";
			this.InfoToolTip.SetToolTip(this.LoadLastPlayedRadioButton, "BUGGY: TEK will attempt to load the last core you played in Allegiance");
			// 
			// LoadPreviousCoreRadioButton
			// 
			this.LoadPreviousCoreRadioButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LoadPreviousCoreRadioButton.Location = new System.Drawing.Point(8, 40);
			this.LoadPreviousCoreRadioButton.Name = "LoadPreviousCoreRadioButton";
			this.LoadPreviousCoreRadioButton.Size = new System.Drawing.Size(120, 16);
			this.LoadPreviousCoreRadioButton.TabIndex = 2;
			this.LoadPreviousCoreRadioButton.Text = "Load Previous Core";
			this.InfoToolTip.SetToolTip(this.LoadPreviousCoreRadioButton, "TEK will load the last core opened in CoreTool");
			// 
			// StartupOptionsLabel
			// 
			this.StartupOptionsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.StartupOptionsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.StartupOptionsLabel.Location = new System.Drawing.Point(0, 5);
			this.StartupOptionsLabel.Name = "StartupOptionsLabel";
			this.StartupOptionsLabel.Size = new System.Drawing.Size(264, 16);
			this.StartupOptionsLabel.TabIndex = 0;
			this.StartupOptionsLabel.Text = "Startup Options";
			// 
			// RecentCoresPanel
			// 
			this.RecentCoresPanel.Controls.Add(this.ClearButton);
			this.RecentCoresPanel.Controls.Add(this.RecentCoresLabel);
			this.RecentCoresPanel.Controls.Add(this.RememberRecentCoresCheckBox);
			this.RecentCoresPanel.Location = new System.Drawing.Point(0, 112);
			this.RecentCoresPanel.Name = "RecentCoresPanel";
			this.RecentCoresPanel.Size = new System.Drawing.Size(264, 48);
			this.RecentCoresPanel.TabIndex = 2;
			// 
			// ClearButton
			// 
			this.ClearButton.BackColor = System.Drawing.Color.Maroon;
			this.ClearButton.Enabled = false;
			this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ClearButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ClearButton.Location = new System.Drawing.Point(184, 26);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(64, 20);
			this.ClearButton.TabIndex = 2;
			this.ClearButton.Text = "Clear";
			this.InfoToolTip.SetToolTip(this.ClearButton, "Clears all Recent Cores from the rightclick menu on the \"New Game\" screen");
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// RecentCoresLabel
			// 
			this.RecentCoresLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.RecentCoresLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.RecentCoresLabel.Location = new System.Drawing.Point(0, 5);
			this.RecentCoresLabel.Name = "RecentCoresLabel";
			this.RecentCoresLabel.Size = new System.Drawing.Size(264, 16);
			this.RecentCoresLabel.TabIndex = 0;
			this.RecentCoresLabel.Text = "Recent Cores";
			// 
			// RememberRecentCoresCheckBox
			// 
			this.RememberRecentCoresCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.RememberRecentCoresCheckBox.Location = new System.Drawing.Point(8, 28);
			this.RememberRecentCoresCheckBox.Name = "RememberRecentCoresCheckBox";
			this.RememberRecentCoresCheckBox.Size = new System.Drawing.Size(152, 16);
			this.RememberRecentCoresCheckBox.TabIndex = 1;
			this.RememberRecentCoresCheckBox.Text = "Remember Recent Cores";
			this.InfoToolTip.SetToolTip(this.RememberRecentCoresCheckBox, "If checked, TEK will remember your most recently loaded cores in a right-click me" +
				"nu on the \"New Game\" screen");
			this.RememberRecentCoresCheckBox.CheckedChanged += new System.EventHandler(this.RememberRecentCoresCheckBox_CheckedChanged);
			// 
			// OptionsCancelButton
			// 
			this.OptionsCancelButton.BackColor = System.Drawing.Color.Maroon;
			this.OptionsCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OptionsCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OptionsCancelButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OptionsCancelButton.Location = new System.Drawing.Point(112, 236);
			this.OptionsCancelButton.Name = "OptionsCancelButton";
			this.OptionsCancelButton.Size = new System.Drawing.Size(64, 23);
			this.OptionsCancelButton.TabIndex = 5;
			this.OptionsCancelButton.Text = "&Cancel";
			this.InfoToolTip.SetToolTip(this.OptionsCancelButton, "Discards changes to the settings and closes this dialog box");
			// 
			// OptionsOKButton
			// 
			this.OptionsOKButton.BackColor = System.Drawing.Color.Maroon;
			this.OptionsOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OptionsOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OptionsOKButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.OptionsOKButton.Location = new System.Drawing.Point(184, 236);
			this.OptionsOKButton.Name = "OptionsOKButton";
			this.OptionsOKButton.Size = new System.Drawing.Size(64, 23);
			this.OptionsOKButton.TabIndex = 6;
			this.OptionsOKButton.Text = "&OK";
			this.InfoToolTip.SetToolTip(this.OptionsOKButton, "Saves settings, then closes this dialog box");
			this.OptionsOKButton.Click += new System.EventHandler(this.OptionsOKButton_Click);
			// 
			// CoreOpenFileDialog
			// 
			this.CoreOpenFileDialog.DefaultExt = "*.igc";
			this.CoreOpenFileDialog.Filter = "Allegiance Core Files (*.igc)|*.igc";
			this.CoreOpenFileDialog.Title = "Choose a Core...";
			// 
			// CoreLocationPanel
			// 
			this.CoreLocationPanel.Controls.Add(this.BrowseDefaultCoreLocationButton);
			this.CoreLocationPanel.Controls.Add(this.DefaultCoreLocationTextBox);
			this.CoreLocationPanel.Controls.Add(this.label1);
			this.CoreLocationPanel.Location = new System.Drawing.Point(0, 164);
			this.CoreLocationPanel.Name = "CoreLocationPanel";
			this.CoreLocationPanel.Size = new System.Drawing.Size(264, 48);
			this.CoreLocationPanel.TabIndex = 3;
			// 
			// BrowseDefaultCoreLocationButton
			// 
			this.BrowseDefaultCoreLocationButton.BackColor = System.Drawing.Color.Maroon;
			this.BrowseDefaultCoreLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BrowseDefaultCoreLocationButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.BrowseDefaultCoreLocationButton.Location = new System.Drawing.Point(216, 28);
			this.BrowseDefaultCoreLocationButton.Name = "BrowseDefaultCoreLocationButton";
			this.BrowseDefaultCoreLocationButton.Size = new System.Drawing.Size(32, 16);
			this.BrowseDefaultCoreLocationButton.TabIndex = 3;
			this.BrowseDefaultCoreLocationButton.Text = "...";
			this.InfoToolTip.SetToolTip(this.BrowseDefaultCoreLocationButton, "Browses for a new default folder");
			this.BrowseDefaultCoreLocationButton.Click += new System.EventHandler(this.BrowseDefaultCoreLocationButton_Click);
			// 
			// DefaultCoreLocationTextBox
			// 
			this.DefaultCoreLocationTextBox.AutoSize = false;
			this.DefaultCoreLocationTextBox.BackColor = System.Drawing.Color.Maroon;
			this.DefaultCoreLocationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DefaultCoreLocationTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DefaultCoreLocationTextBox.ForeColor = System.Drawing.Color.White;
			this.DefaultCoreLocationTextBox.Location = new System.Drawing.Point(8, 28);
			this.DefaultCoreLocationTextBox.Name = "DefaultCoreLocationTextBox";
			this.DefaultCoreLocationTextBox.Size = new System.Drawing.Size(200, 16);
			this.DefaultCoreLocationTextBox.TabIndex = 2;
			this.DefaultCoreLocationTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.DefaultCoreLocationTextBox, "The folder CoreTool will look in when showing the Load Core dialog box. CoreTool " +
				"will use your Allegiance Artwork path if this is empty");
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label1.Location = new System.Drawing.Point(0, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default Core Location";
			// 
			// DefaultCoreLocationFolderBrowserDialog
			// 
			this.DefaultCoreLocationFolderBrowserDialog.Description = "Choose the location where CoreTool will look for core files. Leave this blank for" +
				" CoreTool to use your Allegiance Artwork directory";
			// 
			// AboutButton
			// 
			this.AboutButton.BackColor = System.Drawing.Color.Maroon;
			this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AboutButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AboutButton.Location = new System.Drawing.Point(190, 0);
			this.AboutButton.Name = "AboutButton";
			this.AboutButton.Size = new System.Drawing.Size(64, 21);
			this.AboutButton.TabIndex = 1;
			this.AboutButton.Text = "About...";
			this.InfoToolTip.SetToolTip(this.AboutButton, "Clears all Recent Cores from the rightclick menu on the \"New Game\" screen");
			this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
			// 
			// HelpBalloonTimer
			// 
			this.HelpBalloonTimer.Tick += new System.EventHandler(this.HelpBalloonTimer_Tick);
			// 
			// ShowOverriddenCheckBox
			// 
			this.ShowOverriddenCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ShowOverriddenCheckBox.Location = new System.Drawing.Point(8, 216);
			this.ShowOverriddenCheckBox.Name = "ShowOverriddenCheckBox";
			this.ShowOverriddenCheckBox.Size = new System.Drawing.Size(144, 16);
			this.ShowOverriddenCheckBox.TabIndex = 4;
			this.ShowOverriddenCheckBox.Text = "Show Overridden Items";
			this.InfoToolTip.SetToolTip(this.ShowOverriddenCheckBox, "Shows overridden items like \"Gatt 1\" even if \"Gatt 2\" has been researched");
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.OptionsOKButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.CancelButton = this.OptionsCancelButton;
			this.ClientSize = new System.Drawing.Size(254, 263);
			this.Controls.Add(this.ShowOverriddenCheckBox);
			this.Controls.Add(this.CoreLocationPanel);
			this.Controls.Add(this.OptionsOKButton);
			this.Controls.Add(this.OptionsCancelButton);
			this.Controls.Add(this.RecentCoresPanel);
			this.Controls.Add(this.StartupOptionsPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Kneeboard Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.StartupOptionsPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumberOfTeamsNumericUpDown)).EndInit();
			this.RecentCoresPanel.ResumeLayout(false);
			this.CoreLocationPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Loads the settings into the form
		/// </summary>
		/// <param name="settings"></param>
		private void LoadSettings (TekSettings settings)
		{
			switch ((StartupAction)settings.Startup)
			{
				case StartupAction.DoNothing:
					DoNothingRadioButton.Checked = true;
					break;
				case StartupAction.LoadLastPlayed:
					LoadLastPlayedRadioButton.Checked = true;
					NumberOfTeamsNumericUpDown.Enabled = true;
					break;
				case StartupAction.LoadLastUsed:
					LoadPreviousCoreRadioButton.Checked = true;
					NumberOfTeamsNumericUpDown.Enabled = true;
					break;
				case StartupAction.LoadSpecified:
					LoadThisCoreRadioButton.Checked = true;
					NumberOfTeamsNumericUpDown.Enabled = true;
					break;
				default:
					break;
			}
            
			NumberOfTeamsNumericUpDown.Value = settings.NumTeams;
			LoadThisCoreTextBox.Text = settings.SpecifiedCore;
			LoadThisCoreTextBox.SelectionStart = LoadThisCoreTextBox.Text.Length;
			DefaultCoreLocationTextBox.Text = settings.DefaultCoreLocation;
			RememberRecentCoresCheckBox.Checked = settings.RememberRecentCores;
			ShowToolTipsCheckBox.Checked = settings.ShowToolTips;
			ShowBalloonHelpCheckBox.Checked = settings.ShowBalloonHelp;
			ShowOverriddenCheckBox.Checked = settings.ShowOverridden;
		}

		/// <summary>
		/// Enables and disables the Clear Recent Cores button
		/// </summary>
		private void RememberRecentCoresCheckBox_CheckedChanged (object sender, System.EventArgs e)
		{
			CheckBox Box = (CheckBox)sender;
			ClearButton.Enabled = Box.Checked;
		}

		/// <summary>
		/// Clears the Recent Cores list
		/// </summary>
		private void ClearButton_Click (object sender, System.EventArgs e)
		{
			_clearRecent = true;
			MessageBox.Show(this, "Recent Cores will be cleared when you save settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Enables or disables the core textbox and button
		/// </summary>
		private void LoadThisCoreRadioButton_CheckedChanged (object sender, System.EventArgs e)
		{
			RadioButton radio = (RadioButton)sender;
			LoadThisCoreTextBox.Enabled = radio.Checked;
			BrowseCoreButton.Enabled = radio.Checked;
		}

		/// <summary>
		/// Displays the "Open Core" dialog box
		/// </summary>
		private void BrowseCoreButton_Click (object sender, System.EventArgs e)
		{
			DialogResult Result = CoreOpenFileDialog.ShowDialog(this);
			switch (Result)
			{
				case DialogResult.OK:
					LoadThisCoreTextBox.Text = CoreOpenFileDialog.FileName;
					LoadThisCoreTextBox.SelectionStart = LoadThisCoreTextBox.Text.Length - 1;
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
		}

		private void BrowseDefaultCoreLocationButton_Click(object sender, System.EventArgs e)
		{
			DialogResult Result = DefaultCoreLocationFolderBrowserDialog.ShowDialog(this);
			switch (Result)
			{
				case DialogResult.OK:
					DefaultCoreLocationTextBox.Text = DefaultCoreLocationFolderBrowserDialog.SelectedPath;
					DefaultCoreLocationTextBox.SelectionStart = DefaultCoreLocationTextBox.Text.Length - 1;
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
		}

		/// <summary>
		/// Commits the form's layout to the Settings object
		/// </summary>
		private void OptionsOKButton_Click (object sender, System.EventArgs e)
		{
			if (LoadThisCoreRadioButton.Checked)
			{
				if (!File.Exists(LoadThisCoreTextBox.Text))
				{
					MessageBox.Show(this, "Invalid core path! Settings not saved!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.DialogResult = DialogResult.Cancel;
					return;
				}
			}

			if (DoNothingRadioButton.Checked)
				_settings.Startup = (int)StartupAction.DoNothing;
			else if (LoadLastPlayedRadioButton.Checked)
				_settings.Startup = (int)StartupAction.LoadLastPlayed;
			else if (LoadPreviousCoreRadioButton.Checked)
				_settings.Startup = (int)StartupAction.LoadLastUsed;
			else if (LoadThisCoreRadioButton.Checked)
				_settings.Startup = (int)StartupAction.LoadSpecified;

			_settings.NumTeams = (int)NumberOfTeamsNumericUpDown.Value;
			_settings.SpecifiedCore = LoadThisCoreTextBox.Text;
			_settings.DefaultCoreLocation = DefaultCoreLocationTextBox.Text;
			_settings.RememberRecentCores = RememberRecentCoresCheckBox.Checked;
			_settings.ShowToolTips = ShowToolTipsCheckBox.Checked;
			_settings.ShowBalloonHelp = ShowBalloonHelpCheckBox.Checked;
			_settings.ShowOverridden = ShowOverriddenCheckBox.Checked;
			if (_clearRecent)
				_settings.RecentCores.Clear();
		}

		private void DoNothingRadioButton_CheckedChanged (object sender, System.EventArgs e)
		{
			RadioButton Radio = (RadioButton)sender;
			NumberOfTeamsNumericUpDown.Enabled = !Radio.Checked;
		}

		private void HelpBalloonTimer_Tick (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.OptionsHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Change your core location here</b>\r\n<hr=100%>\r\nIf left blank, TEK will automatically\r\ndetect your <u>Allegiance\\Artwork<//u> folder.\r\n\r\nChange this only if you keep your cores\r\nelsewhere";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, DefaultCoreLocationTextBox, true, BalloonDirection.BALLOON_RIGHT_TOP, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.OptionsHelpShown = true;
			}
			HelpBalloonTimer.Enabled = false;
		}

		private void OptionsForm_Load(object sender, System.EventArgs e)
		{
			HelpBalloonTimer.Enabled = true;
		}

		private void AboutButton_Click(object sender, System.EventArgs e)
		{
			AboutForm About = new AboutForm();
			About.ShowDialog();
			About.Dispose();
		}

		private void ClearHelpButton_Click(object sender, System.EventArgs e)
		{
			HelpBalloon.ResetBalloons();
			MessageBox.Show(this, "All already-seen HelpBalloons will once again pop up.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
