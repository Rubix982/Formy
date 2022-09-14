namespace StudentDataRecord.StudentDataRecord.Models.Interfaces
{
    internal interface IRepository<T>
    {
        public long? IndexCounter { get; set; }
        public void Add(T entity);

        public void DeleteByEntity(T entity);

        public void DeleteByIndex(int index);

        public List<T>? GetAll();

        public T? GetById(int id);
    }
}
