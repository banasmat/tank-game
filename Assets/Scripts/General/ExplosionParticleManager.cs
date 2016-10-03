using UnityEngine;

public class ExplosionParticleManager : ScriptableObject {

    private GameObject explosionParticleSystemPrefab;

    private Color particleColor = new Color(1, 1, 1, 1);

    #region Singleton
    private static readonly ExplosionParticleManager instance = ScriptableObject.CreateInstance(typeof(ExplosionParticleManager)) as ExplosionParticleManager;

    public static ExplosionParticleManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

	public void setColor(Color _color){
		particleColor = _color;
	}

	public void createExplosionParticleSystem(Transform _transform){

        if (null == explosionParticleSystemPrefab)
        {
            explosionParticleSystemPrefab = Resources.Load(PrefabContainer.EXPLOSION_PARTICLE_SYSTEM) as GameObject;
        }

        GameObject explosionParticleSystem = ObjectPoolManager.Instance.Retrieve (explosionParticleSystemPrefab, _transform.position, _transform.rotation);
		ParticleSystem _explosionParticleSystem = explosionParticleSystem.GetComponent<ParticleSystem> ();

		//TODO delegate to separate function, remove code duplication, move color to const
		_explosionParticleSystem.startColor = (particleColor);
		_explosionParticleSystem.Play ();
	}

}
