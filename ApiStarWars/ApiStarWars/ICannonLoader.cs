namespace ApiStarWars
{
    public interface ICannonLoader { 
        /// <summary>
        /// Calculates the number of cannons to be deployed to a collection of heights. 
        /// </summary>
        /// <param name="heights">A collection of heights.</param>
        /// <returns>The number of cannons.</returns>
        int GetCannonCount(IReadOnlyList<uint> heights);
    } 

    
    
}