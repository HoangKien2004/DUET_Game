using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: PlayerMovement
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion
    [HideInInspector] public bool isGameover = false;
}
