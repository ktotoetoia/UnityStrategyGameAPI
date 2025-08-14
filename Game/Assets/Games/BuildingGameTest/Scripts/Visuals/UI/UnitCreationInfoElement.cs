using Unity.Android.Gradle;
using UnityEngine.UIElements;

namespace BuildingsTestGame
{
    public class UnitCreationInfoElement : VisualElement
    {
        public IUnitInfo UnitInfo { get; set; }
        public IUnitCreatingComponent UnitCreatingComponent { get; set; }
        
        public void InitializeUI()
        {
            Button buildButton = new Button();
            Label unitNameLabel = new Label("UnitName");

            buildButton.clicked += () =>
            {
                UnitCreatingComponent.AddToQueue(UnitInfo);
            };
            
            Add(buildButton);
            Add(unitNameLabel);
            
            AddToClassList("buildActions");
            unitNameLabel.AddToClassList("unitName");
            
            unitNameLabel.text = UnitInfo.Name; 
        }
    }
}