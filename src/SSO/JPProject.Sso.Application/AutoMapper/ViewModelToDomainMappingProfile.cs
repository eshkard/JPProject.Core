﻿using AutoMapper;
using JPProject.Sso.Application.ViewModels;
using JPProject.Sso.Application.ViewModels.EmailViewModels;
using JPProject.Sso.Application.ViewModels.RoleViewModels;
using JPProject.Sso.Application.ViewModels.UserViewModels;
using JPProject.Sso.Domain.Commands.Email;
using JPProject.Sso.Domain.Commands.Role;
using JPProject.Sso.Domain.Commands.User;
using JPProject.Sso.Domain.Commands.UserManagement;
using JPProject.Sso.Domain.Models;

namespace JPProject.Sso.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            /*
             * User Creation Commands
             */
            CreateMap<RegisterUserViewModel, RegisterNewUserCommand>().ConstructUsing(c => new RegisterNewUserCommand(c.Username, c.Email, c.Name, c.PhoneNumber, c.Password, c.ConfirmPassword, c.Birthdate, c.SocialNumber));
            CreateMap<SocialViewModel, RegisterNewUserWithoutPassCommand>(MemberList.Source).ConstructUsing(c => new RegisterNewUserWithoutPassCommand(c.Email, c.Email, c.Name, c.Picture, c.Provider, c.ProviderId));
            CreateMap<RegisterUserViewModel, RegisterNewUserWithProviderCommand>().ConstructUsing(c => new RegisterNewUserWithProviderCommand(c.Username, c.Email, c.Name, c.PhoneNumber, c.Password, c.ConfirmPassword, c.Picture, c.Provider, c.ProviderId, c.Birthdate.Date, c.SocialNumber));
            CreateMap<ForgotPasswordViewModel, SendResetLinkCommand>().ConstructUsing(c => new SendResetLinkCommand(c.UsernameOrEmail));
            CreateMap<ResetPasswordViewModel, ResetPasswordCommand>().ConstructUsing(c => new ResetPasswordCommand(c.Password, c.ConfirmPassword, c.Code, c.Email));
            CreateMap<ConfirmEmailViewModel, ConfirmEmailCommand>().ConstructUsing(c => new ConfirmEmailCommand(c.Code, c.Email));
            CreateMap<SocialViewModel, AddLoginCommand>().ConstructUsing(c => new AddLoginCommand(c.Email, c.Provider, c.ProviderId));

            /*
             * User Management commands
             */
            CreateMap<UserViewModel, UpdateProfileCommand>().ConstructUsing(c => new UpdateProfileCommand(c.Id, c.Url, c.Bio, c.Company, c.JobTitle, c.Name, c.PhoneNumber, c.SocialNumber, c.Birthdate));
            CreateMap<UserViewModel, UpdateUserCommand>().ConstructUsing(c => new UpdateUserCommand(c.Email, c.UserName, c.Name, c.PhoneNumber, c.EmailConfirmed, c.PhoneNumberConfirmed, c.TwoFactorEnabled, c.LockoutEnd, c.LockoutEnabled, c.AccessFailedCount));
            CreateMap<ProfilePictureViewModel, UpdateProfilePictureCommand>().ConstructUsing(c => new UpdateProfilePictureCommand(c.Id, c.Picture));
            CreateMap<ChangePasswordViewModel, ChangePasswordCommand>().ConstructUsing(c => new ChangePasswordCommand(c.Id, c.OldPassword, c.NewPassword, c.ConfirmPassword));
            CreateMap<SetPasswordViewModel, SetPasswordCommand>().ConstructUsing(c => new SetPasswordCommand(c.Id, c.NewPassword, c.ConfirmPassword));
            CreateMap<RemoveAccountViewModel, RemoveAccountCommand>().ConstructUsing(c => new RemoveAccountCommand(c.Id));
            CreateMap<SaveUserClaimViewModel, SaveUserClaimCommand>().ConstructUsing(c => new SaveUserClaimCommand(c.Username, c.Type, c.Value));
            CreateMap<RemoveUserClaimViewModel, RemoveUserClaimCommand>().ConstructUsing(c => new RemoveUserClaimCommand(c.Username, c.Type, c.Value));
            CreateMap<RemoveUserRoleViewModel, RemoveUserRoleCommand>().ConstructUsing(c => new RemoveUserRoleCommand(c.Username, c.Role));
            CreateMap<SaveUserRoleViewModel, SaveUserRoleCommand>().ConstructUsing(c => new SaveUserRoleCommand(c.Username, c.Role));
            CreateMap<RemoveUserLoginViewModel, RemoveUserLoginCommand>().ConstructUsing(c => new RemoveUserLoginCommand(c.Username, c.LoginProvider, c.ProviderKey));
            CreateMap<AdminChangePasswordViewodel, AdminChangePasswordCommand>().ConstructUsing(c => new AdminChangePasswordCommand(c.Password, c.ConfirmPassword, c.Username));


            /*
             * Role commands
             */
            CreateMap<RemoveRoleViewModel, RemoveRoleCommand>().ConstructUsing(c => new RemoveRoleCommand(c.Name));
            CreateMap<SaveRoleViewModel, SaveRoleCommand>().ConstructUsing(c => new SaveRoleCommand(c.Name));
            CreateMap<RemoveUserFromRoleViewModel, RemoveUserFromRoleCommand>().ConstructUsing(c => new RemoveUserFromRoleCommand(c.Role, c.Username));

            /*
             * Email commands
             */
            CreateMap<EmailViewModel, SaveEmailCommand>().ConstructUsing(c => new SaveEmailCommand(c.Content, c.Sender, c.Subject, c.Type, c.Bcc, c.Username));
            CreateMap<TemplateViewModel, SaveTemplateCommand>().ConstructUsing(c => new SaveTemplateCommand(c.Subject, c.Content, c.Name, c.Username));
            CreateMap<TemplateViewModel, UpdateTemplateCommand>().ConstructUsing(c => new UpdateTemplateCommand(c.OldName, c.Subject, c.Content, c.Name, c.Username));

        }
    }
}
