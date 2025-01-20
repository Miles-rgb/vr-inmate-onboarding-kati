using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityImage = UnityEngine.UI.Image;

public class XRFloatingPictogramButton : MonoBehaviour
{
    private Camera mainCamera;

    [Header("Pictogram Settings")]
    [SerializeField] private GameObject imageObject;
    private RectTransform rectTransform;
    private UnityImage imageRenderer;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Color defaultSpriteColor = new Color(255, 255, 255);
    private Vector2 defaultSpriteSize;
    [SerializeField] private Sprite pictogramSprite;
    [SerializeField] private float resetDistance = 5f;

    [Header("Scaling")]
    [SerializeField] private float scaleSpeed = 1f;
    [SerializeField] private float scaleShrinkAmount = 2f;
    [SerializeField] private float scaleExpandAmount = 2f;

    private enum ButtonState { Idle, Shrinking, Expanding, Selected }
    private ButtonState currentState;

    private void Awake()
    {
        mainCamera = Camera.main;

        rectTransform = imageObject.GetComponent<RectTransform>();
        imageRenderer = imageObject.GetComponentInChildren<UnityImage>();

        imageRenderer.sprite = defaultSprite;
        imageRenderer.color = defaultSpriteColor;
        defaultSpriteSize = rectTransform.sizeDelta;

        currentState = ButtonState.Idle; // Start in Idle state
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        transform.LookAt(new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z)); // Face camera, lock Y axis

        float distanceToCamera = Vector3.Distance(transform.position, cameraPosition);
        HandleStateTransitions(distanceToCamera);
        ExecuteStateLogic();
    }

    private void HandleStateTransitions(float distanceToCamera)
    {
        switch (currentState)
        {
            case ButtonState.Idle:
                if (distanceToCamera < resetDistance)
                {
                    currentState = ButtonState.Expanding;
                }
                break;

            case ButtonState.Shrinking:
                if (distanceToCamera < resetDistance)
                {
                    currentState = ButtonState.Expanding;
                }
                break;

            case ButtonState.Expanding:
                if (distanceToCamera >= resetDistance)
                {
                    currentState = ButtonState.Shrinking;
                }
                break;

            case ButtonState.Selected:
                if (distanceToCamera >= resetDistance)
                {
                    currentState = ButtonState.Shrinking;
                }
                break;
        }
    }

    private void ExecuteStateLogic()
    {
        switch (currentState)
        {
            case ButtonState.Idle:
                SmoothResize(defaultSpriteSize / scaleShrinkAmount);
                break;

            case ButtonState.Shrinking:
                imageRenderer.sprite = defaultSprite;
                imageRenderer.color = defaultSpriteColor;
                SmoothResize(defaultSpriteSize / scaleShrinkAmount);
                break;

            case ButtonState.Expanding:
                SmoothResize(defaultSpriteSize);
                break;

            case ButtonState.Selected:
                SmoothResize(defaultSpriteSize * scaleExpandAmount);
                break;
        }
    }

    private void SmoothResize(Vector2 targetSize)
    {
        if (Mathf.Abs((rectTransform.sizeDelta - targetSize).magnitude) > 0.01f)
        {
            rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, targetSize, Time.deltaTime * scaleSpeed);
        }
    }

    public void UpdateSprite()
    {
        if (imageRenderer.sprite != pictogramSprite)
        {
            imageRenderer.sprite = pictogramSprite;
            imageRenderer.color = new Color(255,255,255,255);
            currentState = ButtonState.Selected;
        }
        else
        {
            imageRenderer.sprite = defaultSprite;
            imageRenderer.color = defaultSpriteColor;
            currentState = ButtonState.Expanding;
        }
    }
}
