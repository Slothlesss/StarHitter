using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public FinalHole[] finalHolePools;
    public GameObject victory;
    public static GameManager Instance;
    public int count;

    public GameObject[] gameViews;
    public int gameIndex;

    public Hole[] holes;

    public GameObject mainCamera;
    public bool isTransitioning;
    private void Awake()
    {
        MoveToNextLevel();
        Instance = this;
        count = 0;
    }

    private void Update()
    {
        if (count == finalHolePools.Length)
        {
            gameIndex++; 
            isTransitioning = true;
            if (gameIndex == gameViews.Length)
            {
                victory.SetActive(true);
            }
            else
            {
                MoveToNextLevel();
                count = 0;
            }
        }
        if (mainCamera.transform.position == gameViews[gameIndex].transform.position + new Vector3(0, 0, -10) && isTransitioning == true)
        {
            Debug.Log("Long");
            isTransitioning = false;
            StartCoroutine(BeginEffect());
        }

    }
    public void MoveToNextLevel()
    {
        for (int i = 0; i < gameViews.Length; i++)
        {
            gameViews[i].SetActive(false);
        }
        gameViews[gameIndex].SetActive(true);
        holes = gameViews[gameIndex].GetComponentsInChildren<Hole>();
        finalHolePools = gameViews[gameIndex].GetComponentsInChildren<FinalHole>();
        foreach (Hole hole in holes)
        {
            Debug.Log("Long123");
            hole.gameObject.SetActive(false);
        }
        foreach (FinalHole finalHole in finalHolePools)
        {
            Debug.Log("Long12333");
            finalHole.gameObject.SetActive(false);
        }
        if (gameIndex >= 1)
        {
            StartCoroutine(MoveTo(mainCamera, gameViews[gameIndex - 1].transform.position, gameViews[gameIndex].transform.position));
        }
    }
    IEnumerator BeginEffect()
    {
        foreach (FinalHole hole in finalHolePools)
        {
            hole.gameObject.SetActive(true);
            hole.GetComponent<Animator>().SetBool("Begin", true);
            yield return new WaitForSeconds(0.75f);
        }

        foreach (Hole hole in holes)
        {
            hole.gameObject.SetActive(true);
            hole.GetComponent<Animator>().SetBool("Begin", true);

            yield return new WaitForSeconds(0.75f);
        }
    }


    public IEnumerator MoveTo(GameObject go, Vector3 posA, Vector3 posB)
    {
        float progress = 0;
        while (progress <= 5)
        {
            go.transform.position = Vector3.Lerp(posA, posB, progress/5) + new Vector3(0,0,-10);
            progress += Time.deltaTime;
            yield return null;
        }
        go.transform.position = posB + new Vector3(0, 0, -10);

    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
