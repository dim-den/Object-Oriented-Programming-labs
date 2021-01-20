using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab9
{
    class User
    {
        public delegate void SoftwareWork (int progress);
        public delegate void SoftwareUpgrade (double version);
        public event SoftwareWork OnWork;
        public event SoftwareUpgrade OnUpgrade;

        private int project_progress = 0;
        public int Progress
        {
            get => project_progress;
            set => project_progress = value;
        }
        private double project_version = 0;
        public double Version
        {
            get => project_version;
            set => project_version = value;
        }

        public User(double version) => this.project_version = version;
        public void Work(int progress)
        {
            Progress += progress;
            OnWork?.Invoke(progress);
        }

        public void Upgrade(double version)
        {
            OnUpgrade?.Invoke(version);
        }
    }
}
