class GamePlayManager
{
    #region Singleton
    private static readonly GamePlayManager instance = new GamePlayManager();

    public static GamePlayManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    public bool Paused;

}
