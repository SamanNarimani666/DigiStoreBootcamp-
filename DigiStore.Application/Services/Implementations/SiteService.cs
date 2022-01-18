﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiStore.Application.Convertors;
using DigiStore.Application.Security;
using DigiStore.Application.Services.Interfaces;
using DigiStore.Domain.Entities;
using DigiStore.Domain.IRepositories.ContactUs;
using DigiStore.Domain.IRepositories.SiteSetting;
using DigiStore.Domain.ViewModels.Contacts;

namespace DigiStore.Application.Services.Implementations
{
    public class SiteService : ISiteService
    {
        #region Contrcutor
        private readonly IContactUsRepository _contactUsRepository;
        private readonly ISiteSettingRepository _settingRepository;
        public SiteService(IContactUsRepository contactUsRepository, ISiteSettingRepository settingRepository)
        {
            _contactUsRepository = contactUsRepository;
            _settingRepository = settingRepository;
        }
        #endregion

        #region CreateContact
        public async Task<CreateContactResult> CreateContact(CreateContactUsViewModel createContactUs, string userIp)
        {
            var newContactUs = new ContactU()
            {
                Email = FixedText.FixEmail(createContactUs.Email.SanitizeText()),
                FullName = createContactUs.FullName.SanitizeText(),
                UserIp = userIp,
                Subject = createContactUs.Subject.SanitizeText(),
                Text = createContactUs.Text.SanitizeText()
            };
            try
            {
                await _contactUsRepository.AddContactUs(newContactUs);
                await _contactUsRepository.Save();
                return CreateContactResult.Success;
            }
            catch
            {
                return CreateContactResult.Error;
            }
        }
        #endregion

        #region GetDefaultSiteSetting
        public async Task<SiteSetting> GetDefaultSiteSetting()
        {
            return await _settingRepository.GetDefaultSiteSetting();
        }
        #endregion

        #region Dispose
        public async ValueTask DisposeAsync()
        {
            await _contactUsRepository.DisposeAsync();
            await _settingRepository.DisposeAsync();
        }
        #endregion

      
    }
}
