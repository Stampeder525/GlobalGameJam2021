using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public bool holdingItem = false;
    public float proxRadius = 10;
    public float pickupTime = 2;
    public GameObject holdLocation;
    private GameObject heldItem;
    private IEnumerator grabRoutine;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && grabRoutine == null)
        {
            if(!holdingItem)
            {
                float minDist = proxRadius;
                GameObject closestObj = null;
                //Check all items in proximity and move to hold location
                Collider[] itemCollider = Physics.OverlapSphere(transform.position, proxRadius, 1 << LayerMask.NameToLayer("Item"));

                if(itemCollider.Length > 0)
                {
                    foreach (Collider coll in itemCollider)
                    {
                        float dist = Vector3.Distance(transform.position, coll.transform.position);
                        if (dist < minDist)
                        {
                            //Pick this item up as primary
                            minDist = dist;
                            closestObj = coll.gameObject;
                        }
                    }

                    //Grab min item as object
                    grabRoutine = PickupItem(closestObj);
                    if(grabRoutine != null)
                        StartCoroutine(grabRoutine);
                }
            }
            else
            {
                DropItem(heldItem);
            }
        }
    }

    public IEnumerator PickupItem(GameObject item)
    {
        //Parent object to hold location
        item.transform.parent = holdLocation.transform;
        
        //Turn off rigidbody physics
        Rigidbody itemRB = item.GetComponent<Rigidbody>();
        if(itemRB != null)
        {
            itemRB.useGravity = false;
            itemRB.isKinematic = true;
        }

        float time = pickupTime;
        Vector3 prevItemLoc = item.transform.position;

        while(time > 0)
        {
            time -= Time.deltaTime;
            item.transform.position = Vector3.Lerp(prevItemLoc, holdLocation.transform.position, 1 - (time / pickupTime));
            yield return null;
        }

        heldItem = item;
        holdingItem = true;
        grabRoutine = null;
        item.GetComponent<PickupItem>().OnPickup();
    }

    public void DropItem(GameObject item)
    {
        //Parent object out of hold location
        item.transform.parent = null;

        heldItem = null;
        holdingItem = false;

        //Turn off rigidbody physics
        Rigidbody itemRB = item.GetComponent<Rigidbody>();
        if (itemRB != null)
        {
            itemRB.useGravity = true;
            itemRB.isKinematic = false;
        }
    }
}
