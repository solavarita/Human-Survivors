using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Weapon : MonoBehaviour, IWeapon
{
    public WeaponData weaponData;
    protected float attackTimer;
    protected virtual void Start()
    {
        TryAttack(); 
    }
    protected virtual void Update()
    {
        if (!enabled) return;
        else
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= weaponData.attackInterval)
            {
                TryAttack();
                attackTimer = 0f;
            }
        }        
    }

    protected abstract void TryAttack();

    public virtual void Activate()
    {
        enabled = true;
    }
    public virtual void Deactivate()
    {
        enabled = false;
    }
}
