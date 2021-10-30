using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using TMPro;

public class FirestoreTest : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("TITLE FIELD")]
    public TMP_Text txtQuestionTitle;
    [Header("QUESTION FIELDS")]
    public TMP_Text txtAnswer1;
    public TMP_Text txtAnswer2;
    public TMP_Text txtAnswer3;
    public TMP_Text txtAnswer4;
    //
    string questionTitle;
    string answer1;
    string answer2;
    string answer3;
    string answer4;

    //
    bool loadedData = false;
    [SerializeField]
    bool nextQuestion = false;
    [SerializeField]
    int questionNumber = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetQuestionFromFirestore(1);
        //VALIDATION
        //if (nextQuestion)
        //{
        //    if (loadedData)
        //    {
        //        GetQuestionFromFirestore(questionNumber);
        //    }
        //}
    }
    void GetQuestionFromFirestore(int question)
    {
        Debug.Log("Intento");
        string questionID = question.ToString(); //convertir el valor a string
        string testPath = "questions/testConcept1/tests/question1";
        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document(testPath).GetSnapshotAsync().ContinueWith(task => 
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    var test = task.Result.ConvertTo<questionFS>();
                    questionTitle = test.questionTitle;
                    answer1 = test.correctAnswer;
                    answer2 = test.incorrectAnswer1;
                    answer3 = test.incorrectAnswer2;
                    answer4 = test.incorrectAnswer3;
                }
            }
        });
        if (answer1 != null && questionTitle != null)
        {
            SetDataInScene();
        }
    }
    void SetDataInScene()
    {
        txtQuestionTitle.text = questionTitle;
        txtAnswer1.text = answer1;
        txtAnswer2.text = answer2;
        txtAnswer3.text = answer3;
        txtAnswer4.text = answer4;
    }
}
