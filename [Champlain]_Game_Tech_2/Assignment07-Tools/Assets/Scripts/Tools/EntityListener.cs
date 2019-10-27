using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityListener : MonoBehaviour
{
    public Entity target;

    public void testFunction()
    {
        target.printName();
    }

}
