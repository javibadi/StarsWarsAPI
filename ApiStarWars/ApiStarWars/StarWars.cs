using System.Reflection.Metadata.Ecma335;

namespace ApiStarWars
{
    public class CannonLoader : ICannonLoader
    {


        /// <summary>
        /// Funcion que obtiene el numero maximo de posibles cañones en la galaxia
        /// </summary>
        /// <param name="heights">Vector que contiene las posiciones y puntos maximos donde pueden instalarse los cañones</param>
        /// <returns>numero entero maximo de cañones</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public int GetCannonCount(IReadOnlyList<uint> heights)
        {
            if (heights == null)
            {
                throw new ArgumentNullException(nameof(heights));
            }

            int n = heights.Count;
            if (n == 0)
            {
                return 0;
            }

            int cannons = IsFeasible(heights);



            return cannons;
        }


        private static int IsFeasible(IReadOnlyList<uint> heights)
        {


            List<int> posicionesmaximos = new List<int>();
            //obtenervalores maximos de un vector 

            for (int i = 1; i < heights.Count - 1; i++)
            {
                if (heights[i] > heights[i - 1] && heights[i] > heights[i + 1])
                {
                    posicionesmaximos.Add(i);
                }
            }

            //comprobamos desde k= numero mayor de maximos en el vector d heights hasta k=1
            int k = posicionesmaximos.Count;

            for (int i = k; i > 0; i--)
            {
                if (IsposibleKcannons(k, posicionesmaximos))
                {
                    return k;
                }
                k--;

            }
            return k;

        }
        /// <summary>
        /// Funcion que devuelve true si es posible colocar k cañones
        /// </summary>
        /// <param name="k">numero ideal de cañones k</param>
        /// <param name="posicionesmaximos">vector de posiciones donde se encuentran los maximos</param>
        /// <returns></returns>
        private static bool IsposibleKcannons(int k, List<int> posicionesmaximos)
        {

            List<int> newvector = new List<int>();
            newvector.Add(posicionesmaximos[0]);
            int posnewector = 0;
            for (int i = 1; i < posicionesmaximos.Count; i++)
            {

                int distancia = Math.Abs(newvector[posnewector] - posicionesmaximos[i]);
                if (distancia >= k)
                {
                    newvector.Add(posicionesmaximos[i]);
                    posnewector += 1;

                }

            }
            if (newvector.Count >= k)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
