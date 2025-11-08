using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCarVarient : MonoBehaviour
{
    public List<GameObject> switchGameObject;
    public List<GameObject> hideObject;
    private void Start()
    {
        SwitchGameObject(false);
    }
    public void SwitchGameObject(bool switchVarient)
    {
        foreach (GameObject item in switchGameObject)
        {
            item.SetActive(switchVarient);
        }
        foreach (GameObject item in hideObject)
        {
            item.SetActive(!switchVarient);
        }
    }
}
