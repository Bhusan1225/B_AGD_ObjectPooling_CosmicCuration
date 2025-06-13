using CosmicCuration.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Create a class of a pooledBullet
// Create this pool vai PlayerService
// Create constructor of pool 
public class BulletPool
{

    private BulletView bulletView;
    private BulletScriptableObject bulletScriptableObject;
    private List<PooledBullet> pooledBullets = new List<PooledBullet>();

    public class PooledBullet
    {
        public BulletController Bullet;
        public bool isUsed;


    }
    public BulletPool(BulletView _bulletView, BulletScriptableObject _bulletScriptableObject)
    {
        this.bulletView = _bulletView;
        this.bulletScriptableObject = _bulletScriptableObject;

    }


}
