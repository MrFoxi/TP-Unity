    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CactusGenerate : MonoBehaviour
    {
        public GameObject Spawn;
        public GameObject[] cactusArray;

         public float minDelay = 1f; 
        public float maxDelay = 2.5f;
        public float destructionTime = 10f;

        private List<GameObject> spawnedCacti = new List<GameObject>();
        private List<float> cactusSpawnTimes = new List<float>();


        
        void Start()
        {
            Invoke("a", Random.Range(minDelay, maxDelay));
            InvokeRepeating("CheckForOldCacti", 0f, 1f);
        }

        
        void Update()
        {
            
        }

        void a() {
            int randomIndex = Random.Range(0, cactusArray.Length);
            GameObject selectedCactus = cactusArray[randomIndex];

            Spawn = Instantiate(selectedCactus, transform.position,Quaternion.identity)as GameObject;

            spawnedCacti.Add(Spawn);
            cactusSpawnTimes.Add(Time.time);

            Invoke("a", Random.Range(minDelay, maxDelay));
        }

        void CheckForOldCacti() {
            for (int i = spawnedCacti.Count - 1; i >= 0; i--) {
                float spawnTime = cactusSpawnTimes[i];
                if (Time.time - spawnTime > destructionTime) {
                    Destroy(spawnedCacti[i]);
                    spawnedCacti.RemoveAt(i);
                    cactusSpawnTimes.RemoveAt(i);
                }
            }
        }
    }
