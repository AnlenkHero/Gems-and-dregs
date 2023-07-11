using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    [CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState", order = 1)]
    public class GameState : ScriptableObject
    {
        [FormerlySerializedAs("currentGem")]
        public Gem selectedGem; 
        public int selectedLevel; 
    }
}