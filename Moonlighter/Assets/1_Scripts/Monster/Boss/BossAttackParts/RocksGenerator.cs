using UnityEngine;

public class RocksGenerator : MonoBehaviour
{
    public GameObject rock;

    private GameObject[] rocks;

    public int numObjects;

    public float radius = 1.7f;

    private void Awake()
    {
        rocks = new GameObject[numObjects];
        if (rocks[0] == null)
        {
            CreateRocks();
        }
    }


    void CreateRocks()
    {
        float angleStep = Mathf.PI / (numObjects + 1);
        for (int i = 0; i < numObjects; ++i)
        {
            float angle = (i + 1) * angleStep;
            float x = -radius * Mathf.Cos(angle);
            float y = -radius * Mathf.Sin(angle);
            Vector3 position = transform.position + new Vector3(x, y, 0);
            rocks[i] = Instantiate(rock, position, Quaternion.identity, this.transform);
        }
    }
}
