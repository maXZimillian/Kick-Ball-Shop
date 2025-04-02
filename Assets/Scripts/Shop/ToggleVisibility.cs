using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject[] toggleObj;

    public void ToggleObjects()
    {
        foreach(GameObject obj in toggleObj)
            obj.SetActive(!obj.activeSelf);
    }
}