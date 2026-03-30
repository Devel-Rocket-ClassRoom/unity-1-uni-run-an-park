using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkPool
{
    private Queue<GameObject> _items = new Queue<GameObject>();

    public ChunkPool(List<GameObject> items)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items.Enqueue(items[i]);
        }
    }

    public void GetRandomChunk()
    {

    }

    public void ReturnRandomChunk(GameObject item)
    {
        item.transform.position = new Vector3(15, 0, 0);
    }
}
