using System;
using System.Collections;
using System.Windows.Forms;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Util;
using FreeAllegiance.IGCCore.Modules;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for AllegianceGame.
	/// </summary>
	public class Game : IDisposable
	{
		public event EventHandler MeChanged;
		public event EventHandler TargetChanged;
		const int ALLOWDEVELOPMENT = 1;
		const int DEATHMATCH = 2;
		const int ALLOWSUPREMACY = 3;
		const int ALLOWTACTICAL = 4;
		const int ALLOWEXPANSION = 5;
		const int ALLOWSHIPYARDS = 6;
		const int CAPTURETHEFLAG = 7;
		//const int ALLOWARTIFACTS = ?;
		//const int PROSPERITY = ?;

		Core		_core;
		ArrayList	_teams;
		BitArray	_gameDefs;
		ArrayList	_comparisons;
		
		Team		_myTeam = null;
		Ship		_me = null;
		AllegObject _target = null;

		public Game (string corePath, int numTeams, int myTeam, bool allowDevelopment, bool allowShipyards, bool deathMatch, bool captureTheFlag, bool allowArtifacts, bool prosperity)
		{
			_core = new Core(corePath);
			_teams = new ArrayList(numTeams);
			_comparisons = new ArrayList(3);

			_gameDefs = new BitArray(400, false);
			_gameDefs[ALLOWDEVELOPMENT] = allowDevelopment;
			_gameDefs[ALLOWSUPREMACY] = allowDevelopment;
			_gameDefs[ALLOWTACTICAL] = allowDevelopment;
			_gameDefs[ALLOWEXPANSION] = allowDevelopment;
			_gameDefs[ALLOWSHIPYARDS] = allowShipyards;
			_gameDefs[DEATHMATCH] = deathMatch;
			_gameDefs[CAPTURETHEFLAG] = captureTheFlag;
			//_gameDefs[ALLOWARTIFACTS] = allowArtifacts;
			//_gameDefs[PROSPERITY] = prosperity;

			for (int i = 0; i < numTeams; i++)
			{
				_teams.Add(new Team(this, i));
			}

			_myTeam = (Team)_teams[myTeam - 1];
			
			// Get references to the ammo and fuel packs
			foreach (IGCCorePart Part in _core.Parts)
			{
				if (Part is IGCCorePartPack)
				{
					IGCCorePartPack Pack = (IGCCorePartPack)Part;
					if (Pack.PackType == PackType.Ammo)
						Ship.AmmoPack = Pack;

					if (Pack.PackType == PackType.Fuel)
						Ship.FuelPack = Pack;
				}
			}
		}

		public void Dispose ()
		{
			while (_teams.Count > 0)
				((Team)_teams[0]).Dispose();
		}

		public Core Core
		{
			get {return _core;}
		}

		public ArrayList Teams
		{
			get {return _teams;}
		}

		public ArrayList Comparisons
		{
			get {return _comparisons;}
		}

		public BitArray GameDefs
		{
			get {return _gameDefs;}
			set {_gameDefs = value;}
		}

		public Team MyTeam
		{
			get {return _myTeam;}
		}

		public Ship Me
		{
			get {return _me;}
			set
			{
				_me = value;
				if (MeChanged != null)
					MeChanged(_me, new EventArgs());
			}
		}

		public AllegObject Target
		{
			get {return _target;}
			set
			{
				_target = value;
				if (TargetChanged != null)
					TargetChanged(_target, new EventArgs());
			}
		}
	}
}
