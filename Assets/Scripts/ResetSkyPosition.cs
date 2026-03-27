using UnityEngine;

public class ResetSkyPosition : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x < -20.48f)
        {
            transform.position = new Vector3(20.48f, 0, 0);
        }
    }
}
