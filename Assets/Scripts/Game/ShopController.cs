using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PopupController purchasePopupController;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI skinNameText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject purchaseButton;
    [SerializeField] private GameObject selectButton;
    [SerializeField] private GameObject selectedIcon;
    [SerializeField] private int moneyCount = 0;
    private int viewId = 0;
    public int selectedId = 0;
    [SerializeField] private ShopItem[] items;

    public void LoadDataToShop(string nickname, int money, int selectedId, bool[] purchases)
    {
        playerNameText.text = nickname;
        UpdateMoney(money);
        ShowItemData(selectedId);

        for(int i = 0; i < items.Length; i++)
        {
            items[i].purchased = purchases[i];
            items[i].selected = i == selectedId;
        }

        this.selectedId = selectedId;
        viewId = selectedId;
        cameraController.MoveTo(viewId);
        SelectCurrent();
    }

    public void MoveRight()
    {
        if(viewId < items.Length - 1)
            viewId++;
        cameraController.MoveTo(viewId);
        ShowItemData(viewId);
    }

    public void MoveLeft()
    {
        if(viewId > 0)
            viewId--;
        cameraController.MoveTo(viewId);
        ShowItemData(viewId);
    }

    public void ShowPurchase()
    {
        purchasePopupController.ShowPopup(items[viewId].cost.ToString(), moneyCount >= items[viewId].cost);
    }

    public void Purchase()
    {
        if(moneyCount >= items[viewId].cost && !items[viewId].purchased)
        {
            items[viewId].purchased = true;
            UpdateMoney(moneyCount - items[viewId].cost);
            SelectCurrent();
            purchasePopupController.HidePopup();
            WebglBridge.SendPurchase(viewId, moneyCount);
        }
    }

    public void SelectCurrent()
    {
        foreach(ShopItem item in items)
        {
            item.selected = false;
        }
        items[viewId].selected = true;
        selectedId = viewId;
        ShowItemData(viewId);
    }

    public void ShowItemData(int id)
    {
        costText.text = items[id].purchased ? "got" : items[id].cost.ToString();
        skinNameText.text = items[id].name;
        purchaseButton.SetActive(items[id].purchased ? false : true);
        selectButton.SetActive(items[id].purchased && !items[id].selected ? true : false);
        selectedIcon.SetActive(items[id].purchased && items[id].selected ? true : false);
    }

    private void UpdateMoney(int value)
    {
        moneyCount = value;
        moneyText.text = moneyCount.ToString();
    }
}
