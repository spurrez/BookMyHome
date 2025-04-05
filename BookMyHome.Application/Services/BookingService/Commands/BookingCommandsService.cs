using BookMyHome.Application.Interfaces.ReposInterfaces;
using BookMyHome.Application.Interfaces.UnitOfWork;
using BookMyHome.Application.Services.BookingService.Interfaces;
using BookMyHome.Domain.CustomException;
using BookMyHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Services.BookingService.Commands
{
    public class BookingCommandsService : IBookingCommands
    {

        private readonly IUnitOfWork _unitOfWork;
        public BookingCommandsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingBookings = await _unitOfWork.BookingRepository.GetAllBookings();

                if (booking.IsOverLapping(existingBookings))
                    throw new OverlappingBookingException();

                Booking newBooking = await _unitOfWork.BookingRepository.CreateBooking(booking);
                await _unitOfWork.CommitTransactionAsync(); // Perchance refactor to have SaveChanges() to commit method in UnitOfWork class in infrastructure
                return newBooking;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                Console.WriteLine("Rollback called");
                throw;
            }
        }

        public async Task<Booking> UpdateBooking(int id, Booking booking)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingBookings = await _unitOfWork.BookingRepository.GetAllBookings();

                if (booking.IsOverLapping(existingBookings))
                    throw new OverlappingBookingException();

                Booking updatedBooking = await _unitOfWork.BookingRepository.UpdateBooking(id, booking);
                await _unitOfWork.CommitTransactionAsync();
                return updatedBooking;

            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                Console.WriteLine("Rollback called");
                throw;
            }
        }

        public async Task<bool> DeleteBooking(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                bool isDeleted = await _unitOfWork.BookingRepository.DeleteBooking(id);
                await _unitOfWork.CommitTransactionAsync();
                return isDeleted;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
