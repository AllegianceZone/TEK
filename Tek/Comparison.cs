using System;

using FreeAllegiance.IGCCore;
using FreeAllegiance.IGCCore.Modules;
using FreeAllegiance.IGCCore.Util;

namespace FreeAllegiance.Tek
{
	/// <summary>
	/// Summary description for Comparison.
	/// </summary>
	public class Comparison
	{
		private AllegObject _object1;
		private AllegObject _object2;
		private float		_accuracy;
		private float		_kb;
		private float		_launchSpeed;

		IGCCorePart[] shipCargo;
		IGCCoreMissile firingMissile;
		DamageIndex[] DamageIndices = null;
		Factors Mods = null;

		int HullAC = -1;
		float HullHitpoints = 0F;
		float HullRecharge = 0F;
		int ShieldAC = -1;
		float ShieldHitpoints = 0F;
		float ShieldRecharge = 0F;

		float ReloadAmmoTime = 0F;
		float ArmGunsTime = 0F;
		float ReloadMissileTime = 0F;
		float ArmMissileTime = 0F;
		float ArmTurret1Time = 0F;
		float ArmTurret2Time = 0F;
		float ArmTurret3Time = 0F;
		float ArmTurret4Time = 0F;

		float AmmoClip = 0F;
		float Battery = 0F;
		float MissilePack = 0F;

		private float _timeToKill = 0F;
		private float _range = 0F;
		private float _ammoUsed = 0F;
		private float _energyUsed = 0F;
		private float _missilesUsed = 0F;
		private float _damageDealt = 0F;

		public Comparison (AllegObject shooter, float kb, float accuracy, float launchSpeed)
		{
			_object1 = shooter;
			_kb = kb;
			_accuracy = accuracy;
			_launchSpeed = launchSpeed;

			AmmoClip = (_object1 is Probe) ? ((Probe)_object1).IGCProbe.AmmoCapacity : (short)((Ship)_object1).IGCShip.AmmoCapacity;
			Battery = (_object1 is Ship) ? ((Ship)_object1).CalculateEnergy() : 0F;

			Mods = shooter.Team.CalculateFactors();

			if (shooter is Ship)
			{
				Ship ship = (Ship)shooter;
				shipCargo = new IGCCorePart[5];
				for (int i = 0; i < ship.Cargo.Length; i++)
				{
					shipCargo[i] = ship.Cargo[i];
				}
				firingMissile = ship.Missile;
			}
			Calculate();
		}

		public Comparison (AllegObject shooter, float kb, float accuracy, float launchSpeed, AllegObject killed)
		{
			_accuracy = accuracy;
			_object1 = shooter;
			_object2 = killed;
			_kb = kb;
			_launchSpeed = launchSpeed;

			HullAC = killed.GetHullAC();
			HullHitpoints = killed.CalculateHullHitpoints();
			HullRecharge = killed.CalculateHullRepairRate();
			ShieldAC = killed.GetShieldAC();
			ShieldHitpoints = killed.CalculateShieldHitpoints();
			ShieldRecharge = killed.CalculateShieldRepairRate();

			AmmoClip = (_object1 is Probe) ? ((Probe)_object1).IGCProbe.AmmoCapacity : (short)((Ship)_object1).IGCShip.AmmoCapacity;
			Battery = (_object1 is Ship) ? ((Ship)_object1).CalculateEnergy() : 0F;

			DamageIndices = shooter.Core.Constants.DamageIndexes;
			Mods = shooter.Team.CalculateFactors();
			
			if (shooter is Ship)
			{
				Ship ship = (Ship)shooter;
				shipCargo = new IGCCorePart[5];
				for (int i = 0; i < ship.Cargo.Length; i++)
				{
					shipCargo[i] = ship.Cargo[i];
				}
				firingMissile = ship.Missile;
			}
			Calculate();
		}

		private void Calculate ()
		{
			if (_object1 is Station)
			{
				_timeToKill = float.PositiveInfinity;
				return;
			}

			float Interval = _object1.Core.Constants.DownedShield;
			
			if (_object1 is Ship)
			{
				Ship ship = (Ship)_object1;
				if (ship.FireMissile && firingMissile != null)
					MissilePack = ship.IGCShip.MissileCapacity / firingMissile.CargoPayload;
			}

			float WeaponDamage = 0F;

			bool DownedShield = false;
			bool TakingDamage = false;
			while (true)
			{
				_timeToKill += Interval;
				if (_timeToKill > 3600F)
				{
					_timeToKill = float.NaN;
					break;
				}

				TakingDamage = false;

				if (_object1 is Probe)
				{
					Probe probe = (Probe)_object1;
					IGCCoreProjectile Projectile = (IGCCoreProjectile)probe.Core.Projectiles.GetModule((ushort)probe.IGCProbe.Projectile);
					if (Projectile == null)
					{
						_timeToKill = float.PositiveInfinity;
						break;
					}
					float ProjRange = Projectile.Speed * Projectile.Lifespan * Mods.PWRange;
					if (ProjRange > _range)
						_range = ProjRange;

					WeaponDamage = CalculateWeaponDamage(Projectile, probe.IGCProbe.ShotInterval);
					WeaponDamage *= Interval * probe.IGCProbe.Accuracy;
					if (WeaponDamage == 0)
					{
						TakingDamage = true;
						_timeToKill = float.PositiveInfinity;
						break;
					}
					_ammoUsed += Interval / probe.IGCProbe.ShotInterval;
					if (_ammoUsed > probe.IGCProbe.AmmoCapacity)
						break;

					if (ApplyDamage(WeaponDamage) == false)
						continue;
					else
						break;	// Target Destroyed!
				}

				if (_object1 is Ship)
				{
					Ship ship = (Ship)_object1;
					IGCCorePartWeapon Weapon;
					if (ship.FireWeapons == true)
					{
						Weapon = ship.Weapons[0];
						if ((ship.WeaponToFire == -1 || ship.WeaponToFire == 0) && Weapon != null)
						{
							// If we're not reloading, not rearming, and not recharging energy (if we need them)
							if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
								(Weapon.EnergyConsumption > 0 && Battery > 0))
							{
								WeaponDamage = FireGun(Weapon, Interval);
								if (WeaponDamage != 0)
								{
									TakingDamage = true;
									if (ApplyDamage(WeaponDamage) == true)
										break;	// Target Destroyed!
								}
							}
						}

						Weapon = ship.Weapons[1];
						if ((ship.WeaponToFire == -1 || ship.WeaponToFire == 1) && Weapon != null)
						{
							if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
								(Weapon.EnergyConsumption > 0 && Battery > 0))
							{
								WeaponDamage = FireGun(Weapon, Interval);
								if (WeaponDamage != 0)
								{
									TakingDamage = true;
									if (ApplyDamage(WeaponDamage) == true)
										break;	// Target Destroyed!
								}
							}
						}

						Weapon = ship.Weapons[2];
						if ((ship.WeaponToFire == -1 || ship.WeaponToFire == 2) && Weapon != null)
						{
							if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
								(Weapon.EnergyConsumption > 0 && Battery > 0))
							{
								WeaponDamage = FireGun(Weapon, Interval);
								if (WeaponDamage != 0)
								{
									TakingDamage = true;
									if (ApplyDamage(WeaponDamage) == true)
										break;	// Target Destroyed!
								}
							}
						}

						Weapon = ship.Weapons[3];
						if ((ship.WeaponToFire == -1 || ship.WeaponToFire == 3) && Weapon != null)
						{
							if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
								(Weapon.EnergyConsumption > 0 && Battery > 0))
							{
								WeaponDamage = FireGun(Weapon, Interval);
								if (WeaponDamage != 0)
								{
									TakingDamage = true;
									if (ApplyDamage(WeaponDamage) == true)
										break;	// Target Destroyed!
								}
							}
						}
					}

					Weapon = ship.Turrets[0];
					if (ship.FireTurrets[0] == true)
					{
						if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
							(Weapon.EnergyConsumption > 0 && Battery > 0))
						{
							WeaponDamage = FireGun(Weapon, Interval);
							if (WeaponDamage != 0)
							{
								TakingDamage = true;
								if (ApplyDamage(WeaponDamage) == true)
									break;	// Target Destroyed!
							}
						}
					}

					Weapon = ship.Turrets[1];
					if (ship.FireTurrets[1] == true)
					{
						if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
							(Weapon.EnergyConsumption > 0 && Battery > 0))
						{
							WeaponDamage = FireGun(Weapon, Interval);
							if (WeaponDamage != 0)
							{
								TakingDamage = true;
								if (ApplyDamage(WeaponDamage) == true)
									break;	// Target Destroyed!
							}
						}
					}

					Weapon = ship.Turrets[2];
					if (ship.FireTurrets[2] == true)
					{
						if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
							(Weapon.EnergyConsumption > 0 && Battery > 0))
						{
							WeaponDamage = FireGun(Weapon, Interval);
							if (WeaponDamage != 0)
							{
								TakingDamage = true;
								if (ApplyDamage(WeaponDamage) == true)
									break;	// Target Destroyed!
							}
						}
					}

					Weapon = ship.Turrets[3];
					if (ship.FireTurrets[3] == true)
					{
						if (((ReloadAmmoTime == 0 && ArmGunsTime == 0) && Weapon.AmmoConsumption > 0) ||
							(Weapon.EnergyConsumption > 0 && Battery > 0))
						{
							WeaponDamage = FireGun(Weapon, Interval);
							if (WeaponDamage != 0)
							{
								TakingDamage = true;
								if (ApplyDamage(WeaponDamage) == true)
									break;	// Target Destroyed!
							}
						}
					}

					if (ship.FireMissile == true)
					{
						if (firingMissile != null)
						{
							if (firingMissile.SpecialEffect == MissileSpecialEffect.NerveGas)
							{
								_timeToKill = float.PositiveInfinity;
								break;
							}
							if (ReloadMissileTime == 0 && ArmMissileTime == 0 && firingMissile.SpecialEffect != MissileSpecialEffect.Resonator)
							{	// Not reloading or rearming missiles, fire it!
								float MissileDamage = CalculateMissileDamage(firingMissile);
								
								float WorkingRange = firingMissile.LifeSpan * firingMissile.Acceleration;
								WorkingRange = WorkingRange / 2F;
								WorkingRange = WorkingRange + firingMissile.LaunchVelocity + _launchSpeed;
								WorkingRange = WorkingRange * firingMissile.LifeSpan;
										
								if (WorkingRange > _range)
									_range = WorkingRange;

								if (MissileDamage > 0)
								{
									_missilesUsed += firingMissile.LaunchCount;
									MissilePack -= firingMissile.LaunchCount;

									ArmMissileTime = firingMissile.ReloadTime;
									if (MissilePack == 0)
										ReloadMissileTime = (1F / _object1.Core.Constants.MountRate);

									TakingDamage = true;
									if (ApplyDamage(MissileDamage) == true)
										break;	// Target Destroyed!
								}
							}
						}
					}
					
					// See if the target's shields started recharging
					if (TakingDamage == true)
					{
						DownedShield = false;
					}
					else
					{
						// We're not damaging, and not reloading... so stop!
						if (ReloadAmmoTime == 0 && ArmGunsTime == 0 && 
							ArmTurret1Time == 0 && ArmTurret2Time == 0 &&
							ArmTurret3Time == 0 && ArmTurret4Time == 0 &&
							ReloadMissileTime == 0 && ArmMissileTime == 0)
						{
							_timeToKill = float.PositiveInfinity;
							break;
						}

						if (DownedShield == false)
						{
							DownedShield = true;
						}
						else
						{
							if (ShieldHitpoints <= _object2.CalculateShieldHitpoints())
								ShieldHitpoints += Interval * ShieldRecharge;
						}
					}
					
					// All damage that could be done has been applied.
					// reload, rearm, and recharge if needed
					if (ReloadAmmoTime > 0)
					{
						ReloadAmmoTime = (float)Math.Round(ReloadAmmoTime - Interval, 1);
						if (ReloadAmmoTime == 0)
						{
							if (HullHitpoints >= _object2.CalculateHullHitpoints() ||
								(ShieldHitpoints >= _object2.CalculateShieldHitpoints() && _object2.CalculateShieldHitpoints() != 0))
							{	// We just finished reloading, and it's full again. Stop now.
								_timeToKill = float.PositiveInfinity;
								break;
							}
							for (int i = 0; i < shipCargo.Length; i++)
							{
								if (shipCargo[i] != null)
								{
									if (shipCargo[i] is IGCCorePartPack)
									{
										IGCCorePartPack Pack = (IGCCorePartPack)shipCargo[i];
										if (Pack.PackType == PackType.Ammo)
										{
											AmmoClip = ship.IGCShip.AmmoCapacity;
											shipCargo[i] = null;
											break;
											
										}
									}
								}
							}
						}
					}

					if (ArmGunsTime > 0)
						ArmGunsTime = (float)Math.Round(ArmGunsTime - Interval, 1);

					if (Battery <= 0 && ship.CalculateEnergy() > 0)
					{
						if (_object2 != null)
						{
							if (HullHitpoints >= _object2.CalculateHullHitpoints())
							{
								_timeToKill = float.PositiveInfinity;
								break;
							}
						}
					}

					if (Battery < ship.CalculateEnergy())
						Battery += Interval * ship.CalculateEnergyRecharge();

					if (ReloadMissileTime > 0)
					{
						ReloadMissileTime = (float)Math.Round(ReloadMissileTime - Interval, 1);
						if (ReloadMissileTime == 0)
						{
							if (HullHitpoints >= _object2.CalculateHullHitpoints())
							{	// We just finished reloading
								if (ShieldHitpoints >= _object2.CalculateShieldHitpoints())
								{	//Shields have recharged during the reloading time - we'll never kill this. Stop now.
									_timeToKill = float.PositiveInfinity;
									break;
								}
							}
							firingMissile = null;
							for (int i = 0; i < shipCargo.Length; i++)
							{
								if (shipCargo[i] != null)
								{
									if (shipCargo[i] is IGCCoreMissile)
									{
										IGCCoreMissile Missile = (IGCCoreMissile)shipCargo[i];
										if (ship.CanMountPart(Missile, ShipSlots.Missile))
										{
											firingMissile = Missile;
											MissilePack = ship.IGCShip.MissileCapacity / Missile.CargoPayload;
											shipCargo[i] = null;
											break;
										}
									}
								}
							}
						}
					}
					else
					{
						if (ArmMissileTime > 0)
						{
							ArmMissileTime = (float)Math.Round(ArmMissileTime - Interval, 1);
						}
					}
				}
				if (_object2 == null && _timeToKill >= 1F)	// Stops calculating after 1 second for single-object Damage calcs
				{
					_timeToKill = float.PositiveInfinity;
					break;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="weapon"></param>
		/// <returns>The amount of damage dealt by the weapon</returns>
		private float FireGun (IGCCorePartWeapon weapon, float interval)
		{
			Ship ship = (Ship)_object1;
			float WeaponDamage = 0F;

			// if we can't fire because of ammo or energy, return 0.
			if ((ReloadAmmoTime > 0 || AmmoClip == 0) && weapon.AmmoConsumption > 0)
				return 0F;
			
			if ((ArmGunsTime > 0 || AmmoClip == 0) && weapon.AmmoConsumption > 0)
				return 0F;

			if (weapon.EnergyConsumption > 0 && Battery <= 0)
				return 0F;

			IGCCoreProjectile Proj = (IGCCoreProjectile)ship.Core.Projectiles.GetModule((ushort)weapon.ProjectileUID);
			float ProjRange = Proj.Speed * Proj.Lifespan * Mods.PWRange;
			if (ProjRange > _range)
				_range = ProjRange;
						
			WeaponDamage = CalculateWeaponDamage(Proj, weapon.ShotInterval);
			if (WeaponDamage != 0)
			{
				float AmmoUsed = weapon.AmmoConsumption * (interval / weapon.ShotInterval);
				float EnergyUsed = weapon.EnergyConsumption * (interval / weapon.ShotInterval);
				if (AmmoUsed <= AmmoClip)
				{	// Remove the ammo used from the clip
					AmmoClip -= AmmoUsed;
					_ammoUsed += AmmoUsed;
					if (AmmoClip <= 0F)
						ReloadAmmoTime = 4F;
				}
				else
				{	// More ammo is needed than is in clip! Start reloading!
					float PercentageUsed = AmmoClip / AmmoUsed;
					WeaponDamage = PercentageUsed * WeaponDamage;
					_ammoUsed += PercentageUsed * AmmoUsed;
					AmmoClip = 0F;
					ReloadAmmoTime = 4F;
					ArmGunsTime = ReloadAmmoTime * weapon.TimeReady;
				}
				if (EnergyUsed <= Battery)
				{	// Remove the energy from the battery
					Battery -= EnergyUsed;
					_energyUsed += EnergyUsed;
				}
				else
				{	// More energy is needed than is in battery!
					float PercentageUsed = Battery / EnergyUsed;
					WeaponDamage = PercentageUsed * WeaponDamage;
					Battery = 0F;
				}
			}
			return WeaponDamage;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="weaponDamage"></param>
		/// <param name="missileDamage"></param>
		/// <returns>TRUE if target was killed</returns>
		private bool ApplyDamage (float weaponDamage)
		{
			if (weaponDamage != 0)
			{
				if (ShieldHitpoints > 0 && ShieldAC != -1)
				{	// Apply damage to shield
					if (weaponDamage < 0 && ShieldHitpoints > 0)
						return false;		// Nanite was fired at an existing shield... skip to next interval

					ShieldHitpoints -= weaponDamage;
					if (ShieldHitpoints >= 0)
						return false;		// Shields weren't downed, so continue to next interval

					weaponDamage -= (-1 * ShieldHitpoints);	// Remove the damage done to shield from this interval of damage
					ShieldHitpoints = 0F;
				}

				if (HullHitpoints > 0 && HullAC != -1)
				{	// Apply damage to hull
					HullHitpoints -= weaponDamage;

					if (HullHitpoints <= 0)
						return true;		// Target killed!!
				}
			}
			return false;
		}

		public float CalculateMissileDamage (IGCCoreMissile missile)
		{
			float MissileDamage = missile.Damage * Mods.MissileDamage;
			MissileDamage *= missile.LaunchCount;
			MissileDamage += (MissileDamage * (_kb / 100));
			_damageDealt += MissileDamage;
			int MissileDM = missile.DamageIndex;

			float DamageTaken = 0F;
			
			if (ShieldHitpoints > 0 && ShieldAC != -1)
			{
				DamageTaken = (MissileDamage * (DamageIndices[MissileDM].Damages[ShieldAC]));
				if (DamageTaken <= ShieldHitpoints)
					return DamageTaken;	// The damage taken didn't down the shields. Return it.

				ShieldHitpoints = 0F;
				// Damage took shields down. Set the DamageDealt to the extra damage dealt after shields were downed.
				MissileDamage = (-1 * (ShieldHitpoints - DamageTaken)) / DamageIndices[MissileDM].Damages[ShieldAC];
			}

			if (HullHitpoints > 0 && HullAC != -1)
				DamageTaken = (MissileDamage * (DamageIndices[MissileDM].Damages[HullAC]));

			return DamageTaken;
		}

		public float CalculateWeaponDamage (IGCCoreProjectile proj, float shotInterval)
		{
			float DamageDealt = 0F;
			float DamageTaken = 0F;
			int ProjDM = proj.DamageIndex;
			float Interval = _object1.Core.Constants.DownedShield;
			float ShotsPerInterval = Interval / shotInterval;

			float DirectDamage = ShotsPerInterval * proj.ShotDamage;
			float AreaDamage = ShotsPerInterval * proj.AreaDamage;
			DirectDamage *= (_accuracy / 100F);
			DamageDealt = (DirectDamage + AreaDamage) * Mods.PWDamage;
			DamageDealt += (DamageDealt * (_kb / 100));
			_damageDealt += DamageDealt;
			if (_object2 != null)
			{
				if (ShieldHitpoints > 0 && ShieldAC != -1)
				{
					DamageTaken = (DamageDealt * (DamageIndices[ProjDM].Damages[ShieldAC]));
					if (DamageTaken <= ShieldHitpoints)
						return DamageTaken;	// The damage taken didn't down the shields. Return it.

					ShieldHitpoints = 0F;
					// Damage took shields down. Set the DamageDealt to the extra damage dealt after shields were downed.
					DamageDealt = (-1 * (ShieldHitpoints - DamageTaken)) / DamageIndices[ProjDM].Damages[ShieldAC];
				}

				if (HullHitpoints > 0 && HullAC != -1)
					DamageTaken = (DamageDealt * (DamageIndices[ProjDM].Damages[HullAC]));
			}
			else
			{
				DamageTaken = DamageDealt;
			}

			return DamageTaken;
		}

		public float TimeToKill
		{
			get {return _timeToKill;}
		}

		public float AmmoUsed
		{
			get {return _ammoUsed;}
		}

		public float MissilesUsed
		{
			get {return _missilesUsed;}
		}

		public float EnergyUsed
		{
			get {return _energyUsed;}
		}

		public float Range
		{
			get {return _range;}
		}

		public float Damage
		{
			get {return _damageDealt;}
		}
	}
}
