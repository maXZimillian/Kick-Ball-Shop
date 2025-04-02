[System.Serializable]
public class ExitMessage
{
    public int selectedId;

    public ExitMessage(int id)
    {
        this.selectedId = id;
    }
}