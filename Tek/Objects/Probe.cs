using System;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for Probe.
	/// </summary>
	public class Probe : AllegObject
	{
		IGCCoreProbe _probe;
		int _numKills = 1;

		public Probe (Team team, IGCCoreProbe probe) : base(team, probe)
		{
			_probe = probe;
		}

		public override float CalculateScanrange ()
		{
			float Scanrange = _probe.Scanrange * _factors.ShipSensors;

			return Scanrange;
		}

		public override float CalculateSignature ()
		{
			float Signature = _probe.Signature / _factors.ShipSignature;
			return Signature;
		}

		public override float DetectionScale ()
		{
			return _probe.Scale;
		}

		public override float CalculateHullHitpoints ()
		{
			return _probe.Hitpoints * _factors.StationHull;
		}

		public override float CalculateHullRepairRate()
		{
			return 0;
		}

		public override float CalculateShieldHitpoints ()
		{
			return 0;
		}

		public override float CalculateShieldRepairRate ()
		{
			return 0;
		}

		public override float GetKillBonus()
		{
			return KillBonus;
		}


		public override int GetHullAC ()
		{
			return (int)_probe.ArmorClass;
		}

		public override int GetShieldAC ()
		{
			return -1;
		}

		public IGCCoreProbe IGCProbe
		{
			get {return _probe;}
		}

		public int Kills
		{
			get {return _numKills;}
			set {_numKills = (value < 0) ? 0 : value;}
		}

		public float KillBonus
		{
			get {return (float)Math.Round((_numKills / (_numKills + 4D) * 50D), 0);}
		}
	}
}
