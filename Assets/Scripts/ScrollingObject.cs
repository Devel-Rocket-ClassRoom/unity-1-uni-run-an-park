using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    
    void Update()
    {
        if (GameManager.Instance.isGameOver) { return; }

        transform.Translate(new Vector3(-GameManager.Instance.scrollSpeed * Time.deltaTime, 0, 0));
    }
}
