using System;
namespace MyRecipesLib.Model
{
    public struct Recipe
    {
        /**
         * <summary>
         *  The name of the recipe
         * </summary>
         */
        public string Title { get; set; }


        /**
         * <summary>
         *  The description of the recipe. Can be quite long.
         * </summary>
         *  @TODO Use markdown for the description.
         */
        public string Description { get; set; }

        /**
         * <summary>
         * How long to prepare ingredients in minutes
         * </summary>
         * */
        public int PreparationTime { get; set; }

        /**
         * <summary>
         * How long to cook the recipe
         * </summary>
         */
        public int CookingTime { get; set; }

        /**
         * <summary> 
         * Identifier of the recipe
         * </summary>
         */
        public int id { get; private set; }

        public List<RecipeStep> Steps { get; set; }




    }
}

