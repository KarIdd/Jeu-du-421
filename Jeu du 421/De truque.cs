using System;

namespace Jeu_du_421
{
    public class De_truque : De
    {
        private Random random = new Random();

        public override int Lancer()
        {
            int luck;
            luck = random.Next(1, 13);
            if (1 == luck)
            {
                return Face = random.Next(1, 5);
            }
            else if (luck == 2 || luck == 3)
            {
                return Face = 5;
            }
            else
            {
                return Face = 6;
            }
        }
    }
}
