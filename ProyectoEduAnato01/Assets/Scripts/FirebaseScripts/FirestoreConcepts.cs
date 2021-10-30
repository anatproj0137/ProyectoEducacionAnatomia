using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using TMPro;

public class FirestoreConcepts : MonoBehaviour
{
    //SCENE
    [Header("FIELDS")]
    public TMP_Text txtTitle;
    public TMP_Text txtContent;

    //FROM FIRESTORE
    string title;
    string content;
    bool dataLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        GetFirestoreConcept();
    }

    // Update is called once per frame
    void Update()
    {
        //ORIGINAL
        if (!dataLoaded)
        {
            GetFirestoreConcept();
        }



    }
    //GET DATA FROM FIRESTORE
    void GetFirestoreConcept()
    {
        //ORIGINAL
        Debug.Log("Intento");
        string id = "HWQWJmMjaWEsLAwvjy2L";
        string conceptPath = "concepts/" + id;
        var firestore = FirebaseFirestore.DefaultInstance;
        firestore.Document(conceptPath).GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    var concept = task.Result.ConvertTo<conceptsFS>();
                    title = concept.title;
                    content = concept.content;
                }
            }
        });
        if (title != null && content != null)
        {
            SetDataInScene();
        }



    }
    //ESCRIBIR LOS DATOS DEL CONCEPTO EN LA PANTALLA
    void SetDataInScene()
    {
        txtTitle.text = title;
        txtContent.text = content;
        dataLoaded = true;
    }
}
