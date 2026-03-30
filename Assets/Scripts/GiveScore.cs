using UnityEngine;

public class GiveScore : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.currentScore++;
            GameManager.Instance.Energy += 0.1f;
            GameManager.Instance.Score++;
            gameObject.SetActive(false);
        }
    }
}
