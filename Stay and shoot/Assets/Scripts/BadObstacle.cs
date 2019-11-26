using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BadObstacle : Obstacle
{
    
    public static event Action OnLevelLosed;
    public override void OnHitByBullet()
    {
        if (OnLevelLosed!=null)
        OnLevelLosed.Invoke();
    }
    public override void AddEffectOnBulletDeath(Bullet bullet)
    {
        bullet.InstantiateDeathEff();
    }
}
