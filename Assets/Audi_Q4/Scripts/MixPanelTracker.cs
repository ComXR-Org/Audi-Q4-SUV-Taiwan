using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mixpanel;

public class MixPanelTracker : MonoBehaviour
{
    private void Awake()
    {
        Mixpanel.Track("App Start");

        string deviceIdentifier = System.Guid.NewGuid().ToString();
        string userID = Mixpanel.DistinctId; 
        Mixpanel.Identify(userID);

        // Add device identifier as a property to associate with the user.
        Value properties = new Value() { { "DeviceID", deviceIdentifier } };

        // Track user information with the device identifier as a property.
        Mixpanel.Track("UserProfile", properties);
    }

    public void EventTriggerExteriorColour(string value)
    {
        Mixpanel.Track("Exterior Colour Selected", "colour_selected", value);
    }

    public void EventTriggerInteriorColour(string value)
    {
        Mixpanel.Track("Interior Seat Colour Selected", "colour_selected", value);
    }

    public void EventTriggerInlaysColour(string value)
    {
        Mixpanel.Track("Inlays Colour Selected", "colour_selected", value);
    }

    public void EventTriggerRims(string value)
    {
        Mixpanel.Track("Rims Selection", "rims_type", value);
    }

    public void EventTriggerDoors(string value)
    {
        Mixpanel.Track("Door Selected", "door_selected", value);
    }

    public void CommonEventTrigger(string value)
    {
        Mixpanel.Track(value);
        //Debug.Log(value+ " MixPanel");
    }

    public void LanguageEventTrigger(string value)
    {
        Mixpanel.Track("Language Selected"+ value);
        //Debug.Log(value + " MixPanel");
    }

    public void OnApplicationQuit()
    {
        AppQuit();
    }

    public void AppQuit()
    {
        Mixpanel.Track("App Quit");
    }

    public void AppReset()
    {
        Mixpanel.Reset();
    }
}
