using VehiChoice.Data;
using VehiChoice.Models.Entities;
using VehiChoice.Repository.Interface;

namespace VehiChoice.Implementations.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DataContext _dataContext;

        public DepositRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Deposit Create(Deposit deposit)
        {
            _dataContext.Add(deposit);
            _dataContext.SaveChanges();
            return deposit;
        }

        public Deposit Get(string referenceNumber)
        {
            return _dataContext.Deposits.FirstOrDefault(x => x.ReferenceNumber == referenceNumber);
        }

        public List<Deposit> GetAll()
        {
            return _dataContext.Deposits.ToList();
        }

        public Deposit Update(string id, Deposit deposit)
        {
            var depositToUpdate = _dataContext.Deposits.FirstOrDefault(x => x.Id == id);
            if(depositToUpdate != null)
            {
                _dataContext.SaveChanges();
                return deposit;
            }
            return null;
        }
    }
}
