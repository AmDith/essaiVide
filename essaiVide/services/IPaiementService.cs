using Microsoft.AspNetCore.Mvc;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace essaiVide.services
{
    public interface IPaiementService
    {
        Task<Paiement> CreatePaiementAsync(Paiement paiement);
        Task<Paiement> Create(Paiement paiement);
    }
}
