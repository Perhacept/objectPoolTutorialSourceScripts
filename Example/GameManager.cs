using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    int initialSize = 20;

    public bulletPoolSO btPool;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        btPool.Prewarm(initialSize);
        btPool.SetParent(this.transform);
    }

}