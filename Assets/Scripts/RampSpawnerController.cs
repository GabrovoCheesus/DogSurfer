using UnityEngine;

public class RampSpawnerController : MonoBehaviour
{
    public int minRampCount = 100;
    public int maxRampCount = 200;

    public GameObject[] ramps;
    
    public GameObject rampPrototype;
    public GameObject finish;

    public void Start()
    {
        var count = Random.Range(minRampCount, maxRampCount);

        Vector3 lastPossition;
        for (int i = 1; i <= count; i++)
        {
            int index = Random.Range(0, ramps.Length);
            lastPossition = rampPrototype.transform.Find("End").transform.position;

            var ramp = Instantiate(ramps[index]);
            ramp.transform.position = lastPossition;
            
            ramp.transform.SetParent(transform.parent);
            ramp.name = "Wave " + i; 
            rampPrototype = ramp;
        }

        var finishRamp = Instantiate(finish);

        lastPossition = rampPrototype.transform.Find("End").transform.position;
        finishRamp.transform.position = lastPossition;
    }
}
