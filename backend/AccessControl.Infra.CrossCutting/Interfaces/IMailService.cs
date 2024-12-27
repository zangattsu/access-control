using CinSaude.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
