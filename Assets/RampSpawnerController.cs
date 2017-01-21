using UnityEngine;

public class RampSpawnerController : MonoBehaviour
{
    public int rampCount = 3;

    public GameObject[] ramps;
    
    public GameObject rampPrototype;

    public void Start()
    {
        for (int i = 1; i <= rampCount; i++)
        {
            int index = Random.Range(0, ramps.Length);
            Vector3 lastPossition = rampPrototype.transform.FindChild("End").transform.position;

            var ramp = Instantiate(ramps[index]);
            ramp.transform.position = lastPossition;
            
            ramp.transform.SetParent(transform.parent);
            ramp.name = "Wave " + i; 
            rampPrototype = ramp;
        }
    }
}
