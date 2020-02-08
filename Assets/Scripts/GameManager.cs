using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject collectPool;
    public Material collectedMaterial;
    public List<GameObject> collectedObjects;
    private bool gameIsOver = false;

    private void Update()
    {
        if (collectedObjects.Count <= 0 && !gameIsOver)
        {
            GameOver();
        }

        if (CollectableObject.gameIsFinished)
        {
            StartCoroutine(Restart());
        }

    }

    IEnumerator Restart()
    {
        CollectableObject.gameIsFinished = false;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        gameIsOver = true;
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
