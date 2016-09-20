using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class GamePlayManager : MonoBehaviour
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
