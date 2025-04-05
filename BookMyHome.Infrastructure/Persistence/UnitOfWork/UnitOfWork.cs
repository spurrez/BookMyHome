using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
using BookMyHome.Infrastructure.EntityFrameWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EntityFrameworkDBContext _dbContext;
        private IDbContextTransaction? _dbTransaction;
        public IBookingRepository BookingRepository { get; } // consider adding a generic base repository in the future
        public IAccommodationRepository AccommodationRepository { get; }
        public IHostRepository HostRepository { get; private set; }
        public IGuestRepository GuestRepository { get; private set; }


        public UnitOfWork
            (EntityFrameworkDBContext dbContext, 
            IBookingRepository bookingRepository,
            IAccommodationRepository accommodationRepository,
            IHostRepository hostRepository, 
            IGuestRepository guestRepository)
        {
            _dbContext = dbContext;
            BookingRepository = bookingRepository; // could add new constructors for different repositories
            AccommodationRepository = accommodationRepository;
            HostRepository = hostRepository;
            GuestRepository = guestRepository;

        }
        public async Task BeginTransactionAsync()
        {
            if (_dbTransaction != null)
                throw new InvalidOperationException("A transaction is already in progress");
            _dbTransaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_dbTransaction == null)
                throw new InvalidOperationException("No transactions has been started");
            await _dbTransaction.CommitAsync();
            await _dbTransaction.DisposeAsync();
            _dbTransaction = null;

        }

        public async Task RollbackTransactionAsync()
        {
            if (_dbTransaction == null)
                throw new InvalidOperationException("No transaction has been started");
            await _dbTransaction.RollbackAsync();
            await _dbTransaction.DisposeAsync();
            _dbTransaction = null;

        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
