using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Space : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] grass;
    public GameObject[] bigRocks;
    public int maxObjects = 10;
    public int maxGrass = 100;
    public int maxRock = 5;

    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;
    public LayerMask layersToInstance;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxObjects; i++)
        {
            SpreadObjects();
        }

        for (int i = 0; i < maxGrass; i++)
        {
            SpreadGrass();
        }
        for (int i = 0; i < maxRock; i++)
        {
            SpreadBigRocks();
        }
    }

    void SpreadObjects()
    {
        RaycastHit hit;

        Vector3 randPosition = new Vector3(Random.Range(transform.position.x - (itemXSpread/2), transform.position.x + (itemXSpread / 2)),
            1000, Random.Range(transform.position.z - (itemZSpread / 2), transform.position.z + (itemZSpread / 2)));

        if (Physics.Raycast(randPosition, -Vector3.up, out hit))
        {
            if (hit.transform.gameObject.layer == layersToInstance)
            {
                int index = Random.Range(0, objects.Length);
                Quaternion rot = Quaternion.FromToRotation(objects[index].transform.up, hit.normal) * objects[index].transform.localRotation;
                GameObject clone = Instantiate(objects[index], hit.point, rot, transform);
                clone.transform.localRotation = Quaternion.Euler(clone.transform.localRotation.x, Random.Range(-360, 360), clone.transform.localRotation.z);
                float size = Random.Range(1f, 1.5f);
                clone.transform.localScale = new Vector3(clone.transform.localScale.x * size, clone.transform.localScale.y * size,
                    clone.transform.localScale.z * size);
            }
        }
    }

    void SpreadGrass()
    {

        RaycastHit hit;

        Vector3 randPosition = new Vector3(Random.Range(transform.position.x - (itemXSpread / 2), transform.position.x + (itemXSpread / 2)),
            1000, Random.Range(transform.position.z - (itemZSpread / 2), transform.position.z + (itemZSpread / 2)));

        if (Physics.Raycast(randPosition, -Vector3.up, out hit))
        {
            if (hit.transform.gameObject.layer == layersToInstance)
            {
                int index = Random.Range(0, grass.Length);
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject clone = Instantiate(grass[index], hit.point, rot, transform);
                //clone.transform.localRotation = Quaternion.Euler(clone.transform.localRotation.x, Random.Range(-360, 360), clone.transform.localRotation.z);
                float size = Random.Range(1f, 1.5f);
                clone.transform.localScale = new Vector3(clone.transform.localScale.x * size, clone.transform.localScale.y * size,
                    clone.transform.localScale.z * size);
            }
        }
    }
    void SpreadBigRocks()
    {

        RaycastHit hit;

        Vector3 randPosition = new Vector3(Random.Range(transform.position.x - (itemXSpread / 2), transform.position.x + (itemXSpread / 2)),
            1000, Random.Range(transform.position.z - (itemZSpread / 2), transform.position.z + (itemZSpread / 2)));

        if (Physics.Raycast(randPosition, -Vector3.up, out hit))
        {
            if (hit.transform.gameObject.layer == layersToInstance)
            {
                int index = Random.Range(0, bigRocks.Length);
                Quaternion rot = Quaternion.FromToRotation(bigRocks[index].transform.up, hit.normal) * bigRocks[index].transform.localRotation;
                GameObject clone = Instantiate(bigRocks[index], hit.point, rot, transform);
                clone.transform.localRotation = Quaternion.Euler(clone.transform.localRotation.x, Random.Range(-360, 360), clone.transform.localRotation.z);
                float size = Random.Range(1f, 1.5f);
                clone.transform.localScale = new Vector3(clone.transform.localScale.x * size, clone.transform.localScale.y * size,
                    clone.transform.localScale.z * size);
            }
        }
    }
}
