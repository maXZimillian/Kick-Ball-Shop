using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;
using System.Collections;
using UnityEngine.SceneManagement;

public class WebGameManager : MonoBehaviour
{
#region Public
    public bool gameStarted = false;
    public ShopController shopController;
#endregion

#region Private

#endregion

    async void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        WebglBridge.SendLoadedEvent();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void StartHandler(StartMessage message)
    {
        shopController.LoadDataToShop(message.nickname, message.moneyCount, message.selectedId, message.purchases);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    async void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        WebglBridge.SendExitEvent(shopController.selectedId);
    }
}