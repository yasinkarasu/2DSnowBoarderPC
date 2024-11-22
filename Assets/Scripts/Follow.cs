using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , Target.transform.position , 10 * Time.deltaTime);
    }
}
