using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPSlocation : MonoBehaviour {

    public static GPSlocation currentGPS { set; get; }

    bool waited = true;

    float longitude;
    float latitude;

    public Text ehh;

    float[] CoordLong = { 55.867704f, 55.867280f, 55.867366f, 55.866970f, 55.866440f, 55.866370f, 55.863617f };
    float[] CoordLat = { -4.249458f, -4.249820f, -4.250511f, -4.251133f, -4.250350f, -4.249094f, -4.218252f };

    float DegToRad(float deg)
    {
        float temp;
        temp = (deg * Mathf.PI) / 180.0f;
        temp = Mathf.Tan(temp);
        return temp;
    }

    float Distance_x(float lon_a, float lon_b, float lat_a, float lat_b)
    {
        float temp;
        float c;
        temp = (lat_b - lat_a);
        c = Mathf.Abs(temp * Mathf.Cos((lat_a + lat_b)) / 2);
        return c;
    }

    private float Distance_y(float lat_a, float lat_b)
    {
        float c;
        c = (lat_b - lat_a);
        return c;
    }

    float Final_distance(float x, float y)
    {
        float c;
        c = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f))) * 6.371000f;
        return c;
    }

    //*******************************
    //This is the function to call to calculate the distance between two points

    public float Calculate_Distance(float long_a, float lat_a, float long_b, float lat_b)
    {
        float a_long_r, a_lat_r, p_long_r, p_lat_r, dist_x, dist_y, total_dist;
        a_long_r = DegToRad(long_a);
        a_lat_r = DegToRad(lat_a);
        p_long_r = DegToRad(long_b);
        p_lat_r = DegToRad(lat_b);
        dist_x = Distance_x(a_long_r, p_long_r, a_lat_r, p_lat_r);
        dist_y = Distance_y(a_lat_r, p_lat_r);
        total_dist = Final_distance(dist_x, dist_y);
        return total_dist;
        //prints the distance on the console
        print(total_dist);

    }

    public float ConvertToRadians(float angle)
    {
        return (Mathf.PI / 180) * angle;
    }

    public float DistanceTo(float latitude1, float longitude1, float latitude2, float longitude2)
    {
        // The radius of the earth in Km.
        // You could also use a better estimation of the radius of the earth
        // using decimals digits, but you have to change then the int to double.
        int R = 6371;

        float f1 = ConvertToRadians(latitude1);
        float f2 = ConvertToRadians(latitude2);

        float df = ConvertToRadians(latitude1 - latitude2);
        float dl = ConvertToRadians(longitude1 - longitude2);

        float a = Mathf.Sin(dl / 2) * Mathf.Sin(dl / 2) + Mathf.Cos(f1) * Mathf.Cos(f2) * Mathf.Sin(df / 2) * Mathf.Sin(df / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        // Calculate the distance.
        float d = R * c;

        return d;
    }

    void GPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS not enabled");
        }
        else
        {
            Input.location.Start();

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
            }
            else
            {
                longitude = Input.location.lastData.longitude;
                latitude = Input.location.lastData.latitude;
            }
        }
        currentGPS = this;
    }

    //IEnumerator FindLocation()
    //{
    //    if (!Input.location.isEnabledByUser)
    //    {
    //        Debug.Log("GPS not enabled");
    //        yield break;
    //    }

    //    Input.location.Start();
    //    int maxWait = 20;
    //    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //    {
    //        yield return new WaitForSeconds(1);
    //        maxWait--;
    //    }

    //    if (maxWait <= 0)
    //    {
    //        Debug.Log("Timed Out");
    //        yield break;
    //    }

    //    if (Input.location.status == LocationServiceStatus.Failed)
    //    {
    //        Debug.Log("Unable to determine device location");
    //        yield break;
    //    }

    //    longitude = Input.location.lastData.longitude;
    //    latitude = Input.location.lastData.latitude;
    //    yield return 0;
    //}

    private void Start()
    {
        InvokeRepeating("GPS", 0f, 2f);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        waited = true;
        yield return 0;
    }

    private void Update()
    {
        //ehh.text = longitude.ToString() + " " + latitude.ToString() + "  " + Calculate_Distance(latitude, longitude, CoordLat[6], CoordLong[6]).ToString();
        if (SceneManager.GetActiveScene().name == "MapScene")
        {
            for (int i = 0; i < CoordLat.Length; i++)
            {
                if (Calculate_Distance(latitude, longitude, CoordLat[i], CoordLong[i]) < 22)
                {
                    if (waited)
                    {
                        waited = false;
                        StartCoroutine(Wait());
                        Handheld.Vibrate();
                    }
                    GameObject.Find("ARButton").GetComponent<Selectable>().interactable = true;
                    switch (i) {
                        case 0:
                        GetComponent<GameDataScript>().objectToDisplay = "Royalist";
                            break;
                        case 1:
                            GetComponent<GameDataScript>().objectToDisplay = "Leap";
                            break;
                        case 2:
                            GetComponent<GameDataScript>().objectToDisplay = "Sniper";
                            break;
                        case 3:
                            GetComponent<GameDataScript>().objectToDisplay = "Charge";
                            break;
                        case 4:
                            GetComponent<GameDataScript>().objectToDisplay = "TJacobite";
                            break;
                        case 5:
                            GetComponent<GameDataScript>().objectToDisplay = "TJacobite";
                            break;
                        case 6:
                            GetComponent<GameDataScript>().objectToDisplay = "Charge";
                            break;
                    }
                }
                else
                {
                    GameObject.Find("ARButton").GetComponent<Selectable>().enabled = false;
                }
            }
        }
    }
}
