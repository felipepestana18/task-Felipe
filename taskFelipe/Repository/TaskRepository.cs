using taskFelipe.Data.ValueObject;

namespace taskFelipe.Repository 
{

    public class TaskRepository : ITaskRepository
    {
        Task<TaskVO> ITaskRepository.Create(TaskVO vo)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITaskRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITaskRepository.Done(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TaskVO>> ITaskRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<TaskVO> ITaskRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<TaskVO> ITaskRepository.Update(TaskVO vo)
        {
            throw new NotImplementedException();
        }
    }
}
