using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityImage = UnityEngine.UI.Image;

public class XRFloatingPictogramButton : MonoBehaviour
{
    private Camera _camera;

    [Header("Pictogram Settings")]
    [SerializeField] private GameObject _imageObject;
    private RectTransform _rectTransform;
    private UnityImage _imageRenderer;

    [SerializeField] private Sprite _defaultSprite;
    private Vector2 _defaultSpriteSize;
    [SerializeField] private Sprite _pictogramSprite;
    [SerializeField] private float _resetDistance = 5f;

    [Header("Scaling")]
    [SerializeField] private float _scaleSpeed = 1f;
    [SerializeField] private float _scaleShrinkAmount = 2f;
    [SerializeField] private float _scaleExpandAmount = 2f;

    private enum ButtonState { Idle, Shrinking, Expanding, Selected }
    private ButtonState _currentState;

    private void Awake()
    {
        _camera = Camera.main;

        _rectTransform = _imageObject.GetComponent<RectTransform>();
        _imageRenderer = _imageObject.GetComponentInChildren<UnityImage>();

        _imageRenderer.sprite = _defaultSprite;
        _defaultSpriteSize = _rectTransform.sizeDelta;

        _currentState = ButtonState.Idle; // Start in Idle state
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = _camera.transform.position;
        transform.LookAt(new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z)); // Face camera, lock Y axis

        float distanceToCamera = Vector3.Distance(transform.position, cameraPosition);
        HandleStateTransitions(distanceToCamera);
        ExecuteStateLogic();
    }

    private void HandleStateTransitions(float distanceToCamera)
    {
        switch (_currentState)
        {
            case ButtonState.Idle:
                if (distanceToCamera < _resetDistance)
                {
                    _currentState = ButtonState.Expanding;
                }
                break;

            case ButtonState.Shrinking:
                if (distanceToCamera < _resetDistance)
                {
                    _currentState = ButtonState.Expanding;
                }
                break;

            case ButtonState.Expanding:
                if (distanceToCamera >= _resetDistance)
                {
                    _currentState = ButtonState.Shrinking;
                }
                break;

            case ButtonState.Selected:
                if (distanceToCamera >= _resetDistance)
                {
                    _currentState = ButtonState.Shrinking;
                }
                break;
        }
    }

    private void ExecuteStateLogic()
    {
        switch (_currentState)
        {
            case ButtonState.Idle:
                SmoothResize(_defaultSpriteSize / _scaleShrinkAmount);
                break;

            case ButtonState.Shrinking:
                _imageRenderer.sprite = _defaultSprite;
                SmoothResize(_defaultSpriteSize / _scaleShrinkAmount);
                break;

            case ButtonState.Expanding:
                SmoothResize(_defaultSpriteSize);
                break;

            case ButtonState.Selected:
                SmoothResize(_defaultSpriteSize * _scaleExpandAmount);
                break;
        }
    }

    private void SmoothResize(Vector2 targetSize)
    {
        if (Mathf.Abs((_rectTransform.sizeDelta - targetSize).magnitude) > 0.01f)
        {
            _rectTransform.sizeDelta = Vector2.Lerp(_rectTransform.sizeDelta, targetSize, Time.deltaTime * _scaleSpeed);
        }
    }

    public void UpdateSprite()
    {
        if (_imageRenderer.sprite != _pictogramSprite)
        {
            _imageRenderer.sprite = _pictogramSprite;
            _currentState = ButtonState.Selected;
        }
    }
}
