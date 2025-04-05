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
        IBookingRepository BookingRepository { get; }
        IAccommodationRepository AccommodationRepository { get; }
        IHostRepository HostRepository { get; }
        IGuestRepository GuestRepository { get; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
