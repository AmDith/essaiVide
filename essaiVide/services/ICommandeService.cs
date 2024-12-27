using Microsoft.AspNetCore.Mvc;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace essaiVide.services
{
    public interface ICommandeService 
    {
        Task<Commande> Create(Commande commande);
        Task<Commande> CreateCommandeAsync(Commande commande);
    }
}
