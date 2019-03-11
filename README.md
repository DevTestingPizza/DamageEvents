# DamageEvents

This resource provides events for pretty much all entity related damage or death events by listening to the `gameEventTriggered` event, taking the data and triggering new events based on that game event data.


----

## <i class="fas fa-download"></i> Download
You can download it [**here**](https://github.com/TomGrobbe/damageevents/releases/latest).

----

## <i class="fas fa-wrench"></i> Debugging
There is an option in the `__resource.lua` file that allows you to turn on debug prints. This will print all triggered events to the F8 console. Note that you should disable this on your live server because it does reduce performance, and it just spams the console and client log of your users.

----

## <i class="far fa-list-alt"></i> Events reference

There are 8 events in total, all of which have been documented below.

Note, only one event will be triggered for every game event. Only the one that's most appropriate in any given situation will be used.

For example, if a player kills a ped, only the `DamageEvents:PedKilledByPlayer` event will be triggered, events like `DamageEvents:PedDied` or `DamageEvents:EntityKilled` will not be triggered in that case.

----

## `DamageEvents:VehicleDestroyed`

**Description**

Event gets triggered whenever a vehicle is destroyed.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|vehicle|The vehicle that got destroyed.|
|int|attacker|The attacker handle of what destroyed the vehicle.|
|uint|weaponHash|The weapon hash that was used to destroy the vehicle.|
|bool|isMeleeDamage|True if the damage dealt was using any melee weapon (including unarmed).|
|int|vehicleDamageTypeFlag|Vehicle damage type flag, 93 is vehicle tires damaged, others unknown.|

----

## `DamageEvents:PedKilledByVehicle`

**Description**

Event gets triggered whenever a ped was killed by a vehicle without a driver.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|ped|Ped that got killed.|
|int|vehicle|Vehicle that was used to kill the ped.|

----

## `DamageEvents:PedKilledByPlayer`

**Description**

Event gets triggered whenever a ped is killed by a player.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|ped|The ped that got killed.|
|int|playerId|The player that killed the ped.|
|uint|weaponHash|The weapon hash used to kill the ped.|
|bool|isMeleeDamage|True if the ped was killed with a melee weapon (including unarmed).|

----

## `DamageEvents:PedKilledByPed`

**Description**

Event gets triggered whenever a ped is killed by another (non-player) ped.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|ped|Ped that got killed.|
|int|attackerPed|Ped that killed the victim ped.|
|uint|weaponHash|Weapon hash used to kill the ped.|
|bool|isMeleeDamage|True if the ped was killed using a melee weapon (including unarmed).|

----

## `DamageEvents:PedDied`

**Description**

Event gets triggered whenever a ped died, but only if the other (more detailed) events weren't triggered.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|ped|The ped that died.|
|int|attacker|The attacker (can be the same as the ped that died).|
|uint|weaponHash|Weapon hash used to kill the ped.|
|bool|isMeleeDamage|True whenever the ped was killed using a melee weapon (including unarmed).|

----

## `DamageEvents:EntityKilled`

**Description**

Gets triggered whenever an entity died, that's not a vehicle, nor a ped.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|entity|Entity that was killed/destroyed.|
|int|attacker|The attacker that destroyed/killed the entity.|
|uint|weaponHash|The weapon hash used to kill/destroy the entity.|
|bool|isMeleeDamage|True whenever the ped was killed using a melee weapon (including unarmed).|

----

## `DamageEvents:VehicleDamaged`

**Description**

Event gets triggered whenever a vehicle is damaged, but not destroyed.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|vehicle|Vehicle that got damaged.|
|int|attacker|Attacker that damaged the vehicle.|
|uint|weaponHash|Weapon hash used to damage the vehicle.|
|bool|isMeleeDamage|True whenever the ped was killed using a melee weapon (including unarmed).|
|int|vehicleDamageTypeFlag|Vehicle damage type flag, 93 is vehicle tire damage, others are unknown.|


----

## `DamageEvents:EntityDamaged`

**Description**

Event gets triggered whenever an entity is damaged but hasn't died from the damage.

**Parameters**

|Type|Name|Description|
|:---|:---|:----------|
|int|entity|Entity that got damaged.|
|int|attacker|The attacker that damaged the entity.|
|uint|weaponHash|The weapon hash used to damage the entity.|
|bool|isMeleeDamage|True whenever the ped was killed using a melee weapon (including unarmed).|

----

