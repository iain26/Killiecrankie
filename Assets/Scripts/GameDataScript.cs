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
    public bool Musket = false;
    public bool RandomModel = false;

    public string objectToDisplay;
    public string character;

    private GameObject notification;
    private Text notificationText;

    private GameObject LeapButton;

    FileInfo fileOfGames;
    string fileName = "Collected_Games";

    public string data;
    string gamesCollected;

    public Text trackNameText;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        GameObject[] arrayCheck = GameObject.FindGameObjectsWithTag("GameData");
        if(arrayCheck.Length > 1)
        {
            Destroy(gameObject);
        }
        //if (new FileInfo(Application.persistentDataPath + "\\" + fileName +".txt").Exists == false)
        {
            fileOfGames = new FileInfo(Application.persistentDataPath + "\\" + fileName +".txt");
        }
        CheckUnlocked();
    }

    #region file_saving_Loading

    void SaveToFile(string gameCollected)
    {
        gamesCollected = gamesCollected + gameCollected;
        StreamWriter write;
        fileOfGames.Delete();
        write = fileOfGames.CreateText();
        write.WriteLine(gamesCollected);
        write.Close();
    }

    string LoadFile()
    {
        StreamReader read = File.OpenText(Application.persistentDataPath + "\\" + fileName + ".txt");
        string loadedData = read.ReadToEnd();
        read.Close();
        data = loadedData;
        return data;
    }

#endregion


    void CheckUnlocked()
    {
        if (LoadFile().Contains("Leap_Game"))
        {
            LeapGame = true;
            gamesCollected = gamesCollected + "Leap_Game ||";
        }
        if (LoadFile().Contains("Charge_Game"))
        {
            ChargeGame = true;
            gamesCollected = gamesCollected + "Charge_Game ||";
        }
        if (LoadFile().Contains("Royalist_Model"))
        {
            Royalist = true;
            gamesCollected = gamesCollected + "Royalist_Model ||";
        }
        if (LoadFile().Contains("Musket_Model"))
        {
            Musket = true;
            gamesCollected = gamesCollected + "Musket_Model ||";
        }
    }

    public void ClearGames()
    {
        File.Delete(Application.persistentDataPath + "\\" + fileName + ".txt");
        LeapGame = false;
        ChargeGame = false;
        Royalist = false;
        Musket = false;
        RandomModel = false;
        fileOfGames = new FileInfo(Application.persistentDataPath + "\\" + fileName + ".txt");
    }

    public void SetBool(string trackName)
    {
        trackNameText.text = trackName;
        switch (trackName)
        {
            case "Leap_Game":
                LeapButton.SetActive(true);
                if (!LeapGame)
                {
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Leap Game in Games Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + "|| ");
                    CheckUnlocked();
                }
                break;
            case "Charge_Game":
                if (!ChargeGame)
                {
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Charge Game in Games Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + " || ");
                    CheckUnlocked();
                }
                break;
            case "Royalist_Model":
                if (!Royalist)
                {
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Royalist in Gallery Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + " || ");
                    CheckUnlocked();
                }
                break;
            case "Musket_Model":
                if (!Musket)
                {
                    notification.SetActive(true);
                    notificationText.text = "You have unlocked the Musket in Gallery Menu";
                    StartCoroutine(Wait());
                    SaveToFile(trackName + " || ");
                    CheckUnlocked();
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
        if (SceneManager.GetActiveScene().name == "ArScene")
        {
            notification = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
            notificationText = GameObject.Find("Canvas").transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>();
            LeapButton = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
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
