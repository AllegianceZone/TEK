using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for AngleChooserUserControl.
	/// </summary>
	public class AngleChooser : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.PictureBox SensorEnvelopePictureBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Ship	_targetShip = null;
		TextBox _bearingTextBox = null;
		double	_bearing = 0;

		public AngleChooser (Ship ship, TextBox bearingTextBox)
		{
			InitializeComponent();
			_targetShip = ship;
			_bearingTextBox = bearingTextBox;
			_bearing = ship.Bearing;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AngleChooser));
			this.SensorEnvelopePictureBox = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// SensorEnvelopePictureBox
			// 
			this.SensorEnvelopePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("SensorEnvelopePictureBox.Image")));
			this.SensorEnvelopePictureBox.Location = new System.Drawing.Point(2, 2);
			this.SensorEnvelopePictureBox.Name = "SensorEnvelopePictureBox";
			this.SensorEnvelopePictureBox.Size = new System.Drawing.Size(57, 57);
			this.SensorEnvelopePictureBox.TabIndex = 0;
			this.SensorEnvelopePictureBox.TabStop = false;
			this.SensorEnvelopePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SensorEnvelopePictureBox_Paint);
			this.SensorEnvelopePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SensorEnvelopePictureBox_MouseUp);
			this.SensorEnvelopePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SensorEnvelopePictureBox_MouseMove);
			this.SensorEnvelopePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SensorEnvelopePictureBox_MouseDown);
			// 
			// AngleChooser
			// 
			this.BackColor = System.Drawing.Color.Maroon;
			this.Controls.Add(this.SensorEnvelopePictureBox);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "AngleChooser";
			this.Size = new System.Drawing.Size(61, 61);
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateBearing (int x, int y)
		{
			_bearing = Math.Atan2(28 - y, 28 - x);
			_bearing -= Math.PI / 2;
			if (_bearing < 0)
				_bearing += 2 * Math.PI;
			_targetShip.Bearing = _bearing;
			_bearingTextBox.Text = _targetShip.BearingDegrees.ToString() + "°";
			SensorEnvelopePictureBox.Refresh();
		}

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

		private void SensorEnvelopePictureBox_MouseUp (object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				UpdateBearing(e.X, e.Y);
				_targetShip.Update();
				this.Hide();
				ComparisonForm Comp = (ComparisonForm)this.Parent;
				if (_bearingTextBox.Tag.ToString().Equals("1"))
					Comp.Chooser1 = null;
				else
					Comp.Chooser2 = null;

				this.Parent.Controls.Remove(this);
				this.Dispose(true);
			}
		}
	}
}
