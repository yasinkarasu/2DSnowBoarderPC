/*
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , Target.transform.position , 10 * Time.deltaTime);
    }
}
*/
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target; // Takip edilecek hedef
    public float FollowSpeed = 10f; // Takip hızını kontrol eder
    public float MinDistance = 1.5f; // Hedef ile takip eden arasındaki minimum mesafe
    public float MaxDistance = 3f; // Hedef ile takip eden arasındaki maksimum mesafe

    void Update()
    {
        if (Target != null)
        {
            // Hedef ile takip eden nesne arasındaki mesafeyi hesapla
            float currentDistance = Vector2.Distance(transform.position, Target.transform.position);

            // Eğer mevcut mesafe maksimum mesafeden büyükse, hedefe yaklaş
            if (currentDistance > MaxDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    Target.transform.position,
                    FollowSpeed * Time.deltaTime
                );
            }
            // Eğer mevcut mesafe minimum mesafeden küçükse, hedeften uzaklaş
            else if (currentDistance < MinDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    Target.transform.position,
                    -FollowSpeed * Time.deltaTime
                );
            }
            // Mesafe aralık içindeyse, dur
        }
    }
}
