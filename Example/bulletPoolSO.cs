using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newBulletPool", menuName = "Pool/BulletPool")]
public class bulletPoolSO : ComponentPoolSO<Bullet>
{
    [SerializeField]
    BulletFactory factory;

    public override IFactory<Bullet> Factory {

        get => factory;
        set => factory = value as BulletFactory;
    }

}
