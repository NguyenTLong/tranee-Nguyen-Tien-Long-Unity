using UnityEngine;
using CreatorKitCode;

public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    private int radius = 5;
    public int numberOfStarterPotion = 5;

    void Start()
    {
        LootAngle loot = new LootAngle(30);

        for (int i = 0; i < numberOfStarterPotion; i++)
        {
            SpawnPotion(loot.NextAngle());
        }
    }

    public void SpawnPotion(int angle)
    {
        Vector3 spawnPosition = transform.position;
        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;

        spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }
}

public class LootAngle
{
    public int angle { get; set; }
    public int step { get; set; }

    public LootAngle(int increment)
    {
        step = increment;
        angle = 0;
    }

    public int NextAngle()
    {
        int currentAngle = angle;
        angle = Helpers.WrapAngle(angle + step);

        return currentAngle;
    }
}

