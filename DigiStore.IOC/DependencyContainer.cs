﻿using DigiStore.Application.Security.PassWordHashing;
using DigiStore.Application.Senders;
using DigiStore.Application.Services.Implementations;
using DigiStore.Application.Services.Interfaces;
using DigiStore.Data.Context;
using DigiStore.Data.Repositories.Address;
using DigiStore.Data.Repositories.Ticket;
using DigiStore.Data.Repositories.User;
using DigiStore.Domain.IRepositories.Address;
using DigiStore.Domain.IRepositories.Ticket;
using DigiStore.Domain.IRepositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigiStore.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<DigiStore_DBContext>(option => { option.UseSqlServer(connectionString); });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketMessageRepository, TicketMessageRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddSingleton<IPasswordHelper, PasswordHelper>();
            services.AddSingleton<ISender, EmailSender>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITicketService,TicketService>();
            services.AddScoped<IAddressService,AddressService>();

        }
    }
}
