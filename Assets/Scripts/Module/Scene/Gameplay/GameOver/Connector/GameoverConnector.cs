using Agate.MVC.Base;

public class GameoverConnector : BaseConnector
{
    private GameoverController _gameOver;

    protected override void Connect(){
        Subscribe<GameoverMessage>(_gameOver.OnGameOver);
    }

    protected override void Disconnect(){
        Unsubscribe<GameoverMessage>(_gameOver.OnGameOver);
    }
}
