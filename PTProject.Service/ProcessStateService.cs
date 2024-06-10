using Task2Project.Data;
using System;

namespace Task2Project.Service
{
    public class ProcessStateService : IProcessStateService
    {
        private IUnitOfWork _unitOfWork;
        private IGoodService _goodService;

        public ProcessStateService(IUnitOfWork unitOfWork, IGoodService goodService)
        {
            _unitOfWork = unitOfWork;
            _goodService = goodService;
        }

        public void AddProcessState(ProcessState processState)
        {
            _unitOfWork.ProcessStateRepository.Add(processState);
            _unitOfWork.Save();
        }

        public ProcessState GetProcessState(int id)
        {
            return _unitOfWork.ProcessStateRepository.GetById(id);
        }

        public void UpdateProcessState(ProcessState updatedProcessState, string eventType)
        {
            ProcessState processState = _unitOfWork.ProcessStateRepository.GetById(updatedProcessState.Id);
            if (processState != null)
            {
                Good good = _unitOfWork.GoodRepository.GetById(processState.Id);

                if (good != null)
                {
                    if (eventType == "Purchase")
                    {
                        if (_goodService.GetGoodById(good.Id) != null)
                        {
                            processState.Description = "Buy";
                            CreateEvent(updatedProcessState, "Purchase");

                            _unitOfWork.GoodRepository.Delete(good);
                        }
                        else
                        {
                            throw new Exception("Not enough quantity for purchase");
                        }
                    }
                    else if (eventType == "Return")
                    {
                        processState.Description = "Stock";
                        CreateEvent(updatedProcessState, "Return");

                        Good newGood = new Good
                        {

                            Name = good.Name,
                            Description = good.Description,
                            Price = good.Price,

                        };
                        _unitOfWork.GoodRepository.Add(newGood);
                    }

                    _unitOfWork.Save();
                }
            }
        }

        private void CreateEvent(ProcessState processState, string eventType)
        {
            Events evt = new Events
            {
                Description = $"ProcessState with ID {processState.Id} was updated to {eventType}",
                EventType = eventType,
            };

            EventsService eventsService = new EventsService(_unitOfWork);
            eventsService.AddEvent(evt);
        }

        public void DeleteProcessState(int id)
        {
            ProcessState processState = _unitOfWork.ProcessStateRepository.GetById(id);
            if (processState != null)
            {
                _unitOfWork.ProcessStateRepository.Delete(processState);
                _unitOfWork.Save();
            }
        }
    }
}
