using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactEventsHandler : MonoBehaviour
{
    public void StartShop(string value)
    {
        StartMessage startMessage = JsonUtility.FromJson<StartMessage>(value);
        WebGameManager webGameManager = FindObjectOfType<WebGameManager>();
        if(webGameManager)
            webGameManager.StartHandler(startMessage);
    }
}
