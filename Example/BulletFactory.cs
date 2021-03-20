using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="newBulletFactory", menuName = "Factory/BulletFactory")]
public class BulletFactory : FactotySO<Bullet>
{
    public Bullet[] bt;
    public override Bullet Create()
    {
        int index = Random.Range(0,bt.Length);
        Bullet _instance = Instantiate(bt[index]);
        return _instance;
    }


}
