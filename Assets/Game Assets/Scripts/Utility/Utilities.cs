using UnityEngine;

namespace ArcheroCase.Utility
{
    public class Utilities
    {
        public static Transform GetClosestEnemy(Vector3 positionToCheck, float detectRadius, LayerMask enemyLayer)
        {
            var maxColliderCount = 5;
            
           var enemyColliders = new Collider[maxColliderCount];

            var enemyCountInRange =
                Physics.OverlapSphereNonAlloc(positionToCheck, detectRadius, enemyColliders,
                    enemyLayer, QueryTriggerInteraction.Collide);

            var distanceBetweenEnemy = detectRadius * detectRadius;
            Transform closestEnemy = null;
            for (int i = 0; i < enemyCountInRange; i++)
            {
                var currentEnemyTransform = enemyColliders[i].transform;
                var tempDistanceBetweenEnemy = (positionToCheck - currentEnemyTransform.position).sqrMagnitude;
                if (tempDistanceBetweenEnemy > distanceBetweenEnemy) continue;
                distanceBetweenEnemy = tempDistanceBetweenEnemy;
                closestEnemy = currentEnemyTransform;
            }

            return closestEnemy;
        }
        
        public static Transform GetClosestEnemy(Vector3 positionToCheck, float detectRadius, LayerMask enemyLayer, Transform ignoreEnemy)
        {
            var maxColliderCount = 5;
            
            var enemyColliders = new Collider[maxColliderCount];

            var enemyCountInRange =
                Physics.OverlapSphereNonAlloc(positionToCheck, detectRadius, enemyColliders,
                    enemyLayer, QueryTriggerInteraction.Collide);

            var distanceBetweenEnemy = detectRadius * detectRadius;
            Transform closestEnemy = null;
            for (int i = 0; i < enemyCountInRange; i++)
            {
                var currentEnemyTransform = enemyColliders[i].transform;
                if(currentEnemyTransform == ignoreEnemy) continue;
                var tempDistanceBetweenEnemy = (positionToCheck - currentEnemyTransform.position).sqrMagnitude;
                if (tempDistanceBetweenEnemy > distanceBetweenEnemy) continue;
                distanceBetweenEnemy = tempDistanceBetweenEnemy;
                closestEnemy = currentEnemyTransform;
            }

            return closestEnemy;
        }
    }
}