namespace GenericTask
{
    public abstract class GenericTestClassBase<T>
    {
        public T Params { get; set; }

        public abstract bool Equals(T param);
    }
}
