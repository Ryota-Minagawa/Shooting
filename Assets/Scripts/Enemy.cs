using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{

    private GameObject upperStage;
    private float upperStageX;
    private float upperStageZ;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    
    private void OnEnable()
    {
        if(upperStage!=null)
        gameObject.transform.position = upperStage.transform.position + new Vector3(
                                            Random.Range(-upperStageX / 2, upperStageX / 2), 0,
                                            Random.Range(-upperStageZ / 2, upperStageZ / 2));	
    }
     
    private void Start()
    {
        
        if (upperStage == null)
        {
            upperStage = InstantiateStage._stageInstance;
            upperStageX = upperStage.GetComponent<Renderer>().bounds.size.x;
            upperStageZ = upperStage.GetComponent<Renderer>().bounds.size.z;
        }

        if (_rigidbody == null)
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidbody.GetComponent<Rigidbody>().drag = 1;
            
        }

        if (_boxCollider == null)
        {
            _boxCollider = gameObject.GetComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
    
}


