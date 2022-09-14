using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Constants
{
    public class UserSocialMediaAddressMessages
    {
        public const string GithubUrlCanNotBeDuplicated = "Github address can not be duplicated";
        public const string UserNotFound = "User not found";
        public const string UserIdIsRequired = "User Id is required";
        public const string GithubUrlIsRequired = "Github Url is required";
        public const string UserSocialMediaAddressIsNotFound = "User Social Media Address is not found";
        public const string IdIsRequired = "Id is required";
        public const string GreaterThanZero = "Id must be greater than zero";
        public const string CanNotAddMultipleGithubAddresses = "Can not have more than one github address";
    }
}
