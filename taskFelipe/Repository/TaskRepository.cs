using AutoMapper;
using Microsoft.EntityFrameworkCore;
using taskFelipe.Data.ValueObject;
using taskFelipe.Model.Context;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace taskFelipe.Repository
{

    public class TaskRepository : ITaskRepository
    {

        private readonly MySQLContext _context;
        private IMapper _mapper;


        public TaskRepository(MySQLContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<TaskVO>> GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<List<TaskVO>>(tasks);
        }

        public async Task<IEnumerable<TaskVO>> GetFilter(int id, string Title, int page)
        {

            if (id > 0)
            {
                var task = await _context.Tasks.Where(x => x.Id == id).ToListAsync();
                return _mapper.Map<List<TaskVO>>(task);
            }

            else if (!string.IsNullOrEmpty(Title))
            {
                Title = "Atividade";
                var task = await _context.Tasks.Where(x => x.Title.Contains(Title)).ToListAsync();
                return _mapper.Map<List<TaskVO>>(task);

            }
            else if (page > 0)
            {
                var task = await _context.Tasks.Skip(0).Take(10).ToListAsync();
                return _mapper.Map<List<TaskVO>>(task);
            }

            return null;
        }


        public async Task<TaskVO> Update(TaskVO vo)
        {
            var task = _mapper.Map<Model.Task>(vo);
            task.updated_at = true;
            _context.Update(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskVO>(task);
        }

        public async Task<TaskVO> Create(TaskVO vo)
        {
            var task = _mapper.Map<Model.Task>(vo);
            task.completed_at = true;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskVO>(task);
        }


        public async Task<bool> Delete(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return false;
            _context.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Done(int id)
        {

            Model.Task task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return false;
            task.completed_at = true;
            _context.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }





    }
}
