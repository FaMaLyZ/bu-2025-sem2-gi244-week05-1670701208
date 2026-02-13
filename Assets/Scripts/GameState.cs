using UnityEngine;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            hitCount++;
            Debug.Log($"hitCount = {hitCount}");
        }
        if(hitCount >= 10)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }
    }
}
