using System;
using System.Collections;
using System.Collections.Generic;
using KBEngine;
using UnityEngine;

public class Bullet : FrameSyncBehaviour
{
    public FP speed = 15;
    public FPVector direction;

    [AddTracking]
    private FP destroyTime = 3;

    public override void OnSyncedUpdate()
    {
        if (destroyTime <= 0)
        {
            FrameSyncManager.SyncedDestroy(this.gameObject);
        }
        FPTransform.Translate(direction * speed * FrameSyncManager.DeltaTime);
        destroyTime -= FrameSyncManager.DeltaTime;
    }

    public void OnSyncedTriggerEnter(FPCollision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OnSyncedTriggerEnter other :" + other.gameObject.name);

            PlayerMovement hitPlayer = other.gameObject.GetComponent<PlayerMovement>();

            if (hitPlayer.ownerIndex != ownerIndex)
            {
                FrameSyncManager.SyncedDestroy(this.gameObject);
                hitPlayer.Respawn();
            }
        }
    }
}