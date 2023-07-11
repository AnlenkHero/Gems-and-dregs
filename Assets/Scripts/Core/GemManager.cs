using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "GemManager", menuName = "ScriptableObjects/GemManager", order = 1)]
    public class GemManager : ScriptableObject
    {
        private const int GEMS_IN_GAME = 3;

        public List<Gem> gems;

        private static GemManager instance;

        public static GemManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<GemManager>("Scriptable Objects/Gems/GemManager");
                }

                return instance;
            }
        }

        private void OnValidate()
        {
            ValidateGemsCount();
            ValidateUniqueNames();
        }

        private void ValidateGemsCount()
        {
            if (gems.Count != GEMS_IN_GAME)
                throw new ArgumentOutOfRangeException(nameof(gems),
                    $"There must be {GEMS_IN_GAME} gems in manager");
        }

        private void ValidateUniqueNames()
        {
            var names = gems.Select(gem => gem.gemName).ToList();
            var uniqueNames = new HashSet<string>(names);

            if (uniqueNames.Count != names.Count)
                throw new InvalidOperationException("All gem names must be unique");

        }
    }
}