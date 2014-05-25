using System;
using System.Collections;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for Ship.
	/// </summary>
	public class Ship : AllegObject
	{
		public static IGCCorePartPack AmmoPack;
		public static IGCCorePartPack FuelPack;
		
		double _sensorBearing = 0;

		IGCCorePartWeapon[]		_weapons = null;
		bool					_fireWeapons = false;
		int						_weaponToFire = -1;	// -1 = all
		IGCCoreMissile			_missile;
		bool					_fireMissile = false;
		IGCCorePartWeapon[]		_turrets;
		bool[]					_fireTurrets;
		IGCCorePartAfterburner	_booster;
		bool					_fireBooster = false;
		IGCCorePartShield		_shield;
		IGCCorePartCloak		_cloak;
		bool					_useCloak = false;
		IGCCorePart				_pack;
		IGCCoreCounter			_chaff;
		IGCCorePart[]			_cargo;

		IGCCoreShip _ship = null;
		int			_numKills = 1;

		public Ship (Team team, IGCCoreShip ship) : base(team, ship)
		{
			_weapons = new IGCCorePartWeapon[4];
			_turrets = new IGCCorePartWeapon[4];
			_fireTurrets = new bool[4] {false, false, false, false};
			_cargo = new IGCCorePart[5];
			
			_ship = ship;
			AssignDefaultCargo();
		}

		public override void Update ()
		{
			for (int i = 0; i < _fireTurrets.Length; i++)
			{
				if (_fireTurrets[i] == true)
				{
					if (_turrets[i] == null)
					{
						_fireTurrets[i] = false;
					}
				}
			}

			base.Update ();
		}


		public override float CalculateScanrange ()
		{
			float Scanrange = _ship.Scanrange * _factors.ShipSensors;

			double TrueBearing = (_sensorBearing > (2 * Math.PI)) ? _sensorBearing - (2 * Math.PI) : _sensorBearing;
			TrueBearing += Math.PI / 2;
			if (TrueBearing > Math.PI && TrueBearing < (2 * Math.PI))
				Scanrange = (float)(Scanrange/(Math.Sqrt(15.0 * Math.Abs(Math.Cos(_sensorBearing)) + 1.0)));

			return Scanrange + this.DetectionScale();
		}

		public override float CalculateSignature ()
		{
			float Signature = _ship.Signature;

			for (int i = 0; i < _weapons.Length; i++)
			{
				IGCCorePartWeapon Weapon = _weapons[i];
				IGCCorePartWeapon Turret = _turrets[i];

				if (Weapon != null)
					if (_fireWeapons == true && (_weaponToFire == i || _weaponToFire == -1))
						Signature += Weapon.Signature;
				if (Turret != null)
					if (_fireTurrets[i] == true)
						Signature += Turret.Signature;
			}
			
			if (_missile != null)
				Signature += _missile.Signature;

			if (_shield != null)
				Signature += _shield.Signature;

			if (_fireBooster == true && _booster != null)
				Signature += _booster.Signature;

			Signature /= _factors.ShipSignature;

			if (_cloak != null)
				if (_useCloak == true)
					Signature -= (_cloak.SignatureReduction * Signature);

			return Signature;
		}

		public override float DetectionScale ()
		{
			return (_ship.Scale / 2);
		}

		public override float CalculateHullHitpoints ()
		{
			return _ship.Hitpoints * _factors.ShipHull;
		}

		public override float CalculateHullRepairRate ()
		{
			return 0;
		}

		public override float CalculateShieldHitpoints ()
		{
			return (_shield != null) ? (_shield.Hitpoints * _factors.ShipShield) : 0;
		}

		public override float CalculateShieldRepairRate ()
		{
			float Rate = 0;
			if (_shield != null)
				Rate = _shield.RechargeRate * _factors.ShipShieldRepairRate;

			return Rate;
		}

		public override float GetKillBonus()
		{
			return KillBonus;
		}


		public override int GetHullAC ()
		{
			return (int)_ship.ArmorClass;
		}

		public override int GetShieldAC ()
		{
			return (_shield != null) ? (int)_shield.ArmorClass : 0;
		}



		public float CalculateMass ()
		{
			float Mass = _ship.Mass;
			for (int i = 0; i < _weapons.Length; i++)
				if (_weapons[i] != null)
					Mass += _weapons[i].Mass;
			for (int i = 0; i < _turrets.Length; i++)
				if (_turrets[i] != null)
					Mass += _turrets[i].Mass;

			if (_missile != null)
			{
				int NumMissiles = (_ship.MissileCapacity / _missile.CargoPayload);
				Mass += _missile.Mass * (float)NumMissiles;
			}

			if (_booster != null)
				Mass += _booster.Mass;

			if (_shield != null)
				Mass += _shield.Mass;

			if (_cloak != null)
				Mass += _cloak.Mass;

			if (_chaff != null)
				Mass += _chaff.Mass;

			for (int i = 0; i < _cargo.Length; i++)
				if (_cargo[i] != null)
					Mass += _cargo[i].Mass;

			return Mass;
		}

		public float CalculatePitch ()
		{
			return _ship.PitchRate * _factors.ShipTurnRate;
		}

		public float CalculateYaw ()
		{
			return _ship.YawRate * _factors.ShipTurnRate;
		}

		public float CalculateRoll ()
		{
			return _ship.RollRate * _factors.ShipTurnRate;
		}

		public float CalculatePitchTorque ()
		{
			return _ship.PitchTorque * _factors.ShipTurnTorque;
		}

		public float CalculateYawTorque ()
		{
			return _ship.YawTorque * _factors.ShipTurnTorque;
		}

		public float CalculateRollTorque ()
		{
			return _ship.RollTorque * _factors.ShipTurnTorque;
		}

		public float CalculateRipTime ()
		{
			return _ship.RipcordTime / _factors.Ripcord;
		}

		public float CalculateEnergy ()
		{
			return _ship.Energy * _factors.ShipEnergy;
		}

		public float CalculateEnergyRecharge ()
		{
			return _ship.RechargeRate /* * _factors.ShipEnergy*/;
		}


		public void AssignDefaultCargo ()
		{
			// Add the default parts
			foreach (short id in _ship.DefaultLoadout)
			{
				if (id == -1)
					continue;

				IGCCorePart Part = GetOverriddenPart((ushort)id);
				// If the part doesn't exist, skip it
				if (Part == null)
					continue;

				if (Part is IGCCoreCounter && _chaff == null)
					if (CanMountPart(Part, ShipSlots.Chaff))
						_chaff = (IGCCoreCounter)Part;

				if (Part is IGCCoreMine && _pack == null)
					if (CanMountPart(Part, ShipSlots.Pack))
						_pack = Part;

				if (Part is IGCCoreMissile && _missile == null)
					if (CanMountPart(Part, ShipSlots.Missile))
						_missile = (IGCCoreMissile)Part;

				if (Part is IGCCoreProbe && _pack == null)
					if (CanMountPart(Part, ShipSlots.Pack))
						_pack = Part;

				if (Part is IGCCorePartAfterburner && _booster == null)
					if (CanMountPart(Part, ShipSlots.Booster))
						_booster = (IGCCorePartAfterburner)Part;

				if (Part is IGCCorePartCloak && _cloak == null)
					if (CanMountPart(Part, ShipSlots.Cloak))
						_cloak = (IGCCorePartCloak)Part;

				if (Part is IGCCorePartShield && _shield == null)
					if (CanMountPart(Part, ShipSlots.Shield))
						_shield = (IGCCorePartShield)Part;

				if (Part is IGCCorePartWeapon)
				{
					int WeaponIndex = 0;
					int TurretIndex = 0;
					for (int i = 0; i < _ship.WeaponMounts.Length; i++)
					{
						IGCCoreShipMP Mount = _ship.WeaponMounts[i];
						if (Mount.PartType == 1)
						{	// it's a weapon
							if (CanMountPart(Part, (ShipSlots)(WeaponIndex)))
								if (_weapons[WeaponIndex] == null)
									_weapons[WeaponIndex] = (IGCCorePartWeapon)Part;

							WeaponIndex++;
						}
						else
						{	// It's a turret!
							if (CanMountPart(Part, (ShipSlots)(TurretIndex + 4)))
								if (_turrets[TurretIndex] == null)
									_turrets[TurretIndex] = (IGCCorePartWeapon)Part;

							TurretIndex++;
						}
					}
				}
			}

			// Add default cargo

			bool AmmoRequired = (_ship.WeaponMounts.Length > 0);
			bool FuelRequired = CanUseSlot(ShipSlots.Booster);

			int SlotIndex = 0;
			// Add Slot 1: Missile, Pack, Fuel, Ammo, empty
			if (CanUseSlot(ShipSlots.Missile) && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = _missile;
			if (CanUseSlot(ShipSlots.Pack) == true && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = _pack;
			if (FuelRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = FuelPack;
			if (AmmoRequired == true && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = AmmoPack;

			SlotIndex++;

			// Add Slot 2: (Pack), (Missile), Ammo, Fuel, empty
			if (_cargo[0] != _pack && CanUseSlot(ShipSlots.Pack) && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = _pack;
			if (_cargo[0] != _missile && CanUseSlot(ShipSlots.Missile) && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = _missile;
			if (AmmoRequired == true && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = AmmoPack;
			if (FuelRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = FuelPack;

			SlotIndex++;

			// Add Slot 3: Fuel, ammo, empty
			if (FuelRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = FuelPack;
			if (AmmoRequired == true && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = AmmoPack;
			
			SlotIndex++;

			// Add Slot 4: ammo, fuel, empty
			if (AmmoRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = AmmoPack;
			if (FuelRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = FuelPack;

			SlotIndex++;

			// Add Slot 5: fuel, ammo, empty
			if (FuelRequired && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = FuelPack;
			if (AmmoRequired == true && _cargo[SlotIndex] == null)
				_cargo[SlotIndex] = AmmoPack;
		}

		/// <summary>
		/// Retrieves the most overriden part for the UID provided
		/// </summary>
		/// <param name="uid">A part UID to search</param>
		/// <returns>The most overriden useable part, or null if the specified UID cannot be used or does not exist</returns>
		public IGCCorePart GetOverriddenPart (ushort uid)
		{
			IGCCorePart Result = null;
			BitArray CurrentTech = _team.CalculateDefs();
			BitArray WorkingTech;
			IGCCorePart Part = (IGCCorePart)_team.Game.Core.Parts.GetObject(uid);

			if (Part != null)
			{
				do 
				{
					WorkingTech = (BitArray)CurrentTech.Clone();
					WorkingTech.And(Part.Techtree.Pres);
					if (!Part.Techtree.PreEquals(WorkingTech))
						break;	// This part is unavailable! Stop looking

					Result = Part;
					Part = (IGCCorePart)_team.Game.Core.Parts.GetObject((ushort)Part.OverridingUID);
				} while (Part != null);
			}
			
			return Result;
		}

		/// <summary>
		/// Determines whether or not this ship can mount anything in the specified slot
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool CanUseSlot (ShipSlots slot)
		{
			int Slot = (int)slot;
			bool Result = false;
			BitArray Mask = null;

			if (Slot < 8)
			{
				if (Slot < 4)
				{
					if (Slot >= _ship.WeaponMounts.Length)
						return false;

					if (_ship.WeaponMounts[Slot].PartType != 1)
						return false;

					Mask = _ship.WeaponMounts[Slot].PartMask;
				}
				else
				{
					int TurretIndex = GetWeaponCount() + (Slot - 4);
					if (TurretIndex >= _ship.WeaponMounts.Length)
						return false;
					Mask = _ship.WeaponMounts[TurretIndex].PartMask;
				}
			}

			if (Mask == null)
				Mask = _ship.UseMasks[((int)slot) - 8];

			foreach (bool value in Mask)
			{
				if (value == true)
				{
					Result = value;
					break;
				}
			}

			return Result;
		}

		public int GetWeaponCount ()
		{
			int i = 0;
			int NumWeapons = 0;
			while (i < _ship.WeaponMounts.Length)
			{
				if (_ship.WeaponMounts[i].PartType == 1)
					NumWeapons++;
				i++;
			}

			return NumWeapons;
		}

		public int GetTurretCount ()
		{
			return (_ship.WeaponMounts.Length - GetWeaponCount());
		}

		/// <summary>
		/// Determines whether or not this ship can mount the specified part
		/// </summary>
		/// <param name="part"></param>
		/// <returns></returns>
		public bool CanMountPart (IGCCorePart part, ShipSlots slot)
		{
			if (part == null)
				return CanUseSlot(slot);

			bool Result = false;
			BitArray SlotMask = null;

			// Find which SlotMask we need to compare
			int MaskIndex = -1;
			switch (part.ModuleType)
			{
				case AGCObjectType.AGC_ChaffType:
					if (slot == ShipSlots.Chaff || (int)slot > 15)
						MaskIndex = (int)ShipUseMasks.Counter;
					break;
				case AGCObjectType.AGC_MineType:
					if (slot == ShipSlots.Pack || (int)slot > 15)
						MaskIndex = (int)ShipUseMasks.Pack;
					break;
				case AGCObjectType.AGC_MissileType:
					if (slot == ShipSlots.Missile || (int)slot > 15)
						MaskIndex = (int)ShipUseMasks.Missile;
					break;
				case AGCObjectType.AGC_ProbeType:
					if (slot == ShipSlots.Pack || (int)slot > 15)
						MaskIndex = (int)ShipUseMasks.Pack;
					break;
				case AGCObjectType.AGC_PartType:
					switch (part.PartType)
					{
						case PartType.Afterburner:
							if (slot == ShipSlots.Booster || (int)slot > 15)
								MaskIndex = (int)ShipUseMasks.Booster;
							break;
						case PartType.Cloak:
							if (slot == ShipSlots.Cloak || (int)slot > 15)
								MaskIndex = (int)ShipUseMasks.Cloak;
							break;
						case PartType.Shield:
							if (slot == ShipSlots.Shield || (int)slot > 15)
								MaskIndex = (int)ShipUseMasks.Shield;
							break;
						case PartType.Pack:
							if ((int)slot < 16) // You can't mount ammo or fuel in bays
								return false;
							else
								SlotMask = new BitArray(16, true);
							break;
						case PartType.Weapon:
							int Slot = (int)slot;
							if (Slot >= 8 && Slot < 16)
								return false;

							if (Slot < 8)
							{
								if (_ship.WeaponMounts.Length == 0)
									return false;

								if (Slot < 4)
									SlotMask = (BitArray)_ship.WeaponMounts[Slot].PartMask.Clone();
								else
									SlotMask = (BitArray)_ship.WeaponMounts[GetWeaponCount() + (Slot - 4)].PartMask.Clone();
							}
							else
								SlotMask = new BitArray(16, true);
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}

			// Get the required slot mask for comparison if it isn't a gun/turret
			if (SlotMask == null)
			{
				if (MaskIndex == -1)
					return false;
				SlotMask = (BitArray)_ship.UseMasks[MaskIndex].Clone();
			}
			
			SlotMask.And(part.UseMask);
			// Check if part matches the slot mask
			if (Techtree.BitArrayEquals(SlotMask, part.UseMask) || (int)slot > 15)
			{	// Part can be mounted. Is it available?
				BitArray CurrentDefs = _team.CalculateDefs();
				CurrentDefs.And(part.Techtree.Pres);
				if (part.Techtree.PreEquals(CurrentDefs))
					Result = true;
			}

			return Result;
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

		public IGCCoreShip IGCShip
		{
			get {return _ship;}
		}

		public IGCCorePartWeapon[] Weapons
		{
			get {return _weapons;}
		}

		public bool FireWeapons
		{
			get {return _fireWeapons;}
			set {_fireWeapons = value; Update();}
		}

		public int WeaponToFire
		{
			get {return _weaponToFire;}
			set {_weaponToFire = value;}
		}

		public IGCCoreMissile Missile
		{
			get {return _missile;}
			set
			{
				_missile = value;
				if (value == null)
					_fireMissile = false;
				Update();
			}
		}

		public bool FireMissile
		{
			get {return _fireMissile;}
			set {_fireMissile = value; Update();}
		}

		public IGCCorePartWeapon[] Turrets
		{
			get {return _turrets;}
		}

		public bool[] FireTurrets
		{
			get	{return _fireTurrets;}
		}

		public IGCCorePartAfterburner Booster
		{
			get {return _booster;}
			set
			{
				_booster = value;
				if (value == null)
					_fireBooster = false;

				Update();
			}
		}
		
		public bool FireBooster
		{
			get {return _fireBooster;}
			set {_fireBooster = value; Update();}
		}

		public IGCCorePartShield Shield
		{
			get {return _shield;}
			set {_shield = value; Update();}
		}

		public IGCCorePartCloak Cloak
		{
			get {return _cloak;}
			set
			{
				_cloak = value;
				if (value == null)
					_useCloak = false;
				Update();
			}
		}

		public bool UseCloak
		{
			get {return _useCloak;}
			set {_useCloak = value; Update();}
		}

		public IGCCorePart Pack
		{
			get {return _pack;}
			set {_pack = value; Update();}
		}

		public IGCCoreCounter Chaff
		{
			get {return _chaff;}
			set {_chaff = value; Update();}
		}

		public IGCCorePart[] Cargo
		{
			get {return _cargo;}
		}

		public double BearingDegrees
		{
			get {return Math.Round(_sensorBearing / (Math.PI / 180));}
			set {_sensorBearing = value * (Math.PI / 180); Update();}
		}

		public double Bearing
		{
			get {return _sensorBearing;}
			set {_sensorBearing = value; Update();}
		}
	}

	/// <summary>
	/// A numeric index assigned to each slot
	/// </summary>
	public enum ShipSlots
	{
		Weapon1 = 0,
		Weapon2 = 1,
		Weapon3 = 2,
		Weapon4 = 3,
		Turret1 = 4,
		Turret2 = 5,
		Turret3 = 6,
		Turret4 = 7,
		Chaff = 8,
		Missile = 10,
		Pack = 11,
		Shield = 12,
		Cloak = 13,
		Booster = 15,
		Any = 255
	}
}
