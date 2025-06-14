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
    private List<PooledBullet> pooledBullets = new List<PooledBullet>(); //************** imp for pooling

    public class PooledBullet
    {
        public BulletController Bullet;
        public bool isUsed; //************** imp for pooling


    }
    public BulletPool(BulletView _bulletView, BulletScriptableObject _bulletScriptableObject)
    {
        this.bulletView = _bulletView;
        this.bulletScriptableObject = _bulletScriptableObject;

    }



    public void ReturnBullet(BulletController returnedBullet)
    {

        PooledBullet pooledBullet = pooledBullets.Find(item => item.Bullet == (returnedBullet));
        pooledBullet.isUsed = false; //************** imp for pooling



    }
    public BulletController GetBullet()
    {
       if( pooledBullets.Count > 0)
        {
            PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
            
            if (pooledBullet.Bullet != null)
            {
                pooledBullet.isUsed = true; //************** imp for pooling
                return pooledBullet.Bullet;
            }


        }
       return CreateNewPooledBullet();
    }

    private BulletController CreateNewPooledBullet()
    {
        PooledBullet newPooledBullet = new PooledBullet();
        newPooledBullet.Bullet = new BulletController(bulletView, bulletScriptableObject);
        newPooledBullet.isUsed = true; //************** imp for pooling
        pooledBullets.Add(newPooledBullet); 
        return newPooledBullet.Bullet;
    }



}
