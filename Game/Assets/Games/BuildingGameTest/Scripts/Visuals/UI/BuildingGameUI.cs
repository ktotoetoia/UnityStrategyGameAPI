using System;
using System.Collections.Generic;
using TDS;
using TDS.Entities;
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
        private ListView _listView;
        
        private void Awake()
        {
            _document = GetComponent<UIDocument>();
            _selectionName = _document.rootVisualElement.Q<Label>("SelectionTitleLabel");
            _listView = _document.rootVisualElement.Q<ListView>("SelectionListView");

            OnSelectionUpdated();
        }
        
        private void OnSelectionUpdated()
        {
            _selector.OnSelectionUpdated += x =>
            {
                if (x.First is IEntity ent && ent.TryGetComponent(out IEntityCreationComponent building))
                {
                    _selectionName.text = ent.Name;
                    _listView.itemsSource = building.GetItemSource();
                    
                    _listView.makeItem = () => new UnitCreationInfoElement();
                    _listView.bindItem = (item, index) =>
                    {
                        UnitCreationInfoElement unitCreationInfoElement = item as UnitCreationInfoElement;
                        
                        unitCreationInfoElement.EntityCreationComponent = building;
                        unitCreationInfoElement.EntityInfo = _listView.itemsSource[index] as IEntityInfo;
                        
                        unitCreationInfoElement.InitializeUI();
                    };
                }
            };
        }
    }
}