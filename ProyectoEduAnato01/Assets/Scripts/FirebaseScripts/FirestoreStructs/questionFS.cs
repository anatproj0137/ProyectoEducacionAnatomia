using Firebase.Firestore;
[FirestoreData]
public struct questionFS
{
    [FirestoreProperty]
    public string questionTitle { get; set; }
    [FirestoreProperty]
    public string correctAnswer { get; set; }
    [FirestoreProperty]
    public string incorrectAnswer1 { get; set; }
    [FirestoreProperty]
    public string incorrectAnswer2 { get; set; }
    [FirestoreProperty]
    public string incorrectAnswer3 { get; set; }

}
