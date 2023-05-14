using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Events

    #endregion

    #region Private SerializeFields

    #endregion

    #region Private Fields


    #endregion

    #region Protected Fields

    #endregion

    #region Public Fields

    public static GameManager Inctance;

    public GameObject Player;

    #endregion

    #region Properties

    #endregion

    #region MonoBehaviour CallBacks

    private void Awake()
    {
        if (Inctance == null)
        {
            Inctance = this;
        }
    }

    #endregion

    #region Static Methods

    #endregion

    #region Public Methods

    #endregion

    #region Protected Methods

    #endregion

    #region Private Methods

    #endregion
}