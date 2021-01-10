using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomEventSystem : EventSystem
{
    private Selectable[] _selectables = default;
    private GameObject _previousSelectedObject = default;

    [SerializeField] private string _submitLabel = "Submit";
    [SerializeField] private string _cancelLabel = "Cancel";

    public bool IsSubmitButtonUp { get => Input.GetButtonUp(_submitLabel); }
    public bool IsCancelButtonUp { get => Input.GetButtonUp(_cancelLabel); }
    public static CustomEventSystem Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Initialize();
    }
    protected override void Start()
    {
        base.Start();

        SetSelectedObject(firstSelectedGameObject);
    }
    protected override void Update()
    {
        base.Update();

        if(IsCancelButtonUp)
        {
            SetSelectedObject(null);
        }

        if(currentSelectedGameObject != null) return;

        if(Input.anyKeyDown)
        {
            SetSelectedObject(_previousSelectedObject != null ? _previousSelectedObject : GetFirstActiveSelectedObject());
        }
    }

    private void Initialize()
    {
        _selectables = FindObjectsOfType<Selectable>();

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void SetSelectedObject(GameObject gameObject)
    {
        _previousSelectedObject = currentSelectedGameObject;

        SetSelectedGameObject(gameObject);
    }
    private GameObject GetFirstActiveSelectedObject()
    {
        foreach(var selectble in _selectables)
        {
            if(selectble.gameObject.activeInHierarchy)
            {
                return selectble.gameObject;
            }
        }

        return null;
    }
}
