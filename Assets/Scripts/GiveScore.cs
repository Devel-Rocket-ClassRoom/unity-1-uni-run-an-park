using UnityEngine;

public class GiveScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentScore++;
            GameManager.Instance.Energy += 1;
            GameManager.Instance.Score++;
            gameObject.SetActive(false);
        }
    }
}
