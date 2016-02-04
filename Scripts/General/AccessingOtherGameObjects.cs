// Most advanced game code does not only manipulate a single object. The Unity scripting interface has various ways to find and access other game objects and components there-in. In the following we assume there is a script named OtherScript.js attached to game objects in the scene.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Update() {
        OtherScript otherScript = GetComponent<OtherScript>();
        otherScript.DoSomething();
    }
}

//1. Through inspector assignable references.
//You can assign variables to any object type through the inspector:

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    public Transform target;
    void Update() {
        target.Translate(0, 1, 0);
    }
}

//You can also expose references to other objects to the inspector. Below you can drag a game object that contains the OtherScript on the target slot in the inspector.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    public OtherScript target;
    void Update() {
        target.foo = 2;
        target.DoSomething("Hello");
    }
}

//2. Located through the object hierarchy.
//You can find child and parent objects to an existing object through the Transform component of a game object:
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Example() {
        transform.Find("Hand").Translate(0, 1, 0);
    }
}

//Once you have found the transform in the hierarchy, you can use GetComponent to get to other scripts.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Example() {
        transform.Find("Hand").GetComponent<OtherScript>().foo = 2;
        transform.Find("Hand").GetComponent<OtherScript>().DoSomething("Hello");
        transform.Find("Hand").rigidbody.AddForce(0, 10, 0);
    }
}

//You can loop over all children:
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Example() {
        foreach (Transform child in transform) {
            child.Translate(0, 10, 0);
        }
    }
}

//See the documentation for the Transform class for further information.
//3. Located by name or Tag.
//
//You can search for game objects with certain tags using GameObject.FindWithTag and GameObject.FindGameObjectsWithTag. Use GameObject.Find to find a game object by name.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Start() {
        GameObject go = GameObject.Find("SomeGuy");
        go.transform.Translate(0, 1, 0);
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.Translate(0, 1, 0);
    }
}

//You can use GetComponent on the result to get to any script or component on the found game object
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Start() {
        GameObject go = GameObject.Find("SomeGuy");
        go.GetComponent<OtherScript>().DoSomething();
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<OtherScript>().DoSomething();
    }
}

//Some special objects like the main camera have shorts cuts using Camera.main.

//4. Passed as parameters.

//Some event messages contain detailed information on the event. For instance, trigger events pass the Collider component of the colliding object to the handler function.

//OnTriggerStay gives us a reference to a collider. From the collider we can get to its attached rigidbody.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void OnTriggerStay(Collider other) {
        if (other.rigidbody)
            other.rigidbody.AddForce(0, 2, 0);
        
    }
}

//Or we can get to any component attached to the same game object as the collider.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void OnTriggerStay(Collider other) {
        if (other.GetComponent<OtherScript>())
            other.GetComponent<OtherScript>().DoSomething();
        
    }
}

//Note that by suffixing the other variable in the above example, you can access any component inside the colliding object.

//5. All scripts of one Type

//Find any object of one class or script name using Object.FindObjectsOfType or find the first object of one type using Object.FindObjectOfType.
//C#

using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {
    void Start() {
        OtherScript other = FindObjectOfType(typeof(OtherScript));
        other.DoSomething();
    }
}