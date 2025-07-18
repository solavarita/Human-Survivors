using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expAmount = 1;
    private Transform player;

    private void Start()
    {
        player = PlayerMovement.Instance.transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hehehe");
            ExpOrbPooling.Instance.ReturnToPool(this.gameObject);
        }
    }
}
