using TDS.SelectionSystem;
using TDS.Worlds;
using UnityEngine;
using UnityEngine.UIElements;

namespace BuildingsTestGame
{
    public class BuildingGameUI : MonoBehaviour
    {
        private UIDocument _document;
        private Label _unitName;
        private Label _terrainName;
        private Label _buildingName;
        private ISelector _selector;

        public ISelector Selector
        {
            get
            {
                return _selector; 
            }
            set
            {
                _document ??= GetComponent<UIDocument>();
                _unitName ??= _document.rootVisualElement.Q<Label>("UnitLabel");
                _terrainName ??= _document.rootVisualElement.Q<Label>("TerrainLabel");
                _buildingName ??= _document.rootVisualElement.Q<Label>("BuildingLabel");
                
                _selector = value;
                _selector.OnSelected += () =>
                {
                    BuildingTerrain terrain = _selector.GetSelectionOfType<BuildingTerrain>().First;

                    if (terrain != null)
                    {
                        _terrainName.text = terrain.Name;
                        _buildingName.text = terrain.Building?.Name ?? "No Building";
                        _unitName.text = terrain.Unit?.Name ?? "No Unit";
                    }
                };
            }
        } 
        
        private void Awake()
        {
            _document = GetComponent<UIDocument>();
        }
    }
}