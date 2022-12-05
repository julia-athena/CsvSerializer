namespace SerializeMedia;

public interface IMedia<T>
{
    public IMedia<T> AddContentToMedia(T input);
    public string TranslateToString();
}