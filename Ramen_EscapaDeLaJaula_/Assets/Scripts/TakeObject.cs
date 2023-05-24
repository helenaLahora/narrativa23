using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public bool playerDetectedObject = false;

    public SphereCollider SphereCollider;

    [SerializeField] private Variable variable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetectedObject = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetectedObject = false;

        }
    }

    public void OnInteract()
	{
        if (playerDetectedObject)
		{
            EventHandler.Variables[variable]++;
            Destroy(gameObject); 
		}
	}

}
