using System;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for AGCObject.
	/// </summary>
	public abstract class AllegObject
	{	
		public event EventHandler	Updated;
		public event EventHandler	Closed;
		protected Core				_core;
		protected Team				_team;
		protected IGCCoreObject		_object;
		protected Factors			_factors;

		public AllegObject (Team team, IGCCoreObject coreObj)
		{
			_core = team.Game.Core;
			_team = team;
			_object = coreObj;
			_factors = team.CalculateFactors();
		}

		public virtual void Update ()
		{
			_factors = _team.CalculateFactors();
			if (Updated != null)
				Updated(this, new EventArgs());
		}

		public virtual void Close ()
		{
			if (Closed != null)
				Closed(this, new EventArgs());

			_team.OpenObjects.Remove(this);
		}

		public abstract float CalculateScanrange ();
		public abstract float CalculateSignature ();
		public abstract float DetectionScale ();
		public abstract float CalculateHullHitpoints ();
		public abstract float CalculateHullRepairRate ();
		public abstract float CalculateShieldHitpoints ();
		public abstract float CalculateShieldRepairRate ();

		public abstract float GetKillBonus ();
		public abstract int GetHullAC ();
		public abstract int GetShieldAC ();

		public override string ToString()
		{
			return string.Concat(_team.Faction.Name, ": ", _object.Name);
		}

		// ###############################################################

		public Core Core
		{
			get {return _core;}
		}

		public Team Team
		{
			get {return _team;}
		}

		public string Name
		{
			get {return _object.Name;}
		}
	}
}
