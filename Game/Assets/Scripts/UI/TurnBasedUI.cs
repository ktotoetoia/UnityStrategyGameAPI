using System;
using TDS.TurnSystem;
using UnityEngine;
using TDS.Worlds;
using UnityEngine.UIElements;

namespace TDS.UI
{
    public class TurnBasedUI : MonoBehaviour
    {
        [SerializeField] private UIDocument _document;
        private Label _nameLabel;
        
        private PlayerTurnLogic _player;

        public PlayerTurnLogic Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                Player.Selector.OnSelected += () =>
                {
                    if (Player.Selector.Selection.First.Object is IHaveName name)
                    {
                        _document.rootVisualElement.Q<Label>("NameLabel").text = name.Name;
                    }
                };
            }
        }
    }
}