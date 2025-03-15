using BookMyHome.Application.Interfaces.ReposInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBookingRepository BookingRepository { get; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
