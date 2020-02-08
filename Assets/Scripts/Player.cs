using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rb;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.collectedObjects.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<CollectableObject>().isCollected = true;
            other.GetComponent<MeshRenderer>().material = gameManager.collectedMaterial;
            other.transform.parent = null;
            other.transform.parent = gameManager.collectPool.transform;
            gameManager.collectedObjects.Add(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            boxCollider.isTrigger = false;
            rb.useGravity = true;
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }


        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.collectedObjects.Remove(gameObject);
            Destroy(gameObject);
        }
    }

}
