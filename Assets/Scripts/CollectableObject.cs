using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public static bool gameIsFinished = false;
    public bool isCollected;
    private GameManager gameManager;
    private Rigidbody rb;

    private BoxCollider boxCollider;

    void Start()
    {
        isCollected = false;
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && isCollected)
        {
            gameManager.collectedObjects.Remove(gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            gameIsFinished = true;
            boxCollider.isTrigger = false;
            rb.useGravity = true;
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Collectable") && isCollected && !other.GetComponent<CollectableObject>().isCollected)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = gameManager.collectedMaterial;
            other.gameObject.GetComponent<CollectableObject>().isCollected = true;
            other.transform.parent = null;
            other.transform.parent = gameManager.collectPool.transform;
            gameManager.collectedObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable") && isCollected && !other.GetComponent<CollectableObject>().isCollected)
        {
            other.gameObject.GetComponent<MeshRenderer>().material = gameManager.collectedMaterial;
            other.gameObject.GetComponent<CollectableObject>().isCollected = true;
            other.transform.parent = null;
            other.transform.parent = gameManager.collectPool.transform;
            gameManager.collectedObjects.Add(other.gameObject);
        }
    }

}

