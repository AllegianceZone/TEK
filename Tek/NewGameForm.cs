using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for NewGameForm.
	/// </summary>
	public class NewGameForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.Panel CorePanel;
		private System.Windows.Forms.Label CoreLabel;
		private System.Windows.Forms.TextBox CoreTextBox;
		private System.Windows.Forms.Button BrowseCoreButton;
		private System.Windows.Forms.Panel GameOptionsPanel;
		private System.Windows.Forms.Label GameOptionsLabel;
		private System.Windows.Forms.CheckBox DeathMatchCheckBox;
		private System.Windows.Forms.CheckBox AllowShipyardsCheckBox;
		private System.Windows.Forms.CheckBox AllowDevelopmentCheckBox;
		private System.Windows.Forms.CheckBox CaptureTheFlagCheckBox;
		private System.Windows.Forms.CheckBox AllowArtifactsCheckBox;
		private System.Windows.Forms.CheckBox ProsperityCheckBox;
		private System.Windows.Forms.NumericUpDown NumberOfTeamsNumericUpDown;
		private System.Windows.Forms.Button NewGameCancelButton;
		private System.Windows.Forms.Button NewGameOKButton;
		private System.Windows.Forms.ContextMenu RecentCoresContextMenu;
		private System.Windows.Forms.Label NumTeamsLabel;
		private System.Windows.Forms.OpenFileDialog CoreOpenFileDialog;
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.Windows.Forms.NumericUpDown YourTeamNumericUpDown;
		private System.Windows.Forms.Label YourTeamLabel;
		private System.ComponentModel.IContainer components;
		#endregion

		string[] Cores = null;
		TekSettings _settings;
		string _corePath;

		/// <summary>
		/// Constructs a new NewGameForm
		/// </summary>
		public NewGameForm (TekSettings settings, string corePath)
		{
			InitializeComponent();
			_settings = settings;
			_corePath = corePath;

			InfoToolTip.Active = settings.ShowToolTips;
			CoreOpenFileDialog.InitialDirectory = corePath;
			CoreTextBox.Text = Path.GetFileName(_settings.LastCore);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewGameForm));
			this.CorePanel = new System.Windows.Forms.Panel();
			this.BrowseCoreButton = new System.Windows.Forms.Button();
			this.CoreTextBox = new System.Windows.Forms.TextBox();
			this.RecentCoresContextMenu = new System.Windows.Forms.ContextMenu();
			this.CoreLabel = new System.Windows.Forms.Label();
			this.GameOptionsPanel = new System.Windows.Forms.Panel();
			this.NumberOfTeamsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.NumTeamsLabel = new System.Windows.Forms.Label();
			this.YourTeamNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.YourTeamLabel = new System.Windows.Forms.Label();
			this.ProsperityCheckBox = new System.Windows.Forms.CheckBox();
			this.AllowArtifactsCheckBox = new System.Windows.Forms.CheckBox();
			this.CaptureTheFlagCheckBox = new System.Windows.Forms.CheckBox();
			this.DeathMatchCheckBox = new System.Windows.Forms.CheckBox();
			this.AllowShipyardsCheckBox = new System.Windows.Forms.CheckBox();
			this.AllowDevelopmentCheckBox = new System.Windows.Forms.CheckBox();
			this.GameOptionsLabel = new System.Windows.Forms.Label();
			this.NewGameCancelButton = new System.Windows.Forms.Button();
			this.NewGameOKButton = new System.Windows.Forms.Button();
			this.CoreOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.CorePanel.SuspendLayout();
			this.GameOptionsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumberOfTeamsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.YourTeamNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// CorePanel
			// 
			this.CorePanel.Controls.Add(this.BrowseCoreButton);
			this.CorePanel.Controls.Add(this.CoreTextBox);
			this.CorePanel.Controls.Add(this.CoreLabel);
			this.CorePanel.Location = new System.Drawing.Point(0, 0);
			this.CorePanel.Name = "CorePanel";
			this.CorePanel.Size = new System.Drawing.Size(280, 56);
			this.CorePanel.TabIndex = 0;
			// 
			// BrowseCoreButton
			// 
			this.BrowseCoreButton.BackColor = System.Drawing.Color.Maroon;
			this.BrowseCoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BrowseCoreButton.Location = new System.Drawing.Point(176, 26);
			this.BrowseCoreButton.Name = "BrowseCoreButton";
			this.BrowseCoreButton.Size = new System.Drawing.Size(72, 24);
			this.BrowseCoreButton.TabIndex = 2;
			this.BrowseCoreButton.Text = "Browse...";
			this.InfoToolTip.SetToolTip(this.BrowseCoreButton, "Search for a core file to use in the new game");
			this.BrowseCoreButton.Click += new System.EventHandler(this.BrowseCoreButton_Click);
			// 
			// CoreTextBox
			// 
			this.CoreTextBox.AutoSize = false;
			this.CoreTextBox.BackColor = System.Drawing.Color.Maroon;
			this.CoreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CoreTextBox.ContextMenu = this.RecentCoresContextMenu;
			this.CoreTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CoreTextBox.ForeColor = System.Drawing.Color.White;
			this.CoreTextBox.Location = new System.Drawing.Point(8, 28);
			this.CoreTextBox.MaxLength = 255;
			this.CoreTextBox.Name = "CoreTextBox";
			this.CoreTextBox.Size = new System.Drawing.Size(160, 20);
			this.CoreTextBox.TabIndex = 1;
			this.CoreTextBox.Text = "";
			this.InfoToolTip.SetToolTip(this.CoreTextBox, "The path to the core to use for a new game. Rightclick for a list of recent cores" +
				" (if options permit)");
			// 
			// RecentCoresContextMenu
			// 
			this.RecentCoresContextMenu.Popup += new System.EventHandler(this.RecentCoresContextMenu_Popup);
			// 
			// CoreLabel
			// 
			this.CoreLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.CoreLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.CoreLabel.Location = new System.Drawing.Point(0, 5);
			this.CoreLabel.Name = "CoreLabel";
			this.CoreLabel.Size = new System.Drawing.Size(280, 16);
			this.CoreLabel.TabIndex = 0;
			this.CoreLabel.Text = "Core";
			// 
			// GameOptionsPanel
			// 
			this.GameOptionsPanel.Controls.Add(this.NumberOfTeamsNumericUpDown);
			this.GameOptionsPanel.Controls.Add(this.NumTeamsLabel);
			this.GameOptionsPanel.Controls.Add(this.YourTeamNumericUpDown);
			this.GameOptionsPanel.Controls.Add(this.YourTeamLabel);
			this.GameOptionsPanel.Controls.Add(this.ProsperityCheckBox);
			this.GameOptionsPanel.Controls.Add(this.AllowArtifactsCheckBox);
			this.GameOptionsPanel.Controls.Add(this.CaptureTheFlagCheckBox);
			this.GameOptionsPanel.Controls.Add(this.DeathMatchCheckBox);
			this.GameOptionsPanel.Controls.Add(this.AllowShipyardsCheckBox);
			this.GameOptionsPanel.Controls.Add(this.AllowDevelopmentCheckBox);
			this.GameOptionsPanel.Controls.Add(this.GameOptionsLabel);
			this.GameOptionsPanel.Location = new System.Drawing.Point(0, 52);
			this.GameOptionsPanel.Name = "GameOptionsPanel";
			this.GameOptionsPanel.Size = new System.Drawing.Size(280, 92);
			this.GameOptionsPanel.TabIndex = 1;
			// 
			// NumberOfTeamsNumericUpDown
			// 
			this.NumberOfTeamsNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.NumberOfTeamsNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NumberOfTeamsNumericUpDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NumberOfTeamsNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.NumberOfTeamsNumericUpDown.Location = new System.Drawing.Point(216, 40);
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
			this.NumberOfTeamsNumericUpDown.Size = new System.Drawing.Size(33, 21);
			this.NumberOfTeamsNumericUpDown.TabIndex = 3;
			this.InfoToolTip.SetToolTip(this.NumberOfTeamsNumericUpDown, "The number of teams playing in the new game");
			this.NumberOfTeamsNumericUpDown.Value = new System.Decimal(new int[] {
																					 2,
																					 0,
																					 0,
																					 0});
			this.NumberOfTeamsNumericUpDown.ValueChanged += new System.EventHandler(this.NumberOfTeamsNumericUpDown_ValueChanged);
			// 
			// NumTeamsLabel
			// 
			this.NumTeamsLabel.Location = new System.Drawing.Point(152, 40);
			this.NumTeamsLabel.Name = "NumTeamsLabel";
			this.NumTeamsLabel.Size = new System.Drawing.Size(64, 16);
			this.NumTeamsLabel.TabIndex = 2;
			this.NumTeamsLabel.Text = "# Teams:";
			// 
			// YourTeamNumericUpDown
			// 
			this.YourTeamNumericUpDown.BackColor = System.Drawing.Color.Maroon;
			this.YourTeamNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.YourTeamNumericUpDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.YourTeamNumericUpDown.ForeColor = System.Drawing.Color.White;
			this.YourTeamNumericUpDown.Location = new System.Drawing.Point(216, 24);
			this.YourTeamNumericUpDown.Maximum = new System.Decimal(new int[] {
																				  2,
																				  0,
																				  0,
																				  0});
			this.YourTeamNumericUpDown.Minimum = new System.Decimal(new int[] {
																				  1,
																				  0,
																				  0,
																				  0});
			this.YourTeamNumericUpDown.Name = "YourTeamNumericUpDown";
			this.YourTeamNumericUpDown.Size = new System.Drawing.Size(33, 21);
			this.YourTeamNumericUpDown.TabIndex = 8;
			this.InfoToolTip.SetToolTip(this.YourTeamNumericUpDown, "The team you are playing for. 1 = Yellow, 2 = Blue, etc");
			this.YourTeamNumericUpDown.Value = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				0});
			// 
			// YourTeamLabel
			// 
			this.YourTeamLabel.Location = new System.Drawing.Point(144, 24);
			this.YourTeamLabel.Name = "YourTeamLabel";
			this.YourTeamLabel.Size = new System.Drawing.Size(72, 16);
			this.YourTeamLabel.TabIndex = 7;
			this.YourTeamLabel.Text = "Your Team:";
			// 
			// ProsperityCheckBox
			// 
			this.ProsperityCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ProsperityCheckBox.Location = new System.Drawing.Point(144, 56);
			this.ProsperityCheckBox.Name = "ProsperityCheckBox";
			this.ProsperityCheckBox.Size = new System.Drawing.Size(80, 16);
			this.ProsperityCheckBox.TabIndex = 6;
			this.ProsperityCheckBox.Text = "Prosperity";
			this.InfoToolTip.SetToolTip(this.ProsperityCheckBox, "Specifies whether or not the game is a prosperity game");
			this.ProsperityCheckBox.Visible = false;
			// 
			// AllowArtifactsCheckBox
			// 
			this.AllowArtifactsCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AllowArtifactsCheckBox.Location = new System.Drawing.Point(144, 40);
			this.AllowArtifactsCheckBox.Name = "AllowArtifactsCheckBox";
			this.AllowArtifactsCheckBox.Size = new System.Drawing.Size(96, 16);
			this.AllowArtifactsCheckBox.TabIndex = 5;
			this.AllowArtifactsCheckBox.Text = "Allow Artifacts";
			this.InfoToolTip.SetToolTip(this.AllowArtifactsCheckBox, "Specifies whether or not the game allows artifacts");
			this.AllowArtifactsCheckBox.Visible = false;
			// 
			// CaptureTheFlagCheckBox
			// 
			this.CaptureTheFlagCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.CaptureTheFlagCheckBox.Location = new System.Drawing.Point(8, 72);
			this.CaptureTheFlagCheckBox.Name = "CaptureTheFlagCheckBox";
			this.CaptureTheFlagCheckBox.Size = new System.Drawing.Size(112, 16);
			this.CaptureTheFlagCheckBox.TabIndex = 4;
			this.CaptureTheFlagCheckBox.Text = "Capture the Flag";
			this.InfoToolTip.SetToolTip(this.CaptureTheFlagCheckBox, "Specifies whether or not the game is a Capture the Flag game");
			// 
			// DeathMatchCheckBox
			// 
			this.DeathMatchCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DeathMatchCheckBox.Location = new System.Drawing.Point(8, 56);
			this.DeathMatchCheckBox.Name = "DeathMatchCheckBox";
			this.DeathMatchCheckBox.Size = new System.Drawing.Size(88, 16);
			this.DeathMatchCheckBox.TabIndex = 3;
			this.DeathMatchCheckBox.Text = "DeathMatch";
			this.InfoToolTip.SetToolTip(this.DeathMatchCheckBox, "Specifies whether or not the new game is a Deathmatch game");
			// 
			// AllowShipyardsCheckBox
			// 
			this.AllowShipyardsCheckBox.Checked = true;
			this.AllowShipyardsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AllowShipyardsCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AllowShipyardsCheckBox.Location = new System.Drawing.Point(8, 40);
			this.AllowShipyardsCheckBox.Name = "AllowShipyardsCheckBox";
			this.AllowShipyardsCheckBox.Size = new System.Drawing.Size(104, 16);
			this.AllowShipyardsCheckBox.TabIndex = 2;
			this.AllowShipyardsCheckBox.Text = "Allow Shipyards";
			this.InfoToolTip.SetToolTip(this.AllowShipyardsCheckBox, "Specifies whether or not the new game will allow shipyards");
			// 
			// AllowDevelopmentCheckBox
			// 
			this.AllowDevelopmentCheckBox.Checked = true;
			this.AllowDevelopmentCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AllowDevelopmentCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AllowDevelopmentCheckBox.Location = new System.Drawing.Point(8, 24);
			this.AllowDevelopmentCheckBox.Name = "AllowDevelopmentCheckBox";
			this.AllowDevelopmentCheckBox.Size = new System.Drawing.Size(120, 16);
			this.AllowDevelopmentCheckBox.TabIndex = 1;
			this.AllowDevelopmentCheckBox.Text = "Allow Development";
			this.InfoToolTip.SetToolTip(this.AllowDevelopmentCheckBox, "Specifies whether or not the new game will allow development");
			// 
			// GameOptionsLabel
			// 
			this.GameOptionsLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.GameOptionsLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.GameOptionsLabel.Location = new System.Drawing.Point(0, 5);
			this.GameOptionsLabel.Name = "GameOptionsLabel";
			this.GameOptionsLabel.Size = new System.Drawing.Size(280, 16);
			this.GameOptionsLabel.TabIndex = 0;
			this.GameOptionsLabel.Text = "Game Options";
			// 
			// NewGameCancelButton
			// 
			this.NewGameCancelButton.BackColor = System.Drawing.Color.Maroon;
			this.NewGameCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.NewGameCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NewGameCancelButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NewGameCancelButton.Location = new System.Drawing.Point(116, 116);
			this.NewGameCancelButton.Name = "NewGameCancelButton";
			this.NewGameCancelButton.Size = new System.Drawing.Size(64, 23);
			this.NewGameCancelButton.TabIndex = 4;
			this.NewGameCancelButton.Text = "&Cancel";
			this.InfoToolTip.SetToolTip(this.NewGameCancelButton, "Hides this dialog in your system tray");
			// 
			// NewGameOKButton
			// 
			this.NewGameOKButton.BackColor = System.Drawing.Color.Maroon;
			this.NewGameOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NewGameOKButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.NewGameOKButton.Location = new System.Drawing.Point(186, 116);
			this.NewGameOKButton.Name = "NewGameOKButton";
			this.NewGameOKButton.Size = new System.Drawing.Size(64, 23);
			this.NewGameOKButton.TabIndex = 5;
			this.NewGameOKButton.Text = "&OK";
			this.InfoToolTip.SetToolTip(this.NewGameOKButton, "Launches the new game, then hides this dialog in your system tray");
			this.NewGameOKButton.Click += new System.EventHandler(this.NewGameOKButton_Click);
			// 
			// CoreOpenFileDialog
			// 
			this.CoreOpenFileDialog.DefaultExt = "*.igc";
			this.CoreOpenFileDialog.Filter = "Allegiance Core Files (*.igc)|*.igc";
			this.CoreOpenFileDialog.Title = "Choose a Core...";
			// 
			// NewGameForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.CancelButton = this.NewGameCancelButton;
			this.ClientSize = new System.Drawing.Size(256, 143);
			this.Controls.Add(this.NewGameOKButton);
			this.Controls.Add(this.NewGameCancelButton);
			this.Controls.Add(this.GameOptionsPanel);
			this.Controls.Add(this.CorePanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Game";
			this.CorePanel.ResumeLayout(false);
			this.GameOptionsPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.NumberOfTeamsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.YourTeamNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Allows the user to browse for a core to load
		/// </summary>
		private void BrowseCoreButton_Click (object sender, System.EventArgs e)
		{
			DialogResult Result = CoreOpenFileDialog.ShowDialog();
			switch (Result)
			{
				case DialogResult.OK:
					CoreTextBox.Text = Path.GetFileName(CoreOpenFileDialog.FileName);
					CoreTextBox.SelectionStart = CoreTextBox.Text.Length - 1;
					break;
				case DialogResult.Cancel:
				default:
					break;
			}
		}

		/// <summary>
		/// Creates the game, and hides the NewGame window
		/// </summary>
		private void NewGameOKButton_Click (object sender, System.EventArgs e)
		{
			string CoreFile = this.CorePath;
			if (!File.Exists(CoreFile))
			{
				MessageBox.Show(this, "The chosen core does not exist! Choose again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Add the chosen core to the Recent Cores list, if not already there
			if (!_settings.RecentCores.Contains(CoreFile))
				_settings.RecentCores.Add(CoreFile);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Builds the "Recent Cores" list
		/// </summary>
		private void RecentCoresContextMenu_Popup (object sender, System.EventArgs e)
		{
			ContextMenu Popup = (ContextMenu)sender;
			Popup.MenuItems.Clear();

			string[] CoreList = null;
			if (_settings.RememberRecentCores == false)
			{
				if (Cores == null)
					Cores = Directory.GetFiles(_corePath, "*.igc");
				CoreList = Cores;
			}
			else
			{
				if (_settings.RecentCores.Count == 0)
					return;

				CoreList = new string[_settings.RecentCores.Count];
				for (int i = 0; i < _settings.RecentCores.Count; i++)
					CoreList[i] = (string)_settings.RecentCores[i];
			}

			foreach (string item in CoreList)
			{
				string CoreName = Path.GetFileName(item);
				MenuItem Menu = new MenuItem(CoreName, new EventHandler(RecentCoresMenuItem_Click));
				Popup.MenuItems.Add(Menu);
			}
		}

		/// <summary>
		/// Copies the core path into the CoreTextBox
		/// </summary>
		private void RecentCoresMenuItem_Click (object sender, System.EventArgs e)
		{
			MenuItem Menu = (MenuItem)sender;
			CoreTextBox.Text = Menu.Text;
			CoreTextBox.SelectionStart = CoreTextBox.Text.Length;
		}

		private void NumberOfTeamsNumericUpDown_ValueChanged(object sender, System.EventArgs e)
		{
			if (YourTeamNumericUpDown.Value > NumberOfTeamsNumericUpDown.Value)
				YourTeamNumericUpDown.Value = NumberOfTeamsNumericUpDown.Value;

			YourTeamNumericUpDown.Maximum = NumberOfTeamsNumericUpDown.Value;
		}

		/// <summary>
		/// The path of the core entered in the CoreTextBox
		/// </summary>
		public string CorePath
		{
			get {return string.Concat(_settings.DefaultCoreLocation, "\\", CoreTextBox.Text);}
		}

		/// <summary>
		/// The number of teams chosen
		/// </summary>
		public int NumberOfTeams
		{
			get {return (int)NumberOfTeamsNumericUpDown.Value;}
		}

		public int MyTeam
		{
			get {return (int)YourTeamNumericUpDown.Value;}
		}

		public bool AllowDevelopment
		{
			get {return AllowDevelopmentCheckBox.Checked;}
		}

		public bool AllowShipyards
		{
			get {return AllowShipyardsCheckBox.Checked;}
		}

		public bool DeathMatch
		{
			get {return DeathMatchCheckBox.Checked;}
		}

		public bool CaptureTheFlag
		{
			get {return CaptureTheFlagCheckBox.Checked;}
		}

		public bool AllowArtifacts
		{
			get {return AllowArtifactsCheckBox.Checked;}
		}

		public bool Prosperity
		{
			get {return ProsperityCheckBox.Checked;}
		}
	}
}
