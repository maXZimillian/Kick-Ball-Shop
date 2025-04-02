using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public static class WebglBridge
{
    [DllImport("__Internal")]
    private static extern void OnLoaded();

    [DllImport("__Internal")]
    private static extern void OnStarted();

    [DllImport("__Internal")]
    private static extern void OnExit(int selectedId);

    [DllImport("__Internal")]
    private static extern void OnPurchase(int id, int moneyCount);
    
    public static void SendLoadedEvent()
    {
#if UNITY_WEBGL && ! UNITY_EDITOR
        OnLoaded();
#endif
    }

    public static void SendStartEvent()
    {
#if UNITY_WEBGL && ! UNITY_EDITOR
        OnStarted();
#endif
    }
    
    public static void SendExitEvent(int selectedId)
    {
#if UNITY_WEBGL && ! UNITY_EDITOR
        OnExit(selectedId);
#endif
    }

    public static void SendPurchase(int id, int moneyCount)
    {
#if UNITY_WEBGL && ! UNITY_EDITOR
        OnPurchase(id, moneyCount);
#endif
    }
}