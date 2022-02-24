
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ReflectionProbeUpdater : UdonSharpBehaviour
{
    [Tooltip("Update frecuency on seconds. Default 0.3 seconds")]
    public float syncFrequency = 0.3f;

    private void Update()
    {
        SyncReflection();
    }

    float _lastSyncTime;

    void SyncReflection()
    {
        float timeSinceStartup = Time.realtimeSinceStartup;

        if (timeSinceStartup - _lastSyncTime > syncFrequency)
        {
            _lastSyncTime = timeSinceStartup;
            this.gameObject.GetComponent<ReflectionProbe>().RenderProbe();
        }
    }

}
