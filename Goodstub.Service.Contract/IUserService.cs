using System.ServiceModel;
using Goodstub.Data.Entity;
using Goodstub.Data.Interface;
using System.ServiceModel.Web;

namespace Goodstub.Service.Contract
{
    [ServiceContract]
    [ServiceKnownType(typeof(User))]
    public interface IUserService
    {
        [OperationContract]
        void CreateUser(IUser user);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "MyJsonResource")]
        IUser GetByUsername(string username);

        [OperationContract]
        IUser GetByEmail(string email);
    }
}
