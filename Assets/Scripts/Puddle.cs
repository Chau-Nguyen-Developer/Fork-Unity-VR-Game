using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Puddle : MonoBehaviour
{
    [Tooltip("0 = no friction, 1 = normal friction")]
    public float frictionMultiplier = 0.7f;

    [Tooltip("Drag your PlayerPhysicMaterial here")]
    public PhysicMaterial playerMaterial;

    private float originalFriction;

    private void Start()
    {
        // Find the player’s CharacterController
        var cc = FindObjectOfType<CharacterController>();
        if (cc != null)
        {
            // If you assigned a material here, override the CC’s material
            if (playerMaterial != null)
            {
                cc.sharedMaterial = playerMaterial;
                originalFriction = playerMaterial.dynamicFriction;
            }
            // Otherwise, if the CC already has one, cache that
            else if (cc.sharedMaterial != null)
            {
                originalFriction = cc.sharedMaterial.dynamicFriction;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var cc = other.GetComponent<CharacterController>();
        if (cc != null && cc.sharedMaterial != null)
            cc.sharedMaterial.dynamicFriction = originalFriction * frictionMultiplier;
    }

    private void OnTriggerExit(Collider other)
    {
        var cc = other.GetComponent<CharacterController>();
        if (cc != null && cc.sharedMaterial != null)
            cc.sharedMaterial.dynamicFriction = originalFriction;
    }
}
