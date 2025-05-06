using JetBrains.Annotations;
using UnityEngine;

public class BackGroundLoof : MonoBehaviour
{

    public float width = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackGround"))
        {
            Vector3 currentPos = collision.transform.position;

            Vector3 newPos = new Vector3(currentPos.x + width, currentPos.y, currentPos.z);
            collision.transform.position = newPos;
        }


    }
}
