using System;
using TDS;
using TDS.SelectionSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace BuildingsTestGame
{
    public class BuildingGameUI : MonoBehaviour
    {
        [SerializeField] private MonoBehSelector _selector;
        private UIDocument _document;
        private Label _selectionName;

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            _selectionName = _document.rootVisualElement.Q<Label>("SelectionName");
            _selector.OnSelectionUpdated += x =>
            {
                if (x.First is IHaveName firstName)
                {
                    _selectionName.text = firstName.Name;
                }
            };
        }
    }
}