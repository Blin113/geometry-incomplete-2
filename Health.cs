using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Health
    {
        private float maxHealthPoints = 10;
        private float currentHealthPoints;

        public Health(float maxHealthPoints, float currentHealthPoints)
        {
            this.maxHealthPoints = maxHealthPoints;
            this.currentHealthPoints = currentHealthPoints;
        }

        public float HP
        {
            get => maxHealthPoints;
        }

        public float currentHP
        {
            get => currentHealthPoints;
            set => currentHealthPoints = value;
        }
    }
}
