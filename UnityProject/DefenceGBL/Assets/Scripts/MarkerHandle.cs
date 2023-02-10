// using System;
// using UnityEngine;
// using Vuforia;
// using UnityEngine.SceneManagement;
// public class MarkerHandle : MonoBehaviour, ITrackableEventHandler
// {
//     public GameObject Scene;
//     public GameObject UI;
//     public UIMenuContrl UIMenuCtrl;
//     public UIGameContrl UIGameCtrl;
//     protected TrackableBehaviour mTrackableBehaviour;

//     void Awake()
//     {
//         TipsManager.m_bIsLoading = false;
//     }

//     protected virtual void Start()
//     {

//         mTrackableBehaviour = GetComponent<TrackableBehaviour>();
//         if (mTrackableBehaviour)
//             mTrackableBehaviour.RegisterTrackableEventHandler(this);
//     }

//     public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
//     {
//         if (newStatus == TrackableBehaviour.Status.DETECTED ||
//             newStatus == TrackableBehaviour.Status.TRACKED ||
//             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
//         {
//             OnTrackingFound();
//         }
//         else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
//                  newStatus == TrackableBehaviour.Status.NOT_FOUND)
//         {
//             OnTrackingLost();
//         }
//         else
//         {
//             OnTrackingLost();
//         }
//     }

//     protected virtual void OnTrackingFound()
//     {
//         MarkerFound();
//     }

//     protected virtual void OnTrackingLost()
//     {
//         MarkerLost();
//     }

//     void MarkerFound()
//     {
//         GazePointManager.Instance.ShowPoint();
//         TipsManager.Instance.HideMarkerTipsUI();
//         if (!TipsManager.m_bIsFindMarker)
//             TipsManager.m_bIsFindMarker = true;
//         UI.SetActive(true);
//         Scene.SetActive(true);
//         Time.timeScale = 1;
//     }

//     void MarkerLost()
//     {
//         if (TipsManager.m_bIsLoading != true)
//         {
//             GazePointManager.Instance.HidePoint();
//             TipsManager.Instance.ShowMarkerTipsUI();

//             if (TipsManager.m_bIsFindMarker)
//                 TipsManager.m_bIsFindMarker = false;
//             Time.timeScale = 0;
//             Scene.SetActive(false);
//             UI.SetActive(false);
//         }
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.K))
//         {
//             MarkerLost();
//         }
//         if (Input.GetKeyDown(KeyCode.L))
//         {
//             MarkerFound();
//         }
//     }

// }
