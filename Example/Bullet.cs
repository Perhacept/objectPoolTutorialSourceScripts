using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("returnthis",0.8f);
    }
    void returnthis() {
        GameManager.instance.btPool.Return(this);
    }
}
