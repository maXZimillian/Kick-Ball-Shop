[System.Serializable]
public class PurchaseMessage
{
    public int id;
    public int moneyCount;

    public PurchaseMessage(int id, int moneyCount)
    {
        this.id = id;
        this.moneyCount = moneyCount;
    }
}