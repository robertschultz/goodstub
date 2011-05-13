using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Goodstub.Service.Contract;
using Goodstub.Data.Entity;
using Goodstub.Data.Interface;

namespace Goodstub.Service.Client
{
    public class UserServiceClient : IDisposable
    {
        private IUserService UserService = null;

        public UserServiceClient()
        {
            // TODO:
            // Perform a close on the CreateChannel call ; create custom ServiceChannel (i.e. UserServiceChannel) which inherits from IClientChannel
            ChannelFactory<IUserService> channelFactory = new ChannelFactory<IUserService>("BasicHttpBinding_IUserService");
            this.UserService = channelFactory.CreateChannel();
        }

        public IUser GetByUsername(string username)
        {
            return this.UserService.GetByUsername(username);
        }

        public IUser GetByEmail(string email)
        {
            return this.UserService.GetByEmail(email);
        }

        public void CreateUser(IUser user)
        {
            this.UserService.CreateUser(user);
        }

        public void Dispose()
        {
            ((IClientChannel)this.UserService).Close();
        }
    }
}
