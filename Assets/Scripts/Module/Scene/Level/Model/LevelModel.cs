using Agate.MVC.Base;

public interface ILevelModel : IBaseModel
{
    int Level { get; }
    int LevelNumber { get; }
}

public class LevelModel : BaseModel, ILevelModel
{
    public int Level { get; set; }
    public int LevelNumber { get; set; }

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel(int source)
    {
        LevelNumber = source;
        Level = LevelNumber - 1;
    }
}