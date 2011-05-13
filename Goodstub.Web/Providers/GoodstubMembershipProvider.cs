using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.Specialized;
using Goodstub.Service.Client;
using Goodstub.Data.Entity;
using Goodstub.Common;
using Goodstub.Data.Interface;

namespace Goodstub.Web.Providers
{
    public class GoodstubMembershipProvider : MembershipProvider
    {
        private NameValueCollection config = null;
        private string providerName = "GoodstubMembershipProvider";
        private int minRequiredPasswordLength = 6;
        private bool requiresUniqueEmail = true;

        internal object GetConfigValue(string configKey, object defaultValue)
        {
            return string.IsNullOrEmpty(this.config[configKey]) ? defaultValue : this.config[configKey];
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            UserServiceClient userProxy = new UserServiceClient();
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && !string.IsNullOrEmpty(GetUserNameByEmail(email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            MembershipUser membershipUser = GetUser(username, false);
            if (membershipUser == null)
            {
                string salt = Encryption.Hash.ComputeHash(new Guid().ToString(), System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.HashAlgorithm"], null);

                IUser user = new User
                {
                    UserRoleId = 1,
                    Username = username,
                    Email = email,
                    Password = Encryption.Rijndael.Encrypt(password,
                                    System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.PassPhrase"],
                                    salt,
                                    System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.HashAlgorithm"],
                                    Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.PasswordIterations"]),
                                    System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.InitVector"],
                                    Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.KeySize"])),
                    Salt = salt,
                    Firstname = string.Empty,
                    Lastname = string.Empty,
                    Enabled = true,
                    Registered = false,
                    RegistrationKey = Encryption.RandomPassword.Generate(30)
                };

                try
                {
                    userProxy.CreateUser(user);
                    status = MembershipCreateStatus.Success;
                }
                catch
                {
                    status = MembershipCreateStatus.ProviderError;
                    throw;
                }

                return GetUser(username, false);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            UserServiceClient userProxy = new UserServiceClient();
            MembershipUser membershipUser = null;

            try
            {
                IUser u = new User();

                IUser user = userProxy.GetByUsername(username);

                if (user != null)
                {
                    membershipUser = new MembershipUser(
                        providerName,
                        user.Username,
                        user.UserId,
                        user.Email,
                        string.Empty,
                        string.Empty,
                        user.Registered,
                        false,
                        DateTime.MinValue,
                        DateTime.UtcNow,
                        DateTime.MinValue,
                        DateTime.MinValue,
                        DateTime.MinValue
                        );

                    //user.LastActivityDateTime = DateTime.UtcNow;
                    userProxy.CreateUser(user);
                }
            }
            catch
            {
            }

            return membershipUser;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            string username = string.Empty;
            UserServiceClient userProxy = new UserServiceClient();

            IUser user = userProxy.GetByEmail(email);

            if (user != null)
            {
                username = user.Email;
            }

            return username;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            this.config = config;

            // Initialize the abstract base class.
            base.Initialize(name, this.config);

            minRequiredPasswordLength = Convert.ToInt32(GetConfigValue("minRequiredPasswordLength", minRequiredPasswordLength));
            requiresUniqueEmail = Convert.ToBoolean(GetConfigValue("requiresUniqueEmail", requiresUniqueEmail));
            providerName = Convert.ToString(GetConfigValue("providerName", providerName));
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return minRequiredPasswordLength;
            }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return requiresUniqueEmail;
            }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();

            //IUserRepository userRepository = new UserRepository();

            //User user = userRepository.GetByUsername(username);

            ////if (user != null)
            ////{
            ////    string passwordEncrypted = Encryption.Rijndael.Encrypt(password,
            ////                        System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.PassPhrase"],
            ////                        user.Salt,
            ////                        System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.HashAlgorithm"],
            ////                        Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.PasswordIterations"]),
            ////                        System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.InitVector"],
            ////                        Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["Encryption.KeySize"]));

            ////    if (user.Password.Equals(passwordEncrypted))
            ////    {
            ////        return true;
            ////    }
            ////}

            //return false;
        }
    }
}
