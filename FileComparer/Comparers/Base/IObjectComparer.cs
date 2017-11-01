namespace FileComparer.Comparers.Base {
    public interface IObjectComparer {
        bool Compare(object object1, object object2);
        object GetObject(string fileName);

    }
}