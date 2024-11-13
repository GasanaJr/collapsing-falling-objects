using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Factory Class
public abstract class Sphere : MonoBehaviour
{
    public abstract void Move();
    public static event Action<Sphere> onSphereDestroyed;

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroySphere();
        }
    }

    public void DestroySphere()
    {
        onSphereDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}

public class Spheres : Sphere
{
    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 5);
    }
}

public class Cylinder : Sphere
{
    public override void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2);
    }
}


