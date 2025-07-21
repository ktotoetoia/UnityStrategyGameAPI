using UnityEngine;
using UnityEngine.UIElements;

namespace BuildingsTestGame
{
    public class BuildingGameUI : MonoBehaviour
    {
        private UIDocument _document;
        private Label _unitLabel;
        private Label _terrainLabel;
        private Label _buildingLabel;
        private Label _stageLabel;
        private BuildingGame _game;

        public BuildingGame Game
        {
            get
            {
                return _game; 
            }
            set
            {
                _document ??= GetComponent<UIDocument>();
                _unitLabel ??= _document.rootVisualElement.Q<Label>("UnitLabel");
                _terrainLabel ??= _document.rootVisualElement.Q<Label>("TerrainLabel");
                _buildingLabel ??= _document.rootVisualElement.Q<Label>("BuildingLabel");
                _stageLabel ??= _document.rootVisualElement.Q<Label>("StageLabel");
                
                _game = value;
                _game.GameContext.Selector.OnSelected += () =>
                {
                    BuildingTerrain terrain = _game.GameContext.Selector.GetSelectionOfType<BuildingTerrain>().First;

                    if (terrain != null)
                    {
                        _terrainLabel.text = terrain.Name;
                        _buildingLabel.text = terrain.Building?.Name ?? "No Building";
                        _unitLabel.text = terrain.Unit?.Name ?? "No Unit";
                    }
                };
            }
        }

        public void Update()
        {
            if (Game != null)
            {
                if (Game.AssignStage == Game.TurnSwitcher.CurrentUser)
                {
                    _stageLabel.text = nameof(Game.AssignStage);
                }
                if (Game.BuildStage == Game.TurnSwitcher.CurrentUser)
                {
                    _stageLabel.text = nameof(Game.BuildStage);
                }
                if (Game.EventStage == Game.TurnSwitcher.CurrentUser)
                {
                    _stageLabel.text = nameof(Game.EventStage);
                }
            }
        }
    }
}