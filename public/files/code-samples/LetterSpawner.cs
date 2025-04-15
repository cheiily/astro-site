using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;
using GridLayout = Data.GridLayout;

namespace Letters {
    public class LetterSpawner : MonoBehaviour {
        public WordsDatabase wordsDb;
        public GridLayoutDatabase gridsDb;
        public LetterPrefabDict letterpointPrefabDict;
        // public float distBtwnPts = 50;
        public int numPts = 30;
        public int numRows = 4;
        public Vector2 padding = new Vector2(50, 50);
        // public Vector3 letterpointScale = new Vector3(1.5f, 1.75f, 2.0f);
        public float letterpointScale = 1.75f;
        public Vector2 randomOffsetMax = new Vector2(50, 50);
        public float randomScalingDiffMax = 0.5f;

        private Words chosenDict;
        private List<string> availableWords = new();
        private List<string> chosenWords = new();

        public void Start() {
            Camera _camera = Camera.main;

            Vector2 screenSize = new Vector2(Screen.width, Screen.height);

            chosenDict = wordsDb.GetRandomWords();
            availableWords = new List<string>(chosenDict.WordsArray);
            List<char> lettersCpy = new (chosenDict.Letters);

            int[] ptsPerRow = new int[numRows];
            int numXtra = numPts % numRows;
            for (int i = 0; i < numRows; ++i) {
                ptsPerRow[ i ] = numPts / numRows;
            }
            if ( numXtra > 0 ) {
                for (int i = 0; i < numRows; i+=2) {
                    if ( numXtra == 0 ) break;
                    ptsPerRow[ i ]++;
                    numXtra--;
                }
            }
            if ( numXtra > 0 ) {
                for (int i = 1; i < numRows; i+=2) {
                    if ( numXtra == 0 ) break;
                    ptsPerRow[ i ]++;
                    numXtra--;
                }
            }

            int maxInRow = ptsPerRow.Max();
            float distBtwnPts = (Screen.width - 2 * padding.x) / (maxInRow - 1);
            float distBtwnRows = (Screen.height - 2 * padding.y) / (numRows - 1);

            for (int yi = 0; yi < numRows; ++yi) {
                float y = 0.75f * padding.y + yi * distBtwnRows;
                for (int xi = 0; xi < ptsPerRow[ yi ]; ++xi) {
                    float x = padding.x + xi * distBtwnPts;
                    if ( ptsPerRow[ yi ] < maxInRow ) x += distBtwnPts / 2;

                    var pos = _camera.ScreenToWorldPoint(new Vector3(x + Random.Range(0, randomOffsetMax.x), y + Random.Range(0, randomOffsetMax.y), 0));
                    pos.z = 0;

                    if ( lettersCpy.Count == 0 ) lettersCpy = new(chosenDict.Letters);
                    char letter = lettersCpy[ Random.Range(0, lettersCpy.Count) ];
                    lettersCpy.Remove(letter);

                    var newLetter = Instantiate(letterpointPrefabDict.letters.Find(entry => entry.letter == letter).go, pos, transform.rotation);
                    newLetter.GetComponent<LetterPoint>().letter = letter;
                    var scalingRand = Random.Range(-randomScalingDiffMax, randomScalingDiffMax);
                    newLetter.transform.localScale = new Vector3(letterpointScale + scalingRand, letterpointScale + scalingRand, letterpointScale);
                    float randomZRotation = Random.Range(-20f, 20f);
                    Quaternion newRotation = Quaternion.Euler(0, 0, randomZRotation);
                    newLetter.transform.rotation = newRotation;
                }
            }
        }

        public List<string> ChooseThreeWords() {
            if ( chosenWords.Count == 0 ) {
                List<string> wrds = new List<string>();
                while ( availableWords.Count > 0 && wrds.Count < 3 ) {
                    var idx = Random.Range(0, availableWords.Count);
                    wrds.Add(availableWords[ idx ]);
                    availableWords.RemoveAt(idx);
                }

                chosenWords = wrds;
            }

            return chosenWords;
        }
    }
}