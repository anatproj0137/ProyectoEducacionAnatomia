using Firebase.Firestore;
[FirestoreData]
public struct conceptsFS 
{
    [FirestoreProperty]
    public string title { get; set; }
    [FirestoreProperty]
    public string content { get; set; }

}
