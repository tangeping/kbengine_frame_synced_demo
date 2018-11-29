using System.Collections;
using System.Collections.Generic;
using KBEngine;
using UnityEngine;

public class PlayerMovement : FrameSyncBehaviour
{
    public FP accellRate;

    public FP steerRate;

    public int deaths = 0;

    public override void OnSyncedInput()
    {
        FP accell = Input.GetAxis("Vertical");
        FP steer = Input.GetAxis("Horizontal");

        FrameSyncInput.SetFP(0, accell);
        FrameSyncInput.SetFP(1, steer);

        //Debug.Log("OnSyncedInput::accell:" + accell + ",steer:" + steer);
    }

    public override void OnSyncedUpdate()
    {
        FP accell = FrameSyncInput.GetFP(0);
        FP steer = FrameSyncInput.GetFP(1);
        //Debug.Log("OnSyncedUpdate::accell:" + accell + ",steer:" + steer);

        accell *= accellRate * FrameSyncManager.DeltaTime;
        steer *= steerRate * FrameSyncManager.DeltaTime;

        FPTransform.Translate(0, 0, accell, Space.Self);
        FPTransform.Rotate(0, steer, 0);

        
    }

    public override void OnSyncedStart()
    {
        FPTransform.position = new FPVector(FPRandom.Range(-5, 5), 0, FPRandom.Range(-5, 5));
    }

    public void Respawn()
    {
        FPTransform.position = new FPVector(FPRandom.Range(-5, 5), 0, FPRandom.Range(-5, 5));
        deaths++;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 100 + 30 * owner.id, 300, 30), "player: " + owner.id + ", deaths: " + deaths);
    }
}