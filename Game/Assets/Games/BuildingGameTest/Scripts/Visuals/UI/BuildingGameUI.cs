using System.Collections.Generic;
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
        private UnitCreationService _unitCreationService;
        private FactionTurnUser _factionStage;

        public FactionTurnUser FactionStage
        {
            get => _factionStage;
            set
            {
                _factionStage = value;
                
                _document = GetComponent<UIDocument>();
                _selectionName = _document.rootVisualElement.Q<Label>("SelectionTitleLabel");
                _listView = _document.rootVisualElement.Q<ListView>("SelectionListView");
                _unitCreationService = _factionStage.GetService<UnitCreationService>();
                
                SetOnSelectionUpdated();
            }
        }
        
        private void SetOnSelectionUpdated()
        {
            _selector.OnSelectionUpdated += x =>
            {
                if (!_unitCreationService.CanUse)
                {
                    _listView.itemsSource = new List<object>();
                    
                    return;
                }
                
                if (x.First is IEntity ent && ent.TryGetComponent(out IEntityCreationComponent creationComponent))
                {
                    _selectionName.text = ent.Name;
                    _listView.itemsSource = creationComponent.GetItemSource();
                    
                    _listView.makeItem = () => new UnitCreationInfoElement();
                    _listView.bindItem = (item, index) =>
                    {
                        UnitCreationInfoElement unitCreationInfoElement = item as UnitCreationInfoElement;
                        
                        unitCreationInfoElement.EntityInfo = _listView.itemsSource[index] as IEntityInfo;
                        
                        unitCreationInfoElement.InitializeUI(() => _unitCreationService.CreateUnit(creationComponent,_listView.itemsSource[index] as IEntityInfo));
                    };
                }
            };
        }
    }
}