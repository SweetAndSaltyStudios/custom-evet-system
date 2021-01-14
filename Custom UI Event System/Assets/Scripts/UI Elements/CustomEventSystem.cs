using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomEventSystem : EventSystem
{
    private GameObject _previousSelectedObject = default;
    private GameObject _currentSelectedGameObject_Recent = default;

    [Space]
    [Header("Axis References")]
    [SerializeField] private string _submitButtonAxisName = "Submit";
    [SerializeField] private string _cancelButtonAxisName = "Cancel";
    [SerializeField] private string _horizontalAxisName = "Horizontal";
    [SerializeField] private string _verticalAxisName = "Vertical";

    public bool IsSubmitButtonUp { get => Input.GetButtonUp(_submitButtonAxisName); }
    public bool IsCancelButtonUp { get => Input.GetButtonUp(_cancelButtonAxisName); }
    public static CustomEventSystem Instance { get; private set; }

    public bool HasAxisMovement { get { return currentInputModule.input.GetAxisRaw(_horizontalAxisName) != 0 || currentInputModule.input.GetAxisRaw(_verticalAxisName) != 0; } }

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

        if(currentSelectedGameObject != _currentSelectedGameObject_Recent)
        {
            _previousSelectedObject = _currentSelectedGameObject_Recent;
            _currentSelectedGameObject_Recent = currentSelectedGameObject;
        }

        if(HasAxisMovement == true)
        {
            SetSelectedGameObject(_previousSelectedObject != null ? _previousSelectedObject : GetFirstActiveSelectedObject());
        }
    }

    private void Initialize()
    {
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
