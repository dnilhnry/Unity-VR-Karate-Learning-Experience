using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformScript
{
    public static Transform FindDeepChild(this Transform parentForSearch, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(parentForSearch);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c == null)
            {
                int a = 0;
                a++;
            }
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }

    public static Transform FindAlways(string name)
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            objectsInScene.Add(go);
        }
        return objectsInScene.Find(x => x.name == name).transform;
    }
}
