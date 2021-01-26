using UnityEngine;

namespace CustomUI.Selectables
{
    public class SelectableWorldHandler : MonoBehaviour
    {
        [SerializeField] private CustomButton _customButton = default;
        [SerializeField] private GameObject _selectionIndicator = default;

        private void Awake()
        {
            _customButton.OnSelect_Event.AddListener(ShowIndicator);
            _customButton.OnDeselect_Event.AddListener(HideIndicator);
        }

        private void OnDestroy()
        {
            _customButton.OnSelect_Event.RemoveListener(ShowIndicator);
            _customButton.OnDeselect_Event.RemoveListener(HideIndicator);
        }

        private void Start()
        {
            _selectionIndicator.SetActive(false);

            _customButton.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }

        private void ShowIndicator()
        {
            _selectionIndicator.SetActive(true);
        }

        private void HideIndicator()
        {
            _selectionIndicator.SetActive(false);
        }
    }
}