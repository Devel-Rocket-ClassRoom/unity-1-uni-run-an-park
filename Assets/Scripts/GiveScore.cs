using UnityEngine;

public class GiveScore : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject pickedCoin = null;

        // Handle both setups: script on Coin or script on Player.
        if (CompareTag("Coin") && collision.CompareTag("Player"))
        {
            pickedCoin = gameObject;
        }
        else if (CompareTag("Player") && collision.CompareTag("Coin"))
        {
            pickedCoin = collision.gameObject;
        }

        if (pickedCoin == null)
        {
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null. Cannot give score.");
            return;
        }

        GameManager.Instance.currentScore++;
        GameManager.Instance.Energy += 0.1f;
        GameManager.Instance.Score++;
        pickedCoin.SetActive(false);
    }
}
