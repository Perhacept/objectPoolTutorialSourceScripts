using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class the_sceneManager : MonoBehaviour
{
    public void RequestBullet() {
        Bullet temp = GameManager.instance.btPool.Request();
        temp.gameObject.transform.position = new Vector3(Random.Range(0,10f), Random.Range(0, 10f), Random.Range(0, 10f));
        temp.gameObject.transform.SetParent(this.transform);
    }

    public void RequestBulletPerOpoint3(int howmuch) {
        StartCoroutine(_RequestBulletPerOpoint3(howmuch));
    }

    IEnumerator _RequestBulletPerOpoint3(int _howmuch) {
        
        for (int i = 0; i < _howmuch; i++)
        {
            yield return new WaitForSeconds(0.01f);
            RequestBullet();
        }
       
        yield return null;
    }

}
