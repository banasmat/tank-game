using UnityEngine;
using System.Collections;

public class ExplosionParticleManager : MonoBehaviour {

	public GameObject explosionParticleSystemPrefab;

	private Color particleColor;

	public ExplosionParticleManager(){
		// Setting defaults
		particleColor = new Color (1, 1, 1, 1);
	}

	public void setColor(Color _color){
		particleColor = _color;
	}

	public void createExplosionParticleSystem(Transform _transform){
		
		GameObject explosionParticleSystem = Instantiate (explosionParticleSystemPrefab, _transform.position, _transform.rotation) as GameObject;
		ParticleSystem _explosionParticleSystem = explosionParticleSystem.GetComponent<ParticleSystem> ();

		//TODO delegate to separate function, remove code duplication, move color to const
		_explosionParticleSystem.startColor = (particleColor);
		_explosionParticleSystem.Play ();
	}

}
