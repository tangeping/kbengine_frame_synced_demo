using System.Collections;
using System.Collections.Generic;
using KBEngine;
using UnityEngine;

public class PlayerWeapon : FrameSyncBehaviour
{
    public GameObject projectilePrefab;

    private FP cooldown = 0;

    public override void OnSyncedInput()
    {
        if (Input.GetButton("Fire1"))
        {
            FrameSyncInput.SetByte(2, 1);
        }
        else
        {
            FrameSyncInput.SetByte(2, 0);
        }
    }

    public override void OnSyncedUpdate()
    {
        byte fire = FrameSyncInput.GetByte(2);
        if (fire == 1 && cooldown <= 0)
        {
            FrameSyncManager.SyncedInstantiate(projectilePrefab, FPTransform.position, FPQuaternion.identity);

            Bullet projectile = projectilePrefab.GetComponent<Bullet>();
            projectile.direction = FPTransform.forward;
            projectile.owner = owner;

            cooldown = 1;
        }
        cooldown -= FrameSyncManager.DeltaTime;
    }
}