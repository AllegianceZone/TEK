using System;
using System.Drawing;
using System.Collections;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for AllegianceTeam.
	/// </summary>
	public class Team : IDisposable
	{
		Color[]			_teamColors = new Color[6] {Color.Gold, Color.DodgerBlue, Color.Magenta, Color.Green, Color.Salmon, Color.Turquoise};
		Game			_game;
		IGCCoreCiv		_faction;
		ObjectList		_stations;
		ObjectList		_research;
		ArrayList		_openObjects;
		Color			_teamColor;

		public Team (Game game, int teamNumber)
		{
			_game = game;
			_stations = new ObjectList();
			_research = new ObjectList();
			_openObjects = new ArrayList();
			_teamColor = _teamColors[teamNumber];

			if (game.Core.Factions.Count > 0)
			{
				Faction = (IGCCoreCiv)game.Core.Factions[0];
			}
		}

		public void Dispose ()
		{
			_stations.Clear();
			_research.Clear();

			while (_openObjects.Count > 0)
				((AllegObject)_openObjects[0]).Close();

			_game.Teams.Remove(this);
		}

		/// <summary>
		/// Calculates the sum of all stations and developments
		/// </summary>
		/// <returns></returns>
		public BitArray CalculateDefs ()
		{
			BitArray Defs = (BitArray)_game.GameDefs.Clone();				// Start with GameDefs
			if (_game.GameDefs[1] == false)
				Defs = Defs.Or(_faction.Techtree.Defs); // No development; Add the defs.
			else
				Defs = Defs.Or(_faction.Techtree.Pres);	// Development on; Add Faction pres.

			foreach (IGCCoreStationType Station in _stations)				// Add each station's def
			{
				Defs = Defs.Or(Station.Techtree.Defs);
				Defs = Defs.Or(Station.TechTreeLocal);
			}
			foreach (IGCCoreDevel Devel in _research)					// Add each research's def
			{
				Defs = Defs.Or(Devel.Techtree.Defs);
			}

			return Defs;
		}

		public Factors CalculateFactors ()
		{
			Factors Facts = new Factors();
			Facts.Combine(_faction.Factors);

			foreach (IGCCoreDevel Devel in _research)
			{
				Facts.Combine(Devel.Factors);
			}

			return Facts;
		}

		/// <summary>
		/// Calculates the total amount of credits spent on stations and research
		/// </summary>
		/// <returns></returns>
		public int CalculateTotalCost ()
		{
			int Cost = 0;
			foreach (IGCCoreStationType Stat in _stations)
				Cost += Stat.Cost;

			foreach (IGCCoreDevel Devel in _research)
				Cost += (int)Devel.Cost;

			IGCCoreStationType Garrison = (IGCCoreStationType)_game.Core.StationTypes.GetObject(_faction.Garrison_UID);
			Cost -= Garrison.Cost;
			return Cost;
		}

		/// <summary>
		/// This team's faction
		/// </summary>
		public IGCCoreCiv Faction
		{
			get {return _faction;}
			set
			{
				if (value != _faction)
				{
					_faction = value;
					_stations.Clear();
					_research.Clear();
					_stations.Add(_game.Core.StationTypes.GetObject(_faction.Garrison_UID));
				}
			}
		}

		public Game Game
		{
			get {return _game;}
		}

		public ObjectList Stations
		{
			get {return _stations;}
		}

		public ObjectList Research
		{
			get {return _research;}
		}

		public ArrayList OpenObjects
		{
			get {return _openObjects;}
		}

		public Color TeamColor
		{
			get {return _teamColor;}
		}
		}
}
