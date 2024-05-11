using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    [CreateAssetMenu(fileName = "Obstacle Data", menuName = "Obstacle Data")]
    public class ObstacleData : ScriptableObject
    {
        public List<Obstacle> SingleObstacles;
        public List<Obstacle> TwiceObstacles;

        public Obstacle GetRandomObstacle()
        {
            return SingleObstacles[Random.Range(0, SingleObstacles.Count)];
        }
        
        public Obstacle GetRandomTwiceObstacle()
        {
            return TwiceObstacles[Random.Range(0, TwiceObstacles.Count)];
        }
    }
}