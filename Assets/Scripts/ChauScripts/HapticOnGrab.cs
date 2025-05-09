using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticOnGrab : MonoBehaviour
{
    public HapticImpulsePlayer hapticPlayer;
    public float safeAmplitude = 0.0f;
    public float unsafeAmplitude = 0.8f;
    public float duration = 0.3f;
    
    private void OnEnable()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

    }
    
}
