using System.Runtime.InteropServices;
using UnityEngine;

public static class Vibration
{
    [DllImport("__Internal")]
    private static extern void TriggerHapticFeedback(string type);

    public static void Vibrate()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            TriggerHapticFeedback("");
        #endif
    }
}