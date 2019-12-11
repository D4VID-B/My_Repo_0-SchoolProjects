using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineScript : MonoBehaviour
{
    PlayableDirector pd;

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }

    public void playTimeline()
    {
        pd.Play();
    }
}
