using UnityEngine;
using EnemyNameSpace;

namespace ScoreNameSpace
{
    public class EnemyHealth : Health
    {
        [SerializeField] private int scoreValue = 10; // Очки за уничтожение врага

        protected override void Die()
        {
            ScoreManager.Instance.AddScore(scoreValue);
            base.Die();
        }
    }
}
