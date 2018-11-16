using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class UserInfo
    {

        public bool hasAdminRights { get; set; }

        public bool hasResearcherRights { get; set; }

        public bool hasParticipantRights { get; set; }

        public string userID { get; set; }

    }
}
