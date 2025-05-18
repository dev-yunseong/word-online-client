[System.Serializable]
public class CreatedObjectDto
{
    public int id;
    public Position position;
    public string type; // enum 대응 가능
}

[System.Serializable]
public class Position
{
    public int x;
    public int y;
}