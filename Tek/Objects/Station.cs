using System;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for Station.
	/// </summary>
	public class Station : AllegObject
	{
		private IGCCoreStationType _station;
		public Station (Team team, IGCCoreStationType station) : base(team, station)
		{
			_station = station;
		}

		public override float CalculateScanrange ()
		{
			float Scanrange = _station.Scanrange * _factors.ShipSensors;

			return Scanrange;
		}

		public override float CalculateSignature ()
		{
			float Signature = _station.Signature / _factors.ShipSignature;
			return Signature;
		}

		public override float DetectionScale ()
		{
			return _station.Scale;
		}

		public override float CalculateHullHitpoints ()
		{
			return _station.Hull * _factors.StationHull;
		}

		public override float CalculateHullRepairRate ()
		{
			return _station.HullRepairRate * _factors.StationHullRepairRate;
		}

		public override float CalculateShieldHitpoints ()
		{
			return _station.Shield * _factors.StationShield;
		}

		public override float CalculateShieldRepairRate ()
		{
			return _station.ShieldRepairRate * _factors.StationShieldRepairRate;
		}

		public override float GetKillBonus ()
		{
			return 0;
		}


		public override int GetHullAC ()
		{
			return (int)_station.HullArmorClass;
		}

		public override int GetShieldAC ()
		{
			return (int)_station.ShieldArmorClass;
		}


		public IGCCoreStationType IGCStation
		{
			get {return _station;}
		}
	}
}
