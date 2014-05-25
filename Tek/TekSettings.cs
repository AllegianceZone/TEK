using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for TekSettings.
	/// </summary>
	public class TekSettings
	{
		private const double	SETTINGSVERSION = 1.5;
		private const string	SETTINGSNAME = "TekSettings";

		private StartupAction	_startup = StartupAction.DoNothing;
		private string			_specifiedCore = string.Empty;
		private string			_lastCore = string.Empty;
		private string			_defaultCoreLocation = string.Empty;
		private int				_numTeams = 2;
		private bool			_rememberRecentCores = false;
		private ArrayList		_recentCores = new ArrayList(3);
		private bool			_showOverridden = false;
		private bool			_showToolTips = true;
		private bool			_showBalloonHelp = true;

		// Event Handlers required for updating UI controls when databound
		public event EventHandler StartupChanged = new EventHandler(EventStub);
		public event EventHandler SpecifiedCoreChanged = new EventHandler(EventStub);
		public event EventHandler LastCoreChanged = new EventHandler(EventStub);
		public event EventHandler DefaultCoreLocationChanged = new EventHandler(EventStub);
		public event EventHandler ShowOverriddenChanged = new EventHandler(EventStub);
		public event EventHandler NumTeamsChanged = new EventHandler(EventStub);
		public event EventHandler RememberRecentCoresChanged = new EventHandler(EventStub);
		public event EventHandler RecentCoresChanged = new EventHandler(EventStub);
		public event EventHandler ShowToolTipsChanged = new EventHandler(EventStub);
		public event EventHandler ShowBalloonHelpChanged = new EventHandler(EventStub);

		/// <summary>
		/// A dummy method that is bound to the PropertyChanged event of all settings properties.
		/// </summary>
		private static void EventStub (object sender, EventArgs e) {}

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TekSettings () {}

		/// <summary>
		/// Loads the Settings file
		/// </summary>
		/// <param name="filePath">The fully-qualified path of the Settings object.</param>
		/// <returns>a Settings object containing the user-defined settings.</returns>
		public static TekSettings Deserialize (string filePath)
		{
			TekSettings NewSettings = null;

			FileStream FS = null;
			XmlTextReader XmlIn = null;
			try
			{
				// Prepare to read the file
				FS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				XmlIn = new XmlTextReader(FS);
			
				// Ignore all whitespace
				XmlIn.WhitespaceHandling = WhitespaceHandling.None;

				// Move to first node
				XmlIn.MoveToContent();

				// Doublecheck the name of the node
				if (!XmlIn.Name.Equals(SETTINGSNAME))
					throw new ArgumentException("An improperly formatted Settings file was encountered.");

				if (XmlIn.AttributeCount != 1)
					throw new ArgumentException("There is no version associated with this Settings file.");

				// Check the version of the settings file
				double SettingsVersion = double.Parse(XmlIn.GetAttribute(0));
				if (SettingsVersion != SETTINGSVERSION)
				{
					string VersionMismatchMessage;
					DialogResult Result;
					if (SettingsVersion < SETTINGSVERSION)
						VersionMismatchMessage = "The version of the settings file is older than the version supported by this program.\nYour settings are compatible with the new version.\n\nDo you want to convert your settings to the new version?";
					else
						VersionMismatchMessage = "The version of the settings file is newer than the version supported by this program.\nErrors may result if you continue.\nIt is recommended to save over these settings to ensure validity.\n\nDo you want to attempt to load these settings?";

					// Prompt the user what to do if the version mismatches.
					Result = MessageBox.Show(VersionMismatchMessage, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					switch (Result)
					{
						case DialogResult.Yes:	// Attempt to continue parsing
							break;
						case DialogResult.No:	// Abort parsing. No settings loaded.
						default:
							XmlIn.Close();
							FS.Close();
							return null;
					}
				}
				
				// Read each individual setting
				NewSettings = new TekSettings();
				PropertyInfo Property = null;
				while (!XmlIn.EOF)
				{
					if (!XmlIn.Read())
						throw new ArgumentException("Expected an XmlNode but got none! Settings file may be corrupt.");

					// If it's the end-root node, exit loop.
					// If it's the end-property node, go to next.
					if (XmlIn.NodeType == XmlNodeType.EndElement)
					{
						if (XmlIn.Name.Equals(SETTINGSNAME))
							break;
						else
							continue;
					}

					// XmlNode type should be an Element or Text.

					// If reading a property element...
					if (XmlIn.NodeType == XmlNodeType.Element)
					{
						if (!XmlIn.Name.Equals("Core"))
							Property = typeof(TekSettings).GetProperty(XmlIn.Name);
					}
	
					if (XmlIn.NodeType == XmlNodeType.Text)
					{
						if (Property != null)
						{
							if (Property.PropertyType.Equals(typeof(ArrayList)))
							{
								ArrayList List = (ArrayList)Property.GetValue(NewSettings, null);
								List.Add(Convert.ChangeType(XmlIn.Value, typeof(string)));
							}
							else
							{
								Property.SetValue(NewSettings, Convert.ChangeType(XmlIn.Value, Property.PropertyType), null);
							}
						}
					}
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Could not load Settings: file does not exist at that location.", Application.ProductName);
			}
			catch (EndOfStreamException)
			{
				MessageBox.Show("Could not load Settings: End of file reached prematurely.", Application.ProductName);
			}
			catch (PathTooLongException)
			{
				MessageBox.Show("You have specified a path that is too long. Please specify a shorter one.", Application.ProductName);
			}
			catch (IOException e)
			{
				MessageBox.Show("IOError: Could not read Settings.\n" + e.Message, Application.ProductName);
			}
			catch (XmlException e)
			{
				MessageBox.Show("XmlError: Could not read Settings.\n" + e.Message, Application.ProductName);
			}
			catch (Exception e)
			{
				MessageBox.Show("General Error: Could not read Settings.\n" + e.Message, Application.ProductName);
			}
			finally
			{
				// Clean up
				if (XmlIn != null)
					XmlIn.Close();;
				if (FS != null)
					FS.Close();
			}

			return NewSettings;
		}

		/// <summary>
		/// Writes the Settings to the specified location.
		/// </summary>
		/// <param name="filePath">The fully-qualified path where this Settings object should be written to.</param>
		public void Serialize (string filePath)
		{
			XmlTextWriter XmlOut = null;
			FileStream FS = null;
		
			try
			{
				// Prepare to write the file
				FS = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
				XmlOut = new XmlTextWriter(FS, Encoding.ASCII);
				XmlOut.Formatting = Formatting.Indented;

				// Get a list of all of the settings defined
				PropertyInfo[] Properties = this.GetType().GetProperties();

				// Write the file
				XmlOut.WriteStartDocument();

				// Customize XML document for DFC
				XmlOut.WriteComment("This file contains settings for TE's Kneeboard.");
				XmlOut.WriteComment("It is not recommended to edit this file manually.");
				XmlOut.WriteComment("You can change these settings from within Tek.");

				XmlOut.WriteStartElement(SETTINGSNAME);
				XmlOut.WriteAttributeString("SettingsVersion", SETTINGSVERSION.ToString());
				// Loop through every property and write it
				foreach (PropertyInfo Property in Properties)
				{
					if (Property.PropertyType.Equals(typeof(ArrayList)))
					{
						XmlOut.WriteStartElement(Property.Name);
						ArrayList List = (ArrayList)Property.GetValue(this, null);
						foreach (object item in List)
							XmlOut.WriteElementString("Core", item.ToString());
						XmlOut.WriteEndElement();
					} 
					else 
					{
						XmlOut.WriteElementString(Property.Name, Property.GetValue(this, null).ToString());
					}
				}

				// End the main element and document
				XmlOut.WriteEndElement();
				XmlOut.WriteEndDocument();
			}
			catch (DirectoryNotFoundException)
			{
				MessageBox.Show("Attempt to create Settings file in a non-existant directory. Verify the directory exists, then try again.", Application.ProductName);
			}
			catch (PathTooLongException)
			{
				MessageBox.Show("The path for the Settings file is too long. Please use a shorter name.", Application.ProductName);
			}
			catch (IOException e)
			{
				MessageBox.Show("IO Error: Could not write the Settings to disk. \n" + e.Message, Application.ProductName);
			}
			catch (XmlException e)
			{
				MessageBox.Show("XML Error: Could not write the Settings to disk. \n" + e.Message, Application.ProductName);
			}
			catch (Exception e)
			{
				MessageBox.Show("General Error: Could not write the Settings to disk. \n" + e.Message, Application.ProductName);
			}
			finally
			{
				// Clean up
				if (XmlOut != null)
					XmlOut.Close();

				if (FS != null)
					FS.Close();
			}
		}

		/// <summary>
		/// The action to take when the Tek application starts
		/// </summary>
		public int Startup
		{
			get {return (int)_startup;}
			set	{_startup = (StartupAction)value;StartupChanged(this, new EventArgs());}
		}

		/// <summary>
		/// The core to load when the StartupAction is "LoadSpecified"
		/// </summary>
		public string SpecifiedCore
		{
			get {return _specifiedCore;}
			set	{_specifiedCore = value;SpecifiedCoreChanged(this, new EventArgs());}
		}

		/// <summary>
		/// The last core successfully loaded into the Tek
		/// </summary>
		public string LastCore
		{
			get {return _lastCore;}
			set	{_lastCore = value;LastCoreChanged(this, new EventArgs());}
		}

		/// <summary>
		/// The folder containing the core files. If empty, the Allegiance Artwork path will be used instead.
		/// </summary>
		public string DefaultCoreLocation
		{
			get {return _defaultCoreLocation;}
			set	{_defaultCoreLocation = value;DefaultCoreLocationChanged(this, new EventArgs());}
		}

		/// <summary>
		/// The number of teams to use in auto-created games
		/// </summary>
		public int NumTeams
		{
			get {return _numTeams;}
			set {_numTeams = value; NumTeamsChanged(this, new EventArgs());}
		}

		/// <summary>
		/// Specifies whether or not Tek should remember the recently viewed cores
		/// </summary>
		public bool RememberRecentCores
		{
			get {return _rememberRecentCores;}
			set	{_rememberRecentCores = value;RememberRecentCoresChanged(this, new EventArgs());}
		}

		/// <summary>
		/// A list of recently used cores
		/// </summary>
		public ArrayList RecentCores
		{
			get {return _recentCores;}
			set	{_recentCores = value;RecentCoresChanged(this, new EventArgs());}
		}

		/// <summary>
		/// Determines whether or not the tooltips are shown
		/// </summary>
		public bool ShowToolTips
		{
			get {return _showToolTips;}
			set {_showToolTips = value;ShowToolTipsChanged(this, new EventArgs());}
		}

		/// <summary>
		/// Determines whether or not to show the balloon help tutorials
		/// </summary>
		public bool ShowBalloonHelp
		{
			get {return _showBalloonHelp;}
			set {_showBalloonHelp = value;ShowBalloonHelpChanged(this, new EventArgs());}
		}

		/// <summary>
		/// Shows tech and ships even if its overriding tech has been researched
		/// </summary>
		public bool ShowOverridden
		{
			get {return _showOverridden;}
			set {_showOverridden = value;ShowOverriddenChanged(this, new EventArgs());}
		}
	}

	public enum StartupAction
	{
		DoNothing = 0,
		LoadLastPlayed = 1,
		LoadLastUsed = 2,
		LoadSpecified = 3
	}
}
