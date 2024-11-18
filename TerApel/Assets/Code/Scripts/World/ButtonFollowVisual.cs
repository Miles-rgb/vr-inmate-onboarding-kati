using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float restartSpeed;
    public float followAngleThreshold;

    private bool isFrozen = false;

    private Vector3 initialLocalPos;
    private Vector3 offset;
    private Transform pokeAttachTransform;

    private XRBaseInteractable interactable;
    private bool isFollowing = false;

    private bool isOn = false;
    public GameObject SwitchObject;
    public Material offMaterial;
    public Material onMaterial;
    // Start is called before the first frame update
    void Start()
    {
        // Check if visual target and switch object are assigned
        if (visualTarget == null || SwitchObject == null)
        {
            Debug.LogError("Visual Target or Switch Object not assigned.");
            return;
        }

        // Store the initial position of the visual target
        initialLocalPos = visualTarget.localPosition;

        // Get the XRBaseInteractable component
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable == null)
        {
            Debug.LogError("XRBaseInteractable component is missing.");
            return;
        }

        // Subscribe to interaction events
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Restart);
        interactable.selectEntered.AddListener(Freeze);

        // Set initial material state
        UpdateMaterial();
    }

    private void Follow(BaseInteractionEventArgs hover)
    {
        // Check if the interactor is a poke interactor
        if (hover.interactorObject is XRPokeInteractor interactor)
        {            
            isFollowing = true;

            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            // Calculate angle to determine if follow is within threshold
            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            if(pokeAngle > followAngleThreshold)
            {
                isFollowing = false;
                isFrozen = true;
            }
        }
    }

    private void Restart(BaseInteractionEventArgs hover)
    {
        // Only stop following if it’s currently following
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            isFrozen = false;
        }
    }

    private void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFrozen = true;
            Switch();
        }
    }

    public void Switch()
    {
        isOn = !isOn;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        if (SwitchObject.TryGetComponent(out MeshRenderer renderer))
        {
            renderer.material = isOn ? onMaterial : offMaterial;
        }
        else
        {
            Debug.LogError("SwitchObject missing MeshRenderer component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If button is frozen, do nothing
        if (isFrozen)
        {
            return; 
        }

        // Following mode
        if (isFollowing && pokeAttachTransform != null)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        // Returning mode
        else
        {
            // Smoothly return visual target to the initial position
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * restartSpeed);
        }
    }
}
