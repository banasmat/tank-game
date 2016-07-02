using UnityEngine;
using System.Collections;

public class ExplosionParticleManager : MonoBehaviour {

	public GameObject explosionParticleSystemPrefab;

	private Color particleColor;

	private ObjectPoolManager objectPoolManager;

	public void Awake(){
		// Setting defaults
		particleColor = new Color (1, 1, 1, 1);

		objectPoolManager = GameObject.Find (NameContainer.OBJECT_POOL_MANAGER).GetComponent<ObjectPoolManager>();
		objectPoolManager.CreatePool (explosionParticleSystemPrefab, 5);
	}

	public void setColor(Color _color){
		particleColor = _color;
	}

	public void createExplosionParticleSystem(Transform _transform){
		
		GameObject explosionParticleSystem = objectPoolManager.Retrieve (explosionParticleSystemPrefab, _transform.position, _transform.rotation);
		ParticleSystem _explosionParticleSystem = explosionParticleSystem.GetComponent<ParticleSystem> ();

		//TODO delegate to separate function, remove code duplication, move color to const
		_explosionParticleSystem.startColor = (particleColor);
		_explosionParticleSystem.Play ();
	}

}
