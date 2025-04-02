using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
