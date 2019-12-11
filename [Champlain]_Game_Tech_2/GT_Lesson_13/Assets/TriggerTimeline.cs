using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeline : MonoBehaviour
{
    public TimelineScript ts;

    void OnTriggerEnter(Collider other)
    {
        ts.playTimeline();
    }
}
