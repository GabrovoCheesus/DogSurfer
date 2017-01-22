using UnityEngine;

public class RampSpawnerController : MonoBehaviour
{
    public int rampCount = 3;

    public GameObject[] ramps;
    
    public GameObject rampPrototype;
    public GameObject finish;

    public void Start()
    {
        Vector3 lastPossition;
        for (int i = 1; i <= rampCount; i++)
        {
            int index = Random.Range(0, ramps.Length);
            lastPossition = rampPrototype.transform.FindChild("End").transform.position;

            var ramp = Instantiate(ramps[index]);
            ramp.transform.position = lastPossition;
            
            ramp.transform.SetParent(transform.parent);
            ramp.name = "Wave " + i; 
            rampPrototype = ramp;
        }

        var finishRamp = Instantiate(finish);

        lastPossition = rampPrototype.transform.FindChild("End").transform.position;
        finishRamp.transform.position = lastPossition;
    }
}
