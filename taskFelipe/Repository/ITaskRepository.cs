using taskFelipe.Data.ValueObject;


public interface ITaskRepository
{
    Task<IEnumerable<TaskVO>> GetFilter(int id, string Title,  int page);

    Task<IEnumerable<TaskVO>> GetAll();

    Task<TaskVO> Create(TaskVO vo);

    Task<TaskVO> Update(TaskVO vo);

    Task<bool> Delete(int id);

    Task<bool> Done(int id);
}
