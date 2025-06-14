using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmicCuration.Bullets.BulletPool;

public class GenericObjectPool<T> where T : class
{



  // private List
 
    public List<PooledItem<T>> pooledItem = new List<PooledItem<T>>();

   

    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }


    protected T GetItem()
    {
        if (pooledItem.Count > 0)
        {
            PooledItem<T> item = pooledItem.Find(item => !item.isUsed);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.Item = CreateItem();
        newItem.isUsed = true;
        pooledItem.Add(newItem);
        return newItem.Item;
    }

    protected virtual T CreateItem()
    {
        throw new NotImplementedException("Child Class dont have implementation CreateItem()");  
    }
}
