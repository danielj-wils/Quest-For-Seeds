using UnityEngine;

public class AssetRemoval : MonoBehaviour
{
    [SerializeField] public float speed;

    // Update is called once per frame
    void Update()
    {
        // Move the object to the left
        transform.position += new Vector3(-11, 0, 0) * (speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Kill Zone"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
