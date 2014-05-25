using System;
using System.Text;
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
	/// Summary description for DamageIndexForm.
	/// </summary>
	public class DamageIndexForm : System.Windows.Forms.Form
	{
		#region Form Controls
		private System.Windows.Forms.Panel DamageIndexesPanel;
		private System.Windows.Forms.Label DamageIndexLabel;
		private System.Windows.Forms.ComboBox DamageIndexComboBox;
		private System.Windows.Forms.Label AsteroidLabel;
		private System.Windows.Forms.TextBox AsteroidTextBox;
		private System.Windows.Forms.TextBox LightHullTextBox;
		private System.Windows.Forms.Label LightHullLabel;
		private System.Windows.Forms.TextBox MediumHullTextBox;
		private System.Windows.Forms.Label MediumHullLabel;
		private System.Windows.Forms.TextBox HeavyHullTextBox;
		private System.Windows.Forms.Label HeavyHullLabel;
		private System.Windows.Forms.TextBox ExtraHeavyHullTextBox;
		private System.Windows.Forms.Label ExtraHeavyHullLabel;
		private System.Windows.Forms.TextBox UtilityHullTextBox;
		private System.Windows.Forms.Label UtilityHullLabel;
		private System.Windows.Forms.TextBox MinorBaseHullTextBox;
		private System.Windows.Forms.Label MinorBaseHullLabel;
		private System.Windows.Forms.TextBox MajorBaseHullTextBox;
		private System.Windows.Forms.Label MajorBaseHullLabel;
		private System.Windows.Forms.TextBox LightAndMedShieldTextBox;
		private System.Windows.Forms.Label LightandMedShieldLabel;
		private System.Windows.Forms.TextBox MinorBaseShieldTextBox;
		private System.Windows.Forms.Label MinorBaseShieldLabel;
		private System.Windows.Forms.TextBox MajorBaseShieldTextBox;
		private System.Windows.Forms.Label MajorBaseShieldLabel;
		private System.Windows.Forms.TextBox PartsTextBox;
		private System.Windows.Forms.Label PartsLabel;
		private System.Windows.Forms.TextBox LightBaseHullTextBox;
		private System.Windows.Forms.Label LightBaseHullLabel;
		private System.Windows.Forms.TextBox LightBaseShieldTextBox;
		private System.Windows.Forms.Label LightBaseShieldLabel;
		private System.Windows.Forms.TextBox LargeShieldTextBox;
		private System.Windows.Forms.Label LargeShieldLabel;
		private System.Windows.Forms.TextBox AC15TextBox;
		private System.Windows.Forms.Label AC15Label;
		private System.Windows.Forms.TextBox AC16TextBox;
		private System.Windows.Forms.Label AC16Label;
		private System.Windows.Forms.TextBox AC17TextBox;
		private System.Windows.Forms.Label AC17Label;
		private System.Windows.Forms.TextBox AC18TextBox;
		private System.Windows.Forms.Label AC18Label;
		private System.Windows.Forms.TextBox AC19TextBox;
		private System.Windows.Forms.Label AC19Label;
		private System.Windows.Forms.Panel UsedByPanel;
		private System.Windows.Forms.Label UsedByLabel;
		private System.Windows.Forms.ToolTip InfoToolTip;
		private System.ComponentModel.IContainer components;
		#endregion
		private System.Windows.Forms.TextBox UsedByDMTextBox;
		private System.Windows.Forms.TextBox UsedByACTextBox;
		private System.Windows.Forms.Timer BalloonTimer;

		Core				_core;
		IGCCoreConstants	_constants;
		BindingManagerBase	_bmDamageIndex;
		private System.Windows.Forms.Label UsedAgainstLabel;
		TekSettings			_settings;

		public DamageIndexForm (MainForm mainForm)
		{
			InitializeComponent();

			this.Icon = mainForm.Icon;
			_core = mainForm.Game.Core;
			_constants = _core.Constants;
			_settings = mainForm.Settings;
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
			this.DamageIndexesPanel = new System.Windows.Forms.Panel();
			this.AC19TextBox = new System.Windows.Forms.TextBox();
			this.AC19Label = new System.Windows.Forms.Label();
			this.AC18TextBox = new System.Windows.Forms.TextBox();
			this.AC18Label = new System.Windows.Forms.Label();
			this.AC17TextBox = new System.Windows.Forms.TextBox();
			this.AC17Label = new System.Windows.Forms.Label();
			this.AC16TextBox = new System.Windows.Forms.TextBox();
			this.AC16Label = new System.Windows.Forms.Label();
			this.AC15TextBox = new System.Windows.Forms.TextBox();
			this.AC15Label = new System.Windows.Forms.Label();
			this.LargeShieldTextBox = new System.Windows.Forms.TextBox();
			this.LargeShieldLabel = new System.Windows.Forms.Label();
			this.LightBaseShieldTextBox = new System.Windows.Forms.TextBox();
			this.LightBaseShieldLabel = new System.Windows.Forms.Label();
			this.LightBaseHullTextBox = new System.Windows.Forms.TextBox();
			this.LightBaseHullLabel = new System.Windows.Forms.Label();
			this.PartsTextBox = new System.Windows.Forms.TextBox();
			this.PartsLabel = new System.Windows.Forms.Label();
			this.MajorBaseShieldTextBox = new System.Windows.Forms.TextBox();
			this.MajorBaseShieldLabel = new System.Windows.Forms.Label();
			this.MinorBaseShieldTextBox = new System.Windows.Forms.TextBox();
			this.MinorBaseShieldLabel = new System.Windows.Forms.Label();
			this.LightAndMedShieldTextBox = new System.Windows.Forms.TextBox();
			this.LightandMedShieldLabel = new System.Windows.Forms.Label();
			this.MajorBaseHullTextBox = new System.Windows.Forms.TextBox();
			this.MajorBaseHullLabel = new System.Windows.Forms.Label();
			this.MinorBaseHullTextBox = new System.Windows.Forms.TextBox();
			this.MinorBaseHullLabel = new System.Windows.Forms.Label();
			this.UtilityHullTextBox = new System.Windows.Forms.TextBox();
			this.UtilityHullLabel = new System.Windows.Forms.Label();
			this.ExtraHeavyHullTextBox = new System.Windows.Forms.TextBox();
			this.ExtraHeavyHullLabel = new System.Windows.Forms.Label();
			this.HeavyHullTextBox = new System.Windows.Forms.TextBox();
			this.HeavyHullLabel = new System.Windows.Forms.Label();
			this.MediumHullTextBox = new System.Windows.Forms.TextBox();
			this.MediumHullLabel = new System.Windows.Forms.Label();
			this.LightHullTextBox = new System.Windows.Forms.TextBox();
			this.LightHullLabel = new System.Windows.Forms.Label();
			this.AsteroidTextBox = new System.Windows.Forms.TextBox();
			this.AsteroidLabel = new System.Windows.Forms.Label();
			this.DamageIndexComboBox = new System.Windows.Forms.ComboBox();
			this.DamageIndexLabel = new System.Windows.Forms.Label();
			this.UsedByPanel = new System.Windows.Forms.Panel();
			this.UsedAgainstLabel = new System.Windows.Forms.Label();
			this.UsedByACTextBox = new System.Windows.Forms.TextBox();
			this.UsedByDMTextBox = new System.Windows.Forms.TextBox();
			this.UsedByLabel = new System.Windows.Forms.Label();
			this.InfoToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.BalloonTimer = new System.Windows.Forms.Timer(this.components);
			this.DamageIndexesPanel.SuspendLayout();
			this.UsedByPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// DamageIndexesPanel
			// 
			this.DamageIndexesPanel.Controls.Add(this.AC19TextBox);
			this.DamageIndexesPanel.Controls.Add(this.AC19Label);
			this.DamageIndexesPanel.Controls.Add(this.AC18TextBox);
			this.DamageIndexesPanel.Controls.Add(this.AC18Label);
			this.DamageIndexesPanel.Controls.Add(this.AC17TextBox);
			this.DamageIndexesPanel.Controls.Add(this.AC17Label);
			this.DamageIndexesPanel.Controls.Add(this.AC16TextBox);
			this.DamageIndexesPanel.Controls.Add(this.AC16Label);
			this.DamageIndexesPanel.Controls.Add(this.AC15TextBox);
			this.DamageIndexesPanel.Controls.Add(this.AC15Label);
			this.DamageIndexesPanel.Controls.Add(this.LargeShieldTextBox);
			this.DamageIndexesPanel.Controls.Add(this.LargeShieldLabel);
			this.DamageIndexesPanel.Controls.Add(this.LightBaseShieldTextBox);
			this.DamageIndexesPanel.Controls.Add(this.LightBaseShieldLabel);
			this.DamageIndexesPanel.Controls.Add(this.LightBaseHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.LightBaseHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.PartsTextBox);
			this.DamageIndexesPanel.Controls.Add(this.PartsLabel);
			this.DamageIndexesPanel.Controls.Add(this.MajorBaseShieldTextBox);
			this.DamageIndexesPanel.Controls.Add(this.MajorBaseShieldLabel);
			this.DamageIndexesPanel.Controls.Add(this.MinorBaseShieldTextBox);
			this.DamageIndexesPanel.Controls.Add(this.MinorBaseShieldLabel);
			this.DamageIndexesPanel.Controls.Add(this.LightAndMedShieldTextBox);
			this.DamageIndexesPanel.Controls.Add(this.LightandMedShieldLabel);
			this.DamageIndexesPanel.Controls.Add(this.MajorBaseHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.MajorBaseHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.MinorBaseHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.MinorBaseHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.UtilityHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.UtilityHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.ExtraHeavyHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.ExtraHeavyHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.HeavyHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.HeavyHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.MediumHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.MediumHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.LightHullTextBox);
			this.DamageIndexesPanel.Controls.Add(this.LightHullLabel);
			this.DamageIndexesPanel.Controls.Add(this.AsteroidTextBox);
			this.DamageIndexesPanel.Controls.Add(this.AsteroidLabel);
			this.DamageIndexesPanel.Controls.Add(this.DamageIndexComboBox);
			this.DamageIndexesPanel.Controls.Add(this.DamageIndexLabel);
			this.DamageIndexesPanel.Location = new System.Drawing.Point(0, 0);
			this.DamageIndexesPanel.Name = "DamageIndexesPanel";
			this.DamageIndexesPanel.Size = new System.Drawing.Size(328, 192);
			this.DamageIndexesPanel.TabIndex = 0;
			this.InfoToolTip.SetToolTip(this.DamageIndexesPanel, "Click an armor class to see all objects that carry it");
			// 
			// AC19TextBox
			// 
			this.AC19TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AC19TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AC19TextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AC19TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AC19TextBox.ForeColor = System.Drawing.Color.White;
			this.AC19TextBox.Location = new System.Drawing.Point(272, 176);
			this.AC19TextBox.Name = "AC19TextBox";
			this.AC19TextBox.ReadOnly = true;
			this.AC19TextBox.Size = new System.Drawing.Size(40, 14);
			this.AC19TextBox.TabIndex = 39;
			this.AC19TextBox.Tag = "19";
			this.AC19TextBox.Text = "0";
			this.AC19TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AC19TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AC19Label
			// 
			this.AC19Label.Location = new System.Drawing.Point(160, 176);
			this.AC19Label.Name = "AC19Label";
			this.AC19Label.Size = new System.Drawing.Size(40, 16);
			this.AC19Label.TabIndex = 38;
			this.AC19Label.Tag = "19";
			this.AC19Label.Text = "AC19:";
			this.AC19Label.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AC19Label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AC19Label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// AC18TextBox
			// 
			this.AC18TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AC18TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AC18TextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AC18TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AC18TextBox.ForeColor = System.Drawing.Color.White;
			this.AC18TextBox.Location = new System.Drawing.Point(112, 176);
			this.AC18TextBox.Name = "AC18TextBox";
			this.AC18TextBox.ReadOnly = true;
			this.AC18TextBox.Size = new System.Drawing.Size(40, 14);
			this.AC18TextBox.TabIndex = 37;
			this.AC18TextBox.Tag = "18";
			this.AC18TextBox.Text = "0";
			this.AC18TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AC18TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AC18Label
			// 
			this.AC18Label.Location = new System.Drawing.Point(8, 176);
			this.AC18Label.Name = "AC18Label";
			this.AC18Label.Size = new System.Drawing.Size(40, 16);
			this.AC18Label.TabIndex = 36;
			this.AC18Label.Tag = "18";
			this.AC18Label.Text = "AC18:";
			this.AC18Label.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AC18Label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AC18Label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// AC17TextBox
			// 
			this.AC17TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AC17TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AC17TextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AC17TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AC17TextBox.ForeColor = System.Drawing.Color.White;
			this.AC17TextBox.Location = new System.Drawing.Point(272, 160);
			this.AC17TextBox.Name = "AC17TextBox";
			this.AC17TextBox.ReadOnly = true;
			this.AC17TextBox.Size = new System.Drawing.Size(40, 14);
			this.AC17TextBox.TabIndex = 35;
			this.AC17TextBox.Tag = "17";
			this.AC17TextBox.Text = "0";
			this.AC17TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AC17TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AC17Label
			// 
			this.AC17Label.Location = new System.Drawing.Point(160, 160);
			this.AC17Label.Name = "AC17Label";
			this.AC17Label.Size = new System.Drawing.Size(40, 16);
			this.AC17Label.TabIndex = 34;
			this.AC17Label.Tag = "17";
			this.AC17Label.Text = "AC17:";
			this.AC17Label.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AC17Label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AC17Label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// AC16TextBox
			// 
			this.AC16TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AC16TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AC16TextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AC16TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AC16TextBox.ForeColor = System.Drawing.Color.White;
			this.AC16TextBox.Location = new System.Drawing.Point(112, 160);
			this.AC16TextBox.Name = "AC16TextBox";
			this.AC16TextBox.ReadOnly = true;
			this.AC16TextBox.Size = new System.Drawing.Size(40, 14);
			this.AC16TextBox.TabIndex = 33;
			this.AC16TextBox.Tag = "16";
			this.AC16TextBox.Text = "0";
			this.AC16TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AC16TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AC16Label
			// 
			this.AC16Label.Location = new System.Drawing.Point(8, 160);
			this.AC16Label.Name = "AC16Label";
			this.AC16Label.Size = new System.Drawing.Size(40, 16);
			this.AC16Label.TabIndex = 32;
			this.AC16Label.Tag = "16";
			this.AC16Label.Text = "AC16:";
			this.AC16Label.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AC16Label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AC16Label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// AC15TextBox
			// 
			this.AC15TextBox.BackColor = System.Drawing.Color.Maroon;
			this.AC15TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AC15TextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AC15TextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AC15TextBox.ForeColor = System.Drawing.Color.White;
			this.AC15TextBox.Location = new System.Drawing.Point(272, 144);
			this.AC15TextBox.Name = "AC15TextBox";
			this.AC15TextBox.ReadOnly = true;
			this.AC15TextBox.Size = new System.Drawing.Size(40, 14);
			this.AC15TextBox.TabIndex = 31;
			this.AC15TextBox.Tag = "15";
			this.AC15TextBox.Text = "0";
			this.AC15TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AC15TextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AC15Label
			// 
			this.AC15Label.Location = new System.Drawing.Point(160, 144);
			this.AC15Label.Name = "AC15Label";
			this.AC15Label.Size = new System.Drawing.Size(40, 16);
			this.AC15Label.TabIndex = 30;
			this.AC15Label.Tag = "15";
			this.AC15Label.Text = "AC15:";
			this.AC15Label.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AC15Label.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AC15Label.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// LargeShieldTextBox
			// 
			this.LargeShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LargeShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LargeShieldTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LargeShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LargeShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.LargeShieldTextBox.Location = new System.Drawing.Point(112, 128);
			this.LargeShieldTextBox.Name = "LargeShieldTextBox";
			this.LargeShieldTextBox.ReadOnly = true;
			this.LargeShieldTextBox.Size = new System.Drawing.Size(40, 14);
			this.LargeShieldTextBox.TabIndex = 14;
			this.LargeShieldTextBox.Tag = "14";
			this.LargeShieldTextBox.Text = "0";
			this.LargeShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LargeShieldTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// LargeShieldLabel
			// 
			this.LargeShieldLabel.Location = new System.Drawing.Point(8, 128);
			this.LargeShieldLabel.Name = "LargeShieldLabel";
			this.LargeShieldLabel.Size = new System.Drawing.Size(80, 16);
			this.LargeShieldLabel.TabIndex = 13;
			this.LargeShieldLabel.Tag = "14";
			this.LargeShieldLabel.Text = "Large Shield:";
			this.LargeShieldLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.LargeShieldLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.LargeShieldLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// LightBaseShieldTextBox
			// 
			this.LightBaseShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LightBaseShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LightBaseShieldTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LightBaseShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LightBaseShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.LightBaseShieldTextBox.Location = new System.Drawing.Point(272, 48);
			this.LightBaseShieldTextBox.Name = "LightBaseShieldTextBox";
			this.LightBaseShieldTextBox.ReadOnly = true;
			this.LightBaseShieldTextBox.Size = new System.Drawing.Size(40, 14);
			this.LightBaseShieldTextBox.TabIndex = 19;
			this.LightBaseShieldTextBox.Tag = "13";
			this.LightBaseShieldTextBox.Text = "0";
			this.LightBaseShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LightBaseShieldTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// LightBaseShieldLabel
			// 
			this.LightBaseShieldLabel.Location = new System.Drawing.Point(160, 48);
			this.LightBaseShieldLabel.Name = "LightBaseShieldLabel";
			this.LightBaseShieldLabel.Size = new System.Drawing.Size(112, 16);
			this.LightBaseShieldLabel.TabIndex = 18;
			this.LightBaseShieldLabel.Tag = "13";
			this.LightBaseShieldLabel.Text = "Light Base Shield:";
			this.LightBaseShieldLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.LightBaseShieldLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.LightBaseShieldLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// LightBaseHullTextBox
			// 
			this.LightBaseHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LightBaseHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LightBaseHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LightBaseHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LightBaseHullTextBox.ForeColor = System.Drawing.Color.White;
			this.LightBaseHullTextBox.Location = new System.Drawing.Point(272, 32);
			this.LightBaseHullTextBox.Name = "LightBaseHullTextBox";
			this.LightBaseHullTextBox.ReadOnly = true;
			this.LightBaseHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.LightBaseHullTextBox.TabIndex = 17;
			this.LightBaseHullTextBox.Tag = "12";
			this.LightBaseHullTextBox.Text = "0";
			this.LightBaseHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LightBaseHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// LightBaseHullLabel
			// 
			this.LightBaseHullLabel.Location = new System.Drawing.Point(160, 32);
			this.LightBaseHullLabel.Name = "LightBaseHullLabel";
			this.LightBaseHullLabel.Size = new System.Drawing.Size(96, 16);
			this.LightBaseHullLabel.TabIndex = 16;
			this.LightBaseHullLabel.Tag = "12";
			this.LightBaseHullLabel.Text = "Light Base Hull:";
			this.LightBaseHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.LightBaseHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.LightBaseHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// PartsTextBox
			// 
			this.PartsTextBox.BackColor = System.Drawing.Color.Maroon;
			this.PartsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PartsTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PartsTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.PartsTextBox.ForeColor = System.Drawing.Color.White;
			this.PartsTextBox.Location = new System.Drawing.Point(112, 144);
			this.PartsTextBox.Name = "PartsTextBox";
			this.PartsTextBox.ReadOnly = true;
			this.PartsTextBox.Size = new System.Drawing.Size(40, 14);
			this.PartsTextBox.TabIndex = 25;
			this.PartsTextBox.Tag = "11";
			this.PartsTextBox.Text = "0";
			this.PartsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PartsTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// PartsLabel
			// 
			this.PartsLabel.Location = new System.Drawing.Point(8, 144);
			this.PartsLabel.Name = "PartsLabel";
			this.PartsLabel.Size = new System.Drawing.Size(40, 16);
			this.PartsLabel.TabIndex = 15;
			this.PartsLabel.Tag = "11";
			this.PartsLabel.Text = "Parts:";
			this.PartsLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.PartsLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.PartsLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// MajorBaseShieldTextBox
			// 
			this.MajorBaseShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MajorBaseShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MajorBaseShieldTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MajorBaseShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MajorBaseShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.MajorBaseShieldTextBox.Location = new System.Drawing.Point(272, 112);
			this.MajorBaseShieldTextBox.Name = "MajorBaseShieldTextBox";
			this.MajorBaseShieldTextBox.ReadOnly = true;
			this.MajorBaseShieldTextBox.Size = new System.Drawing.Size(40, 14);
			this.MajorBaseShieldTextBox.TabIndex = 27;
			this.MajorBaseShieldTextBox.Tag = "10";
			this.MajorBaseShieldTextBox.Text = "0";
			this.MajorBaseShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MajorBaseShieldTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// MajorBaseShieldLabel
			// 
			this.MajorBaseShieldLabel.Location = new System.Drawing.Point(160, 112);
			this.MajorBaseShieldLabel.Name = "MajorBaseShieldLabel";
			this.MajorBaseShieldLabel.Size = new System.Drawing.Size(112, 16);
			this.MajorBaseShieldLabel.TabIndex = 26;
			this.MajorBaseShieldLabel.Tag = "10";
			this.MajorBaseShieldLabel.Text = "Major Base Shield:";
			this.MajorBaseShieldLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.MajorBaseShieldLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.MajorBaseShieldLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// MinorBaseShieldTextBox
			// 
			this.MinorBaseShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MinorBaseShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MinorBaseShieldTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MinorBaseShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MinorBaseShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.MinorBaseShieldTextBox.Location = new System.Drawing.Point(272, 80);
			this.MinorBaseShieldTextBox.Name = "MinorBaseShieldTextBox";
			this.MinorBaseShieldTextBox.ReadOnly = true;
			this.MinorBaseShieldTextBox.Size = new System.Drawing.Size(40, 14);
			this.MinorBaseShieldTextBox.TabIndex = 23;
			this.MinorBaseShieldTextBox.Tag = "9";
			this.MinorBaseShieldTextBox.Text = "0";
			this.MinorBaseShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MinorBaseShieldTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// MinorBaseShieldLabel
			// 
			this.MinorBaseShieldLabel.Location = new System.Drawing.Point(160, 80);
			this.MinorBaseShieldLabel.Name = "MinorBaseShieldLabel";
			this.MinorBaseShieldLabel.Size = new System.Drawing.Size(112, 16);
			this.MinorBaseShieldLabel.TabIndex = 22;
			this.MinorBaseShieldLabel.Tag = "9";
			this.MinorBaseShieldLabel.Text = "Minor Base Shield:";
			this.MinorBaseShieldLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.MinorBaseShieldLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.MinorBaseShieldLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// LightAndMedShieldTextBox
			// 
			this.LightAndMedShieldTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LightAndMedShieldTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LightAndMedShieldTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LightAndMedShieldTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LightAndMedShieldTextBox.ForeColor = System.Drawing.Color.White;
			this.LightAndMedShieldTextBox.Location = new System.Drawing.Point(112, 112);
			this.LightAndMedShieldTextBox.Name = "LightAndMedShieldTextBox";
			this.LightAndMedShieldTextBox.ReadOnly = true;
			this.LightAndMedShieldTextBox.Size = new System.Drawing.Size(40, 14);
			this.LightAndMedShieldTextBox.TabIndex = 12;
			this.LightAndMedShieldTextBox.Tag = "8";
			this.LightAndMedShieldTextBox.Text = "0";
			this.LightAndMedShieldTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LightAndMedShieldTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// LightandMedShieldLabel
			// 
			this.LightandMedShieldLabel.Location = new System.Drawing.Point(8, 112);
			this.LightandMedShieldLabel.Name = "LightandMedShieldLabel";
			this.LightandMedShieldLabel.Size = new System.Drawing.Size(104, 16);
			this.LightandMedShieldLabel.TabIndex = 11;
			this.LightandMedShieldLabel.Tag = "8";
			this.LightandMedShieldLabel.Text = "Lt & Med Shield:";
			this.LightandMedShieldLabel.UseMnemonic = false;
			this.LightandMedShieldLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.LightandMedShieldLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.LightandMedShieldLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// MajorBaseHullTextBox
			// 
			this.MajorBaseHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MajorBaseHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MajorBaseHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MajorBaseHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MajorBaseHullTextBox.ForeColor = System.Drawing.Color.White;
			this.MajorBaseHullTextBox.Location = new System.Drawing.Point(272, 96);
			this.MajorBaseHullTextBox.Name = "MajorBaseHullTextBox";
			this.MajorBaseHullTextBox.ReadOnly = true;
			this.MajorBaseHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.MajorBaseHullTextBox.TabIndex = 25;
			this.MajorBaseHullTextBox.Tag = "7";
			this.MajorBaseHullTextBox.Text = "0";
			this.MajorBaseHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MajorBaseHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// MajorBaseHullLabel
			// 
			this.MajorBaseHullLabel.Location = new System.Drawing.Point(160, 96);
			this.MajorBaseHullLabel.Name = "MajorBaseHullLabel";
			this.MajorBaseHullLabel.Size = new System.Drawing.Size(104, 16);
			this.MajorBaseHullLabel.TabIndex = 24;
			this.MajorBaseHullLabel.Tag = "7";
			this.MajorBaseHullLabel.Text = "Major Base Hull:";
			this.MajorBaseHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.MajorBaseHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.MajorBaseHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// MinorBaseHullTextBox
			// 
			this.MinorBaseHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MinorBaseHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MinorBaseHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MinorBaseHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MinorBaseHullTextBox.ForeColor = System.Drawing.Color.White;
			this.MinorBaseHullTextBox.Location = new System.Drawing.Point(272, 64);
			this.MinorBaseHullTextBox.Name = "MinorBaseHullTextBox";
			this.MinorBaseHullTextBox.ReadOnly = true;
			this.MinorBaseHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.MinorBaseHullTextBox.TabIndex = 21;
			this.MinorBaseHullTextBox.Tag = "6";
			this.MinorBaseHullTextBox.Text = "0";
			this.MinorBaseHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MinorBaseHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// MinorBaseHullLabel
			// 
			this.MinorBaseHullLabel.Location = new System.Drawing.Point(160, 64);
			this.MinorBaseHullLabel.Name = "MinorBaseHullLabel";
			this.MinorBaseHullLabel.Size = new System.Drawing.Size(104, 16);
			this.MinorBaseHullLabel.TabIndex = 20;
			this.MinorBaseHullLabel.Tag = "6";
			this.MinorBaseHullLabel.Text = "Minor Base Hull:";
			this.MinorBaseHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.MinorBaseHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.MinorBaseHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// UtilityHullTextBox
			// 
			this.UtilityHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.UtilityHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.UtilityHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.UtilityHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UtilityHullTextBox.ForeColor = System.Drawing.Color.White;
			this.UtilityHullTextBox.Location = new System.Drawing.Point(112, 32);
			this.UtilityHullTextBox.Name = "UtilityHullTextBox";
			this.UtilityHullTextBox.ReadOnly = true;
			this.UtilityHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.UtilityHullTextBox.TabIndex = 3;
			this.UtilityHullTextBox.Tag = "5";
			this.UtilityHullTextBox.Text = "0";
			this.UtilityHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.UtilityHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// UtilityHullLabel
			// 
			this.UtilityHullLabel.Location = new System.Drawing.Point(8, 32);
			this.UtilityHullLabel.Name = "UtilityHullLabel";
			this.UtilityHullLabel.Size = new System.Drawing.Size(48, 16);
			this.UtilityHullLabel.TabIndex = 2;
			this.UtilityHullLabel.Tag = "5";
			this.UtilityHullLabel.Text = "Utility:";
			this.UtilityHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.UtilityHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.UtilityHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// ExtraHeavyHullTextBox
			// 
			this.ExtraHeavyHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.ExtraHeavyHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ExtraHeavyHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ExtraHeavyHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ExtraHeavyHullTextBox.ForeColor = System.Drawing.Color.White;
			this.ExtraHeavyHullTextBox.Location = new System.Drawing.Point(112, 96);
			this.ExtraHeavyHullTextBox.Name = "ExtraHeavyHullTextBox";
			this.ExtraHeavyHullTextBox.ReadOnly = true;
			this.ExtraHeavyHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.ExtraHeavyHullTextBox.TabIndex = 11;
			this.ExtraHeavyHullTextBox.Tag = "4";
			this.ExtraHeavyHullTextBox.Text = "0";
			this.ExtraHeavyHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ExtraHeavyHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// ExtraHeavyHullLabel
			// 
			this.ExtraHeavyHullLabel.Location = new System.Drawing.Point(8, 96);
			this.ExtraHeavyHullLabel.Name = "ExtraHeavyHullLabel";
			this.ExtraHeavyHullLabel.Size = new System.Drawing.Size(104, 16);
			this.ExtraHeavyHullLabel.TabIndex = 10;
			this.ExtraHeavyHullLabel.Tag = "4";
			this.ExtraHeavyHullLabel.Text = "Extra Heavy Hull:";
			this.ExtraHeavyHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.ExtraHeavyHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.ExtraHeavyHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// HeavyHullTextBox
			// 
			this.HeavyHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.HeavyHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.HeavyHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.HeavyHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HeavyHullTextBox.ForeColor = System.Drawing.Color.White;
			this.HeavyHullTextBox.Location = new System.Drawing.Point(112, 80);
			this.HeavyHullTextBox.Name = "HeavyHullTextBox";
			this.HeavyHullTextBox.ReadOnly = true;
			this.HeavyHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.HeavyHullTextBox.TabIndex = 9;
			this.HeavyHullTextBox.Tag = "3";
			this.HeavyHullTextBox.Text = "0";
			this.HeavyHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.HeavyHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// HeavyHullLabel
			// 
			this.HeavyHullLabel.Location = new System.Drawing.Point(8, 80);
			this.HeavyHullLabel.Name = "HeavyHullLabel";
			this.HeavyHullLabel.Size = new System.Drawing.Size(72, 16);
			this.HeavyHullLabel.TabIndex = 8;
			this.HeavyHullLabel.Tag = "3";
			this.HeavyHullLabel.Text = "Heavy Hull:";
			this.HeavyHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.HeavyHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.HeavyHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// MediumHullTextBox
			// 
			this.MediumHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.MediumHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MediumHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MediumHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MediumHullTextBox.ForeColor = System.Drawing.Color.White;
			this.MediumHullTextBox.Location = new System.Drawing.Point(112, 64);
			this.MediumHullTextBox.Name = "MediumHullTextBox";
			this.MediumHullTextBox.ReadOnly = true;
			this.MediumHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.MediumHullTextBox.TabIndex = 7;
			this.MediumHullTextBox.Tag = "2";
			this.MediumHullTextBox.Text = "0";
			this.MediumHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.MediumHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// MediumHullLabel
			// 
			this.MediumHullLabel.Location = new System.Drawing.Point(8, 64);
			this.MediumHullLabel.Name = "MediumHullLabel";
			this.MediumHullLabel.Size = new System.Drawing.Size(80, 16);
			this.MediumHullLabel.TabIndex = 6;
			this.MediumHullLabel.Tag = "2";
			this.MediumHullLabel.Text = "Medium Hull:";
			this.MediumHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.MediumHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.MediumHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// LightHullTextBox
			// 
			this.LightHullTextBox.BackColor = System.Drawing.Color.Maroon;
			this.LightHullTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LightHullTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.LightHullTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.LightHullTextBox.ForeColor = System.Drawing.Color.White;
			this.LightHullTextBox.Location = new System.Drawing.Point(112, 48);
			this.LightHullTextBox.Name = "LightHullTextBox";
			this.LightHullTextBox.ReadOnly = true;
			this.LightHullTextBox.Size = new System.Drawing.Size(40, 14);
			this.LightHullTextBox.TabIndex = 5;
			this.LightHullTextBox.Tag = "1";
			this.LightHullTextBox.Text = "0";
			this.LightHullTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LightHullTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// LightHullLabel
			// 
			this.LightHullLabel.Location = new System.Drawing.Point(8, 48);
			this.LightHullLabel.Name = "LightHullLabel";
			this.LightHullLabel.Size = new System.Drawing.Size(64, 16);
			this.LightHullLabel.TabIndex = 4;
			this.LightHullLabel.Tag = "1";
			this.LightHullLabel.Text = "Light Hull:";
			this.LightHullLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.LightHullLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.LightHullLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// AsteroidTextBox
			// 
			this.AsteroidTextBox.BackColor = System.Drawing.Color.Maroon;
			this.AsteroidTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.AsteroidTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AsteroidTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.AsteroidTextBox.ForeColor = System.Drawing.Color.White;
			this.AsteroidTextBox.Location = new System.Drawing.Point(272, 128);
			this.AsteroidTextBox.Name = "AsteroidTextBox";
			this.AsteroidTextBox.ReadOnly = true;
			this.AsteroidTextBox.Size = new System.Drawing.Size(40, 14);
			this.AsteroidTextBox.TabIndex = 29;
			this.AsteroidTextBox.Tag = "0";
			this.AsteroidTextBox.Text = "0";
			this.AsteroidTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.AsteroidTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArmorClassTextBox_MouseDown);
			// 
			// AsteroidLabel
			// 
			this.AsteroidLabel.Location = new System.Drawing.Point(160, 128);
			this.AsteroidLabel.Name = "AsteroidLabel";
			this.AsteroidLabel.Size = new System.Drawing.Size(64, 16);
			this.AsteroidLabel.TabIndex = 28;
			this.AsteroidLabel.Tag = "0";
			this.AsteroidLabel.Text = "Asteroid:";
			this.AsteroidLabel.Click += new System.EventHandler(this.ArmorClassLabel_Click);
			this.AsteroidLabel.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
			this.AsteroidLabel.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
			// 
			// DamageIndexComboBox
			// 
			this.DamageIndexComboBox.BackColor = System.Drawing.Color.Maroon;
			this.DamageIndexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DamageIndexComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DamageIndexComboBox.ForeColor = System.Drawing.Color.White;
			this.DamageIndexComboBox.Location = new System.Drawing.Point(256, 3);
			this.DamageIndexComboBox.Name = "DamageIndexComboBox";
			this.DamageIndexComboBox.Size = new System.Drawing.Size(56, 21);
			this.DamageIndexComboBox.TabIndex = 1;
			this.DamageIndexComboBox.Click += new System.EventHandler(this.DamageIndexComboBox_Click);
			this.DamageIndexComboBox.SelectedIndexChanged += new System.EventHandler(this.DamageIndexComboBox_SelectedIndexChanged);
			// 
			// DamageIndexLabel
			// 
			this.DamageIndexLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.DamageIndexLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DamageIndexLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.DamageIndexLabel.Location = new System.Drawing.Point(0, 5);
			this.DamageIndexLabel.Name = "DamageIndexLabel";
			this.DamageIndexLabel.Size = new System.Drawing.Size(328, 16);
			this.DamageIndexLabel.TabIndex = 0;
			this.DamageIndexLabel.Text = "Damage Index";
			this.InfoToolTip.SetToolTip(this.DamageIndexLabel, "Click here to see all parts that use the selected DamageIndex");
			this.DamageIndexLabel.Click += new System.EventHandler(this.DamageIndexLabel_Click);
			// 
			// UsedByPanel
			// 
			this.UsedByPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.UsedByPanel.Controls.Add(this.UsedAgainstLabel);
			this.UsedByPanel.Controls.Add(this.UsedByACTextBox);
			this.UsedByPanel.Controls.Add(this.UsedByDMTextBox);
			this.UsedByPanel.Controls.Add(this.UsedByLabel);
			this.UsedByPanel.Location = new System.Drawing.Point(0, 192);
			this.UsedByPanel.Name = "UsedByPanel";
			this.UsedByPanel.Size = new System.Drawing.Size(328, 100);
			this.UsedByPanel.TabIndex = 1;
			this.InfoToolTip.SetToolTip(this.UsedByPanel, "Click an ArmorClass or the DamageIndex box above to see all objects that use it");
			// 
			// UsedAgainstLabel
			// 
			this.UsedAgainstLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UsedAgainstLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.UsedAgainstLabel.Location = new System.Drawing.Point(160, 5);
			this.UsedAgainstLabel.Name = "UsedAgainstLabel";
			this.UsedAgainstLabel.Size = new System.Drawing.Size(144, 16);
			this.UsedAgainstLabel.TabIndex = 3;
			this.UsedAgainstLabel.Text = "Objects with this AC:";
			// 
			// UsedByACTextBox
			// 
			this.UsedByACTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.UsedByACTextBox.BackColor = System.Drawing.Color.Maroon;
			this.UsedByACTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsedByACTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UsedByACTextBox.ForeColor = System.Drawing.Color.White;
			this.UsedByACTextBox.Location = new System.Drawing.Point(158, 24);
			this.UsedByACTextBox.Multiline = true;
			this.UsedByACTextBox.Name = "UsedByACTextBox";
			this.UsedByACTextBox.ReadOnly = true;
			this.UsedByACTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.UsedByACTextBox.Size = new System.Drawing.Size(154, 76);
			this.UsedByACTextBox.TabIndex = 2;
			this.UsedByACTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.UsedByACTextBox, "This box shows all parts with the chosen DamageIndex, or all objects with the cho" +
				"sen ArmorClass. Click an ArmorClass above, or select a DamageIndex from the drop" +
				"down box");
			// 
			// UsedByDMTextBox
			// 
			this.UsedByDMTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.UsedByDMTextBox.BackColor = System.Drawing.Color.Maroon;
			this.UsedByDMTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsedByDMTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.UsedByDMTextBox.ForeColor = System.Drawing.Color.White;
			this.UsedByDMTextBox.Location = new System.Drawing.Point(4, 24);
			this.UsedByDMTextBox.Multiline = true;
			this.UsedByDMTextBox.Name = "UsedByDMTextBox";
			this.UsedByDMTextBox.ReadOnly = true;
			this.UsedByDMTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.UsedByDMTextBox.Size = new System.Drawing.Size(154, 76);
			this.UsedByDMTextBox.TabIndex = 1;
			this.UsedByDMTextBox.Text = "<None>";
			this.InfoToolTip.SetToolTip(this.UsedByDMTextBox, "This box shows all parts with the chosen DamageIndex, or all objects with the cho" +
				"sen ArmorClass. Click an ArmorClass above, or select a DamageIndex from the drop" +
				"down box");
			// 
			// UsedByLabel
			// 
			this.UsedByLabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
			this.UsedByLabel.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.UsedByLabel.Location = new System.Drawing.Point(0, 5);
			this.UsedByLabel.Name = "UsedByLabel";
			this.UsedByLabel.Size = new System.Drawing.Size(328, 16);
			this.UsedByLabel.TabIndex = 0;
			this.UsedByLabel.Text = "Weapons with this DM:";
			// 
			// BalloonTimer
			// 
			this.BalloonTimer.Tick += new System.EventHandler(this.BalloonTimer_Tick);
			// 
			// DamageIndexForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(314, 295);
			this.Controls.Add(this.UsedByPanel);
			this.Controls.Add(this.DamageIndexesPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.Name = "DamageIndexForm";
			this.ShowInTaskbar = false;
			this.Text = "Damage Indices";
			this.Resize += new System.EventHandler(this.DamageIndexForm_Resize);
			this.Load += new System.EventHandler(this.DamageIndexForm_Load);
			this.Closed += new System.EventHandler(this.DamageIndexForm_Closed);
			this.DamageIndexesPanel.ResumeLayout(false);
			this.UsedByPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BindControls ()
		{
			for (int i = 0; i < _constants.DamageIndexes.Length; i++)
			{
				DamageIndex Index = _constants.DamageIndexes[i];
				DamageIndexComboBox.Items.Add("DM " + i.ToString());
			}

			string Text = "Text";
			UtilityHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "UtilityHull"));
			LightHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "LightHull"));
			MediumHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "MediumHull"));
			HeavyHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "HeavyHull"));
			ExtraHeavyHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "ExtraHeavyHull"));
			LightAndMedShieldTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "LightAndMediumShield"));
			LargeShieldTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "LargeShield"));
			PartsTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "Parts"));
			LightBaseHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "LightBaseHull"));
			LightBaseShieldTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "LightBaseShield"));
			MinorBaseHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "MinorBaseHull"));
			MinorBaseShieldTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "MinorBaseShield"));
			MajorBaseHullTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "MajorBaseHull"));
			MajorBaseShieldTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "MajorBaseShield"));
			AsteroidTextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "Asteroid"));
			AC15TextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "AC15"));
			AC16TextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "AC16"));
			AC17TextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "AC17"));
			AC18TextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "AC18"));
			AC19TextBox.DataBindings.Add(new Binding(Text, _constants.DamageIndexes, "AC19"));

			_bmDamageIndex = this.BindingContext[_constants.DamageIndexes];
			DamageIndexComboBox.SelectedIndex = 0;
		}

		/// <summary>
		/// Lists all parts that have the chosen DamageIndex;
		/// </summary>
		private void ListPartsByDamageIndex ()
		{
			int Index = DamageIndexComboBox.SelectedIndex;
			UsedByLabel.Text = string.Concat("Weapons with DM ", Index.ToString(), ":");
			StringBuilder SB = new StringBuilder();

			foreach (IGCCorePart Part in _core.Parts)
			{
				IGCCorePart RealPart = Part;
				int PartDM = -1;
				if (!(Part is IGCCorePartSpec) && !(Part is IGCCorePartWeapon))
					continue;

				if (Part is IGCCorePartSpec)
				{
					switch (Part.Slot)
					{
						case "invchaff":
							continue;
						case "invsmissile":
							RealPart = (IGCCorePart)_core.Missiles.GetObject((ushort)Part.Group);
							PartDM = ((IGCCoreMissile)RealPart).DamageIndex;
							break;
						case "invsmine":
							RealPart = (IGCCorePart)_core.Mines.GetObject((ushort)Part.Group);
							if (RealPart == null)
							{
								RealPart = (IGCCorePart)_core.Probes.GetObject((ushort)Part.Group);
								if (RealPart != null)
								{
									IGCCoreProjectile Proj = (IGCCoreProjectile)_core.Projectiles.GetModule((ushort)((IGCCoreProbe)RealPart).Projectile);
									if (Proj == null)
										continue;
									PartDM = Proj.DamageIndex;
								}
							}
							else
							{
								PartDM = ((IGCCoreMine)RealPart).DamageIndex;
							}
							break;
					}
				}
				else
				{
					if (Part is IGCCorePartWeapon)
					{
						IGCCoreProjectile Proj = (IGCCoreProjectile)_core.Projectiles.GetModule(((IGCCorePartWeapon)Part).ProjectileUID);
						PartDM = Proj.DamageIndex;
					}
				}
				
				if (Index == PartDM)
				{
					SB.Append(RealPart.Name);
					SB.Append(Environment.NewLine);
				}
			}
			if (SB.Length == 0)
				UsedByDMTextBox.Text = "<None>";
			else
				UsedByDMTextBox.Text = SB.ToString();
		}

		/// <summary>
		/// Lists all objects that share the chosen ArmorClass
		/// </summary>
		private void ListObjectsByArmorClass (int armorClass)
		{
			StringBuilder SB = new StringBuilder();

			foreach (IGCCoreStationType Station in _core.StationTypes)
			{
				if (Station.HullArmorClass == armorClass)
				{
					SB.Append(Station.Name);
					SB.Append(" Hull");
					SB.Append(Environment.NewLine);
				}
				if (Station.ShieldArmorClass == armorClass)
				{
					SB.Append(Station.Name);
					SB.Append(" Shield");
					SB.Append(Environment.NewLine);
				}
			}

			foreach (IGCCoreShip Ship in _core.Ships)
			{
				if ((int)Ship.ArmorClass == armorClass)
				{
					SB.Append(Ship.Name);
					SB.Append(Environment.NewLine);
				}
			}

			foreach (IGCCorePart Part in _core.Parts)
			{
				IGCCorePart RealPart = Part;
				int PartAC = -1;
				if (Part is IGCCorePartSpec)
				{
					switch (Part.Slot)
					{
						case "invchaff":
							RealPart = (IGCCoreCounter)_core.Countermeasures.GetObject((ushort)Part.Group);
							PartAC = (int)((IGCCoreCounter)RealPart).ArmorClass;
							break;
						case "invsmissile":
							RealPart = (IGCCorePart)_core.Missiles.GetObject((ushort)Part.Group);
							PartAC = ((IGCCoreMissile)RealPart).ArmorClass;
							break;
						case "invsmine":
							RealPart = (IGCCorePart)_core.Mines.GetObject((ushort)Part.Group);
							if (RealPart == null)
							{
								RealPart = (IGCCorePart)_core.Probes.GetObject((ushort)Part.Group);
								if (RealPart != null)
									PartAC = (int)((IGCCoreProbe)RealPart).ArmorClass;
							}
							else
							{
								PartAC = (int)((IGCCoreMine)RealPart).ArmorClass;
							}
							break;
					}
				}
				else
				{
					if (!(RealPart is IGCCorePartShield))
						continue;

					PartAC = (int)((IGCCorePartShield)Part).ArmorClass;
				}
				if (PartAC == armorClass)
				{
					SB.Append(RealPart.Name);
					SB.Append(Environment.NewLine);
				}
			}

			if (SB.Length == 0)
				UsedByACTextBox.Text = "<None>";
			else
				UsedByACTextBox.Text = SB.ToString();
		}

		private void DamageIndexComboBox_SelectedIndexChanged (object sender, System.EventArgs e)
		{
			_bmDamageIndex.Position = DamageIndexComboBox.SelectedIndex;
			ListPartsByDamageIndex();
		}

		private void DamageIndexComboBox_Click (object sender, System.EventArgs e)
		{
			ListPartsByDamageIndex();
		}

		private void DamageIndexForm_Resize (object sender, System.EventArgs e)
		{
			this.Width = 322;
		}

		private void ArmorClassLabel_Click (object sender, System.EventArgs e)
		{
			Control control = (Control)sender;
			int ArmorClass = int.Parse(control.Tag.ToString());
			ListObjectsByArmorClass(ArmorClass);
			UsedAgainstLabel.Text = string.Concat("Objects with AC ", ArmorClass.ToString(), ":");
		}

		private void ArmorClassTextBox_MouseDown (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ArmorClassLabel_Click(sender, null);
		}

		private void DamageIndexForm_Closed (object sender, System.EventArgs e)
		{
			this.Dispose(true);
		}

		private void Label_MouseEnter (object sender, System.EventArgs e)
		{
			Control Con = (Control)sender;
			Con.Cursor = Cursors.Hand;

			Con.ForeColor = Color.Yellow;
		}

		private void Label_MouseLeave (object sender, System.EventArgs e)
		{
			Control Con = (Control)sender;
			Con.Cursor = Cursors.Default;

			Con.ForeColor = this.ForeColor;
		}

		private void DamageIndexLabel_Click (object sender, System.EventArgs e)
		{
			_bmDamageIndex.Position = DamageIndexComboBox.SelectedIndex;
			ListPartsByDamageIndex();
		}

		private void BalloonTimer_Tick (object sender, System.EventArgs e)
		{
			if (_settings.ShowBalloonHelp == true && HelpBalloon.DamageIndexHelpShown == false)
			{
				Application.DoEvents();
				string HelpString = "<b>Choose a Damage/Armor Class</b>\r\n<hr=100%>\r\nUse this dropdown box, or click\r\na box below to see all objects with\r\nthe selected Armor/DamageClass";
				HelpBalloon BHelp = new HelpBalloon(HelpString, SystemIcons.Information, DamageIndexComboBox, true, BalloonDirection.BALLOON_LEFT_BOTTOM, BalloonEffect.BALLOON_EFFECT_SOLID);
				BHelp.ShowBalloon();
				HelpBalloon.DamageIndexHelpShown = true;
			}
			BalloonTimer.Enabled = false;
		}

		private void DamageIndexForm_Load(object sender, System.EventArgs e)
		{
			BalloonTimer.Enabled = true;
		}
	}
}
