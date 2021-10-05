using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AttachGameObjectsToParticles : MonoBehaviour {
    public GameObject prefab;

    private ParticleSystem particleSystem;
    private List<GameObject> gameObjects = new List<GameObject>();
    private ParticleSystem.Particle[] particles;

    // Start is called before the first frame update
    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    // Update is called once per frame
    void LateUpdate() {
        int particleCount = particleSystem.GetParticles(particles);

        while (gameObjects.Count < particleCount) {
            GameObject instantiation = Instantiate(prefab, particleSystem.transform);
            gameObjects.Add(instantiation);
        }

        bool worldSpace = ( particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World );

        for (int i = 0; i < gameObjects.Count; i++) {
            gameObjects[i].transform.localScale = new Vector3(particles[i].startSize, particles[i].startSize, particles[i].startSize);
            if (i < particleCount) {
                if (worldSpace)
                    gameObjects[i].transform.position = particles[i].position;
                else
                    gameObjects[i].transform.localPosition = particles[i].position;
                gameObjects[i].SetActive(true);
            } else {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
