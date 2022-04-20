using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    float randomRolateX;
    float randomRolateY;
    float randomRolateZ;

    void Start()
    {
        randomRolateX = getRandom();
        randomRolateY = getRandom();
        randomRolateZ = getRandom();
        
        transform.position = new Vector3(getRandom(), getRandom(), getRandom());
        transform.localScale = Vector3.one * getRandom();
        
        Material material = Renderer.material;
        
        material.color = new Color(getColorValue(), getColorValue(), getColorValue(), 0.2f);
    }
    
    void Update()
    {
        transform.Rotate(randomRolateX * 0.1f, randomRolateY * 0.1f, randomRolateZ * 0.1f);
    }

    private float getRandom()
    {
       return Random.Range(-5f, 5f);
    }

    private float getColorValue()
    {
        return Random.Range(0f, 1f);
    }
}
