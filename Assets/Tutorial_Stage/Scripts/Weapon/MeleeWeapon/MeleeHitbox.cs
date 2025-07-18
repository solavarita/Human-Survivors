using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Đánh cận chiến trúng");
        }
    }
}
