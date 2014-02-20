using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class Command
    {
        //predefined commands
        private string getRepositoryCommits = "/repos/costea32/AutomationTraining/commits";
        public string GetRepositoryCommits { get { return this.getRepositoryCommits; } }

        private string getContributorsList = "/repos/costea32/AutomationTraining/stats/contributors";
        public string GetContributorsList { get { return this.getContributorsList; } }

    }
}
