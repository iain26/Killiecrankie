using UnityEngine;

namespace Vuforia
{
    public class TrackImage : MonoBehaviour, ITrackableEventHandler{

        public delegate void Tracking(string name); 
        public static event Tracking OnFound;
        public static event Tracking OnLost;

        private TrackableBehaviour mTrackableBehaviour;

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        private void OnTrackingFound()
        {
            OnFound(mTrackableBehaviour.TrackableName);

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
        }


        private void OnTrackingLost()
        {
            OnLost(mTrackableBehaviour.TrackableName);
            //GameObject.Find("GameData").GetComponent<GameDataScript>().TurnOffButtons(mTrackableBehaviour.TrackableName);

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
        }
    }
}
