using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerObserverManager
{
    public static Action<int> OnCoinsChanged;
    public static Action<int> OnRosquinhasChanged;

    public static void CoinsChanged(int value)
    {
        OnCoinsChanged?.Invoke(value);
    }

    public static void RosquinhasChanged(int value)
    {
        OnRosquinhasChanged?.Invoke(value);
    }
    
}
