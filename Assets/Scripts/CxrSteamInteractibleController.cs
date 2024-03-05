using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class CxrSteamInteractibleController : MonoBehaviour
{
    InteractableHoverEvents iHE;
    // Start is called before the first frame update

 public void OnHoverBegin()
    {
        Debug.Log("OnHoverBegan Called for " + gameObject.name);
        GetComponent<InteractableHoverEvents>().onHandHoverBegin.Invoke();
    }
}
