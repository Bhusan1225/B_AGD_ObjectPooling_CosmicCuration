using System.Collections.Generic;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
        //private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }

        public BulletController GetBullet() => GetItem();

        protected override BulletController CreateItem()
        {
            // Create a new bullet controller instance using the prefab and scriptable object
            return new BulletController(bulletPrefab, bulletSO);
        }

    }
}