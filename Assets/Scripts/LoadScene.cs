using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public GameObject Menu;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Start");
        if (SceneManager.GetActiveScene().name == "WarpScene")
        {
            StartCoroutine(LoadSceneDelay("Sniper"));
        }
	}

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
    }

    public void LoadSniperScene()
    {
        SceneManager.LoadScene("WarpScene");
    } 

    IEnumerator LoadSceneDelay(string scene)
    {
        Debug.Log("Delaying");
        yield return new WaitForSeconds(8f);
        Debug.Log("Delayed");
        SceneManager.LoadScene("SniperScene");
        //yield return 0;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
