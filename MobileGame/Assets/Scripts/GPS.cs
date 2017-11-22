using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

    public float latitude;
    public float longitude;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        while (true)
        {
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log("User has not enabled GPS");
                yield break;
            }
            Input.location.Start();
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }
            if (maxWait <= 0)
            {
                Debug.Log("Timed out");
                yield break;
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determin device location");
                yield break;
            }

            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
