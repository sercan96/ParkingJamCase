using System.Collections;
using Sounds;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject confetti;
        public GameObject level;
        
        public static int levelNumber = 1;
        
        public int currentLevel;
        public int totalLevelCount;

        [SerializeField] private TMP_Text levelText;
        private void Start()
        {
            OpenCurrentLevel();
        }

        private void OnEnable()
        {
            EventManager.OnGameWin += Confetti;
            EventManager.OnGameWin += IncreaseLevel;
        }

        private void OnDisable()
        {
            EventManager.OnGameWin -= Confetti;
            EventManager.OnGameWin -= IncreaseLevel;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        private void OpenCurrentLevel()
        {
            currentLevel = levelNumber;
            
            if (currentLevel > totalLevelCount)
            {
                levelNumber = 1;
                currentLevel = levelNumber;
                level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
            }
            else
            {
                level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
            }

            levelText.text = "Level : " + currentLevel;
        }

        private void Confetti()
        {
            confetti.SetActive(true);
            AudioManager.Instance.PlaySound(SoundName.Win);
        }
        
        private void IncreaseLevel()
        {
            levelNumber++;

            StartCoroutine(RestartScene());
        }

        private IEnumerator RestartScene()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
