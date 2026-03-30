using UnityEngine;

public class SetChunk : MonoBehaviour
{
    private GameObject[] Coin;

   
    private void OnDisable()
    {
        CacheCoinsIfNeeded();

        for (int i = 0; i < Coin.Length; i++)
        {
            if (Coin[i] != null)
            {
                Coin[i].SetActive(true);
            }
        }
    }

    private void CacheCoinsIfNeeded()
    {
        if (Coin != null && Coin.Length > 0)
        {
            return;
        }

        Transform[] children = GetComponentsInChildren<Transform>(true);
        int coinCount = 0;

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null && children[i].CompareTag("Coin"))
            {
                coinCount++;
            }
        }

        Coin = new GameObject[coinCount];

        int index = 0;
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null && children[i].CompareTag("Coin"))
            {
                Coin[index++] = children[i].gameObject;
            }
        }

    }

}
