using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using System.Dynamic;

namespace DamageEvents
{
    public class DamageEvents : BaseScript
    {

        public const string eventName = "DamageEvents";
        public DamageEvents()
        {
            EventHandlers.Add("gameEventTriggered", new Action<string, dynamic>(GameEventTriggered));

            EventHandlers.Add(eventName + ":VehicleDestroyed", new Action<int, int, uint, bool, int>((a, b, c, d, e) =>
            {
                Debug.WriteLine("event: VehicleDestroyed");
                Debug.WriteLine($"vehicle: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
                Debug.WriteLine($"vehicle damage flag: {e}");
            }));
            EventHandlers.Add(eventName + ":PedKilledByPlayer", new Action<int, int, uint, bool>((a, b, c, d) =>
            {
                Debug.WriteLine("event: PedKilledByPlayer");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"player: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
            }));
            EventHandlers.Add(eventName + ":PedKilledByPed", new Action<int, int, uint, bool>((a, b, c, d) =>
            {
                Debug.WriteLine("event: PedKilledByPed");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
            }));
            EventHandlers.Add(eventName + ":PedKilledByVehicleWithDriver", new Action<int, int, int>((a, b, c) =>
            {
                Debug.WriteLine("event: PedKilledByVehicleWithDriver");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"driver of vehicle: {b}");
                Debug.WriteLine($"vehicle: {c}");
            }));
            EventHandlers.Add(eventName + ":PedKilledByVehicle", new Action<int, int>((a, b) =>
            {
                Debug.WriteLine("event: PedKilledByVehicle");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"vehicle: {b}");
            }));
            EventHandlers.Add(eventName + ":PedDied", new Action<int, int, uint, bool>((a, b, c, d) =>
            {
                Debug.WriteLine("event: PedDied");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
            }));
            EventHandlers.Add(eventName + ":EntityKilled", new Action<int, int, uint, bool>((a, b, c, d) =>
            {
                Debug.WriteLine("event: EntityKilled");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
            }));
            EventHandlers.Add(eventName + ":VehicleDamaged", new Action<int, int, uint, bool, int>((a, b, c, d, e) =>
            {
                Debug.WriteLine("event: VehicleDamaged");
                Debug.WriteLine($"vehicle: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
                Debug.WriteLine($"vehicle damage flag: {e}");
            }));
            EventHandlers.Add(eventName + ":EntityDamaged", new Action<int, int, uint, bool>((a, b, c, d) =>
            {
                Debug.WriteLine("event: EntityDamaged");
                Debug.WriteLine($"victim: {a}");
                Debug.WriteLine($"attacker: {b}");
                Debug.WriteLine($"weapon hash: {c}");
                Debug.WriteLine($"was melee damage?: {d}");
            }));
        }

        /// <summary>
        /// Event gets triggered whenever a vehicle is destroyed.
        /// </summary>
        /// <param name="vehicle">The vehicle that got destroyed.</param>
        /// <param name="attacker">The attacker handle of what destroyed the vehicle.</param>
        /// <param name="weaponHash">The weapon hash that was used to destroy the vehicle.</param>
        /// <param name="isMeleeDamage">True if the damage dealt was using any melee weapon (including unarmed).</param>
        /// <param name="vehicleDamageTypeFlag">Vehicle damage type flag, 93 is vehicle tires damaged, others unknown.</param>
        private void VehicleDestroyed(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag)
        {
            TriggerEvent(eventName + ":VehicleDestroyed", vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
        }

        /// <summary>
        /// Event gets triggered whenever a ped is killed by a player.
        /// </summary>
        /// <param name="ped">The ped that got killed.</param>
        /// <param name="player">The player that killed the ped.</param>
        /// <param name="weaponHash">The weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True if the ped was killed with a melee weapon (including unarmed).</param>
        private void PedKilledByPlayer(int ped, int player, uint weaponHash, bool isMeleeDamage)
        {
            TriggerEvent(eventName + ":PedKilledByPlayer", ped, player, weaponHash, isMeleeDamage);
        }

        /// <summary>
        /// Event gets triggered whenever a ped is killed by another (non-player) ped.
        /// </summary>
        /// <param name="ped">Ped that got killed.</param>
        /// <param name="attackerPed">Ped that killed the victim ped.</param>
        /// <param name="weaponHash">Weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True if the ped was killed using a melee weapon (including unarmed).</param>
        private void PedKilledByPed(int ped, int attackerPed, uint weaponHash, bool isMeleeDamage)
        {
            TriggerEvent(eventName + ":PedKilledByPed", ped, attackerPed, weaponHash, isMeleeDamage);
        }

        /// <summary>
        /// Event gets triggered whenever a ped was killed by another ped using a vehicle.
        /// </summary>
        /// <param name="ped">Ped that got killed.</param>
        /// <param name="driver">Last ped to be in the driver seat of the vehicle used to kill the ped.</param>
        /// <param name="vehicle">The vehicle used to kill the ped.</param>
        private void PedKilledByVehicleWithDriver(int ped, int driver, int vehicle)
        {
            TriggerEvent(eventName + ":PedKilledByVehicleWithDriver", ped, driver, vehicle);
        }

        /// <summary>
        /// Event gets triggered whenever a ped was killed by a vehicle without a driver.
        /// </summary>
        /// <param name="ped">Ped that got killed.</param>
        /// <param name="vehicle">Vehicle that was used to kill the ped.</param>
        private void PedKilledByVehicle(int ped, int vehicle)
        {
            TriggerEvent(eventName + ":PedKilledByVehicle", ped, vehicle);
        }

        /// <summary>
        /// Event gets triggered whenever a ped died, but only if the other (more detailed) events weren't triggered.
        /// </summary>
        /// <param name="ped">The ped that died.</param>
        /// <param name="attacker">The attacker (can be the same as the ped that died).</param>
        /// <param name="weaponHash">Weapon hash used to kill the ped.</param>
        /// <param name="isMeleeDamage">True whenever the ped was killed using a melee weapon (including unarmed).</param>
        private void PedDied(int ped, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            TriggerEvent(eventName + ":PedDied", ped, attacker, weaponHash, isMeleeDamage);
        }

        /// <summary>
        /// Gets triggered whenever an entity died, that's not a vehicle, or a ped.
        /// </summary>
        /// <param name="entity">Entity that was killed/destroyed.</param>
        /// <param name="attacker">The attacker that destroyed/killed the entity.</param>
        /// <param name="weaponHash">The weapon hash used to kill/destroy the entity.</param>
        /// <param name="isMeleeDamage">True whenever the entity was killed/destroyed with a melee weapon.</param>
        private void EntityKilled(int entity, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            TriggerEvent(eventName + ":EntityKilled", entity, attacker, weaponHash, isMeleeDamage);
        }

        /// <summary>
        /// Event gets triggered whenever a vehicle is damaged, but not destroyed.
        /// </summary>
        /// <param name="vehicle">Vehicle that got damaged.</param>
        /// <param name="attacker">Attacker that damaged the vehicle.</param>
        /// <param name="weaponHash">Weapon hash used to damage the vehicle.</param>
        /// <param name="isMeleeDamage">True whenever the vehicle was damaged using a melee weapon (including unarmed).</param>
        /// <param name="vehicleDamageTypeFlag">Vehicle damage type flag, 93 is vehicle tire damage, others are unknown.</param>
        private void VehicleDamaged(int vehicle, int attacker, uint weaponHash, bool isMeleeDamage, int vehicleDamageTypeFlag)
        {
            TriggerEvent(eventName + ":VehicleDamaged", vehicle, attacker, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
        }

        /// <summary>
        /// Event gets triggered whenever an entity is damaged but hasn't died from the damage.
        /// </summary>
        /// <param name="entity">Entity that got damaged.</param>
        /// <param name="attacker">The attacker that damaged the entity.</param>
        /// <param name="weaponHash">The weapon hash used to damage the entity.</param>
        /// <param name="isMeleeDamage">True if the damage was done using a melee weapon (including unarmed).</param>
        private void EntityDamaged(int entity, int attacker, uint weaponHash, bool isMeleeDamage)
        {
            TriggerEvent(eventName + ":EntityDamaged", entity, attacker, weaponHash, isMeleeDamage);
        }





        /// <summary>
        /// Used internally to trigger the other events.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="data"></param>
        private void GameEventTriggered(string eventName, dynamic data)
        {
            if (eventName == "CEventNetworkEntityDamage")
            {
                Entity victim = Entity.FromHandle(data[0]);
                Entity attacker = Entity.FromHandle(data[1]);
                bool victimDied = data[3] == 1;
                uint weaponHash = (uint)data[4];
                bool isMeleeDamage = data[9] != 0;
                int vehicleDamageTypeFlag = data[10];

                if (victim != null && attacker != null)
                {
                    if (victimDied)
                    {
                        // victim died

                        // vehicle destroyed
                        if (victim.Model.IsVehicle)
                        {
                            VehicleDestroyed(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
                        }
                        // other entity died
                        else
                        {
                            // victim is a ped
                            if (victim is Ped ped)
                            {
                                if (attacker is Ped p)
                                {
                                    if (p.IsPlayer)
                                    {
                                        int player = NetworkGetPlayerIndexFromPed(p.Handle);
                                        PedKilledByPlayer(victim.Handle, player, weaponHash, isMeleeDamage);
                                    }
                                    else
                                    {
                                        PedKilledByPed(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                                    }
                                }
                                else if (attacker is Vehicle veh)
                                {
                                    int lastDriver = GetLastPedInVehicleSeat(veh.Handle, -1);
                                    if (DoesEntityExist(lastDriver))
                                    {
                                        PedKilledByVehicleWithDriver(victim.Handle, lastDriver, attacker.Handle);
                                    }
                                    else
                                    {
                                        PedKilledByVehicle(victim.Handle, attacker.Handle);
                                    }
                                }
                                else
                                {
                                    PedDied(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                                }
                            }
                            // victim is not a ped
                            else
                            {
                                EntityKilled(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                            }
                        }
                    }
                    else
                    {
                        // only damaged
                        if (!victim.Model.IsVehicle)
                        {
                            EntityDamaged(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage);
                        }
                        else
                        {
                            VehicleDamaged(victim.Handle, attacker.Handle, weaponHash, isMeleeDamage, vehicleDamageTypeFlag);
                        }
                    }
                }
            }
        }

    }
}
