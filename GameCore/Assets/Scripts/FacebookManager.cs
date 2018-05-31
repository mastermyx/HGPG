using Facebook.Unity;
using UnityEngine;

public class FacebookManager : MonoBehaviour {

	void Awake()
    {
		// The object (and script) will stay on scene change
		DontDestroyOnLoad(this.gameObject);

        CheckFacebookActivation();
    }

    void OnApplicationPause(bool pauseStatus)
    {
		// "status false" means "OnApplicationResume"
        if (false == pauseStatus)
            CheckFacebookActivation();
    }

    // Using the SDKs initialization methods
	private void CheckFacebookActivation()
    {
        if (FB.IsInitialized)
            FB.ActivateApp();
        else
        {
            // Handle FB.Init
            FB.Init(() => {
                FB.ActivateApp();
            });
        }
    }

    public static void TrackEvent(string eventName)
    {
		FB.LogAppEvent(eventName);
	}

    public static void TrackEvent(string eventName, int paramValue)
    {
		FB.LogAppEvent(eventName, paramValue);
    }
}
