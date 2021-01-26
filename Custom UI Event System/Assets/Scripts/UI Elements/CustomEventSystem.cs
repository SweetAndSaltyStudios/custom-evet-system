using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(StandaloneInputModule))]
public class CustomEventSystem : EventSystem
{
    private GameObject _previousSelectedObject = default;
    private GameObject _currentSelectedGameObjectRecent = default;
    private StandaloneInputModule _standaloneInput = default;

    public bool HasAxisMovement 
    { 
        get =>
            currentInputModule.input.GetAxisRaw(_standaloneInput.horizontalAxis) != 0
            || 
            currentInputModule.input.GetAxisRaw(_standaloneInput.verticalAxis) != 0; 
    }

    public bool IsSubmitButtonUp { get => Input.GetButtonUp(_standaloneInput.submitButton); }
    public bool IsCancelButtonUp { get => Input.GetButtonUp(_standaloneInput.cancelButton); }
    public static CustomEventSystem Instance { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        Initialize();

    }
    protected override void Start()
    {
        base.Start();

        SetSelectedGameObject(firstSelectedGameObject);
    }
    protected override void Update()
    {
        base.Update();

        if(IsCancelButtonUp)
        {
            if(currentSelectedGameObject != null)
            { 
                _previousSelectedObject = currentSelectedGameObject;
            } 

            SetSelectedGameObject(null);
            return;
        }

        if(currentSelectedGameObject != null)
        {
            return;
        }

        if(currentSelectedGameObject != _currentSelectedGameObjectRecent)
        {
            _previousSelectedObject = _currentSelectedGameObjectRecent;
            _currentSelectedGameObjectRecent = currentSelectedGameObject;
        }

        if(HasAxisMovement == true)
        {
            SetSelectedGameObject(_previousSelectedObject != null ? _previousSelectedObject : GetFirstActiveSelectedObject());
        }
    }
    protected override void OnValidate()
    {
        base.OnValidate();

        if(_standaloneInput == null)
        {
            _standaloneInput = GetComponent<StandaloneInputModule>();
        }
    }

    private void Initialize()
    {
        _standaloneInput = GetComponent<StandaloneInputModule>();

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private GameObject GetFirstActiveSelectedObject()
    {
        foreach(var selectble in Selectable.allSelectablesArray)
        {
            if(selectble.gameObject.activeInHierarchy)
            {
                return selectble.gameObject;
            }
        }

        return null;
    }
}