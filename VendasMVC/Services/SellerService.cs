using System;
using VendasMVC.Models;

namespace VendasMVC.Services
{
	public class SellerService
	{
		private readonly VendasMVCContext _context;

		public SellerService(VendasMVCContext context)
		{
			_context = context;
		}


		public List<Seller> FindAll()
        {
			return _context.Seller.ToList();
        }
	}
}

