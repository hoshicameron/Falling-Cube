using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action GameOverEvent;

    public static void CallGameOverEvent()
    {
        GameOverEvent?.Invoke();
    }
}
