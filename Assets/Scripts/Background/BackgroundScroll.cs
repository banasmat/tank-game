using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BackgroundScroll : MonoBehaviour
{
    // Based on https://www.linkedin.com/pulse/infinite-scrolling-2d-background-unity3d-using-c-snapping-owais-zahid

    public float speed;
    private List<Transform> backgroundPart;

    void Start()
    {
        backgroundPart = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.GetComponent<SpriteRenderer>() != null)
            {
                backgroundPart.Add(child);
            }
        }
        backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        Transform firstChild = backgroundPart.FirstOrDefault();

        if (firstChild != null)
        {
            if (firstChild.position.x < Camera.main.transform.position.x)
            {
                if (firstChild.GetComponent<SpriteRenderer>().IsVisibleFrom(Camera.main) == false)
                {
                    Transform lastChild = backgroundPart.LastOrDefault();

                    Vector3 lastPosition = lastChild.transform.position;

                    Vector3 lastSize = lastChild.GetComponent<SpriteRenderer>().bounds.max - lastChild.GetComponent<SpriteRenderer>().bounds.min;

                    firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

                    backgroundPart.Remove(firstChild);
                    backgroundPart.Add(firstChild);
                }
            }
        }
    }
}


//TODO move to separate file

public static class SpriteRendererExtension
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

