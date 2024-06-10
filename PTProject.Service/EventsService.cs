using Task2Project.Data;

namespace Task2Project.Service
{
    public class EventsService
    {
        private IUnitOfWork _unitOfWork;

        public EventsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddEvent(Events evt)
        {
            _unitOfWork.EventRepository.Add(evt);
            _unitOfWork.Save();
        }

        public Events GetEvent(int id)
        {
            return _unitOfWork.EventRepository.GetById(id);
        }

        public void DeleteEvent(int id)
        {
            Events evt = _unitOfWork.EventRepository.GetById(id);
            if (evt != null)
            {
                _unitOfWork.EventRepository.Delete(evt);
                _unitOfWork.Save();
            }
        }
    }
}
