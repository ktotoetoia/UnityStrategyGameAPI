using Unity.Android.Gradle;
using UnityEngine.UIElements;

namespace BuildingsTestGame
{
    [UxmlElement]
    public partial class UnitCreationInfoElement : VisualElement
    {
        private readonly Button _buildButton;
        private readonly Label _unitNameLabel;
        private readonly VisualElement _container;
        
        public IEntityInfo EntityInfo { get; set; }
        public IEntityCreationComponent EntityCreationComponent { get; set; }

        public UnitCreationInfoElement()
        {
            _buildButton = new Button();
            _unitNameLabel = new Label();
            _container = new VisualElement();

            Add(_container); 
            _container.Add(_buildButton);
            _container.Add(_unitNameLabel);
            
            AddToClassList("unitCreationInfoElement");
            _container.AddToClassList("unitCreationContainer");
            _unitNameLabel.AddToClassList("unitName");
            _buildButton.AddToClassList("buildButton");
            
            _unitNameLabel.text = "Unit Name";
            _buildButton.text = "Build";
        }

        public void InitializeUI()
        {
            _buildButton.clicked += () =>
            {
                EntityCreationComponent.AddToQueue(EntityInfo);
            };
            
            _unitNameLabel.text = EntityInfo.Name; 
        }
    }
}