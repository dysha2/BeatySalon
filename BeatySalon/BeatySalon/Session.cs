using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatySalon.Models;
using Microsoft.EntityFrameworkCore;

namespace BeatySalon
{
    public static class Session
    {
        private static BeautySalonContext _context;
        public static BeautySalonContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context=new BeautySalonContext();
                    _context.AttachedProducts.Load();
                    _context.Clients.Load();
                    _context.ClientServices.Load();
                    _context.DocumentByServices.Load();
                    _context.Genders.Load();
                    _context.Manufacturers.Load();
                    _context.Products.Load();
                    _context.ProductPhotos.Load();
                    _context.ProductSales.Load();
                    _context.Services.Load();
                    _context.ServicePhotos.Load();
                    _context.Tags.Load();
                    _context.TagOfClients.Load();
                }
                return _context;
            }
        }
        public static bool IsAdmin { get;set; }
    }
}
