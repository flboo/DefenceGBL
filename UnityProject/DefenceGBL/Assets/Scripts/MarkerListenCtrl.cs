using UnityEngine;
// using Vuforia;
using UnityEngine.SceneManagement;

/*
public class MarkerListenCtrl : MonoBehaviour,ITrackableEventHandler
{
public GameObject m_objScenes;
void Awake()
{
    TipsManager.m_bIsLoading = false;
}

protected TrackableBehaviour mTrackableBehaviour;

protected virtual void Start()
{
    mTrackableBehaviour = GetComponent<TrackableBehaviour>();
    if (mTrackableBehaviour)
        mTrackableBehaviour.RegisterTrackableEventHandler(this);
}

public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
{
    if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
    {
        OnTrackingFound();
    }
    else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
             newStatus == TrackableBehaviour.Status.NOT_FOUND)
    {
        OnTrackingLost();
    }
    else
    {
        OnTrackingLost();
    }
}

protected virtual void OnTrackingFound()
{
    MarkerFound();
}

protected virtual void OnTrackingLost()
{
    MarkerLost();
}

void MarkerFound()
{
    Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    TipsManager.m_bIsFindMarker = true;
    TipsManager.Instance.HideMarkerTipsUI();
    if (!m_objScenes.activeSelf)
        m_objScenes.SetActive(true);
        GazePointManager.Instance.ShowPoint();
    Time.timeScale = 1;
}

void MarkerLost()
{
    //UnityEngine.XR.XRSettings.enabled
    if (TipsManager.m_bIsLoading != true)
    {
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " Lost");
        TipsManager.m_bIsFindMarker = false;
        TipsManager.Instance.ShowMarkerTipsUI();
        GazePointManager.Instance.HidePoint();
        if (m_objScenes.activeSelf)
            m_objScenes.SetActive(false);
        Time.timeScale = 0;
    }
}
}
*/
