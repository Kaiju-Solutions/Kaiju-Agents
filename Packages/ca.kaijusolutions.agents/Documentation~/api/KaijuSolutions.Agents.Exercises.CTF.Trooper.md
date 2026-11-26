# Trooper

Troopers who aim to capture the enemy flag and defend their own. They have a Health value and have a blaster to battle the other team with. Walking into either the flag, a HealthPickup or an AmmoPickup will automatically interact with them.

~~~csharp
public class Trooper : KaijuController
~~~

[Package source](../../Samples~/Exercise%203%20-%20Capture%20the%20Flag/Trooper/Trooper.cs)

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnHitTrooper"></a>

### OnHitTrooper

~~~csharp
public event TrooperAction OnHitTrooper
~~~

Callback for hitting another trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnHitByTrooper"></a>

### OnHitByTrooper

~~~csharp
public event TrooperAction OnHitByTrooper
~~~

Callback for getting hit by another trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnTrooperHitGlobal"></a>

### OnTrooperHitGlobal

~~~csharp
public static MultiTrooperAction OnTrooperHitGlobal
~~~

Global callback for one agent hitting another.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnEliminatedTrooper"></a>

### OnEliminatedTrooper

~~~csharp
public event TrooperAction OnEliminatedTrooper
~~~

Callback for eliminated another trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnEliminatedByTrooper"></a>

### OnEliminatedByTrooper

~~~csharp
public event TrooperAction OnEliminatedByTrooper
~~~

Callback for getting eliminated by another trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnTrooperEliminatedGlobal"></a>

### OnTrooperEliminatedGlobal

~~~csharp
public static event MultiTrooperAction OnTrooperEliminatedGlobal
~~~

Global callback for one trooper eliminating another.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagDropped"></a>

### OnFlagDropped

~~~csharp
public event FlagAction OnFlagDropped
~~~

Callback for when this agent dropped the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagDroppedGlobal"></a>

### OnFlagDroppedGlobal

~~~csharp
public event TrooperFlagAction OnFlagDroppedGlobal
~~~

Global callback for when this agent dropped the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagPickedUp"></a>

### OnFlagPickedUp

~~~csharp
public event FlagAction OnFlagPickedUp
~~~

Callback for when this agent picking up the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagPickedUpGlobal"></a>

### OnFlagPickedUpGlobal

~~~csharp
public event TrooperFlagAction OnFlagPickedUpGlobal
~~~

Global callback for when this agent picking up the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagReturned"></a>

### OnFlagReturned

~~~csharp
public event FlagAction OnFlagReturned
~~~

Callback for when this agent returned the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagReturnedGlobal"></a>

### OnFlagReturnedGlobal

~~~csharp
public event TrooperFlagAction OnFlagReturnedGlobal
~~~

Global callback for when this agent returned the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagCaptured"></a>

### OnFlagCaptured

~~~csharp
public event FlagAction OnFlagCaptured
~~~

Callback for when this agent captured the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnFlagCapturedGlobal"></a>

### OnFlagCapturedGlobal

~~~csharp
public event TrooperFlagAction OnFlagCapturedGlobal
~~~

Global callback for when this agent captured the Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnHealth"></a>

### OnHealth

~~~csharp
public event HealthAction OnHealth
~~~

Callback for picking up a HealthPickup.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnHealthGlobal"></a>

### OnHealthGlobal

~~~csharp
public event TrooperHealthAction OnHealthGlobal
~~~

Global callback for picking up a HealthPickup.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnAmmo"></a>

### OnAmmo

~~~csharp
public event AmmoAction OnAmmo
~~~

Callback for picking up a AmmoPickup.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnAmmoGlobal"></a>

### OnAmmoGlobal

~~~csharp
public event TrooperAmmoAction OnAmmoGlobal
~~~

Global callback for picking up a AmmoPickup.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_All"></a>

### All

~~~csharp
public static IReadOnlyCollection<Trooper> All { get; }
~~~

All troopers currently active.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_AllOne"></a>

### AllOne

~~~csharp
public static IReadOnlyCollection<Trooper> AllOne { get; }
~~~

All troopers currently active for team one.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_AllTwo"></a>

### AllTwo

~~~csharp
public static IReadOnlyCollection<Trooper> AllTwo { get; }
~~~

All troopers currently active for team two.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_Health"></a>

### Health

~~~csharp
public int Health { get; private set; }
~~~

The current health of this trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamOne"></a>

### TeamOne

~~~csharp
public bool TeamOne { get; private set; }
~~~

What team this trooper is on.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OwnBase"></a>

### OwnBase

~~~csharp
public Vector2 OwnBase { get; }
~~~

Get the location of this trooper's own base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OwnBase3"></a>

### OwnBase3

~~~csharp
public Vector3 OwnBase3 { get; }
~~~

Get the location of this trooper's own base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyBase"></a>

### EnemyBase

~~~csharp
public Vector2 EnemyBase { get; }
~~~

Get the location of the other team's base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyBase3"></a>

### EnemyBase3

~~~csharp
public Vector3 EnemyBase3 { get; }
~~~

Get the location of the other team's base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamFlag"></a>

### TeamFlag

~~~csharp
public Flag TeamFlag { get; }
~~~

Get our team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyFlag"></a>

### EnemyFlag

~~~csharp
public Flag EnemyFlag { get; }
~~~

Get the enemy team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamFlagPosition"></a>

### TeamFlagPosition

~~~csharp
public Vector2 TeamFlagPosition { get; }
~~~

The position of our team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamFlagPosition3"></a>

### TeamFlagPosition3

~~~csharp
public Vector3 TeamFlagPosition3 { get; }
~~~

The position of our team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyFlagPosition"></a>

### EnemyFlagPosition

~~~csharp
public Vector2 EnemyFlagPosition { get; }
~~~

The position of the enemy team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyFlagPosition3"></a>

### EnemyFlagPosition3

~~~csharp
public Vector3 EnemyFlagPosition3 { get; }
~~~

The position of the enemy team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_HasFlag"></a>

### HasFlag

~~~csharp
public bool HasFlag { get; }
~~~

If we have the enemy's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamFlagAtBase"></a>

### TeamFlagAtBase

~~~csharp
public bool TeamFlagAtBase { get; }
~~~

If our Flag is at its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyFlagAtBase"></a>

### EnemyFlagAtBase

~~~csharp
public bool EnemyFlagAtBase { get; }
~~~

If the enemy Flag is at its base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TeamCarryingFlag"></a>

### TeamCarryingFlag

~~~csharp
public bool TeamCarryingFlag { get; }
~~~

If someone on our team is carrying the enemy Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_EnemyCarryingFlag"></a>

### EnemyCarryingFlag

~~~csharp
public bool EnemyCarryingFlag { get; }
~~~

If someone on the enemy team is carrying our team's Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_DistanceTeamFlag"></a>

### DistanceTeamFlag

~~~csharp
public float DistanceTeamFlag { get; }
~~~

The distance from us to our Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_DistanceEnemyFlag"></a>

### DistanceEnemyFlag

~~~csharp
public float DistanceEnemyFlag { get; }
~~~

The distance from us to the enemy Flag.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_DistanceTeamBase"></a>

### DistanceTeamBase

~~~csharp
public float DistanceTeamBase { get; }
~~~

The distance from us to our team's base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_DistanceEnemyBase"></a>

### DistanceEnemyBase

~~~csharp
public float DistanceEnemyBase { get; }
~~~

The distance from us to the enemy team's base.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_Ammo"></a>

### Ammo

~~~csharp
public int Ammo { get; private set; }
~~~

The ammo for this Trooper's BlasterActuator.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_HasAmmo"></a>

### HasAmmo

~~~csharp
public bool HasAmmo { get; }
~~~

If the BlasterActuator has any ammo.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_CanAttack"></a>

### CanAttack

~~~csharp
public bool CanAttack { get; }
~~~

If the BlasterActuator has any ammo and is not KaijuSolutions.Agents.Actuators.KaijuAttackActuator.OnCooldown.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_FlagPosition"></a>

### FlagPosition

~~~csharp
public Transform FlagPosition { get; private set; }
~~~

Where to store the flag when picking it up.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_Spawn"></a>

### Spawn

~~~csharp
public static Trooper Spawn ([NotNull] KaijuAgent trooperPrefab, [NotNull] SpawnPoint spawnPoint)
~~~

Spawn a trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_TakeDamage"></a>

### TakeDamage

~~~csharp
public void TakeDamage ([NotNull] Trooper attacker)
~~~

Take damage from another trooper.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_Attack"></a>

### Attack

~~~csharp
public void Attack ()
~~~

Fire the BlasterActuator.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_StopAttacking"></a>

### StopAttacking

~~~csharp
public void StopAttacking ()
~~~

Cancel trying to fire the BlasterActuator.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnEnable"></a>

### OnEnable

~~~csharp
protected override void OnEnable ()
~~~

This function is called when the object becomes enabled and active.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnDisable"></a>

### OnDisable

~~~csharp
protected override void OnDisable ()
~~~

This function is called when the behaviour becomes disabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_OnActuatorEnabled"></a>

### OnActuatorEnabled

~~~csharp
protected override void OnActuatorEnabled (KaijuActuator actuator)
~~~

Callback for when an KaijuSolutions.Agents.Actuators.KaijuActuator has been enabled.

<a id="KaijuSolutions_Agents_Exercises_CTF_Trooper_ToString"></a>

### ToString

~~~csharp
public override string ToString ()
~~~

Get a description of the object.
