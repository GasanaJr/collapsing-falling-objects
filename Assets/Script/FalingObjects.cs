using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Factory Implementation Pattern For Falling Objects
public class FalingObjects : MonoBehaviour
{
    private static FalingObjects instance;
    public static FalingObjects Instance
    {
        get
        {
            if (instance ==  null)
            {
                instance = FindObjectOfType<FalingObjects>();
                if (instance == null)
                {
                    instance = new GameObject("FallingObjects").AddComponent<FalingObjects>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public Sphere CreateFallingObject(string type)
    {
        Sphere sphere = null;

        if (type == "Spheres")
        {
            GameObject sphereObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereObj.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), 6f, 0);
            sphere = sphereObj.AddComponent<Spheres>();
        }
        else if (type == "Cylinder")
        {
            GameObject cylObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylObj.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), 6f, 0);
            sphere = cylObj.AddComponent<Spheres>();
        }
        return sphere;

    }
}
