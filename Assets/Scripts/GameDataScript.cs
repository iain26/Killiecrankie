using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;

public class GameDataScript : MonoBehaviour {

    public string sceneName;

    public bool SniperGame = false;
    public bool LeapGame = false;
    public bool ChargeGame = false;
    public bool Royalist = false;
    public bool ThinJacobite = false;
    public bool FatJacobite = false;

    public string objectToDisplay;
    public string character;

    private GameObject notification;
    private Text notificationText;

    FileInfo fileOfGames;

    public string data;
    string gamesCollected;

    public Text dataText;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        GameObject[] arrayCheck = GameObject.FindGameObjectsWithTag("GameData");
        if(arrayCheck.Length > 1)
        {
            Destroy(gameObject);
        }
        //if (new FileInfo(Application.persistentDataPath + "\\" + "gamesCollected.txt").Exists == false)
        {
            fileOfGames = new FileInfo(Application.persistentDataPath + "\\" + "gamesCollected.txt");
        }
        CheckUnlockedGames();
    }

    void SaveToFile(string gameCollected)
    {
        gamesCollected = gamesCollected + gamesCollected;
        StreamWriter write;
        fileOfGames.Delete();
        write = fileOfGames.CreateText();
        write.WriteLine(gamesCollected);
        write.Close();
    }

    string LoadFile()
    {
        StreamReader read = File.OpenText(Application.persistentDataPath + "\\" + "gamesCollected.txt");
        string loadedData = read.ReadToEnd();
        read.Close();
        data = loadedData;
        return data;
    }

    void CheckUnlockedGames()
    {
        if (LoadFile().Contains("Leap_Game"))
        {
            LeapGame = true;
        }
        if (LoadFile().Contains("QR"))
        {
            ChargeGame = true;
        }
    }

    public void SetBool(string trackName)
    {
        switch (trackName)
        {
            case "Leap_Game":
                if (!LeapGame)
                {
                    LeapGame = true;
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Leap Game in Games Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + "|| ");
                    CheckUnlockedGames();
                }
                break;
            case "QR":
                if (!ChargeGame)
                {
                    ChargeGame = true;
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Charge Game in Games Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + " || ");
                    CheckUnlockedGames();
                }
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        notification.SetActive(false);
        yield return 0;
    }

    public void ChangeSceneName(string scene)
    {
        sceneName = scene;
    }

    // Update is called once per frame
    void Update()
    {
        dataText.text = data;
        if (SceneManager.GetActiveScene().name == "ArScene")
        {
            notification = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
            notificationText = GameObject.Find("Canvas").transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>();
        }

        if (SceneManager.GetActiveScene().name == "ChargeScene" || SceneManager.GetActiveScene().name == "LeapScene")
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
