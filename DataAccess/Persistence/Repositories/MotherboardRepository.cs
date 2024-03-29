﻿using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class MotherboardRepository : IMotherboardRepository
    {
        private readonly ApplicationDbContext _context;

        public MotherboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Motherboard> GetMotherboardsThatMatchTheSocket(string socketType)
        {
            if (socketType == null)
                throw new ArgumentNullException(nameof(socketType));

            IQueryable<Motherboard> filteredMotherboards = _context.Motherboards
                .Include(m => m.Company)
                .Where(m => m.Socket == socketType);

            return filteredMotherboards;
        }

        public IQueryable<Motherboard> GetAll()
        {
            return _context.Motherboards.Include(m => m.Company);
        }

        public Motherboard GetById(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            return _context.Motherboards
                .Include(c => c.Company)
                .FirstOrDefault(c => c.ID == ID);
        }

        public void Create(Motherboard motherboard)
        {
            if (motherboard == null)
                throw new ArgumentNullException(nameof(motherboard));

            _context.Motherboards.Add(motherboard);
        }

        public void Update(Motherboard motherboard)
        {
            if (motherboard == null)
                throw new ArgumentNullException(nameof(motherboard));

            _context.Entry(motherboard).State = EntityState.Modified;
        }

        public void Delete(int? ID)
        {
            if (ID == null)
                throw new ArgumentNullException(nameof(ID));

            Motherboard motherboard = _context.Motherboards.Find(ID);

            if (motherboard == null)
                throw new Exception("Motherboard not found");

            _context.Motherboards.Remove(motherboard);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
