using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playGame());
    }

    IEnumerator playGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

}
