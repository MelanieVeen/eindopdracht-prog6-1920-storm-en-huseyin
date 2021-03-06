﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeestjeOpJeFeestje.Data;
using Microsoft.EntityFrameworkCore;

namespace BeestjeOpJeFeestje.Models.Repositories
{
	public class BookingDBRepository : IRepository<Booking>
	{
		private readonly BeestjeOpJeFeestjeContext _context;

		public BookingDBRepository(BeestjeOpJeFeestjeContext context)
		{
			_context = context;
		}

		public async Task<Booking> Get(int? ID)
		{
			return await _context.Booking.Where(e => e.ID == ID).Include(e => e.BookingAccessories)
				.ThenInclude(ba => ba.Accessories)
				.Include(e => e.BookingAnimals)
				.ThenInclude(ba => ba.Animal)
				.Include(e => e.ClientInfo)
				.FirstOrDefaultAsync();
		}

		public async Task<List<Booking>> GetAll()
		{
			return await _context.Booking.Include(e => e.BookingAccessories)
				.ThenInclude(ba => ba.Accessories)
				.Include(e => e.BookingAnimals)
				.ThenInclude(ba => ba.Animal)
				.Include(e => e.ClientInfo)
				.ToListAsync();
		}

		public Task<List<Booking>> Find(params int[] keyValues)
		{
			throw new NotImplementedException();
		}

		public async Task Create(Booking type)
		{
			_context.Booking.Add(type);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Booking type)
		{
			_context.Update(type);
			_context.Entry(type).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Booking type)
		{
			_context.Booking.Remove(type);
			await _context.SaveChangesAsync();
		}

		public bool Exists(int? ID)
		{
			return _context.Booking.Any(e => e.ID == ID);
		}

		public bool Exists(Booking type)
		{
			return _context.Booking.Any(b => b.Date == type.Date);
		}

		public async Task<Booking> GetFromDate(DateTime bookingDate)
		{
			return await _context.Booking.Where(b => b.Date == bookingDate).Include(b => b.BookingAnimals)
				.FirstOrDefaultAsync();
		}
	}
}