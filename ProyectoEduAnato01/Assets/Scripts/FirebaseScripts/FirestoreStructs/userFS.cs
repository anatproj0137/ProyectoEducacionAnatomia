using Firebase.Firestore;
[FirestoreData]
public struct userFS
{
    [FirestoreProperty]
    public string userName { get; set; }
    [FirestoreProperty]
    public string userSurname { get; set; }
    [FirestoreProperty]
    public string userCI { get; set; }
    [FirestoreProperty]
    public string userEmail { get; set; }
    [FirestoreProperty]
    public string userPassword { get; set; }
}
