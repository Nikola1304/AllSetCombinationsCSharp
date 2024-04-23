namespace AllSetCombinationsCSharp;

public class MyPair
{
    private int index;
    private string value;

    public MyPair(int index, string value)
    {
        this.index = index;
        this.value = value;
    }

    public MyPair()
    {
        this.index = -1;
        this.value = "trashvalue";
    }

    public MyPair(MyPair p)
    {
        this.index = p.index;
        this.value = p.value;
    }

    public int getIndex()
    {
        return index;
    }

    public string getValue()
    {
        return value;
    }
}